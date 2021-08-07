using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 快眼刷题
{
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
        }

        private void Wait_Load(object sender, EventArgs e)
        {
            this.Location=new Point((Form1.f1.Width-this.Width)/2+Form1.f1.Left,(Form1.f1.Height-this.Height)/2+Form1.f1.Top);
            x1.Location = new Point((this.Width-x1.Width)/2,(this.Height-x1.Height)/2);
            x2.Location = x1.Location;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            star += moveStep;
            move(star);
            if(star>=end)
            {
                x1.Visible = false;
                x2.Visible = false;
                this.Opacity = 0;
                timer1.Stop();
                
                Form1.f1.doSome(Form1.f1.Keys);
                this.Close();
            }
        }
        public double moveStep = 0.1;
        public double star = 0.00;
        public double end = 200.00;
        private void move(double step)
        {
            int x1X = (this.Width - x1.Width) / 2 + Convert.ToInt32(30 * Math.Sin(step));//+3*pi/4
            int x1Y = (this.Height - x1.Height) / 2;// - Convert.ToInt32(50 * Math.Cos(step));
            int x2X = (this.Width - x2.Width) / 2 - Convert.ToInt32(30 * Math.Sin(step));

            x1.Location = new Point(x1X, x1Y);
            x2.Location = new Point(x2X, x1Y);
            

            if (x1.Location.X == x2.Location.X)
            {
                Color c = x1.NormalColor;
                x1.NormalColor = x2.NormalColor;
                x2.NormalColor = c;
            }
        }
    }
}
