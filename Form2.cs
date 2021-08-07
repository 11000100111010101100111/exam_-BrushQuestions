using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSWord = NPOI.XSSF.UserModel;
using System.IO;
//using NPOI.XSSF.UserModel;
using myword = NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Drawing.Drawing2D;
using Rectangle = System.Drawing.Rectangle;
using Point = System.Drawing.Point;
using System.Runtime.InteropServices;

namespace 快眼刷题
{
    public partial class Form2 : Form
    {
        public ContactDelegate essage;
        public static Form2 f2;
        public Form2()
        {
            InitializeComponent();
            f2 = this;
        }
        public void getnum(string path, ref int nums, int cell, int pNum, string str)//读取某列指定内容记录的数目
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            
            myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
            myexcle = excl.GetSheetAt(0);
            for (int j = 0; j < pNum; j++)
            {
                if (myexcle.GetRow(j).GetCell(cell).ToString() == str)
                    nums++;
            }

            fs.Close();
        }
        public void add_row(string path, Dictionary<int, string[]> values, int nums, int cells)//修改具有nums行、cells列的工作表值为values[nums,cells]
        {
            myword.HSSFWorkbook excl = new myword.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet myexcle = excl.CreateSheet("Sheet1");
            FileStream fs = File.OpenWrite(path);
            for (int i = 0; i < nums; i++)
            {
                IRow Row = myexcle.CreateRow(i);
                for (int j = 0; j < cells; j++)
                {
                    Row.CreateCell(j).SetCellValue(values[i+1][j]);
                }
            }
            excl.Write(fs);
            fs.Close();
        }

