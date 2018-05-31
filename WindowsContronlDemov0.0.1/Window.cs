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
        
        static int count = 0;
        //[StructLayout(LayoutKind.Sequential)]
        //public struct RECT
        //{
        //    public int Left, Top, Right, Bottom;

        //    public RECT(int left, int top, int right, int bottom)
        //    {
        //        Left = left;
        //        Top = top;
        //        Right = right;
        //        Bottom = bottom;
        //    }

        //    public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

        //    public int X
        //    {
        //        get { return Left; }
        //        set { Right -= (Left - value); Left = value; }
        //    }

        //    public int Y
        //    {
        //        get { return Top; }
        //        set { Bottom -= (Top - value); Top = value; }
        //    }

        //    public int Height
        //    {
        //        get { return Bottom - Top; }
        //        set { Bottom = value + Top; }
        //    }

        //    public int Width
        //    {
        //        get { return Right - Left; }
        //        set { Right = value + Left; }
        //    }

        //    public System.Drawing.Point Location
        //    {
        //        get { return new System.Drawing.Point(Left, Top); }
        //        set { X = value.X; Y = value.Y; }
        //    }

        //    public System.Drawing.Size Size
        //    {
        //        get { return new System.Drawing.Size(Width, Height); }
        //        set { Width = value.Width; Height = value.Height; }
        //    }

        //    public static implicit operator System.Drawing.Rectangle(RECT r)
        //    {
        //        return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
        //    }

        //    public static implicit operator RECT(System.Drawing.Rectangle r)
        //    {
        //        return new RECT(r);
        //    }

        //    public static bool operator ==(RECT r1, RECT r2)
        //    {
        //        return r1.Equals(r2);
        //    }

        //    public static bool operator !=(RECT r1, RECT r2)
        //    {
        //        return !r1.Equals(r2);
        //    }

        //    public bool Equals(RECT r)
        //    {
        //        return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
        //    }

        //    public override bool Equals(object obj)
        //    {
        //        if (obj is RECT)
        //            return Equals((RECT)obj);
        //        else if (obj is System.Drawing.Rectangle)
        //            return Equals(new RECT((System.Drawing.Rectangle)obj));
        //        return false;
        //    }

        //    public override int GetHashCode()
        //    {
        //        return ((System.Drawing.Rectangle)this).GetHashCode();
        //    }

        //    public override string ToString()
        //    {
        //        return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
        //    }
        //}
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
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
        public static extern int GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);



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
        static public Bitmap get_window_pic(IntPtr hwnd1, int w, int h)
        {

            Rect rect = new Rect();
            //IntPtr hwnd1 = FindWindow(handle_name, window_name);
            if (!hwnd1.Equals(IntPtr.Zero))
            {
                //MessageBox.Show("1！");
                GetWindowRect(hwnd1, out rect);  //获得目标窗体的大小  
                //int SW = Screen.PrimaryScreen.Bounds.Width; 
                //MessageBox.Show(rect.Right.ToString() + "," + rect.Left.ToString() + "," + rect.Width.ToString());
                int width = w == 0 ? rect.Right - rect.Left : w;
                int height = h == 0 ? rect.Bottom - rect.Top : h;
                Bitmap QQPic = new Bitmap(width, height );
                
                //MessageBox.Show((rect.Width - rect.Left).ToString() + "，" + (rect.Height - rect.Top).ToString());
                Graphics g1 = Graphics.FromImage(QQPic);
                IntPtr hdc1 = GetDC(hwnd1);
                IntPtr hdc2 = g1.GetHdc();  //得到Bitmap的DC  
                BitBlt(hdc2, 0, 0, width, height, hdc1, 0, 0, 13369376);
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
