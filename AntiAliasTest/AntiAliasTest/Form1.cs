using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static int y;

        public Form1()
        {
            InitializeComponent();
            y = 150;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Color.White;
            Pen pen = new Pen(Color.Black, 40);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.DrawLine(pen, 10, 10, 200, y);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, 210, 10, 400, y);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            y = trackBar1.Value;
            Invalidate();
        }
    }
}
