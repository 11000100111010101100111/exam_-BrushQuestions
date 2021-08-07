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
using myword=NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Drawing.Drawing2D;
using Rectangle = System.Drawing.Rectangle;
using Point = System.Drawing.Point;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Windows;
using NPOI.XWPF.UserModel;

namespace 快眼刷题
{
    public partial class Form1 : Form
    {
        public static Form1 f1;
        public Form1()
        {
            InitializeComponent();
            f1 = this;
        }

        ////禁用窗体信息，禁止重绘
        //[DllImport("user32")]
        //private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        //private const int WM_SETREDRAW = 0xB;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        public Dictionary<string, string> proTypes = new Dictionary<string, string> { { "J", "数据结构" },
        { "K" , "数据库原理"},{"W", "计算机网络"},{"R","软件工程" },{"Z","操作系统"},
        {"C","计算机应用基础"},{"D","计算机多媒体技术"},{"Y","计算机硬件基础"},{"H","计算机移动互联应用"},{"S","数据表示和计算"},{"L","离散数学"},
        {"Q","软件知识产权"},{"1","C语言程序设计"},{"2","C++程序设计"},{"3","Java语言程序设计"},{"4","JavaScript"},{"5","C#程序设计"}};
        public void showTxtBox(System.Windows.Forms.TextBox tb, ref string strItem, int lineMax)
        {
            int nNum = 0;
            foreach (var item in strItem)
            {
                if (item == '\n')
                    nNum++;
            }
            if (nNum < lineMax)
            {
                tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
                for (int i = 1; i < lineMax - nNum; i++)
                {
                    if (i % 2 != 0)
                        strItem = "\r\n" + strItem;
                }
            }
            else
                tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }
        public void add_row(string path, string[,] values, int nums, int cells)//修改具有nums行、cells列的工作表值为values[nums,cells]
        {
            myword.HSSFWorkbook excl = new myword.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet myexcle = excl.CreateSheet("Sheet1");
            FileStream fs = File.OpenWrite(path);
            for (int i = 0; i < nums; i++)
            {
                IRow Row = myexcle.CreateRow(i);
                for (int j = 0; j < cells; j++)
                {
                    Row.CreateCell(j).SetCellValue(values[i, j]);
                }
            }
            excl.Write(fs);
            fs.Close();
        }

        public void setNew_value(string path, int row, int cell, string new_value, int nums, string[,] strs)//读取path地址里的所有记录
        {
            myword.HSSFWorkbook excl = new myword.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet myexcle = excl.CreateSheet("Sheet1");
            FileStream fs = File.OpenWrite(path);
            for (int i = 0; i < nums; i++)
            {
                IRow Row = myexcle.CreateRow(i);
                for (int j = 0; j < 10; j++)
                {
                    if (i == row && j == cell)
                    {
                        Row.CreateCell(j).SetCellValue(new_value);
                    }
                    else
                        Row.CreateCell(j).SetCellValue(strs[i, j]);
                }

            }
            excl.Write(fs);
            fs.Close();
        }

