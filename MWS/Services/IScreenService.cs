using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispCore.Services;
using System.Windows.Controls;
using MWS;

namespace MWS.Services
{
    public interface IWin32ScreenService : IScreenService
    {
        LoginForm ScreenAuthentication
        {
            get;
        }

        MainForm ScreenMain
        {
            get;
        }
    }
}
