using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Calendar
{
    public class Methods
    {
        private struct DWMMargins
        {
            public int top;
            public int bottom;
            public int left;
            public int right;
        }

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref DWMMargins margins);

        public static void ExtendAeroToFullWindow(Window wnd)
        {
            IntPtr hwnd = new WindowInteropHelper(wnd).Handle;
            wnd.Background = Brushes.Transparent;
            HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = Colors.Transparent;
            DWMMargins m = new DWMMargins();
            m.top = -1;
            m.bottom = -1;
            m.left = -1;
            m.right = -1;
            DwmExtendFrameIntoClientArea(hwnd, ref m);
        }
    }
}
