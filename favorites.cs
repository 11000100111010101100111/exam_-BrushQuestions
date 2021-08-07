using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static 快眼刷题.Form1;

namespace 快眼刷题
{
    public partial class favorites : Form
    {
        public favorites()
        {
            InitializeComponent();
        }

        string[] cell;
        public  string name = "收藏夹";
        public string path = @"收藏夹.xls";

        private void readmypro()
        {
            listBox1.Items.Clear();
            int num = 0;
            Form1.f1.readProNum(path, ref num);
            if (num > 0)
            {
                cell = new string[num];
                //label1.Text = "个人" + name;
                //获取收藏的题目存放在listBox中
                Form1.f1.readAPro(path, ref cell, 2, num);
                string ch;
                for (int i = 0; i < num; i++)
                {
                    if (((i + 1).ToString() + "、" + cell[i]).Length > 16)
                        ch = ((i + 1).ToString() + "、" + cell[i]).Substring(0, 15) + "...";
                    else
                        ch = (i + 1).ToString() + "、" + cell[i];
                    listBox1.Items.Add(ch);
                }
                label10.Text = listBox1.Items.Count.ToString();
            }
            else
            {
                listBox1.Items.Add("无信息");
                listBox1.Enabled = false;
                panel6.Visible = true;
                label10.Text = "0";
            }
            label13.Left = label10.Right;
            label11.Text = (listBox1.SelectedIndex + 1).ToString();
            label11.Left = label12.Right;
            label14.Left = label11.Right;
            label10.Left = label9.Right;
            label13.Left = label10.Right;

        }
        private void favorites_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(255, 99, 71);
            if (name.Equals("收藏夹") == true)
                my_pro = new string[10];
            else
                my_pro = new string[11];
            label5.ForeColor = Color.Blue;
            label6.ForeColor = Color.Blue ;
            label10.Left = label9.Right;
            panel6.Location = new System.Drawing.Point(panel3.Width / 2 + panel2.Width - panel6.Width / 2, panel3.Height / 2 + panel1.Height - panel6.Height / 2);
            listBox1.Items.Clear();
            readmypro();

            int myW = panel3.Width - label2.Right - 80;

            Bt[0] = new mybutton();
            Color[] color ={Color.White ,Color.Red,Color.Red,Color.FromArgb(255, 127, 80)};
            createmyBt(
                Bt[0] ,
                panel1,
                new System.Drawing.Size(2*panel1.Height-20 , panel1.Height-20),
                new System.Drawing.Point(panel1.Width -Bt[0].Width-30,10 ),
                color,
                "退  出");
            Bt[0].ControlState = ControlState.Normal;
            Bt[0].Click += ExtnBt_Click;

            Bt[1] = new mybutton();
            color[0] = Color.Black ;color[1] = Color.White ;
            color[2] = Color.FromArgb(0 ,206, 209);color[3]= Color.FromArgb(132, 112, 255);
            createmyBt(
                Bt[1],
                panel3,
                new System.Drawing.Size(myW, (panel3.Height-radioButton4.Bottom-3 )/3),
                new System.Drawing.Point(label2.Right+60, radioButton4.Bottom+1),
                color,
                "上一题");
            Bt[1].ControlState = ControlState.Normal;
            Bt[1].Click += AgoBt_Click;

            Bt[2] = new mybutton();
            createmyBt(
                Bt[2],
                panel3,
                new System.Drawing.Size(myW, (panel3.Height - radioButton4.Bottom -3) / 3),
                new System.Drawing.Point(label2.Right + 60, radioButton4.Bottom + 1+ Bt[1].Height ),
                color,
                "下一题");
            Bt[2].ControlState = ControlState.Normal;
            Bt[2].Click += NextBt_Click; ;

            Bt[3] = new mybutton();
            color[0] = Color.White; color[1] = Color.Red;
            color[2] = Color.Red; color[3] = Color.FromArgb(0 ,255 ,127);
            createmyBt(
                Bt[3],
                panel3,
                new System.Drawing.Size(myW, (panel3.Height - radioButton4.Bottom -3) / 3),
                new System.Drawing.Point(label2.Right + 60, radioButton4.Bottom + 1 + Bt[2].Height+Bt[1].Height),
                color,
                "删除此题");
            Bt[3].ControlState = ControlState.Normal;
            Bt[3].Click += DeleteOneBt_Click; ;

