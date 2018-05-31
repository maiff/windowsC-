using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace WindowsContronlDemov0._0._1
{
    public partial class Form1 : Form
    {
        HotKeys hot = new HotKeys();
        private int now_choose_index;
        Log log = new Log();
        private List<ComboboxItem> items;

        private int _now_handle_hwnd = 0;
        public int now_handle_hwnd
        {
            get {
                return this._now_handle_hwnd;
            }
            set {
                this._now_handle_hwnd = value;
                this.textBox_window_name.Text = value.ToString();
            }
        }

        private string now_log
        {
            get
            {
                return this.log.get_log();
            }
            set
            {
                this.log.set_log(value);
                this._log.Text = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public void CallBack()
        {
            switch (this.now_choose_index){
                case 0:
                    int hwnd = WindowLike.get_handle();
                    //MessageBox.Show(s[0],s[1]);
                    this.now_handle_hwnd = hwnd;
                    break;
                case 1:
                    this.capture();
                    break;
                case 2:
                    Point p = Mouse.getMousePoint();
                    this.textBox_MouseX.Text = p.X.ToString();
                    this.textBox_MouseY.Text = p.Y.ToString();
                    break;
            }
            //MessageBox.Show("快捷键被调用！");
        }
        public void CallBack_next()
        {
            //this.nowChoose = 1;
            //ComboboxItem selectedCar = (ComboboxItem)nowChoose.SelectedItem;
            nowChoose.SelectedItem = this.items[1];
            //this.now_log = "";
        }
        public void CallBack_click()
        {
            Mouse.mockClick(Convert.ToInt32(this.textBox_MouseX.Text), Convert.ToInt32(this.textBox_MouseY.Text));
        }
        public void CallBack_wheel()
        {
            Mouse.mockWheel();
        }
        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            hot.ProcessHotKey(m);
            base.WndProc(ref m);
        }
  

        private void button1_Click(object sender, System.EventArgs e)
        {
            //取得当前屏幕的大小
            //Rectangle rect = new Rectangle();
            //rect = Screen.GetWorkingArea(this);
            //创立一个以以后屏幕为模板的图象
            //Graphics g1 = this.CreateGraphics();
            //创立以屏幕大小为尺度的位图
            //Image MyImage = new Bitmap(rect.Width, rect.Height, g1);
            //Graphics g2 = Graphics.FromImage(MyImage);
            ////得到屏幕的DC
            //IntPtr dc1 = g1.GetHdc();
            ////得到Bitmap的DC
            //IntPtr dc2 = g2.GetHdc();
            ////调用彼API函数，完成屏幕捕捉
            //BitBlt(dc2, 0, 0, rect.Width, rect.Height, dc1, 0, 0, 13369376);
            ////开释掉屏幕的DC
            //g1.ReleaseHdc(dc1);
            ////开释掉Bitmap的DC
            //g2.ReleaseHdc(dc2);
            ////以JPG白件格局来保留
            //MyImage.Save(@".\Capture.jpg", ImageFormat.Jpeg);


            //IntPtr hwnd1 = FindWindow(null, "QQpic");
            //if (!hwnd1.Equals(IntPtr.Zero))
            //{
            //    MessageBox.Show("1！");
            //    GetWindowRect(hwnd1, out rect);  //获得目标窗体的大小  
            //    Bitmap QQPic = new Bitmap(rect.Width, rect.Height);
            //    Graphics g1 = Graphics.FromImage(QQPic);
            //    IntPtr hdc1 = GetDC(hwnd1);
            //    IntPtr hdc2 = g1.GetHdc();  //得到Bitmap的DC  
            //    BitBlt(hdc2, 0, 0, rect.Width, rect.Height, hdc1, 0, 0, 13369376);
            //    g1.ReleaseHdc(hdc2);  //释放掉Bitmap的DC  
            //    QQPic.Save("QQpic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //    //以JPG文件格式保存  
            //}
            //MessageBox.Show("该前屏幕已经保留为C盘的capture.jpg白件！");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.init_Hot();
            ComboboxList comList = new ComboboxList();
            List<ComboboxItem> items = comList.getList();
            this.items = items;
            this.nowChoose.DataSource = items;
            this.nowChoose.DisplayMember = "Text";
            this.nowChoose.ValueMember = "Value";
            this.nowChoose.SelectedIndexChanged += new System.EventHandler(this.nowChoose_SelectedIndexChanged); // 防止初始化时触发事件
        }
        private void init_Hot()
        {
            hot.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control, Keys.E, CallBack);
            hot.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control, Keys.W, CallBack_next);
            hot.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control, Keys.R, CallBack_click);
            hot.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Alt, Keys.D, CallBack_wheel);
            //MessageBox.Show("注册成功");
        }

        private void nowChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedCar = (ComboboxItem)nowChoose.SelectedItem;
            this.now_choose_index = Convert.ToInt32(selectedCar.Value);
            //MessageBox.Show(String.Format("Index: [{0}]", selecteVal));
        }

        private double zoom = 1.0;
        private void imageView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (imageView.Image != null)
            {
                if (e.Delta < 0)
                {
                    zoom = zoom * 1.05;
                }
                else
                {
                    if (zoom != 1.0)
                    {
                        zoom = zoom / 1.05;
                    }
                }



                imageView.Width = (int)Math.Round(imageView.Image.Width * zoom);
                imageView.Height = (int)Math.Round(imageView.Image.Height * zoom);
            }
        }

        private void capturePic_Click(object sender, EventArgs e)
        {
            this.capture();
        }
        private void capture()
        {
            if (this.now_handle_hwnd == 0) MessageBox.Show("请先获取句柄等相关信息");
            else
            {
                int w = this.W.Text == "" ? 0 : Int32.Parse(this.W.Text) ;
                int h = this.H.Text == "" ? 0 : Int32.Parse(this.H.Text);
                Bitmap pic = WindowLike.get_window_pic(new IntPtr(this.now_handle_hwnd), w, h);
                if (pic != null)
                {

                    this.now_log = "保存成功" + pic.Width.ToString() + "x" + pic.Height.ToString();
 
                    this.imageView.Image = pic;

                    FormRect rect = new FormRect();
                    rect = Util.getFormRect(this);

                    //int oldWidth_imageView = this.imageView.Width;
                    //int oldHeight_imageView = this.imageView.Height;
                    //pic = Util.ZoomImage(pic, pic.Width / 5, pic.Height / 5);
                    // 注意先后设置顺序
                    //this.Height = pic.Height - this.imageView.Height + rect.height;
                    //this.Width = pic.Width - this.imageView.Width + rect.width;

                    this.imageView.Height = pic.Height;
                    this.imageView.Width = pic.Width;


                }

            }
        }

        private void window_name_Click(object sender, EventArgs e)
        {

        }
    }
}
