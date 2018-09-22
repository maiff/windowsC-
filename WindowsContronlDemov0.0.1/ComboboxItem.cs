using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsContronlDemov0._0._1
{
    class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public override string ToString() { return Text; }
    }

    class ComboboxList
    {
        public List<ComboboxItem> getList()
        {
            ComboboxItem item1 = new ComboboxItem();
            item1.Text = "获取句柄";
            item1.Value = "0";

            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "截图";
            item2.Value = "1";

            ComboboxItem item3 = new ComboboxItem();
            item3.Text = "获取鼠标坐标";
            item3.Value = "2";

            

            List<ComboboxItem> items = new List<ComboboxItem> { item1, item2, item3 };
            return items;
        }
    }
}
