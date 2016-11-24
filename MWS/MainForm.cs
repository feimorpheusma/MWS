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
using System.Configuration;

namespace MWS
{
    public partial class MainForm : Form
    {
        #region menu buttons

        private static IList<MenuInfo> MenuList;

        private static int CurrentWainingId = 0;

        #endregion

        #region variables

        public string CurrentUser { get; set; }

        ObservableCollection<MyAVSession> sessions;
        bool[] isVideoViewAttached;
        MyAVSession[] attachedVideoSessions;

        MyAVSession currentVedioSession;
        Panel currentVedioPanel;

        List<CameraInfo> currentCameras;

        Dictionary<Panel, MonitorInfo> cameraPanelGroup;


        bool isPollCall = false;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            initializeMenu();
            initializetAvatar();
            initializeUser();
            initializeCamera();
            initializeLayout();

            CheckForIllegalCrossThreadCalls = false;

            this.Text = ConfigurationManager.AppSettings["SystemName"];
            lblTitle.Text = ConfigurationManager.AppSettings["SystemName"];

            cameraPanelGroup = new Dictionary<Panel, MonitorInfo>();
            this.lbCameras.SelectedItems.Clear();

            sessions = new ObservableCollection<MyAVSession>();
            isVideoViewAttached = new bool[2] { false, false };
            attachedVideoSessions = new MyAVSession[2] { null, null };

            Win32ServiceManager.SharedManager.ServiceRealizeService.AvSessionMgr.Sessions.CollectionChanged
                        += OnAvSessionsCollectionChanged;
            Win32ServiceManager.SharedManager.StatusService.OnlineCalls.CollectionChanged
                        += OnOnlineCallsCollectionChanged;

        }

