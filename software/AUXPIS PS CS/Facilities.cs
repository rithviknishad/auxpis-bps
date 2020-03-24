using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Plotter.ui
{
    public static class Facilities
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static void WireControls(Control control, EventHandler eventHandler)
        {
            foreach (Control c in control.Controls)
            {
                c.Click += eventHandler;
                if (c.HasChildren)
                    WireControls(c, eventHandler);
            }
        }

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();
    }
}
