using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsContronlDemov0._0._1
{
    class WindowLike
    {
        public struct RECT
        {
            public int Left;       // Specifies the x-coordinate of the upper-left corner of the rectangle.
            public int Top;        // Specifies the y-coordinate of the upper-left corner of the rectangle.
            public int Right;      // Specifies the x-coordinate of the lower-right corner of the rectangle.
            public int Bottom;     // Specifies the y-coordinate of the lower-right corner of the rectangle.

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public uint cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;

            public WINDOWINFO(Boolean? filler)
             : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
            {
                cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
            }

        }

        class Win32
        {
            /// <summary>
            /// Gets the foreground window.
            /// </summary>
            /// <returns></returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetForegroundWindow();

            /// <summary>
            /// Gets the window info.
            /// </summary>
            /// <param name="hwnd">The HWND.</param>
            /// <param name="pwi">The pwi.</param>
            /// <returns></returns>
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

            /// <summary>
            /// Gets the window text.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="text">The text.</param>
            /// <param name="count">The count.</param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

            /// <summary>
            /// Creates the round rect RGN.
            /// </summary>
            /// <param name="nLeftRect">The n left rect.</param>
            /// <param name="nTopRect">The n top rect.</param>
            /// <param name="nRightRect">The n right rect.</param>
            /// <param name="nBottomRect">The n bottom rect.</param>
            /// <param name="nWidthEllipse">The n width ellipse.</param>
            /// <param name="nHeightEllipse">The n height ellipse.</param>
            /// <returns></returns>
            [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            public static extern IntPtr CreateRoundRectRgn
             (
              int nLeftRect,
              int nTopRect, // y-coordinate of upper-left corner
              int nRightRect, // x-coordinate of lower-right corner
              int nBottomRect, // y-coordinate of lower-right corner
              int nWidthEllipse, // height of ellipse
              int nHeightEllipse // width of ellipse
             );
        }
        static int count = 0;
       
        [StructLayout(LayoutKind.Sequential)]//定义与API相兼容结构体，实际上是一种内存转换  
        public struct POINTAPI
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]//获取鼠标坐标  
        public static extern int GetCursorPos(
           ref POINTAPI lpPoint
       );

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]//指定坐标处窗体句柄  
        public static extern int WindowFromPoint(
            int xPoint,
            int yPoint
        );

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(
            int hWnd,
            StringBuilder lpString,
            int nMaxCount
        );

        [DllImport("user32.dll", EntryPoint = "GetClassName")]
        public static extern int GetClassName(
            int hWnd,
            StringBuilder lpString,
            int nMaxCont
        );


        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
              IntPtr hdcDest, // 目的 DC的句柄
              int nXDest,
              int nYDest,
              int nWidth,
              int nHeight,
              IntPtr hdcSrc, // 源DC的句柄
              int nXSrc,
              int nYSrc,
              System.Int32 dwRop // 光栅的处置数值
          );
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static IntPtr GetDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        static public int get_handle()
        {
            POINTAPI point = new POINTAPI();//必须用与之相兼容的结构体，类也可以  
            //add some wait time  
            GetCursorPos(ref point);//获取当前鼠标坐标  

            int hwnd = WindowFromPoint(point.X, point.Y);//获取指定坐标处窗口的句柄  
            //StringBuilder window_name = new StringBuilder(256);
            //StringBuilder handle_name = new StringBuilder(256);
            //MessageBox.Show(hwnd.ToString());
            //GetWindowText(hwnd, window_name, 256);
            //MessageBox.Show(name.ToString());
            //GetClassName(hwnd, handle_name, 256);
            //MessageBox.Show(name.ToString());
            //string[] s = { handle_name.ToString(), window_name.ToString() };
            return hwnd;
        }
        static public Bitmap get_window_pic(IntPtr hwnd1)
        {
            Rectangle rect = new Rectangle();
            WINDOWINFO info = new WINDOWINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            Win32.GetWindowInfo(hwnd1, ref info);
            int width = info.rcWindow.Right - info.rcWindow.Left;
            int height = info.rcWindow.Bottom - info.rcWindow.Top;
            MessageBox.Show(width.ToString()+','+height.ToString());
            //IntPtr hwnd1 = FindWindow(handle_name, window_name);
            if (!hwnd1.Equals(IntPtr.Zero))
            {
                //MessageBox.Show("1！");
                GetWindowRect(hwnd1, out rect);  //获得目标窗体的大小  
                //int SW = Screen.PrimaryScreen.Bounds.Width; 
                //MessageBox.Show(rect.Right.ToString() + "," + rect.Left.ToString() + "," + rect.Width.ToString());
                Bitmap QQPic = new Bitmap(rect.Width, rect.Height );
                
                //MessageBox.Show((rect.Width - rect.Left).ToString() + "，" + (rect.Height - rect.Top).ToString());
                Graphics g1 = Graphics.FromImage(QQPic);
                IntPtr hdc1 = GetDC(hwnd1);
                IntPtr hdc2 = g1.GetHdc();  //得到Bitmap的DC  
                BitBlt(hdc2, 0, 0, rect.Width, rect.Height , hdc1, 0, 0, 13369376);
                g1.ReleaseHdc(hdc2);  //释放掉Bitmap的DC  
                string filename = @".\pic\"+count + ".jpg";
                //QQPic.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                count++;
                return QQPic;
                //以JPG文件格式保存  
            }
            return null;
            
        }
    }
}
