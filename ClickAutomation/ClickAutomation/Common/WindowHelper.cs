using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClickAutomation.Common
{
    public class WindowHelper
    {
        [DllImport("user32")]
        internal static extern bool ShowWindow(nint hWnd, int type);
    }
}
