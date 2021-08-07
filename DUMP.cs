using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 快眼刷题
{
    public partial class DUMP : Form
    {
        public DUMP()
        {
            InitializeComponent();
            
        }
        public int num = 100;
        public int deep = 10;

        ///C# 窗体程序，窗体上控件过多，会导致打开程序时窗体闪烁，下面有个不错的方法
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {

        //        CreateParams cp = base.CreateParams;

        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED  

        //        if (this.IsXpOr2003 == true)
        //        {
        //            cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED
        //            this.Opacity = 1;
        //        }

        //        return cp;

        //    }

        //}  //防止闪烁

        //private Boolean IsXpOr2003
        //{
        //    get
        //    {
        //        OperatingSystem os = Environment.OSVersion;
        //        Version vs = os.Version;

        //        if (os.Platform == PlatformID.Win32NT)
        //            if ((vs.Major == 5) && (vs.Minor != 0))
        //                return true;
        //            else
        //                return false;
        //        else
        //            return false;
        //    }
        //}


    private void DUMP_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }
        //    public void Wait(int time, int times)
        //    {
        //        drawcir leftC = new drawcir();

        //        leftC.Time = time;
        //        leftC.R = 36;
        //        leftC.D = 0;

        //        leftC.P = new Point(this.Width / 2 - leftC.R - leftC.D / 2, (this.Height - 20) / 2);

        //        leftC.PR = new Point(this.Width / 2 - leftC.D / 2, (this.Height - 20) / 2);

        //        leftC.Sl = new System.Drawing.Size(40, 40);
        //        leftC.Sr = new System.Drawing.Size(40, 40);

        //        leftC.MoveStep = 2;
        //        int i = 0;
        //        while (i < times)
        //        {
        //            int t = 0, d = 0;
        //            while (t < 40)
        //            {
        //                Color temp;
        //                if (t < 20)
        //                {
        //                    leftC.MoveStep = 2;
        //                    d = -2 * t * leftC.MoveStep;

        //                    if (t == 10 || t == 30)
        //                    {
        //                        temp = leftC.ColorL;
        //                        leftC.ColorL = leftC.ColorR;
        //                        leftC.ColorR = temp;
        //                    }
        //                }

        //                else
        //                {
        //                    leftC.MoveStep = -2;
        //                    d = -2 * t * leftC.MoveStep - 160;

        //                    if (t == 10 || t == 30)
        //                    {
        //                        temp = leftC.ColorL;
        //                        leftC.ColorL = leftC.ColorR;
        //                        leftC.ColorR = temp;
        //                    }
        //                }
        //                leftC.move(d);
        //                t++;
        //            }
        //            leftC.stop();
        //            i++;
        //        }
        //    }

        //    public class drawcir
        //    {
        //        private Color colorR = Color.Blue;
        //        private Color colorL = Color.Red;
        //        private System.Drawing.Size sl = new System.Drawing.Size(10, 10);
        //        private System.Drawing.Size sr = new System.Drawing.Size(10, 10);
        //        private int r = 10;
        //        private Point p = new Point(0, 0);
        //        private Point pR = new Point(50, 0);
        //        private int d = 40;
        //        private int moveStep = 1;
        //        private int time = 10;


        //        public int Time
        //        {
        //            set { this.time = value; }
        //            get { return this.time; }
        //        }
        //        public int MoveStep
        //        {
        //            set
        //            {

        //                this.moveStep = value;
        //            }
        //            get { return this.moveStep; }
        //        }
        //        public int D
        //        {
        //            set
        //            {
        //                if (value > 0)
        //                    this.d = value;
        //            }
        //            get { return this.d; }
        //        }
        //        public Color ColorR
        //        {
        //            set
        //            {

        //                this.colorR = value;
        //            }
        //            get { return colorR; }
        //        }
        //        public Color ColorL
        //        {
        //            set
        //            {

        //                this.colorL = value;
        //            }
        //            get { return colorL; }
        //        }
        //        public int R
        //        {
        //            set
        //            {
        //                if (value > 0)
        //                    this.r = value;
        //            }
        //            get { return r; }
        //        }
        //        public Point P
        //        {
        //            set { this.p = value; }
        //            get { return p; }
        //        }
        //        public Point PR
        //        {
        //            set { this.pR = value; }
        //            get { return pR; }
        //        }
        //        public System.Drawing.Size Sl
        //        {
        //            set { sl = value; }
        //            get { return sl; }
        //        }
        //        public System.Drawing.Size Sr
        //        {
        //            set { sr = value; }
        //            get { return sr; }
        //        }
        //        public drawcir()
        //        {
        //            draw();
        //        }


        //        private void draw()
        //        {
        //            Graphics g = dp.CreateGraphics();
        //            g.SmoothingMode = SmoothingMode.HighQuality;
        //            //g.InterpolationMode = InterpolationMode.HighQualityBilinear ;
        //            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

        //            //左边小球
        //            Brush b = new SolidBrush(this.colorL);
        //            g.FillEllipse(b, new Rectangle(this.p, new System.Drawing.Size(this.r, this.r)));//

        //            //右边小球
        //            b = new SolidBrush(this.colorR);
        //            g.FillEllipse(b, new Rectangle(this.pR, new System.Drawing.Size(this.r, this.r)));//
        //        }
        //        private void clear()
        //        {
        //            Graphics g = dp.CreateGraphics();
        //            g.SmoothingMode = SmoothingMode.HighSpeed;
        //            g.InterpolationMode = InterpolationMode.Low;
        //            g.PixelOffsetMode = PixelOffsetMode.None;

        //            Brush b = new SolidBrush(dp.BackColor);
        //            g.FillEllipse(b, new Rectangle(new Point(this.p.X - 1, this.p.Y - 1), new System.Drawing.Size(this.r + 2, this.r + 2)));

        //            g.FillEllipse(b, new Rectangle(new Point(this.pR.X - 1, this.pR.Y - 1), new System.Drawing.Size(this.r + 2, this.r + 2)));
        //        }
        //        public void move(int step)
        //        {
        //            //clear();


        //            this.d = step;
        //            this.p.X += this.moveStep;
        //            this.pR.X -= this.moveStep;

        //            draw();


        //            System.Threading.Thread.Sleep(this.time);
        //        }

        //        public void stop()
        //        { clear(); }
        //    }

        //    private void button1_Click(object sender, EventArgs e)
        //    {
        //        Wait(10, 20);
        //    }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (num <= 0 || this.Opacity <= 0.02)
            //{
            //    timer1.Stop();
            //    this.Close();
            //    this.Dispose();
            //}
            //else
            //{
            //    this.Opacity -= 0.01;
            //    Wait(deep, 2);
            //    num--;
            //}
        }
    }


}
