using NPOI.XWPF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 快眼刷题.Form1;

namespace 快眼刷题
{
    public partial class AnsProblem : Form
    {
        public static AnsProblem an;
        public AnsProblem()
        {
            InitializeComponent(); an = this;
        }
        int awTrue = 0;
        int awFalse = 0;
        public int proNums = 0;//共有题目数量
        public int proOver = 0;//上次答题记录
        public int proStep = 0;//本次答题总数
        public int thisAnstimes = 0;//记录本次刷题次数
        public bool showAns = false;//是否背题模式，答题模式
        string path = Form2.f2.proPath;

        string[] str = new string[10];



        public string[] st;

        void conLocTION()
        {
           

            panel6.Left = (this.Width  - panel6.Width) / 2;
            panel6.Top = (this.Height - panel6.Height )/ 2;
            if (panel6.Top < 0)
                panel6.Top = 0;
            panel1.Top = textBox2.Top;
            panel1.Left = panel6.Right;
            panel1.Width = this.Width - panel6.Right;

            //panel6.Left -= panel1.Width / 2;
            panel1.Left = panel6.Right;

            mybutton9.Left =panel1.Left+10;
            mybutton9.Top = panel1.Bottom+10;

            mybutton10.Left = mybutton9.Left;
            mybutton10.Top = mybutton9.Bottom+mybutton9.Height/4;

            mybutton11.Left = mybutton10.Left;
            mybutton11.Top = mybutton10.Bottom + mybutton10.Height/4;

            panel5.Left = (this.Width - panel5.Width) / 2;
            panel5.Top = (this.Height- panel5.Height) / 2;

            //panel5.Location = new Point(0, mybutton5.Top -panel5.Height );

            mybutton12.Location = new Point(panel5.Width/2 -mybutton12.Width/2,panel5.Height-mybutton12.Height-5);
        }
        //void selectPan6(int x,int y)
        //{
        //    foreach (Control item in panel6.Controls)
        //    {
        //        if (item != panel6)
        //        {
        //            float size = item.Font.Size;
        //            string namefont = item.Font.Name;
        //            if (item.Width - x > 0)
        //                item.Width -= x+20;
        //            else
        //                item.Width = 1;
        //            if (item.Height - y > 0)
        //                item.Height -= y;
        //            else
        //                item.Height = 1;
        //            item.Left -= x / 2+20;
        //            item.Top -= y;
        //            item.Font = new Font(namefont, size, FontStyle.Regular);
        //        }
        //    }
        //}
        private void AnsProblem_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = Form1.f1.progressBar1.Maximum;

            progressBar1.Value = Form1.f1.progressBar1.Value;
            //int x = 0, y = 0;
            //panel6.Top = 0;
            //if (panel6.Height > this.Height)
            //    y = panel6.Height - this.Height;
            //panel6.Height = this.Height;
            //panel6.Left = this.Width / 2 - panel6.Width / 2;
            //if (panel6.Left < mybutton5.Right+20)
            //{
            //    x= 2 * (mybutton5.Right - panel6.Left + 20);
            //    panel6.Width -= x;
            //    panel6.Left = mybutton5.Right+20;
            //}
            //selectPan6(x, y);
            conLocTION();//调整界面
            st = new string[proNums + 1];
            strs = new string[proNums + 1, 10];
            Form1.f1.readAPro(path, ref strs);
            pictureBox1.Location = label8.Location;
            readNewPro(proOver);

            label1_TextChanged(sender, e);

            panel6.Visible = true;
            panel1.Visible = true;
            timer2.Start();
        }


