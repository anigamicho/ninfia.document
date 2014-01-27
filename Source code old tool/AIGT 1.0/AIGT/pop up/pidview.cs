using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIGT.pop_up
{
    public partial class pidview : Form
    {
        public int nature;
        public int gender;
        public int ability;
        public pidview(Form1 ownerForm)
        {
            InitializeComponent();
            comboBox1.DataSource = (ArrayList)Program.pntl.GetArrayList().Clone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nature = int.Parse(this.textBox1.Text.Substring(this.textBox1.Text.Length - 2));

            if (nature > 24)
            {
                nature = nature % 25;
            }

            this.comboBox1.SelectedValue = nature;

            string hexgender;

            hexgender = (int.Parse(textBox1.Text).ToString("X")).Substring(this.textBox1.Text.Length - 2);

            gender = int.Parse(hexgender, System.Globalization.NumberStyles.HexNumber);
            textBox2.Text = gender.ToString();

            string binary = (Convert.ToString(int.Parse(this.textBox1.Text), 2)).Substring((Convert.ToString(int.Parse(this.textBox1.Text), 2)).Length - 1);

            if (binary == "1")
            {
                ability = 2;
            }
            else
            {
                ability = 1;
            }

            this.textBox3.Text = ability.ToString();
        }
    }
}