            Bt[4] = new mybutton();
            createmyBt(
                Bt[4],
                panel2,
                new System.Drawing.Size(panel2.Width-40 , panel2.Height-listBox1.Bottom-20),
                new System.Drawing.Point(20,listBox1.Bottom  + 10),
                color,
                "全部清空");
            Bt[4].ControlState = ControlState.Normal;
            Bt[4].Click += DeleteAllBt_Click; ;
        }
        mybutton []Bt =new mybutton[5];
        //mybutton AgoBt;
        //mybutton NextBt;
        //mybutton DeleteOneBt;
        //mybutton deleteAllBt;
        void read(object vioceTxt)
        {
            Form1.f1.sp.Speak(vioceTxt);
        }
        Thread th;
        private void DeleteAllBt_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 1 && listBox1.Items.IndexOf("无信息") == 0)
            {
                th = new Thread(read);
                th.Start("没有可以清楚的题目了！");
                //System.Windows.Forms.MessageBox.Show("没有可以清楚的题目了！");
            }
            else
            {
                if (System.Windows.Forms.MessageBox.Show("确定移除【全部】记录？", "    谨慎操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox1.Items.Clear();
                    //在表中也相应移除全部
                    Form1.f1.add_row(path, aftre_remove, listBox1.Items.Count, 10);
                    label10.Text = listBox1.Items.Count.ToString();
                    label13.Left = label10.Right;
                    if (File.Exists(path))
                        File.Delete(path);

                    listBox1.Items.Add("无信息");
                    listBox1.Enabled = false;
                    panel6.Visible = true;
                    clear();
                    panel3.Visible = false;
                }
            }
        }

        private void DeleteOneBt_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (System.Windows.Forms.MessageBox.Show("确定移除此记录？", "    移除警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //在表中也相应移除此项
                    int selectItem = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(Convert.ToInt32(label11.Text) - 1);
                    string[,] item;
                    if (name.Equals("收藏夹") == true)
                    {
                        aftre_remove = new string[listBox1.Items.Count, 10];
                        item = new string[listBox1.Items.Count + 1, 10];
                    }
                    else
                    {
                        aftre_remove = new string[listBox1.Items.Count, 11];
                        item = new string[listBox1.Items.Count + 1, 11];
                    }

                    Form1.f1.readAPro(path, ref item, listBox1.Items.Count + 1, item.Length / (listBox1.Items.Count + 1));

                    for (int i = 0, k = 0; i < listBox1.Items.Count + 1; i++)
                    {
                        if (i != selectItem)
                        {
                            for (int j = 0; j < item.Length / (listBox1.Items.Count + 1); j++)
                                aftre_remove[k, j] = item[i, j];
                            k++;

                        }
                    }
                    if (listBox1.Items.Count > 0)
                        Form1.f1.add_row(path, aftre_remove, listBox1.Items.Count, aftre_remove.Length / listBox1.Items.Count);
                    else
                        Form1.f1.add_row(path, aftre_remove, listBox1.Items.Count, 0);
                    if (listBox1.Items.Count <= 0)
                    {
                        if (File.Exists(path))
                            File.Delete(path);
                    }
                    clear();
                    panel3.Visible = false;
                    label10.Text = listBox1.Items.Count.ToString();
                    label13.Left = label10.Right;
                    if (listBox1.Items.Count <= 0)
                    {
                        listBox1.Items.Add("无信息");
                        listBox1.Enabled = false;
                        panel6.Visible = true;
                    }
                    System.Windows.Forms.MessageBox.Show("移除成功！");

                    readmypro();
                }
            }
        }

        private void NextBt_Click(object sender, EventArgs e)


        {
            if (listBox1.Items.Count > 1)
                Bt[1].Enabled = true;
            //panel3.Visible = false;
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                listBox1.SelectedIndex += 1;
            if (listBox1.SelectedIndex > listBox1.Items.Count - 2)
                Bt[2].Enabled = false;
            else
                Bt[2].Enabled = true;
            listBox1_SelectedIndexChanged(sender, e);
        }

        private void AgoBt_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 1)
                Bt[2].Enabled = true;
            //panel3.Visible = false;
            if (listBox1.SelectedIndex > 0)
                listBox1.SelectedIndex -= 1;
            if (listBox1.SelectedIndex < 1)
                Bt[1].Enabled = false;
            else
                Bt[1].Enabled = true;
            listBox1_SelectedIndexChanged(sender, e);
        }

        private void createmyBt(mybutton Bt,Control con, System.Drawing.Size s, System.Drawing.Point p,Color []c,string str)
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
            Bt.ControlState = ControlState.Normal;
            //Bt.Click += Bt_Click;
        }

        private void ExtnBt_Click(object sender, EventArgs e)
        {
            Form1.f1.button3.Enabled = true;
            Form1.f1.button4.Enabled = true;
            this.Dispose();
            this.Close();
            Form1.f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void clear()
        {
            foreach (Control ri in panel3.Controls)
            {
                if (ri is RadioButton)
                {
                    if (ri.BackColor != Color.White)
                        ri.BackColor = Color.White;
                }    
            }

        }
        string[] my_pro;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearContral();
            if (listBox1.SelectedIndex >= 0)
            {
                panel3.Visible = true;
                label11.Text = (listBox1.SelectedIndex + 1).ToString();
                label14.Left = label11.Right;
                if (listBox1.Items.Count <= 1)
                {
                    Bt[1].Enabled = false;
                    Bt[2].Enabled = false;
                }
                Form1.f1.readAPro(listBox1.SelectedIndex+1, path, ref my_pro,my_pro.Length);
                
                if (name == "错题本")
                {
                    label2.Visible = true;
                    //MessageBox.Show(my_pro[10]);
                    foreach (Control ri in panel3.Controls)
                    {
                        if (ri is RadioButton)
                        {
                            if (ri.Text.Trim().Substring(0, 1) == my_pro[10])
                                ri.BackColor  = Color.FromArgb(238, 0, 0);
                        }
                    }
                }
                setContral_value();
            }  
        }
        public void clearContral()
        {
            label2.Visible = false;
            foreach (Control ri in panel3.Controls)
            {
                if (ri is RadioButton)
                {
                    ri.BackColor = Color.FromArgb(250, 250, 250);
                }
            }
        }
        public void setContral_value()
        {
            foreach (KeyValuePair <string,string> item in Form1.f1.proTypes)
            {

                if(my_pro[1]==item.Key)
                {
                    my_pro[1] = item.Value;
                    break;
                }
            }
            textBox1.Text="@_题型："+my_pro[1]+"\r\n   " + cell[listBox1.SelectedIndex];
            radioButton1.Text = "A、" + my_pro[3];
            radioButton2.Text = "B、" + my_pro[4];
            radioButton3.Text = "C、" + my_pro[5];
            radioButton4.Text = "D、" + my_pro[6];
            label5.Text = my_pro[7];
            label6.Text = my_pro[8] + "颗星";
            label14.Left = label11.Right;
            
            foreach (Control  ri in panel3.Controls)
            {
                if (ri is RadioButton)
                {
                    if (ri.Text.Trim().Substring(0, 1) == label5.Text.Trim())
                        ri.BackColor = Color.FromArgb(248, 248, 255);
                    //else
                    //{
                    //    if(ri.BackColor != Color.FromArgb(238, 0, 0))
                    //         ri.BackColor = Color.FromArgb(250, 250, 250);
                    //}
                }
            }
        }
        string[,] aftre_remove;
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        System.Drawing.Point p;
        //bool t = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new System.Drawing.Point(e.Location.X,e.Location.Y );
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left )
            {
                this.Location = new System.Drawing.Point(this.Location.X+e.X -p.X ,this.Location.Y+e.Y-p.Y);
            }
        }

        private void favorites_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.Abort();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class mybutton : RoundButton
    {
        private Color enterForeColor = Color.White;
        private Color leftForeColor = Color.Black;
        private int multiples = 10;
        private float textSize = 14f;
        private float TextSize
        {
            get { return textSize; }
            set
            {
                if (this.Font.Size == 9)
                {
                    textSize = 14;
                }
                else
                    textSize = this.Font.Size;
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
            if (this.multiples > 0)
            {
                this.Left -= this.Width / (2 * Multiples);
                this.Width += this.Width / Multiples;
            }
            else
            {
                this.Left -= 10;
                this.Width += 20;
                this.Top -= 10;
                this.Height +=20;
            }
        }
        protected override void OnMouseLeave(EventArgs e)//鼠标离开
        {
            base.OnMouseLeave(e);
            ControlState = ControlState.Normal;//正常
            this.ForeColor = this.LeftForeColor;
            if (this.multiples > 0)
            {
                this.Width -= this.Width / (Multiples + 1);
                this.Left += this.Width / (2 * Multiples);
            }
            else
            {
                this.Left += 10;
                this.Width -= 20;
                this.Top += 10;
                this.Height -= 20;
            }
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
                System.Drawing.Font fo = new System.Drawing.Font(this.Font.Name,this.textSize);
                Brush brush = new SolidBrush(this.ForeColor);
                Pen penn = new Pen(brush, 3);
                StringFormat gs = new StringFormat();
                gs.Alignment = StringAlignment.Center; //居中
                gs.LineAlignment = StringAlignment.Center;//垂直居中
                e.Graphics.TextRenderingHint=System.Drawing.Text.TextRenderingHint.ClearTypeGridFit  ;
                e.Graphics.DrawString(this.Text, fo,brush, rect, gs);
                
                //e.Graphics.DrawPath(p, path);
            }

        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            //int diameter;
            //Point lo = new Point(rect.Location.X + 10, rect.Location.Y + 10);
            Rectangle arcRect = new Rectangle(rect.Location, new System.Drawing.Size(this.Height , this.Height ));
            GraphicsPath path = new GraphicsPath();
            //Pen pp = new Pen(Color.White, 1);
            path.AddArc(arcRect ,90,180);
            arcRect = new Rectangle(new System.Drawing.Point(this.Width-this.Height ,0), new System.Drawing.Size(this.Height, this.Height));
            path.AddArc(arcRect, 270, 180);
            //
            //path.Widen(pp);
            path.CloseFigure();
            return path;
        }
    }
}
