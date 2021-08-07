using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 快眼刷题
{
    public partial class 测试 : Form
    {
        public static 测试 Cs;
        public 测试()
        {
            InitializeComponent();Cs = this;
        }

       int scorNum = 0;

        int proNums = 0;
       public Button[] bt;
        int proNum = 0;
        private void 测试_Load(object sender, EventArgs e)
        {
            
            bt = new Button[100];
            proNums = AnsProblem.an.proNums;           

            vScrollBar1.Maximum  = proNums / 10-9;
            if (proNum % 10 != 0)
                vScrollBar1.Maximum += 1;

            new_btn(100);
            panel2.Width = bt[9].Right;
            panel2.Height = bt[99].Bottom;
            panel2.Location = new Point(0,label1.Height );
            vScrollBar1.Left = panel2.Right;
            vScrollBar1.Height = panel2.Height;

            scorNum = vScrollBar1.Value;

            button1.Left = vScrollBar1.Right;
            button1.Top = vScrollBar1.Top;
            button1.Height = panel2.Height/2;
            button2.Top = button1.Bottom;
            button2.Left = vScrollBar1.Right;
            button2.Height = panel2.Height / 2;
            this.Width = panel2.Width + vScrollBar1.Width + button1.Width ;
            this.Height = panel2.Height + label1.Height; ;
        }
        public void scrValueChange(int changeStep)
        {
            
        }

        public void new_btn(int num)
        {

            string[] temp = new string[100];
            Form1.f1.readAPro(Form2.f2.proPath, 1, 100, 9, ref temp);
            for (int i = 0; i < 100; i++)
            {
                bt[i] = new Button();
                bt[i].Text = (i + 1).ToString();
                bt[i].Size = new Size(40, 40);
                bt[i].Parent = this.panel2;
                if (i == 0)
                    bt[i].Location = new Point(0, 0);
                else
                {
                    if (i % 10 == 0)
                        bt[i].Location = new Point(bt[0].Left, bt[i - 10].Bottom);
                    else
                        bt[i].Location = new Point(bt[i - 1].Right, bt[i - 1].Top);
                }

                bt[i].Click += 测试_Click;
                bt[i].MouseEnter += 测试_MouseEnter;
                bt[i].MouseLeave += 测试_MouseLeave;
                if (temp[i] == "T")
                {
                    bt[i].BackColor = Color.FromArgb(0, 206, 209);
                }
                else if (temp[i] == "F")
                {
                    bt[i].BackColor = Color.FromArgb(255, 69, 0);
                }
                else
                {
                    bt[i].BackColor = panel2.BackColor;
                }
                bt[i].Enabled = true;
            }
        }
        private void 测试_Click(object sender, EventArgs e)
        {
            if (AnsProblem.an.showAns == false)
            {
                AnsProblem.an.mybutton7.Enabled = true;
                AnsProblem.an.label3.Visible = false;
                AnsProblem.an.label7.Visible = false;
                AnsProblem.an.textBox1.Visible = false;
            }
            AnsProblem.an.clearRadio(AnsProblem.an.panel4);
            AnsProblem.an.label1.Text = ((Button)sender).Text;
            AnsProblem.an.readNewPro(Convert.ToInt32(((Button)sender).Text));
            AnsProblem.an.button5.BackgroundImage = Properties.Resources.列表激活;
            if (AnsProblem.an.showAns == true)
            {
                AnsProblem.an.thisAnstimes++;
                AnsProblem.an.showResoult();
                AnsProblem.an.mybutton7.Enabled = false;
                AnsProblem.an.label23.Text = "刷题量：" + AnsProblem.an.thisAnstimes.ToString();
            }
            AnsProblem.an.bt5click = false;
            close();
        }
        public void close()
        {
            this.Dispose();
            this.Close();
        }

        private void 测试_MouseLeave(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.FromArgb(0, 206, 209) && ((Button)sender).BackColor != Color.FromArgb(255, 69, 0))
            {
                if (((Button)sender).Text != AnsProblem.an.label1.Text)
                    ((Button)sender).BackColor = panel2.BackColor;//
            }
        }

        private void 测试_MouseEnter(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.FromArgb(0, 206, 209) && ((Button)sender).BackColor != Color.FromArgb(255, 69, 0))
            {
                if (((Button)sender).Text != AnsProblem.an.label1.Text)
                    ((Button)sender).BackColor = Color.FromArgb(78, 238, 148);
            }
            //MessageBox.Show(st[Convert.ToInt32(((Button)sender).Text) - 1].ToString());
        }

        public void judge_bt(int btStep, int rowStar,int rowEnd)
        {
            string[] temp = new string[100];
            Form1.f1.readAPro(Form2.f2.proPath, rowStar,rowEnd, 9, ref temp);
           
            for (int i = 0; i < btStep ; i++)
            {
                if (temp[i] == "T")
                {
                    bt[i].BackColor = Color.FromArgb(0, 206, 209);
                }
                else if (temp[i] == "F")
                {
                    bt[i].BackColor = Color.FromArgb(255, 69, 0);
                }
                else
                {
                    bt[i].BackColor = panel2.BackColor;
                    bt[i].Enabled = true;
                }
            }
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {

            setNewValue(vScrollBar1.Value);
            int btStep = 0;
            for(int i=0;i<100;i++)
            {
                if (bt[i].Visible == true)
                    btStep++;
            }
            //MessageBox.Show(bt[0].Text.Trim()+" "+ bt[99].Text.Trim()+" "+btStep.ToString());
            judge_bt(btStep,Convert.ToInt32(bt[0].Text.Trim()), Convert.ToInt32(bt[0].Text.Trim())+btStep-1);
            
        }

        public void setNewValue(int value)
        {
            for (int i = 0; i < 100; i++)
            {
                
                bt[i].Text = (value* 10 + 1 + i).ToString();
                if (Convert.ToInt32(bt[i].Text.Trim().ToString()) > proNums)
                    bt[i].Visible = false;
                else
                {
                    bt[i].Visible = true ;
                }
            }
        }
        
        public void topPage(int moveStep)
        {
            int num = Convert.ToInt32(bt[90].Text.Trim().ToString());
            int temp = proNums - proNums %10  + 1;
            if (proNums % 10 == 0)
                temp = proNums -9;
            if (num < temp )
            {
                
                int step = 10;
                if (proNums % 10 != 0&& num ==proNums - proNums % 10-10 * moveStep+1)
                    step =proNums % 10 ;
                for (int i = 0; i < 100; i++)
                {
                    bt[i].Text = (Convert.ToInt32(bt[i].Text.Trim()) + 10 * moveStep).ToString();
                    if (i > step + 89)
                    {
                        bt[i].Visible = false;
                    }
                    else
                    {
                        bt[i].Visible = true ;
                    }

                    if (bt[i].Text == AnsProblem.an.label1.Text.Trim())
                    {
                        bt[i].BackColor = Color.FromArgb(0, 255, 127);
                    }
                }
            }
        }
        public void nextPage(int moveStep)
        {
            int num = Convert.ToInt32(bt[0].Text.Trim().ToString());
            if (num > 1)
            {
                int step = 10* moveStep;
                if (num < 10 * moveStep)
                    step = num - 1;
                for (int i = 0; i < 100; i++)
                {
                    if (bt[i].Visible == false)
                        bt[i].Visible = true;
                    bt[i].Text = (Convert.ToInt32(bt[i].Text.Trim()) - 10 * moveStep).ToString();
                    if (bt[i].Text == AnsProblem.an.label1.Text.Trim())
                    {
                        bt[i].BackColor = Color.FromArgb(0, 255, 127);
                    }
                }
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
                AnsProblem.an.bt5click = false;
                AnsProblem.an.button5.BackgroundImage = Properties.Resources.列表激活;
            this.Dispose();
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                bt[i].Enabled = true;
                bt[i].BackColor = panel2.BackColor;
            }
            string[,] values = new string[proNums,10];
            Form1.f1.readAPro(Form2.f2.proPath, ref values ,proNums,10);
            for (int i = 0; i < proNums; i++)
            { values[i, 9] = "O"; }
            Form1.f1.add_row(Form2.f2.proPath, values, proNums , 10);
            MessageBox.Show("清除成功！");
        }
    }
}