        public void readAPro(string path, ref string[,] str, int pNum)//读取path地址里的默认10列的所有行记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
            myexcle = excl.GetSheetAt(0);
            for (int j = 0; j < pNum; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    str[j, i] = myexcle.GetRow(j).GetCell(i).ToString();
                }
            }
            fs.Close();
        }
        public void readAPro(string path, ref string[,] str, int pNum, int cellLength)//读取path地址里具有cellLength列的的所有行记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
            myexcle = excl.GetSheetAt(0);
            for (int j = 0; j < pNum; j++)
            {
                for (int i = 0; i < cellLength; i++)
                {
                    str[j, i] = myexcle.GetRow(j).GetCell(i).ToString();
                }
            }
            fs.Close();
        }
        public void readAPro(string path, ref string[,] str)//读取path地址里的所有记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int j = 0; j < proNum; j++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        str[j, i] = myexcle.GetRow(j).GetCell(i).ToString();
                    }
                }
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int j = 0; j < proNum; j++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        str[j, i] = myexcle.GetRow(j).GetCell(i).ToString();
                    }
                }
            }
            fs.Close();
        }
        public void getnum(string path, ref int nums, int cell, int pNum, string[] str)//读取某列指定内容记录的数目
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int j = 0; j < pNum; j++)
                {
                    if (myexcle.GetRow(j).GetCell(cell).ToString() == str[0] || myexcle.GetRow(j).GetCell(cell).ToString() == str[1])
                        nums++;
                }
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int j = 0; j < pNum; j++)
                {
                    if (myexcle.GetRow(j).GetCell(cell).ToString() == str[0] || myexcle.GetRow(j).GetCell(cell).ToString() == str[1])
                        nums++;
                }
            }

            fs.Close();
        }
        public void readAPro(string path, ref string[] str, int cell, int pNum)//读取path地址里某列
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int j = 0; j < pNum; j++)
                {
                    str[j] = myexcle.GetRow(j).GetCell(cell).ToString();
                }
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int j = 0; j < pNum; j++)
                {
                    str[j] = myexcle.GetRow(j).GetCell(cell).ToString();
                }
            }

            fs.Close();
        }
        public void readAPro(int row, string path, ref string[] str)//读取path地址里的某行记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int i = 0; i < 10; i++)
                {
                    str[i] = myexcle.GetRow(row).GetCell(i).ToString();
                }
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int i = 0; i < 10; i++)
                {
                    str[i] = myexcle.GetRow(row - 1).GetCell(i).ToString();
                }
            }
            fs.Close();
        }
        public void readAPro(string path, int rowStar, int rowEnd, int objecCell, ref string[] value)//读取path地址里的某行开始到某行结束的某列记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int i = rowStar, j = 0; i < rowEnd; i++, j++)
                {
                    value[j] = myexcle.GetRow(i).GetCell(objecCell).ToString();
                }
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int i = rowStar, j = 0; i < rowEnd; i++, j++)
                {
                    value[j] = myexcle.GetRow(i).GetCell(objecCell).ToString();
                }
            }
            fs.Close();
        }
        public void readAPro(string path, ref string str, int row, int cell)//读取path地址里的某行某列记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                str = myexcle.GetRow(row).GetCell(cell).ToString();
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                str = myexcle.GetRow(row).GetCell(cell).ToString();
            }
            fs.Close();
        }
        public void readAPro(int row, string path, ref string[] str, int length)//读取path地址里的某行记录
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.Equals(".xlsx"))
            {
                MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int i = 0; i < length; i++)
                {
                    str[i] = myexcle.GetRow(row).GetCell(i).ToString();
                }
            }
            else
            {
                myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                myexcle = excl.GetSheetAt(0);
                for (int i = 0; i < length; i++)
                {
                    str[i] = myexcle.GetRow(row - 1).GetCell(i).ToString();
                }
            }
            fs.Close();
        }
        public void readProNum(string path, ref int number)//返回path地址下excle的总记录数
        {
            NPOI.SS.UserModel.ISheet myexcle;
            number = 0;
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                if (path.Equals(".xlsx"))
                {
                    MSWord.XSSFWorkbook excl = new MSWord.XSSFWorkbook(fs);
                    myexcle = excl.GetSheetAt(0);
                    number = myexcle.LastRowNum;
                }
                else
                {
                    try
                    {
                        myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
                        myexcle = excl.GetSheetAt(0);
                        number = myexcle.LastRowNum + 1;
                    }
                    catch { number = 0; }
                }
                fs.Close();
            }
            else
            { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            Form2.f2.Dispose();
            Form2.f2.Close();
        }
        public int proNum = 0;//excle中题目总数
        public int proOver = 0;//上次答题的位置
        public int proStep = 0;//学习完成的题目数


        myProgressBar po;
        public void set_myprogressbar()
        {
            po.ValueColor = Color.Blue;
            po.Size = new System.Drawing.Size(200, 200);
            po.Location = new Point(this.Width / 2 - po.Width / 2, label1.Top - po.Height);
            po.Value = proStep;
            po.Minnum = 0;
            po.Maxnum = proNum;
            po.Parent = this;
            po.Visible = false;
            po.BackColor = this.BackColor;
            po.ValueWidth = 30;
            po.NullColor = Color.FromArgb(205, 201, 201);
            po.MouseEnter += Po_MouseEnter;
            po.MouseLeave += Po_MouseLeave;
            //mybutton8.Size = new System.Drawing.Size(po.Width-2*po.ValueWidth,po.Height-2*po.ValueWidth);
            mybutton9.Location = new Point((this.Width-mybutton9.Width)/2, label1.Top - (po.Height+mybutton9.Height)/2);
        }

        private void Po_MouseLeave(object sender, EventArgs e)
        {
            ////button8.Size = new System.Drawing.Size(button8.Width * 2, button8.Height * 2);
            ////button8.Location = new Point(button8.Location.X-button8.Width/4,button8.Location.Y-button8.Height/4 );
            //po.Width -= 20; po.Height -= 20;
            //po.ValueWidth -= 10;
            //po.Left += 10; po.Top += 10;
            //label1.Top -= 10;

            //po.Visible = true;
            //AnsProblem.an.clearLighting(this);
        }

        private void Po_MouseEnter(object sender, EventArgs e)
        {
            //po.Width += 20; po.Height += 20;
            //po.ValueWidth += 10;
            //po.Left -= 10; po.Top -= 10;
            //label1.Top += 10;
            //findProcess(Bt[0]);
            //po.Visible = true;

            ////button8.Location = new Point(button8.Location.X + button8.Width/4, button8.Location.Y + button8.Height/4);
            ////button8.Size = new System.Drawing.Size(button8.Width / 2, button8.Height / 2);
            //AnsProblem.an.lighting(po,this ,Color.Blue );
        }

        public void star()
        {

            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 5 * this.Height / 8);
            label1.BackColor = this.BackColor;
            label1.Visible = false;
            label3.Top = progressBar1.Top - label3.Height;
            label3.Left = this.Width / 2 - label3.Width / 2;

            //progressBar1.BackColor= this.BackColor;
            button1.BackColor = this.BackColor;
            button2.BackColor = this.BackColor;
            button3.BackColor = this.BackColor;
            button4.BackColor = this.BackColor;
            button5.BackColor = this.BackColor;
            button6.BackColor = this.BackColor;
        }

        mybutton[] Bt = new mybutton[8];
        private void Form1_Load(object sender, EventArgs e)
        {
            pen1 = new Pen(Color.Black);
            b = new SolidBrush(Color.FromArgb(255, 218, 185));
            foreach (System.Windows.Forms.Control bt in this.Controls)
            {
                if (bt is System.Windows.Forms.Button)
                {
                    if (!(bt is mybutton)&&!(bt is RoundButton)&& bt.Name != "button7")
                    {
                        bt.BackgroundImageLayout = ImageLayout.Center;
                        bt.MouseMove += Bt_MouseMove;
                        bt.MouseLeave += Bt_MouseLeave;
                    }
                }
            }


            f1.BackColor = Color.FromArgb(225, 255, 255);
            readProLine();
            readProNum(Form2.f2.proPath, ref proNum);
            string[] str = { "T", "F" };
            getnum(Form2.f2.proPath, ref proStep, 9, proNum, str);
            label1.Text = proStep.ToString() + @"\" + proNum.ToString();

            star();

            po = new myProgressBar();
            set_myprogressbar();
            po.Value = proStep;


            Color[] color = { Color.White, Color.FromArgb(255, 140, 0), Color.FromArgb(65, 105, 225), Color.FromArgb(193, 205, 193) };
            string[] BtTxt = { "查看进度", "选择题库", "导入题库", "题库管理", "版本信息", "获取跟多", "设置", "帮助" };
            for (int i = 0; i < 8; i++)
            {
                Bt[i] = new mybutton();
                createmyBt(
               Bt[i],
               pictureBox1.Parent,
               new System.Drawing.Size(120, 40),
               new System.Drawing.Point(0, 50 + i * Bt[i].Height * 2),
               color,
               BtTxt[i]);
                if(i==0)
                    Bt[i].NormalColor = Color.FromArgb(138, 43, 226);
                else
                    Bt[i].NormalColor = Color.FromArgb(106, 90, 205);
                Bt[i].HoverColor = Color.FromArgb(60, 179, 113);
                Bt[i].EnterForeColor = Color.White;
                Bt[i].LeftForeColor= Color.White;
                Bt[i].ControlState = 快眼刷题.ControlState.Normal;
                Bt[i].Multiples = 2;
                Bt[i].Click += Bt_Click;
            }
            pictureBox1.Width = Bt[0].Width + Bt[0].Width / 4;
            panel2.Left = pictureBox1.Right;
            panel2.Top = 0;
            panel2.Height = Bt[7].Bottom + Bt[7].Top - Bt[6].Bottom;
            panel1.Top = Bt[7].Bottom + Bt[7].Top - Bt[6].Bottom;
            panel1.Width = panel2.Right;
            pictureBox2.Left = panel2.Right;
            pictureBox2.Width = this.Width - panel2.Right;

            textBox1.Top = pictureBox2.Bottom;
            textBox1.Left = panel2.Right;

            groupBox1.Location = new Point((this.Width+panel2.Right-groupBox1.Width)/2,(label3.Top +pictureBox2.Bottom-groupBox1.Height)/2);
        }
        private void Bt_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Button)sender).ForeColor = Color.Black;
                p1 = Graphics.FromImage(ig);
                p1.FillRectangle(new SolidBrush(this.BackColor),
                    new Rectangle(
                        new Point(0, 0), new System.Drawing.Size(((System.Windows.Forms.Button)sender).Width,
                        ((System.Windows.Forms.Button)sender).Height)));
                ((System.Windows.Forms.Button)sender).BackgroundImage = ig;
            }
            catch { }
        }

        private void readProLine()//读取上次的答题记录
        {
            if (!File.Exists(@"阅题记录.txt"))
            {
                proOver = 1;
                File.Create(@"阅题记录.txt");

            }
            else
            {
                StreamReader sd = new StreamReader(@"阅题记录.txt", Encoding.UTF8);
                string line = "1";
                while ((line = sd.ReadLine()) != null)
                {
                    proOver = Convert.ToInt32(line.Trim());
                    //MessageBox.Show(line);
                }
                sd.Dispose();
                sd.Close();
                if (proOver < 1)
                {
                    line = "1";
                    proOver = 1;
                    StreamWriter sw = new StreamWriter(@"阅题记录.txt", false, Encoding.UTF8);
                    sw.Write(line);
                    sw.Close();
                }
            }
        }
        private void hideBut()
        {
            click_mybut1();
            Bt[0].Text = "查看进度";
            po.Visible = false;
            mybutton9.Visible = false;
            label1.Visible = false;
        }
        private void findProcess(mybutton bt)
        {
            click_mybut1();

            
            if (bt.Text == "查看进度")
            {
                string[] tf = { "F", "T" };
                int numtemp = 0;
                getnum(Form2.f2.proPath, ref numtemp, 9, proNum, tf);
                po.Value = numtemp; proStep = numtemp;

                bt.Text = "关闭进度";
                po.Visible = true;
                label1.Visible = true;
                mybutton9.Visible = true;
                //label2.Visible = true;
                //numericUpDown1.Visible = true;
                po.Value = 0;
                timer2.Start();
            }
            else
            {
                bt.Text = "查看进度";
                po.Visible = false;
                label1.Visible = false;
                mybutton9.Visible = false;
                //label2.Visible = false;
                //numericUpDown1.Visible = false;
            }
        }
        private void work_1()//选择题库
        {
            click_mybut1();

            Bt[0].Text = "关闭进度";
            findProcess(Bt[0]);
            
            if(System.Windows.Forms.MessageBox.Show("重新选择题库，本次习题记录将全部清空，确认？","进入欢迎界面",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(File.Exists(@"答题记录.txt"))
                { File.Delete(@"答题记录.txt"); }
                if (File.Exists(@"收藏夹.xls"))
                { File.Delete(@"收藏夹.xls"); }
                if (File.Exists(@"错题本.xls"))
                { File.Delete(@"错题本.xls"); }
                Chiose ch = new Chiose();
                ch.Show();
                Form1.f1.Close();
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }
        private void worke_2()//导入题库
        {
            click_mybut1();

            System.Windows.Forms.MessageBox.Show("导入题库为.xls后缀文件，文件必须有序且包含：\n\t题目序号，\n\t题目类型，\n\t题目，\n\t选项A、B、C、D，\n\t正确答案，\n\t题目难度，\n以及完成情况这10个必要单元格,请注意！\n否则会导致产生不必要的错误！","#导 入 须 知");
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string newFile = openFileDialog1.FileName;
                string[] array = newFile.Split('\\');

                if (System.Windows.Forms.MessageBox.Show("已选择：" + newFile, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    File.Copy(newFile, Path.Combine(System.IO.Directory.GetCurrentDirectory(), "题库", array[array.Length - 1]), true);
                    System.Windows.Forms.MessageBox.Show("导入成功！");
                    getFile();
                }
            }
        }
        private void chioseFile_HelpRequest(object sender, EventArgs e)
        {

        }
        private void worke_3()//题库管理
        {
            click_mybut1();
            if (Bt[0].Text != "查看进度")
            {
                mybutton9.Visible = false;
                po.Visible = false;
                Bt[0].Text = "查看进度";
            }
            getFile();
            groupBox1.Visible = true;
            //System.Windows.Forms.MessageBox.Show("功能暂未推出！");

        }
        private void getFile()//获取题库名称的集合
        {
            
            listBox1.Items.Clear();
            
            var files = Directory.GetFiles(@"题库", "*.xls");

            string[] fileName = new string[files.Length];
            int i = 0;
            foreach (var item in files)
            {
                fileName[i] = item.ToString();
                fileName[i] = fileName[i].Substring(3, fileName[i].Length - 3);
                i++;
            }
            listBox1.Items.AddRange(fileName);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex>=0)
            {
                textBox2.Text = listBox1.SelectedItem.ToString();
                FileInfo fi = new FileInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "题库", listBox1.SelectedItem.ToString()));
                textBox3.Text = fi.FullName;
                textBox4.Text = fi.Length + "字节（约"+(Convert.ToDouble(1.0*fi.Length/(1024*1024))).ToString("f2")+"MB)";
            }
            else{
                textBox2.Text = "空";
                textBox3.Text = "空";
                textBox4.Text = "空";
            }
        }

        private void mybutton3_Click(object sender, EventArgs e)
        {
            
        }

        private void mybutton2_Click(object sender, EventArgs e)
        {
            
        }
        private void AppInformation()
        {
            click_mybut1();

            roundButton3.Width = textBox1.Width;
            roundButton3.Top = textBox1.Bottom;
            roundButton3.Left = textBox1.Left;

            if (textBox1.Visible == false)
            {
                textBox1.Text = "\t应用信息\r\n(1)版本号：\r\n   2020.8.21.2.4（GK版）\r\n(2)题库来源：\r\n   江西省电子信息大赛\r\n(3)软件说明：\r\n   免费公开";
                textBox1.Visible = true;
                roundButton3.Visible = true;
            }
            else
            {

                textBox1.Visible = false;
                roundButton3.Visible = false;
            }
        }
        private void mybutton1_Click(object sender, EventArgs e)
        {
            click_mybut1();
        }

        private void click_mybut1()
        {
            textBox1.Visible = false;
            roundButton3.Visible = false;
            
            label1.Visible = false;
            groupBox1.Visible = false;
        }
        private void getMoreInformation()
        {
            click_mybut1();

            System.Windows.Forms.MessageBox.Show("功能暂未推出！");


        }
        private void Setting()
        {
            click_mybut1();

            System.Windows.Forms.MessageBox.Show("功能暂未推出！");

        }
        private void Help()
        {
            hideBut();

            click_mybut1();
            Keys = 6;
            Wait(0.00, 0.16, 14.00);
            //rightC.stop();   
        }
        public void Wait(double star,double step,double end)
        {
            foreach (System.Windows.Forms.Control item in this.Controls)
                item.Enabled = false;
            Wait w = new Wait();
            w.star = star;
            w.end = end;
            //w.Parent = this;
            //w.Location = new Point(this.Width/2,this.Height/2);
            w.moveStep = step ;
            this.Opacity = 0.8;
            w.Show();
        }
        private void Bt_Click(object sender, EventArgs e)
        {
            switch (((mybutton)sender).Text.Trim())
            {
                case "查看进度":
                case "关闭进度":
                    { findProcess((mybutton)sender); break; }
                case "选择题库":
                    { work_1(); break; }
                case "导入题库":
                    { worke_2(); break; }
                case "题库管理":
                    { worke_3(); break; }
                case "版本信息":
                    { AppInformation(); break; }
                case "获取跟多":
                    { getMoreInformation(); break; }
                case "设置":
                    { Setting(); break; }
                case "帮助":
                    { Help(); break; }
            }
        }

        private void createmyBt(mybutton Bt, System.Windows.Forms.Control con, System.Drawing.Size s, System.Drawing.Point p, Color[] c, string str)
        {
            Bt.Parent = con;
            Bt.Size = s;
            Bt.Location = p;
            Bt.EnterForeColor = c[0];
            Bt.LeftForeColor = c[1];
            Bt.NormalColor = c[3];
            Bt.HoverColor = c[2];
            Bt.Text = str;
            Bt.ForeColor = Color.White;
            Bt.Visible = true;
            //Bt.Click += Bt_Click;
        }
        private void Bt_MouseMove(object sender, MouseEventArgs e)
        {
            ((System.Windows.Forms.Button)sender).ForeColor = Color.White;
            foreach (System.Windows.Forms.Control bt in this.Controls)
            {
                if (bt is System.Windows.Forms.Button)
                {
                    if (bt != ((System.Windows.Forms.Control)sender))
                        bt.BackgroundImage = null;
                }
            }
            click_col = e.Location;

            System.Drawing.Graphics p = ((System.Windows.Forms.Control)sender).CreateGraphics();
            //Brush bu = new SolidBrush(Color.Red);
            //p.FillEllipse(bu, e.X - 5, e.Y - 5, 10, 10);

            col = (System.Windows.Forms.Control)sender;

            b = new SolidBrush(Color.FromArgb(118, 238, 198));//155, 205, 155
            timer1.Start();
        }

        public static Type type = Type.GetTypeFromProgID("SAPI.SpVoice");
        public dynamic sp = Activator.CreateInstance(type);
        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        public void doSome(int key)
        {
            foreach (System.Windows.Forms.Control item in this.Controls)
                item.Enabled = true;
            this.Opacity = 1;
            switch (key)
            {
                case 0:
                    readProLine();
                    AnsProblem mypro = new AnsProblem();
                    mypro.proNums = this.proNum;
                    mypro.proOver = this.proOver;
                    //mypro.WindowState = FormWindowState.Minimized;
                    mypro.Opacity = 0;
                    mypro.Show();
                    //mypro.WindowState = FormWindowState.Maximized;
                    this.Hide();
                    while (true)//渐变窗体，逐渐出现
                    {
                        if(mypro.Opacity==1)
                        {
                            break;
                        }
                        else
                        {
                            mypro.Opacity += 0.01;
                            System.Threading.Thread.Sleep(10);
                        }
                    }
                    break;
                case 1:
                    button2.Enabled = false;
                    findPro fP = new findPro();
                    fP.Opacity = 0;
                    f1.Hide();
                    fP.Show();
                    while(true)
                    {
                        if (fP.Opacity==1)
                        { break; 
                        }
                        else
                        {
                            fP.Opacity += 0.02;
                            System.Threading.Thread.Sleep(10);
                        }
                    }
                    break;
                case 2:
                    button3.Enabled = false; button4.Enabled = false;
                    favorites fav = new favorites();
                    fav.name = "收藏夹";
                    fav.path = @"收藏夹.xls";
                    fav.label1.Text = "个人收藏夹";
                    fav.label9.Text = "<Tip>我收藏了：";
                    fav.label12.Text = "这是我收藏的第：";
                    f1.Hide();
                    fav.Show();
                    break;
                case 3:
                    button4.Enabled = false; button3.Enabled = false;
                    favorites fav1 = new favorites();
                    fav1.name = "错题本";
                    fav1.path = @"错题本.xls";
                    fav1.label1.Text = "我的错题本";
                    fav1.label9.Text = "<Tip>我的错过：";
                    fav1.label12.Text = "错题之第：";
                    f1.Hide();
                    fav1.Show();
                    break;
                case 4:
                    Process.Start(@"exam.exe");
                    break;
                case 5:
                    if (File.Exists(@"考试记录.txt"))
                    {
                        allTest at = new allTest();
                        at.Show();
                        f1.Hide();
                    }
                    else
                        System.Windows.Forms.MessageBox.Show("暂时没有考试记录，无法查看！");
                    break;
                case 6:
                    if (System.Windows.Forms.MessageBox.Show("即将跳转到网页，确定？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        System.Diagnostics.Process.Start(@"帮助.html"); 
                    ; break;
            }
        }
        public int Keys=0;
        //private void show()
        private void button1_Click(object sender, EventArgs e)//进入练题模式
        {
            hideBut();
            Keys = 0;
            Wait(0.00,0.12,12.00);
            //Wait w = new Wait();
            
        }

        private void button2_Click(object sender, EventArgs e)//进入查体小助手
        {
            hideBut();
            Keys = 1;
            Wait(0.00, 0.12, 10.00);

            
        }

        private void button3_Click(object sender, EventArgs e)//进入我的收藏夹
        {
            hideBut();

            Wait(0.00, 0.12, 10.00);

            Keys = 2;
        }

        private void button4_Click(object sender, EventArgs e)//查看错题本
        {
            hideBut();
            Keys = 3;
            Wait(0.00, 0.12, 12.00);

        }

        private void button5_Click(object sender, EventArgs e)//开始我的模拟考试
        {
            hideBut();
            Keys = 4;
            Wait(0.00, 0.12, 12.00);
        }

        private void button6_Click(object sender, EventArgs e)//分析并了解了解我的成绩
        {
            hideBut();
            Keys = 5;
            Wait(0.00, 0.1, 10.00);
            //System.Windows.Forms.MessageBox.Show("功能暂未推出，敬请期待！");
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Maximum = proNum;
            progressBar1.Value = proStep;
        }

        System.Drawing.Point p;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new System.Drawing.Point(e.Location.X, e.Location.Y);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
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

        int r = 0;
        Graphics p1;
        Pen pen1;
        Brush b;
        //Brush b2;
        System.Windows.Forms.Control col;
        System.Drawing.Image ig;
        System.Drawing.Point click_col;
        private void timer1_Tick(object sender, EventArgs e)
        {
            bubble();
        }
        public void get_max(ref int max)
        {
            int d1 = ((click_col.X) * (click_col.X)) + ((click_col.Y) * (click_col.Y));
            int d2 = ((ig.Width - click_col.X) * (ig.Width - click_col.X)) + ((click_col.Y) * (click_col.Y));
            if (d1 < d2)
                max = d2;
            else
                max = d1;
        }
        public void bubble()
        {
            ig = new Bitmap(col.Width, col.Height);
            p1 = Graphics.FromImage(ig);
            r += col.Width / 10;
            p1.FillEllipse(b, click_col.X - r / 2, click_col.Y - r / 2, r, r);
            col.BackgroundImage = ig;
            p1.Dispose();
            int max = 0;
            get_max(ref max);
            if ((r / 2) * (r / 2) >= max)
            {
                r = 0;
                p1 = Graphics.FromImage(ig);
                p1.FillRectangle(b,new Rectangle(new Point(0,0),new System.Drawing.Size(col.Width,col.Height)));
                col.BackgroundImage = ig;
                //p1.Clear(this.BackColor);
                p1.Dispose();
                //col.BackColor = Color.FromArgb(118, 238, 198);
                timer1.Stop();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            //progressBar1.Value = proOver;
        }

        int stepp = 50;//50
        bool ret = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (po.Value > proNum - 80)
            {
                ret = true;
                //if (proNum > proStep)
                    stepp = -80;//-80
                //else
                //    { stepp = 0; po.Value = proStep; }//-80

            }
            else if ((po.Value == proStep && ret == true))
            {
                po.Value -= 50;//50
                ret = false;
                stepp = 50;//50

                timer2.Interval = 1;
                timer2.Stop();
            }
            else
            {
                
                if (ret == false && stepp > 1 && po.Value % 20 == 0)
                    stepp -= 1;
                else if (ret == true && stepp < -1 && po.Value % 20 == 0 && po.Value > proStep)
                {
                    stepp += 1;
                }
                else if (ret == true && po.Value < proStep)
                {
                    stepp = proStep - po.Value;
                }
            }
            po.Value += stepp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            po.ValueWidth = (int)numericUpDown1.Value;
            //findProcess(Bt[0]);
            po.Value = proStep;
            Bt[0].Text = "关闭进度";
            po.Visible = true;
            timer2.Start();
        }
        private void mybutton4_Click(object sender, EventArgs e)
        {

        }

        private void mybutton8_Click(object sender, EventArgs e)
        {
           
        }

        private void mybutton5_Click(object sender, EventArgs e)
        {
        }

        private void mybutton6_Click(object sender, EventArgs e)
        {
           
        }

        private void mybutton7_Click(object sender, EventArgs e)
        {
          
        }
        private void roundButton3_Click(object sender, EventArgs e)
        {

            textBox1.Visible = false;
            roundButton3.Visible = false;
        }

        private void mybutton9_Click(object sender, EventArgs e)
        {
            string[] tf = { "F", "T" };
            int numtemp = 0;
            getnum(Form2.f2.proPath, ref numtemp, 9, proNum, tf);
            po.Value = numtemp;
            proStep = numtemp;
            po.Visible = true;
            if (timer2.Enabled == false)
            {
                po.Value = 0;
                timer2.Start();
            }
            else
                timer2.Stop();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void roundButton1_Click(object sender, EventArgs e)//删除题库
        {
            if (listBox1.SelectedIndex < 0)
            {
                if (System.Windows.Forms.MessageBox.Show("是否删除此题库?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    File.Delete(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "题库", listBox1.SelectedItem.ToString()));
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("请先选择题库！");
            }
        }


        ////新进度条???????????????????????????????????????????????????????????????????????????????????????????????????????

        public partial class myProgressBar : System.Windows.Forms.UserControl
        {
            int valu = 0;
            int maxnum = 100;
            int minnum = 0;
            Color valueColor = Color.Blue;//进度条值区域颜色
            Color nullColor = Color.White;//进度条空值区域颜色
            int valueWidth = 10;//进度条宽度
            public int ValueWidth
            {
                get { return valueWidth; }
                set
                {
                    if (value > this.Width || value <= 0)
                        this.valueWidth = 10;
                    else
                        this.valueWidth = value;
                }
            }
            public Color NullColor
            {
                get { return nullColor; }
                set
                {
                    nullColor = value;
                }
            }
            public Color ValueColor
            {
                get { return valueColor; }
                set
                {
                    valueColor = value;
                }
            }

            [DllImport("user32")]
            private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
            private const int WM_SETREDRAW = 0xB;
            public int Value
            {
                get { return valu; }
                set
                {

                    this.valu = value;
                    mypro();
                }
            }
            public void mypro()
            {

                this.CreateGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                this.CreateGraphics().CompositingQuality = CompositingQuality.HighQuality;
                this.CreateGraphics().InterpolationMode = InterpolationMode.HighQualityBilinear;
                this.CreateGraphics().TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                float num = (float)this.valu / (float)this.Maxnum * 100.0000f;
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                Brush myProbush = new SolidBrush(this.valueColor);
                if (num <= 100.00f && num > 80.00f)
                    myProbush = new SolidBrush(Color.FromArgb(0, 206, 209));
                else if (num <= 80.00f && num > 60.00f)
                    myProbush = new SolidBrush(Color.FromArgb(0, 255, 127));
                else if (num <= 60.00f && num > 40.00f)
                    myProbush = new SolidBrush(Color.FromArgb(238, 154, 73));
                else if (num <= 40.00f && num > 20.00f)
                    myProbush = new SolidBrush(Color.FromArgb(255, 69, 0));
                else
                    myProbush = new SolidBrush(Color.Red);

                //System.Windows.Forms.MessageBox.Show(this.valu.ToString());
                //填充有效区域
                var path = GetRoundedRectPath1(rect, 90, ((float)valu / (float)Maxnum * 360.00f));
                this.CreateGraphics().FillPath(myProbush, path);


                //填充无效区域
                myProbush = new SolidBrush(this.NullColor);
                path = GetRoundedRectPath1(rect, 90.00f + ((float)valu / (float)Maxnum * 360.00f), 360.00f - ((float)Value / (float)Maxnum * 360.00f));
                this.CreateGraphics().FillPath(myProbush, path);

                //底部添加百分百数值
                this.Text = (num).ToString("f2") + "%";

                using (SolidBrush b = new SolidBrush(Color.White))
                {
                    System.Drawing.Font fo = new System.Drawing.Font("楷体", 10.5F);
                    Brush brush = new SolidBrush(this.ForeColor);
                    StringFormat gs = new StringFormat();
                    gs.Alignment = StringAlignment.Center; //居中
                    gs.LineAlignment = StringAlignment.Center;//垂直居中
                    rect = new Rectangle(0, this.Height - ValueWidth, this.Width, ValueWidth);
                    this.CreateGraphics().DrawString(this.Text, fo, brush, rect, gs);
                }

            }
            public int Maxnum
            {
                get { return maxnum; }
                set
                {
                    this.maxnum = value;
                }
            }
            public int Minnum
            {
                get { return minnum; }
                set
                {
                    this.minnum = value;
                }
            }
            public myProgressBar()
            {
                //SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                this.SetStyle(

                 ControlStyles.UserPaint |  //控件自行绘制，而不使用操作系统的绘制
                 ControlStyles.AllPaintingInWmPaint | //忽略擦出的消息，减少闪烁。
                 ControlStyles.OptimizedDoubleBuffer |//在缓冲区上绘制，不直接绘制到屏幕上，减少闪烁。
                 ControlStyles.ResizeRedraw | //控件大小发生变化时，重绘。                  
                 ControlStyles.SupportsTransparentBackColor, true);//支持透明背景颜色
                mypro();


            }

            public ControlState ControlState { get; set; }
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

            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                base.OnPaint(e);
                base.OnPaintBackground(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;



                Rectangle rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
                var path = GetRoundedRectPath(rect, this.Width);
                rect = new Rectangle(1+this.valueWidth, 1+this.valueWidth, this.Width - 32, this.Height - 32);
                this.Region = new Region(path);

                Brush myProbush = new SolidBrush(Color.White);
                e.Graphics.FillPath(myProbush, path);


            }
            private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
            {
                int diameter = radius;

                Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(diameter, diameter));
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(arcRect);
                //path.AddPie(rect, 0, Value / Maxnum * 360);
                Rectangle rect1 = new Rectangle(ValueWidth, ValueWidth, this.Width - ValueWidth * 2, this.Height - ValueWidth * 2);
                path.AddEllipse(rect1);
                //Pen pp = new Pen(Color.Black ,10);
                //path.Widen(pp);

                path.CloseFigure();
                return path;
            }
            private GraphicsPath GetRoundedRectPath1(Rectangle rect, float Starangle, float Sweepangle)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddPie(rect, Starangle, Sweepangle);
                //path.CloseFigure();
                return path;
            }
        }

        ////???????????????????????????????????????????????????????????????????????????????????????????????????????

        public class buttonclass : RoundButton
        {
            //public enum ControlState { Hover, Normal, Pressed }
            private Color enterForeColor = Color.White;
            private Color leftForeColor = Color.Black;

            public Color EnterForeColor
            {
                get { return enterForeColor; }
                set
                {
                    this.enterForeColor = value;
                    this.ForeColor = value;
                }
            }
            public Color LeftForeColor
            {
                get { return leftForeColor; }
                set
                {
                    this.leftForeColor = value;
                    this.ForeColor = value;
                }
            }
            [DefaultValue(typeof(Color), "51, 161, 224")]
            //  [DefaultValue(typeof(Color), "220, 80, 80")]


            //  [DefaultValue(typeof(Color), "251, 161, 0")]
            protected override void OnMouseEnter(EventArgs e)//鼠标进入时
            {
                base.OnMouseEnter(e);
                ControlState = 快眼刷题.ControlState.Hover;//正常
                this.ForeColor = this.EnterForeColor;

                this.Left -= this.Width / 20; this.Width += this.Width / 10;
            }
            protected override void OnMouseLeave(EventArgs e)//鼠标离开
            {
                base.OnMouseLeave(e);
                ControlState = 快眼刷题.ControlState.Normal;//正常
                this.ForeColor = this.LeftForeColor;
                this.Width -= this.Width / 11;
                this.Left += this.Width / 20;
            }


            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                base.OnPaint(e);
                base.OnPaintBackground(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                var path = GetRoundedRectPath(rect, this.Radius);
                this.Region = new Region(path);

                Color baseColor = this.NormalColor;
                switch (ControlState)
                {
                    case 快眼刷题.ControlState.Hover:
                        baseColor = this.HoverColor;
                        break;
                    case 快眼刷题.ControlState.Pressed:
                        baseColor = this.PressedColor;
                        break;
                    case 快眼刷题.ControlState.Normal:
                        baseColor = this.NormalColor;
                        break;
                    default:
                        baseColor = this.NormalColor;
                        break;
                }

                using (SolidBrush b = new SolidBrush(baseColor))
                {
                    e.Graphics.FillPath(b, path);
                    System.Drawing.Font fo = new System.Drawing.Font(this.Font.Name, this.Font.Size);
                    Brush brush = new SolidBrush(this.ForeColor);
                    Pen penn = new Pen(brush, 3);
                    StringFormat gs = new StringFormat();
                    gs.Alignment = StringAlignment.Center; //居中
                    gs.LineAlignment = StringAlignment.Center;//垂直居中
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    e.Graphics.DrawString(this.Text, fo, brush, rect, gs);

                    //e.Graphics.DrawPath(p, path);
                }

            }

            private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
            {
                //int diameter = radius;
                //Point lo = new Point(rect.Location.X + 10, rect.Location.Y + 10);
                Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(this.Height, this.Height));
                GraphicsPath path = new GraphicsPath();
                //Pen pp = new Pen(Color.White, 1);
                Point[] p = new Point[5];
                p[0] = rect.Location;
                p[1] = new Point(0, this.Height);
                p[2] = new Point(3 * this.Width / 4, this.Height);
                p[3] = new Point(this.Width, this.Height / 2);
                p[4] = new Point(3 * this.Width / 4, 0);
                path.AddLines(p);
                //path.AddLine (p1,p2);
                //path.AddLine(p2,p3);
                //path.AddLine(p3,p4);
                //path.AddLine(p4,p5);
                //path.AddLine(p5,p1);
                //
                //path.Widen(pp);
                path.CloseFigure();
                return path;
            }
        }


        public class drawcir
        {
            private Color colorR = Color.Blue;
            private Color colorL = Color.Red ;
            private System.Drawing.Size sl = new System.Drawing.Size(10,10);
            private System.Drawing.Size sr = new System.Drawing.Size(10, 10);
            private int r = 10;
            private Point p = new Point(0, 0);
            private Point pR = new Point(50, 0);
            private int d = 40;
            private int moveStep = 1;
            private int time = 10;


            public int Time
            {
                set { this.time = value; }
                get { return this.time; }
            }
            public int MoveStep
            {
                set
                {

                        this.moveStep = value;
                }
                get { return this.moveStep; }
            }
            public int D
            {
                set{
                    if (value > 0)
                        this.d = value;
                }
                get { return this.d; }
            }
            public Color ColorR
            {
                set
                {

                    this.colorR = value;
                }
                get { return colorR; }
            }
            public Color ColorL
            {
                set
                {

                    this.colorL = value;
                }
                get { return colorL; }
            }
            public int R
            {
                set
                {
                    if (value > 0)
                        this.r = value;
                }
                get { return r; }
            }
            public Point P
            {
                set { this.p = value; }
                get { return p; }
            }
            public Point PR
            {
                set { this.pR = value; }
                get { return pR; }
            }
            public System.Drawing.Size Sl
            {
                set { sl = value; }
                get { return sl; }
            }
            public System.Drawing.Size Sr
            {
                set { sr = value; }
                get { return sr; }
            }
            public drawcir()
            {
                draw();
            }

          
            private void draw()
            {
                Graphics g =f1.CreateGraphics();
                g.Clear(f1.BackColor);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                //g.FillRectangle(new SolidBrush(f1.BackColor),new Rectangle(new Point(this.p.X-this.r,this.p.Y-this.r), new System.Drawing.Size(this.r*2, this.r*2)));
                //左边小球
                Brush b = new SolidBrush(this.colorL);
                g.FillEllipse(b, new Rectangle(this.p,new System.Drawing.Size(this.r,this.r)));//

                //右边小球
                b = new SolidBrush(this.colorR);
                g.FillEllipse(b, new Rectangle(this.pR, new System.Drawing.Size(this.r, this.r)));//
                g.Dispose();
                System.Threading.Thread.Sleep(this.time / 2);
            }
            private void clear()
            {

                Graphics g = f1.CreateGraphics();
                //g.SmoothingMode = SmoothingMode.HighSpeed ;
                //g.InterpolationMode = InterpolationMode.Low ;
                //g.PixelOffsetMode = PixelOffsetMode.None  ;
                g.Clear(f1.BackColor);
                //Brush b = new SolidBrush(f1.BackColor);
                ////g.FillRectangle(b, new Rectangle(new Point(0, 0), f1.Size));
                //g.FillEllipse(b, new Rectangle(new Point(this.p.X - 1, this.p.Y - 1), new System.Drawing.Size(this.r + 2, this.r + 2)));
                g.Dispose();
                //g.FillEllipse(b, new Rectangle(new Point(this.pR.X - 1, this.pR.Y - 1), new System.Drawing.Size(this.r + 2, this.r + 2)));

            }
            public void move(int step)
            {
                System.Threading.Thread.Sleep(this.time / 2);
                //clear();

                this.d = step;
                this.p.X += this.moveStep ;
                this.pR.X -= this.moveStep;
                draw();
                
                //System.Threading.Thread.Sleep(this.time/2);

            }

            public void stop()
            { System.Threading.Thread.Sleep(20);clear(); }
        }
        public enum ControlState { Hover, Normal, Pressed }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        //  [DefaultValue(typeof(Color), "220, 80, 80")]
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

        //  [DefaultValue(typeof(Color), "251, 161, 0")]
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
            get;
            set;
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
            {
                ControlState = ControlState.Pressed;//按下的状态
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)//鼠标弹起
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (ClientRectangle.Contains(e.Location))//控件区域包含鼠标的位置
                {
                    ControlState = ControlState.Hover;
                }
                else
                {
                    ControlState = ControlState.Normal;
                }
            }
        }
        public RoundButton()
        {
            Radius = 15;
            this.ForeColor = Color.White;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            //this.ControlState = ControlState.Normal;
            this.SetStyle(
             ControlStyles.UserPaint |  //控件自行绘制，而不使用操作系统的绘制
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

        //重写OnPaint
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
                //  e.Graphics.DrawPath(p, path);
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
            //Pen pp = new Pen(Color.White, 10);
            //path.Widen(pp);
            path.CloseFigure();
            return path;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
    public class showButton : System.Windows.Forms.Button
    {
        private Color enterForeColor = Color.White;
        private Color leftForeColor = Color.Black;
        private bool Isleft = true;

        public bool IsLEFT
        {
            get { return Isleft; }
            set
            {
                this.Isleft = value;
            }
        }

        public Color EnterForeColor
        {
            get { return enterForeColor; }
            set
            {
                this.enterForeColor = value;
                this.ForeColor = value;
            }
        }
        public Color LeftForeColor
        {
            get { return leftForeColor; }
            set
            {
                this.leftForeColor = value;
                this.ForeColor = value;
            }
        }
        [DefaultValue(typeof(Color), "51, 161, 224")]
        //  [DefaultValue(typeof(Color), "220, 80, 80")]


        //  [DefaultValue(typeof(Color), "251, 161, 0")]
        protected override void OnMouseEnter(EventArgs e)//鼠标进入时
        {
            base.OnMouseEnter(e);
            this.ForeColor = this.EnterForeColor;
        }
        protected override void OnMouseLeave(EventArgs e)//鼠标离开
        {
            base.OnMouseLeave(e);
            this.ForeColor = this.LeftForeColor;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            var path = GetRoundedRectPath(rect);
            this.Region = new Region(path);

            //var pa = RectPath(rect);
            //this.Region = new Region(pa);
            Color baseColor = this.BackColor;

            using (SolidBrush b = new SolidBrush(baseColor))
            {
                e.Graphics.FillPath(b, path);
                //e.Graphics.FillPath(b, pa);
                System.Drawing.Font fo = new System.Drawing.Font(this.Font.Name, this.Font.Size);
                Brush brush = new SolidBrush(this.ForeColor);
                Pen penn = new Pen(brush, 3);
                StringFormat gs = new StringFormat();
                gs.Alignment = StringAlignment.Center; //居中
                gs.LineAlignment = StringAlignment.Center;//垂直居中
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(this.Text, fo, brush, rect, gs);
            }

        }
        private GraphicsPath RectPath(Rectangle re)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] ps = new Point[4];
            ps[0] = new Point(this.Width / 5, this.Height / 5);
            ps[1] = new Point(4 * this.Width / 5, this.Height / 5);
            ps[2] = new Point(this.Width / 5, 4 * this.Height / 5);
            ps[3] = new Point(4 * this.Width / 5, 4 * this.Height / 5);
            path.AddLines(ps);
            path.CloseFigure();

            return path;
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect)
        {
            Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(this.Height, this.Height));
            GraphicsPath path = new GraphicsPath();
            Point[] p = new Point[12];
            if (Isleft == true)
            {
                p[0] = new Point(2 * this.Width / 5, 0);
                p[1] = new Point(0, this.Height / 2);
                p[2] = new Point(2 * this.Width / 5, this.Height);

                p[3] = new Point(this.Width, 0);
                p[4] = new Point(4 * this.Width / 5, this.Height / 4);
                p[5] = new Point(4 * this.Width / 5, 3 * this.Height / 4);
                p[6] = new Point(this.Width, this.Height);
            }
            else
            {
                p[0] = new Point(3 * this.Width / 5, 0);
                p[1] = new Point(this.Width, this.Height / 2);
                p[2] = new Point(3 * this.Width / 5, this.Height);

                p[3] = new Point(0, 0);
                p[4] = new Point(1 * this.Width / 5, this.Height / 4);
                p[5] = new Point(1 * this.Width / 5, 3 * this.Height / 4);
                p[6] = new Point(0, this.Height);
            }
            path.AddLine(p[0], p[1]);
            path.AddLine(p[1], p[2]);
            path.AddBezier(p[6], p[5], p[4], p[3]);
            path.CloseFigure();
            return path;
        }
    }

}

   