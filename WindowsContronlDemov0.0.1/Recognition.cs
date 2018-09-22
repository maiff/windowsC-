using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace WindowsContronlDemov0._0._1
{
    class Recognition
    {
        private static int center_x = Screen.PrimaryScreen.WorkingArea.Width / 2;
        private static int center_y = Screen.PrimaryScreen.WorkingArea.Height / 2;
        private static IDictionary<string, int[]> dict = new Dictionary<string, int[]>()
        {
            {"中心",new int[] { center_x, center_y } },
            { "车站选择", new int[] { center_x + 40, center_y + 14 }},
            {"塘子巷站", new int[] { center_x + 200, center_y + 14 } },
            {"S60103",new int[] { 170, 546 } },
            { "设置进路",new int[] { 207, 563 }},
            {"选择进路" ,new int[] { 274, 685 } }
        };
        
        public static int[] recognize(String keyword)
        {
            if(!dict.ContainsKey(keyword))
            {
                MessageBox.Show("识别失败");
                return new int[] { 0, 0 };
            }
            return dict[keyword];
        }
    }
}
