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
    class Keybd
    {
        public const int KEYEVENTF_KEYUP = 2;
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        static public void keyboard(string s)
        {
            keybd_event((Keys)Enum.Parse(typeof(Keys), s), 0, 0, 0);
            //keybd_event(Keys.E, 0, 0, 0);
            //keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            //SendKeys.Send(s);
        }
    }
}
