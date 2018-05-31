using System;
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
    partial class Form1
    {
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        /// 
        
        private void InitializeComponent()
        {
            this.nowChoose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.window_name = new System.Windows.Forms.Label();
            this.textBox_window_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._log = new System.Windows.Forms.Label();
            this.textBox_MouseY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MouseX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageView = new System.Windows.Forms.PictureBox();
            this.capturePic = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.W = new System.Windows.Forms.TextBox();
            this.H = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).BeginInit();
            this.SuspendLayout();
            // 
            // nowChoose
            // 
            this.nowChoose.FormattingEnabled = true;
            this.nowChoose.Location = new System.Drawing.Point(152, 13);
            this.nowChoose.Name = "nowChoose";
            this.nowChoose.Size = new System.Drawing.Size(115, 26);
            this.nowChoose.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "现在干的事情：";
            // 
            // window_name
            // 
            this.window_name.AutoSize = true;
            this.window_name.Location = new System.Drawing.Point(295, 19);
            this.window_name.Name = "window_name";
            this.window_name.Size = new System.Drawing.Size(98, 18);
            this.window_name.TabIndex = 8;
            this.window_name.Text = "窗口句柄：";
            this.window_name.Click += new System.EventHandler(this.window_name_Click);
            // 
            // textBox_window_name
            // 
            this.textBox_window_name.Location = new System.Drawing.Point(399, 16);
            this.textBox_window_name.Name = "textBox_window_name";
            this.textBox_window_name.Size = new System.Drawing.Size(152, 28);
            this.textBox_window_name.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "日志：";
            // 
            // _log
            // 
            this._log.AutoSize = true;
            this._log.Location = new System.Drawing.Point(636, 16);
            this._log.Name = "_log";
            this._log.Size = new System.Drawing.Size(0, 18);
            this._log.TabIndex = 11;
            // 
            // textBox_MouseY
            // 
            this.textBox_MouseY.Location = new System.Drawing.Point(399, 106);
            this.textBox_MouseY.Name = "textBox_MouseY";
            this.textBox_MouseY.Size = new System.Drawing.Size(152, 28);
            this.textBox_MouseY.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "鼠标坐标Y：";
            // 
            // textBox_MouseX
            // 
            this.textBox_MouseX.Location = new System.Drawing.Point(399, 62);
            this.textBox_MouseX.Name = "textBox_MouseX";
            this.textBox_MouseX.Size = new System.Drawing.Size(152, 28);
            this.textBox_MouseX.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "鼠标坐标X:";
            // 
            // imageView
            // 
            this.imageView.Location = new System.Drawing.Point(37, 170);
            this.imageView.Name = "imageView";
            this.imageView.Size = new System.Drawing.Size(851, 318);
            this.imageView.TabIndex = 16;
            this.imageView.TabStop = false;
            // 
            // capturePic
            // 
            this.capturePic.Location = new System.Drawing.Point(15, 56);
            this.capturePic.Name = "capturePic";
            this.capturePic.Size = new System.Drawing.Size(83, 27);
            this.capturePic.TabIndex = 17;
            this.capturePic.Text = "截图";
            this.capturePic.UseVisualStyleBackColor = true;
            this.capturePic.Click += new System.EventHandler(this.capturePic_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "W:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "H:";
            // 
            // W
            // 
            this.W.Location = new System.Drawing.Point(64, 95);
            this.W.Name = "W";
            this.W.Size = new System.Drawing.Size(159, 28);
            this.W.TabIndex = 20;
            // 
            // H
            // 
            this.H.Location = new System.Drawing.Point(64, 125);
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(159, 28);
            this.H.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(10, 21);
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.H);
            this.Controls.Add(this.W);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.capturePic);
            this.Controls.Add(this.imageView);
            this.Controls.Add(this.textBox_MouseY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_MouseX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_window_name);
            this.Controls.Add(this.window_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nowChoose);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "C#捕捉以后屏幕！";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
       
        #endregion
        private ComboBox nowChoose;
        private Label label1;
        private Label window_name;
        private TextBox textBox_window_name;
        private Label label2;
        private Label _log;
        private TextBox textBox_MouseY;
        private Label label3;
        private TextBox textBox_MouseX;
        private Label label4;
        private PictureBox imageView;
        private Button capturePic;
        private Label label5;
        private Label label6;
        private TextBox W;
        private TextBox H;
    }
}

