using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 快眼刷题
{
    public partial class allTest : Form
    {
        public allTest()
        {
            InitializeComponent();
        }

        Dictionary<int, string> arr = new Dictionary<int, string> { };
        int drawPoints = 0;
        private void allTest_Load(object sender, EventArgs e)
        {
            star();
            //FileStream fs = new FileStream(@"考试记录.txt",FileMode.Open);
            //StreamReader sr = new StreamReader(fs, Encoding.UTF8 ,true);
            //string line = "";

            //int i = 0;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    arr.Add(i, line);
            //    i++;
            //}
            //sr.Close();
            //listBox1.Items.Clear();
            //string[] temp = new string[arr.Count];
            //drawP = new Point[arr.Count];
            //i = 0;
            //int step = 0;

            //step = 0;
            //if (arr.Count>1)
            //{
            //    while (step < pictureBox1.Width-20)
            //    {
            //        step = (arr.Count - 1) * (++i);
            //    }
            //    step = --i;
            //}
            //i = 0;
            ////step= (pictureBox1.Width - 20) / (arr.Count-1);

            //int top = 0;
            //int bottom = 100;
            //float average = 0.0f;
            //int sum = 0;
            //foreach (KeyValuePair<int, string> item in arr)
            //{
            //    string[] m = item.Value.Split('_');
            //    drawP[i] = new Point(10 + i * step, 450 - Convert.ToInt32(m[1]) * 4);
            //    temp[i] = m[4];
            //    if (Convert.ToInt32(m[1]) >= top)
            //        top = Convert.ToInt32(m[1]);
            //    if (Convert.ToInt32(m[1]) <= bottom)
            //        bottom = Convert.ToInt32(m[1]);
            //    sum += Convert.ToInt32(m[1]);
            //    i++;
            //}

            //average = sum*1.00f / arr.Count;

            //set(arr.Count, top, bottom,average);

            //listBox1.Items.AddRange(temp);

            ////if (arr.Count <= 10)
            //    drawPoints = arr.Count;
            ////else
            ////    drawPoints = 10;
            //timer1.Start();
        }
        private void star()
        {
            arr.Clear();
            listBox1.Items.Clear();
            FileStream fs = new FileStream(@"考试记录.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true);
            string line = "";

            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    arr.Add(i, line);
                    i++;
                }
            }
            sr.Close();
            listBox1.Items.Clear();
            string[] temp = new string[arr.Count];
            drawP = new Point[arr.Count];
            i = 0;
            int step = 0;

            step = 0;
            if (arr.Count > 1)
            {
                while (step < pictureBox1.Width - 20)
                {
                    step = (arr.Count - 1) * (++i);
                }
                step = --i;
            }
            i = 0;
            //step= (pictureBox1.Width - 20) / (arr.Count-1);

            int top = 0;
            int bottom = 100;
            float average = 0.0f;
            int sum = 0;
            foreach (KeyValuePair<int, string> item in arr)
            {
                string[] m = item.Value.Split('_');
                drawP[i] = new Point(10 + i * step, 450 - Convert.ToInt32(m[1]) * 4);
                temp[i] = m[0];
                //temp[i]=m[4];
                if (Convert.ToInt32(m[1]) >= top)
                    top = Convert.ToInt32(m[1]);
                if (Convert.ToInt32(m[1]) <= bottom)
                    bottom = Convert.ToInt32(m[1]);
                sum += Convert.ToInt32(m[1]);
                i++;
            }

            average = sum * 1.00f / arr.Count;

            set(arr.Count, top, bottom, average);

            listBox1.Items.AddRange(temp);

            //if (arr.Count <= 10)
            drawPoints = arr.Count;
            //else
            //    drawPoints = 10;
            timer1.Start();
        }
        private void set(int num1,int num2,int num3,float num4)
        {
            label9.Text = num1.ToString();//习题次数
            label17.Text = num4.ToString("f2");//平均分
            label19.Text = num2.ToString();//最高分
            label21.Text = num3.ToString();//最低分
        }
        private void mybutton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f1.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setMessage(listBox1.SelectedIndex);
        }

        private void setMessage(int selectIndex)
        {
            label2.Text = "模拟考试-" + (selectIndex + 1).ToString();
            string[] m = arr[selectIndex].Split('_');
            //label2.Text = m[4];
            label4.Text = m[1].ToString();//成绩
            label5.Text = m[0].Trim().Substring(1, m[0].Length - 8);//时间
            label7.Text = m[2].Trim().ToString();//等级
            label15.Text = m[3].Trim().ToString();//题库来源
            trackBar1.Value = drawP[selectIndex].X;
            listBox1.SelectedIndex = selectIndex;
        }

        int times = 0;
        Point[] drawP;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Line();
            if (arr.Count  > 1)
            {
                if (times <= drawPoints - 2)
                {
                    string[] m = arr[times].Split('_');
                    string[] m1 = arr[times + 1].Split('_');
                    drawLine(drawP[times], drawP[times + 1], m[1], m1[1]);
                    trackBar1.Value = drawP[times + 1].X;
                    setMessage(times);
                }
                else
                {
                    if (arr.Count < 5)
                        drawStr("     考试次数太少了吧！\n增加考试次数成绩数据更精准哦！",Color.FromArgb(255, 69, 0),new Point(pictureBox1.Width/4, pictureBox1.Height*5/8));
                    else if(arr.Count<10&&arr.Count>=5)
                        drawStr("测验多多益善，练习效果更佳！", Color.FromArgb(60, 179, 113), new Point(pictureBox1.Width / 4, pictureBox1.Height * 5 / 8));
                    else
                        drawStr("不错呦！已经有"+arr.Count+"次成绩了！", Color.FromArgb(60, 179, 113), new Point(pictureBox1.Width / 4, pictureBox1.Height * 5 / 8));
                    timer1.Stop();
                }
            }
            else
            {
                if (times <= drawPoints - 1)
                {
                    string[] m = arr[times].Split('_');
                    drawLine(drawP[times], drawP[times], m[1], m[1]);
                    trackBar1.Value = drawP[times].X;
                    setMessage(times);
                }
                else
                {
                    drawStr("没有太多的自测数据 :)", Color.FromArgb(255, 69, 0), new Point(pictureBox1.Width / 4, pictureBox1.Height * 5 / 8));
                    timer1.Stop();
                }
            }
            times++;
        }

        private void drawStr(string str,Color clo, Point strP)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            // g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.DrawString(str,new Font("楷体", 20f, FontStyle.Regular), new SolidBrush(clo), strP);
        }
        private void Line()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
           // g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Pen p = new Pen(Color.FromArgb(176, 196, 222),2);
            g.DrawLine(p,new Point(0,pictureBox1.Height/2-4*10),new Point(pictureBox1.Width,pictureBox1.Height/2-4*10));
            g.DrawLine(p,new Point(0,0),new Point(0,pictureBox1.Height));
            g.DrawLine(p, new Point(pictureBox1.Width, 0), new Point(pictureBox1.Width, pictureBox1.Height));

            p = new Pen(Color.FromArgb(176, 196, 222), 0.5f);
            for(int i=0;i<11;i++)
            {
                g.DrawLine(p, new Point(0, 50+40*i), new Point( 10, 50 + 40 * i));
                float strSize = 10f;
                if (i == 0)
                    strSize = 15f;
                g.DrawString(((10 - i) * 10).ToString(), new Font("楷体", strSize, FontStyle.Regular), new SolidBrush(Color.FromArgb(105, 105, 105)), new Point(10, 50 + 40 * i - 10));
                g.DrawLine(p, new Point(pictureBox1.Width-10, 50 + 40 * i), new Point(pictureBox1.Width, 50 + 40 * i));
                strSize = 10f;
                g.DrawString(((10 - i) * 10).ToString(), new Font("楷体", strSize, FontStyle.Regular), new SolidBrush(Color.FromArgb(105, 105, 105)), new Point(pictureBox1.Width - 30, 50 + 40 * i-10));
            }
        }
        private void clear()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Brush bru = new SolidBrush(pictureBox1.BackColor);
            g.FillRectangle(bru,new Rectangle( new Point(0,0),pictureBox1.Size));
            Line();
        }
        private void drawLine(Point p1,Point p2,string num1,string num2)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;


            Brush bush = new SolidBrush(Color.Blue );
            g.FillEllipse(bush,new Rectangle(new Point(p1.X-5,p1.Y-5),new Size(10,10)));

            g.DrawString(num1, new Font("楷体", 14f, FontStyle.Regular), new SolidBrush(Color.Green ), new Point(p1.X -9, p1.Y - 19));

            Pen pen = new Pen(Color.Red,3f);
            g.DrawLine(pen,p1,p2);

            g.FillEllipse(bush, new Rectangle(new Point(p2.X - 5, p2.Y - 5), new Size(10, 10)));

            g.DrawString(num2, new Font("楷体", 14f, FontStyle.Regular), new SolidBrush(Color.Green), new Point(p2.X - 9, p2.Y - 19));
            
            pen = new Pen(Color.FromArgb(176, 196, 222), 1);
            g.DrawLine(pen, p1, new Point(p1.X, pictureBox1.Height));
            g.DrawLine(pen, p2, new Point(p2.X, pictureBox1.Height));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int pX = 0, i = 0, I = 0;
            int starP = trackBar1.Value;
            int itemp = pictureBox1.Width;
            int flageP = 0;
            foreach (Point itemP in drawP)
            {
                if (itemP.X != starP)
                {
                    if (itemP.X > trackBar1.Value)
                        pX = itemP.X - trackBar1.Value;
                    else
                        pX = trackBar1.Value - itemP.X;
                    if (itemp > pX)
                    {
                        itemp = pX;
                        flageP = itemP.X;
                        I = i;
                    }
                }
                i++;
            }
            trackBar1.Value = flageP;
            setMessage(I);
        }
        System.Drawing.Point p;
        private void allTest_MouseDown(object sender, MouseEventArgs e)
        {
             p = new System.Drawing.Point(e.Location.X, e.Location.Y);
        }

        private void allTest_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = this.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {
                Brush bu = new SolidBrush(Color.Red);
                ps.FillEllipse(bu, e.X - 5, e.Y - 5, 10, 10);
            }
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + e.X - p.X, this.Location.Y + e.Y - p.Y);
                ps.Clear(this.BackColor);
                ps.Dispose();
            }
        }

        private void mybutton2_Click(object sender, EventArgs e)
        {
            clear();
            star();
            times = 0;
            timer1.Start();
        }
    }
}
