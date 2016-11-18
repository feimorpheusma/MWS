using MWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            //Application.Run(new Form1());
            //return;

            String log4net = String.Format(MWS.Properties.Resources.log4net, Win32ServiceManager.SharedManager.ApplicationDataPath);
            using (Stream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(log4net)))
                Win32ServiceManager.SharedManager.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(Win32ServiceManager.SharedManager.Win32ScreenService.ScreenAuthentication);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new LoginForm());
            var loginForm = new LoginForm();
            Win32ServiceManager.SharedManager.Win32ScreenService.ScreenAuthentication.ShowDialog();
            if (Win32ServiceManager.SharedManager.Win32ScreenService.ScreenAuthentication.DialogResult == DialogResult.OK)
            {
                Application.Run(Win32ServiceManager.SharedManager.Win32ScreenService.ScreenMain);
            }
        }
    }
}
