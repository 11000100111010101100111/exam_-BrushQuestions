namespace 快眼刷题
{
    partial class Wait
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wait));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.x1 = new 快眼刷题.RoundButton();
            this.x2 = new 快眼刷题.RoundButton();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // x1
            // 
            this.x1.ControlState = 快眼刷题.ControlState.Normal;
            this.x1.FlatAppearance.BorderSize = 0;
            this.x1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1.ForeColor = System.Drawing.Color.White;
            this.x1.HoverColor = System.Drawing.Color.Blue;
            this.x1.Location = new System.Drawing.Point(62, 109);
            this.x1.Name = "x1";
            this.x1.NormalColor = System.Drawing.Color.Blue;
            this.x1.PressedColor = System.Drawing.Color.Blue;
            this.x1.Radius = 34;
            this.x1.Size = new System.Drawing.Size(34, 34);
            this.x1.TabIndex = 1;
            this.x1.UseVisualStyleBackColor = true;
            // 
            // x2
            // 
            this.x2.ControlState = 快眼刷题.ControlState.Normal;
            this.x2.FlatAppearance.BorderSize = 0;
            this.x2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2.ForeColor = System.Drawing.Color.White;
            this.x2.HoverColor = System.Drawing.Color.Red;
            this.x2.Location = new System.Drawing.Point(131, 109);
            this.x2.Name = "x2";
            this.x2.NormalColor = System.Drawing.Color.Red;
            this.x2.PressedColor = System.Drawing.Color.Red;
            this.x2.Radius = 34;
            this.x2.Size = new System.Drawing.Size(34, 34);
            this.x2.TabIndex = 0;
            this.x2.UseVisualStyleBackColor = true;
            // 
            // Wait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.ControlBox = false;
            this.Controls.Add(this.x1);
            this.Controls.Add(this.x2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Wait";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wait";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Wait_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private RoundButton x2;
        private RoundButton x1;
        public System.Windows.Forms.Timer timer1;
    }
}