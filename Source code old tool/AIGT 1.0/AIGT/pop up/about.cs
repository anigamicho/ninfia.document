using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIGT.pop_up
{
    public partial class about : Form
    {
        private bool drag;
        private Point start_point;

        public about(Form1 ownerForm)
        {
            InitializeComponent();
            this.TransparencyKey = Color.PapayaWhip;
            this.BackColor = Color.PapayaWhip;
            base.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            base.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            base.MouseMove += new MouseEventHandler(this.Form_MouseMove);

            this.BackgroundImage = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("formbg");
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X, e.Y);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p = new Point(e.X, e.Y);
                Point point2 = base.PointToScreen(p);
                Point point3 = new Point(point2.X - this.start_point.X, point2.Y - this.start_point.Y);
                base.Location = point3;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
