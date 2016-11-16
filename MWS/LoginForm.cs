using MWS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


            Win32ServiceManager.SharedManager.Win32ScreenService.ScreenAuthentication.Hide();
            Win32ServiceManager.SharedManager.Win32ScreenService.ScreenMain.Show();

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }
    }
}
