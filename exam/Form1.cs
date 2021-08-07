using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MSWord = NPOI.XSSF.UserModel;
using myword = NPOI.HSSF.UserModel;
using Point = System.Drawing.Point;

namespace exam
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = @"我的题库.xls";
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
            { number = -1; }
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

        string[] pro = new string[10];
        public void read(int row)
        {
            if (myans[thisPro - 1] == "")
            {
                foreach (System.Windows.Forms.RadioButton item in panel3.Controls)
                    item.BackColor = Color.White;
            }
            else
            {
                foreach (System.Windows.Forms.RadioButton item in panel3.Controls)
                {
                    if (item.Text.Substring(0, 1) == myans[thisPro - 1])
                    {
                        item.Checked = true;
                        item.BackColor = Color.FromArgb(135, 206, 250);
                    }
                    else
                    {
                        item.Checked = false;
                        item.BackColor = Color.White;
                    }
                }
            }
            readAPro(row, path, ref pro);
            pro[2] = thisPro.ToString() + "、" + pro[2];
            showTxtBox(textBox2, ref pro[2], 11);//13
            textBox2.Text = pro[2];
            chice[0] = pro[3];
            chice[1] = pro[4];
            chice[2] = pro[5];
            chice[3] = pro[6];
            for (int i = 0; i < 4; i++)
                rBt[i].Text = ab[i] + "、" + chice[i];
            trueans[thisPro - 1] = pro[7];

            if (Examover == true)
            {
                foreach (System.Windows.Forms.RadioButton item in panel3.Controls)
                {
                    if (item.Text.Trim().Substring(0, 1) == myans[thisPro - 1])
                    {
                        item.BackColor = Color.FromArgb(255, 69, 0);
                    }
                    if (item.Text.Trim().Substring(0, 1) == trueans[thisPro - 1].Trim())
                    {
                        item.BackColor = Color.FromArgb(0, 255, 127);
                    }
                }

                if (myans[thisPro - 1] == null)
                {
                    label9.Text = "-未选择-";
                    label9.BackColor = Color.FromArgb(64, 224, 208);
                }
                else if (myans[thisPro - 1] != null && myans[thisPro - 1] == trueans[thisPro - 1])
                {
                    label9.Text = "-正  确-";
                    label9.BackColor = Color.FromArgb(0, 255, 127);
                }
                else
                {
                    label9.Text = "-错  误-";
                    label9.BackColor = Color.FromArgb(255, 69, 0);
                }
            }

            label10.Text = "-" + thisPro + "-";
            label10.BackColor = Color.FromArgb(0, 250, 154);
        }

        string examName;//考试试题卷名称
        int examTime =1200;//2700
        string[] chice = new string[4];
        string[] ab = { "A","B","C","D"};
        int[] proNumber = new int[51];
        string[] trueans = new string[50];
        string[] myans = new string[50];
        int thisPro = 1;//定位到当前题目序号
        public void changeContrals()
        {
            checkBox1.Top = textBox1.Bottom;
            label6.Top = this.Height - label6.Height;
            label6.Left = this.Width / 2 - label6.Width / 2;

            label5.Top = label1.Bottom;
            label5.Left = this.Width - label5.Width;
            
            panel1.Top = (label6.Top - label5.Bottom) / 2 - panel1.Height / 2 + label5.Bottom;
            panel1.Left = ((label5.Left - label2.Right) / 2 - panel1.Width / 2) + label2.Right;
            


            label9.Top = panel2.Height-label9.Height;
            label9.Left = (roundButton4.Left+roundButton3.Right-label9.Width)/2;

            
            set_newbutton();
            set_newRiobutton(chice, ab);

            toolTip1.SetToolTip(button3, "单击隐藏题目列表");

            panel2.Left =((label5.Left-label2.Right )/2-(panel2.Width-flowLayoutPanel1.Width)/2)+label2.Right ;
            panel2.Top =(label6.Top+label5.Bottom-panel2.Height)/2;
            
            read(proNumber[0]);

            pictureBox1.Top = label2.Bottom+10;
            pictureBox1.Left = (panel2.Left - pictureBox1.Width) / 2 - 10;
            pictureBox2.Location = pictureBox1.Location;

            label1.Visible = true;
            label2.Visible = true;
            label6.Visible = true;
            //mybutton2.Width = Convert.ToInt32((this.Width-panel2.Right)* 0.8);
            //mybutton1.Width = mybutton2.Width;
            //mybutton2.Left = this.Width-mybutton2.Width;
            //mybutton2.Top = this.Height-mybutton2.Height-20-mybutton1.Height;
            //mybutton1.Top = mybutton2.Bottom+10;
            //mybutton1.Left = mybutton2.Left;

            roundButton5.Top = pictureBox1.Bottom;
            roundButton5.Left = pictureBox1.Left;

            mybutton2.Width = pictureBox1.Width/2;
            mybutton1.Width = mybutton2.Width;
            mybutton2.Left = pictureBox1.Width/4+pictureBox1.Left;
            mybutton2.Top = roundButton5.Bottom+10;
            mybutton1.Top = mybutton2.Bottom + 10;
            mybutton1.Left = mybutton2.Left;

            roundButton6.Top = mybutton1.Bottom + 10;
            roundButton6.Left = mybutton1.Left;
            roundButton6.Width = mybutton1.Width;
            
        }
        mybutton[] bt = new mybutton[50];
        public void set_newbutton()
        {
            for (int i = 0; i < 50; i++)
            {
                bt[i] = new mybutton();
                bt[i].Name = "my_bt" + i.ToString();
                bt[i].Text = "第" + (i + 1).ToString() + "题";
                bt[i].ForeSize = 10;
                bt[i].Parent = flowLayoutPanel1;
                bt[i].Size = new Size(50,50);
                bt[i].EnterForeColor = Color.Black;
                bt[i].LeftForeColor = Color.Black;
                bt[i].ControlState = ControlState.Normal;
                bt[i].NormalColor = Color.FromArgb(135, 206, 235);
                bt[i].HoverColor = Color.FromArgb(100, 149, 237);
                bt[i].Cursor = Cursors.Hand;
               // bt[i].BackColor = Color.White;
                bt[i].Click += new System.EventHandler(this.bt_Click);
                //bt[i].MouseEnter += new EventHandler(this.bt_mouseEnter);
                //bt[i].MouseLeave  += new EventHandler(this.bt_mouseLeave);
            }
        }
        private void bt_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(((System.Windows.Forms.Button)sender).Text.Trim().Substring(1, ((System.Windows.Forms.Button)sender).Text.Trim().Length - 2));
            thisPro = i;
            read(proNumber[thisPro - 1]);
            if (Examover == true )
            {
                foreach (System.Windows.Forms.RadioButton item in panel3.Controls)
                {
                    if (item .Text.Trim().Substring(0,1)==myans[thisPro-1])
                    {
                        item.BackColor = Color.FromArgb(255, 69, 0);
                    }
                    if(item.Text.Trim().Substring(0, 1) == trueans [thisPro - 1])
                    {
                        item.BackColor = Color.FromArgb(0, 255, 127);
                        
                    }
                }
            }
        }
        //private void bt_mouseEnter(object sender, EventArgs e)
        //{
        //    if(Examover==false) 
        //    { 
        //        if (((System.Windows.Forms.Button)sender).BackColor != Color.FromArgb(135, 206, 250))
        //            ((System.Windows.Forms.Button)sender).BackColor = Color.FromArgb(175, 238, 238);
        //    }
        //}
        //private void bt_mouseLeave(object sender, EventArgs e)
        //{
        //    if (Examover == false)
        //    {
        //        if (((System.Windows.Forms.Button)sender).BackColor != Color.FromArgb(135, 206, 250))
        //            ((System.Windows.Forms.Button)sender).BackColor = Color.White;
        //    }
        //}

        System.Windows.Forms.RadioButton[] rBt = new System.Windows.Forms.RadioButton[4];
        public void set_newRiobutton(string []select,string []abc)
        {
            for (int i = 0; i < 4; i++)
            {
                rBt[i] = new System.Windows.Forms.RadioButton();
                rBt[i].Checked = false;
                rBt[i].Name = "rbt" + (i).ToString();
                rBt[i].Text =abc[i]+"、"+ select[i];
                rBt[i].Font = textBox2.Font;
                rBt[i].Parent = panel3;
                rBt[i].BackColor = Color.White;
                rBt[i].Appearance = Appearance.Button;
                rBt[i].Location = new Point(0,i* panel3.Height / rBt.Length);
                rBt[i].Size = new Size(panel3.Width ,panel3.Height/rBt.Length );
                rBt[i].Cursor =Cursors.Hand;
                rBt[i].Click+= new System.EventHandler(this.rbt_Click);
                rBt[i].MouseEnter += new EventHandler(this.rbt_mouseEnter);
                rBt[i].MouseLeave += new EventHandler(this.rbt_mouseLeave);
            }
        }
        private void rbt_Click(object sender, EventArgs e)
        {
            if (Examover == false)
            {
                foreach (System.Windows.Forms.RadioButton item in panel3.Controls)
                {
                    if (item == (System.Windows.Forms.RadioButton)sender)
                    {
                        item.Checked = true;
                        item.BackColor = Color.FromArgb(135, 206, 250);
                        bt[thisPro - 1].BackColor = Color.FromArgb(135, 206, 250);
                    }
                    else
                    {
                        item.Checked = false;
                        item.BackColor = Color.White;
                    }
                }
                myans[thisPro - 1] = ((System.Windows.Forms.RadioButton)sender).Text.Substring(0, 1);
            }
        }
        private void rbt_mouseEnter(object sender, EventArgs e)
        {
            if (Examover == false)
            {
                if (((System.Windows.Forms.RadioButton)sender).BackColor != Color.FromArgb(135, 206, 250))
                    ((System.Windows.Forms.RadioButton)sender).BackColor = Color.FromArgb(64, 224, 208);
            }
        }
        private void rbt_mouseLeave(object sender, EventArgs e)
        {
            if (Examover == false)
            {
                if (((System.Windows.Forms.RadioButton)sender).BackColor != Color.FromArgb(135, 206, 250))
                    ((System.Windows.Forms.RadioButton)sender).BackColor = Color.White;
            }
        }

        private void seachDifferent(ref int temp,int i,int max)
        {
            Random r = new Random();
            for (int j = 0; j < i; j++)
            {
                if (proNumber[i] == temp)
                {
                    temp = r.Next(1,max);
                    seachDifferent(ref temp,i,max );
                    break;
                }
            }
        }
        public void showTxtBox(TextBox tb, ref string strItem, int lineMax)
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
        public void lighting(Control con, Control backCon, Color co)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(con.Left - 20, con.Top - 20, con.Width + 40, con.Height + 40);


            PathGradientBrush pthGrBrush = new PathGradientBrush(path);


            pthGrBrush.CenterPoint = new PointF(con.Left + con.Width / 2, con.Top + (con.Height) / 2);


            pthGrBrush.CenterColor = co;


            Color[] colors = { Color.FromArgb(255, 255, 255, 255) };
            pthGrBrush.SurroundColors = colors;

            backCon.CreateGraphics().FillEllipse(pthGrBrush, con.Left - 20, con.Top - 20, con.Width + 40, con.Height + 40);
            //panel1.CreateGraphics().FillRectangle(pthGrBrush, button1.Left - 50, button1.Top - 50, button1.Width + 100, button1.Height + 100);

        }
        public void clearLighting(Control objectCon)
        {
            Graphics g = objectCon.CreateGraphics();
            Brush b = new SolidBrush(objectCon.BackColor);
            g.FillRectangle(b, new Rectangle(new Point(0, 0), objectCon.Size));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"考试记录.txt"))
                File.Create(@"考试记录.txt");
            
                if (!File.Exists(path))
                    path = @"题库\2020竞赛公开题库.xls";
           
            
            Random r = new Random();
            int numpro = 0;

            readProNum(path, ref numpro);
            if (numpro <= 0)
            {
                if (numpro < 0)
                    MessageBox.Show("文件" + path + "不存在");
                else
                    MessageBox.Show("文件" + path + "为空！");
                this.Close();
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    int temp = r.Next(1, numpro - 1);
                    for (int j = 0; j < i; j++)
                    {
                        seachDifferent(ref temp, i, numpro - 1);
                    }
                    proNumber[i] = temp;
                }


                System.DateTime ti = new DateTime();
                ti = DateTime.Now;
                this.Text = "第" + ti.Year.ToString() + ti.Month.ToString() + ti.Day.ToString() + ti.Hour.ToString() + ti.Minute.ToString() + ti.Second.ToString() + "号考试[模拟]";
                examName = this.Text;
                label1.Text = examName;
                label2.Text = "[考试须知：]\n    一、考试严格按照江西省教育考试院下发的考试具体要求。\n\n    二、考试期间不准离开应用或打开其他应用，否则视为舞弊，取消考试资格。\n\n    三、提交考卷后系统自动打分完成可正常离开考试。\n\n    四、本试题为一道主观题包含50小题，每题2分，总分100分，60分合格！\n\n    五、考试时间20分钟，考试开始5分钟后可提交试卷。";
                
                changeContrals();

                //button6.Visible = true;
                string str = "";
                if (File.Exists(@"考试要求.txt"))
                {
                    //File.OpenRead(@"考试要求.txt");
                    StreamReader sr = new StreamReader(@"考试要求.txt", Encoding.UTF8);
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        str += line.ToString() + "\r\n";
                    }
                    sr.Close();
                    sr.Dispose();
                }
                textBox1.Text = str;
                panel1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            examTime--;
            label5.Text = "[考试注意]考试剩余时间："+((examTime-examTime%60)/60).ToString()+"分钟"+(examTime%60).ToString()+"秒";
            if (examTime <= 0)
            {
                timer1.Stop();
                MessageBox.Show("考试结束","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Over();
               // button2.Enabled  = false;
                //button6.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (examTime < 2100)
            //{
               
            //}
            //else
            //{
            //    MessageBox.Show("考试开始未满10分钟，不允许交卷！");
            //}

            
        }
        bool Examover = false;
        public void Over()
        {
            Examover = true;
            flowLayoutPanel1.Visible = true;
            label9.Visible = true;
            pictureBox2.Visible = false ;
            pictureBox1.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            roundButton6.Visible = true;

            int sum = 0;
            for (int i = 0; i < 50; i++)
            {
                if (myans[i] != null && myans[i] == trueans[i])
                {
                    sum += 2;
                    bt[i].NormalColor = Color.FromArgb(60, 179, 113);
                }
                else
                {
                    //bt[i].BackColor = Color.Red;
                    bt[i].NormalColor = Color.FromArgb(250, 128, 114);//220,20,60
                    //bt[i].ForeColor = Color.White;
                }
            }
            string str = "合格";
            if (sum < 60)
                str = "不合格";

            read(proNumber[thisPro - 1]);//

            int examTimeNow = 1200 - examTime;
            MessageBox.Show("(1)得分:" + sum + "," + str+"\n(2)耗时："+examTimeNow+"秒!","考-试-结-果");

            drawSolution(sum.ToString(), str,"本次耗时："+ examTimeNow + "秒", pictureBox1, Color.Red, Color.Black, 100, 50,20);

            string line = label1.Text+"_"+sum.ToString()+"_"+str+"_"+path;
            if (write == false)
            { 
                writeSou(line); write = true;
                roundButton5.Visible = true;
            }

         }
        bool write = false;
        private void writeSou(string line)
        {
            FileStream f = new FileStream(@"考试记录.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(line);
            sw.Close();
            f.Close();
        }
        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }
        bool open = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (open==true  )
            {
                if (panel2.Width <= panel3.Width+flowLayoutPanel1.Width )
                {
                    if (panel2.Width <= panel3.Width + flowLayoutPanel1.Width+20)
                    {
                        panel2.Width += 5;
                        button3.Left += 5;
                    }
                    else
                    {
                        panel2.Width += 1;
                        button3.Left += 1;
                    }
                }
                else
                {
                    timer2.Stop();
                    button3.BackgroundImage = Properties.Resources.折叠  ;
                    open = false;
                    toolTip1.SetToolTip(button3, "单击隐藏题目列表");
                }
            }
            else
            {
                if (panel2.Width > panel3.Width )
                {
                    if (panel2.Width > panel3.Width-20)
                    {
                        panel2.Width -= 5;
                        button3.Left -= 5;
                    }
                    else
                    {
                        panel2.Width -= 1;
                        button3.Left -= 1;
                    }
                }
                else
                {
                    timer2.Stop();
                    button3.BackgroundImage = Properties.Resources.展开;
                    open = true ;
                    toolTip1.SetToolTip(button3, "单击显示题目列表");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        private void drawSolution(string str1,string str2,string str3,Control con,Color str1Col,Color str2Col,int s1,int s2,int s3)
        {
            Graphics g = con.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            g.Clear(con.BackColor);
            Brush b = new SolidBrush(Color.Black );

            g.DrawString("本次答题结果如下：", new Font("宋体", 20, FontStyle.Italic ), b, new Point(0,50));

            b = new SolidBrush(str1Col);
            g.DrawString(str1,new Font ("宋体",s1,FontStyle.Bold ),b,new Point(con.Width/2-(str1.Length *s1)/2,con.Height/2-s1));
            
            Pen p = new Pen(Color.Black, 5);
            //g.DrawLine(p, new Point(0, con.Height / 2), new Point(con.Width , con.Height / 2));

            g.DrawString("分", new Font("宋体", 40, FontStyle.Regular ), b, new Point(con.Width / 2 + str1.Length * s1/3, con.Height / 2 - s1+40));

            
            g.DrawLine(p,new Point(con.Width / 2 - (str1.Length * s1) / 2+10, con.Height / 2 +20),new Point(con.Width / 2 + str1.Length * s1 / 3-10, con.Height / 2 + 20));
            g.DrawLine(p, new Point(con.Width / 2 - (str1.Length * s1) / 2+9, con.Height / 2 + 30), new Point(con.Width / 2 + str1.Length * s1 / 3 - 9, con.Height / 2 + 30));
            
            b = new SolidBrush(str2Col);
            g.DrawString(str2, new Font("楷体", s2, FontStyle.Underline ), b, new Point(con.Width / 2 - (str2.Length * s2)*3/4, con.Height / 2 + 80));
            g.DrawString(str3, new Font("楷体", s3, FontStyle.Underline), b, new Point(0, con.Height-50));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void mybutton1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void mybutton2_Click(object sender, EventArgs e)
        {
            bool over = true;
            foreach (System.Windows.Forms.Button bt in flowLayoutPanel1.Controls)
            {
                if (bt.BackColor != Color.FromArgb(135, 206, 250))
                {
                    if (MessageBox.Show("有部分题目未完成答题，确定提交？", "零分警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        mybutton1.Enabled = true;
                        mybutton2.Enabled = false;
                        timer1.Stop();
                        Over();
                    }
                    else
                    { }
                    over = false;
                    break;
                }
                else
                    over = true;
            }
            if (over == true)
            {


                //button6.Visible = true;
                //button2.Enabled = false;
                mybutton1.Enabled = true;
                mybutton2.Enabled = false;
                timer1.Stop();
                Over();
            }
        }
        private void roundButton3_Click(object sender, EventArgs e)
        {
            if (thisPro > 1)
            {
                thisPro--;
                read(proNumber[thisPro - 1]);
            }
            else
            {
                label10.Text = "已经到顶了哦！";
                label10.BackColor = Color.FromArgb(250, 128, 114);
            }

            //if (thisPro <= 1)
            //{
            //    roundButton3.Enabled = false;
            //    roundButton4.Enabled = true;
            //}
            //else
            //{
            //    roundButton3.Enabled = true;
            //    roundButton4.Enabled = true;
            //}
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            if (thisPro < 50)
            {
                thisPro++;
                read(proNumber[thisPro - 1]);
                label10.Text = "-"+thisPro+"-";
                label10.BackColor = Color.FromArgb(0, 250, 154);
            }
            else
            {
                label10.Text = "已经是最后一题了哦！";
                label10.BackColor = Color.FromArgb(250, 128, 114);
            }
            //if (thisPro >=50)
            //{
            //    roundButton3.Enabled = true;
            //    roundButton4.Enabled = false;
            //}
            //else
            //{
            //    roundButton3.Enabled = true;
            //    roundButton4.Enabled = true;
            //}
        }

        private void mybutton1_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton1,this,mybutton1.BackColor);
        }

        private void mybutton1_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(this);
        }

        private void mybutton2_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton2, this,mybutton2.BackColor);
        }

        private void mybutton2_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(this);
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            lighting(label9, panel2,label9.BackColor);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(panel2);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void mybutton5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                MessageBox.Show("需同意以上内容方可进行考试！", "错  误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                panel1.Visible = false;
                panel1.Top = 1670;
                panel1.Dispose();
                label5.Visible = true;
                panel2.Visible = true;
                mybutton2.Visible = true;
                mybutton1.Enabled = false;
                //button6.Visible = false;
                //button2.Visible = true;
                //panel4.Visible = true;
                timer1.Start();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = pictureBox2.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {
                ps.Clear(pictureBox1.BackColor);
                ps.Dispose();
            }

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "--此处可打草稿--\n#书写内容按住左键移动\n#清除单击右键！");
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = pictureBox2.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                Brush bu = new SolidBrush(Color.FromArgb(0, 0, 0));
                ps.FillEllipse(bu, e.X - 5, e.Y - 5, 10, 10);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            Over();
            roundButton5.Enabled = false;
        }

        private void roundButton6_Click(object sender, EventArgs e)//重做
        {
            write = false;
                roundButton5.Visible = false;
                panel1.Visible = false;
                panel1.Top = 1670;
                panel1.Dispose();
                label5.Visible = true;
                panel2.Visible = true;
                mybutton2.Visible = true;
                mybutton2.Enabled = true;
                mybutton1.Enabled = false;
                label9.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                roundButton6.Visible = false;
                int i = 0;
                Examover = false;
                foreach (mybutton item in flowLayoutPanel1.Controls)
                {
                    item.NormalColor = Color.FromArgb(135, 206, 235);
                    myans[i] = null;
                    i++;
                }
                //button6.Visible = false;
                //button2.Visible = true;
                //panel4.Visible = true;
                examTime = 1200;
                timer1.Start();
                thisPro = 1;
                read(proNumber[thisPro - 1]);
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
                System.Drawing.Font fo = new System.Drawing.Font("宋体", 10.5F);
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
    public class mybutton : RoundButton
    {
        private Color enterForeColor = Color.White;
        private Color leftForeColor = Color.Black;
        private int multiples = 10;
        private float foreSize = 14.5F;
        public float ForeSize
        {
            get { return foreSize; }
            set
            {
                this.foreSize = value;
            }
        }
        public int Multiples
        {
            get { return multiples; }
            set
            {
                this.multiples = value;
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
            ControlState = ControlState.Hover;//正常
            this.ForeColor = this.EnterForeColor;

            this.Left -= this.Width / (2 * Multiples);
            this.Width += this.Width / Multiples;
        }
        protected override void OnMouseLeave(EventArgs e)//鼠标离开
        {
            base.OnMouseLeave(e);
            ControlState = ControlState.Normal;//正常
            this.ForeColor = this.LeftForeColor;
            this.Width -= this.Width / (Multiples + 1);
            this.Left += this.Width / (2 * Multiples);
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

            Color baseColor;
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
                    baseColor = this.NormalColor;
                    break;
            }

            using (SolidBrush b = new SolidBrush(baseColor))
            {
                e.Graphics.FillPath(b, path);
                System.Drawing.Font fo = new System.Drawing.Font("隶书", this.foreSize);
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
            //int diameter;
            //Point lo = new Point(rect.Location.X + 10, rect.Location.Y + 10);
            Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(this.Height, this.Height));
            GraphicsPath path = new GraphicsPath();
            //Pen pp = new Pen(Color.White, 1);
            path.AddArc(arcRect, 90, 180);
            arcRect = new Rectangle(new System.Drawing.Point(this.Width - this.Height, 0), new System.Drawing.Size(this.Height, this.Height));
            path.AddArc(arcRect, 270, 180);
            //
            //path.Widen(pp);
            path.CloseFigure();
            return path;
        }
    }
}
