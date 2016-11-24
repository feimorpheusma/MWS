namespace MWS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlIntercom = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnHangup1 = new System.Windows.Forms.Button();
            this.btnHangup2 = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnAnswer1 = new System.Windows.Forms.Button();
            this.btnAnswer2 = new System.Windows.Forms.Button();
            this.pnlVideo2 = new System.Windows.Forms.Panel();
            this.pnlVideo1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.pnlMinitor = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbxLayout = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCameraContainer = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCameras = new System.Windows.Forms.ListBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlMask = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCloseWarning = new System.Windows.Forms.Button();
            this.txtStatusWarning = new System.Windows.Forms.TextBox();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.btnCloseWarningMask = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlIntercom.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlMinitor.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMask.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLocation);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1354, 36);
            this.panel2.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(126, 12);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(29, 12);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "首页";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "您现在的位置:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MWS.Properties.Resources.icon_location;
            this.pictureBox2.Location = new System.Drawing.Point(13, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackgroundImage = global::MWS.Properties.Resources.bg_login;
            this.pnlContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 109);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(40);
            this.pnlContainer.Size = new System.Drawing.Size(1354, 644);
            this.pnlContainer.TabIndex = 2;
            // 
            // pnlIntercom
            // 
            this.pnlIntercom.BackColor = System.Drawing.Color.Transparent;
            this.pnlIntercom.Controls.Add(this.panel5);
            this.pnlIntercom.Controls.Add(this.panel4);
            this.pnlIntercom.Location = new System.Drawing.Point(40, 40);
            this.pnlIntercom.Name = "pnlIntercom";
            this.pnlIntercom.Size = new System.Drawing.Size(1273, 638);
            this.pnlIntercom.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(239, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1034, 638);
            this.panel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::MWS.Properties.Resources.bg_title;
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "本地视频";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnHangup1);
            this.panel6.Controls.Add(this.btnHangup2);
            this.panel6.Controls.Add(this.txtStatus);
            this.panel6.Controls.Add(this.btnAnswer1);
            this.panel6.Controls.Add(this.btnAnswer2);
            this.panel6.Controls.Add(this.pnlVideo2);
            this.panel6.Controls.Add(this.pnlVideo1);
            this.panel6.Location = new System.Drawing.Point(15, 43);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1001, 576);
            this.panel6.TabIndex = 0;
            // 
            // btnHangup1
            // 
            this.btnHangup1.Location = new System.Drawing.Point(417, 330);
            this.btnHangup1.Name = "btnHangup1";
            this.btnHangup1.Size = new System.Drawing.Size(75, 23);
            this.btnHangup1.TabIndex = 4;
            this.btnHangup1.Text = "挂断";
            this.btnHangup1.UseVisualStyleBackColor = true;
            this.btnHangup1.Click += new System.EventHandler(this.btnHangup1_Click);
            // 
            // btnHangup2
            // 
            this.btnHangup2.Location = new System.Drawing.Point(911, 330);
            this.btnHangup2.Name = "btnHangup2";
            this.btnHangup2.Size = new System.Drawing.Size(75, 23);
            this.btnHangup2.TabIndex = 4;
            this.btnHangup2.Text = "挂断";
            this.btnHangup2.UseVisualStyleBackColor = true;
            this.btnHangup2.Click += new System.EventHandler(this.btnHangup2_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(12, 373);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(974, 187);
            this.txtStatus.TabIndex = 2;
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.Location = new System.Drawing.Point(317, 330);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer1.TabIndex = 4;
            this.btnAnswer1.Text = "接听";
            this.btnAnswer1.UseVisualStyleBackColor = true;
            this.btnAnswer1.Click += new System.EventHandler(this.btnAnswer1_Click);
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.Location = new System.Drawing.Point(811, 330);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer2.TabIndex = 4;
            this.btnAnswer2.Text = "接听";
            this.btnAnswer2.UseVisualStyleBackColor = true;
            this.btnAnswer2.Click += new System.EventHandler(this.btnAnswer2_Click);
            // 
            // pnlVideo2
            // 
            this.pnlVideo2.BackgroundImage = global::MWS.Properties.Resources.bg_video;
            this.pnlVideo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlVideo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVideo2.Location = new System.Drawing.Point(506, 13);
            this.pnlVideo2.Name = "pnlVideo2";
            this.pnlVideo2.Size = new System.Drawing.Size(480, 311);
            this.pnlVideo2.TabIndex = 1;
            // 
            // pnlVideo1
            // 
            this.pnlVideo1.BackgroundImage = global::MWS.Properties.Resources.bg_video;
            this.pnlVideo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlVideo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVideo1.Location = new System.Drawing.Point(12, 13);
            this.pnlVideo1.Name = "pnlVideo1";
            this.pnlVideo1.Size = new System.Drawing.Size(480, 311);
            this.pnlVideo1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lbUsers);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(218, 638);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = global::MWS.Properties.Resources.bg_title;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "在线用户";
            // 
            // lbUsers
            // 
            this.lbUsers.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Items.AddRange(new object[] {
            "sip:18800050002@test.com",
            "sip:18800050002@test.com",
            "sip:18800050002@test.com",
            "sip:18800050002@test.com",
            "sip:18800050002@test.com"});
            this.lbUsers.Location = new System.Drawing.Point(13, 43);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(191, 576);
            this.lbUsers.TabIndex = 0;
            this.lbUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbUsers_MouseDoubleClick);
            // 
            // pnlMinitor
            // 
            this.pnlMinitor.BackColor = System.Drawing.Color.Transparent;
            this.pnlMinitor.Controls.Add(this.panel8);
            this.pnlMinitor.Controls.Add(this.panel12);
            this.pnlMinitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMinitor.Location = new System.Drawing.Point(40, 40);
            this.pnlMinitor.Name = "pnlMinitor";
            this.pnlMinitor.Size = new System.Drawing.Size(1274, 564);
            this.pnlMinitor.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.cbxLayout);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.pnlCameraContainer);
            this.panel8.Location = new System.Drawing.Point(239, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1035, 564);
            this.panel8.TabIndex = 1;
            // 
            // cbxLayout
            // 
            this.cbxLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLayout.FormattingEnabled = true;
            this.cbxLayout.Items.AddRange(new object[] {
            "1=a,",
            "2=b"});
            this.cbxLayout.Location = new System.Drawing.Point(945, 17);
            this.cbxLayout.Name = "cbxLayout";
            this.cbxLayout.Size = new System.Drawing.Size(72, 20);
            this.cbxLayout.TabIndex = 2;
            this.cbxLayout.SelectedIndexChanged += new System.EventHandler(this.cbxLayout_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Image = global::MWS.Properties.Resources.bg_title;
            this.label4.Location = new System.Drawing.Point(15, 13);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(75, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "摄像机组";
            // 
            // pnlCameraContainer
            // 
            this.pnlCameraContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCameraContainer.AutoScroll = true;
            this.pnlCameraContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCameraContainer.Location = new System.Drawing.Point(15, 43);
            this.pnlCameraContainer.Name = "pnlCameraContainer";
            this.pnlCameraContainer.Size = new System.Drawing.Size(1002, 502);
            this.pnlCameraContainer.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.label5);
            this.panel12.Controls.Add(this.lbCameras);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(218, 564);
            this.panel12.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Image = global::MWS.Properties.Resources.bg_title;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(61, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "摄像机";
            // 
            // lbCameras
            // 
            this.lbCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCameras.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCameras.FormattingEnabled = true;
            this.lbCameras.Location = new System.Drawing.Point(13, 43);
            this.lbCameras.Name = "lbCameras";
            this.lbCameras.Size = new System.Drawing.Size(191, 498);
            this.lbCameras.TabIndex = 0;
            this.lbCameras.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCameras_MouseDoubleClick);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(40, 40);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1273, 638);
            this.webBrowser.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MWS.Properties.Resources.header;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pnlMenu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 73);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(68, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 35);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "执勤调度信息系统";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.pbxAvatar);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(1234, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(120, 73);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(52)))), ((int)(((byte)(43)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(70, 25);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(45, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "注销";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.Location = new System.Drawing.Point(12, 12);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(50, 50);
            this.pbxAvatar.TabIndex = 0;
            this.pbxAvatar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MWS.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pnlMask
            // 
            this.pnlMask.BackColor = System.Drawing.Color.Transparent;
            this.pnlMask.BackgroundImage = global::MWS.Properties.Resources.bg_mask;
            this.pnlMask.Controls.Add(this.panel3);
            this.pnlMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMask.Location = new System.Drawing.Point(0, 109);
            this.pnlMask.Name = "pnlMask";
            this.pnlMask.Size = new System.Drawing.Size(1354, 718);
            this.pnlMask.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnCloseWarning);
            this.panel3.Controls.Add(this.txtStatusWarning);
            this.panel3.Controls.Add(this.pnlWarning);
            this.panel3.Controls.Add(this.btnCloseWarningMask);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(412, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(465, 486);
            this.panel3.TabIndex = 0;
            // 
            // btnCloseWarning
            // 
            this.btnCloseWarning.BackgroundImage = global::MWS.Properties.Resources.bg_title;
            this.btnCloseWarning.FlatAppearance.BorderSize = 0;
            this.btnCloseWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseWarning.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseWarning.ForeColor = System.Drawing.Color.White;
            this.btnCloseWarning.Location = new System.Drawing.Point(15, 449);
            this.btnCloseWarning.Name = "btnCloseWarning";
            this.btnCloseWarning.Size = new System.Drawing.Size(93, 29);
            this.btnCloseWarning.TabIndex = 4;
            this.btnCloseWarning.Text = "关闭警报";
            this.btnCloseWarning.UseVisualStyleBackColor = true;
            this.btnCloseWarning.Click += new System.EventHandler(this.btnCloseWarning_Click);
            // 
            // txtStatusWarning
            // 
            this.txtStatusWarning.Enabled = false;
            this.txtStatusWarning.Location = new System.Drawing.Point(17, 352);
            this.txtStatusWarning.Multiline = true;
            this.txtStatusWarning.Name = "txtStatusWarning";
            this.txtStatusWarning.Size = new System.Drawing.Size(435, 88);
            this.txtStatusWarning.TabIndex = 3;
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackgroundImage = global::MWS.Properties.Resources.bg_video;
            this.pnlWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlWarning.Location = new System.Drawing.Point(17, 52);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(435, 293);
            this.pnlWarning.TabIndex = 2;
            // 
            // btnCloseWarningMask
            // 
            this.btnCloseWarningMask.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseWarningMask.Location = new System.Drawing.Point(424, 14);
            this.btnCloseWarningMask.Name = "btnCloseWarningMask";
            this.btnCloseWarningMask.Size = new System.Drawing.Size(28, 23);
            this.btnCloseWarningMask.TabIndex = 1;
            this.btnCloseWarningMask.Text = "×";
            this.btnCloseWarningMask.UseVisualStyleBackColor = true;
            this.btnCloseWarningMask.Click += new System.EventHandler(this.btnCloseWarningMask_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(189, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 35);
            this.label6.TabIndex = 0;
            this.label6.Text = "联动报警";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 753);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "执勤调动信息系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlIntercom.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlMinitor.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMask.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pbxAvatar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel pnlIntercom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlVideo2;
        private System.Windows.Forms.Panel pnlVideo1;
        private System.Windows.Forms.Panel pnlMinitor;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCameraContainer;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbCameras;
        private System.Windows.Forms.ComboBox cbxLayout;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pnlMask;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCloseWarning;
        private System.Windows.Forms.TextBox txtStatusWarning;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Button btnCloseWarningMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnHangup2;
        private System.Windows.Forms.Button btnAnswer2;
        private System.Windows.Forms.Button btnHangup1;
        private System.Windows.Forms.Button btnAnswer1;
    }
}