        public void OnOnlineCallsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            MyAVSession avSession;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object item in e.NewItems)
                    {
                        avSession = (MyAVSession)item;


                        if (isPollCall == true)
                        {
                            currentVedioSession = avSession;
                            attachSessionToPanel();
                            isPollCall = false;
                        }
                        else
                        {
                            currentVedioSession = avSession;

                            sessions.Insert(0, avSession);
                            avSession.PropertyChanged += OnAvSessionPropertyChanged;
                            Win32ServiceManager.SharedManager.SoundService.PlayTone(DispCore.Services.Tone.TONE_RING, true, avSession.Id);

                            if (avSession.State == InviteState.INCOMING)
                            {
                                txtStatus.Text = DateTime.Now.ToString() + " 新来电,请接听..." + "\r\n" + txtStatus.Text;
                            }
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object item in e.OldItems)
                    {
                        avSession = (MyAVSession)item;
                        sessions.Remove(avSession);
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    sessions.Clear();
                    break;
                default:
                    break;
            }
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


                        if (isPollCall == true)
                        {
                            currentVedioSession = avSession;
                            attachSessionToPanel();
                            isPollCall = false;
                        }
                        else
                        {
                            currentVedioSession = avSession;

                            sessions.Insert(0, avSession);
                            avSession.PropertyChanged += OnAvSessionPropertyChanged;
                            Win32ServiceManager.SharedManager.SoundService.PlayTone(DispCore.Services.Tone.TONE_RING, true, avSession.Id);

                            if (avSession.State == InviteState.INCOMING)
                            {
                                txtStatus.Text = DateTime.Now.ToString() + " 新来电,请接听..." + "\r\n" + txtStatus.Text;
                            }
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object item in e.OldItems)
                    {
                        avSession = (MyAVSession)item;
                        sessions.Remove(avSession);
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    sessions.Clear();
                    break;
                default:
                    break;
            }
        }

        public void OnAvSessionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var session = (MyAVSession)sender;

            if (e.PropertyName == "State")
            {
                txtStatus.Text = DateTime.Now.ToString() + " " + getSessionState(session.State, session.Code) + "\r\n" + txtStatus.Text;


                if (session.State == InviteState.INCALL)
                {
                    attachSessionToPanel();
                }
                if (session.State == InviteState.TERMINATED)
                {

                }
            }

            this.OnPropertyChanged(e.PropertyName);
        }

        private void btnAnswer1_Click(object sender, EventArgs e)
        {
            if (currentVedioSession != null)
            {
                attachedVideoSessions[0] = currentVedioSession;
                isVideoViewAttached[0] = true;
                currentVedioPanel = pnlVideo1;
                Win32ServiceManager.SharedManager.ServiceRealizeService.AcceptCall(attachedVideoSessions[0].Id);
                Win32ServiceManager.SharedManager.SoundService.StopPlay(DispCore.Services.Tone.TONE_RING, attachedVideoSessions[0].Id);
                btnAnswer1.Hide();
            }
            else
            {
                MessageBox.Show("目前没有来电");
            }

        }

        private void btnHangup1_Click(object sender, EventArgs e)
        {
            if (attachedVideoSessions[0] != null)
            {
                Win32ServiceManager.SharedManager.SoundService.StopPlay(attachedVideoSessions[0].Id);
                if (!Win32ServiceManager.SharedManager.ServiceRealizeService.ReleaseCall(attachedVideoSessions[0].Id))
                {
                    MessageBox.Show("挂断失败");
                }
                btnAnswer1.Show();
                btnHangup1.Show();
                isVideoViewAttached[0] = false;
                attachedVideoSessions[0] = null;
            }
            else
            {
                MessageBox.Show("目前没有来电");
            }
        }

        private void btnAnswer2_Click(object sender, EventArgs e)
        {
            if (currentVedioSession != null)
            {
                attachedVideoSessions[1] = currentVedioSession;
                isVideoViewAttached[1] = true;
                currentVedioPanel = pnlVideo2;
                Win32ServiceManager.SharedManager.ServiceRealizeService.AcceptCall(attachedVideoSessions[1].Id);
                Win32ServiceManager.SharedManager.SoundService.StopPlay(DispCore.Services.Tone.TONE_RING, attachedVideoSessions[1].Id);
                btnAnswer2.Hide();
            }
            else
            {
                MessageBox.Show("目前没有来电");
            }

        }

        private void btnHangup2_Click(object sender, EventArgs e)
        {
            if (attachedVideoSessions[1] != null)
            {
                Win32ServiceManager.SharedManager.SoundService.StopPlay(attachedVideoSessions[1].Id);
                if (!Win32ServiceManager.SharedManager.ServiceRealizeService.ReleaseCall(attachedVideoSessions[1].Id))
                {
                    MessageBox.Show("挂断失败");
                }
                btnAnswer2.Show();
                btnHangup2.Show();
                isVideoViewAttached[1] = false;
                attachedVideoSessions[1] = null;
            }
            else
            {
                MessageBox.Show("目前没有来电");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        private void btnMenu_Click(object sender, EventArgs e)
        {
            var menu = MenuList.FirstOrDefault(m => m.Name == ((Button)sender).Text);
            lblLocation.Text = menu.Name;
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
                        generateCameraPanel();
                        break;
                    default:
                        break;
                }
            }

            //releaseAllCalls();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void lbUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem as UserInfo;
            if (selectedItem != null)
            {
                if (isVideoViewAttached[0] == false)
                {
                    isVideoViewAttached[0] = true;
                    currentVedioPanel = pnlVideo1;

                    Win32ServiceManager.SharedManager.ServiceRealizeService.GroupVideoCall(selectedItem.NO, null);
                    btnAnswer1.Hide();
                    attachedVideoSessions[0] = currentVedioSession;
                }
                else if (isVideoViewAttached[1] == false)
                {
                    isVideoViewAttached[1] = true;
                    currentVedioPanel = pnlVideo2;

                    Win32ServiceManager.SharedManager.ServiceRealizeService.GroupVideoCall(selectedItem.NO, null);
                    btnAnswer2.Hide();
                    attachedVideoSessions[1] = currentVedioSession;
                }
                else
                {
                    MessageBox.Show("最多开启两个对讲");
                }
            }
        }

        private void lbCameras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lbCameras.IndexFromPoint(e.Location);
            if (index != -1)
            {
                var selectedItem = lbCameras.Items[index] as CameraInfo;

                if (cameraPanelGroup.Any(c => c.Value != null && c.Value.User == selectedItem.NO) == true)
                {
                    var panel = cameraPanelGroup.FirstOrDefault(c => c.Value.User == selectedItem.NO);
                    Win32ServiceManager.SharedManager.ServiceRealizeService.ReleaseCall(panel.Value.Session.Id);

                    cameraPanelGroup[panel.Key] = null;
                }
                else
                {
                    if (cameraPanelGroup.Any(c => c.Value == null) == true)
                    {
                        currentVedioPanel = cameraPanelGroup.FirstOrDefault(o => o.Value == null).Key;

                        isPollCall = true;
                        Win32ServiceManager.SharedManager.ServiceRealizeService.VideoPollCall(selectedItem.NO);

                        cameraPanelGroup[currentVedioPanel] = new MonitorInfo(selectedItem.NO, currentVedioSession);

                    }
                    else
                    {
                        MessageBox.Show("画面不足，请选择多画面");
                    }
                }
            }

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
                if (status == "0" && string.IsNullOrEmpty(NO) == false)
                {
                    //TODO: add vedio screen

                    currentVedioPanel = pnlWarning;

                    isPollCall = true;
                    var result = Win32ServiceManager.SharedManager.ServiceRealizeService.VideoPollCall(NO);

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


        private void attachSessionToPanel()
        {
            currentVedioSession.MediaSessionMgr.consumerSetInt64(twrap_media_type_t.twrap_media_video, "remote-hwnd", (Int64)currentVedioPanel.Handle);

            var success = false;
            try
            { }
            catch (Exception ex)
            {
                success = false;
            }
            if (success == true)
            {

            }
        }

        private string getSessionState(InviteState state, int code = 0)
        {

            switch (state)
            {
                case InviteState.INCOMING:
                    return "来话";

                case InviteState.INPROGRESS:
                    return "呼叫进展中";

                case InviteState.INCALL:
                    return "通话中";

                case InviteState.REMOTE_RINGING:
                    return "振铃中";

                case InviteState.LOCAL_HELD:
                    return "本端保持";

                case InviteState.REMOTE_HELD:
                    return "远端保持";

                case InviteState.TERMINATED:
                    {
                        switch (code)
                        {
                            case 403:
                                return "不允许呼叫";

                            case 404:
                                return "用户不存在";

                            case 406:
                                return "来话不可接听";

                            case 415:
                                return "媒体不支持";

                            case 480:
                                return "用户不可达";

                            case 486:
                                return "用户忙";

                            case 503:
                                return "服务不可用";

                            default:
                                return "通话已结束";
                        }
                    }
                default:
                    return "通话已结束";
            }

        }

        private void releaseAllCalls()
        {
            foreach (var session in sessions)
            {
                Win32ServiceManager.SharedManager.SoundService.StopPlay(session.Id);
                Win32ServiceManager.SharedManager.ServiceRealizeService.ReleaseCall(session.Id);
            }
        }

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

        private void initializetAvatar()
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
            if (cbxLayout.SelectedItem == null)
            {
                return;
            }
            var margin = 10;
            var totalCount = int.Parse((cbxLayout.SelectedItem as LayoutInfo).Value.Split('-')[0]);
            var rowLength = int.Parse((cbxLayout.SelectedItem as LayoutInfo).Value.Split('-')[1]);
            var rouCount = (int)Math.Ceiling((double)totalCount / rowLength);
            var width = (pnlCameraContainer.Width - (rowLength + 1) * margin) / rowLength;
            var height = (pnlCameraContainer.Height - (rouCount + 1) * margin) / rouCount;
            var startX = margin;
            var startY = margin;

            foreach (Panel item in pnlCameraContainer.Controls)
            {
                if (int.Parse(item.Name.Replace("pnlCamera", "")) >= totalCount)
                {
                    item.Hide();
                }
            }

            for (int i = 0; i < totalCount; i++)
            {
                var x = startX + (i % rowLength) * (width + margin);
                var y = startY + (i / rowLength) * (height + margin);

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
                    cameraPanelGroup.Add(panel, null);
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Win32ServiceManager.SharedManager.AccessNetworkService.Unregister();
        }




    }

    public class MonitorInfo
    {

        public MonitorInfo(string User, MyAVSession Session)
        {
            this.User = User;
            this.Session = Session;
        }
        public string User { get; set; }

        public MyAVSession Session { get; set; }
    }


}
