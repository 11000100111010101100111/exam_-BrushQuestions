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
    public partial class Chiose : Form
    {
        public Chiose()
        {
            InitializeComponent();
            ch1 = this;
        }
        public static Chiose ch1;
        int chioseTimes = 0;
        string[] proType;
        public string proYear = "";
        private void mybutton1_Click(object sender, EventArgs e)
        {
            moveButtom(mybutton1, 1, mybutton2, 1 - chioseTimes);
            if (chioseTimes==0)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
           else if (chioseTimes == 1) 
            {
                panel1.Visible = false ;
                panel2.Visible = true ;
                panel3.Visible = false;
            }
            else 
            {
                panel1.Visible = false ;
                panel2.Visible = false;
                panel3.Visible = true ;
            }
        }

        private void mybutton2_Click(object sender, EventArgs e)
        {
            moveButtom(mybutton2, -1, mybutton1, chioseTimes);
            if (chioseTimes == 0)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
            else if (chioseTimes == 1)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
            }    
        }
        public void moveButtom(mybutton b1,int step, mybutton b2,int flage)
        {
            b2.Enabled = true;
            if (b1.Enabled == true)
            {
                chioseTimes+=step;
            }

            if (flage >0)
            {
                b1.Enabled = true;
            }
            else
                b1.Enabled = false;

            if (chioseTimes == 2)
                mybutton4.Visible = true;
            else
                mybutton4.Visible = false;
        }
        private void mybutton3_Click(object sender, EventArgs e)
        {
            if (File.Exists(Form2.f2.proPath))
                File.Delete(Form2.f2.proPath);
            this.Close();
            Form2.f2.Close();
        }

        private void mybutton4_Click(object sender, EventArgs e)
        {
            string[] type = { "C语言","C++","Java","Web开发","C#程序设计"};
            proType = new string[checkedListBox3.CheckedItems.Count];
            int i = 0;
            foreach (var item in checkedListBox3.CheckedItems)
            {
                for (int j = 0; j < type.Length; j++)
                {
                    if (item.ToString () == type[j])
                    {
                        proType[i] = (j+1).ToString();
                        break;
                    }
                }
                i++;
            }

            if (proYear == "" || proType.Length == 0)
            {
                MessageBox.Show("选择不完整！无法继续！");
            }
            else
            {
                string str = "选择题库是："+proYear ;
                string str1 = "选择的题目类型有：";
                i = 0;
                foreach (var item in checkedListBox3.CheckedItems)
                {
                    str1 += "[" + item + "] "; i++;
                }
               
                int proLength = 0;

                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(),"题库", proYear.Trim());

                Form2.f2.readProNum(@path,ref proLength);

                string []temp = new string[10];
                Dictionary<int, string[]> arr = new Dictionary<int,string[]> { };
                int location = 0;
                int times = 0;
                for (; times < proType.Length; times++)
                {
                    Form2.f2.readProMessage(@path, proLength, 1, ref arr, proType[times],ref location);
                }
                Form2.f2.readProMessage(@path, proLength, 1, ref arr,ref location);

                Form2.f2.add_row(@"我的题库.xls",arr, arr.Count, 10);
                
                if (MessageBox.Show("\t"+str+"！\n\t"+str1,
                                    "配 置 完 成", 
                                    MessageBoxButtons.OKCancel, 
                                    MessageBoxIcon.Information) == DialogResult.OK)
                {

                    this.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Chiose_Load(object sender, EventArgs e)
        {
            checkedListBox2.SetItemChecked(0, true);
            show();
            getFileName();
        }
        public void show()
        {
            panel1.Size = panel2.Size;
            panel3.Size = panel2.Size;
             panel1.Location = new Point(this.Width / 2 - panel1.Width / 2, this.Height / 2 - panel1.Height / 2);
            panel2.Location = new Point(this.Width / 2 - panel2.Width / 2, this.Height / 2 - panel2.Height / 2);
            panel3.Location = new Point(this.Width / 2 - panel3.Width / 2, this.Height / 2 - panel3.Height / 2);
        }

        
        public void getFileName()
        {
            int i = 0;
            var files = Directory.GetFiles(@"题库", "*.xls");
            checkedListBox2.Items.Clear();

            string[] fileName = new string[files.Length];
            foreach (var item in files)
            {
                fileName[i]=item.ToString();
                fileName[i] = fileName[i].Substring(3, fileName[i].Length-3);
                i++;
            }
            checkedListBox2.Items.AddRange(fileName);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void checkedListBox2_Click(object sender, EventArgs e)
        {
            int index = checkedListBox2.SelectedIndex;
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.Items.IndexOf(i) != index)
                    checkedListBox2.SetItemChecked(i, false);
                else
                    checkedListBox2.SetItemChecked(i, true);
            }
            proYear = checkedListBox2.SelectedItem.ToString().Trim();
        }

        private void checkedListBox2_DoubleClick(object sender, EventArgs e)
        {}
    }
}
