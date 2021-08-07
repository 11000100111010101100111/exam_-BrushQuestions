namespace 免安装更新
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.roundButton1 = new 免安装更新.RoundButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundButton3 = new 免安装更新.RoundButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.roundButton2 = new 免安装更新.RoundButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.roundButton4 = new 免安装更新.RoundButton();
            this.roundButton5 = new 免安装更新.RoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.x3 = new 免安装更新.RoundButton();
            this.x2 = new 免安装更新.RoundButton();
            this.x1 = new 免安装更新.RoundButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.mypanel1 = new 免安装更新.mypanel();
            this.mypanel2 = new 免安装更新.mypanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mypanel1.SuspendLayout();
            this.mypanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundButton1
            // 
            this.roundButton1.ControlState = 免安装更新.ControlState.Normal;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundButton1.ForeColor = System.Drawing.Color.White;
            this.roundButton1.HoverColor = System.Drawing.Color.SlateBlue;
            this.roundButton1.Location = new System.Drawing.Point(183, 634);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.roundButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.roundButton1.Radius = 15;
            this.roundButton1.Size = new System.Drawing.Size(599, 58);
            this.roundButton1.TabIndex = 0;
            this.roundButton1.Text = "开 始 更 新";
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(146, 504);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(350, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "C:\\Program Files (x86)";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(95, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件\r\n位置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundButton3
            // 
            this.roundButton3.ControlState = 免安装更新.ControlState.Normal;
            this.roundButton3.FlatAppearance.BorderSize = 0;
            this.roundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundButton3.ForeColor = System.Drawing.Color.White;
            this.roundButton3.HoverColor = System.Drawing.Color.Tomato;
            this.roundButton3.Location = new System.Drawing.Point(788, 634);
            this.roundButton3.Name = "roundButton3";
            this.roundButton3.NormalColor = System.Drawing.Color.Crimson;
            this.roundButton3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.roundButton3.Radius = 15;
            this.roundButton3.Size = new System.Drawing.Size(86, 58);
            this.roundButton3.TabIndex = 5;
            this.roundButton3.Text = "退 出";
            this.roundButton3.UseVisualStyleBackColor = true;
            this.roundButton3.Click += new System.EventHandler(this.roundButton3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // roundButton2
            // 
            this.roundButton2.ControlState = 免安装更新.ControlState.Normal;
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.ForeColor = System.Drawing.Color.White;
            this.roundButton2.HoverColor = System.Drawing.Color.MediumSeaGreen;
            this.roundButton2.Location = new System.Drawing.Point(502, 503);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.NormalColor = System.Drawing.Color.SeaGreen;
            this.roundButton2.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.roundButton2.Radius = 15;
            this.roundButton2.Size = new System.Drawing.Size(88, 29);
            this.roundButton2.TabIndex = 6;
            this.roundButton2.Text = "选择路径";
            this.roundButton2.UseVisualStyleBackColor = true;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\Program Files (x86)\\";
            // 
            // roundButton4
            // 
            this.roundButton4.ControlState = 免安装更新.ControlState.Normal;
            this.roundButton4.FlatAppearance.BorderSize = 0;
            this.roundButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton4.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundButton4.ForeColor = System.Drawing.Color.White;
            this.roundButton4.HoverColor = System.Drawing.Color.DarkTurquoise;
            this.roundButton4.Location = new System.Drawing.Point(738, 172);
            this.roundButton4.Name = "roundButton4";
            this.roundButton4.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(71)))));
            this.roundButton4.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.roundButton4.Radius = 15;
            this.roundButton4.Size = new System.Drawing.Size(44, 255);
            this.roundButton4.TabIndex = 7;
            this.roundButton4.Text = ">>";
            this.roundButton4.UseVisualStyleBackColor = true;
            this.roundButton4.Click += new System.EventHandler(this.roundButton4_Click);
            this.roundButton4.DragEnter += new System.Windows.Forms.DragEventHandler(this.roundButton4_DragEnter);
            this.roundButton4.MouseEnter += new System.EventHandler(this.roundButton4_MouseEnter);
            this.roundButton4.MouseLeave += new System.EventHandler(this.roundButton4_MouseLeave);
            // 
            // roundButton5
            // 
            this.roundButton5.ControlState = 免安装更新.ControlState.Normal;
            this.roundButton5.FlatAppearance.BorderSize = 0;
            this.roundButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton5.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundButton5.ForeColor = System.Drawing.Color.White;
            this.roundButton5.HoverColor = System.Drawing.Color.DarkTurquoise;
            this.roundButton5.Location = new System.Drawing.Point(7, 172);
            this.roundButton5.Name = "roundButton5";
            this.roundButton5.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(71)))));
            this.roundButton5.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.roundButton5.Radius = 15;
            this.roundButton5.Size = new System.Drawing.Size(44, 255);
            this.roundButton5.TabIndex = 8;
            this.roundButton5.Text = "<<";
            this.roundButton5.UseVisualStyleBackColor = true;
            this.roundButton5.Click += new System.EventHandler(this.roundButton5_Click);
            this.roundButton5.MouseEnter += new System.EventHandler(this.roundButton5_MouseEnter);
            this.roundButton5.MouseLeave += new System.EventHandler(this.roundButton5_MouseLeave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(146, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "tip:更新位置即之前（旧）版本安装的文件夹";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(801, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "1";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("楷体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(55, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(682, 63);
            this.label4.TabIndex = 11;
            this.label4.Text = "刷 题 荣 耀 更 新";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(52, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 415);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(53, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "请稍后...";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // x3
            // 
            this.x3.ControlState = 免安装更新.ControlState.Normal;
            this.x3.FlatAppearance.BorderSize = 0;
            this.x3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3.ForeColor = System.Drawing.Color.White;
            this.x3.HoverColor = System.Drawing.Color.Tomato;
            this.x3.Location = new System.Drawing.Point(42, 82);
            this.x3.Name = "x3";
            this.x3.NormalColor = System.Drawing.Color.RoyalBlue;
            this.x3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.x3.Radius = 30;
            this.x3.Size = new System.Drawing.Size(30, 30);
            this.x3.TabIndex = 8;
            this.x3.UseVisualStyleBackColor = true;
            // 
            // x2
            // 
            this.x2.ControlState = 免安装更新.ControlState.Normal;
            this.x2.FlatAppearance.BorderSize = 0;
            this.x2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2.ForeColor = System.Drawing.Color.White;
            this.x2.HoverColor = System.Drawing.Color.Tomato;
            this.x2.Location = new System.Drawing.Point(42, 46);
            this.x2.Name = "x2";
            this.x2.NormalColor = System.Drawing.Color.RoyalBlue;
            this.x2.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.x2.Radius = 30;
            this.x2.Size = new System.Drawing.Size(30, 30);
            this.x2.TabIndex = 7;
            this.x2.UseVisualStyleBackColor = true;
            // 
            // x1
            // 
            this.x1.ControlState = 免安装更新.ControlState.Normal;
            this.x1.FlatAppearance.BorderSize = 0;
            this.x1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1.ForeColor = System.Drawing.Color.White;
            this.x1.HoverColor = System.Drawing.Color.Tomato;
            this.x1.Location = new System.Drawing.Point(42, 118);
            this.x1.Name = "x1";
            this.x1.NormalColor = System.Drawing.Color.Crimson;
            this.x1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(71)))));
            this.x1.Radius = 30;
            this.x1.Size = new System.Drawing.Size(30, 30);
            this.x1.TabIndex = 6;
            this.x1.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // mypanel1
            // 
            this.mypanel1.BackColor = System.Drawing.Color.White;
            this.mypanel1.BorderColor = System.Drawing.Color.MidnightBlue;
            this.mypanel1.BorderSize = 10;
            this.mypanel1.Controls.Add(this.pictureBox1);
            this.mypanel1.Controls.Add(this.roundButton5);
            this.mypanel1.Controls.Add(this.textBox1);
            this.mypanel1.Controls.Add(this.label2);
            this.mypanel1.Controls.Add(this.roundButton4);
            this.mypanel1.Controls.Add(this.roundButton2);
            this.mypanel1.Controls.Add(this.label4);
            this.mypanel1.Controls.Add(this.label1);
            this.mypanel1.Location = new System.Drawing.Point(85, 70);
            this.mypanel1.Name = "mypanel1";
            this.mypanel1.Raidus = 250;
            this.mypanel1.Size = new System.Drawing.Size(789, 558);
            this.mypanel1.TabIndex = 14;
            // 
            // mypanel2
            // 
            this.mypanel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.mypanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mypanel2.BorderColor = System.Drawing.Color.White;
            this.mypanel2.BorderSize = 10;
            this.mypanel2.Controls.Add(this.x2);
            this.mypanel2.Controls.Add(this.label5);
            this.mypanel2.Controls.Add(this.x3);
            this.mypanel2.Controls.Add(this.x1);
            this.mypanel2.Location = new System.Drawing.Point(1005, 243);
            this.mypanel2.Name = "mypanel2";
            this.mypanel2.Raidus = 100;
            this.mypanel2.Size = new System.Drawing.Size(250, 250);
            this.mypanel2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::免安装更新.Properties.Resources.统计图背景6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 701);
            this.Controls.Add(this.mypanel2);
            this.Controls.Add(this.mypanel1);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.roundButton3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mypanel1.ResumeLayout(false);
            this.mypanel1.PerformLayout();
            this.mypanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundButton roundButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RoundButton roundButton3;
        private System.Windows.Forms.Timer timer1;
        private RoundButton roundButton2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.TextBox textBox1;
        private RoundButton roundButton4;
        private RoundButton roundButton5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private RoundButton x2;
        private RoundButton x1;
        private System.Windows.Forms.Timer timer2;
        private RoundButton x3;
        private System.Windows.Forms.Label label5;
        private mypanel mypanel1;
        private mypanel mypanel2;
    }
}

