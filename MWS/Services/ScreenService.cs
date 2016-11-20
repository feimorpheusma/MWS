using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispCore.Events;
using DispCore.Models;
using DispCore.Types;
using MWS.Services;
using DispCore.Services;
using DispCore.Utils;
using MWS;

namespace MWS.Services
{
    public class ScreenService : IWin32ScreenService
    {
        private LoginForm screenAuthentication;
        private MainForm screenMain;

        public ScreenService()
        {
            
        }

        ~ScreenService()
        {
          
        }

        #region IWin32ScreenService
        public bool Start()
        {
            Win32ServiceManager.SharedManager.AccessNetworkService.onAccessNetworkEvent += OnAccessNetworkEvent;
            return true;
        }

        public bool Stop()
        {
            Win32ServiceManager.SharedManager.AccessNetworkService.onAccessNetworkEvent -= OnAccessNetworkEvent;
            return true;
        }
        #endregion

        public void OnAccessNetworkEvent(object sender, AccessNetworkEventArgs e)
        {
            //if (Demo_WinForm.Program.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
            //{
            //    Demo.App.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
            //            new EventHandler<AccessNetworkEventArgs>(this.OnAccessNetworkEvent), sender, new object[] { e });
            //    return;
            //}

            //switch (e.Type)
            //{
            //    case AccessNetworkEventTypes.ANET_LOGIN:
            //        switch (e.Status)
            //        {
            //            case ANStatus.INSERVICE:
            //                ScreenAuthentication.Hide();
            //                ScreenMain.Show();
            //                break;
            //        }
            //        break;
            //}
        }

        #region setter/getter
        public LoginForm ScreenAuthentication
        {
            get
            {
                if (screenAuthentication == null)
                {
                    screenAuthentication = new LoginForm();
                }
                return this.screenAuthentication;
            }
        }

        public MainForm ScreenMain
        {
            get
            {
                if (screenMain == null)
                {
                    screenMain = new MainForm();
                }
                return this.screenMain;
            }
        }
        #endregion
    }
}
