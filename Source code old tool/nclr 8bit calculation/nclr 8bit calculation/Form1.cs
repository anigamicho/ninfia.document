using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nclr_8bit_calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int red,green,blue;

            red = int.Parse(textBox1.Text);
            green = int.Parse(textBox2.Text);
            blue = int.Parse(textBox3.Text);

            if(red % 8 != 0){
                red = red - (red % 8);
            }
            if (green % 8 != 0)
            {
                green = green - (green % 8);
            }
            if (blue % 8 != 0)
            {
                blue = blue - (blue % 8);
            }

            textBox15.Text = ""+red; //red
            textBox14.Text = ""+green; //green
            textBox13.Text = ""+blue; //blue0

            textBox4.Text = "" + blue;//blue
            textBox9.Text = "" + green; //green
            textBox12.Text = "" + red;//red

            panel2.BackColor = Color.FromArgb(255, red, green, blue);

            blue = blue / 8;
            red = red / 8;
            green = green / 8;

            
                //Color.FromArgb(255,red,green,blue);
            

            textBox5.Text = "" + (blue);//blue
            textBox8.Text = "" + (green); //green
            textBox11.Text = "" + (red);//red

            //blue
                int rem = 0;
                int num = int.Parse(textBox5.Text);
                string resultblue = string.Empty;
                while (num > 0)
                {
                    rem = num % 2;
                    num = num / 2;
                    resultblue = rem.ToString() + resultblue;
                }

                int countblue = resultblue.Length;

                if (countblue == 1)
                {
                    resultblue = "0000" + resultblue;
                }
                else if (countblue == 2)
                {
                    resultblue = "000" + resultblue;
                }
                else if (countblue == 3)
                {
                    resultblue = "00" + resultblue;
                }
                else if (countblue == 4)
                {
                    resultblue = "0" + resultblue;
                }
                else if (countblue == 0)
                {
                    resultblue = "00000" + resultblue;
                }

                textBox6.Text = "" + (resultblue);

           //green
                rem = 0;
                num = int.Parse(textBox8.Text);
                string resultgreen = string.Empty;
                while (num > 0)
                {
                    rem = num % 2;
                    num = num / 2;
                    resultgreen = rem.ToString() + resultgreen;
                }

                int countgreen = resultgreen.Length;

                if (countgreen == 1)
                {
                    resultgreen = "0000" + resultgreen;
                }
                else if (countgreen == 2)
                {
                    resultgreen = "000" + resultgreen;
                }
                else if (countgreen == 3)
                {
                    resultgreen = "00" + resultgreen;
                }
                else if (countgreen == 4)
                {
                    resultgreen = "0" + resultgreen;
                }
                else if (countgreen == 0)
                {
                    resultgreen = "00000" + resultgreen;
                }

                textBox7.Text = "" + (resultgreen);

            //red
                rem = 0;
                num = int.Parse(textBox11.Text);
                string resultred= string.Empty;
                while (num > 0)
                {
                    rem = num % 2;
                    num = num / 2;
                    resultred = rem.ToString() + resultred;
                }

                int countred = resultred.Length;

                if (countred == 1)
                {
                    resultred = "0000" + resultred;
                }
                else if (countred == 2)
                {
                    resultred = "000" + resultred;
                }
                else if (countred == 3)
                {
                    resultred = "00" + resultred;
                }
                else if (countred == 4)
                {
                    resultred = "0" + resultred;
                }
                else if (countred == 0)
                {
                    resultred = "00000" + resultred;
                }

                textBox10.Text = "" + (resultred);

         string resultall = string.Empty;

         resultall = "0"+ resultblue + resultgreen + resultred;

         textBox18.Text = "" + (resultall);

         string finalresult = String.Format("{0:X2}",Convert.ToInt32(resultall, 2));

         textBox16.Text = "" + (finalresult);
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a;
            a = int.Parse(listBox1.Text);

            if (a > 255)
            {
                MessageBox.Show("angkanya lebih dari 255");
            }
            else
            {
                textBox17.Text = listBox1.Text + "";

                int rem = 0;
                int num = int.Parse(listBox1.Text);
                string resultblue = string.Empty;
                while (num > 0)
                {
                    rem = num % 2;
                    num = num / 2;
                    resultblue = rem.ToString() + resultblue;
                }

                int countblue = resultblue.Length;
                string bx = "";
                int jum = 8 - countblue;

                for (int i = 1; i <= jum; i++)
                {
                    bx = bx + "0";
                }

                label19.Text = bx + resultblue + "";

                char[] array = (bx + resultblue).ToCharArray();

                if (array[0].ToString() == "1")
                {
                    checkBox8.Checked = true;
                }
                else
                {
                    checkBox8.Checked = false;
                }
                if (array[1].ToString() == "1")
                {
                    checkBox7.Checked = true;
                }
                else
                {
                    checkBox7.Checked = false;
                }

                if (array[2].ToString() == "1")
                {
                    checkBox6.Checked = true;
                }
                else
                {
                    checkBox6.Checked = false;
                }

                if (array[3].ToString() == "1")
                {
                    checkBox5.Checked = true;
                }
                else
                {
                    checkBox5.Checked = false;
                }
                if (array[4].ToString() == "1")
                {
                    checkBox4.Checked = true;
                }
                else
                {
                    checkBox4.Checked = false;
                }
                if (array[5].ToString() == "1")
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
                if (array[6].ToString() == "1")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }

                if (array[7].ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;

            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = colorDlg.Color.R + "";
                textBox2.Text = colorDlg.Color.G + "";
                textBox3.Text = colorDlg.Color.B + "";
                panel1.BackColor = colorDlg.Color;
            }
        }

    }
}
