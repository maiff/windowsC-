using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsContronlDemov0._0._1
{
    class Store
    {
        static public int hwdl = 0;

        static private int now_x = 0;
        static private int now_y = 0;

        static public int w_left = 0;
        static public int w_right = 0;

        static public int w_top = 0;
        static public int w_bottom = 0;


        public static void setNow(int x, int y)
        {
            now_x = x;
            now_y = y;
        }

        public static int[] getNow()
        {

            return new int[] { now_x, now_y };
        }

        public static void mock_position(int x, int y)
        {
            setNow(x, y);
        }
    }
}
