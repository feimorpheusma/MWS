using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MWS.Services;
using System.Collections.ObjectModel;
using DispCore.Models;
using System.Collections.Specialized;
using org.doubango.tinyWRAP;

namespace MWS
{
    public partial class MainForm : Form
    {
        #region menu buttons

        private static IList<MenuInfo> MenuList;

        private static int CurrentWainingId = 0;

        #endregion

        #region variables

        ObservableCollection<MyAVSession> sessions;
        bool[] isVideoViewAttached;
        MyAVSession[] sessionAttached2VideoView;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            initializeMenu();
            initAvatar();
            initializeUser();
            initializeCamera();
            initializeLayout();

            sessions = new ObservableCollection<MyAVSession>();
            isVideoViewAttached = new bool[2] { false, false };
            sessionAttached2VideoView = new MyAVSession[2] { null, null };

            Win32ServiceManager.SharedManager.ServiceRealizeService.AvSessionMgr.Sessions.CollectionChanged
                        += OnAvSessionsCollectionChanged;
        }

        public void OnAvSessionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            MyAVSession avSession;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object item in e.NewItems)
                    {
                        avSession = (MyAVSession)item;

                        sessions.Insert(0, avSession);

                        txtStatus.Text = avSession.Code + "\r\n" + txtStatus.Text;

                        if ((avSession.MediaType & DispCore.MediaType.Video) == DispCore.MediaType.Video)
                        {
                            if (!isVideoViewAttached[0])
                            {
                                avSession.MediaSessionMgr.consumerSetInt64(twrap_media_type_t.twrap_media_video, "remote-hwnd", (Int64)pnlVideo1.Handle);
                            }
                            else if (!isVideoViewAttached[1])
                            {
                                avSession.MediaSessionMgr.consumerSetInt64(twrap_media_type_t.twrap_media_video, "remote-hwnd", (Int64)pnlVideo2.Handle);
                            }
                        }


                        //avSession.PropertyChanged += OnAvSessionPropertyChanged;
                        /* play incoming call ring tone */
                        Win32ServiceManager.SharedManager.SoundService.PlayTone(DispCore.Services.Tone.TONE_RING, true, avSession.Id);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object item in e.OldItems)
                    {
                        avSession = (MyAVSession)item;
                        sessions.Remove(avSession);

                        // @TODO: 根据sessions更新datagridview的内容
                    }
                    break;
            }
        }

        public void OnAvSessionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MyAVSession avSession = (MyAVSession)sender;

            if ((e.PropertyName == "State") && (avSession.State == InviteState.INCALL))
            {
                if ((avSession.MediaType & DispCore.MediaType.Video) == DispCore.MediaType.Video)
                {

                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var menu = MenuList.FirstOrDefault(m => m.Name == ((Button)sender).Text);

            if (menu.Type == "link")
            {
                this.pnlContainer.Controls.Add(this.webBrowser);
                this.pnlContainer.Controls.Remove(this.pnlIntercom);
                this.pnlContainer.Controls.Remove(this.pnlMinitor);
                webBrowser.Url = new Uri(menu.Parameter);
            }
            else if (menu.Type == "button")
            {
                switch (menu.Code)
                {
                    case "jkdj":

                        this.pnlContainer.Controls.Add(this.pnlIntercom);
                        this.pnlContainer.Controls.Remove(this.pnlMinitor);
                        this.pnlContainer.Controls.Remove(this.webBrowser);

                        break;
                    case "swjk":

                        this.pnlContainer.Controls.Add(this.pnlMinitor);
                        this.pnlContainer.Controls.Remove(this.pnlIntercom);
                        this.pnlContainer.Controls.Remove(this.webBrowser);
                        break;
                    default:
                        break;
                }
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void lbUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem;
            if (selectedItem != null)
            {
                Win32ServiceManager.SharedManager.ServiceRealizeService.VideoCall(selectedItem.ToString());
            }
        }

        private void lbCameras_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void cbxLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateCameraPanel();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            generateCameraPanel();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Warning.xml");
            var nodes = xmlDoc.SelectSingleNode("root").ChildNodes;

            foreach (var node in nodes)
            {
                var xe = (XmlElement)node;
                var NO = xe.GetAttribute("NO");
                var status = xe.GetAttribute("status");
                if (status == "0")
                {
                    //TODO: add vedio screen
                    CurrentWainingId = int.Parse(xe.GetAttribute("id"));
                    this.Controls.Add(this.pnlMask);
                    this.pnlMask.BringToFront();
                    this.timer.Enabled = false;
                }

            }
        }

        private void btnCloseWarningMask_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(this.pnlMask);
            this.timer.Enabled = true;
        }

        private void btnCloseWarning_Click(object sender, EventArgs e)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Warning.xml");
            var nodes = xmlDoc.SelectSingleNode("root").ChildNodes;

            foreach (var node in nodes)
            {
                var xe = (XmlElement)node;
                var id = int.Parse(xe.GetAttribute("id"));
                if (id == CurrentWainingId)
                {
                    xe.SetAttribute("status", "1");
                    break;
                }

            }
            this.Controls.Remove(this.pnlMask);
            this.timer.Enabled = true;
            xmlDoc.Save("Warning.xml");

        }



        #region private methods

        private void initializeMenu()
        {

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Data.xml");
            var nodes = xmlDoc.SelectSingleNode("root/menu").ChildNodes;

            var menuWidth = 78 * nodes.Count;
            this.pnlMenu.Size = new System.Drawing.Size(120 + menuWidth, 73);
            this.pbxAvatar.Location = new System.Drawing.Point(12 + menuWidth, 12);
            this.btnLogout.Location = new System.Drawing.Point(70 + menuWidth, 25);

            MenuList = new List<MenuInfo>();

            var index = 1;
            foreach (var node in nodes)
            {
                var xe = (XmlElement)node;

                var menu = new MenuInfo();
                menu.Name = xe.GetAttribute("name");
                menu.Code = xe.GetAttribute("code");
                menu.Type = xe.GetAttribute("type");
                menu.Parameter = xe.GetAttribute("parameter");
                MenuList.Add(menu);

                generateMenuButton(index, menu);
                index++;
            }
        }

        private void initializeUser()
        {

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Data.xml");
            var nodes = xmlDoc.SelectSingleNode("root/user").ChildNodes;

            var userList = new List<UserInfo>();
            foreach (var node in nodes)
            {
                var xe = (XmlElement)node;
                var user = new UserInfo();
                user.Name = xe.GetAttribute("name");
                user.NO = xe.GetAttribute("NO");
                userList.Add(user);
            }
            lbUsers.DataSource = userList;
            lbUsers.DisplayMember = "Name";
            lbUsers.ValueMember = "NO";
        }

        private void initializeCamera()
        {

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Data.xml");
            var nodes = xmlDoc.SelectSingleNode("root/camera").ChildNodes;

            var cameraList = new List<CameraInfo>();
            foreach (var node in nodes)
            {
                var xe = (XmlElement)node;
                var camera = new CameraInfo();
                camera.Name = xe.GetAttribute("name");
                camera.NO = xe.GetAttribute("NO");
                cameraList.Add(camera);
            }

            lbCameras.DataSource = cameraList;
            lbCameras.DisplayMember = "Name";
            lbCameras.ValueMember = "NO";
        }

        private void initializeLayout()
        {

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Data.xml");
            var nodes = xmlDoc.SelectSingleNode("root/layout").ChildNodes;

            var layoutList = new List<LayoutInfo>();
            foreach (var node in nodes)
            {
                var xe = (XmlElement)node;
                var layout = new LayoutInfo();
                layout.Name = xe.GetAttribute("name");
                layout.Value = xe.GetAttribute("value");
                layoutList.Add(layout);
            }
            cbxLayout.DataSource = layoutList;
            cbxLayout.DisplayMember = "Name";
            cbxLayout.ValueMember = "Value";
        }

        private void generateMenuButton(int index, MenuInfo menu)
        {

            var button = new Button();
            button.BackColor = System.Drawing.Color.Transparent;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(52)))), ((int)(((byte)(43)))));
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            button.ForeColor = System.Drawing.Color.White;
            button.Image = global::MWS.Properties.Resources.ResourceManager.GetObject("menu_" + menu.Code) as Bitmap;

            button.Location = new System.Drawing.Point((index - 1) * 78, 4);
            button.Name = "btnMenu" + index;
            button.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            button.Size = new System.Drawing.Size(78, 64);
            button.TabIndex = 1;
            button.Text = menu.Name;
            button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button.UseVisualStyleBackColor = false;

            button.Click += new System.EventHandler(this.btnMenu_Click);

            pnlMenu.Controls.Add(button);
        }

        private void initAvatar()
        {
            System.Drawing.Bitmap bitmap = global::MWS.Properties.Resources.avatar;
            for (int y = 0; y < 50; y++)//假设图片已经处理为100*100像素
            {
                for (int x = 0; x < 50; x++)
                {
                    if ((x - 25) * (x - 25) + (y - 25) * (y - 25) > 25 * 25)//圆标准方程
                    {
                        //将圆以外的点设为透明
                        bitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(0, 255, 255, 255));
                    }
                }
            }
            pbxAvatar.Image = bitmap;
        }


        private void generateCameraPanel()
        {
            var margin = 10;
            var count = int.Parse((cbxLayout.SelectedItem as LayoutInfo).Value.Split('-')[0]);
            var row = int.Parse((cbxLayout.SelectedItem as LayoutInfo).Value.Split('-')[1]);
            var width = (pnlCameraContainer.Width - (row + 1) * margin) / row;
            var height = width / 4 * 3;
            var startX = margin;
            var startY = margin;

            foreach (Panel item in pnlCameraContainer.Controls)
            {
                if (int.Parse(item.Name.Replace("pnlCamera", "")) >= count)
                {
                    item.Hide();
                }
            }

            for (int i = 0; i < count; i++)
            {
                var x = startX + (i % row) * (width + margin);
                var y = startY + (i / row) * (height + margin);

                var control = pnlCameraContainer.Controls.Find("pnlCamera" + i, false);
                if (control.Length == 0)
                {
                    var panel = new Panel();

                    panel.BackgroundImage = global::MWS.Properties.Resources.bg_video;
                    panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    panel.Location = new System.Drawing.Point(x, y);
                    panel.Name = "pnlCamera" + i;
                    panel.Size = new System.Drawing.Size(width, height);
                    panel.TabIndex = 0;

                    this.pnlCameraContainer.Controls.Add(panel);
                }
                else
                {
                    var panel = control[0];
                    panel.Size = new System.Drawing.Size(width, height);
                    panel.Location = new System.Drawing.Point(x, y);
                }

            }
        }

        #endregion


    }


}