        public void readProNum(string path, ref int number)//返回path地址下excle的总记录数
        {
            NPOI.SS.UserModel.ISheet myexcle;

            number = 0;
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
               
                    try
                    {
                        myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                        myexcle = excl.GetSheetAt(0);
                        number = myexcle.LastRowNum + 1;
                    }
                    catch { number = 0; }
                fs.Close();
            }
            else
            { }
        }
        public void readProMessage(string path, int pNum, int cell, ref Dictionary<int, string[]> arr, String str, ref int star)
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
            myexcle = excl.GetSheetAt(0);
            
            for (int j = 0; j < pNum; j++)
            {
                string item = myexcle.GetRow(j).GetCell(cell).ToString();
                if (item == str)
                {
                    string[] temp = new string[10];
                    temp[0] = (star+1).ToString();
                    for (int i = 1; i < 10; i++)
                    {
                        temp[i] = myexcle.GetRow(j).GetCell(i).ToString();
                    }
                    temp[9] = "O";
                    arr.Add(star+1, temp);
                    star++;
                }
            }
            fs.Close();
        }
        public void readProMessage(string path, int pNum, int cell, ref Dictionary<int,string[]> arr, ref int star)
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
            myexcle = excl.GetSheetAt(0);
            
            for (int j = 0; j < pNum; j++)
            {
                string item = myexcle.GetRow(j).GetCell(cell).ToString();
                char temp = Convert.ToChar(item);
                if (temp > '9' || temp < '0')
                {
                    string[] str = new string[10];
                    str[0] = (star+1).ToString();
                    for (int i = 1; i < 9; i++)
                    {
                        str[i] = myexcle.GetRow(j).GetCell(i).ToString();
                    }
                    str[9] ="O";
                    arr.Add(star+1,str);
                    star++;
                }
            }
            fs.Close();
        }


        static int Num = 0;
        public string proPath = @"我的题库.xls";
        int[] R = {
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
        240, 220, 200, 180, 160, 140, 120, 100, 80, 60, 40, 20, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240 };

        int[] G = {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240,
        255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };

        int []B = {
                0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240,
        255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
        240, 220, 200, 180, 160, 140, 120, 100, 80, 60, 40, 20, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void Form2_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            progressBar1.Maximum = r.Next(90, 120);
            //MessageBox.Show(R.Length.ToString()+" "+G.Length.ToString()+" "+B.Length.ToString());

            float progress = ((float)progressBar1.Value + 2) / (float)progressBar1.Maximum * 100.00f;
            label1.Text =progress.ToString("f2") + "%";

            progressBar1.Value = 10;

            elliButton1.Parent = this;
            elliButton1.Size = new System.Drawing.Size(30, 30);
            elliButton1.Top = this.Height/2-elliButton1.Height/2 - (a * maxT * maxT) / 2;
            elliButton1.Left = this.Width/2-elliButton1.Width/2;

            elliButton1.BackColor = Color.FromArgb(0 ,206 ,209);

            label1.Left = this.Width/2 - label1.Width/2;
            label1.Top = this.Height / 2 + elliButton1.Height / 2;

            label3.Top = 0;
            label3.Left = 0;

            label2.Top = progressBar1.Top - label2.Height*3/2;
            label2.Left = this.Width / 2 - label2.Width / 2;

            try
            {
                if (!File.Exists(@"收藏夹.xls"))
                    File.Create(@"收藏夹.xls");
                if (!File.Exists(@"错题本.xls"))
                    File.Create(@"错题本.xls");
            }
            catch 
            {
                MessageBox.Show("文件创建失败！");
                this.Close();
            }
            timer2.Start();
        }

        Point p;
        
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + e.X - p.X, this.Location.Y + e.Y - p.Y);
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            p = new System.Drawing.Point(e.Location.X, e.Location.Y);
        }
        public void downBut()
        {
            if (t >= 0 && t <= maxT)
            {
                timer2.Interval = 100;
                h = (a * t * t) / 2;
            }
            else if (t > maxT && t <= maxT + changeSizeT)
            {
                timer2.Interval = 10;
                h = (a * (maxT) * (maxT)) / 2 + t - maxT;
                elliButton1.Left -= changeSizeT / 2;
                elliButton1.Width += changeSizeT;
                elliButton1.Height -= changeSizeT;
            }
            else if (t > maxT + changeSizeT && t <= maxT + 2 * changeSizeT)
            {
                timer2.Interval = 10;
                h = (a * (maxT) * (maxT)) / 2 - t + maxT;
                elliButton1.Left += changeSizeT / 2;
                elliButton1.Width -= changeSizeT;
                elliButton1.Height += changeSizeT;
            }
            else if (t > maxT + 2 * changeSizeT && t < 2 * maxT + 2 * changeSizeT)
            {
                timer2.Interval = 100;
                h = (a * (maxT) * (maxT)) / 2 - (a * (t - maxT - 2 * changeSizeT) * (t - maxT - 2 * changeSizeT)) / 2;
            }
            else
            {
                timer2.Interval = 100;
                t = 0;
                h = 0;
                Random r = new Random();
                int tempCol = r.Next(0, R.Length - 1);
                elliButton1.BackColor = Color.FromArgb(R[tempCol] ,G[ tempCol] ,B[tempCol] );
            }
            t++;
            elliButton1.Top = h + this.Height/2-elliButton1.Height/2 - (a * maxT * maxT) / 2;
            
        }
        int t = 0, maxT =4, changeSizeT = 4, h = 0, a = 4;

        AnsProblem.ElliButton elliButton1 = new AnsProblem.ElliButton();
        private void timer2_Tick(object sender, EventArgs e)
        {
            downBut();
            drawRainbow();
            Num++;
            if (progressBar1.Value >= progressBar1.Maximum - 1)
            {
                timer2.Stop();
                if (!File.Exists(proPath))
                {
                    if (!File.Exists(@"我的题库.xls"))
                        File.Create(@"我的题库.xls");

                    Chiose ch = new Chiose();
                    ch.Show();
                }
                else
                {
                    Form1 f1 = new Form1();
                    f1.Show();
                }
                this.Hide();
            }
            float progress = ((float)progressBar1.Value + 2) / (float)progressBar1.Maximum * 100.00f;
            label1.Text =progress .ToString("f2")+"%";
            label1.Left = this.Width / 2 - label1.Width / 2;
            label1.Top = this.Height / 2 + elliButton1.Height / 2;

            label1.BackColor = elliButton1.BackColor ;
            progressBar1.Value += 1;
        }
        int te = 1;
        int Clo=0;
        public void drawRainbow()
        {
            
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
           
            int leght = R.Length;
            if (Clo < leght)
            {
                Pen p = new Pen(Color.FromArgb(R[Clo], G[Clo], B[Clo]),1.9f);
                Rectangle rect = new Rectangle(new Point(this.Width/2-50 - te/2,this.Height/2-50 - te/2 ), new Size(te+100, te+100));
                Random r = new Random();
                int num = r.Next(0,60);
                g.DrawArc(p, rect, 200-num, 140+2*num);
               
                Clo++;
            }
            te +=2;
        }
    }
}
