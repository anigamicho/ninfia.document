using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIGT.pop_up
{
    public partial class source : Form
    {
        private bool drag;
        private Point start_point;
        private bool sizse = false;

        public source(Form1 ownerForm)
        {
            InitializeComponent();
            glassPane1.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            glassPane1.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            glassPane1.MouseMove += new MouseEventHandler(this.Form_MouseMove);
            textBox1.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            textBox1.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            textBox1.MouseMove += new MouseEventHandler(this.Form_MouseMove);

            menuStrip1.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            menuStrip1.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            menuStrip1.MouseMove += new MouseEventHandler(this.Form_MouseMove);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X + 20, e.Y + 60);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p = new Point(e.X + 10, e.Y + 30);
                Point point2 = base.PointToScreen(p);
                Point point3 = new Point(point2.X - this.start_point.X, point2.Y - this.start_point.Y);
                base.Location = point3;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void saveAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filestrng;

            filestrng = textBox1.Text;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save File";
            dialog.Filter = "Text File|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, filestrng);
                MessageBox.Show("Data was saved !");
            }
            else
            {
                MessageBox.Show("Data was not saved !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sizse == false)
            {
                this.ClientSize = new System.Drawing.Size(489, 459);
                sizse = true;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(489, 268);
                sizse = false;
            }

            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                textBox1.Text = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
            else
                textBox1.Text = "The clipboad does not contain any text";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text, true);
        }
    }
}