        public void clearRadio(Panel p)
        {
            label9.Visible = false;
            label8.Visible = false;
            if (showAns == false)
            {
                flowLayoutPanel1.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label14.Visible = false;
                label21.Visible = false;
            }
            foreach (RadioButton ri in p.Controls)
            {
                if (ri.Checked == true)
                    ri.Checked = false;
                ri.BackColor = panel4.BackColor;
                ri.Enabled = true;
            }
        }

        
        public void readNewPro(int num)//读取一个题
        {
            Form1.f1.readAPro(num, path, ref str);
            label1.Text = str[0];
            Form1.f1.showTxtBox(textBox2,ref str[2],13);//13
            textBox2.Text = str[2];
            radioButton1.Text = "A、" + str[3];
            radioButton2.Text = "B、" + str[4];
            radioButton3.Text = "C、" + str[5];
            radioButton4.Text = "D、" + str[6];
            label7.Text = str[7];
            label11.Text = str[8] + "颗星";
            foreach (KeyValuePair<string, string> item in Form1.f1.proTypes)
            {
                if (str[1] == item.Key)
                {
                    str[1] = item.Value;
                    break;
                }
            }
            label21.Text = "@[" + str[1]+"]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        public bool bt5click = false;
        private void button5_Click(object sender, EventArgs e)
        {

            if (bt5click == false)
            {
                测试 cs = new 测试();
                cs.Show();
                cs.Top = panel1.Top - cs.Height;
                cs.Left = this.Width/2-cs.Width/2;
                cs.Top = this.Height / 2 - cs.Height / 2;
                bt5click = true;
                button5.BackgroundImage = Properties.Resources.列表关闭;

                int PageNo = Convert.ToInt32(label1.Text.Trim().ToString()) % 10;
                if (Convert.ToInt32(this.label1.Text.Trim().ToString()) >= proNums - 100 && Convert.ToInt32(this.label1.Text.Trim().ToString()) <= proNums)
                {
                    测试.Cs.vScrollBar1.Value = 测试.Cs.vScrollBar1.Maximum;
                }
                else
                    测试.Cs.vScrollBar1.Value = (Convert.ToInt32(this.label1.Text.Trim().ToString()) - PageNo) / 10;
            }
            else
            {

                测试.Cs.button1_Click(sender, e);
                bt5click = false;
                button5.BackgroundImage = Properties.Resources.列表激活;
            }

        }


        Stack<Control> query = new Stack<Control>();
        public void clear(Control item)
        {
            for (int i = 0; i < item.Controls.Count; i++)
            {
                if (item.Controls[i].HasChildren)
                    clear(item.Controls[i]);
                else
                    query.Push(item.Controls[i]);
            }
        }

        public void show_difficulty(int NO)//显示难度的等级，对应星星的数目
        {
            foreach (PictureBox pi in flowLayoutPanel1.Controls)
            {
                if (NO <= 0)
                    pi.BackgroundImage = Properties.Resources.星星0;
                else
                    pi.BackgroundImage = Properties.Resources.星星;
                NO--;
            }
        }
        string[,] strs;
        void read(object vioceTxt)
        {
            Form1.f1.sp.Speak(vioceTxt);
        }
        Thread td;

        public void addToExcle(string path)
        {
            int false_num = 0;
                Form1.f1.readProNum(path, ref false_num);
                //MessageBox.Show(false_num.ToString());
                //false_num++;
           
            collect = new string[false_num + 1, 11];
            if (false_num > 0)
                Form1.f1.readAPro(path, ref collect, false_num, 11);
            for (int col_num = 0; col_num < false_num + 1; col_num++)
            {
                if (col_num == false_num)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        if (i == 0)
                            collect[false_num, i] = (false_num).ToString();
                        else if (i == 10)
                        {
                            collect[false_num, i] = label8.Text.Trim();
                        }
                        else
                            collect[false_num, i] = strs[Convert.ToInt32(label1.Text.Trim()) - 1, i];
                    }
                    Form1.f1.add_row(path, collect, false_num + 1, 11);
                    //MessageBox.Show("已加入错题本！");
                    break;
                }
                if (strs[Convert.ToInt32(label1.Text.Trim()) - 1, 2] == collect[col_num, 2])
                {
                    break;
                }
            }
        }
        public double getnum(int num1, int num2)
        {
            double num = 0.0000;
            num = Convert.ToDouble(num1) / Convert.ToDouble(num1 + num2);
            return num * 100;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label1.Text.Trim()) <= 1)
                showButton3.Enabled = false;
            else
                showButton3.Enabled = true;

            if (Convert.ToInt32(label1.Text.Trim()) >= proNums)
                showButton4.Enabled = false;
            else
                showButton4.Enabled = true;
        }

        private void radioButton1_MouseEnter(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton1.Checked == false)
                    radioButton1.BackColor = Color.FromArgb(255, 218, 185);
            }
        }

        private void radioButton1_MouseLeave(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton1.Checked == false)
                    radioButton1.BackColor = panel4.BackColor;
            }
        }

        private void radioButton2_MouseEnter(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton2.Checked == false)
                    radioButton2.BackColor = Color.FromArgb(255, 218, 185);
            }
        }

        private void radioButton2_MouseLeave(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton2.Checked == false)
                    radioButton2.BackColor = panel4.BackColor;
            }
        }

        private void radioButton3_MouseEnter(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton3.Checked == false)
                    radioButton3.BackColor = Color.FromArgb(255, 218, 185);
            }
        }

        private void radioButton3_MouseLeave(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton3.Checked == false)
                    radioButton3.BackColor = panel4.BackColor;
            }
        }

        private void radioButton4_MouseEnter(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton4.Checked == false)
                    radioButton4.BackColor = Color.FromArgb(255, 218, 185);
            }
        }

        private void radioButton4_MouseLeave(object sender, EventArgs e)
        {
            if (mybutton7.Enabled != false)
            {
                if (radioButton4.Checked == false)
                    radioButton4.BackColor = panel4.BackColor;
            }
        }

        private void radioButton1_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton1.Checked = true;
            radioButton1.BackColor = Color.FromArgb(30, 144, 255);
            foreach (RadioButton r in panel4.Controls)
            {
                if (r.Checked == false)
                    r.BackColor = panel4.BackColor;
            }
        }

        private void radioButton2_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton2.Checked = true;
            radioButton2.BackColor = Color.FromArgb(30, 144, 255);
            foreach (RadioButton r in panel4.Controls)
            {
                if (r.Checked == false)
                    r.BackColor = panel4.BackColor;
            }
        }

        private void radioButton3_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton3.Checked = true;
            radioButton3.BackColor = Color.FromArgb(30, 144, 255);
            foreach (RadioButton r in panel4.Controls)
            {
                if (r.Checked == false)
                    r.BackColor = panel4.BackColor;
            }
        }

        private void radioButton4_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton4.Checked = true;
            radioButton4.BackColor = Color.FromArgb(30, 144, 255);
            foreach (RadioButton r in panel4.Controls)
            {
                if (r.Checked == false)
                    r.BackColor = panel4.BackColor;
            }
        }
        string[,] collect;
        private void button4_Click(object sender, EventArgs e)//收藏此题
        {
            int Col_num = 0;
            if (File.Exists(@"收藏夹.xls"))
            {
                Form1.f1.readProNum(@"收藏夹.xls", ref Col_num);
            }
            else
                File.Create(@"收藏夹.xls");
            collect = new string[Col_num + 1, 10];
            if (Col_num > 0)
                Form1.f1.readAPro(@"收藏夹.xls", ref collect, Col_num);
            for (int col_num = 0; col_num < Col_num + 1; col_num++)
            {
                if (col_num == Col_num)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0)
                            collect[Col_num, i] = (Col_num).ToString();
                        else
                            collect[Col_num, i] = strs[Convert.ToInt32(label1.Text.Trim()) - 1, i];
                    }
                    Form1.f1.add_row(@"收藏夹.xls", collect, Col_num + 1, 10);
                    //MessageBox.Show((collect.Length / 9).ToString()+":"+Col_num.ToString());
                    MessageBox.Show("添加成功！");
                    break;
                }
                if (strs[Convert.ToInt32(label1.Text.Trim()) - 1, 2] == collect[col_num, 2])
                {
                    MessageBox.Show("不能重复添加！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void AnsProblem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            { showButton1_Click(sender, e); }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            { showButton2_Click(sender, e); }
        }

        private void close()
        {
            string btStr = proOver.ToString();
            if (mybutton7.Enabled == false)
            {
                if (Convert.ToInt32(btStr) < proNums)
                    btStr = (Convert.ToInt32(btStr) + 1).ToString();
            }
            StreamWriter sw = new StreamWriter(@"阅题记录.txt", false, Encoding.UTF8);
            sw.Write(btStr);

            sw.Close();
            this.Dispose();
            this.Close();
            Form1.f1.Show();
        }  
        private void AnsProblem_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] tf = { "F", "T" };
            int num = 0;
            Form1.f1.getnum(Form2.f2.proPath, ref num, 9, Form1.f1.proNum, tf);
            Form1.f1.label1.Text = num.ToString() + @"\" + proNums.ToString();
            测试.Cs.button1_Click(sender, e);
            close();
        }

        private void AnsProblem_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }

        private void showButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void showButton2_Click(object sender, EventArgs e)
        {
           
        }
        public void showResoult()
        {
            if (st[0] == null)
                Form1.f1.readAPro(path, ref st, 9, proNums);

            label10.Visible = true;
            label11.Visible = true;
            label14.Visible = true;
            label21.Visible = true;
            show_difficulty(Convert.ToInt32(label11.Text.Substring(0, 1)));
            flowLayoutPanel1.Visible = true;
            mybutton7.Enabled = false;
            label3.Visible = true;
            label7.Visible = true;
            textBox1.Visible = true;
            foreach (RadioButton ri in this.panel4.Controls)
            {
                if (ri.Text.StartsWith(label7.Text.Trim()))
                {
                    ri.BackColor = Color.FromArgb(50, 205, 50);
                }
                //if (showAns == true)
                    ri.Enabled = false;
            }
            if(showAns==true)
            {
                st[Convert.ToInt32(label1.Text.Trim())] = "T";
                strs[Convert.ToInt32(label1.Text.Trim()), 9] = "T";
                Form1.f1.setNew_value(path, Convert.ToInt32(label1.Text.Trim()), 9, "T", proNums, strs);
                proOver = Convert.ToInt32(label1.Text.Trim());
            }
        }
        private void mybutton1_Click(object sender, EventArgs e)
        {
            
        }

        private void mybutton2_Click(object sender, EventArgs e)
        {
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
        private void showButton2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void showButton2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void showButton1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void showButton1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void mybutton1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void mybutton1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void mybutton2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void mybutton2_MouseLeave(object sender, EventArgs e)
        {

        }


    public class ElliButton : System.Windows.Forms.Button
        {
            public ElliButton()
            {
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

            //重写OnPaint
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                base.OnPaint(e);
                base.OnPaintBackground(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingMode = CompositingMode.SourceCopy;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                var path = GetRoundedRectPath(rect);
                this.Region = new Region(path);
                e.Graphics.FillPath(new SolidBrush(this.BackColor), path);

            }
            private GraphicsPath GetRoundedRectPath(Rectangle rect)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(rect);
                path.CloseFigure();
                return path;
            }

            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void mybutton3_Click(object sender, EventArgs e)
        {
        }

        private void mybutton4_Click(object sender, EventArgs e)//结束刷题
        {
            
        }

        private void mybutton5_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void AnsProblem_MouseDown(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = this.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {
                ps.Clear(this.BackColor);
                ps.Dispose();
            }
        }

        private void AnsProblem_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = this.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                Brush bu = new SolidBrush(Color.FromArgb(0, 0, 0));
                ps.FillEllipse(bu, e.X - 5, e.Y - 5, 10, 10);
            }
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = panel6.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {
                ps.Clear(panel6.BackColor);
                ps.Dispose();
            }
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = panel6.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                Brush bu = new SolidBrush(Color.FromArgb(0, 0, 0));
                ps.FillEllipse(bu, e.X - 5, e.Y - 5, 10, 10);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = panel1.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {
                ps.Clear(panel1.BackColor);
                ps.Dispose();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Graphics ps = panel1.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                Brush bu = new SolidBrush(Color.FromArgb(0, 0, 0));
                ps.FillEllipse(bu, e.X - 5, e.Y - 5, 10, 10);
            }
        }
        private void mybutton6_Click(object sender, EventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void showButton3_Click(object sender, EventArgs e)
        {
            if (showAns == false)
            {
                mybutton7.Enabled = true;
                label3.Visible = false;
                label7.Visible = false;
                textBox1.Visible = false;
            }
            clearRadio(panel4);

            label1.Text = (Convert.ToInt32(label1.Text.Trim()) - 1).ToString();

            readNewPro(Convert.ToInt32(label1.Text.Trim()));
            if (showAns == true)
            {
                showResoult();
                mybutton7.Enabled = false;
                thisAnstimes++;
                label23.Text = "刷题量：" + thisAnstimes.ToString();
            }
        }

        private void showButton4_Click(object sender, EventArgs e)
        {
            if (showAns == false)
            {
                mybutton7.Enabled = true;
                label3.Visible = false;
                label7.Visible = false;
                textBox1.Visible = false;
            }
            clearRadio(panel4);
            label1.Text = (Convert.ToInt32(label1.Text.Trim()) + 1).ToString();
            readNewPro(Convert.ToInt32(label1.Text.Trim()));
            if (showAns == true)
            {
                showResoult();
                mybutton7.Enabled = false;
                thisAnstimes++;
                label23.Text = "刷题量：" + thisAnstimes.ToString();
            }
        }

        private void mybutton7_Click(object sender, EventArgs e)
        {
            td = new Thread(read);
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {

                td = new Thread(read);
                td.Start("失败，请选择答案！");

                MessageBox.Show("未选择", "警 告", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (strs[Convert.ToInt32(label1.Text.Trim()), 9] != "T" && strs[Convert.ToInt32(label1.Text.Trim()), 9] != "F")
                {
                    proStep++;//本次答题数目累计加一
                    //Form1.f1.proStep += proStep;
                }
                showResoult();
                //if (st[0] == null)
                //    Form1.f1.readAPro(path, ref st, 9, proNums);

                //label10.Visible = true;
                //label11.Visible = true;
                //label14.Visible = true;
                //label21.Visible = true;
                //show_difficulty(Convert.ToInt32(label11.Text.Substring(0, 1)));
                //flowLayoutPanel1.Visible = true;
                //mybutton1.Enabled = false;
                //label3.Visible = true;
                //label7.Visible = true;
                //textBox1.Visible = true;
                //foreach (RadioButton ri in this.panel4.Controls)
                //{
                //    if (ri.Text.StartsWith(label7.Text.Trim()))
                //    {
                //        ri.BackColor = Color.FromArgb(50, 205, 50);
                //    }
                //}
                foreach (RadioButton ri in this.panel4.Controls)
                {
                    if (ri.Checked == true)
                    {
                        if (!ri.Text.StartsWith(label7.Text.Trim()))
                        {
                            td = new Thread(read);
                            td.Start("很遗憾，答错啦");

                            st[Convert.ToInt32(label1.Text.Trim())] = "F";
                            strs[Convert.ToInt32(label1.Text.Trim()), 9] = "F";
                            Form1.f1.setNew_value(path, Convert.ToInt32(label1.Text.Trim()), 9, "F", proNums, strs);

                            label9.Visible = true;
                            label8.Visible = true;
                            label8.Text = ri.Text.Substring(0, 1);
                            label8.ForeColor = Color.Red;
                            ri.BackColor = Color.FromArgb(255, 48, 48);

                            td = new Thread(read);

                            if (MessageBox.Show("是否加入错题本？", "    很遗憾，答错啦！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                addToExcle(@"错题本.xls");
                                MessageBox.Show("添加成功", "    提  示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                td = new Thread(read);
                                td.Start("添加成功");

                            }
                            awFalse++;
                        }
                        else
                        {
                            st[Convert.ToInt32(label1.Text.Trim())] = "T";
                            strs[Convert.ToInt32(label1.Text.Trim()), 9] = "T";
                            Form1.f1.setNew_value(path, Convert.ToInt32(label1.Text.Trim()), 9, "T", proNums, strs);
                            label9.Visible = true;
                            label8.Visible = true;
                            label8.Text = ri.Text.Substring(0, 1);
                            label8.ForeColor = Color.Green;
                            awTrue++;
                            td = new Thread(read);
                            td.Start("恭喜您，答对了！");

                        }

                    }
                }

                // Form1.f1.proOver = Convert.ToInt32(label1.Text.Trim());


                //foreach (RadioButton ri in panel4.Controls)
                //{
                //    ri.Enabled = false;
                //}
                thisAnstimes++;
                label4.Text = "正确：" + awTrue.ToString();
                label5.Text = "错误：" + awFalse.ToString();
                label6.Text = "准确率：" + getnum(awTrue, awFalse).ToString("f2") + "%";
                label23.Text = "刷题量：" + thisAnstimes.ToString();
                proOver = Convert.ToInt32(label1.Text.Trim());
            }
            progressBar1.Value = Form1.f1.progressBar1.Value;
        }

        private void mybutton8_Click(object sender, EventArgs e)
        {

            int Col_num = 0;
            if (File.Exists(@"收藏夹.xls"))
            {
                Form1.f1.readProNum(@"收藏夹.xls", ref Col_num);
            }
            else
                File.Create(@"收藏夹.xls");
            collect = new string[Col_num + 1, 10];
            if (Col_num > 0)
                Form1.f1.readAPro(@"收藏夹.xls", ref collect, Col_num);
            for (int col_num = 0; col_num < Col_num + 1; col_num++)
            {
                if (col_num == Col_num)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0)
                            collect[Col_num, i] = (Col_num).ToString();
                        else
                            collect[Col_num, i] = strs[Convert.ToInt32(label1.Text.Trim()) - 1, i];
                    }
                    Form1.f1.add_row(@"收藏夹.xls", collect, Col_num + 1, 10);
                    MessageBox.Show("添加成功！");
                    td = new Thread(read);
                    td.Start("收藏成功！");
                    break;
                }
                if (strs[Convert.ToInt32(label1.Text.Trim()) - 1, 2] == collect[col_num, 2])
                {
                    td = new Thread(read);
                    td.Start("操作失败！重复添加了！");
                    MessageBox.Show("不能重复添加！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
                }
            }
        }

        private void mybutton9_Click(object sender, EventArgs e)
        {
            if (showAns == false)
            {
                pictureBox7.BackgroundImage = Properties.Resources.背题;
                showResoult();
                mybutton9.Text = "答题模式";
                showAns = true;
                mybutton7.Enabled = false;
                label22.Text = "背\n题\n进\n行\n中\n.\n.\n.";
                mybutton9.NormalColor = Color.FromArgb(148, 0, 211);
                label22.ForeColor = Color.MediumSeaGreen;
            }
            else
            {
                pictureBox7.BackgroundImage = Properties.Resources.答题;
                showResoult();
                mybutton9.Text = "背题模式";
                showAns = false;
                mybutton7.Enabled = true;

                label10.Visible = false;
                label11.Visible = false;
                label14.Visible = false;
                label21.Visible = false;
                flowLayoutPanel1.Visible = false;
                label3.Visible = false;
                label7.Visible = false;
                textBox1.Visible = false;
                label22.Text = "正\n在\n答\n题\n.\n.\n.";
                mybutton9.NormalColor = Color.MediumSeaGreen;
                label22.ForeColor = Color.FromArgb(148, 0, 211);
            }
        }

        private void mybutton10_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void mybutton11_Click(object sender, EventArgs e)
        {
            string[] tf = { "F", "T" };


            int num = 0;
            Form1.f1.getnum(Form2.f2.proPath, ref num, 9, Form1.f1.proNum, tf);
            Form1.f1.label1.Text = num.ToString() + @"\" + proNums.ToString();

            if (!label4.Text.Trim().Contains("*"))
            {
                int mathNum = Convert.ToInt32(label6.Text.Trim().Substring(4, Convert.ToInt32(label6.Text.Trim().Length) - 8));
                string showStr = "    " + label4.Text + "\n    " + label5.Text + "\n    " + label6.Text + "\n    " + label23.Text + "     ";
                if (mathNum < 25)
                    showStr += "\n实在是不符合你的实力";
                else if (mathNum >= 25 && mathNum < 50)
                    showStr += "\n没有发挥好？下次加油！";
                else if (mathNum >= 50 && mathNum < 75)
                    showStr += "\n离成功仅一步之遥，不过还蛮不错！";
                else
                    showStr += "\n太棒啦，继续保持，nice!";
                MessageBox.Show(showStr, "☆✈本次作答情况如下：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (bt5click != false)
                测试.Cs.button1_Click(sender, e);
            close();
        }

        private void showButton3_MouseEnter(object sender, EventArgs e)
        {
            lighting(showButton3, panel2, showButton3.BackColor);
        }

        private void showButton3_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(panel2);
        }

        private void mybutton7_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton7, panel2, mybutton7.HoverColor);
        }

        private void mybutton7_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(panel2);
        }

        private void showButton4_MouseEnter(object sender, EventArgs e)
        {
            lighting(showButton4, panel2, showButton4.BackColor);
        }

        private void showButton4_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(panel2);
        }

        private void mybutton8_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton8, panel2, mybutton8.HoverColor);
        }

        private void mybutton8_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(panel2);
        }

        private void mybutton9_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton9, this, mybutton9.HoverColor);
        }

        private void mybutton9_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(this);
        }

        private void mybutton10_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton10, this, mybutton10.HoverColor);
        }

        private void mybutton10_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(this);
        }

        private void mybutton11_MouseEnter(object sender, EventArgs e)
        {
            lighting(mybutton11, this, mybutton11.HoverColor);
        }

        private void mybutton11_MouseLeave(object sender, EventArgs e)
        {
            clearLighting(this);
        }

        private void mybutton12_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }
    }
}

