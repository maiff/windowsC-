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
            this.script = new System.Windows.Forms.TextBox();
            this.run = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.log1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).BeginInit();
            this.SuspendLayout();
            // 
            // nowChoose
            // 
            this.nowChoose.FormattingEnabled = true;
            this.nowChoose.Location = new System.Drawing.Point(98, 46);
            this.nowChoose.Name = "nowChoose";
            this.nowChoose.Size = new System.Drawing.Size(69, 20);
            this.nowChoose.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "现在干的事情：";
            // 
            // window_name
            // 
            this.window_name.AutoSize = true;
            this.window_name.Location = new System.Drawing.Point(177, 13);
            this.window_name.Name = "window_name";
            this.window_name.Size = new System.Drawing.Size(65, 12);
            this.window_name.TabIndex = 8;
            this.window_name.Text = "窗口句柄：";
            this.window_name.Click += new System.EventHandler(this.window_name_Click);
            // 
            // textBox_window_name
            // 
            this.textBox_window_name.Location = new System.Drawing.Point(239, 11);
            this.textBox_window_name.Name = "textBox_window_name";
            this.textBox_window_name.Size = new System.Drawing.Size(92, 21);
            this.textBox_window_name.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "日志：";
            this.label2.Visible = false;
            // 
            // _log
            // 
            this._log.AutoSize = true;
            this._log.Location = new System.Drawing.Point(383, 17);
            this._log.Name = "_log";
            this._log.Size = new System.Drawing.Size(0, 12);
            this._log.TabIndex = 11;
            this._log.Visible = false;
            // 
            // textBox_MouseY
            // 
            this.textBox_MouseY.Location = new System.Drawing.Point(239, 71);
            this.textBox_MouseY.Name = "textBox_MouseY";
            this.textBox_MouseY.Size = new System.Drawing.Size(92, 21);
            this.textBox_MouseY.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "鼠标坐标Y：";
            // 
            // textBox_MouseX
            // 
            this.textBox_MouseX.Location = new System.Drawing.Point(239, 41);
            this.textBox_MouseX.Name = "textBox_MouseX";
            this.textBox_MouseX.Size = new System.Drawing.Size(92, 21);
            this.textBox_MouseX.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "鼠标坐标X:";
            // 
            // imageView
            // 
            this.imageView.Location = new System.Drawing.Point(23, 121);
            this.imageView.Name = "imageView";
            this.imageView.Size = new System.Drawing.Size(669, 406);
            this.imageView.TabIndex = 16;
            this.imageView.TabStop = false;
            // 
            // capturePic
            // 
            this.capturePic.Location = new System.Drawing.Point(512, 11);
            this.capturePic.Name = "capturePic";
            this.capturePic.Size = new System.Drawing.Size(50, 18);
            this.capturePic.TabIndex = 17;
            this.capturePic.Text = "截图";
            this.capturePic.UseVisualStyleBackColor = true;
            this.capturePic.Click += new System.EventHandler(this.capturePic_Click);
            // 
            // script
            // 
            this.script.Location = new System.Drawing.Point(346, 37);
            this.script.Multiline = true;
            this.script.Name = "script";
            this.script.Size = new System.Drawing.Size(158, 60);
            this.script.TabIndex = 23;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(512, 39);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(20, 58);
            this.run.TabIndex = 24;
            this.run.Text = "执行";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "演示";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // log1
            // 
            this.log1.AutoSize = true;
            this.log1.Location = new System.Drawing.Point(389, 19);
            this.log1.Name = "log1";
            this.log1.Size = new System.Drawing.Size(41, 12);
            this.log1.TabIndex = 26;
            this.log1.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(715, 556);
            this.Controls.Add(this.log1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.run);
            this.Controls.Add(this.script);
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
            this.Text = "windowsContronl";
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
        private TextBox script;
        private Button run;
        private Button button1;
        private Label log1;
    }
}

