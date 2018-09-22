using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsContronlDemov0._0._1
{
    class Mouse
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        // 模拟滑轮
        const int MOUSEEVENTF_WHEEL = 0x0800;
        const int MOUSEEVENTF_HWHEEL = 0x1000;

        const int WM_HSCROLL = 276;

        [DllImport("User32")]
        public extern static bool GetCursorPos(ref Point lpPoint);
        static public void mockClick(int X, int  Y)
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            
            
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, X * 65536 / SW, Y * 65536 / SH, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        static public void mockWheel(int distance = -100)
        {

            //MessageBox.Show("click");
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, distance,0);
        }
        static public void HWheel(int distance = -100)
        {

            //MessageBox.Show("click");
            mouse_event(MOUSEEVENTF_HWHEEL, 0, 0, distance, 0);
            //SendMessage(hwdl, WM_HSCROLL, IntPtr.Zero, IntPtr.Zero);
        }
        static Point p = new Point(1, 1);//定义存放获取坐标的point变量 
        static public Point getMousePoint()
        {
            GetCursorPos(ref p);
            return p;
        }

        static public void moveMouse(int X, int  Y)
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, X * 65536 / SW, Y * 65536 / SH, 0, 0);
        }

        static public void rightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        static public void leftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        static public void mockHRwheel()
        {
            moveMouse(Store.w_right-50, Store.w_bottom-10);
            leftClick();
        }
    }

}
