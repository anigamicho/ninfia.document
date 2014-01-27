
using Percobaan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AHGE;

namespace AHGE.Popup
{
    public partial class Batch : Form
    {
        Form1 ownerForm = null;
        public Batch(Form1 ownerForm)
        {
            InitializeComponent();
            comboBox1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Name";

            comboBox1.SelectedIndex = 1;

            this.Icon = global::aleafia_resicon.Properties.Resources.icons;

            this.ownerForm = ownerForm;
            //this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = checkBox3.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox2.Checked;
            numericUpDown2.Enabled = checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pokecheck = "", levelcheck = "", feratecheck = "";
            int w21 = 0,w22 = 0,w23 = 0,b21 = 0,b22 = 0,b23 = 0;
            int pkm = 0, lvmin = 0,lvmax = 0 , frate = 0, forme = 0;

            if (checkBox1.Checked)
            {
                pokecheck = "y";

                pkm = (int)this.comboBox1.SelectedValue;
                forme = (int)this.comboBox2.SelectedIndex;
            }

            if (checkBox2.Checked)
            {
                levelcheck = "y";

                lvmin = (int)numericUpDown1.Value;
                lvmax = (int)numericUpDown2.Value;
            }

            if (checkBox3.Checked)
            {
                feratecheck = "y";

                frate = (int)numericUpDown3.Value;
            }

            if (w2a.Checked){
                w21 = 1;
            }
            if (w2b.Checked){
                w22 = 1;
            }
            if (w2c.Checked){
                w23 = 1;
            }
            if (b2a.Checked){
                b21 = 1;
            }
            if (b2b.Checked){
                b22 = 1;
            }
            if (b2c.Checked){
                b23 = 1;
            }

            this.ownerForm.batchvalue(pokecheck, levelcheck, feratecheck, w21, w22, w23, b21, b22, b23, pkm, lvmin, lvmax, frate, forme);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {

                if (numericUpDown2.Value == numericUpDown1.Value)
                {
                    numericUpDown2.Value = numericUpDown2.Value + 1;
                }

                if (numericUpDown2.Value < numericUpDown1.Value)
                {
                    numericUpDown2.Value = (numericUpDown2.Value + (numericUpDown1.Value - numericUpDown2.Value)) + 1;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != 0)
            {
                if (numericUpDown1.Value == numericUpDown2.Value)
                {
                    numericUpDown2.Value = numericUpDown2.Value - 1;
                }

                if (numericUpDown1.Value > numericUpDown2.Value)
                {
                    numericUpDown1.Value = (numericUpDown1.Value - (numericUpDown1.Value - numericUpDown2.Value)) - 1;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            switch ((int)this.comboBox1.SelectedValue)
            {
                case 172: //Pichu
                    comboBox2.Items.Add("Normal");

                    if ((int)this.comboBox1.SelectedValue < 1)
                    {
                        comboBox2.SelectedIndex = (int)this.comboBox1.SelectedValue;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    comboBox2.Items.Add("A");
                    comboBox2.Items.Add("B");
                    comboBox2.Items.Add("C");
                    comboBox2.Items.Add("D");
                    comboBox2.Items.Add("E");
                    comboBox2.Items.Add("F");
                    comboBox2.Items.Add("G");
                    comboBox2.Items.Add("H");
                    comboBox2.Items.Add("I");
                    comboBox2.Items.Add("J");
                    comboBox2.Items.Add("K");
                    comboBox2.Items.Add("L");
                    comboBox2.Items.Add("M");
                    comboBox2.Items.Add("N");
                    comboBox2.Items.Add("O");
                    comboBox2.Items.Add("P");
                    comboBox2.Items.Add("Q");
                    comboBox2.Items.Add("R");
                    comboBox2.Items.Add("S");
                    comboBox2.Items.Add("T");
                    comboBox2.Items.Add("U");
                    comboBox2.Items.Add("V");
                    comboBox2.Items.Add("W");
                    comboBox2.Items.Add("X");
                    comboBox2.Items.Add("Y");
                    comboBox2.Items.Add("Z");
                    comboBox2.Items.Add("!");
                    comboBox2.Items.Add("?");

                    if ((int)this.comboBox1.SelectedValue < 28)
                    {
                        comboBox2.SelectedIndex = (int)this.comboBox1.SelectedValue;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    comboBox2.Items.Add("Normal");
                    comboBox2.Items.Add("Sunny Form");
                    comboBox2.Items.Add("Rainy Form");
                    comboBox2.Items.Add("Snowy Form");

                    if ((int)this.comboBox1.SelectedValue < 4)
                    {
                        comboBox2.SelectedIndex = (int)this.comboBox1.SelectedValue;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    comboBox2.Items.Add("Normal");
                    comboBox2.Items.Add("Attack");
                    comboBox2.Items.Add("Defense");
                    comboBox2.Items.Add("Speed");

                    if ((int)this.comboBox1.SelectedValue < 4)
                    {
                        comboBox2.SelectedIndex = (int)this.comboBox1.SelectedValue;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    comboBox2.Items.Add("Plant");
                    comboBox2.Items.Add("Sand");
                    comboBox2.Items.Add("Trash");

                    if ((int)this.comboBox1.SelectedValue < 3)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    comboBox2.Items.Add("Overcast Form");
                    comboBox2.Items.Add("Sunshine Form");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    comboBox2.Items.Add("West");
                    comboBox2.Items.Add("East");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = (int)this.comboBox1.SelectedValue;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    comboBox2.Items.Add("Normal");
                    comboBox2.Items.Add("Heat");
                    comboBox2.Items.Add("Wash");
                    comboBox2.Items.Add("Frost");
                    comboBox2.Items.Add("Spin");
                    comboBox2.Items.Add("Cut");

                    if ((int)this.comboBox1.SelectedValue < 6)
                    {
                        comboBox2.SelectedIndex = (int)this.comboBox1.SelectedValue;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    comboBox2.Items.Add("Altered");
                    comboBox2.Items.Add("Origin");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    comboBox2.Items.Add("Land");
                    comboBox2.Items.Add("Sky");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    comboBox2.Items.Add("Normal");
                    comboBox2.Items.Add("Fighting");
                    comboBox2.Items.Add("Flying");
                    comboBox2.Items.Add("Poison");
                    comboBox2.Items.Add("Ground");
                    comboBox2.Items.Add("Rock");
                    comboBox2.Items.Add("Bug");
                    comboBox2.Items.Add("Ghost");
                    comboBox2.Items.Add("Steel");
                    comboBox2.Items.Add("Fire");
                    comboBox2.Items.Add("Water");
                    comboBox2.Items.Add("Grass");
                    comboBox2.Items.Add("Electric");
                    comboBox2.Items.Add("Psychic");
                    comboBox2.Items.Add("Ice");
                    comboBox2.Items.Add("Dragon");
                    comboBox2.Items.Add("Dark");

                    if ((int)this.comboBox1.SelectedValue < 18)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    comboBox2.Items.Add("Red-Striped");
                    comboBox2.Items.Add("Blue-Striped");
                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    comboBox2.Items.Add("Normal");
                    comboBox2.Items.Add("Zen mode");
                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    comboBox2.Items.Add("Spring Form");
                    comboBox2.Items.Add("Summer Form");
                    comboBox2.Items.Add("Autumn Form");
                    comboBox2.Items.Add("Winter Form");

                    if ((int)this.comboBox1.SelectedValue < 4)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    comboBox2.Items.Add("Incarnate Forme");
                    comboBox2.Items.Add("Therian Forme");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    comboBox2.Items.Add("Kyurem");
                    comboBox2.Items.Add("White Kyurem");
                    comboBox2.Items.Add("Black Kyurem");

                    if ((int)this.comboBox1.SelectedValue < 3)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    comboBox2.Items.Add("Ordinary Form");
                    comboBox2.Items.Add("Resolute Form");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    comboBox2.Items.Add("Aria Forme");
                    comboBox2.Items.Add("Pirouette Forme");

                    if ((int)this.comboBox1.SelectedValue < 2)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    comboBox2.Items.Add("Normal");
                    comboBox2.Items.Add("1");
                    comboBox2.Items.Add("2");
                    comboBox2.Items.Add("3");
                    comboBox2.Items.Add("4");

                    if ((int)this.comboBox1.SelectedValue < 5)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }

                    break;

                default:
                    comboBox2.Items.Add("Normal");

                    if ((int)this.comboBox1.SelectedValue < 1)
                    {
                        comboBox2.SelectedIndex = ((int)this.comboBox1.SelectedValue);
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                    break;

            }
        }


        
    }
}
