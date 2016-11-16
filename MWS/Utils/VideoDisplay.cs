using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Drawing;

namespace MWS.Utils
{
    public class VideoDisplay : HwndHost
    {
        private IntPtr hwndThis;
        private IntPtr hwndParent;

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            int width = (int)this.Width;
            int height = (int)this.Height;

            this.hwndParent = hwndParent.Handle;
            this.hwndThis = NativeMethods.CreateWindowEx(0, "static", String.Empty,
                NativeMethods.WS_CHILD | NativeMethods.WS_CLIPSIBLINGS | NativeMethods.WS_CLIPCHILDREN,
                0, 0,
                width, height,
                this.hwndParent,
                IntPtr.Zero,
                IntPtr.Zero,
                0);

            return new HandleRef(this, this.hwndThis);
        }

        protected override void OnWindowPositionChanged(System.Windows.Rect rcBoundingBox)
        {
            base.OnWindowPositionChanged(rcBoundingBox);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            NativeMethods.DestroyWindow(hwnd.Handle);
        }

        protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //if (msg == NativeMethods.WM_ERASEBKGND)
            //{
            //    Graphics g = Graphics.FromHdc(wParam);
            //    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, (int)this.Width, (int)this.Height));
            //    g.Dispose();
            //    return IntPtr.Zero;
            //}
            return base.WndProc(hwnd, msg, wParam, lParam, ref handled);
        }
    }
}
