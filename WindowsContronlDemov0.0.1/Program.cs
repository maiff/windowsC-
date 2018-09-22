using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsContronlDemov0._0._1
{
   
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Test test = new Test();
            test.say();
            

        }
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
           IntPtr hdcDest, // 目的 DC的句柄
           int nXDest,
           int nYDest,
           int nWidth,
           int nHeight,
           IntPtr hdcSrc, // 流DC的句柄
           int nXSrc,
           int nYSrc,
           System.Int32 dwRop // 光栅的处置数值
       );
    }

}
