using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace 免安装更新
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string APPname = "刷题助手";
        Image[] ig = new Image[4];
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "刷 题 助 手 更 新";
            //bitmap = new Bitmap(mypanel2.Width, mypanel2.Height);
            mypanel2.BackColor=Color.FromArgb(135, 206, 235);
            //Graphics g = Graphics.FromImage(bitmap);
            //g.FillRectangle(new SolidBrush(mypanel2.BackColor),new Rectangle(new Point(0,0),bitmap.Size));
            ig[0] = Properties.Resources._0;
            ig[1] = Properties.Resources._1;
            ig[2] = Properties.Resources._2;
            ig[3] = Properties.Resources._3;
            timer1.Start();
            drawArc();
            mypanel1.Location = new Point((this.Width-mypanel1.Width)/2,(this.Height-mypanel1.Height)/2);
            mypanel1.Visible = true;

        }
        public void lighting(Control con, Control backCon, Color co)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(con.Left - 40, con.Top - 40, con.Width + 80, con.Height + 80);


            PathGradientBrush pthGrBrush = new PathGradientBrush(path);


            pthGrBrush.CenterPoint = new PointF(con.Left + con.Width / 2, con.Top + (con.Height) / 2);


            pthGrBrush.CenterColor = co;


            Color[] colors = { Color.FromArgb(255, 255, 255, 255) };
            pthGrBrush.SurroundColors = colors;

           // bitmap = new Bitmap(backCon.Width,backCon.Height);
            //Graphics g = Graphics.FromImage(bitmap);
            //g.FillRectangle(new SolidBrush(backCon.BackColor),new Rectangle(new Point(0,0),bitmap.Size));
            //g.FillEllipse(pthGrBrush, con.Left - 40, con.Top - 40, con.Width + 80, con.Height + 80);
            //backCon.BackgroundImage = bitmap;
            //bitmap.Dispose();
            backCon.CreateGraphics().FillEllipse(pthGrBrush, con.Left - 40, con.Top - 40, con.Width + 80, con.Height + 80);
            //panel1.CreateGraphics().FillRectangle(pthGrBrush, button1.Left - 50, button1.Top - 50, button1.Width + 100, button1.Height + 100);

        }
        //Bitmap bitmap;
        public void clearLighting(Control objectCon)
        {
            Graphics g = objectCon.CreateGraphics();
            Brush b = new SolidBrush(objectCon.BackColor);
            g.FillRectangle(b, new Rectangle(new Point(0, 0), objectCon.Size));
        }
        private void drawArc()
        {
            Graphics g = mypanel1.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            g.Clear(mypanel1.BackColor);

            for(int i=0;i<4;i++)
            {
                if(i==picNum)
                {
                    Brush b = new SolidBrush(Color.FromArgb(0, 255, 127));
                    g.FillEllipse(b, new Rectangle(new Point(pictureBox1.Right-85+i*20,pictureBox1 .Bottom+5),new Size(20,20)));
                }
                else
                {
                    Brush b = new SolidBrush(Color.FromArgb(192, 192, 192));
                    g.FillEllipse(b,new Rectangle(new Point(pictureBox1.Right - 80 + i * 20, pictureBox1.Bottom + 10), new Size(10,10)));
                }
            }
            label3.Text = (picNum+1).ToString();
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请选择您-之前-安装" + APPname + "的文件夹！");
            }
            else
            {
                string path = Path.Combine(@textBox1.Text.Trim(), "快眼刷题.exe");
                if (File.Exists(path))
                {
                    string pathThis = @"更新内容";
                    DirectoryInfo root = new DirectoryInfo(pathThis);
                    foreach(FileInfo s in root.GetFiles())
                    {
                        //MessageBox.Show(s.FullName + "\n" + s.Name + "\n" + s.Extension);
                        if(File.Exists(Path.Combine(@textBox1.Text.Trim() , s.Name)))
                            File.Copy(Path.Combine(@"更新内容",s.Name), Path.Combine(@textBox1.Text.Trim(),s.Name), true);
                        else
                            File.Copy(Path.Combine(@"更新内容", s.Name),@textBox1.Text.Trim());
                    }   
                    //MessageBox.Show("升级成功");
                    timer1.Stop();
                    mypanel2.Location = new Point((this.Width-mypanel2.Height)/2,(this.Height-mypanel2.Height)/2);
                    mypanel2.Visible = true;
                    roundButton1.Enabled = false;
                    roundButton2.Enabled = false;
                    roundButton3.Enabled = false;
                    timer2.Start();
                    
                }
                else
                {
                    MessageBox.Show("您未在["+textBox1.Text.Trim()+"]中安装：" + APPname+"\n请按绿色按钮重新选择正确的路径\n或者检查{-本机-}是否安装-" + APPname, "更 新 失 败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    folderBrowserDialog1.SelectedPath = "";
                    //textBox1.Text = @"C:\Program Files(x86)";
                    //folderBrowserDialog1.SelectedPath = @"C:\Program Files(x86)";
                }
            }
        }

        double x = 0;
        double pi = 3.1415926535f;
        private void showAcc(double step)
        {
            //clearLighting(mypanel2);
            int x1X = (mypanel2.Width - x1.Width) / 2 +Convert.ToInt32(50*Math.Sin(step));//+3*pi/4
            int x1Y = (mypanel2.Height - x1.Height) / 2- Convert.ToInt32(50 * Math.Cos(step));
            int x2X = (mypanel2.Width - x2.Width) / 2 ;
            //int x2Y = x1Y;// 
            int x3X= (mypanel2.Width - x3.Width) / 2 + Convert.ToInt32(50 * Math.Cos(step+pi/2));//+
            int x3Y = (mypanel2.Height - x3.Height) / 2 - Convert.ToInt32(50 * Math.Sin (step+pi/2));

            x1.Location = new Point(x1X,x1Y);
            //lighting(x1,mypanel2,x1.NormalColor);
            x2.Location = new Point(x2X, x1Y);
            //lighting(x2, mypanel2, x2.NormalColor);
            x3.Location = new Point(x3X, x3Y);
            //lighting(x3, mypanel2, x3.NormalColor);
            if (x1.Location.X==x3.Location.X)
            {
                if (x2.NormalColor == x1.NormalColor)
                {
                    x2.NormalColor = x3.NormalColor;
                }
                else
                    x2.NormalColor = x1.NormalColor;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            showAcc(x);
            x += 0.08;
            if(x>=24)
            {
                timer2.Stop();
                //File.Delete(@"更新内容");
                MessageBox.Show("更 新 成 功","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }    
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
        int picNum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(picNum <=3)
            {
                drawArc();
                pictureBox1.BackgroundImage = ig[picNum];
                picNum++;
            }
            else
            {
                picNum = 0;
            }
        }
        private void roundButton2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "请选择您之前安装[-" + APPname + "-]的文件夹！";
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                string path = Path.Combine(@textBox1.Text.Trim(), "快眼刷题.exe");
                if (!File.Exists(path))
                {
                    MessageBox.Show("您未在[" + textBox1.Text.Trim() + "]中安装：" + APPname + "\n请按绿色按钮重新选择正确的路径\n或者检查{-本机-}是否安装-" + APPname, "安 装 失 败",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Text = "";
                }
            }
        }



        System.Drawing.Point p;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new System.Drawing.Point(e.Location.X, e.Location.Y);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + e.X - p.X, this.Location.Y + e.Y - p.Y);
            }
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            if (picNum >0)
            { 
                picNum--;
            }
            else
            {
                picNum = 3;
            }

            drawArc();
            pictureBox1.BackgroundImage = ig[picNum];
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            if (picNum < 3)
            {
                picNum++;
            }
            else
            {
                picNum = 0;
            }
            drawArc();
            pictureBox1.BackgroundImage = ig[picNum];
        }

        private void roundButton4_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void roundButton4_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void roundButton5_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void roundButton5_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void roundButton4_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new System.Drawing.Point(e.Location.X, e.Location.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + e.X - p.X, this.Location.Y + e.Y - p.Y);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public enum ControlState { Hover, Normal, Pressed }
    public class RoundButton : System.Windows.Forms.Button
    {
        private int radius;//半径 
        private Color _baseColor = Color.FromArgb(175, 238, 238);//基颜色
        private Color _hoverColor = Color.FromArgb(175, 238, 238);//停留颜色
        private Color _normalColor = Color.FromArgb(255, 99, 71);//初始颜色
        private Color _pressedColor = Color.FromArgb(255, 130, 71);//单击颜色
        //圆形按钮的半径属性
        [CategoryAttribute("布局"), BrowsableAttribute(true), ReadOnlyAttribute(false)]
        public int Radius
        {
            set
            {
                radius = value;
                this.Invalidate();
            }
            get
            {
                return radius;
            }
        }
        [DefaultValue(typeof(Color), "51, 161, 224")]
        public Color NormalColor
        {
            get
            {
                return this._normalColor;
            }
            set
            {
                this._normalColor = value;
                this.Invalidate();
            }
        }
        public Color HoverColor
        {
            get
            {
                return this._hoverColor;
            }
            set
            {
                this._hoverColor = value;
                this.Invalidate();
            }
        }
        public Color PressedColor
        {
            get
            {
                return this._pressedColor;
            }
            set
            {
                this._pressedColor = value;
                this.Invalidate();
            }
        }
        public ControlState ControlState
        {
            get;set;
        }
        protected override void OnMouseEnter(EventArgs e)//鼠标进入时
        {
            base.OnMouseEnter(e);
            ControlState = ControlState.Hover;//正常
        }
        protected override void OnMouseLeave(EventArgs e)//鼠标离开
        {
            base.OnMouseLeave(e);
            ControlState = ControlState.Normal;//正常
        }
        protected override void OnMouseDown(MouseEventArgs e)//鼠标按下
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)//鼠标左键且点击次数为1
                ControlState = ControlState.Pressed;//按下的状态
        }
        protected override void OnMouseUp(MouseEventArgs e)//鼠标弹起
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (ClientRectangle.Contains(e.Location))//控件区域包含鼠标的位置
                    ControlState = ControlState.Hover;
                else
                    ControlState = ControlState.Normal;
            }
        }
        public RoundButton()
        {
            Radius = 15;
            this.ForeColor = Color.White;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.SetStyle(ControlStyles.UserPaint |  //控件自行绘制，而不使用操作系统的绘制
             ControlStyles.AllPaintingInWmPaint | //忽略擦出的消息，减少闪烁。
             ControlStyles.OptimizedDoubleBuffer |//在缓冲区上绘制，不直接绘制到屏幕上，减少闪烁。
             ControlStyles.ResizeRedraw | //控件大小发生变化时，重绘。                  
             ControlStyles.SupportsTransparentBackColor, true);//支持透明背景颜色
        }
        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;
            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }
            return Color.FromArgb(a, r, g, b);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            var path = GetRoundedRectPath(rect, radius);
            this.Region = new Region(path);
            Color baseColor = this.NormalColor;
            switch (ControlState)
            {
                case ControlState.Hover:
                    baseColor = this.HoverColor;
                    break;
                case ControlState.Pressed:
                    baseColor = this.PressedColor;
                    break;
                case ControlState.Normal:
                    baseColor = this.NormalColor;
                    break;
                default:
                    baseColor = this._normalColor;
                    break;
            }
            using (SolidBrush b = new SolidBrush(baseColor))
            {
                e.Graphics.FillPath(b, path);
                System.Drawing.Font fo = new System.Drawing.Font(this.Font.Name,this.Font.Size);
                Brush brush = new SolidBrush(this.ForeColor);
                StringFormat gs = new StringFormat();
                gs.Alignment = StringAlignment.Center; //居中
                gs.LineAlignment = StringAlignment.Center;//垂直居中
                e.Graphics.DrawString(this.Text, fo, brush, rect, gs);
            }
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            //Point lo = new Point(rect.Location.X + 10, rect.Location.Y + 10);
            Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
    class mypanel : Panel
    {
        private int raidus = 10;
        private int borderSize = 1;
        private Color borderColor = Color.White;
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                this.borderSize = value;
            }
        }
        public int Raidus
        {
            get { return raidus; }
            set { if (value > 0)
                    raidus = value;
                else
                    raidus = 10;
                this.Invalidate();
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            var path = GetRoundedRectPath(rect, raidus);
            this.Region = new Region(path);
            
            using (SolidBrush b = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(b, path);
            }
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);
            
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
}
