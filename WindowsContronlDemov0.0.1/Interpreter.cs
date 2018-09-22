using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsContronlDemov0._0._1
{
    class Interpreter
    {
        private Dictionary<string, Delegate> dico = new Dictionary<string, Delegate>();
        private Form1 form1 = null;

        private Dictionary<string, string> vals = new Dictionary<string, string>()
        {
           
        };

        public Interpreter()
        {
            dico["rightClick"] = new Action(Mouse.rightClick);
            dico["leftClick"] = new Action(Mouse.leftClick);
            dico["move"] = new Action<int, int>(Mouse.moveMouse);
            dico["wheel"] = new Action<int>(Mouse.mockWheel);
            dico["keybd"] = new Action<string>(Keybd.keyboard);


        }

        public void interpreter(string text, Form1 form1)
        {
            this.form1 = form1;
            using (StringReader sr = new StringReader(text))
            {
                string line;
                int lineIndex = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    
                    var val2 = System.Text.RegularExpressions.Regex.Split(line, @"\s{1,}");
                    
                    if (checkScript(val2) == 0)
                    {
                        exec(val2);
                    } else
                    {
                        MessageBox.Show("第"+(lineIndex+1).ToString() + "行出问题了");
                    }
                    Console.WriteLine("行{0}:{1}", ++lineIndex, line);
                    //System.Console.WriteLine(val2[0]);
                }
            }
        }

        //private string[] replaceVal(string [] scriptLine)
        //{
        //    foreach (string t in scriptLine)
        //    {
               
        //    }
        //}
        private int checkScript(string [] scriptline)
        {
            switch (scriptline[0])
            {
                case "rightClick":
                case "leftClick":
                case "capture":
                case "rwheel":
                    return checkLength(scriptline, 1);
                case "wheel":
                case "Hwheel":
                case "keybd":
                case "getHandle":
                case "reg":
                    return checkLength(scriptline, 2);
                case "move":
                    return (checkLength(scriptline, 3) == 0) ? 0 : checkLength(scriptline, 1);
                default:
                    return -1;
            }
        }

        private int checkLength(string[] scriptline, int len) { 
            if (scriptline.Length != len) return -1;
            return 0;
        }

        private void exec(string[] scriptline)
        {
            switch (scriptline[0])
            {
                case "rightClick":
                    dico["rightClick"].DynamicInvoke();
                    break;
                case "leftClick":
                    dico["leftClick"].DynamicInvoke();
                    break;
                case "move":
                    if(scriptline.Length == 3)
                        dico["move"].DynamicInvoke(Convert.ToInt32(scriptline[1]), Convert.ToInt32(scriptline[2]));

                    else
                    {
                        int[] nowPosition = Store.getNow();
                        dico["move"].DynamicInvoke(Convert.ToInt32(nowPosition[0]), Convert.ToInt32(nowPosition[1]));

                    }
                    break;
                case "wheel":
                    dico["wheel"].DynamicInvoke(Convert.ToInt32(scriptline[1]));
                    break;
                case "keybd":
                    dico["keybd"].DynamicInvoke(scriptline[1]);
                    break;
                case "getHandle":
                    int hwnd = WindowLike.get_handle_by_name(scriptline[1]);
                    this.form1.now_handle_hwnd = hwnd;
                    Store.hwdl = hwnd;
                    break;
                case "capture":
                    this.form1.capture();
                    break;
                case "Hwheel":
                    Mouse.HWheel(Convert.ToInt32(scriptline[1]));
                    break;

                case "reg":
                    int[] pos = Recognition.recognize((scriptline[1]));
                    Store.mock_position(pos[0], pos[1]);
                    break;
                case "rwheel":
                    Mouse.mockHRwheel();
                    break;
            }
            System.Threading.Thread.Sleep(1000);

        }


    }
}
