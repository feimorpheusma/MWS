using DispCore.Events;
using DispCore.Services;
using MWS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            lblTitle.Text = ConfigurationManager.AppSettings["SystemName"];
            CheckForIllegalCrossThreadCalls = false;
            Win32ServiceManager.SharedManager.AccessNetworkService.onAccessNetworkEvent += OnAccessNetworkEvent;
        }

        public void OnAccessNetworkEvent(object sender, AccessNetworkEventArgs e)
        {
            switch (e.Type)
            {
                case AccessNetworkEventTypes.ANET_LOGIN:
                    this.LoginProgress = e.Status;
                    this.LoginProgressPhrase = e.Phrase;
                    break;

                case AccessNetworkEventTypes.ANET_KEEPALIVE:
                    // 不处理
                    break;

                default:
                    break;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Win32ServiceManager.SharedManager.ConfigurationService.IdentityCfg.Realm = txtIP.Text;
            Win32ServiceManager.SharedManager.ConfigurationService.IdentityCfg.DisplayName = txtUserName.Text;
            Win32ServiceManager.SharedManager.ConfigurationService.IdentityCfg.Impu = "sip:" + txtUserName.Text + "@"
                        + Win32ServiceManager.SharedManager.ConfigurationService.IdentityCfg.Realm;
            Win32ServiceManager.SharedManager.ConfigurationService.IdentityCfg.Impi = txtUserName.Text;
            Win32ServiceManager.SharedManager.ConfigurationService.IdentityCfg.Password = txtPassword.Text;
            Win32ServiceManager.SharedManager.AccessNetworkService.Register();

            Win32ServiceManager.SharedManager.Win32ScreenService.ScreenMain.CurrentUser = txtUserName.Text;
            //Win32ServiceManager.SharedManager.Win32ScreenService.ScreenAuthentication.DialogResult = DialogResult.OK;
            //Win32ServiceManager.SharedManager.Win32ScreenService.ScreenAuthentication.Close();
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

        private ANStatus loginProgress;
        private string loginProgressPhrase;

        public ANStatus LoginProgress
        {
            set
            {
                if (this.loginProgress != value)
                {
                    this.loginProgress = value;
                    this.OnPropertyChanged("LoginProgress");
                }
            }

            get
            {
                return this.loginProgress;
            }
        }

        public string LoginProgressPhrase
        {
            set
            {
                this.loginProgressPhrase = value;
                this.OnPropertyChanged("LoginProgressPhrase");
            }
            get
            {
                return this.loginProgressPhrase;
            }
        }
    }
}
