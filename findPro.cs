using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MSWord = NPOI.XSSF.UserModel;
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
using System.Collections.Generic;

namespace 快眼刷题
{
    public partial class findPro : Form
    {
        public findPro()
        {
            InitializeComponent();
        }
        string path = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            listBox1.Height = 4;
            if (textBox1.Text == "")
                hideControl();
            else
            {
                seach();
                if (listBox1.Items.Count == 0)
                    label10.Text = "没有关于“" + textBox1.Text.Trim() + "”的记录...";
                else
                    label10.Text = "帮你找到了" + listBox1.Items.Count.ToString() + "关于“" + textBox1.Text.Trim() + "”的记录...";
                label10.Visible = true;
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            hideControl();
            if (textBox1.Text.Trim()!="")
                listBox1.Visible = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            //textBox1.Text = "";
            //listBox1.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        string[] ch = { "A", "B", "C", "D" };
        private void listBox1_Click(object sender, EventArgs e)
        {

            showControl();
            int i= 6;
            int index = listBox1.SelectedItem.ToString().Trim().IndexOf("、");
            textBox2.Text = str[listBox1.SelectedIndex , 0] + "、" + str[listBox1.SelectedIndex , 2];
            //textBox2.Text = listBox1.SelectedItem.ToString();
            int j = 3;
            label6.Text = str[listBox1.SelectedIndex ,8]+"颗星";

            foreach (KeyValuePair<string, string> item in Form1.f1.proTypes)
            {
                if (str[listBox1.SelectedIndex, 1] == item.Key)
                {
                    str[listBox1.SelectedIndex, 1] = item.Value;
                    break;
                }
            }

            label4.Text ="@"+ str[listBox1.SelectedIndex, 1];//Convert.ToInt32(textBox2.Text.Substring(0, index))
            label2.Text = str[listBox1.SelectedIndex, 7];
            foreach (System.Windows.Forms.Control rioBt in panel1.Controls)
            {
                if (rioBt is System.Windows.Forms.RadioButton)
                {
                    
                    ((System.Windows.Forms.RadioButton)(rioBt)).Checked = false;
                    rioBt.Text =ch[j] + "、 " +str[listBox1.SelectedIndex, i] ;
                    if(ch[j] == label2.Text.Trim())
                        rioBt.BackColor = Color.FromArgb(67 ,205, 128); 
                    else
                        rioBt.BackColor = Color.FromArgb(224,255,255);
                    i--;j--;
                }
                
            }
            listBox1.Visible = false;
            button1.Visible = true;
            button3.Visible = true ; 
            panel1.Visible = true;
        }

        private void findPro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                if (ActiveControl.Name == "textBox1")
                {
                    if (listBox1.SelectedIndex > 0)
                        listBox1.SetSelected(listBox1.SelectedIndex - 1, true);
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                if (ActiveControl.Name == "textBox1")
                {
                    if (listBox1.Items.Count != 0)
                    {
                        if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                            listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            hideControl();
            listBox1.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
        }
        public void showControl()
        {
            
                label1.Visible = true; label2.Visible = true;
                label3.Visible = true; label4.Visible = true;
                label5.Visible = true; label6.Visible = true;
        }
        public void hideControl()
        {
                label1.Visible = false ; label2.Visible = false;
                label3.Visible = false; label4.Visible = false;
                label5.Visible = false; label6.Visible = false;
            label10.Text = "";
            label10.Visible = false;
        }

        private void findPro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Form1.f1.button2.Enabled = true;
            Form1.f1.Show();
        }
        string[,] str = new string[Form1.f1.proNum + 1, 10];
        public void seach()
        {          
            
            string ch = "";
            listBox1.Visible = false;
            progressBar1.Value = 0;
            listBox1.Items.Clear(); 
            listBox1.Height = 0;
            int listNum = 0;


            findMyPro(ref str, textBox1.Text.Trim(), ref listNum);


            if (textBox1.Text.Trim() != "")
            {
                timer1.Start();
                //pictureBox1.Visible = true;
                listBox1.Visible = true;
                for (int i = 0; i < listNum ; i++)
                {
                    //if (str[i, 2].Contains(textBox1.Text.Trim()))
                    //{
                        //MessageBox.Show(str[0] + "、" + str[2]);
                        if (listBox1.Height <= 199)
                            listBox1.Height += 15;
                        if (((Convert.ToInt32(str[i, 0]) + 1).ToString() + "、" + str[i, 2]).Length >= 38)
                            ch = ((Convert.ToInt32(str[i, 0]) + 1).ToString() + "、" + str[i, 2]).Substring(0, 35) + "...";
                        else
                            ch = (Convert.ToInt32(str[i, 0]) + 1).ToString() + "、" + str[i, 2];
                        listBox1.BeginUpdate();
                        listBox1.Items.Add(ch);
                        listBox1.EndUpdate();

                    //}
                    progressBar1.Value += 1;
                }
                timer1.Stop();
                //MessageBox.Show(Form1.f1.proNum.ToString()+progressBar1.Value.ToString());
                //pictureBox1.Visible = false;
            }
            else
                listBox1.Visible = false;
        }

        public void findMyPro(ref string [,]str,string title,ref int fondproNum)
        {
            NPOI.SS.UserModel.ISheet myexcle;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            myword.HSSFWorkbook excl = new myword.HSSFWorkbook(fs);
            myexcle = excl.GetSheetAt(0);
            fondproNum = 0;
            for (int j = 0; j <Form1.f1.proNum; j++)
            {
                if (myexcle.GetRow(j).GetCell(2).ToString().Trim().Contains(title))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        str[fondproNum, i] = myexcle.GetRow(j).GetCell(i).ToString();
                    }
                    fondproNum++;
                }
            }
            fs.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            seach();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
                listBox1.Visible = true;

        }

