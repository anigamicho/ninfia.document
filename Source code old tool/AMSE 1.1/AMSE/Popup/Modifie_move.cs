using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMSE;

namespace AMSE
{
    public partial class Add : Form
    {
        public int Row;
        Form1 ownerForm = null;

        public Add(Form1 ownerForm)
        {
            InitializeComponent();
            comboBox1.DataSource = (ArrayList)Program.PokeabwmoveList.GetArrayList().Clone();
            this.ownerForm = ownerForm;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.ControlBox = false;
            this.Icon = global::AMSE.Properties.Resources.amse_icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int y, z, row;
            string x;

            Form1 f2 = new Form1();
            //(Form1)this.ParentForm
            row = Row;
            x = this.comboBox1.Text;
            y = (int)this.numericUpDown1.Value;
            z = (int)this.numericUpDown2.Value;

            f2.Tabel1[1, row].Value = x;
            f2.Tabel1[2, row].Value = y;
            f2.Tabel1[3, row].Value = z;

            this.ownerForm.tablevalue(x,y,z,row);
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "ID Move : " + Program.PokeabwmoveList.SearchByName((string)this.comboBox1.Text) + " (" + Program.PokeabwmoveList.SearchByName((string)this.comboBox1.Text).ToString("X") + ")";
        }

    }
}
