using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace APSV
{
    class VistaApi
    {
        [DllImport("dwmapi.dll")]
        internal static extern void DwmExtendFrameIntoClientArea(System.IntPtr hWnd, ref Margins pMargins);

        [DllImport("dwmapi.dll")]
        internal static extern void DwmIsCompositionEnabled(ref bool isEnabled);

        internal struct Margins
        {
            public int Left, Right, Top, Bottom;
        }

        // consts for wndproc
        internal const int WM_NCHITTEST = 0x84;
        internal const int HTCLIENT = 1;
        internal const int HTCAPTION = 2;
    }
}