        private void findPro_Load(object sender, EventArgs e)
        {
            path =Form2.f2.proPath;//Path.Combine(System.IO.Directory.GetCurrentDirectory(), "题库", Chiose.ch1.proYear);
            hideControl();
            //pictureBox1.Location = new Point(textBox1.Width /2+textBox1.Left-pictureBox1.Width/2, pictureBox1.Height/2+textBox1.Bottom );
            progressBar1.Maximum = Form1.f1.proNum;
            progressBar1.Width = textBox1.Width;
            
            button2.BackColor = Color.White;
            //button2.Size = new Size(textBox1.Height-1, textBox1.Height-1);
            //button2.Left = textBox1.Right-button2.Width;
            //Form1.f1.readAPro(path, ref str);
            //for(int i=0;i<10;i++)
            //  MessageBox.Show(str[i,0]);
        }
        public void get_pro(ref string[] my_pro)
        {
            //string[] arr = textBox1.Text.Trim().Split('、');
            my_pro[0] =textBox2.Text.Trim().Substring(0, textBox2.Text.IndexOf('、'));
            my_pro[1] =label4.Text.Trim();
            my_pro[2] =textBox2.Text.Trim().Substring(textBox2.Text.IndexOf('、')+1, textBox2.Text.Trim().Length-my_pro[0].Length-1);
            my_pro[3] =radioButton1.Text.Trim().Substring(2,radioButton1.Text.Trim().Length-2);
            my_pro[4] = radioButton2.Text.Trim().Substring(2, radioButton2.Text.Trim().Length - 2);
            my_pro[5] = radioButton3.Text.Trim().Substring(2, radioButton3.Text.Trim().Length - 2);
            my_pro[6] = radioButton4.Text.Trim().Substring(2, radioButton4.Text.Trim().Length - 2);
            my_pro[7] =label2.Text.Trim();
            my_pro[8] =label6.Text.Trim().Substring(0,1);
            my_pro[9] ="T";
        }
        string[,] collect;
        string[] my_pro=new string[10];
        private void button3_Click(object sender, EventArgs e)
        {
            get_pro(ref my_pro);
            int Col_num = 0;
            if (File.Exists(@"收藏夹.xls"))
            {
                Form1.f1.readProNum(@"收藏夹.xls", ref Col_num);
            }
            else
                File.Create(@"收藏夹.xls");
            collect = new string[++Col_num, 10];
            if (Col_num > 1)
                Form1.f1.readAPro(@"收藏夹.xls", ref collect, Col_num - 1);
            for (int col_num = 0; col_num < Col_num; col_num++)
            {
                if (my_pro[2] == collect[col_num, 2])
                {
                    MessageBox.Show("不能重复添加！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                if (col_num == Col_num - 1)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0)
                            collect[Col_num - 1, i] = (Col_num).ToString();
                        else
                            collect[Col_num - 1, i] = my_pro[i];
                    }
                    Form1.f1.add_row(@"收藏夹.xls", collect, collect.Length / 10, 10);
                    //MessageBox.Show((collect.Length / 9).ToString()+":"+Col_num.ToString());
                    MessageBox.Show("添加成功！");
                    hideControl();
                    button1.Visible = false;
                    button3.Visible = false;
                }
            }

            Array.Clear(collect, 0, Col_num);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    //this.Focus();
            //    this.SelectNextControl(this.button2, true, true, true, true);
            //    if (listBox1.Visible == false)
            //    {
            //        //if (textBox1.Text != "")
            //        //{
            //        //    seach();
            //        //}
            //    }
            //    else
            //    {
            //        if (listBox1.SelectedItem != null)
            //            listBox1_Click(sender, e);
            //    }
            //}
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(209 ,238, 238);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "在搜索框中输入查询例题的关键字即可");
        }
    }

   
}
