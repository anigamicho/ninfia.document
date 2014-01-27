using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using AHGE;

namespace Percobaan
{
    public partial class Form1 : Form
    {
        public MemoryStream NarcFile = new MemoryStream();
        public MemoryStream MapFile = new MemoryStream();
        public uint FileCount;
        public uint FileOffset;
        public uint FileSize;
        public uint FATOffset;
        public uint Pokemon1;
        public uint Pokemon2;
        public uint Pokemon3;
        public uint Pokemon4;
        public uint Max1;
        public uint Max2;
        public uint Max3;
        public uint Max4;
        public uint Min1;
        public uint Min2;
        public uint Min3;
        public uint Min4;
        public uint frate1;
        public uint frate2;
        public uint frate3;
        public uint frate4;
        public uint unkw1;
        public uint unkw2;
        public uint unkw3;
        public uint unkw4;
        public uint unkw5;
        public uint unkw6;
        public uint item11;
        public int a;
        public string b;

        public Form1()
        {
            InitializeComponent();
            this.Icon = global::aleafia_resicon.Properties.Resources.icons;
            //string locations_bw2;
            this.comboBox1.SelectedIndex = 0;

            //locations_bw2 = @"data\icons_pkm\";

            //load list
            pl1_1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl1_2.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl1_3.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl1_4.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl2_4.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl2_1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl2_3.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl2_2.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl3_4.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl3_1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl3_3.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl3_2.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl4_1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl4_3.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl4_2.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl4_4.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl5_1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl5_3.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl5_2.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl5_4.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl6_1.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl6_3.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl6_2.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            pl6_4.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
            it_11.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_12.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_13.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_14.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_18.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_17.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_16.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_15.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_28.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_27.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_26.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_25.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_24.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_23.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_22.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_21.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_38.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_37.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_36.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_35.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_34.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_33.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_32.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_31.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_41.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_42.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_43.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_44.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_45.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_46.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_47.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            it_48.DataSource = (ArrayList)Program.ItemList.GetArrayList().Clone();
            id_name.DataSource = (ArrayList)Program.loc1List.GetArrayList().Clone();

            this.pl1_1.SelectedIndexChanged += new EventHandler(this.pl1_1_SelectedValueChanged);
            this.pl1_2.SelectedIndexChanged += new EventHandler(this.pl1_2_SelectedValueChanged);
            this.pl1_3.SelectedIndexChanged += new EventHandler(this.pl1_3_SelectedValueChanged);
            this.pl1_4.SelectedIndexChanged += new EventHandler(this.pl1_4_SelectedValueChanged);
            this.pl2_1.SelectedIndexChanged += new EventHandler(this.pl2_1_SelectedValueChanged);
            this.pl2_2.SelectedIndexChanged += new EventHandler(this.pl2_2_SelectedValueChanged);
            this.pl2_3.SelectedIndexChanged += new EventHandler(this.pl2_3_SelectedValueChanged);
            this.pl2_4.SelectedIndexChanged += new EventHandler(this.pl2_4_SelectedValueChanged);
            this.pl3_1.SelectedIndexChanged += new EventHandler(this.pl3_1_SelectedValueChanged);
            this.pl3_2.SelectedIndexChanged += new EventHandler(this.pl3_2_SelectedValueChanged);
            this.pl3_3.SelectedIndexChanged += new EventHandler(this.pl3_3_SelectedValueChanged);
            this.pl3_4.SelectedIndexChanged += new EventHandler(this.pl3_4_SelectedValueChanged);
            this.pl4_1.SelectedIndexChanged += new EventHandler(this.pl4_1_SelectedValueChanged);
            this.pl4_2.SelectedIndexChanged += new EventHandler(this.pl4_2_SelectedValueChanged);
            this.pl4_3.SelectedIndexChanged += new EventHandler(this.pl4_3_SelectedValueChanged);
            this.pl4_4.SelectedIndexChanged += new EventHandler(this.pl4_4_SelectedValueChanged);
            this.pl5_1.SelectedIndexChanged += new EventHandler(this.pl5_1_SelectedValueChanged);
            this.pl5_2.SelectedIndexChanged += new EventHandler(this.pl5_2_SelectedValueChanged);
            this.pl5_3.SelectedIndexChanged += new EventHandler(this.pl5_3_SelectedValueChanged);
            this.pl5_4.SelectedIndexChanged += new EventHandler(this.pl5_4_SelectedValueChanged);
            this.pl6_1.SelectedIndexChanged += new EventHandler(this.pl6_1_SelectedValueChanged);
            this.pl6_2.SelectedIndexChanged += new EventHandler(this.pl6_2_SelectedValueChanged);
            this.pl6_3.SelectedIndexChanged += new EventHandler(this.pl6_3_SelectedValueChanged);
            this.pl6_4.SelectedIndexChanged += new EventHandler(this.pl6_4_SelectedValueChanged);

            this.pbx_pl1_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl1_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl1_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl1_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl2_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl2_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl2_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl2_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl3_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl3_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl3_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");
            this.pbx_pl3_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_0");

            this.id_name.SelectedIndexChanged += new EventHandler(this.id_name_SelectedIndexChanged);
            this.id_list.SelectedIndexChanged += new EventHandler(this.id_list_SelectedIndexChanged);

            
            this.save.Click += new EventHandler(this.save_Click);

            
            //this.button2.Click += new EventHandler(this.button2_Click); 
        }

        public void batchvalue(string pokemoncheck, string levelcheck, string femaleratecheck, int w2a, int w2b, int w2c, int b2a, int b2b, int b2c, int pokemonval, int minlv, int maxlv, int femalerate, int forme)
        {
            if (pokemoncheck == "y")
            {
                if (w2a == 1)
                {
                    pl1_1.SelectedValue = pokemonval;
                    pl1_2.SelectedValue = pokemonval;
                    pl1_3.SelectedValue = pokemonval;
                    pl1_4.SelectedValue = pokemonval;
                    forme_1_1.SelectedIndex = forme;
                    forme_1_2.SelectedIndex = forme;
                    forme_1_3.SelectedIndex = forme;
                    forme_1_4.SelectedIndex = forme;
                }
                if (w2b == 1)
                {
                    pl2_1.SelectedValue = pokemonval;
                    pl2_2.SelectedValue = pokemonval;
                    pl2_3.SelectedValue = pokemonval;
                    pl2_4.SelectedValue = pokemonval;
                    forme_2_1.SelectedIndex = forme;
                    forme_2_2.SelectedIndex = forme;
                    forme_2_3.SelectedIndex = forme;
                    forme_2_4.SelectedIndex = forme;
                }
                if (w2c == 1)
                {
                    pl3_1.SelectedValue = pokemonval;
                    pl3_2.SelectedValue = pokemonval;
                    pl3_3.SelectedValue = pokemonval;
                    pl3_4.SelectedValue = pokemonval;
                    forme_3_1.SelectedIndex = forme;
                    forme_3_2.SelectedIndex = forme;
                    forme_3_3.SelectedIndex = forme;
                    forme_3_4.SelectedIndex = forme;
                }
                if (b2a == 1)
                {
                    pl4_1.SelectedValue = pokemonval;
                    pl4_2.SelectedValue = pokemonval;
                    pl4_3.SelectedValue = pokemonval;
                    pl4_4.SelectedValue = pokemonval;
                    forme_4_1.SelectedIndex = forme;
                    forme_4_2.SelectedIndex = forme;
                    forme_4_3.SelectedIndex = forme;
                    forme_4_4.SelectedIndex = forme;
                }
                if (b2b == 1)
                {
                    pl5_1.SelectedValue = pokemonval;
                    pl5_2.SelectedValue = pokemonval;
                    pl5_3.SelectedValue = pokemonval;
                    pl5_4.SelectedValue = pokemonval;
                    forme_5_1.SelectedIndex = forme;
                    forme_5_2.SelectedIndex = forme;
                    forme_5_3.SelectedIndex = forme;
                    forme_5_4.SelectedIndex = forme;
                }
                if (b2c == 1)
                {
                    pl6_1.SelectedValue = pokemonval;
                    pl6_2.SelectedValue = pokemonval;
                    pl6_3.SelectedValue = pokemonval;
                    pl6_4.SelectedValue = pokemonval;
                    forme_6_1.SelectedIndex = forme;
                    forme_6_2.SelectedIndex = forme;
                    forme_6_3.SelectedIndex = forme;
                    forme_6_4.SelectedIndex = forme;
                }
            }

            if (levelcheck == "y")
            {
                if (w2a == 1)
                {
                    mn1_1.Value = minlv;
                    mn1_2.Value = minlv;
                    mn1_3.Value = minlv;
                    mn1_4.Value = minlv;
                    mx1_1.Value = maxlv;
                    mx1_2.Value = maxlv;
                    mx1_3.Value = maxlv;
                    mx1_4.Value = maxlv;
                }
                if (w2b == 1)
                {
                    mn2_1.Value = minlv;
                    mn2_2.Value = minlv;
                    mn2_3.Value = minlv;
                    mn2_4.Value = minlv;
                    mx2_1.Value = maxlv;
                    mx2_2.Value = maxlv;
                    mx2_3.Value = maxlv;
                    mx2_4.Value = maxlv;
                }
                if (w2c == 1)
                {
                    mn3_1.Value = minlv;
                    mn3_2.Value = minlv;
                    mn3_3.Value = minlv;
                    mn3_4.Value = minlv;
                    mx3_1.Value = maxlv;
                    mx3_2.Value = maxlv;
                    mx3_3.Value = maxlv;
                    mx3_4.Value = maxlv;
                }
                if (b2a == 1)
                {
                    mn4_1.Value = minlv;
                    mn4_2.Value = minlv;
                    mn4_3.Value = minlv;
                    mn4_4.Value = minlv;
                    mx4_1.Value = maxlv;
                    mx4_2.Value = maxlv;
                    mx4_3.Value = maxlv;
                    mx4_4.Value = maxlv;
                }
                if (b2b == 1)
                {
                    mn5_1.Value = minlv;
                    mn5_2.Value = minlv;
                    mn5_3.Value = minlv;
                    mn5_4.Value = minlv;
                    mx5_1.Value = maxlv;
                    mx5_2.Value = maxlv;
                    mx5_3.Value = maxlv;
                    mx5_4.Value = maxlv;
                }
                if (b2c == 1)
                {
                    mn6_1.Value = minlv;
                    mn6_2.Value = minlv;
                    mn6_3.Value = minlv;
                    mn6_4.Value = minlv;
                    mx6_1.Value = maxlv;
                    mx6_2.Value = maxlv;
                    mx6_3.Value = maxlv;
                    mx6_4.Value = maxlv;
                }
            }

            if (femaleratecheck == "y")
            {
                if (w2a == 1)
                {
                    fr1_1.Value = femalerate;
                    fr1_2.Value = femalerate;
                    fr1_3.Value = femalerate;
                    fr1_4.Value = femalerate;
                }
                if (w2b == 1)
                {
                    fr2_1.Value = femalerate;
                    fr2_2.Value = femalerate;
                    fr2_3.Value = femalerate;
                    fr2_4.Value = femalerate;
                }
                if (w2c == 1)
                {
                    fr3_1.Value = femalerate;
                    fr3_2.Value = femalerate;
                    fr3_3.Value = femalerate;
                    fr3_4.Value = femalerate;
                }
                if (b2a == 1)
                {
                    fr4_1.Value = femalerate;
                    fr4_2.Value = femalerate;
                    fr4_3.Value = femalerate;
                    fr4_4.Value = femalerate;
                }
                if (b2b == 1)
                {
                    fr5_1.Value = femalerate;
                    fr5_2.Value = femalerate;
                    fr5_3.Value = femalerate;
                    fr5_4.Value = femalerate;
                }

                if (b2c == 1)
                {
                    fr6_1.Value = femalerate;
                    fr6_2.Value = femalerate;
                    fr6_3.Value = femalerate;
                    fr6_4.Value = femalerate;
                }
            }
        }

        private void ReadSourceData()
        {
            int yu;
            uint bytesx = 0;
            StringBuilder builder = new StringBuilder();
            yu = int.Parse(textBox2.Text);

            this.MapFile.Position = 0L;
            bytesx = 0;

            for (int i = 0; i < FileSize; i++)
            {
                bytesx = (uint)this.MapFile.ReadByte();
                string str = Convert.ToString((int)bytesx, 0x10).ToUpper();
                if (str.Length == 1)
                {
                    str = "0" + str;
                }
                builder.Append(str + " ");
                if ((i % yu) == (yu - 1))
                {
                    builder.Append(Environment.NewLine);
                }
            }
            this.textBox1.Text = builder.ToString();
        }

        //startup pathnya biar portable
        public static string StartupPath
        {
            get
            {
                string startupPath = Application.StartupPath;
                if (!startupPath.EndsWith(@"\"))
                {
                    startupPath = startupPath + @"\";
                }
                return startupPath;
            }
        }



        //button
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Narc File";
            dialog.Filter = "Nitro Archive (a/2/7/3) (*.narc)|*.narc|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(dialog.FileName));
                byte[] buffer = new byte[reader.BaseStream.Length];
                reader.BaseStream.Position = 0L;
                this.NarcFile.Position = 0L;
                reader.Read(buffer, 0, (int)reader.BaseStream.Length);
                this.NarcFile.Write(buffer, 0, (int)reader.BaseStream.Length);
                reader.Close();
                this.NarcFile.Position = 0x18L;
                this.FileCount = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() << 8)) + (this.NarcFile.ReadByte() << 0x10)) + (this.NarcFile.ReadByte() << 0x18));
                this.id_list.Items.Clear();
                for (int i = 0; i < this.FileCount; i++)
                {
                    this.id_list.Items.Add(i.ToString("0"));
                }
                this.FATOffset = (0x1c + (this.FileCount * 8)) + 0x18;

                this.id_list.SelectedIndex = 0;
                this.id_name.SelectedValue = this.id_list.SelectedIndex;
                this.id_list.Enabled = true;
                this.id_name.Enabled = true;
                this.tabControl1.Enabled = true;
                //this.button2.Enabled = true;
                this.save.Enabled = true;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {

            this.MapFile.Position = 0L;
            this.Pokemon1 = (uint)((int)(this.pl1_1.SelectedValue));
            this.Pokemon2 = (uint)((int)(this.pl1_2.SelectedValue));
            this.Pokemon3 = (uint)((int)(this.pl1_3.SelectedValue));
            this.Pokemon4 = (uint)((int)(this.pl1_4.SelectedValue));
            this.Max1 = (uint)this.mx1_1.Value;
            this.Max2 = (uint)this.mx1_2.Value;
            this.Max3 = (uint)this.mx1_3.Value;
            this.Max4 = (uint)this.mx1_4.Value;
            this.Min1 = (uint)this.mn1_1.Value;
            this.Min2 = (uint)this.mn1_2.Value;
            this.Min3 = (uint)this.mn1_3.Value;
            this.Min4 = (uint)this.mn1_4.Value;
            this.frate1 = (uint)this.fr1_1.Value;
            this.frate2 = (uint)this.fr1_2.Value;
            this.frate3 = (uint)this.fr1_3.Value;
            this.frate4 = (uint)this.fr1_4.Value;
            this.unkw1 = (uint)((int)this.forme_1_1.SelectedIndex);
            this.unkw2 = (uint)((int)this.forme_1_2.SelectedIndex);
            this.unkw3 = (uint)((int)this.forme_1_3.SelectedIndex);
            this.unkw4 = (uint)((int)this.forme_1_4.SelectedIndex);
            //this.unkw1 = (uint)this.unk1_1.Value;
            //this.unkw2 = (uint)this.unk1_2.Value;
            //this.unkw3 = (uint)this.unk1_3.Value;
            //this.unkw4 = (uint)this.unk1_4.Value;
            this.unkw5 = (uint)this.unk1_5.Value;
            this.unkw6 = (uint)this.unk1_6.Value;            
            this.WriteNextEntry();

            //this.MapFile.Position = 0x1AL;
            this.Pokemon1 = (uint)(((int)this.pl2_1.SelectedValue));
            this.Pokemon2 = (uint)(((int)this.pl2_2.SelectedValue));
            this.Pokemon3 = (uint)(((int)this.pl2_3.SelectedValue));
            this.Pokemon4 = (uint)(((int)this.pl2_4.SelectedValue));
            this.Max1 = (uint)this.mx2_1.Value;
            this.Max2 = (uint)this.mx2_2.Value;
            this.Max3 = (uint)this.mx2_3.Value;
            this.Max4 = (uint)this.mx2_4.Value;
            this.Min1 = (uint)this.mn2_1.Value;
            this.Min2 = (uint)this.mn2_2.Value;
            this.Min3 = (uint)this.mn2_3.Value;
            this.Min4 = (uint)this.mn2_4.Value;
            this.frate1 = (uint)this.fr2_1.Value;
            this.frate2 = (uint)this.fr2_2.Value;
            this.frate3 = (uint)this.fr2_3.Value;
            this.frate4 = (uint)this.fr2_4.Value;
            this.unkw1 = (uint)((int)this.forme_2_1.SelectedIndex);
            this.unkw2 = (uint)((int)this.forme_2_2.SelectedIndex);
            this.unkw3 = (uint)((int)this.forme_2_3.SelectedIndex);
            this.unkw4 = (uint)((int)this.forme_2_4.SelectedIndex);
            //this.unkw1 = (uint)this.unk2_1.Value;
            //this.unkw2 = (uint)this.unk2_2.Value;
            //this.unkw3 = (uint)this.unk2_3.Value;
            //this.unkw4 = (uint)this.unk2_4.Value;
            this.unkw5 = (uint)this.unk2_5.Value;
            this.unkw6 = (uint)this.unk2_6.Value;
            this.WriteNextEntry();

            //this.MapFile.Position = 0x34L;
            this.Pokemon1 = (uint)((int)(this.pl3_1.SelectedValue));
            this.Pokemon2 = (uint)((int)(this.pl3_2.SelectedValue));
            this.Pokemon3 = (uint)((int)(this.pl3_3.SelectedValue));
            this.Pokemon4 = (uint)((int)(this.pl3_4.SelectedValue));
            this.Max1 = (uint)this.mx3_1.Value;
            this.Max2 = (uint)this.mx3_2.Value;
            this.Max3 = (uint)this.mx3_3.Value;
            this.Max4 = (uint)this.mx3_4.Value;
            this.Min1 = (uint)this.mn3_1.Value;
            this.Min2 = (uint)this.mn3_2.Value;
            this.Min3 = (uint)this.mn3_3.Value;
            this.Min4 = (uint)this.mn3_4.Value;
            this.frate1 = (uint)this.fr3_1.Value;
            this.frate2 = (uint)this.fr3_2.Value;
            this.frate3 = (uint)this.fr3_3.Value;
            this.frate4 = (uint)this.fr3_4.Value;
            this.unkw1 = (uint)((int)this.forme_3_1.SelectedIndex);
            this.unkw2 = (uint)((int)this.forme_3_2.SelectedIndex);
            this.unkw3 = (uint)((int)this.forme_3_3.SelectedIndex);
            this.unkw4 = (uint)((int)this.forme_3_4.SelectedIndex);
            //this.unkw1 = (uint)this.unk3_1.Value;
            //this.unkw2 = (uint)this.unk3_2.Value;
            //this.unkw3 = (uint)this.unk3_3.Value;
            //this.unkw4 = (uint)this.unk3_4.Value;
            this.unkw5 = (uint)this.unk3_5.Value;
            this.unkw6 = (uint)this.unk3_6.Value;
            this.WriteNextEntry();

            //this.MapFile.Position = 0x34L;
            this.Pokemon1 = (uint)((int)(this.pl4_1.SelectedValue));
            this.Pokemon2 = (uint)((int)(this.pl4_2.SelectedValue));
            this.Pokemon3 = (uint)((int)(this.pl4_3.SelectedValue));
            this.Pokemon4 = (uint)((int)(this.pl4_4.SelectedValue));
            this.Max1 = (uint)this.mx4_1.Value;
            this.Max2 = (uint)this.mx4_2.Value;
            this.Max3 = (uint)this.mx4_3.Value;
            this.Max4 = (uint)this.mx4_4.Value;
            this.Min1 = (uint)this.mn4_1.Value;
            this.Min2 = (uint)this.mn4_2.Value;
            this.Min3 = (uint)this.mn4_3.Value;
            this.Min4 = (uint)this.mn4_4.Value;
            this.frate1 = (uint)this.fr4_1.Value;
            this.frate2 = (uint)this.fr4_2.Value;
            this.frate3 = (uint)this.fr4_3.Value;
            this.frate4 = (uint)this.fr4_4.Value;
            this.unkw1 = (uint)((int)this.forme_4_1.SelectedIndex);
            this.unkw2 = (uint)((int)this.forme_4_2.SelectedIndex);
            this.unkw3 = (uint)((int)this.forme_4_3.SelectedIndex);
            this.unkw4 = (uint)((int)this.forme_4_4.SelectedIndex);
            //this.unkw1 = (uint)this.unk4_1.Value;
            //this.unkw2 = (uint)this.unk4_2.Value;
            //this.unkw3 = (uint)this.unk4_3.Value;
            //this.unkw4 = (uint)this.unk4_4.Value;
            this.unkw5 = (uint)this.unk4_5.Value;
            this.unkw6 = (uint)this.unk4_6.Value;
            this.WriteNextEntry();

            this.Pokemon1 = (uint)((int)(this.pl5_1.SelectedValue));
            this.Pokemon2 = (uint)((int)(this.pl5_2.SelectedValue));
            this.Pokemon3 = (uint)((int)(this.pl5_3.SelectedValue));
            this.Pokemon4 = (uint)((int)(this.pl5_4.SelectedValue));
            this.Max1 = (uint)this.mx5_1.Value;
            this.Max2 = (uint)this.mx5_2.Value;
            this.Max3 = (uint)this.mx5_3.Value;
            this.Max4 = (uint)this.mx5_4.Value;
            this.Min1 = (uint)this.mn5_1.Value;
            this.Min2 = (uint)this.mn5_2.Value;
            this.Min3 = (uint)this.mn5_3.Value;
            this.Min4 = (uint)this.mn5_4.Value;
            this.frate1 = (uint)this.fr5_1.Value;
            this.frate2 = (uint)this.fr5_2.Value;
            this.frate3 = (uint)this.fr5_3.Value;
            this.frate4 = (uint)this.fr5_4.Value;
            this.unkw1 = (uint)((int)this.forme_5_1.SelectedIndex);
            this.unkw2 = (uint)((int)this.forme_5_2.SelectedIndex);
            this.unkw3 = (uint)((int)this.forme_5_3.SelectedIndex);
            this.unkw4 = (uint)((int)this.forme_5_4.SelectedIndex);
            //this.unkw1 = (uint)this.unk5_1.Value;
            //this.unkw2 = (uint)this.unk5_2.Value;
            //this.unkw3 = (uint)this.unk5_3.Value;
            //this.unkw4 = (uint)this.unk5_4.Value;
            this.unkw5 = (uint)this.unk5_5.Value;
            this.unkw6 = (uint)this.unk5_6.Value;
            this.WriteNextEntry();

            this.Pokemon1 = (uint)((int)(this.pl6_1.SelectedValue));
            this.Pokemon2 = (uint)((int)(this.pl6_2.SelectedValue));
            this.Pokemon3 = (uint)((int)(this.pl6_3.SelectedValue));
            this.Pokemon4 = (uint)((int)(this.pl6_4.SelectedValue));
            this.Max1 = (uint)this.mx6_1.Value;
            this.Max2 = (uint)this.mx6_2.Value;
            this.Max3 = (uint)this.mx6_3.Value;
            this.Max4 = (uint)this.mx6_4.Value;
            this.Min1 = (uint)this.mn6_1.Value;
            this.Min2 = (uint)this.mn6_2.Value;
            this.Min3 = (uint)this.mn6_3.Value;
            this.Min4 = (uint)this.mn6_4.Value;
            this.frate1 = (uint)this.fr6_1.Value;
            this.frate2 = (uint)this.fr6_2.Value;
            this.frate3 = (uint)this.fr6_3.Value;
            this.frate4 = (uint)this.fr6_4.Value;
            this.unkw1 = (uint)((int)this.forme_6_1.SelectedIndex);
            this.unkw2 = (uint)((int)this.forme_6_2.SelectedIndex);
            this.unkw3 = (uint)((int)this.forme_6_3.SelectedIndex);
            this.unkw4 = (uint)((int)this.forme_6_4.SelectedIndex);
            //this.unkw1 = (uint)this.unk6_1.Value;
            //this.unkw2 = (uint)this.unk6_2.Value;
            //this.unkw3 = (uint)this.unk6_3.Value;
            //this.unkw4 = (uint)this.unk6_4.Value;
            this.unkw5 = (uint)this.unk6_5.Value;
            this.unkw6 = (uint)this.unk6_6.Value;
            this.WriteNextEntry();

            this.MapFile.Position = 0x9cL;
            this.item11 = (uint)(this.it_11.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_12.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_13.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_14.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_15.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_16.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_17.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_18.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_21.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_22.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_23.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_24.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_25.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_26.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_27.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_28.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_31.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_32.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_33.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_34.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_35.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_36.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_37.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_38.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_41.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_42.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_43.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_44.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_45.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_46.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_47.SelectedIndex);
            this.WriteNextEntry2();
            this.item11 = (uint)(this.it_48.SelectedIndex);
            this.WriteNextEntry2();

            this.NarcFile.Position = this.FileOffset + this.FATOffset;
            this.NarcFile.Write(this.MapFile.ToArray(), 0, (int)this.FileSize);
            this.button2.Enabled = true;
        }



        //fungsi nulis dan baca
        private void ReadData()
        {
            this.MapFile.Position = 0L;

            this.ReadNextEntry();
            this.pl1_1.SelectedValue = (int)this.Pokemon1;
            this.pl1_2.SelectedValue = (int)this.Pokemon2;
            this.pl1_3.SelectedValue = (int)this.Pokemon3;
            this.pl1_4.SelectedValue = (int)this.Pokemon4;
            this.mx1_1.Value = this.Max1;
            this.mx1_2.Value = this.Max2;
            this.mx1_3.Value = this.Max3;
            this.mx1_4.Value = this.Max4;
            this.mn1_1.Value = this.Min1;
            this.mn1_2.Value = this.Min2;
            this.mn1_3.Value = this.Min3;
            this.mn1_4.Value = this.Min4;
            this.fr1_1.Value = this.frate1;
            this.fr1_2.Value = this.frate2;
            this.fr1_3.Value = this.frate3;
            this.fr1_4.Value = this.frate4;
            this.forme_1_1.SelectedIndex = (int)this.unkw1;
            this.forme_1_2.SelectedIndex = (int)this.unkw2;
            this.forme_1_3.SelectedIndex = (int)this.unkw3;
            this.forme_1_4.SelectedIndex = (int)this.unkw4;
            //this.unk1_1.Value = this.unkw1;
            //this.unk1_2.Value = this.unkw2;
            //this.unk1_3.Value = this.unkw3;
            //this.unk1_4.Value = this.unkw4;
            this.unk1_5.Value = this.unkw5;
            this.unk1_6.Value = this.unkw6;

            this.ReadNextEntry();
            this.pl2_1.SelectedValue = (int)this.Pokemon1;
            this.pl2_2.SelectedValue = (int)this.Pokemon2;
            this.pl2_3.SelectedValue = (int)this.Pokemon3;
            this.pl2_4.SelectedValue = (int)this.Pokemon4;
            this.mx2_1.Value = this.Max1;
            this.mx2_2.Value = this.Max2;
            this.mx2_3.Value = this.Max3;
            this.mx2_4.Value = this.Max4;
            this.mn2_1.Value = this.Min1;
            this.mn2_2.Value = this.Min2;
            this.mn2_3.Value = this.Min3;
            this.mn2_4.Value = this.Min4;
            this.fr2_1.Value = this.frate1;
            this.fr2_2.Value = this.frate2;
            this.fr2_3.Value = this.frate3;
            this.fr2_4.Value = this.frate4;
            this.forme_2_1.SelectedIndex = (int)this.unkw1;
            this.forme_2_2.SelectedIndex = (int)this.unkw2;
            this.forme_2_3.SelectedIndex = (int)this.unkw3;
            this.forme_2_4.SelectedIndex = (int)this.unkw4;
            //this.unk2_1.Value = this.unkw1;
            //this.unk2_2.Value = this.unkw2;
            //this.unk2_3.Value = this.unkw3;
            //this.unk2_4.Value = this.unkw4;
            this.unk2_5.Value = this.unkw5;
            this.unk2_6.Value = this.unkw6;

            this.ReadNextEntry();
            this.pl3_1.SelectedValue = (int)this.Pokemon1;
            this.pl3_2.SelectedValue = (int)this.Pokemon2;
            this.pl3_3.SelectedValue = (int)this.Pokemon3;
            this.pl3_4.SelectedValue = (int)this.Pokemon4;
            this.mx3_1.Value = this.Max1;
            this.mx3_2.Value = this.Max2;
            this.mx3_3.Value = this.Max3;
            this.mx3_4.Value = this.Max4;
            this.mn3_1.Value = this.Min1;
            this.mn3_2.Value = this.Min2;
            this.mn3_3.Value = this.Min3;
            this.mn3_4.Value = this.Min4;
            this.fr3_1.Value = this.frate1;
            this.fr3_2.Value = this.frate2;
            this.fr3_3.Value = this.frate3;
            this.fr3_4.Value = this.frate4;
            this.forme_3_1.SelectedIndex = (int)this.unkw1;
            this.forme_3_2.SelectedIndex = (int)this.unkw2;
            this.forme_3_3.SelectedIndex = (int)this.unkw3;
            this.forme_3_4.SelectedIndex = (int)this.unkw4;
            //this.unk3_1.Value = this.unkw1;
            //this.unk3_2.Value = this.unkw2;
            //this.unk3_3.Value = this.unkw3;
            //this.unk3_4.Value = this.unkw4;
            this.unk3_5.Value = this.unkw5;
            this.unk3_6.Value = this.unkw6;

            this.ReadNextEntry();
            this.pl4_1.SelectedValue = (int)this.Pokemon1;
            this.pl4_2.SelectedValue = (int)this.Pokemon2;
            this.pl4_3.SelectedValue = (int)this.Pokemon3;
            this.pl4_4.SelectedValue = (int)this.Pokemon4;
            this.mx4_1.Value = this.Max1;
            this.mx4_2.Value = this.Max2;
            this.mx4_3.Value = this.Max3;
            this.mx4_4.Value = this.Max4;
            this.mn4_1.Value = this.Min1;
            this.mn4_2.Value = this.Min2;
            this.mn4_3.Value = this.Min3;
            this.mn4_4.Value = this.Min4;
            this.fr4_1.Value = this.frate1;
            this.fr4_2.Value = this.frate2;
            this.fr4_3.Value = this.frate3;
            this.fr4_4.Value = this.frate4;
            this.forme_4_1.SelectedIndex = (int)this.unkw1;
            this.forme_4_2.SelectedIndex = (int)this.unkw2;
            this.forme_4_3.SelectedIndex = (int)this.unkw3;
            this.forme_4_4.SelectedIndex = (int)this.unkw4;
            //this.unk4_1.Value = this.unkw1;
            //this.unk4_2.Value = this.unkw2;
            //this.unk4_3.Value = this.unkw3;
            //this.unk4_4.Value = this.unkw4;
            this.unk4_5.Value = this.unkw5;
            this.unk4_6.Value = this.unkw6;

            this.ReadNextEntry();
            this.pl5_1.SelectedValue = (int)this.Pokemon1;
            this.pl5_2.SelectedValue = (int)this.Pokemon2;
            this.pl5_3.SelectedValue = (int)this.Pokemon3;
            this.pl5_4.SelectedValue = (int)this.Pokemon4;
            this.mx5_1.Value = this.Max1;
            this.mx5_2.Value = this.Max2;
            this.mx5_3.Value = this.Max3;
            this.mx5_4.Value = this.Max4;
            this.mn5_1.Value = this.Min1;
            this.mn5_2.Value = this.Min2;
            this.mn5_3.Value = this.Min3;
            this.mn5_4.Value = this.Min4;
            this.fr5_1.Value = this.frate1;
            this.fr5_2.Value = this.frate2;
            this.fr5_3.Value = this.frate3;
            this.fr5_4.Value = this.frate4;
            this.forme_5_1.SelectedIndex = (int)this.unkw1;
            this.forme_5_2.SelectedIndex = (int)this.unkw2;
            this.forme_5_3.SelectedIndex = (int)this.unkw3;
            this.forme_5_4.SelectedIndex = (int)this.unkw4;
            //this.unk5_1.Value = this.unkw1;
            //this.unk5_2.Value = this.unkw2;
            //this.unk5_3.Value = this.unkw3;
            //this.unk5_4.Value = this.unkw4;
            this.unk5_5.Value = this.unkw5;
            this.unk5_6.Value = this.unkw6;

            this.ReadNextEntry();
            this.pl6_1.SelectedValue = (int)this.Pokemon1;
            this.pl6_2.SelectedValue = (int)this.Pokemon2;
            this.pl6_3.SelectedValue = (int)this.Pokemon3;
            this.pl6_4.SelectedValue = (int)this.Pokemon4;
            this.mx6_1.Value = this.Max1;
            this.mx6_2.Value = this.Max2;
            this.mx6_3.Value = this.Max3;
            this.mx6_4.Value = this.Max4;
            this.mn6_1.Value = this.Min1;
            this.mn6_2.Value = this.Min2;
            this.mn6_3.Value = this.Min3;
            this.mn6_4.Value = this.Min4;
            this.fr6_1.Value = this.frate1;
            this.fr6_2.Value = this.frate2;
            this.fr6_3.Value = this.frate3;
            this.fr6_4.Value = this.frate4;
            this.forme_6_1.SelectedIndex = (int)this.unkw1;
            this.forme_6_2.SelectedIndex = (int)this.unkw2;
            this.forme_6_3.SelectedIndex = (int)this.unkw3;
            this.forme_6_4.SelectedIndex = (int)this.unkw4;
            //this.unk6_1.Value = this.unkw1;
            //this.unk6_2.Value = this.unkw2;
            //this.unk6_3.Value = this.unkw3;
            //this.unk6_4.Value = this.unkw4;
            this.unk6_5.Value = this.unkw5;
            this.unk6_6.Value = this.unkw6;

            this.MapFile.Position = 0x9cL;
            this.ReadNextEntry2();
            this.it_11.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_12.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_13.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_14.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_15.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_16.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_17.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_18.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_21.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_22.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_23.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_24.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_25.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_26.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_27.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_28.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_31.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_32.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_33.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_34.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_35.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_36.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_37.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_38.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_41.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_42.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_43.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_44.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_45.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_46.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_47.SelectedIndex = (int)this.item11;
            this.ReadNextEntry2();
            this.it_48.SelectedIndex = (int)this.item11;
        }

        private void ReadNextEntry()
        {
            this.Pokemon1 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.Pokemon2 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.Pokemon3 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.Pokemon4 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            
            this.Max1 = 0;
            this.Max2 = 0;
            this.Max3 = 0;
            this.Max4 = 0;
            this.Min1 = 0;
            this.Min2 = 0;
            this.Min3 = 0;
            this.Min4 = 0;
            this.frate1 = 0;
            this.frate2 = 0;
            this.frate3 = 0;
            this.frate4 = 0;
            this.unkw1 = 0;
            this.unkw2 = 0;
            this.unkw3 = 0;
            this.unkw4 = 0;
            this.unkw5 = 0;
            this.unkw6 = 0;
            
            while (this.Pokemon1 > 0x800)
            {
                this.Pokemon1 -= 0x800;
            }
            while (this.Pokemon2 > 0x800)
            {
                this.Pokemon2 -= 0x800;
            }
            while (this.Pokemon3 > 0x800)
            {
                this.Pokemon3 -= 0x800;
            }
            while (this.Pokemon4 > 0x800)
            {
                this.Pokemon4 -= 0x800;
            }
            
            this.Max1 = (uint)this.MapFile.ReadByte();
            this.Max2 = (uint)this.MapFile.ReadByte();
            this.Max3 = (uint)this.MapFile.ReadByte();
            this.Max4 = (uint)this.MapFile.ReadByte();
            this.Min1 = (uint)this.MapFile.ReadByte();
            this.Min2 = (uint)this.MapFile.ReadByte();
            this.Min3 = (uint)this.MapFile.ReadByte();
            this.Min4 = (uint)this.MapFile.ReadByte();
            this.frate1 = (uint)this.MapFile.ReadByte();
            this.frate2 = (uint)this.MapFile.ReadByte();
            this.frate3 = (uint)this.MapFile.ReadByte();
            this.frate4 = (uint)this.MapFile.ReadByte();
            this.unkw1 = (uint)this.MapFile.ReadByte();
            this.unkw2 = (uint)this.MapFile.ReadByte();
            this.unkw3 = (uint)this.MapFile.ReadByte();
            this.unkw4 = (uint)this.MapFile.ReadByte();
            this.unkw5 = (uint)this.MapFile.ReadByte();
            this.unkw6 = (uint)this.MapFile.ReadByte();
        }

        private void ReadNextEntry2()
        {
            this.item11 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));

            while (this.item11 > 0x800)
            {
                this.item11 -= 0x800;
            }
        }
    
        private void WriteNextEntry()
        {
            this.MapFile.WriteByte((byte)(this.Pokemon1 - ((this.Pokemon1 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(this.Pokemon1 >> 8));
            this.MapFile.WriteByte((byte)(this.Pokemon2 - ((this.Pokemon2 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(this.Pokemon2 >> 8));
            this.MapFile.WriteByte((byte)(this.Pokemon3 - ((this.Pokemon3 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(this.Pokemon3 >> 8));
            this.MapFile.WriteByte((byte)(this.Pokemon4 - ((this.Pokemon4 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(this.Pokemon4 >> 8));
            
            this.MapFile.WriteByte((byte)this.Max1);
            this.MapFile.WriteByte((byte)this.Max2);
            this.MapFile.WriteByte((byte)this.Max3);
            this.MapFile.WriteByte((byte)this.Max4);

            this.MapFile.WriteByte((byte)this.Min1);
            this.MapFile.WriteByte((byte)this.Min2);
            this.MapFile.WriteByte((byte)this.Min3);
            this.MapFile.WriteByte((byte)this.Min4);

            this.MapFile.WriteByte((byte)this.frate1);
            this.MapFile.WriteByte((byte)this.frate2);
            this.MapFile.WriteByte((byte)this.frate3);
            this.MapFile.WriteByte((byte)this.frate4);

            this.MapFile.WriteByte((byte)this.unkw1);
            this.MapFile.WriteByte((byte)this.unkw2);
            this.MapFile.WriteByte((byte)this.unkw3);
            this.MapFile.WriteByte((byte)this.unkw4);
            this.MapFile.WriteByte((byte)this.unkw5);
            this.MapFile.WriteByte((byte)this.unkw6);
        }

        private void WriteNextEntry2()
        {
            this.MapFile.WriteByte((byte)(this.item11 - ((this.item11 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(this.item11 >> 8));  
        }



        //button nyimpen narc
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Narc File";
            dialog.Filter = "Nitro Archive (*.narc)|*.narc|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, this.NarcFile.ToArray());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            if (comboBox1.SelectedIndex == 0)
            {
                form.label9.Text = global::aleafia_reslang_en.Properties.Resources.String22;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                form.label9.Text = global::aleafia_reslang_id.Properties.Resources.String22;
            }

            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                unk1_5.Enabled = true;
                unk1_6.Enabled = true;
                unk2_5.Enabled = true;
                unk2_6.Enabled = true;
                unk3_5.Enabled = true;
                unk3_6.Enabled = true;
                unk4_5.Enabled = true;
                unk4_6.Enabled = true;
                unk5_5.Enabled = true;
                unk5_6.Enabled = true;
                unk6_5.Enabled = true;
                unk6_6.Enabled = true;
            }
            else
            {
                unk1_5.Enabled = false;
                unk1_6.Enabled = false;
                unk2_5.Enabled = false;
                unk2_6.Enabled = false;
                unk3_5.Enabled = false;
                unk3_6.Enabled = false;
                unk4_5.Enabled = false;
                unk4_6.Enabled = false;
                unk5_5.Enabled = false;
                unk5_6.Enabled = false;
                unk6_5.Enabled = false;
                unk6_6.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                toolTip1.Active = false;
            }
            else
            {
                toolTip1.Active = true;
            }
        }

        public void id_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.id_name.SelectedIndex < 0)
            {
                this.id_name.SelectedIndex = 0;
            }
            else if (this.id_name.SelectedIndex >= this.id_name.Items.Count)
            {
                this.id_name.SelectedIndex = this.id_name.Items.Count - 1;
            }
            this.id_list.SelectedIndex = (int)this.id_name.SelectedValue;
            this.button2.Enabled = false;

        }

        public void id_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.id_list.SelectedIndex < 0)
            {
                this.id_list.SelectedIndex = 0;
            }
            else if (this.id_list.SelectedIndex >= this.id_list.Items.Count)
            {
                this.id_list.SelectedIndex = this.id_list.Items.Count - 1;
            }
            this.id_name.SelectedValue = this.id_list.SelectedIndex;

            this.NarcFile.Position = 0x1c + (this.id_list.SelectedIndex * 8);
            this.FileOffset = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000));
            this.FileSize = ((uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000))) - this.FileOffset;
            this.MapFile = new MemoryStream();
            this.MapFile.Position = 0L;
            this.MapFile.Write(this.NarcFile.ToArray(), (int)(this.FileOffset + this.FATOffset), (int)this.FileSize);

            if (this.FileSize == 0xdc)
            {
                this.MapFile.Position = 0L;
                this.ReadData();
            }
            label24.Text = "Size : " + FileSize;

            String dos;
            dos = (0xD4 + FileOffset).ToString("X");
            label28.Text = "Offset : 0x" + (dos);
            this.button2.Enabled = false;
            ReadSourceData();
        }
        


        //W2 -1
        private void forme_1_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_1_1.SelectedIndex > 0)
            {
                this.pbx_pl1_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_1.SelectedValue +  "_" + (int)this.forme_1_1.SelectedIndex);
   
            }
            else
            {
                this.pbx_pl1_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_1.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl1_1.SelectedValue) == "1")
            {
                this.pictureBox1.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox1.Image = global::AHGE.Properties.Resources._a1;
            }
            
        }

        private void forme_1_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_1_2.SelectedIndex > 0)
            {
                this.pbx_pl1_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_2.SelectedValue + "_" + (int)this.forme_1_2.SelectedIndex);
            }
            else
            {
                this.pbx_pl1_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_2.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl1_2.SelectedValue) == "1")
            {
                this.pictureBox2.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox2.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_1_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_1_3.SelectedIndex > 0)
            {
                this.pbx_pl1_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_3.SelectedValue + "_" + (int)this.forme_1_3.SelectedIndex);
            }
            else
            {
                this.pbx_pl1_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_3.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl1_3.SelectedValue) == "1")
            {
                this.pictureBox3.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox3.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_1_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_1_4.SelectedIndex > 0)
            {
                this.pbx_pl1_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_4.SelectedValue + "_" + (int)this.forme_1_4.SelectedIndex);
            }
            else
            {
                this.pbx_pl1_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl1_4.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl1_4.SelectedValue) == "1")
            {
                this.pictureBox4.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox4.Image = global::AHGE.Properties.Resources._a1;
            }
        }


        public void pl1_1_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_1_1.Items.Clear();

            switch ((int)this.pl1_1.SelectedValue)
            {
                case 172: //Pichu
                    forme_1_1.Items.Add("Normal");

                    if ((int)this.pl1_1.SelectedValue < 1)
                    {
                        forme_1_1.SelectedIndex = (int)this.pl1_1.SelectedValue;
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_1_1.Items.Add("A");
                    forme_1_1.Items.Add("B");
                    forme_1_1.Items.Add("C");
                    forme_1_1.Items.Add("D");
                    forme_1_1.Items.Add("E");
                    forme_1_1.Items.Add("F");
                    forme_1_1.Items.Add("G");
                    forme_1_1.Items.Add("H");
                    forme_1_1.Items.Add("I");
                    forme_1_1.Items.Add("J");
                    forme_1_1.Items.Add("K");
                    forme_1_1.Items.Add("L");
                    forme_1_1.Items.Add("M");
                    forme_1_1.Items.Add("N");
                    forme_1_1.Items.Add("O");
                    forme_1_1.Items.Add("P");
                    forme_1_1.Items.Add("Q");
                    forme_1_1.Items.Add("R");
                    forme_1_1.Items.Add("S");
                    forme_1_1.Items.Add("T");
                    forme_1_1.Items.Add("U");
                    forme_1_1.Items.Add("V");
                    forme_1_1.Items.Add("W");
                    forme_1_1.Items.Add("X");
                    forme_1_1.Items.Add("Y");
                    forme_1_1.Items.Add("Z");
                    forme_1_1.Items.Add("!");
                    forme_1_1.Items.Add("?");

                    if ((int)this.pl1_1.SelectedValue < 28)
                    {
                        forme_1_1.SelectedIndex = (int)this.pl1_1.SelectedValue;
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_1_1.Items.Add("Normal");
                    forme_1_1.Items.Add("Sunny Form");
                    forme_1_1.Items.Add("Rainy Form");
                    forme_1_1.Items.Add("Snowy Form");

                    if ((int)this.pl1_1.SelectedValue < 4)
                    {
                        forme_1_1.SelectedIndex = (int)this.pl1_1.SelectedValue;
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_1_1.Items.Add("Normal");
                    forme_1_1.Items.Add("Attack");
                    forme_1_1.Items.Add("Defense");
                    forme_1_1.Items.Add("Speed");

                    if ((int)this.pl1_1.SelectedValue < 4)
                    {
                        forme_1_1.SelectedIndex = (int)this.pl1_1.SelectedValue;
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_1_1.Items.Add("Plant");
                    forme_1_1.Items.Add("Sand");
                    forme_1_1.Items.Add("Trash");

                    if ((int)this.pl1_1.SelectedValue < 3)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_1_1.Items.Add("Overcast Form");
                    forme_1_1.Items.Add("Sunshine Form");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_1_1.Items.Add("West");
                    forme_1_1.Items.Add("East");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = (int)this.pl1_1.SelectedValue;
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_1_1.Items.Add("Normal");
                    forme_1_1.Items.Add("Heat");
                    forme_1_1.Items.Add("Wash");
                    forme_1_1.Items.Add("Frost");
                    forme_1_1.Items.Add("Spin");
                    forme_1_1.Items.Add("Cut");

                    if ((int)this.pl1_1.SelectedValue < 6)
                    {
                        forme_1_1.SelectedIndex = (int)this.pl1_1.SelectedValue;
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_1_1.Items.Add("Altered");
                    forme_1_1.Items.Add("Origin");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_1_1.Items.Add("Land");
                    forme_1_1.Items.Add("Sky");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_1_1.Items.Add("Normal");
                    forme_1_1.Items.Add("Fighting");
                    forme_1_1.Items.Add("Flying");
                    forme_1_1.Items.Add("Poison");
                    forme_1_1.Items.Add("Ground");
                    forme_1_1.Items.Add("Rock");
                    forme_1_1.Items.Add("Bug");
                    forme_1_1.Items.Add("Ghost");
                    forme_1_1.Items.Add("Steel");
                    forme_1_1.Items.Add("Fire");
                    forme_1_1.Items.Add("Water");
                    forme_1_1.Items.Add("Grass");
                    forme_1_1.Items.Add("Electric");
                    forme_1_1.Items.Add("Psychic");
                    forme_1_1.Items.Add("Ice");
                    forme_1_1.Items.Add("Dragon");
                    forme_1_1.Items.Add("Dark");

                    if ((int)this.pl1_1.SelectedValue < 18)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_1_1.Items.Add("Red-Striped");
                    forme_1_1.Items.Add("Blue-Striped");
                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_1_1.Items.Add("Normal");
                    forme_1_1.Items.Add("Zen mode");
                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_1_1.Items.Add("Spring Form");
                    forme_1_1.Items.Add("Summer Form");
                    forme_1_1.Items.Add("Autumn Form");
                    forme_1_1.Items.Add("Winter Form");

                    if ((int)this.pl1_1.SelectedValue < 4)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_1_1.Items.Add("Incarnate Forme");
                    forme_1_1.Items.Add("Therian Forme");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_1_1.Items.Add("Kyurem");
                    forme_1_1.Items.Add("White Kyurem");
                    forme_1_1.Items.Add("Black Kyurem");

                    if ((int)this.pl1_1.SelectedValue < 3)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_1_1.Items.Add("Ordinary Form");
                    forme_1_1.Items.Add("Resolute Form");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_1_1.Items.Add("Aria Forme");
                    forme_1_1.Items.Add("Pirouette Forme");

                    if ((int)this.pl1_1.SelectedValue < 2)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_1_1.Items.Add("Normal");
                    forme_1_1.Items.Add("1");
                    forme_1_1.Items.Add("2");
                    forme_1_1.Items.Add("3");
                    forme_1_1.Items.Add("4");

                    if ((int)this.pl1_1.SelectedValue < 5)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_1_1.Items.Add("Normal");

                    if ((int)this.pl1_1.SelectedValue < 1)
                    {
                        forme_1_1.SelectedIndex = ((int)this.pl1_1.SelectedValue);
                    }
                    else
                    {
                        forme_1_1.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl1_2_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_1_2.Items.Clear();

            switch ((int)this.pl1_2.SelectedValue)
            {
                case 172: //Pichu
                    forme_1_2.Items.Add("Normal");

                    if ((int)this.pl1_2.SelectedValue < 1)
                    {
                        forme_1_2.SelectedIndex = (int)this.pl1_2.SelectedValue;
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_1_2.Items.Add("A");
                    forme_1_2.Items.Add("B");
                    forme_1_2.Items.Add("C");
                    forme_1_2.Items.Add("D");
                    forme_1_2.Items.Add("E");
                    forme_1_2.Items.Add("F");
                    forme_1_2.Items.Add("G");
                    forme_1_2.Items.Add("H");
                    forme_1_2.Items.Add("I");
                    forme_1_2.Items.Add("J");
                    forme_1_2.Items.Add("K");
                    forme_1_2.Items.Add("L");
                    forme_1_2.Items.Add("M");
                    forme_1_2.Items.Add("N");
                    forme_1_2.Items.Add("O");
                    forme_1_2.Items.Add("P");
                    forme_1_2.Items.Add("Q");
                    forme_1_2.Items.Add("R");
                    forme_1_2.Items.Add("S");
                    forme_1_2.Items.Add("T");
                    forme_1_2.Items.Add("U");
                    forme_1_2.Items.Add("V");
                    forme_1_2.Items.Add("W");
                    forme_1_2.Items.Add("X");
                    forme_1_2.Items.Add("Y");
                    forme_1_2.Items.Add("Z");
                    forme_1_2.Items.Add("!");
                    forme_1_2.Items.Add("?");

                    if ((int)this.pl1_2.SelectedValue < 28)
                    {
                        forme_1_2.SelectedIndex = (int)this.pl1_2.SelectedValue;
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_1_2.Items.Add("Normal");
                    forme_1_2.Items.Add("Sunny Form");
                    forme_1_2.Items.Add("Rainy Form");
                    forme_1_2.Items.Add("Snowy Form");

                    if ((int)this.pl1_2.SelectedValue < 4)
                    {
                        forme_1_2.SelectedIndex = (int)this.pl1_2.SelectedValue;
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_1_2.Items.Add("Normal");
                    forme_1_2.Items.Add("Attack");
                    forme_1_2.Items.Add("Defense");
                    forme_1_2.Items.Add("Speed");

                    if ((int)this.pl1_2.SelectedValue < 4)
                    {
                        forme_1_2.SelectedIndex = (int)this.pl1_2.SelectedValue;
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_1_2.Items.Add("Plant");
                    forme_1_2.Items.Add("Sand");
                    forme_1_2.Items.Add("Trash");

                    if ((int)this.pl1_2.SelectedValue < 3)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_1_2.Items.Add("Overcast Form");
                    forme_1_2.Items.Add("Sunshine Form");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_1_2.Items.Add("West");
                    forme_1_2.Items.Add("East");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = (int)this.pl1_2.SelectedValue;
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_1_2.Items.Add("Normal");
                    forme_1_2.Items.Add("Heat");
                    forme_1_2.Items.Add("Wash");
                    forme_1_2.Items.Add("Frost");
                    forme_1_2.Items.Add("Spin");
                    forme_1_2.Items.Add("Cut");

                    if ((int)this.pl1_2.SelectedValue < 6)
                    {
                        forme_1_2.SelectedIndex = (int)this.pl1_2.SelectedValue;
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_1_2.Items.Add("Altered");
                    forme_1_2.Items.Add("Origin");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_1_2.Items.Add("Land");
                    forme_1_2.Items.Add("Sky");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_1_2.Items.Add("Normal");
                    forme_1_2.Items.Add("Fighting");
                    forme_1_2.Items.Add("Flying");
                    forme_1_2.Items.Add("Poison");
                    forme_1_2.Items.Add("Ground");
                    forme_1_2.Items.Add("Rock");
                    forme_1_2.Items.Add("Bug");
                    forme_1_2.Items.Add("Ghost");
                    forme_1_2.Items.Add("Steel");
                    forme_1_2.Items.Add("Fire");
                    forme_1_2.Items.Add("Water");
                    forme_1_2.Items.Add("Grass");
                    forme_1_2.Items.Add("Electric");
                    forme_1_2.Items.Add("Psychic");
                    forme_1_2.Items.Add("Ice");
                    forme_1_2.Items.Add("Dragon");
                    forme_1_2.Items.Add("Dark");

                    if ((int)this.pl1_2.SelectedValue < 18)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_1_2.Items.Add("Red-Striped");
                    forme_1_2.Items.Add("Blue-Striped");
                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_1_2.Items.Add("Normal");
                    forme_1_2.Items.Add("Zen mode");
                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_1_2.Items.Add("Spring Form");
                    forme_1_2.Items.Add("Summer Form");
                    forme_1_2.Items.Add("Autumn Form");
                    forme_1_2.Items.Add("Winter Form");

                    if ((int)this.pl1_2.SelectedValue < 4)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_1_2.Items.Add("Incarnate Forme");
                    forme_1_2.Items.Add("Therian Forme");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_1_2.Items.Add("Kyurem");
                    forme_1_2.Items.Add("White Kyurem");
                    forme_1_2.Items.Add("Black Kyurem");

                    if ((int)this.pl1_2.SelectedValue < 3)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_1_2.Items.Add("Ordinary Form");
                    forme_1_2.Items.Add("Resolute Form");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_1_2.Items.Add("Aria Forme");
                    forme_1_2.Items.Add("Pirouette Forme");

                    if ((int)this.pl1_2.SelectedValue < 2)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_1_2.Items.Add("Normal");
                    forme_1_2.Items.Add("1");
                    forme_1_2.Items.Add("2");
                    forme_1_2.Items.Add("3");
                    forme_1_2.Items.Add("4");

                    if ((int)this.pl1_2.SelectedValue < 5)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_1_2.Items.Add("Normal");

                    if ((int)this.pl1_2.SelectedValue < 1)
                    {
                        forme_1_2.SelectedIndex = ((int)this.pl1_2.SelectedValue);
                    }
                    else
                    {
                        forme_1_2.SelectedIndex = 0;
                    }
                    break;
            }
        }

        public void pl1_3_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_1_3.Items.Clear();

            switch ((int)this.pl1_3.SelectedValue)
            {
                case 172: //Pichu
                    forme_1_3.Items.Add("Normal");

                    if ((int)this.pl1_3.SelectedValue < 1)
                    {
                        forme_1_3.SelectedIndex = (int)this.pl1_3.SelectedValue;
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_1_3.Items.Add("A");
                    forme_1_3.Items.Add("B");
                    forme_1_3.Items.Add("C");
                    forme_1_3.Items.Add("D");
                    forme_1_3.Items.Add("E");
                    forme_1_3.Items.Add("F");
                    forme_1_3.Items.Add("G");
                    forme_1_3.Items.Add("H");
                    forme_1_3.Items.Add("I");
                    forme_1_3.Items.Add("J");
                    forme_1_3.Items.Add("K");
                    forme_1_3.Items.Add("L");
                    forme_1_3.Items.Add("M");
                    forme_1_3.Items.Add("N");
                    forme_1_3.Items.Add("O");
                    forme_1_3.Items.Add("P");
                    forme_1_3.Items.Add("Q");
                    forme_1_3.Items.Add("R");
                    forme_1_3.Items.Add("S");
                    forme_1_3.Items.Add("T");
                    forme_1_3.Items.Add("U");
                    forme_1_3.Items.Add("V");
                    forme_1_3.Items.Add("W");
                    forme_1_3.Items.Add("X");
                    forme_1_3.Items.Add("Y");
                    forme_1_3.Items.Add("Z");
                    forme_1_3.Items.Add("!");
                    forme_1_3.Items.Add("?");

                    if ((int)this.pl1_3.SelectedValue < 28)
                    {
                        forme_1_3.SelectedIndex = (int)this.pl1_3.SelectedValue;
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_1_3.Items.Add("Normal");
                    forme_1_3.Items.Add("Sunny Form");
                    forme_1_3.Items.Add("Rainy Form");
                    forme_1_3.Items.Add("Snowy Form");

                    if ((int)this.pl1_3.SelectedValue < 4)
                    {
                        forme_1_3.SelectedIndex = (int)this.pl1_3.SelectedValue;
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_1_3.Items.Add("Normal");
                    forme_1_3.Items.Add("Attack");
                    forme_1_3.Items.Add("Defense");
                    forme_1_3.Items.Add("Speed");

                    if ((int)this.pl1_3.SelectedValue < 4)
                    {
                        forme_1_3.SelectedIndex = (int)this.pl1_3.SelectedValue;
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_1_3.Items.Add("Plant");
                    forme_1_3.Items.Add("Sand");
                    forme_1_3.Items.Add("Trash");

                    if ((int)this.pl1_3.SelectedValue < 3)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_1_3.Items.Add("Overcast Form");
                    forme_1_3.Items.Add("Sunshine Form");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_1_3.Items.Add("West");
                    forme_1_3.Items.Add("East");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = (int)this.pl1_3.SelectedValue;
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_1_3.Items.Add("Normal");
                    forme_1_3.Items.Add("Heat");
                    forme_1_3.Items.Add("Wash");
                    forme_1_3.Items.Add("Frost");
                    forme_1_3.Items.Add("Spin");
                    forme_1_3.Items.Add("Cut");

                    if ((int)this.pl1_3.SelectedValue < 6)
                    {
                        forme_1_3.SelectedIndex = (int)this.pl1_3.SelectedValue;
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_1_3.Items.Add("Altered");
                    forme_1_3.Items.Add("Origin");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_1_3.Items.Add("Land");
                    forme_1_3.Items.Add("Sky");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_1_3.Items.Add("Normal");
                    forme_1_3.Items.Add("Fighting");
                    forme_1_3.Items.Add("Flying");
                    forme_1_3.Items.Add("Poison");
                    forme_1_3.Items.Add("Ground");
                    forme_1_3.Items.Add("Rock");
                    forme_1_3.Items.Add("Bug");
                    forme_1_3.Items.Add("Ghost");
                    forme_1_3.Items.Add("Steel");
                    forme_1_3.Items.Add("Fire");
                    forme_1_3.Items.Add("Water");
                    forme_1_3.Items.Add("Grass");
                    forme_1_3.Items.Add("Electric");
                    forme_1_3.Items.Add("Psychic");
                    forme_1_3.Items.Add("Ice");
                    forme_1_3.Items.Add("Dragon");
                    forme_1_3.Items.Add("Dark");

                    if ((int)this.pl1_3.SelectedValue < 18)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_1_3.Items.Add("Red-Striped");
                    forme_1_3.Items.Add("Blue-Striped");
                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_1_3.Items.Add("Normal");
                    forme_1_3.Items.Add("Zen mode");
                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_1_3.Items.Add("Spring Form");
                    forme_1_3.Items.Add("Summer Form");
                    forme_1_3.Items.Add("Autumn Form");
                    forme_1_3.Items.Add("Winter Form");

                    if ((int)this.pl1_3.SelectedValue < 4)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_1_3.Items.Add("Incarnate Forme");
                    forme_1_3.Items.Add("Therian Forme");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_1_3.Items.Add("Kyurem");
                    forme_1_3.Items.Add("White Kyurem");
                    forme_1_3.Items.Add("Black Kyurem");

                    if ((int)this.pl1_3.SelectedValue < 3)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_1_3.Items.Add("Ordinary Form");
                    forme_1_3.Items.Add("Resolute Form");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_1_3.Items.Add("Aria Forme");
                    forme_1_3.Items.Add("Pirouette Forme");

                    if ((int)this.pl1_3.SelectedValue < 2)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_1_3.Items.Add("Normal");
                    forme_1_3.Items.Add("1");
                    forme_1_3.Items.Add("2");
                    forme_1_3.Items.Add("3");
                    forme_1_3.Items.Add("4");

                    if ((int)this.pl1_3.SelectedValue < 5)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_1_3.Items.Add("Normal");

                    if ((int)this.pl1_3.SelectedValue < 1)
                    {
                        forme_1_3.SelectedIndex = ((int)this.pl1_3.SelectedValue);
                    }
                    else
                    {
                        forme_1_3.SelectedIndex = 0;
                    }
                    break;
            }
        }

        public void pl1_4_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_1_4.Items.Clear();

            switch ((int)this.pl1_4.SelectedValue)
            {
                case 172: //Pichu
                    forme_1_4.Items.Add("Normal");

                    if ((int)this.pl1_4.SelectedValue < 1)
                    {
                        forme_1_4.SelectedIndex = (int)this.pl1_4.SelectedValue;
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_1_4.Items.Add("A");
                    forme_1_4.Items.Add("B");
                    forme_1_4.Items.Add("C");
                    forme_1_4.Items.Add("D");
                    forme_1_4.Items.Add("E");
                    forme_1_4.Items.Add("F");
                    forme_1_4.Items.Add("G");
                    forme_1_4.Items.Add("H");
                    forme_1_4.Items.Add("I");
                    forme_1_4.Items.Add("J");
                    forme_1_4.Items.Add("K");
                    forme_1_4.Items.Add("L");
                    forme_1_4.Items.Add("M");
                    forme_1_4.Items.Add("N");
                    forme_1_4.Items.Add("O");
                    forme_1_4.Items.Add("P");
                    forme_1_4.Items.Add("Q");
                    forme_1_4.Items.Add("R");
                    forme_1_4.Items.Add("S");
                    forme_1_4.Items.Add("T");
                    forme_1_4.Items.Add("U");
                    forme_1_4.Items.Add("V");
                    forme_1_4.Items.Add("W");
                    forme_1_4.Items.Add("X");
                    forme_1_4.Items.Add("Y");
                    forme_1_4.Items.Add("Z");
                    forme_1_4.Items.Add("!");
                    forme_1_4.Items.Add("?");

                    if ((int)this.pl1_4.SelectedValue < 28)
                    {
                        forme_1_4.SelectedIndex = (int)this.pl1_4.SelectedValue;
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_1_4.Items.Add("Normal");
                    forme_1_4.Items.Add("Sunny Form");
                    forme_1_4.Items.Add("Rainy Form");
                    forme_1_4.Items.Add("Snowy Form");

                    if ((int)this.pl1_4.SelectedValue < 4)
                    {
                        forme_1_4.SelectedIndex = (int)this.pl1_4.SelectedValue;
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_1_4.Items.Add("Normal");
                    forme_1_4.Items.Add("Attack");
                    forme_1_4.Items.Add("Defense");
                    forme_1_4.Items.Add("Speed");

                    if ((int)this.pl1_4.SelectedValue < 4)
                    {
                        forme_1_4.SelectedIndex = (int)this.pl1_4.SelectedValue;
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_1_4.Items.Add("Plant");
                    forme_1_4.Items.Add("Sand");
                    forme_1_4.Items.Add("Trash");

                    if ((int)this.pl1_4.SelectedValue < 3)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_1_4.Items.Add("Overcast Form");
                    forme_1_4.Items.Add("Sunshine Form");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_1_4.Items.Add("West");
                    forme_1_4.Items.Add("East");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = (int)this.pl1_4.SelectedValue;
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_1_4.Items.Add("Normal");
                    forme_1_4.Items.Add("Heat");
                    forme_1_4.Items.Add("Wash");
                    forme_1_4.Items.Add("Frost");
                    forme_1_4.Items.Add("Spin");
                    forme_1_4.Items.Add("Cut");

                    if ((int)this.pl1_4.SelectedValue < 6)
                    {
                        forme_1_4.SelectedIndex = (int)this.pl1_4.SelectedValue;
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_1_4.Items.Add("Altered");
                    forme_1_4.Items.Add("Origin");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_1_4.Items.Add("Land");
                    forme_1_4.Items.Add("Sky");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_1_4.Items.Add("Normal");
                    forme_1_4.Items.Add("Fighting");
                    forme_1_4.Items.Add("Flying");
                    forme_1_4.Items.Add("Poison");
                    forme_1_4.Items.Add("Ground");
                    forme_1_4.Items.Add("Rock");
                    forme_1_4.Items.Add("Bug");
                    forme_1_4.Items.Add("Ghost");
                    forme_1_4.Items.Add("Steel");
                    forme_1_4.Items.Add("Fire");
                    forme_1_4.Items.Add("Water");
                    forme_1_4.Items.Add("Grass");
                    forme_1_4.Items.Add("Electric");
                    forme_1_4.Items.Add("Psychic");
                    forme_1_4.Items.Add("Ice");
                    forme_1_4.Items.Add("Dragon");
                    forme_1_4.Items.Add("Dark");

                    if ((int)this.pl1_4.SelectedValue < 18)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_1_4.Items.Add("Red-Striped");
                    forme_1_4.Items.Add("Blue-Striped");
                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_1_4.Items.Add("Normal");
                    forme_1_4.Items.Add("Zen mode");
                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_1_4.Items.Add("Spring Form");
                    forme_1_4.Items.Add("Summer Form");
                    forme_1_4.Items.Add("Autumn Form");
                    forme_1_4.Items.Add("Winter Form");

                    if ((int)this.pl1_4.SelectedValue < 4)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_1_4.Items.Add("Incarnate Forme");
                    forme_1_4.Items.Add("Therian Forme");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_1_4.Items.Add("Kyurem");
                    forme_1_4.Items.Add("White Kyurem");
                    forme_1_4.Items.Add("Black Kyurem");

                    if ((int)this.pl1_4.SelectedValue < 3)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_1_4.Items.Add("Ordinary Form");
                    forme_1_4.Items.Add("Resolute Form");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_1_4.Items.Add("Aria Forme");
                    forme_1_4.Items.Add("Pirouette Forme");

                    if ((int)this.pl1_4.SelectedValue < 2)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_1_4.Items.Add("Normal");
                    forme_1_4.Items.Add("1");
                    forme_1_4.Items.Add("2");
                    forme_1_4.Items.Add("3");
                    forme_1_4.Items.Add("4");

                    if ((int)this.pl1_4.SelectedValue < 5)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_1_4.Items.Add("Normal");

                    if ((int)this.pl1_4.SelectedValue < 1)
                    {
                        forme_1_4.SelectedIndex = ((int)this.pl1_4.SelectedValue);
                    }
                    else
                    {
                        forme_1_4.SelectedIndex = 0;
                    }
                    break;
            }
        }



        //W2 -2

        private void forme_2_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_2_1.SelectedIndex > 0)
            {
                this.pbx_pl2_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_1.SelectedValue + "_" + (int)this.forme_2_1.SelectedIndex);
            }
            else
            {
                this.pbx_pl2_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_1.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl2_1.SelectedValue) == "1")
            {
                this.pictureBox5.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox5.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_2_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_2_2.SelectedIndex > 0)
            {
                this.pbx_pl2_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_2.SelectedValue + "_" + (int)this.forme_2_2.SelectedIndex);
            }
            else
            {
                this.pbx_pl2_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_2.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl2_2.SelectedValue) == "1")
            {
                this.pictureBox6.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox6.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_2_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_2_3.SelectedIndex > 0)
            {
                this.pbx_pl2_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_3.SelectedValue + "_" + (int)this.forme_2_3.SelectedIndex);
            }
            else
            {
                this.pbx_pl2_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_3.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl2_3.SelectedValue) == "1")
            {
                this.pictureBox7.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox7.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_2_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_2_4.SelectedIndex > 0)
            {
                this.pbx_pl2_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_4.SelectedValue + "_" + (int)this.forme_2_4.SelectedIndex);
            }
            else
            {
                this.pbx_pl2_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl2_4.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl2_4.SelectedValue) == "1")
            {
                this.pictureBox8.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox8.Image = global::AHGE.Properties.Resources._a1;
            }
        }


        public void pl2_1_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_2_1.Items.Clear();

            switch ((int)this.pl2_1.SelectedValue)
            {
                case 172: //Pichu
                    forme_2_1.Items.Add("Normal");

                    if ((int)this.pl2_1.SelectedValue < 1)
                    {
                        forme_2_1.SelectedIndex = (int)this.pl2_1.SelectedValue;
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_2_1.Items.Add("A");
                    forme_2_1.Items.Add("B");
                    forme_2_1.Items.Add("C");
                    forme_2_1.Items.Add("D");
                    forme_2_1.Items.Add("E");
                    forme_2_1.Items.Add("F");
                    forme_2_1.Items.Add("G");
                    forme_2_1.Items.Add("H");
                    forme_2_1.Items.Add("I");
                    forme_2_1.Items.Add("J");
                    forme_2_1.Items.Add("K");
                    forme_2_1.Items.Add("L");
                    forme_2_1.Items.Add("M");
                    forme_2_1.Items.Add("N");
                    forme_2_1.Items.Add("O");
                    forme_2_1.Items.Add("P");
                    forme_2_1.Items.Add("Q");
                    forme_2_1.Items.Add("R");
                    forme_2_1.Items.Add("S");
                    forme_2_1.Items.Add("T");
                    forme_2_1.Items.Add("U");
                    forme_2_1.Items.Add("V");
                    forme_2_1.Items.Add("W");
                    forme_2_1.Items.Add("X");
                    forme_2_1.Items.Add("Y");
                    forme_2_1.Items.Add("Z");
                    forme_2_1.Items.Add("!");
                    forme_2_1.Items.Add("?");

                    if ((int)this.pl2_1.SelectedValue < 28)
                    {
                        forme_2_1.SelectedIndex = (int)this.pl2_1.SelectedValue;
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_2_1.Items.Add("Normal");
                    forme_2_1.Items.Add("Sunny Form");
                    forme_2_1.Items.Add("Rainy Form");
                    forme_2_1.Items.Add("Snowy Form");

                    if ((int)this.pl2_1.SelectedValue < 4)
                    {
                        forme_2_1.SelectedIndex = (int)this.pl2_1.SelectedValue;
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_2_1.Items.Add("Normal");
                    forme_2_1.Items.Add("Attack");
                    forme_2_1.Items.Add("Defense");
                    forme_2_1.Items.Add("Speed");

                    if ((int)this.pl2_1.SelectedValue < 4)
                    {
                        forme_2_1.SelectedIndex = (int)this.pl2_1.SelectedValue;
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_2_1.Items.Add("Plant");
                    forme_2_1.Items.Add("Sand");
                    forme_2_1.Items.Add("Trash");

                    if ((int)this.pl2_1.SelectedValue < 3)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_2_1.Items.Add("Overcast Form");
                    forme_2_1.Items.Add("Sunshine Form");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_2_1.Items.Add("West");
                    forme_2_1.Items.Add("East");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = (int)this.pl2_1.SelectedValue;
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_2_1.Items.Add("Normal");
                    forme_2_1.Items.Add("Heat");
                    forme_2_1.Items.Add("Wash");
                    forme_2_1.Items.Add("Frost");
                    forme_2_1.Items.Add("Spin");
                    forme_2_1.Items.Add("Cut");

                    if ((int)this.pl2_1.SelectedValue < 6)
                    {
                        forme_2_1.SelectedIndex = (int)this.pl2_1.SelectedValue;
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_2_1.Items.Add("Altered");
                    forme_2_1.Items.Add("Origin");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_2_1.Items.Add("Land");
                    forme_2_1.Items.Add("Sky");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_2_1.Items.Add("Normal");
                    forme_2_1.Items.Add("Fighting");
                    forme_2_1.Items.Add("Flying");
                    forme_2_1.Items.Add("Poison");
                    forme_2_1.Items.Add("Ground");
                    forme_2_1.Items.Add("Rock");
                    forme_2_1.Items.Add("Bug");
                    forme_2_1.Items.Add("Ghost");
                    forme_2_1.Items.Add("Steel");
                    forme_2_1.Items.Add("Fire");
                    forme_2_1.Items.Add("Water");
                    forme_2_1.Items.Add("Grass");
                    forme_2_1.Items.Add("Electric");
                    forme_2_1.Items.Add("Psychic");
                    forme_2_1.Items.Add("Ice");
                    forme_2_1.Items.Add("Dragon");
                    forme_2_1.Items.Add("Dark");

                    if ((int)this.pl2_1.SelectedValue < 18)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_2_1.Items.Add("Red-Striped");
                    forme_2_1.Items.Add("Blue-Striped");
                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_2_1.Items.Add("Normal");
                    forme_2_1.Items.Add("Zen mode");
                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_2_1.Items.Add("Spring Form");
                    forme_2_1.Items.Add("Summer Form");
                    forme_2_1.Items.Add("Autumn Form");
                    forme_2_1.Items.Add("Winter Form");

                    if ((int)this.pl2_1.SelectedValue < 4)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_2_1.Items.Add("Incarnate Forme");
                    forme_2_1.Items.Add("Therian Forme");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_2_1.Items.Add("Kyurem");
                    forme_2_1.Items.Add("White Kyurem");
                    forme_2_1.Items.Add("Black Kyurem");

                    if ((int)this.pl2_1.SelectedValue < 3)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_2_1.Items.Add("Ordinary Form");
                    forme_2_1.Items.Add("Resolute Form");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_2_1.Items.Add("Aria Forme");
                    forme_2_1.Items.Add("Pirouette Forme");

                    if ((int)this.pl2_1.SelectedValue < 2)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_2_1.Items.Add("Normal");
                    forme_2_1.Items.Add("1");
                    forme_2_1.Items.Add("2");
                    forme_2_1.Items.Add("3");
                    forme_2_1.Items.Add("4");

                    if ((int)this.pl2_1.SelectedValue < 5)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_2_1.Items.Add("Normal");

                    if ((int)this.pl2_1.SelectedValue < 1)
                    {
                        forme_2_1.SelectedIndex = ((int)this.pl2_1.SelectedValue);
                    }
                    else
                    {
                        forme_2_1.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl2_2_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_2_2.Items.Clear();

            switch ((int)this.pl2_2.SelectedValue)
            {
                case 172: //Pichu
                    forme_2_2.Items.Add("Normal");

                    if ((int)this.pl2_2.SelectedValue < 1)
                    {
                        forme_2_2.SelectedIndex = (int)this.pl2_2.SelectedValue;
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_2_2.Items.Add("A");
                    forme_2_2.Items.Add("B");
                    forme_2_2.Items.Add("C");
                    forme_2_2.Items.Add("D");
                    forme_2_2.Items.Add("E");
                    forme_2_2.Items.Add("F");
                    forme_2_2.Items.Add("G");
                    forme_2_2.Items.Add("H");
                    forme_2_2.Items.Add("I");
                    forme_2_2.Items.Add("J");
                    forme_2_2.Items.Add("K");
                    forme_2_2.Items.Add("L");
                    forme_2_2.Items.Add("M");
                    forme_2_2.Items.Add("N");
                    forme_2_2.Items.Add("O");
                    forme_2_2.Items.Add("P");
                    forme_2_2.Items.Add("Q");
                    forme_2_2.Items.Add("R");
                    forme_2_2.Items.Add("S");
                    forme_2_2.Items.Add("T");
                    forme_2_2.Items.Add("U");
                    forme_2_2.Items.Add("V");
                    forme_2_2.Items.Add("W");
                    forme_2_2.Items.Add("X");
                    forme_2_2.Items.Add("Y");
                    forme_2_2.Items.Add("Z");
                    forme_2_2.Items.Add("!");
                    forme_2_2.Items.Add("?");

                    if ((int)this.pl2_2.SelectedValue < 28)
                    {
                        forme_2_2.SelectedIndex = (int)this.pl2_2.SelectedValue;
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_2_2.Items.Add("Normal");
                    forme_2_2.Items.Add("Sunny Form");
                    forme_2_2.Items.Add("Rainy Form");
                    forme_2_2.Items.Add("Snowy Form");

                    if ((int)this.pl2_2.SelectedValue < 4)
                    {
                        forme_2_2.SelectedIndex = (int)this.pl2_2.SelectedValue;
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_2_2.Items.Add("Normal");
                    forme_2_2.Items.Add("Attack");
                    forme_2_2.Items.Add("Defense");
                    forme_2_2.Items.Add("Speed");

                    if ((int)this.pl2_2.SelectedValue < 4)
                    {
                        forme_2_2.SelectedIndex = (int)this.pl2_2.SelectedValue;
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_2_2.Items.Add("Plant");
                    forme_2_2.Items.Add("Sand");
                    forme_2_2.Items.Add("Trash");

                    if ((int)this.pl2_2.SelectedValue < 3)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_2_2.Items.Add("Overcast Form");
                    forme_2_2.Items.Add("Sunshine Form");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_2_2.Items.Add("West");
                    forme_2_2.Items.Add("East");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = (int)this.pl2_2.SelectedValue;
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_2_2.Items.Add("Normal");
                    forme_2_2.Items.Add("Heat");
                    forme_2_2.Items.Add("Wash");
                    forme_2_2.Items.Add("Frost");
                    forme_2_2.Items.Add("Spin");
                    forme_2_2.Items.Add("Cut");

                    if ((int)this.pl2_2.SelectedValue < 6)
                    {
                        forme_2_2.SelectedIndex = (int)this.pl2_2.SelectedValue;
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_2_2.Items.Add("Altered");
                    forme_2_2.Items.Add("Origin");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_2_2.Items.Add("Land");
                    forme_2_2.Items.Add("Sky");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_2_2.Items.Add("Normal");
                    forme_2_2.Items.Add("Fighting");
                    forme_2_2.Items.Add("Flying");
                    forme_2_2.Items.Add("Poison");
                    forme_2_2.Items.Add("Ground");
                    forme_2_2.Items.Add("Rock");
                    forme_2_2.Items.Add("Bug");
                    forme_2_2.Items.Add("Ghost");
                    forme_2_2.Items.Add("Steel");
                    forme_2_2.Items.Add("Fire");
                    forme_2_2.Items.Add("Water");
                    forme_2_2.Items.Add("Grass");
                    forme_2_2.Items.Add("Electric");
                    forme_2_2.Items.Add("Psychic");
                    forme_2_2.Items.Add("Ice");
                    forme_2_2.Items.Add("Dragon");
                    forme_2_2.Items.Add("Dark");

                    if ((int)this.pl2_2.SelectedValue < 18)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_2_2.Items.Add("Red-Striped");
                    forme_2_2.Items.Add("Blue-Striped");
                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_2_2.Items.Add("Normal");
                    forme_2_2.Items.Add("Zen mode");
                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_2_2.Items.Add("Spring Form");
                    forme_2_2.Items.Add("Summer Form");
                    forme_2_2.Items.Add("Autumn Form");
                    forme_2_2.Items.Add("Winter Form");

                    if ((int)this.pl2_2.SelectedValue < 4)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_2_2.Items.Add("Incarnate Forme");
                    forme_2_2.Items.Add("Therian Forme");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_2_2.Items.Add("Kyurem");
                    forme_2_2.Items.Add("White Kyurem");
                    forme_2_2.Items.Add("Black Kyurem");

                    if ((int)this.pl2_2.SelectedValue < 3)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_2_2.Items.Add("Ordinary Form");
                    forme_2_2.Items.Add("Resolute Form");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_2_2.Items.Add("Aria Forme");
                    forme_2_2.Items.Add("Pirouette Forme");

                    if ((int)this.pl2_2.SelectedValue < 2)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_2_2.Items.Add("Normal");
                    forme_2_2.Items.Add("1");
                    forme_2_2.Items.Add("2");
                    forme_2_2.Items.Add("3");
                    forme_2_2.Items.Add("4");

                    if ((int)this.pl2_2.SelectedValue < 5)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_2_2.Items.Add("Normal");

                    if ((int)this.pl2_2.SelectedValue < 1)
                    {
                        forme_2_2.SelectedIndex = ((int)this.pl2_2.SelectedValue);
                    }
                    else
                    {
                        forme_2_2.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl2_3_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_2_3.Items.Clear();

            switch ((int)this.pl2_3.SelectedValue)
            {
                case 172: //Pichu
                    forme_2_3.Items.Add("Normal");

                    if ((int)this.pl2_3.SelectedValue < 1)
                    {
                        forme_2_3.SelectedIndex = (int)this.pl2_3.SelectedValue;
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_2_3.Items.Add("A");
                    forme_2_3.Items.Add("B");
                    forme_2_3.Items.Add("C");
                    forme_2_3.Items.Add("D");
                    forme_2_3.Items.Add("E");
                    forme_2_3.Items.Add("F");
                    forme_2_3.Items.Add("G");
                    forme_2_3.Items.Add("H");
                    forme_2_3.Items.Add("I");
                    forme_2_3.Items.Add("J");
                    forme_2_3.Items.Add("K");
                    forme_2_3.Items.Add("L");
                    forme_2_3.Items.Add("M");
                    forme_2_3.Items.Add("N");
                    forme_2_3.Items.Add("O");
                    forme_2_3.Items.Add("P");
                    forme_2_3.Items.Add("Q");
                    forme_2_3.Items.Add("R");
                    forme_2_3.Items.Add("S");
                    forme_2_3.Items.Add("T");
                    forme_2_3.Items.Add("U");
                    forme_2_3.Items.Add("V");
                    forme_2_3.Items.Add("W");
                    forme_2_3.Items.Add("X");
                    forme_2_3.Items.Add("Y");
                    forme_2_3.Items.Add("Z");
                    forme_2_3.Items.Add("!");
                    forme_2_3.Items.Add("?");

                    if ((int)this.pl2_3.SelectedValue < 28)
                    {
                        forme_2_3.SelectedIndex = (int)this.pl2_3.SelectedValue;
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_2_3.Items.Add("Normal");
                    forme_2_3.Items.Add("Sunny Form");
                    forme_2_3.Items.Add("Rainy Form");
                    forme_2_3.Items.Add("Snowy Form");

                    if ((int)this.pl2_3.SelectedValue < 4)
                    {
                        forme_2_3.SelectedIndex = (int)this.pl2_3.SelectedValue;
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_2_3.Items.Add("Normal");
                    forme_2_3.Items.Add("Attack");
                    forme_2_3.Items.Add("Defense");
                    forme_2_3.Items.Add("Speed");

                    if ((int)this.pl2_3.SelectedValue < 4)
                    {
                        forme_2_3.SelectedIndex = (int)this.pl2_3.SelectedValue;
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_2_3.Items.Add("Plant");
                    forme_2_3.Items.Add("Sand");
                    forme_2_3.Items.Add("Trash");

                    if ((int)this.pl2_3.SelectedValue < 3)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_2_3.Items.Add("Overcast Form");
                    forme_2_3.Items.Add("Sunshine Form");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_2_3.Items.Add("West");
                    forme_2_3.Items.Add("East");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = (int)this.pl2_3.SelectedValue;
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_2_3.Items.Add("Normal");
                    forme_2_3.Items.Add("Heat");
                    forme_2_3.Items.Add("Wash");
                    forme_2_3.Items.Add("Frost");
                    forme_2_3.Items.Add("Spin");
                    forme_2_3.Items.Add("Cut");

                    if ((int)this.pl2_3.SelectedValue < 6)
                    {
                        forme_2_3.SelectedIndex = (int)this.pl2_3.SelectedValue;
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_2_3.Items.Add("Altered");
                    forme_2_3.Items.Add("Origin");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_2_3.Items.Add("Land");
                    forme_2_3.Items.Add("Sky");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_2_3.Items.Add("Normal");
                    forme_2_3.Items.Add("Fighting");
                    forme_2_3.Items.Add("Flying");
                    forme_2_3.Items.Add("Poison");
                    forme_2_3.Items.Add("Ground");
                    forme_2_3.Items.Add("Rock");
                    forme_2_3.Items.Add("Bug");
                    forme_2_3.Items.Add("Ghost");
                    forme_2_3.Items.Add("Steel");
                    forme_2_3.Items.Add("Fire");
                    forme_2_3.Items.Add("Water");
                    forme_2_3.Items.Add("Grass");
                    forme_2_3.Items.Add("Electric");
                    forme_2_3.Items.Add("Psychic");
                    forme_2_3.Items.Add("Ice");
                    forme_2_3.Items.Add("Dragon");
                    forme_2_3.Items.Add("Dark");

                    if ((int)this.pl2_3.SelectedValue < 18)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_2_3.Items.Add("Red-Striped");
                    forme_2_3.Items.Add("Blue-Striped");
                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_2_3.Items.Add("Normal");
                    forme_2_3.Items.Add("Zen mode");
                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_2_3.Items.Add("Spring Form");
                    forme_2_3.Items.Add("Summer Form");
                    forme_2_3.Items.Add("Autumn Form");
                    forme_2_3.Items.Add("Winter Form");

                    if ((int)this.pl2_3.SelectedValue < 4)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_2_3.Items.Add("Incarnate Forme");
                    forme_2_3.Items.Add("Therian Forme");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_2_3.Items.Add("Kyurem");
                    forme_2_3.Items.Add("White Kyurem");
                    forme_2_3.Items.Add("Black Kyurem");

                    if ((int)this.pl2_3.SelectedValue < 3)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_2_3.Items.Add("Ordinary Form");
                    forme_2_3.Items.Add("Resolute Form");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_2_3.Items.Add("Aria Forme");
                    forme_2_3.Items.Add("Pirouette Forme");

                    if ((int)this.pl2_3.SelectedValue < 2)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_2_3.Items.Add("Normal");
                    forme_2_3.Items.Add("1");
                    forme_2_3.Items.Add("2");
                    forme_2_3.Items.Add("3");
                    forme_2_3.Items.Add("4");

                    if ((int)this.pl2_3.SelectedValue < 5)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_2_3.Items.Add("Normal");

                    if ((int)this.pl2_3.SelectedValue < 1)
                    {
                        forme_2_3.SelectedIndex = ((int)this.pl2_3.SelectedValue);
                    }
                    else
                    {
                        forme_2_3.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl2_4_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_2_4.Items.Clear();

            switch ((int)this.pl2_4.SelectedValue)
            {
                case 172: //Pichu
                    forme_2_4.Items.Add("Normal");

                    if ((int)this.pl2_4.SelectedValue < 1)
                    {
                        forme_2_4.SelectedIndex = (int)this.pl2_4.SelectedValue;
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_2_4.Items.Add("A");
                    forme_2_4.Items.Add("B");
                    forme_2_4.Items.Add("C");
                    forme_2_4.Items.Add("D");
                    forme_2_4.Items.Add("E");
                    forme_2_4.Items.Add("F");
                    forme_2_4.Items.Add("G");
                    forme_2_4.Items.Add("H");
                    forme_2_4.Items.Add("I");
                    forme_2_4.Items.Add("J");
                    forme_2_4.Items.Add("K");
                    forme_2_4.Items.Add("L");
                    forme_2_4.Items.Add("M");
                    forme_2_4.Items.Add("N");
                    forme_2_4.Items.Add("O");
                    forme_2_4.Items.Add("P");
                    forme_2_4.Items.Add("Q");
                    forme_2_4.Items.Add("R");
                    forme_2_4.Items.Add("S");
                    forme_2_4.Items.Add("T");
                    forme_2_4.Items.Add("U");
                    forme_2_4.Items.Add("V");
                    forme_2_4.Items.Add("W");
                    forme_2_4.Items.Add("X");
                    forme_2_4.Items.Add("Y");
                    forme_2_4.Items.Add("Z");
                    forme_2_4.Items.Add("!");
                    forme_2_4.Items.Add("?");

                    if ((int)this.pl2_4.SelectedValue < 28)
                    {
                        forme_2_4.SelectedIndex = (int)this.pl2_4.SelectedValue;
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_2_4.Items.Add("Normal");
                    forme_2_4.Items.Add("Sunny Form");
                    forme_2_4.Items.Add("Rainy Form");
                    forme_2_4.Items.Add("Snowy Form");

                    if ((int)this.pl2_4.SelectedValue < 4)
                    {
                        forme_2_4.SelectedIndex = (int)this.pl2_4.SelectedValue;
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_2_4.Items.Add("Normal");
                    forme_2_4.Items.Add("Attack");
                    forme_2_4.Items.Add("Defense");
                    forme_2_4.Items.Add("Speed");

                    if ((int)this.pl2_4.SelectedValue < 4)
                    {
                        forme_2_4.SelectedIndex = (int)this.pl2_4.SelectedValue;
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_2_4.Items.Add("Plant");
                    forme_2_4.Items.Add("Sand");
                    forme_2_4.Items.Add("Trash");

                    if ((int)this.pl2_4.SelectedValue < 3)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_2_4.Items.Add("Overcast Form");
                    forme_2_4.Items.Add("Sunshine Form");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_2_4.Items.Add("West");
                    forme_2_4.Items.Add("East");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = (int)this.pl2_4.SelectedValue;
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_2_4.Items.Add("Normal");
                    forme_2_4.Items.Add("Heat");
                    forme_2_4.Items.Add("Wash");
                    forme_2_4.Items.Add("Frost");
                    forme_2_4.Items.Add("Spin");
                    forme_2_4.Items.Add("Cut");

                    if ((int)this.pl2_4.SelectedValue < 6)
                    {
                        forme_2_4.SelectedIndex = (int)this.pl2_4.SelectedValue;
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_2_4.Items.Add("Altered");
                    forme_2_4.Items.Add("Origin");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_2_4.Items.Add("Land");
                    forme_2_4.Items.Add("Sky");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_2_4.Items.Add("Normal");
                    forme_2_4.Items.Add("Fighting");
                    forme_2_4.Items.Add("Flying");
                    forme_2_4.Items.Add("Poison");
                    forme_2_4.Items.Add("Ground");
                    forme_2_4.Items.Add("Rock");
                    forme_2_4.Items.Add("Bug");
                    forme_2_4.Items.Add("Ghost");
                    forme_2_4.Items.Add("Steel");
                    forme_2_4.Items.Add("Fire");
                    forme_2_4.Items.Add("Water");
                    forme_2_4.Items.Add("Grass");
                    forme_2_4.Items.Add("Electric");
                    forme_2_4.Items.Add("Psychic");
                    forme_2_4.Items.Add("Ice");
                    forme_2_4.Items.Add("Dragon");
                    forme_2_4.Items.Add("Dark");

                    if ((int)this.pl2_4.SelectedValue < 18)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_2_4.Items.Add("Red-Striped");
                    forme_2_4.Items.Add("Blue-Striped");
                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_2_4.Items.Add("Normal");
                    forme_2_4.Items.Add("Zen mode");
                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_2_4.Items.Add("Spring Form");
                    forme_2_4.Items.Add("Summer Form");
                    forme_2_4.Items.Add("Autumn Form");
                    forme_2_4.Items.Add("Winter Form");

                    if ((int)this.pl2_4.SelectedValue < 4)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_2_4.Items.Add("Incarnate Forme");
                    forme_2_4.Items.Add("Therian Forme");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_2_4.Items.Add("Kyurem");
                    forme_2_4.Items.Add("White Kyurem");
                    forme_2_4.Items.Add("Black Kyurem");

                    if ((int)this.pl2_4.SelectedValue < 3)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_2_4.Items.Add("Ordinary Form");
                    forme_2_4.Items.Add("Resolute Form");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_2_4.Items.Add("Aria Forme");
                    forme_2_4.Items.Add("Pirouette Forme");

                    if ((int)this.pl2_4.SelectedValue < 2)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_2_4.Items.Add("Normal");
                    forme_2_4.Items.Add("1");
                    forme_2_4.Items.Add("2");
                    forme_2_4.Items.Add("3");
                    forme_2_4.Items.Add("4");

                    if ((int)this.pl2_4.SelectedValue < 5)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_2_4.Items.Add("Normal");

                    if ((int)this.pl2_4.SelectedValue < 1)
                    {
                        forme_2_4.SelectedIndex = ((int)this.pl2_4.SelectedValue);
                    }
                    else
                    {
                        forme_2_4.SelectedIndex = 0;
                    }
                    break;

            }
        }



        //W2 -3

        private void forme_3_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_3_1.SelectedIndex > 0)
            {
                this.pbx_pl3_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_1.SelectedValue + "_" + (int)this.forme_3_1.SelectedIndex);
            }
            else
            {
                this.pbx_pl3_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_1.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl3_1.SelectedValue) == "1")
            {
                this.pictureBox9.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox9.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_3_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_3_2.SelectedIndex > 0)
            {
                this.pbx_pl3_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_2.SelectedValue + "_" + (int)this.forme_3_2.SelectedIndex);
            }
            else
            {
                this.pbx_pl3_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_2.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl3_2.SelectedValue) == "1")
            {
                this.pictureBox10.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox10.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_3_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_3_3.SelectedIndex > 0)
            {
                this.pbx_pl3_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_3.SelectedValue + "_" + (int)this.forme_3_3.SelectedIndex);
            }
            else
            {
                this.pbx_pl3_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_3.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl3_3.SelectedValue) == "1")
            {
                this.pictureBox11.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox11.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_3_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_3_4.SelectedIndex > 0)
            {
                this.pbx_pl3_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_4.SelectedValue + "_" + (int)this.forme_3_4.SelectedIndex);
            }
            else
            {
                this.pbx_pl3_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl3_4.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl3_4.SelectedValue) == "1")
            {
                this.pictureBox12.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox12.Image = global::AHGE.Properties.Resources._a1;
            }
        }


        public void pl3_1_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_3_1.Items.Clear();

            switch ((int)this.pl3_1.SelectedValue)
            {
                case 172: //Pichu
                    forme_3_1.Items.Add("Normal");

                    if ((int)this.pl3_1.SelectedValue < 1)
                    {
                        forme_3_1.SelectedIndex = (int)this.pl3_1.SelectedValue;
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_3_1.Items.Add("A");
                    forme_3_1.Items.Add("B");
                    forme_3_1.Items.Add("C");
                    forme_3_1.Items.Add("D");
                    forme_3_1.Items.Add("E");
                    forme_3_1.Items.Add("F");
                    forme_3_1.Items.Add("G");
                    forme_3_1.Items.Add("H");
                    forme_3_1.Items.Add("I");
                    forme_3_1.Items.Add("J");
                    forme_3_1.Items.Add("K");
                    forme_3_1.Items.Add("L");
                    forme_3_1.Items.Add("M");
                    forme_3_1.Items.Add("N");
                    forme_3_1.Items.Add("O");
                    forme_3_1.Items.Add("P");
                    forme_3_1.Items.Add("Q");
                    forme_3_1.Items.Add("R");
                    forme_3_1.Items.Add("S");
                    forme_3_1.Items.Add("T");
                    forme_3_1.Items.Add("U");
                    forme_3_1.Items.Add("V");
                    forme_3_1.Items.Add("W");
                    forme_3_1.Items.Add("X");
                    forme_3_1.Items.Add("Y");
                    forme_3_1.Items.Add("Z");
                    forme_3_1.Items.Add("!");
                    forme_3_1.Items.Add("?");

                    if ((int)this.pl3_1.SelectedValue < 28)
                    {
                        forme_3_1.SelectedIndex = (int)this.pl3_1.SelectedValue;
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_3_1.Items.Add("Normal");
                    forme_3_1.Items.Add("Sunny Form");
                    forme_3_1.Items.Add("Rainy Form");
                    forme_3_1.Items.Add("Snowy Form");

                    if ((int)this.pl3_1.SelectedValue < 4)
                    {
                        forme_3_1.SelectedIndex = (int)this.pl3_1.SelectedValue;
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_3_1.Items.Add("Normal");
                    forme_3_1.Items.Add("Attack");
                    forme_3_1.Items.Add("Defense");
                    forme_3_1.Items.Add("Speed");

                    if ((int)this.pl3_1.SelectedValue < 4)
                    {
                        forme_3_1.SelectedIndex = (int)this.pl3_1.SelectedValue;
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_3_1.Items.Add("Plant");
                    forme_3_1.Items.Add("Sand");
                    forme_3_1.Items.Add("Trash");

                    if ((int)this.pl3_1.SelectedValue < 3)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_3_1.Items.Add("Overcast Form");
                    forme_3_1.Items.Add("Sunshine Form");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_3_1.Items.Add("West");
                    forme_3_1.Items.Add("East");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = (int)this.pl3_1.SelectedValue;
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_3_1.Items.Add("Normal");
                    forme_3_1.Items.Add("Heat");
                    forme_3_1.Items.Add("Wash");
                    forme_3_1.Items.Add("Frost");
                    forme_3_1.Items.Add("Spin");
                    forme_3_1.Items.Add("Cut");

                    if ((int)this.pl3_1.SelectedValue < 6)
                    {
                        forme_3_1.SelectedIndex = (int)this.pl3_1.SelectedValue;
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_3_1.Items.Add("Altered");
                    forme_3_1.Items.Add("Origin");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_3_1.Items.Add("Land");
                    forme_3_1.Items.Add("Sky");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_3_1.Items.Add("Normal");
                    forme_3_1.Items.Add("Fighting");
                    forme_3_1.Items.Add("Flying");
                    forme_3_1.Items.Add("Poison");
                    forme_3_1.Items.Add("Ground");
                    forme_3_1.Items.Add("Rock");
                    forme_3_1.Items.Add("Bug");
                    forme_3_1.Items.Add("Ghost");
                    forme_3_1.Items.Add("Steel");
                    forme_3_1.Items.Add("Fire");
                    forme_3_1.Items.Add("Water");
                    forme_3_1.Items.Add("Grass");
                    forme_3_1.Items.Add("Electric");
                    forme_3_1.Items.Add("Psychic");
                    forme_3_1.Items.Add("Ice");
                    forme_3_1.Items.Add("Dragon");
                    forme_3_1.Items.Add("Dark");

                    if ((int)this.pl3_1.SelectedValue < 18)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_3_1.Items.Add("Red-Striped");
                    forme_3_1.Items.Add("Blue-Striped");
                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_3_1.Items.Add("Normal");
                    forme_3_1.Items.Add("Zen mode");
                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_3_1.Items.Add("Spring Form");
                    forme_3_1.Items.Add("Summer Form");
                    forme_3_1.Items.Add("Autumn Form");
                    forme_3_1.Items.Add("Winter Form");

                    if ((int)this.pl3_1.SelectedValue < 4)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_3_1.Items.Add("Incarnate Forme");
                    forme_3_1.Items.Add("Therian Forme");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_3_1.Items.Add("Kyurem");
                    forme_3_1.Items.Add("White Kyurem");
                    forme_3_1.Items.Add("Black Kyurem");

                    if ((int)this.pl3_1.SelectedValue < 3)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_3_1.Items.Add("Ordinary Form");
                    forme_3_1.Items.Add("Resolute Form");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_3_1.Items.Add("Aria Forme");
                    forme_3_1.Items.Add("Pirouette Forme");

                    if ((int)this.pl3_1.SelectedValue < 2)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_3_1.Items.Add("Normal");
                    forme_3_1.Items.Add("1");
                    forme_3_1.Items.Add("2");
                    forme_3_1.Items.Add("3");
                    forme_3_1.Items.Add("4");

                    if ((int)this.pl3_1.SelectedValue < 5)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_3_1.Items.Add("Normal");

                    if ((int)this.pl3_1.SelectedValue < 1)
                    {
                        forme_3_1.SelectedIndex = ((int)this.pl3_1.SelectedValue);
                    }
                    else
                    {
                        forme_3_1.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl3_2_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_3_2.Items.Clear();

            switch ((int)this.pl3_2.SelectedValue)
            {
                case 172: //Pichu
                    forme_3_2.Items.Add("Normal");

                    if ((int)this.pl3_2.SelectedValue < 1)
                    {
                        forme_3_2.SelectedIndex = (int)this.pl3_2.SelectedValue;
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_3_2.Items.Add("A");
                    forme_3_2.Items.Add("B");
                    forme_3_2.Items.Add("C");
                    forme_3_2.Items.Add("D");
                    forme_3_2.Items.Add("E");
                    forme_3_2.Items.Add("F");
                    forme_3_2.Items.Add("G");
                    forme_3_2.Items.Add("H");
                    forme_3_2.Items.Add("I");
                    forme_3_2.Items.Add("J");
                    forme_3_2.Items.Add("K");
                    forme_3_2.Items.Add("L");
                    forme_3_2.Items.Add("M");
                    forme_3_2.Items.Add("N");
                    forme_3_2.Items.Add("O");
                    forme_3_2.Items.Add("P");
                    forme_3_2.Items.Add("Q");
                    forme_3_2.Items.Add("R");
                    forme_3_2.Items.Add("S");
                    forme_3_2.Items.Add("T");
                    forme_3_2.Items.Add("U");
                    forme_3_2.Items.Add("V");
                    forme_3_2.Items.Add("W");
                    forme_3_2.Items.Add("X");
                    forme_3_2.Items.Add("Y");
                    forme_3_2.Items.Add("Z");
                    forme_3_2.Items.Add("!");
                    forme_3_2.Items.Add("?");

                    if ((int)this.pl3_2.SelectedValue < 28)
                    {
                        forme_3_2.SelectedIndex = (int)this.pl3_2.SelectedValue;
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_3_2.Items.Add("Normal");
                    forme_3_2.Items.Add("Sunny Form");
                    forme_3_2.Items.Add("Rainy Form");
                    forme_3_2.Items.Add("Snowy Form");

                    if ((int)this.pl3_2.SelectedValue < 4)
                    {
                        forme_3_2.SelectedIndex = (int)this.pl3_2.SelectedValue;
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_3_2.Items.Add("Normal");
                    forme_3_2.Items.Add("Attack");
                    forme_3_2.Items.Add("Defense");
                    forme_3_2.Items.Add("Speed");

                    if ((int)this.pl3_2.SelectedValue < 4)
                    {
                        forme_3_2.SelectedIndex = (int)this.pl3_2.SelectedValue;
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_3_2.Items.Add("Plant");
                    forme_3_2.Items.Add("Sand");
                    forme_3_2.Items.Add("Trash");

                    if ((int)this.pl3_2.SelectedValue < 3)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_3_2.Items.Add("Overcast Form");
                    forme_3_2.Items.Add("Sunshine Form");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_3_2.Items.Add("West");
                    forme_3_2.Items.Add("East");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = (int)this.pl3_2.SelectedValue;
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_3_2.Items.Add("Normal");
                    forme_3_2.Items.Add("Heat");
                    forme_3_2.Items.Add("Wash");
                    forme_3_2.Items.Add("Frost");
                    forme_3_2.Items.Add("Spin");
                    forme_3_2.Items.Add("Cut");

                    if ((int)this.pl3_2.SelectedValue < 6)
                    {
                        forme_3_2.SelectedIndex = (int)this.pl3_2.SelectedValue;
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_3_2.Items.Add("Altered");
                    forme_3_2.Items.Add("Origin");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_3_2.Items.Add("Land");
                    forme_3_2.Items.Add("Sky");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_3_2.Items.Add("Normal");
                    forme_3_2.Items.Add("Fighting");
                    forme_3_2.Items.Add("Flying");
                    forme_3_2.Items.Add("Poison");
                    forme_3_2.Items.Add("Ground");
                    forme_3_2.Items.Add("Rock");
                    forme_3_2.Items.Add("Bug");
                    forme_3_2.Items.Add("Ghost");
                    forme_3_2.Items.Add("Steel");
                    forme_3_2.Items.Add("Fire");
                    forme_3_2.Items.Add("Water");
                    forme_3_2.Items.Add("Grass");
                    forme_3_2.Items.Add("Electric");
                    forme_3_2.Items.Add("Psychic");
                    forme_3_2.Items.Add("Ice");
                    forme_3_2.Items.Add("Dragon");
                    forme_3_2.Items.Add("Dark");

                    if ((int)this.pl3_2.SelectedValue < 18)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_3_2.Items.Add("Red-Striped");
                    forme_3_2.Items.Add("Blue-Striped");
                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_3_2.Items.Add("Normal");
                    forme_3_2.Items.Add("Zen mode");
                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_3_2.Items.Add("Spring Form");
                    forme_3_2.Items.Add("Summer Form");
                    forme_3_2.Items.Add("Autumn Form");
                    forme_3_2.Items.Add("Winter Form");

                    if ((int)this.pl3_2.SelectedValue < 4)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_3_2.Items.Add("Incarnate Forme");
                    forme_3_2.Items.Add("Therian Forme");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_3_2.Items.Add("Kyurem");
                    forme_3_2.Items.Add("White Kyurem");
                    forme_3_2.Items.Add("Black Kyurem");

                    if ((int)this.pl3_2.SelectedValue < 3)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_3_2.Items.Add("Ordinary Form");
                    forme_3_2.Items.Add("Resolute Form");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_3_2.Items.Add("Aria Forme");
                    forme_3_2.Items.Add("Pirouette Forme");

                    if ((int)this.pl3_2.SelectedValue < 2)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_3_2.Items.Add("Normal");
                    forme_3_2.Items.Add("1");
                    forme_3_2.Items.Add("2");
                    forme_3_2.Items.Add("3");
                    forme_3_2.Items.Add("4");

                    if ((int)this.pl3_2.SelectedValue < 5)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_3_2.Items.Add("Normal");

                    if ((int)this.pl3_2.SelectedValue < 1)
                    {
                        forme_3_2.SelectedIndex = ((int)this.pl3_2.SelectedValue);
                    }
                    else
                    {
                        forme_3_2.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl3_3_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_3_3.Items.Clear();

            switch ((int)this.pl3_3.SelectedValue)
            {
                case 172: //Pichu
                    forme_3_3.Items.Add("Normal");

                    if ((int)this.pl3_3.SelectedValue < 1)
                    {
                        forme_3_3.SelectedIndex = (int)this.pl3_3.SelectedValue;
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_3_3.Items.Add("A");
                    forme_3_3.Items.Add("B");
                    forme_3_3.Items.Add("C");
                    forme_3_3.Items.Add("D");
                    forme_3_3.Items.Add("E");
                    forme_3_3.Items.Add("F");
                    forme_3_3.Items.Add("G");
                    forme_3_3.Items.Add("H");
                    forme_3_3.Items.Add("I");
                    forme_3_3.Items.Add("J");
                    forme_3_3.Items.Add("K");
                    forme_3_3.Items.Add("L");
                    forme_3_3.Items.Add("M");
                    forme_3_3.Items.Add("N");
                    forme_3_3.Items.Add("O");
                    forme_3_3.Items.Add("P");
                    forme_3_3.Items.Add("Q");
                    forme_3_3.Items.Add("R");
                    forme_3_3.Items.Add("S");
                    forme_3_3.Items.Add("T");
                    forme_3_3.Items.Add("U");
                    forme_3_3.Items.Add("V");
                    forme_3_3.Items.Add("W");
                    forme_3_3.Items.Add("X");
                    forme_3_3.Items.Add("Y");
                    forme_3_3.Items.Add("Z");
                    forme_3_3.Items.Add("!");
                    forme_3_3.Items.Add("?");

                    if ((int)this.pl3_3.SelectedValue < 28)
                    {
                        forme_3_3.SelectedIndex = (int)this.pl3_3.SelectedValue;
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_3_3.Items.Add("Normal");
                    forme_3_3.Items.Add("Sunny Form");
                    forme_3_3.Items.Add("Rainy Form");
                    forme_3_3.Items.Add("Snowy Form");

                    if ((int)this.pl3_3.SelectedValue < 4)
                    {
                        forme_3_3.SelectedIndex = (int)this.pl3_3.SelectedValue;
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_3_3.Items.Add("Normal");
                    forme_3_3.Items.Add("Attack");
                    forme_3_3.Items.Add("Defense");
                    forme_3_3.Items.Add("Speed");

                    if ((int)this.pl3_3.SelectedValue < 4)
                    {
                        forme_3_3.SelectedIndex = (int)this.pl3_3.SelectedValue;
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_3_3.Items.Add("Plant");
                    forme_3_3.Items.Add("Sand");
                    forme_3_3.Items.Add("Trash");

                    if ((int)this.pl3_3.SelectedValue < 3)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_3_3.Items.Add("Overcast Form");
                    forme_3_3.Items.Add("Sunshine Form");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_3_3.Items.Add("West");
                    forme_3_3.Items.Add("East");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = (int)this.pl3_3.SelectedValue;
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_3_3.Items.Add("Normal");
                    forme_3_3.Items.Add("Heat");
                    forme_3_3.Items.Add("Wash");
                    forme_3_3.Items.Add("Frost");
                    forme_3_3.Items.Add("Spin");
                    forme_3_3.Items.Add("Cut");

                    if ((int)this.pl3_3.SelectedValue < 6)
                    {
                        forme_3_3.SelectedIndex = (int)this.pl3_3.SelectedValue;
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_3_3.Items.Add("Altered");
                    forme_3_3.Items.Add("Origin");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_3_3.Items.Add("Land");
                    forme_3_3.Items.Add("Sky");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_3_3.Items.Add("Normal");
                    forme_3_3.Items.Add("Fighting");
                    forme_3_3.Items.Add("Flying");
                    forme_3_3.Items.Add("Poison");
                    forme_3_3.Items.Add("Ground");
                    forme_3_3.Items.Add("Rock");
                    forme_3_3.Items.Add("Bug");
                    forme_3_3.Items.Add("Ghost");
                    forme_3_3.Items.Add("Steel");
                    forme_3_3.Items.Add("Fire");
                    forme_3_3.Items.Add("Water");
                    forme_3_3.Items.Add("Grass");
                    forme_3_3.Items.Add("Electric");
                    forme_3_3.Items.Add("Psychic");
                    forme_3_3.Items.Add("Ice");
                    forme_3_3.Items.Add("Dragon");
                    forme_3_3.Items.Add("Dark");

                    if ((int)this.pl3_3.SelectedValue < 18)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_3_3.Items.Add("Red-Striped");
                    forme_3_3.Items.Add("Blue-Striped");
                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_3_3.Items.Add("Normal");
                    forme_3_3.Items.Add("Zen mode");
                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_3_3.Items.Add("Spring Form");
                    forme_3_3.Items.Add("Summer Form");
                    forme_3_3.Items.Add("Autumn Form");
                    forme_3_3.Items.Add("Winter Form");

                    if ((int)this.pl3_3.SelectedValue < 4)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_3_3.Items.Add("Incarnate Forme");
                    forme_3_3.Items.Add("Therian Forme");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_3_3.Items.Add("Kyurem");
                    forme_3_3.Items.Add("White Kyurem");
                    forme_3_3.Items.Add("Black Kyurem");

                    if ((int)this.pl3_3.SelectedValue < 3)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_3_3.Items.Add("Ordinary Form");
                    forme_3_3.Items.Add("Resolute Form");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_3_3.Items.Add("Aria Forme");
                    forme_3_3.Items.Add("Pirouette Forme");

                    if ((int)this.pl3_3.SelectedValue < 2)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_3_3.Items.Add("Normal");
                    forme_3_3.Items.Add("1");
                    forme_3_3.Items.Add("2");
                    forme_3_3.Items.Add("3");
                    forme_3_3.Items.Add("4");

                    if ((int)this.pl3_3.SelectedValue < 5)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_3_3.Items.Add("Normal");

                    if ((int)this.pl3_3.SelectedValue < 1)
                    {
                        forme_3_3.SelectedIndex = ((int)this.pl3_3.SelectedValue);
                    }
                    else
                    {
                        forme_3_3.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl3_4_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_3_4.Items.Clear();

            switch ((int)this.pl3_4.SelectedValue)
            {
                case 172: //Pichu
                    forme_3_4.Items.Add("Normal");

                    if ((int)this.pl3_4.SelectedValue < 1)
                    {
                        forme_3_4.SelectedIndex = (int)this.pl3_4.SelectedValue;
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_3_4.Items.Add("A");
                    forme_3_4.Items.Add("B");
                    forme_3_4.Items.Add("C");
                    forme_3_4.Items.Add("D");
                    forme_3_4.Items.Add("E");
                    forme_3_4.Items.Add("F");
                    forme_3_4.Items.Add("G");
                    forme_3_4.Items.Add("H");
                    forme_3_4.Items.Add("I");
                    forme_3_4.Items.Add("J");
                    forme_3_4.Items.Add("K");
                    forme_3_4.Items.Add("L");
                    forme_3_4.Items.Add("M");
                    forme_3_4.Items.Add("N");
                    forme_3_4.Items.Add("O");
                    forme_3_4.Items.Add("P");
                    forme_3_4.Items.Add("Q");
                    forme_3_4.Items.Add("R");
                    forme_3_4.Items.Add("S");
                    forme_3_4.Items.Add("T");
                    forme_3_4.Items.Add("U");
                    forme_3_4.Items.Add("V");
                    forme_3_4.Items.Add("W");
                    forme_3_4.Items.Add("X");
                    forme_3_4.Items.Add("Y");
                    forme_3_4.Items.Add("Z");
                    forme_3_4.Items.Add("!");
                    forme_3_4.Items.Add("?");

                    if ((int)this.pl3_4.SelectedValue < 28)
                    {
                        forme_3_4.SelectedIndex = (int)this.pl3_4.SelectedValue;
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_3_4.Items.Add("Normal");
                    forme_3_4.Items.Add("Sunny Form");
                    forme_3_4.Items.Add("Rainy Form");
                    forme_3_4.Items.Add("Snowy Form");

                    if ((int)this.pl3_4.SelectedValue < 4)
                    {
                        forme_3_4.SelectedIndex = (int)this.pl3_4.SelectedValue;
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_3_4.Items.Add("Normal");
                    forme_3_4.Items.Add("Attack");
                    forme_3_4.Items.Add("Defense");
                    forme_3_4.Items.Add("Speed");

                    if ((int)this.pl3_4.SelectedValue < 4)
                    {
                        forme_3_4.SelectedIndex = (int)this.pl3_4.SelectedValue;
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_3_4.Items.Add("Plant");
                    forme_3_4.Items.Add("Sand");
                    forme_3_4.Items.Add("Trash");

                    if ((int)this.pl3_4.SelectedValue < 3)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_3_4.Items.Add("Overcast Form");
                    forme_3_4.Items.Add("Sunshine Form");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_3_4.Items.Add("West");
                    forme_3_4.Items.Add("East");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = (int)this.pl3_4.SelectedValue;
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_3_4.Items.Add("Normal");
                    forme_3_4.Items.Add("Heat");
                    forme_3_4.Items.Add("Wash");
                    forme_3_4.Items.Add("Frost");
                    forme_3_4.Items.Add("Spin");
                    forme_3_4.Items.Add("Cut");

                    if ((int)this.pl3_4.SelectedValue < 6)
                    {
                        forme_3_4.SelectedIndex = (int)this.pl3_4.SelectedValue;
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_3_4.Items.Add("Altered");
                    forme_3_4.Items.Add("Origin");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_3_4.Items.Add("Land");
                    forme_3_4.Items.Add("Sky");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_3_4.Items.Add("Normal");
                    forme_3_4.Items.Add("Fighting");
                    forme_3_4.Items.Add("Flying");
                    forme_3_4.Items.Add("Poison");
                    forme_3_4.Items.Add("Ground");
                    forme_3_4.Items.Add("Rock");
                    forme_3_4.Items.Add("Bug");
                    forme_3_4.Items.Add("Ghost");
                    forme_3_4.Items.Add("Steel");
                    forme_3_4.Items.Add("Fire");
                    forme_3_4.Items.Add("Water");
                    forme_3_4.Items.Add("Grass");
                    forme_3_4.Items.Add("Electric");
                    forme_3_4.Items.Add("Psychic");
                    forme_3_4.Items.Add("Ice");
                    forme_3_4.Items.Add("Dragon");
                    forme_3_4.Items.Add("Dark");

                    if ((int)this.pl3_4.SelectedValue < 18)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_3_4.Items.Add("Red-Striped");
                    forme_3_4.Items.Add("Blue-Striped");
                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_3_4.Items.Add("Normal");
                    forme_3_4.Items.Add("Zen mode");
                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_3_4.Items.Add("Spring Form");
                    forme_3_4.Items.Add("Summer Form");
                    forme_3_4.Items.Add("Autumn Form");
                    forme_3_4.Items.Add("Winter Form");

                    if ((int)this.pl3_4.SelectedValue < 4)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_3_4.Items.Add("Incarnate Forme");
                    forme_3_4.Items.Add("Therian Forme");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_3_4.Items.Add("Kyurem");
                    forme_3_4.Items.Add("White Kyurem");
                    forme_3_4.Items.Add("Black Kyurem");

                    if ((int)this.pl3_4.SelectedValue < 3)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_3_4.Items.Add("Ordinary Form");
                    forme_3_4.Items.Add("Resolute Form");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_3_4.Items.Add("Aria Forme");
                    forme_3_4.Items.Add("Pirouette Forme");

                    if ((int)this.pl3_4.SelectedValue < 2)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_3_4.Items.Add("Normal");
                    forme_3_4.Items.Add("1");
                    forme_3_4.Items.Add("2");
                    forme_3_4.Items.Add("3");
                    forme_3_4.Items.Add("4");

                    if ((int)this.pl3_4.SelectedValue < 5)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_3_4.Items.Add("Normal");

                    if ((int)this.pl3_4.SelectedValue < 1)
                    {
                        forme_3_4.SelectedIndex = ((int)this.pl3_4.SelectedValue);
                    }
                    else
                    {
                        forme_3_4.SelectedIndex = 0;
                    }
                    break;

            }
        }



        //B2 -1

        private void forme_4_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_4_1.SelectedIndex > 0)
            {
                this.pbx_pl4_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_1.SelectedValue + "_" + (int)this.forme_4_1.SelectedIndex);
            }
            else
            {
                this.pbx_pl4_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_1.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl4_1.SelectedValue) == "1")
            {
                this.pictureBox13.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox13.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_4_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_4_2.SelectedIndex > 0)
            {
                this.pbx_pl4_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_2.SelectedValue + "_" + (int)this.forme_4_2.SelectedIndex);
            }
            else
            {
                this.pbx_pl4_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_2.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl4_2.SelectedValue) == "1")
            {
                this.pictureBox14.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox14.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_4_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_4_3.SelectedIndex > 0)
            {
                this.pbx_pl4_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_3.SelectedValue + "_" + (int)this.forme_4_3.SelectedIndex);
            }
            else
            {
                this.pbx_pl4_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_3.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl4_3.SelectedValue) == "1")
            {
                this.pictureBox15.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox15.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_4_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_4_4.SelectedIndex > 0)
            {
                this.pbx_pl4_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_4.SelectedValue + "_" + (int)this.forme_4_4.SelectedIndex);
            }
            else
            {
                this.pbx_pl4_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl4_4.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl4_4.SelectedValue) == "1")
            {
                this.pictureBox16.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox16.Image = global::AHGE.Properties.Resources._a1;
            }
        }


        public void pl4_1_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_4_1.Items.Clear();

            switch ((int)this.pl4_1.SelectedValue)
            {
                case 172: //Pichu
                    forme_4_1.Items.Add("Normal");

                    if ((int)this.pl4_1.SelectedValue < 1)
                    {
                        forme_4_1.SelectedIndex = (int)this.pl4_1.SelectedValue;
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_4_1.Items.Add("A");
                    forme_4_1.Items.Add("B");
                    forme_4_1.Items.Add("C");
                    forme_4_1.Items.Add("D");
                    forme_4_1.Items.Add("E");
                    forme_4_1.Items.Add("F");
                    forme_4_1.Items.Add("G");
                    forme_4_1.Items.Add("H");
                    forme_4_1.Items.Add("I");
                    forme_4_1.Items.Add("J");
                    forme_4_1.Items.Add("K");
                    forme_4_1.Items.Add("L");
                    forme_4_1.Items.Add("M");
                    forme_4_1.Items.Add("N");
                    forme_4_1.Items.Add("O");
                    forme_4_1.Items.Add("P");
                    forme_4_1.Items.Add("Q");
                    forme_4_1.Items.Add("R");
                    forme_4_1.Items.Add("S");
                    forme_4_1.Items.Add("T");
                    forme_4_1.Items.Add("U");
                    forme_4_1.Items.Add("V");
                    forme_4_1.Items.Add("W");
                    forme_4_1.Items.Add("X");
                    forme_4_1.Items.Add("Y");
                    forme_4_1.Items.Add("Z");
                    forme_4_1.Items.Add("!");
                    forme_4_1.Items.Add("?");

                    if ((int)this.pl4_1.SelectedValue < 28)
                    {
                        forme_4_1.SelectedIndex = (int)this.pl4_1.SelectedValue;
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_4_1.Items.Add("Normal");
                    forme_4_1.Items.Add("Sunny Form");
                    forme_4_1.Items.Add("Rainy Form");
                    forme_4_1.Items.Add("Snowy Form");

                    if ((int)this.pl4_1.SelectedValue < 4)
                    {
                        forme_4_1.SelectedIndex = (int)this.pl4_1.SelectedValue;
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_4_1.Items.Add("Normal");
                    forme_4_1.Items.Add("Attack");
                    forme_4_1.Items.Add("Defense");
                    forme_4_1.Items.Add("Speed");

                    if ((int)this.pl4_1.SelectedValue < 4)
                    {
                        forme_4_1.SelectedIndex = (int)this.pl4_1.SelectedValue;
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_4_1.Items.Add("Plant");
                    forme_4_1.Items.Add("Sand");
                    forme_4_1.Items.Add("Trash");

                    if ((int)this.pl4_1.SelectedValue < 3)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_4_1.Items.Add("Overcast Form");
                    forme_4_1.Items.Add("Sunshine Form");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_4_1.Items.Add("West");
                    forme_4_1.Items.Add("East");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = (int)this.pl4_1.SelectedValue;
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_4_1.Items.Add("Normal");
                    forme_4_1.Items.Add("Heat");
                    forme_4_1.Items.Add("Wash");
                    forme_4_1.Items.Add("Frost");
                    forme_4_1.Items.Add("Spin");
                    forme_4_1.Items.Add("Cut");

                    if ((int)this.pl4_1.SelectedValue < 6)
                    {
                        forme_4_1.SelectedIndex = (int)this.pl4_1.SelectedValue;
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_4_1.Items.Add("Altered");
                    forme_4_1.Items.Add("Origin");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_4_1.Items.Add("Land");
                    forme_4_1.Items.Add("Sky");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_4_1.Items.Add("Normal");
                    forme_4_1.Items.Add("Fighting");
                    forme_4_1.Items.Add("Flying");
                    forme_4_1.Items.Add("Poison");
                    forme_4_1.Items.Add("Ground");
                    forme_4_1.Items.Add("Rock");
                    forme_4_1.Items.Add("Bug");
                    forme_4_1.Items.Add("Ghost");
                    forme_4_1.Items.Add("Steel");
                    forme_4_1.Items.Add("Fire");
                    forme_4_1.Items.Add("Water");
                    forme_4_1.Items.Add("Grass");
                    forme_4_1.Items.Add("Electric");
                    forme_4_1.Items.Add("Psychic");
                    forme_4_1.Items.Add("Ice");
                    forme_4_1.Items.Add("Dragon");
                    forme_4_1.Items.Add("Dark");

                    if ((int)this.pl4_1.SelectedValue < 18)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_4_1.Items.Add("Red-Striped");
                    forme_4_1.Items.Add("Blue-Striped");
                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_4_1.Items.Add("Normal");
                    forme_4_1.Items.Add("Zen mode");
                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_4_1.Items.Add("Spring Form");
                    forme_4_1.Items.Add("Summer Form");
                    forme_4_1.Items.Add("Autumn Form");
                    forme_4_1.Items.Add("Winter Form");

                    if ((int)this.pl4_1.SelectedValue < 4)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_4_1.Items.Add("Incarnate Forme");
                    forme_4_1.Items.Add("Therian Forme");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_4_1.Items.Add("Kyurem");
                    forme_4_1.Items.Add("White Kyurem");
                    forme_4_1.Items.Add("Black Kyurem");

                    if ((int)this.pl4_1.SelectedValue < 3)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_4_1.Items.Add("Ordinary Form");
                    forme_4_1.Items.Add("Resolute Form");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_4_1.Items.Add("Aria Forme");
                    forme_4_1.Items.Add("Pirouette Forme");

                    if ((int)this.pl4_1.SelectedValue < 2)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_4_1.Items.Add("Normal");
                    forme_4_1.Items.Add("1");
                    forme_4_1.Items.Add("2");
                    forme_4_1.Items.Add("3");
                    forme_4_1.Items.Add("4");

                    if ((int)this.pl4_1.SelectedValue < 5)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_4_1.Items.Add("Normal");

                    if ((int)this.pl4_1.SelectedValue < 1)
                    {
                        forme_4_1.SelectedIndex = ((int)this.pl4_1.SelectedValue);
                    }
                    else
                    {
                        forme_4_1.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl4_2_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_4_2.Items.Clear();

            switch ((int)this.pl4_2.SelectedValue)
            {
                case 172: //Pichu
                    forme_4_2.Items.Add("Normal");

                    if ((int)this.pl4_2.SelectedValue < 1)
                    {
                        forme_4_2.SelectedIndex = (int)this.pl4_2.SelectedValue;
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_4_2.Items.Add("A");
                    forme_4_2.Items.Add("B");
                    forme_4_2.Items.Add("C");
                    forme_4_2.Items.Add("D");
                    forme_4_2.Items.Add("E");
                    forme_4_2.Items.Add("F");
                    forme_4_2.Items.Add("G");
                    forme_4_2.Items.Add("H");
                    forme_4_2.Items.Add("I");
                    forme_4_2.Items.Add("J");
                    forme_4_2.Items.Add("K");
                    forme_4_2.Items.Add("L");
                    forme_4_2.Items.Add("M");
                    forme_4_2.Items.Add("N");
                    forme_4_2.Items.Add("O");
                    forme_4_2.Items.Add("P");
                    forme_4_2.Items.Add("Q");
                    forme_4_2.Items.Add("R");
                    forme_4_2.Items.Add("S");
                    forme_4_2.Items.Add("T");
                    forme_4_2.Items.Add("U");
                    forme_4_2.Items.Add("V");
                    forme_4_2.Items.Add("W");
                    forme_4_2.Items.Add("X");
                    forme_4_2.Items.Add("Y");
                    forme_4_2.Items.Add("Z");
                    forme_4_2.Items.Add("!");
                    forme_4_2.Items.Add("?");

                    if ((int)this.pl4_2.SelectedValue < 28)
                    {
                        forme_4_2.SelectedIndex = (int)this.pl4_2.SelectedValue;
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_4_2.Items.Add("Normal");
                    forme_4_2.Items.Add("Sunny Form");
                    forme_4_2.Items.Add("Rainy Form");
                    forme_4_2.Items.Add("Snowy Form");

                    if ((int)this.pl4_2.SelectedValue < 4)
                    {
                        forme_4_2.SelectedIndex = (int)this.pl4_2.SelectedValue;
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_4_2.Items.Add("Normal");
                    forme_4_2.Items.Add("Attack");
                    forme_4_2.Items.Add("Defense");
                    forme_4_2.Items.Add("Speed");

                    if ((int)this.pl4_2.SelectedValue < 4)
                    {
                        forme_4_2.SelectedIndex = (int)this.pl4_2.SelectedValue;
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_4_2.Items.Add("Plant");
                    forme_4_2.Items.Add("Sand");
                    forme_4_2.Items.Add("Trash");

                    if ((int)this.pl4_2.SelectedValue < 3)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_4_2.Items.Add("Overcast Form");
                    forme_4_2.Items.Add("Sunshine Form");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_4_2.Items.Add("West");
                    forme_4_2.Items.Add("East");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = (int)this.pl4_2.SelectedValue;
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_4_2.Items.Add("Normal");
                    forme_4_2.Items.Add("Heat");
                    forme_4_2.Items.Add("Wash");
                    forme_4_2.Items.Add("Frost");
                    forme_4_2.Items.Add("Spin");
                    forme_4_2.Items.Add("Cut");

                    if ((int)this.pl4_2.SelectedValue < 6)
                    {
                        forme_4_2.SelectedIndex = (int)this.pl4_2.SelectedValue;
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_4_2.Items.Add("Altered");
                    forme_4_2.Items.Add("Origin");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_4_2.Items.Add("Land");
                    forme_4_2.Items.Add("Sky");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_4_2.Items.Add("Normal");
                    forme_4_2.Items.Add("Fighting");
                    forme_4_2.Items.Add("Flying");
                    forme_4_2.Items.Add("Poison");
                    forme_4_2.Items.Add("Ground");
                    forme_4_2.Items.Add("Rock");
                    forme_4_2.Items.Add("Bug");
                    forme_4_2.Items.Add("Ghost");
                    forme_4_2.Items.Add("Steel");
                    forme_4_2.Items.Add("Fire");
                    forme_4_2.Items.Add("Water");
                    forme_4_2.Items.Add("Grass");
                    forme_4_2.Items.Add("Electric");
                    forme_4_2.Items.Add("Psychic");
                    forme_4_2.Items.Add("Ice");
                    forme_4_2.Items.Add("Dragon");
                    forme_4_2.Items.Add("Dark");

                    if ((int)this.pl4_2.SelectedValue < 18)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_4_2.Items.Add("Red-Striped");
                    forme_4_2.Items.Add("Blue-Striped");
                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_4_2.Items.Add("Normal");
                    forme_4_2.Items.Add("Zen mode");
                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_4_2.Items.Add("Spring Form");
                    forme_4_2.Items.Add("Summer Form");
                    forme_4_2.Items.Add("Autumn Form");
                    forme_4_2.Items.Add("Winter Form");

                    if ((int)this.pl4_2.SelectedValue < 4)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_4_2.Items.Add("Incarnate Forme");
                    forme_4_2.Items.Add("Therian Forme");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_4_2.Items.Add("Kyurem");
                    forme_4_2.Items.Add("White Kyurem");
                    forme_4_2.Items.Add("Black Kyurem");

                    if ((int)this.pl4_2.SelectedValue < 3)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_4_2.Items.Add("Ordinary Form");
                    forme_4_2.Items.Add("Resolute Form");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_4_2.Items.Add("Aria Forme");
                    forme_4_2.Items.Add("Pirouette Forme");

                    if ((int)this.pl4_2.SelectedValue < 2)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_4_2.Items.Add("Normal");
                    forme_4_2.Items.Add("1");
                    forme_4_2.Items.Add("2");
                    forme_4_2.Items.Add("3");
                    forme_4_2.Items.Add("4");

                    if ((int)this.pl4_2.SelectedValue < 5)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_4_2.Items.Add("Normal");

                    if ((int)this.pl4_2.SelectedValue < 1)
                    {
                        forme_4_2.SelectedIndex = ((int)this.pl4_2.SelectedValue);
                    }
                    else
                    {
                        forme_4_2.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl4_3_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_4_3.Items.Clear();

            switch ((int)this.pl4_3.SelectedValue)
            {
                case 172: //Pichu
                    forme_4_3.Items.Add("Normal");

                    if ((int)this.pl4_3.SelectedValue < 1)
                    {
                        forme_4_3.SelectedIndex = (int)this.pl4_3.SelectedValue;
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_4_3.Items.Add("A");
                    forme_4_3.Items.Add("B");
                    forme_4_3.Items.Add("C");
                    forme_4_3.Items.Add("D");
                    forme_4_3.Items.Add("E");
                    forme_4_3.Items.Add("F");
                    forme_4_3.Items.Add("G");
                    forme_4_3.Items.Add("H");
                    forme_4_3.Items.Add("I");
                    forme_4_3.Items.Add("J");
                    forme_4_3.Items.Add("K");
                    forme_4_3.Items.Add("L");
                    forme_4_3.Items.Add("M");
                    forme_4_3.Items.Add("N");
                    forme_4_3.Items.Add("O");
                    forme_4_3.Items.Add("P");
                    forme_4_3.Items.Add("Q");
                    forme_4_3.Items.Add("R");
                    forme_4_3.Items.Add("S");
                    forme_4_3.Items.Add("T");
                    forme_4_3.Items.Add("U");
                    forme_4_3.Items.Add("V");
                    forme_4_3.Items.Add("W");
                    forme_4_3.Items.Add("X");
                    forme_4_3.Items.Add("Y");
                    forme_4_3.Items.Add("Z");
                    forme_4_3.Items.Add("!");
                    forme_4_3.Items.Add("?");

                    if ((int)this.pl4_3.SelectedValue < 28)
                    {
                        forme_4_3.SelectedIndex = (int)this.pl4_3.SelectedValue;
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_4_3.Items.Add("Normal");
                    forme_4_3.Items.Add("Sunny Form");
                    forme_4_3.Items.Add("Rainy Form");
                    forme_4_3.Items.Add("Snowy Form");

                    if ((int)this.pl4_3.SelectedValue < 4)
                    {
                        forme_4_3.SelectedIndex = (int)this.pl4_3.SelectedValue;
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_4_3.Items.Add("Normal");
                    forme_4_3.Items.Add("Attack");
                    forme_4_3.Items.Add("Defense");
                    forme_4_3.Items.Add("Speed");

                    if ((int)this.pl4_3.SelectedValue < 4)
                    {
                        forme_4_3.SelectedIndex = (int)this.pl4_3.SelectedValue;
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_4_3.Items.Add("Plant");
                    forme_4_3.Items.Add("Sand");
                    forme_4_3.Items.Add("Trash");

                    if ((int)this.pl4_3.SelectedValue < 3)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_4_3.Items.Add("Overcast Form");
                    forme_4_3.Items.Add("Sunshine Form");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_4_3.Items.Add("West");
                    forme_4_3.Items.Add("East");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = (int)this.pl4_3.SelectedValue;
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_4_3.Items.Add("Normal");
                    forme_4_3.Items.Add("Heat");
                    forme_4_3.Items.Add("Wash");
                    forme_4_3.Items.Add("Frost");
                    forme_4_3.Items.Add("Spin");
                    forme_4_3.Items.Add("Cut");

                    if ((int)this.pl4_3.SelectedValue < 6)
                    {
                        forme_4_3.SelectedIndex = (int)this.pl4_3.SelectedValue;
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_4_3.Items.Add("Altered");
                    forme_4_3.Items.Add("Origin");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_4_3.Items.Add("Land");
                    forme_4_3.Items.Add("Sky");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_4_3.Items.Add("Normal");
                    forme_4_3.Items.Add("Fighting");
                    forme_4_3.Items.Add("Flying");
                    forme_4_3.Items.Add("Poison");
                    forme_4_3.Items.Add("Ground");
                    forme_4_3.Items.Add("Rock");
                    forme_4_3.Items.Add("Bug");
                    forme_4_3.Items.Add("Ghost");
                    forme_4_3.Items.Add("Steel");
                    forme_4_3.Items.Add("Fire");
                    forme_4_3.Items.Add("Water");
                    forme_4_3.Items.Add("Grass");
                    forme_4_3.Items.Add("Electric");
                    forme_4_3.Items.Add("Psychic");
                    forme_4_3.Items.Add("Ice");
                    forme_4_3.Items.Add("Dragon");
                    forme_4_3.Items.Add("Dark");

                    if ((int)this.pl4_3.SelectedValue < 18)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_4_3.Items.Add("Red-Striped");
                    forme_4_3.Items.Add("Blue-Striped");
                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_4_3.Items.Add("Normal");
                    forme_4_3.Items.Add("Zen mode");
                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_4_3.Items.Add("Spring Form");
                    forme_4_3.Items.Add("Summer Form");
                    forme_4_3.Items.Add("Autumn Form");
                    forme_4_3.Items.Add("Winter Form");

                    if ((int)this.pl4_3.SelectedValue < 4)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_4_3.Items.Add("Incarnate Forme");
                    forme_4_3.Items.Add("Therian Forme");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_4_3.Items.Add("Kyurem");
                    forme_4_3.Items.Add("White Kyurem");
                    forme_4_3.Items.Add("Black Kyurem");

                    if ((int)this.pl4_3.SelectedValue < 3)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_4_3.Items.Add("Ordinary Form");
                    forme_4_3.Items.Add("Resolute Form");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_4_3.Items.Add("Aria Forme");
                    forme_4_3.Items.Add("Pirouette Forme");

                    if ((int)this.pl4_3.SelectedValue < 2)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_4_3.Items.Add("Normal");
                    forme_4_3.Items.Add("1");
                    forme_4_3.Items.Add("2");
                    forme_4_3.Items.Add("3");
                    forme_4_3.Items.Add("4");

                    if ((int)this.pl4_3.SelectedValue < 5)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_4_3.Items.Add("Normal");

                    if ((int)this.pl4_3.SelectedValue < 1)
                    {
                        forme_4_3.SelectedIndex = ((int)this.pl4_3.SelectedValue);
                    }
                    else
                    {
                        forme_4_3.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl4_4_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_4_4.Items.Clear();

            switch ((int)this.pl4_4.SelectedValue)
            {
                case 172: //Pichu
                    forme_4_4.Items.Add("Normal");

                    if ((int)this.pl4_4.SelectedValue < 1)
                    {
                        forme_4_4.SelectedIndex = (int)this.pl4_4.SelectedValue;
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_4_4.Items.Add("A");
                    forme_4_4.Items.Add("B");
                    forme_4_4.Items.Add("C");
                    forme_4_4.Items.Add("D");
                    forme_4_4.Items.Add("E");
                    forme_4_4.Items.Add("F");
                    forme_4_4.Items.Add("G");
                    forme_4_4.Items.Add("H");
                    forme_4_4.Items.Add("I");
                    forme_4_4.Items.Add("J");
                    forme_4_4.Items.Add("K");
                    forme_4_4.Items.Add("L");
                    forme_4_4.Items.Add("M");
                    forme_4_4.Items.Add("N");
                    forme_4_4.Items.Add("O");
                    forme_4_4.Items.Add("P");
                    forme_4_4.Items.Add("Q");
                    forme_4_4.Items.Add("R");
                    forme_4_4.Items.Add("S");
                    forme_4_4.Items.Add("T");
                    forme_4_4.Items.Add("U");
                    forme_4_4.Items.Add("V");
                    forme_4_4.Items.Add("W");
                    forme_4_4.Items.Add("X");
                    forme_4_4.Items.Add("Y");
                    forme_4_4.Items.Add("Z");
                    forme_4_4.Items.Add("!");
                    forme_4_4.Items.Add("?");

                    if ((int)this.pl4_4.SelectedValue < 28)
                    {
                        forme_4_4.SelectedIndex = (int)this.pl4_4.SelectedValue;
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_4_4.Items.Add("Normal");
                    forme_4_4.Items.Add("Sunny Form");
                    forme_4_4.Items.Add("Rainy Form");
                    forme_4_4.Items.Add("Snowy Form");

                    if ((int)this.pl4_4.SelectedValue < 4)
                    {
                        forme_4_4.SelectedIndex = (int)this.pl4_4.SelectedValue;
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_4_4.Items.Add("Normal");
                    forme_4_4.Items.Add("Attack");
                    forme_4_4.Items.Add("Defense");
                    forme_4_4.Items.Add("Speed");

                    if ((int)this.pl4_4.SelectedValue < 4)
                    {
                        forme_4_4.SelectedIndex = (int)this.pl4_4.SelectedValue;
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_4_4.Items.Add("Plant");
                    forme_4_4.Items.Add("Sand");
                    forme_4_4.Items.Add("Trash");

                    if ((int)this.pl4_4.SelectedValue < 3)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_4_4.Items.Add("Overcast Form");
                    forme_4_4.Items.Add("Sunshine Form");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_4_4.Items.Add("West");
                    forme_4_4.Items.Add("East");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = (int)this.pl4_4.SelectedValue;
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_4_4.Items.Add("Normal");
                    forme_4_4.Items.Add("Heat");
                    forme_4_4.Items.Add("Wash");
                    forme_4_4.Items.Add("Frost");
                    forme_4_4.Items.Add("Spin");
                    forme_4_4.Items.Add("Cut");

                    if ((int)this.pl4_4.SelectedValue < 6)
                    {
                        forme_4_4.SelectedIndex = (int)this.pl4_4.SelectedValue;
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_4_4.Items.Add("Altered");
                    forme_4_4.Items.Add("Origin");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_4_4.Items.Add("Land");
                    forme_4_4.Items.Add("Sky");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_4_4.Items.Add("Normal");
                    forme_4_4.Items.Add("Fighting");
                    forme_4_4.Items.Add("Flying");
                    forme_4_4.Items.Add("Poison");
                    forme_4_4.Items.Add("Ground");
                    forme_4_4.Items.Add("Rock");
                    forme_4_4.Items.Add("Bug");
                    forme_4_4.Items.Add("Ghost");
                    forme_4_4.Items.Add("Steel");
                    forme_4_4.Items.Add("Fire");
                    forme_4_4.Items.Add("Water");
                    forme_4_4.Items.Add("Grass");
                    forme_4_4.Items.Add("Electric");
                    forme_4_4.Items.Add("Psychic");
                    forme_4_4.Items.Add("Ice");
                    forme_4_4.Items.Add("Dragon");
                    forme_4_4.Items.Add("Dark");

                    if ((int)this.pl4_4.SelectedValue < 18)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_4_4.Items.Add("Red-Striped");
                    forme_4_4.Items.Add("Blue-Striped");
                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_4_4.Items.Add("Normal");
                    forme_4_4.Items.Add("Zen mode");
                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_4_4.Items.Add("Spring Form");
                    forme_4_4.Items.Add("Summer Form");
                    forme_4_4.Items.Add("Autumn Form");
                    forme_4_4.Items.Add("Winter Form");

                    if ((int)this.pl4_4.SelectedValue < 4)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_4_4.Items.Add("Incarnate Forme");
                    forme_4_4.Items.Add("Therian Forme");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_4_4.Items.Add("Kyurem");
                    forme_4_4.Items.Add("White Kyurem");
                    forme_4_4.Items.Add("Black Kyurem");

                    if ((int)this.pl4_4.SelectedValue < 3)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_4_4.Items.Add("Ordinary Form");
                    forme_4_4.Items.Add("Resolute Form");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_4_4.Items.Add("Aria Forme");
                    forme_4_4.Items.Add("Pirouette Forme");

                    if ((int)this.pl4_4.SelectedValue < 2)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_4_4.Items.Add("Normal");
                    forme_4_4.Items.Add("1");
                    forme_4_4.Items.Add("2");
                    forme_4_4.Items.Add("3");
                    forme_4_4.Items.Add("4");

                    if ((int)this.pl4_4.SelectedValue < 5)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_4_4.Items.Add("Normal");

                    if ((int)this.pl4_4.SelectedValue < 1)
                    {
                        forme_4_4.SelectedIndex = ((int)this.pl4_4.SelectedValue);
                    }
                    else
                    {
                        forme_4_4.SelectedIndex = 0;
                    }
                    break;

            }
        }



        //B2 -2

        private void forme_5_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_5_1.SelectedIndex > 0)
            {
                this.pbx_pl5_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_1.SelectedValue + "_" + (int)this.forme_5_1.SelectedIndex);
            }
            else
            {
                this.pbx_pl5_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_1.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl5_1.SelectedValue) == "1")
            {
                this.pictureBox17.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox17.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_5_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_5_2.SelectedIndex > 0)
            {
                this.pbx_pl5_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_2.SelectedValue + "_" + (int)this.forme_5_2.SelectedIndex);
            }
            else
            {
                this.pbx_pl5_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_2.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl5_2.SelectedValue) == "1")
            {
                this.pictureBox18.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox18.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_5_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_5_3.SelectedIndex > 0)
            {
                this.pbx_pl5_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_3.SelectedValue + "_" + (int)this.forme_5_3.SelectedIndex);
            }
            else
            {
                this.pbx_pl5_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_3.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl5_3.SelectedValue) == "1")
            {
                this.pictureBox19.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox19.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_5_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_5_4.SelectedIndex > 0)
            {
                this.pbx_pl5_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_4.SelectedValue + "_" + (int)this.forme_5_4.SelectedIndex);
            }
            else
            {
                this.pbx_pl5_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl5_4.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl5_4.SelectedValue) == "1")
            {
                this.pictureBox20.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox20.Image = global::AHGE.Properties.Resources._a1;
            }
        }


        public void pl5_1_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_5_1.Items.Clear();

            switch ((int)this.pl5_1.SelectedValue)
            {
                case 172: //Pichu
                    forme_5_1.Items.Add("Normal");

                    if ((int)this.pl5_1.SelectedValue < 1)
                    {
                        forme_5_1.SelectedIndex = (int)this.pl5_1.SelectedValue;
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_5_1.Items.Add("A");
                    forme_5_1.Items.Add("B");
                    forme_5_1.Items.Add("C");
                    forme_5_1.Items.Add("D");
                    forme_5_1.Items.Add("E");
                    forme_5_1.Items.Add("F");
                    forme_5_1.Items.Add("G");
                    forme_5_1.Items.Add("H");
                    forme_5_1.Items.Add("I");
                    forme_5_1.Items.Add("J");
                    forme_5_1.Items.Add("K");
                    forme_5_1.Items.Add("L");
                    forme_5_1.Items.Add("M");
                    forme_5_1.Items.Add("N");
                    forme_5_1.Items.Add("O");
                    forme_5_1.Items.Add("P");
                    forme_5_1.Items.Add("Q");
                    forme_5_1.Items.Add("R");
                    forme_5_1.Items.Add("S");
                    forme_5_1.Items.Add("T");
                    forme_5_1.Items.Add("U");
                    forme_5_1.Items.Add("V");
                    forme_5_1.Items.Add("W");
                    forme_5_1.Items.Add("X");
                    forme_5_1.Items.Add("Y");
                    forme_5_1.Items.Add("Z");
                    forme_5_1.Items.Add("!");
                    forme_5_1.Items.Add("?");

                    if ((int)this.pl5_1.SelectedValue < 28)
                    {
                        forme_5_1.SelectedIndex = (int)this.pl5_1.SelectedValue;
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_5_1.Items.Add("Normal");
                    forme_5_1.Items.Add("Sunny Form");
                    forme_5_1.Items.Add("Rainy Form");
                    forme_5_1.Items.Add("Snowy Form");

                    if ((int)this.pl5_1.SelectedValue < 4)
                    {
                        forme_5_1.SelectedIndex = (int)this.pl5_1.SelectedValue;
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_5_1.Items.Add("Normal");
                    forme_5_1.Items.Add("Attack");
                    forme_5_1.Items.Add("Defense");
                    forme_5_1.Items.Add("Speed");

                    if ((int)this.pl5_1.SelectedValue < 4)
                    {
                        forme_5_1.SelectedIndex = (int)this.pl5_1.SelectedValue;
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_5_1.Items.Add("Plant");
                    forme_5_1.Items.Add("Sand");
                    forme_5_1.Items.Add("Trash");

                    if ((int)this.pl5_1.SelectedValue < 3)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_5_1.Items.Add("Overcast Form");
                    forme_5_1.Items.Add("Sunshine Form");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_5_1.Items.Add("West");
                    forme_5_1.Items.Add("East");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = (int)this.pl5_1.SelectedValue;
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_5_1.Items.Add("Normal");
                    forme_5_1.Items.Add("Heat");
                    forme_5_1.Items.Add("Wash");
                    forme_5_1.Items.Add("Frost");
                    forme_5_1.Items.Add("Spin");
                    forme_5_1.Items.Add("Cut");

                    if ((int)this.pl5_1.SelectedValue < 6)
                    {
                        forme_5_1.SelectedIndex = (int)this.pl5_1.SelectedValue;
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_5_1.Items.Add("Altered");
                    forme_5_1.Items.Add("Origin");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_5_1.Items.Add("Land");
                    forme_5_1.Items.Add("Sky");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_5_1.Items.Add("Normal");
                    forme_5_1.Items.Add("Fighting");
                    forme_5_1.Items.Add("Flying");
                    forme_5_1.Items.Add("Poison");
                    forme_5_1.Items.Add("Ground");
                    forme_5_1.Items.Add("Rock");
                    forme_5_1.Items.Add("Bug");
                    forme_5_1.Items.Add("Ghost");
                    forme_5_1.Items.Add("Steel");
                    forme_5_1.Items.Add("Fire");
                    forme_5_1.Items.Add("Water");
                    forme_5_1.Items.Add("Grass");
                    forme_5_1.Items.Add("Electric");
                    forme_5_1.Items.Add("Psychic");
                    forme_5_1.Items.Add("Ice");
                    forme_5_1.Items.Add("Dragon");
                    forme_5_1.Items.Add("Dark");

                    if ((int)this.pl5_1.SelectedValue < 18)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_5_1.Items.Add("Red-Striped");
                    forme_5_1.Items.Add("Blue-Striped");
                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_5_1.Items.Add("Normal");
                    forme_5_1.Items.Add("Zen mode");
                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_5_1.Items.Add("Spring Form");
                    forme_5_1.Items.Add("Summer Form");
                    forme_5_1.Items.Add("Autumn Form");
                    forme_5_1.Items.Add("Winter Form");

                    if ((int)this.pl5_1.SelectedValue < 4)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_5_1.Items.Add("Incarnate Forme");
                    forme_5_1.Items.Add("Therian Forme");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_5_1.Items.Add("Kyurem");
                    forme_5_1.Items.Add("White Kyurem");
                    forme_5_1.Items.Add("Black Kyurem");

                    if ((int)this.pl5_1.SelectedValue < 3)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_5_1.Items.Add("Ordinary Form");
                    forme_5_1.Items.Add("Resolute Form");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_5_1.Items.Add("Aria Forme");
                    forme_5_1.Items.Add("Pirouette Forme");

                    if ((int)this.pl5_1.SelectedValue < 2)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_5_1.Items.Add("Normal");
                    forme_5_1.Items.Add("1");
                    forme_5_1.Items.Add("2");
                    forme_5_1.Items.Add("3");
                    forme_5_1.Items.Add("4");

                    if ((int)this.pl5_1.SelectedValue < 5)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_5_1.Items.Add("Normal");

                    if ((int)this.pl5_1.SelectedValue < 1)
                    {
                        forme_5_1.SelectedIndex = ((int)this.pl5_1.SelectedValue);
                    }
                    else
                    {
                        forme_5_1.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl5_2_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_5_2.Items.Clear();

            switch ((int)this.pl5_2.SelectedValue)
            {
                case 172: //Pichu
                    forme_5_2.Items.Add("Normal");

                    if ((int)this.pl5_2.SelectedValue < 1)
                    {
                        forme_5_2.SelectedIndex = (int)this.pl5_2.SelectedValue;
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_5_2.Items.Add("A");
                    forme_5_2.Items.Add("B");
                    forme_5_2.Items.Add("C");
                    forme_5_2.Items.Add("D");
                    forme_5_2.Items.Add("E");
                    forme_5_2.Items.Add("F");
                    forme_5_2.Items.Add("G");
                    forme_5_2.Items.Add("H");
                    forme_5_2.Items.Add("I");
                    forme_5_2.Items.Add("J");
                    forme_5_2.Items.Add("K");
                    forme_5_2.Items.Add("L");
                    forme_5_2.Items.Add("M");
                    forme_5_2.Items.Add("N");
                    forme_5_2.Items.Add("O");
                    forme_5_2.Items.Add("P");
                    forme_5_2.Items.Add("Q");
                    forme_5_2.Items.Add("R");
                    forme_5_2.Items.Add("S");
                    forme_5_2.Items.Add("T");
                    forme_5_2.Items.Add("U");
                    forme_5_2.Items.Add("V");
                    forme_5_2.Items.Add("W");
                    forme_5_2.Items.Add("X");
                    forme_5_2.Items.Add("Y");
                    forme_5_2.Items.Add("Z");
                    forme_5_2.Items.Add("!");
                    forme_5_2.Items.Add("?");

                    if ((int)this.pl5_2.SelectedValue < 28)
                    {
                        forme_5_2.SelectedIndex = (int)this.pl5_2.SelectedValue;
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_5_2.Items.Add("Normal");
                    forme_5_2.Items.Add("Sunny Form");
                    forme_5_2.Items.Add("Rainy Form");
                    forme_5_2.Items.Add("Snowy Form");

                    if ((int)this.pl5_2.SelectedValue < 4)
                    {
                        forme_5_2.SelectedIndex = (int)this.pl5_2.SelectedValue;
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_5_2.Items.Add("Normal");
                    forme_5_2.Items.Add("Attack");
                    forme_5_2.Items.Add("Defense");
                    forme_5_2.Items.Add("Speed");

                    if ((int)this.pl5_2.SelectedValue < 4)
                    {
                        forme_5_2.SelectedIndex = (int)this.pl5_2.SelectedValue;
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_5_2.Items.Add("Plant");
                    forme_5_2.Items.Add("Sand");
                    forme_5_2.Items.Add("Trash");

                    if ((int)this.pl5_2.SelectedValue < 3)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_5_2.Items.Add("Overcast Form");
                    forme_5_2.Items.Add("Sunshine Form");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_5_2.Items.Add("West");
                    forme_5_2.Items.Add("East");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = (int)this.pl5_2.SelectedValue;
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_5_2.Items.Add("Normal");
                    forme_5_2.Items.Add("Heat");
                    forme_5_2.Items.Add("Wash");
                    forme_5_2.Items.Add("Frost");
                    forme_5_2.Items.Add("Spin");
                    forme_5_2.Items.Add("Cut");

                    if ((int)this.pl5_2.SelectedValue < 6)
                    {
                        forme_5_2.SelectedIndex = (int)this.pl5_2.SelectedValue;
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_5_2.Items.Add("Altered");
                    forme_5_2.Items.Add("Origin");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_5_2.Items.Add("Land");
                    forme_5_2.Items.Add("Sky");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_5_2.Items.Add("Normal");
                    forme_5_2.Items.Add("Fighting");
                    forme_5_2.Items.Add("Flying");
                    forme_5_2.Items.Add("Poison");
                    forme_5_2.Items.Add("Ground");
                    forme_5_2.Items.Add("Rock");
                    forme_5_2.Items.Add("Bug");
                    forme_5_2.Items.Add("Ghost");
                    forme_5_2.Items.Add("Steel");
                    forme_5_2.Items.Add("Fire");
                    forme_5_2.Items.Add("Water");
                    forme_5_2.Items.Add("Grass");
                    forme_5_2.Items.Add("Electric");
                    forme_5_2.Items.Add("Psychic");
                    forme_5_2.Items.Add("Ice");
                    forme_5_2.Items.Add("Dragon");
                    forme_5_2.Items.Add("Dark");

                    if ((int)this.pl5_2.SelectedValue < 18)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_5_2.Items.Add("Red-Striped");
                    forme_5_2.Items.Add("Blue-Striped");
                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_5_2.Items.Add("Normal");
                    forme_5_2.Items.Add("Zen mode");
                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_5_2.Items.Add("Spring Form");
                    forme_5_2.Items.Add("Summer Form");
                    forme_5_2.Items.Add("Autumn Form");
                    forme_5_2.Items.Add("Winter Form");

                    if ((int)this.pl5_2.SelectedValue < 4)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_5_2.Items.Add("Incarnate Forme");
                    forme_5_2.Items.Add("Therian Forme");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_5_2.Items.Add("Kyurem");
                    forme_5_2.Items.Add("White Kyurem");
                    forme_5_2.Items.Add("Black Kyurem");

                    if ((int)this.pl5_2.SelectedValue < 3)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_5_2.Items.Add("Ordinary Form");
                    forme_5_2.Items.Add("Resolute Form");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_5_2.Items.Add("Aria Forme");
                    forme_5_2.Items.Add("Pirouette Forme");

                    if ((int)this.pl5_2.SelectedValue < 2)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_5_2.Items.Add("Normal");
                    forme_5_2.Items.Add("1");
                    forme_5_2.Items.Add("2");
                    forme_5_2.Items.Add("3");
                    forme_5_2.Items.Add("4");

                    if ((int)this.pl5_2.SelectedValue < 5)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_5_2.Items.Add("Normal");

                    if ((int)this.pl5_2.SelectedValue < 1)
                    {
                        forme_5_2.SelectedIndex = ((int)this.pl5_2.SelectedValue);
                    }
                    else
                    {
                        forme_5_2.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl5_3_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_5_3.Items.Clear();

            switch ((int)this.pl5_3.SelectedValue)
            {
                case 172: //Pichu
                    forme_5_3.Items.Add("Normal");

                    if ((int)this.pl5_3.SelectedValue < 1)
                    {
                        forme_5_3.SelectedIndex = (int)this.pl5_3.SelectedValue;
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_5_3.Items.Add("A");
                    forme_5_3.Items.Add("B");
                    forme_5_3.Items.Add("C");
                    forme_5_3.Items.Add("D");
                    forme_5_3.Items.Add("E");
                    forme_5_3.Items.Add("F");
                    forme_5_3.Items.Add("G");
                    forme_5_3.Items.Add("H");
                    forme_5_3.Items.Add("I");
                    forme_5_3.Items.Add("J");
                    forme_5_3.Items.Add("K");
                    forme_5_3.Items.Add("L");
                    forme_5_3.Items.Add("M");
                    forme_5_3.Items.Add("N");
                    forme_5_3.Items.Add("O");
                    forme_5_3.Items.Add("P");
                    forme_5_3.Items.Add("Q");
                    forme_5_3.Items.Add("R");
                    forme_5_3.Items.Add("S");
                    forme_5_3.Items.Add("T");
                    forme_5_3.Items.Add("U");
                    forme_5_3.Items.Add("V");
                    forme_5_3.Items.Add("W");
                    forme_5_3.Items.Add("X");
                    forme_5_3.Items.Add("Y");
                    forme_5_3.Items.Add("Z");
                    forme_5_3.Items.Add("!");
                    forme_5_3.Items.Add("?");

                    if ((int)this.pl5_3.SelectedValue < 28)
                    {
                        forme_5_3.SelectedIndex = (int)this.pl5_3.SelectedValue;
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_5_3.Items.Add("Normal");
                    forme_5_3.Items.Add("Sunny Form");
                    forme_5_3.Items.Add("Rainy Form");
                    forme_5_3.Items.Add("Snowy Form");

                    if ((int)this.pl5_3.SelectedValue < 4)
                    {
                        forme_5_3.SelectedIndex = (int)this.pl5_3.SelectedValue;
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_5_3.Items.Add("Normal");
                    forme_5_3.Items.Add("Attack");
                    forme_5_3.Items.Add("Defense");
                    forme_5_3.Items.Add("Speed");

                    if ((int)this.pl5_3.SelectedValue < 4)
                    {
                        forme_5_3.SelectedIndex = (int)this.pl5_3.SelectedValue;
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_5_3.Items.Add("Plant");
                    forme_5_3.Items.Add("Sand");
                    forme_5_3.Items.Add("Trash");

                    if ((int)this.pl5_3.SelectedValue < 3)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_5_3.Items.Add("Overcast Form");
                    forme_5_3.Items.Add("Sunshine Form");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_5_3.Items.Add("West");
                    forme_5_3.Items.Add("East");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = (int)this.pl5_3.SelectedValue;
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_5_3.Items.Add("Normal");
                    forme_5_3.Items.Add("Heat");
                    forme_5_3.Items.Add("Wash");
                    forme_5_3.Items.Add("Frost");
                    forme_5_3.Items.Add("Spin");
                    forme_5_3.Items.Add("Cut");

                    if ((int)this.pl5_3.SelectedValue < 6)
                    {
                        forme_5_3.SelectedIndex = (int)this.pl5_3.SelectedValue;
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_5_3.Items.Add("Altered");
                    forme_5_3.Items.Add("Origin");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_5_3.Items.Add("Land");
                    forme_5_3.Items.Add("Sky");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_5_3.Items.Add("Normal");
                    forme_5_3.Items.Add("Fighting");
                    forme_5_3.Items.Add("Flying");
                    forme_5_3.Items.Add("Poison");
                    forme_5_3.Items.Add("Ground");
                    forme_5_3.Items.Add("Rock");
                    forme_5_3.Items.Add("Bug");
                    forme_5_3.Items.Add("Ghost");
                    forme_5_3.Items.Add("Steel");
                    forme_5_3.Items.Add("Fire");
                    forme_5_3.Items.Add("Water");
                    forme_5_3.Items.Add("Grass");
                    forme_5_3.Items.Add("Electric");
                    forme_5_3.Items.Add("Psychic");
                    forme_5_3.Items.Add("Ice");
                    forme_5_3.Items.Add("Dragon");
                    forme_5_3.Items.Add("Dark");

                    if ((int)this.pl5_3.SelectedValue < 18)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_5_3.Items.Add("Red-Striped");
                    forme_5_3.Items.Add("Blue-Striped");
                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_5_3.Items.Add("Normal");
                    forme_5_3.Items.Add("Zen mode");
                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_5_3.Items.Add("Spring Form");
                    forme_5_3.Items.Add("Summer Form");
                    forme_5_3.Items.Add("Autumn Form");
                    forme_5_3.Items.Add("Winter Form");

                    if ((int)this.pl5_3.SelectedValue < 4)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_5_3.Items.Add("Incarnate Forme");
                    forme_5_3.Items.Add("Therian Forme");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_5_3.Items.Add("Kyurem");
                    forme_5_3.Items.Add("White Kyurem");
                    forme_5_3.Items.Add("Black Kyurem");

                    if ((int)this.pl5_3.SelectedValue < 3)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_5_3.Items.Add("Ordinary Form");
                    forme_5_3.Items.Add("Resolute Form");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_5_3.Items.Add("Aria Forme");
                    forme_5_3.Items.Add("Pirouette Forme");

                    if ((int)this.pl5_3.SelectedValue < 2)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_5_3.Items.Add("Normal");
                    forme_5_3.Items.Add("1");
                    forme_5_3.Items.Add("2");
                    forme_5_3.Items.Add("3");
                    forme_5_3.Items.Add("4");

                    if ((int)this.pl5_3.SelectedValue < 5)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_5_3.Items.Add("Normal");

                    if ((int)this.pl5_3.SelectedValue < 1)
                    {
                        forme_5_3.SelectedIndex = ((int)this.pl5_3.SelectedValue);
                    }
                    else
                    {
                        forme_5_3.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl5_4_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_5_4.Items.Clear();

            switch ((int)this.pl5_4.SelectedValue)
            {
                case 172: //Pichu
                    forme_5_4.Items.Add("Normal");

                    if ((int)this.pl5_4.SelectedValue < 1)
                    {
                        forme_5_4.SelectedIndex = (int)this.pl5_4.SelectedValue;
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_5_4.Items.Add("A");
                    forme_5_4.Items.Add("B");
                    forme_5_4.Items.Add("C");
                    forme_5_4.Items.Add("D");
                    forme_5_4.Items.Add("E");
                    forme_5_4.Items.Add("F");
                    forme_5_4.Items.Add("G");
                    forme_5_4.Items.Add("H");
                    forme_5_4.Items.Add("I");
                    forme_5_4.Items.Add("J");
                    forme_5_4.Items.Add("K");
                    forme_5_4.Items.Add("L");
                    forme_5_4.Items.Add("M");
                    forme_5_4.Items.Add("N");
                    forme_5_4.Items.Add("O");
                    forme_5_4.Items.Add("P");
                    forme_5_4.Items.Add("Q");
                    forme_5_4.Items.Add("R");
                    forme_5_4.Items.Add("S");
                    forme_5_4.Items.Add("T");
                    forme_5_4.Items.Add("U");
                    forme_5_4.Items.Add("V");
                    forme_5_4.Items.Add("W");
                    forme_5_4.Items.Add("X");
                    forme_5_4.Items.Add("Y");
                    forme_5_4.Items.Add("Z");
                    forme_5_4.Items.Add("!");
                    forme_5_4.Items.Add("?");

                    if ((int)this.pl5_4.SelectedValue < 28)
                    {
                        forme_5_4.SelectedIndex = (int)this.pl5_4.SelectedValue;
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_5_4.Items.Add("Normal");
                    forme_5_4.Items.Add("Sunny Form");
                    forme_5_4.Items.Add("Rainy Form");
                    forme_5_4.Items.Add("Snowy Form");

                    if ((int)this.pl5_4.SelectedValue < 4)
                    {
                        forme_5_4.SelectedIndex = (int)this.pl5_4.SelectedValue;
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_5_4.Items.Add("Normal");
                    forme_5_4.Items.Add("Attack");
                    forme_5_4.Items.Add("Defense");
                    forme_5_4.Items.Add("Speed");

                    if ((int)this.pl5_4.SelectedValue < 4)
                    {
                        forme_5_4.SelectedIndex = (int)this.pl5_4.SelectedValue;
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_5_4.Items.Add("Plant");
                    forme_5_4.Items.Add("Sand");
                    forme_5_4.Items.Add("Trash");

                    if ((int)this.pl5_4.SelectedValue < 3)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_5_4.Items.Add("Overcast Form");
                    forme_5_4.Items.Add("Sunshine Form");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_5_4.Items.Add("West");
                    forme_5_4.Items.Add("East");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = (int)this.pl5_4.SelectedValue;
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_5_4.Items.Add("Normal");
                    forme_5_4.Items.Add("Heat");
                    forme_5_4.Items.Add("Wash");
                    forme_5_4.Items.Add("Frost");
                    forme_5_4.Items.Add("Spin");
                    forme_5_4.Items.Add("Cut");

                    if ((int)this.pl5_4.SelectedValue < 6)
                    {
                        forme_5_4.SelectedIndex = (int)this.pl5_4.SelectedValue;
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_5_4.Items.Add("Altered");
                    forme_5_4.Items.Add("Origin");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_5_4.Items.Add("Land");
                    forme_5_4.Items.Add("Sky");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_5_4.Items.Add("Normal");
                    forme_5_4.Items.Add("Fighting");
                    forme_5_4.Items.Add("Flying");
                    forme_5_4.Items.Add("Poison");
                    forme_5_4.Items.Add("Ground");
                    forme_5_4.Items.Add("Rock");
                    forme_5_4.Items.Add("Bug");
                    forme_5_4.Items.Add("Ghost");
                    forme_5_4.Items.Add("Steel");
                    forme_5_4.Items.Add("Fire");
                    forme_5_4.Items.Add("Water");
                    forme_5_4.Items.Add("Grass");
                    forme_5_4.Items.Add("Electric");
                    forme_5_4.Items.Add("Psychic");
                    forme_5_4.Items.Add("Ice");
                    forme_5_4.Items.Add("Dragon");
                    forme_5_4.Items.Add("Dark");

                    if ((int)this.pl5_4.SelectedValue < 18)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_5_4.Items.Add("Red-Striped");
                    forme_5_4.Items.Add("Blue-Striped");
                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_5_4.Items.Add("Normal");
                    forme_5_4.Items.Add("Zen mode");
                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_5_4.Items.Add("Spring Form");
                    forme_5_4.Items.Add("Summer Form");
                    forme_5_4.Items.Add("Autumn Form");
                    forme_5_4.Items.Add("Winter Form");

                    if ((int)this.pl5_4.SelectedValue < 4)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_5_4.Items.Add("Incarnate Forme");
                    forme_5_4.Items.Add("Therian Forme");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_5_4.Items.Add("Kyurem");
                    forme_5_4.Items.Add("White Kyurem");
                    forme_5_4.Items.Add("Black Kyurem");

                    if ((int)this.pl5_4.SelectedValue < 3)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_5_4.Items.Add("Ordinary Form");
                    forme_5_4.Items.Add("Resolute Form");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_5_4.Items.Add("Aria Forme");
                    forme_5_4.Items.Add("Pirouette Forme");

                    if ((int)this.pl5_4.SelectedValue < 2)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_5_4.Items.Add("Normal");
                    forme_5_4.Items.Add("1");
                    forme_5_4.Items.Add("2");
                    forme_5_4.Items.Add("3");
                    forme_5_4.Items.Add("4");

                    if ((int)this.pl5_4.SelectedValue < 5)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_5_4.Items.Add("Normal");

                    if ((int)this.pl5_4.SelectedValue < 1)
                    {
                        forme_5_4.SelectedIndex = ((int)this.pl5_4.SelectedValue);
                    }
                    else
                    {
                        forme_5_4.SelectedIndex = 0;
                    }
                    break;

            }
        }



        //B2 -3

        private void forme_6_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_6_1.SelectedIndex > 0)
            {
                this.pbx_pl6_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_1.SelectedValue + "_" + (int)this.forme_6_1.SelectedIndex);
            }
            else
            {
                this.pbx_pl6_1.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_1.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl6_1.SelectedValue) == "1")
            {
                this.pictureBox21.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox21.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_6_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_6_2.SelectedIndex > 0)
            {
                this.pbx_pl6_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_2.SelectedValue + "_" + (int)this.forme_6_2.SelectedIndex);
            }
            else
            {
                this.pbx_pl6_2.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_2.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl6_2.SelectedValue) == "1")
            {
                this.pictureBox22.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox22.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_6_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_6_3.SelectedIndex > 0)
            {
                this.pbx_pl6_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_3.SelectedValue + "_" + (int)this.forme_6_3.SelectedIndex);
            }
            else
            {
                this.pbx_pl6_3.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_3.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl6_3.SelectedValue) == "1")
            {
                this.pictureBox23.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox23.Image = global::AHGE.Properties.Resources._a1;
            }
        }

        private void forme_6_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.forme_6_4.SelectedIndex > 0)
            {
                this.pbx_pl6_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_4.SelectedValue + "_" + (int)this.forme_6_4.SelectedIndex);
            }
            else
            {
                this.pbx_pl6_4.Image = (Image)global::aleafia_resicon.Properties.Resources.ResourceManager.GetObject("_" + (int)this.pl6_4.SelectedValue);
            }

            if ((string)Program.PokeList.SearchByhge((int)this.pl6_4.SelectedValue) == "1")
            {
                this.pictureBox24.Image = global::AHGE.Properties.Resources._a2;

            }
            else
            {
                this.pictureBox24.Image = global::AHGE.Properties.Resources._a1;
            }
        }


        public void pl6_1_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_6_1.Items.Clear();

            switch ((int)this.pl6_1.SelectedValue)
            {
                case 172: //Pichu
                    forme_6_1.Items.Add("Normal");

                    if ((int)this.pl6_1.SelectedValue < 1)
                    {
                        forme_6_1.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_6_1.Items.Add("A");
                    forme_6_1.Items.Add("B");
                    forme_6_1.Items.Add("C");
                    forme_6_1.Items.Add("D");
                    forme_6_1.Items.Add("E");
                    forme_6_1.Items.Add("F");
                    forme_6_1.Items.Add("G");
                    forme_6_1.Items.Add("H");
                    forme_6_1.Items.Add("I");
                    forme_6_1.Items.Add("J");
                    forme_6_1.Items.Add("K");
                    forme_6_1.Items.Add("L");
                    forme_6_1.Items.Add("M");
                    forme_6_1.Items.Add("N");
                    forme_6_1.Items.Add("O");
                    forme_6_1.Items.Add("P");
                    forme_6_1.Items.Add("Q");
                    forme_6_1.Items.Add("R");
                    forme_6_1.Items.Add("S");
                    forme_6_1.Items.Add("T");
                    forme_6_1.Items.Add("U");
                    forme_6_1.Items.Add("V");
                    forme_6_1.Items.Add("W");
                    forme_6_1.Items.Add("X");
                    forme_6_1.Items.Add("Y");
                    forme_6_1.Items.Add("Z");
                    forme_6_1.Items.Add("!");
                    forme_6_1.Items.Add("?");

                    if ((int)this.pl6_1.SelectedValue < 28)
                    {
                        forme_6_1.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_6_1.Items.Add("Normal");
                    forme_6_1.Items.Add("Sunny Form");
                    forme_6_1.Items.Add("Rainy Form");
                    forme_6_1.Items.Add("Snowy Form");

                    if ((int)this.pl6_1.SelectedValue < 4)
                    {
                        forme_6_1.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_6_1.Items.Add("Normal");
                    forme_6_1.Items.Add("Attack");
                    forme_6_1.Items.Add("Defense");
                    forme_6_1.Items.Add("Speed");

                    if ((int)this.pl6_1.SelectedValue < 4)
                    {
                        forme_6_1.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_6_1.Items.Add("Plant");
                    forme_6_1.Items.Add("Sand");
                    forme_6_1.Items.Add("Trash");

                    if ((int)this.pl6_1.SelectedValue < 3)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_6_1.Items.Add("Overcast Form");
                    forme_6_1.Items.Add("Sunshine Form");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_6_1.Items.Add("West");
                    forme_6_1.Items.Add("East");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_6_1.Items.Add("Normal");
                    forme_6_1.Items.Add("Heat");
                    forme_6_1.Items.Add("Wash");
                    forme_6_1.Items.Add("Frost");
                    forme_6_1.Items.Add("Spin");
                    forme_6_1.Items.Add("Cut");

                    if ((int)this.pl6_1.SelectedValue < 6)
                    {
                        forme_6_1.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_6_1.Items.Add("Altered");
                    forme_6_1.Items.Add("Origin");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_6_1.Items.Add("Land");
                    forme_6_1.Items.Add("Sky");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_6_1.Items.Add("Normal");
                    forme_6_1.Items.Add("Fighting");
                    forme_6_1.Items.Add("Flying");
                    forme_6_1.Items.Add("Poison");
                    forme_6_1.Items.Add("Ground");
                    forme_6_1.Items.Add("Rock");
                    forme_6_1.Items.Add("Bug");
                    forme_6_1.Items.Add("Ghost");
                    forme_6_1.Items.Add("Steel");
                    forme_6_1.Items.Add("Fire");
                    forme_6_1.Items.Add("Water");
                    forme_6_1.Items.Add("Grass");
                    forme_6_1.Items.Add("Electric");
                    forme_6_1.Items.Add("Psychic");
                    forme_6_1.Items.Add("Ice");
                    forme_6_1.Items.Add("Dragon");
                    forme_6_1.Items.Add("Dark");

                    if ((int)this.pl6_1.SelectedValue < 18)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_6_1.Items.Add("Red-Striped");
                    forme_6_1.Items.Add("Blue-Striped");
                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_6_1.Items.Add("Normal");
                    forme_6_1.Items.Add("Zen mode");
                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_6_1.Items.Add("Spring Form");
                    forme_6_1.Items.Add("Summer Form");
                    forme_6_1.Items.Add("Autumn Form");
                    forme_6_1.Items.Add("Winter Form");

                    if ((int)this.pl6_1.SelectedValue < 4)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_6_1.Items.Add("Incarnate Forme");
                    forme_6_1.Items.Add("Therian Forme");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_6_1.Items.Add("Kyurem");
                    forme_6_1.Items.Add("White Kyurem");
                    forme_6_1.Items.Add("Black Kyurem");

                    if ((int)this.pl6_1.SelectedValue < 3)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_6_1.Items.Add("Ordinary Form");
                    forme_6_1.Items.Add("Resolute Form");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_6_1.Items.Add("Aria Forme");
                    forme_6_1.Items.Add("Pirouette Forme");

                    if ((int)this.pl6_1.SelectedValue < 2)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_6_1.Items.Add("Normal");
                    forme_6_1.Items.Add("1");
                    forme_6_1.Items.Add("2");
                    forme_6_1.Items.Add("3");
                    forme_6_1.Items.Add("4");

                    if ((int)this.pl6_1.SelectedValue < 5)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_6_1.Items.Add("Normal");

                    if ((int)this.pl6_1.SelectedValue < 1)
                    {
                        forme_6_1.SelectedIndex = ((int)this.pl6_1.SelectedValue);
                    }
                    else
                    {
                        forme_6_1.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl6_2_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_6_2.Items.Clear();

            switch ((int)this.pl6_2.SelectedValue)
            {
                case 172: //Pichu
                    forme_6_2.Items.Add("Normal");

                    if ((int)this.pl6_2.SelectedValue < 1)
                    {
                        forme_6_2.SelectedIndex = (int)this.pl6_2.SelectedValue;
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_6_2.Items.Add("A");
                    forme_6_2.Items.Add("B");
                    forme_6_2.Items.Add("C");
                    forme_6_2.Items.Add("D");
                    forme_6_2.Items.Add("E");
                    forme_6_2.Items.Add("F");
                    forme_6_2.Items.Add("G");
                    forme_6_2.Items.Add("H");
                    forme_6_2.Items.Add("I");
                    forme_6_2.Items.Add("J");
                    forme_6_2.Items.Add("K");
                    forme_6_2.Items.Add("L");
                    forme_6_2.Items.Add("M");
                    forme_6_2.Items.Add("N");
                    forme_6_2.Items.Add("O");
                    forme_6_2.Items.Add("P");
                    forme_6_2.Items.Add("Q");
                    forme_6_2.Items.Add("R");
                    forme_6_2.Items.Add("S");
                    forme_6_2.Items.Add("T");
                    forme_6_2.Items.Add("U");
                    forme_6_2.Items.Add("V");
                    forme_6_2.Items.Add("W");
                    forme_6_2.Items.Add("X");
                    forme_6_2.Items.Add("Y");
                    forme_6_2.Items.Add("Z");
                    forme_6_2.Items.Add("!");
                    forme_6_2.Items.Add("?");

                    if ((int)this.pl6_2.SelectedValue < 28)
                    {
                        forme_6_2.SelectedIndex = (int)this.pl6_2.SelectedValue;
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_6_2.Items.Add("Normal");
                    forme_6_2.Items.Add("Sunny Form");
                    forme_6_2.Items.Add("Rainy Form");
                    forme_6_2.Items.Add("Snowy Form");

                    if ((int)this.pl6_2.SelectedValue < 4)
                    {
                        forme_6_2.SelectedIndex = (int)this.pl6_2.SelectedValue;
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_6_2.Items.Add("Normal");
                    forme_6_2.Items.Add("Attack");
                    forme_6_2.Items.Add("Defense");
                    forme_6_2.Items.Add("Speed");

                    if ((int)this.pl6_1.SelectedValue < 4)
                    {
                        forme_6_2.SelectedIndex = (int)this.pl6_1.SelectedValue;
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_6_2.Items.Add("Plant");
                    forme_6_2.Items.Add("Sand");
                    forme_6_2.Items.Add("Trash");

                    if ((int)this.pl6_2.SelectedValue < 3)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_6_2.Items.Add("Overcast Form");
                    forme_6_2.Items.Add("Sunshine Form");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_6_2.Items.Add("West");
                    forme_6_2.Items.Add("East");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = (int)this.pl6_2.SelectedValue;
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_6_2.Items.Add("Normal");
                    forme_6_2.Items.Add("Heat");
                    forme_6_2.Items.Add("Wash");
                    forme_6_2.Items.Add("Frost");
                    forme_6_2.Items.Add("Spin");
                    forme_6_2.Items.Add("Cut");

                    if ((int)this.pl6_2.SelectedValue < 6)
                    {
                        forme_6_2.SelectedIndex = (int)this.pl6_2.SelectedValue;
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_6_2.Items.Add("Altered");
                    forme_6_2.Items.Add("Origin");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_6_2.Items.Add("Land");
                    forme_6_2.Items.Add("Sky");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_6_2.Items.Add("Normal");
                    forme_6_2.Items.Add("Fighting");
                    forme_6_2.Items.Add("Flying");
                    forme_6_2.Items.Add("Poison");
                    forme_6_2.Items.Add("Ground");
                    forme_6_2.Items.Add("Rock");
                    forme_6_2.Items.Add("Bug");
                    forme_6_2.Items.Add("Ghost");
                    forme_6_2.Items.Add("Steel");
                    forme_6_2.Items.Add("Fire");
                    forme_6_2.Items.Add("Water");
                    forme_6_2.Items.Add("Grass");
                    forme_6_2.Items.Add("Electric");
                    forme_6_2.Items.Add("Psychic");
                    forme_6_2.Items.Add("Ice");
                    forme_6_2.Items.Add("Dragon");
                    forme_6_2.Items.Add("Dark");

                    if ((int)this.pl6_2.SelectedValue < 18)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_6_2.Items.Add("Red-Striped");
                    forme_6_2.Items.Add("Blue-Striped");
                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_6_2.Items.Add("Normal");
                    forme_6_2.Items.Add("Zen mode");
                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_6_2.Items.Add("Spring Form");
                    forme_6_2.Items.Add("Summer Form");
                    forme_6_2.Items.Add("Autumn Form");
                    forme_6_2.Items.Add("Winter Form");

                    if ((int)this.pl6_2.SelectedValue < 4)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_6_2.Items.Add("Incarnate Forme");
                    forme_6_2.Items.Add("Therian Forme");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_6_2.Items.Add("Kyurem");
                    forme_6_2.Items.Add("White Kyurem");
                    forme_6_2.Items.Add("Black Kyurem");

                    if ((int)this.pl6_2.SelectedValue < 3)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_6_2.Items.Add("Ordinary Form");
                    forme_6_2.Items.Add("Resolute Form");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_6_2.Items.Add("Aria Forme");
                    forme_6_2.Items.Add("Pirouette Forme");

                    if ((int)this.pl6_2.SelectedValue < 2)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_6_2.Items.Add("Normal");
                    forme_6_2.Items.Add("1");
                    forme_6_2.Items.Add("2");
                    forme_6_2.Items.Add("3");
                    forme_6_2.Items.Add("4");

                    if ((int)this.pl6_2.SelectedValue < 5)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_6_2.Items.Add("Normal");

                    if ((int)this.pl6_1.SelectedValue < 1)
                    {
                        forme_6_2.SelectedIndex = ((int)this.pl6_2.SelectedValue);
                    }
                    else
                    {
                        forme_6_2.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl6_3_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_6_3.Items.Clear();

            switch ((int)this.pl6_3.SelectedValue)
            {
                case 172: //Pichu
                    forme_6_3.Items.Add("Normal");

                    if ((int)this.pl6_3.SelectedValue < 1)
                    {
                        forme_6_3.SelectedIndex = (int)this.pl6_3.SelectedValue;
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_6_3.Items.Add("A");
                    forme_6_3.Items.Add("B");
                    forme_6_3.Items.Add("C");
                    forme_6_3.Items.Add("D");
                    forme_6_3.Items.Add("E");
                    forme_6_3.Items.Add("F");
                    forme_6_3.Items.Add("G");
                    forme_6_3.Items.Add("H");
                    forme_6_3.Items.Add("I");
                    forme_6_3.Items.Add("J");
                    forme_6_3.Items.Add("K");
                    forme_6_3.Items.Add("L");
                    forme_6_3.Items.Add("M");
                    forme_6_3.Items.Add("N");
                    forme_6_3.Items.Add("O");
                    forme_6_3.Items.Add("P");
                    forme_6_3.Items.Add("Q");
                    forme_6_3.Items.Add("R");
                    forme_6_3.Items.Add("S");
                    forme_6_3.Items.Add("T");
                    forme_6_3.Items.Add("U");
                    forme_6_3.Items.Add("V");
                    forme_6_3.Items.Add("W");
                    forme_6_3.Items.Add("X");
                    forme_6_3.Items.Add("Y");
                    forme_6_3.Items.Add("Z");
                    forme_6_3.Items.Add("!");
                    forme_6_3.Items.Add("?");

                    if ((int)this.pl6_3.SelectedValue < 28)
                    {
                        forme_6_3.SelectedIndex = (int)this.pl6_3.SelectedValue;
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_6_3.Items.Add("Normal");
                    forme_6_3.Items.Add("Sunny Form");
                    forme_6_3.Items.Add("Rainy Form");
                    forme_6_3.Items.Add("Snowy Form");

                    if ((int)this.pl6_3.SelectedValue < 4)
                    {
                        forme_6_3.SelectedIndex = (int)this.pl6_3.SelectedValue;
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_6_3.Items.Add("Normal");
                    forme_6_3.Items.Add("Attack");
                    forme_6_3.Items.Add("Defense");
                    forme_6_3.Items.Add("Speed");

                    if ((int)this.pl6_3.SelectedValue < 4)
                    {
                        forme_6_3.SelectedIndex = (int)this.pl6_3.SelectedValue;
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_6_3.Items.Add("Plant");
                    forme_6_3.Items.Add("Sand");
                    forme_6_3.Items.Add("Trash");

                    if ((int)this.pl6_3.SelectedValue < 3)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_6_3.Items.Add("Overcast Form");
                    forme_6_3.Items.Add("Sunshine Form");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_6_3.Items.Add("West");
                    forme_6_3.Items.Add("East");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = (int)this.pl6_3.SelectedValue;
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_6_3.Items.Add("Normal");
                    forme_6_3.Items.Add("Heat");
                    forme_6_3.Items.Add("Wash");
                    forme_6_3.Items.Add("Frost");
                    forme_6_3.Items.Add("Spin");
                    forme_6_3.Items.Add("Cut");

                    if ((int)this.pl6_3.SelectedValue < 6)
                    {
                        forme_6_3.SelectedIndex = (int)this.pl6_3.SelectedValue;
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_6_3.Items.Add("Altered");
                    forme_6_3.Items.Add("Origin");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_6_3.Items.Add("Land");
                    forme_6_3.Items.Add("Sky");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_6_3.Items.Add("Normal");
                    forme_6_3.Items.Add("Fighting");
                    forme_6_3.Items.Add("Flying");
                    forme_6_3.Items.Add("Poison");
                    forme_6_3.Items.Add("Ground");
                    forme_6_3.Items.Add("Rock");
                    forme_6_3.Items.Add("Bug");
                    forme_6_3.Items.Add("Ghost");
                    forme_6_3.Items.Add("Steel");
                    forme_6_3.Items.Add("Fire");
                    forme_6_3.Items.Add("Water");
                    forme_6_3.Items.Add("Grass");
                    forme_6_3.Items.Add("Electric");
                    forme_6_3.Items.Add("Psychic");
                    forme_6_3.Items.Add("Ice");
                    forme_6_3.Items.Add("Dragon");
                    forme_6_3.Items.Add("Dark");

                    if ((int)this.pl6_3.SelectedValue < 18)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_6_3.Items.Add("Red-Striped");
                    forme_6_3.Items.Add("Blue-Striped");
                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_6_3.Items.Add("Normal");
                    forme_6_3.Items.Add("Zen mode");
                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_6_3.Items.Add("Spring Form");
                    forme_6_3.Items.Add("Summer Form");
                    forme_6_3.Items.Add("Autumn Form");
                    forme_6_3.Items.Add("Winter Form");

                    if ((int)this.pl6_3.SelectedValue < 4)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_6_3.Items.Add("Incarnate Forme");
                    forme_6_3.Items.Add("Therian Forme");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_6_3.Items.Add("Kyurem");
                    forme_6_3.Items.Add("White Kyurem");
                    forme_6_3.Items.Add("Black Kyurem");

                    if ((int)this.pl6_3.SelectedValue < 3)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_6_3.Items.Add("Ordinary Form");
                    forme_6_3.Items.Add("Resolute Form");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_6_3.Items.Add("Aria Forme");
                    forme_6_3.Items.Add("Pirouette Forme");

                    if ((int)this.pl6_3.SelectedValue < 2)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_6_3.Items.Add("Normal");
                    forme_6_3.Items.Add("1");
                    forme_6_3.Items.Add("2");
                    forme_6_3.Items.Add("3");
                    forme_6_3.Items.Add("4");

                    if ((int)this.pl6_3.SelectedValue < 5)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_6_3.Items.Add("Normal");

                    if ((int)this.pl6_3.SelectedValue < 1)
                    {
                        forme_6_3.SelectedIndex = ((int)this.pl6_3.SelectedValue);
                    }
                    else
                    {
                        forme_6_3.SelectedIndex = 0;
                    }
                    break;

            }
        }

        public void pl6_4_SelectedValueChanged(object sender, EventArgs e)
        {
            forme_6_4.Items.Clear();

            switch ((int)this.pl6_4.SelectedValue)
            {
                case 172: //Pichu
                    forme_6_4.Items.Add("Normal");

                    if ((int)this.pl6_4.SelectedValue < 1)
                    {
                        forme_6_4.SelectedIndex = (int)this.pl6_4.SelectedValue;
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 201: // Unown

                    forme_6_4.Items.Add("A");
                    forme_6_4.Items.Add("B");
                    forme_6_4.Items.Add("C");
                    forme_6_4.Items.Add("D");
                    forme_6_4.Items.Add("E");
                    forme_6_4.Items.Add("F");
                    forme_6_4.Items.Add("G");
                    forme_6_4.Items.Add("H");
                    forme_6_4.Items.Add("I");
                    forme_6_4.Items.Add("J");
                    forme_6_4.Items.Add("K");
                    forme_6_4.Items.Add("L");
                    forme_6_4.Items.Add("M");
                    forme_6_4.Items.Add("N");
                    forme_6_4.Items.Add("O");
                    forme_6_4.Items.Add("P");
                    forme_6_4.Items.Add("Q");
                    forme_6_4.Items.Add("R");
                    forme_6_4.Items.Add("S");
                    forme_6_4.Items.Add("T");
                    forme_6_4.Items.Add("U");
                    forme_6_4.Items.Add("V");
                    forme_6_4.Items.Add("W");
                    forme_6_4.Items.Add("X");
                    forme_6_4.Items.Add("Y");
                    forme_6_4.Items.Add("Z");
                    forme_6_4.Items.Add("!");
                    forme_6_4.Items.Add("?");

                    if ((int)this.pl6_4.SelectedValue < 28)
                    {
                        forme_6_4.SelectedIndex = (int)this.pl6_4.SelectedValue;
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 351:

                    forme_6_4.Items.Add("Normal");
                    forme_6_4.Items.Add("Sunny Form");
                    forme_6_4.Items.Add("Rainy Form");
                    forme_6_4.Items.Add("Snowy Form");

                    if ((int)this.pl6_4.SelectedValue < 4)
                    {
                        forme_6_4.SelectedIndex = (int)this.pl6_4.SelectedValue;
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;
                case 386: // Deoxys

                    forme_6_4.Items.Add("Normal");
                    forme_6_4.Items.Add("Attack");
                    forme_6_4.Items.Add("Defense");
                    forme_6_4.Items.Add("Speed");

                    if ((int)this.pl6_4.SelectedValue < 4)
                    {
                        forme_6_4.SelectedIndex = (int)this.pl6_4.SelectedValue;
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;


                case 412: // Burmy
                case 413: // Wormadam

                    forme_6_4.Items.Add("Plant");
                    forme_6_4.Items.Add("Sand");
                    forme_6_4.Items.Add("Trash");

                    if ((int)this.pl6_4.SelectedValue < 3)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 421:

                    forme_6_4.Items.Add("Overcast Form");
                    forme_6_4.Items.Add("Sunshine Form");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;
                case 422: // Shellos
                case 423: // Gastrodon

                    forme_6_4.Items.Add("West");
                    forme_6_4.Items.Add("East");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = (int)this.pl6_4.SelectedValue;
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 479: // Rotom

                    forme_6_4.Items.Add("Normal");
                    forme_6_4.Items.Add("Heat");
                    forme_6_4.Items.Add("Wash");
                    forme_6_4.Items.Add("Frost");
                    forme_6_4.Items.Add("Spin");
                    forme_6_4.Items.Add("Cut");

                    if ((int)this.pl6_4.SelectedValue < 6)
                    {
                        forme_6_4.SelectedIndex = (int)this.pl6_4.SelectedValue;
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }
                    break;

                case 487: // Giratina

                    forme_6_4.Items.Add("Altered");
                    forme_6_4.Items.Add("Origin");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 492: // Shaymin

                    forme_6_4.Items.Add("Land");
                    forme_6_4.Items.Add("Sky");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 493: // Arceus

                    forme_6_4.Items.Add("Normal");
                    forme_6_4.Items.Add("Fighting");
                    forme_6_4.Items.Add("Flying");
                    forme_6_4.Items.Add("Poison");
                    forme_6_4.Items.Add("Ground");
                    forme_6_4.Items.Add("Rock");
                    forme_6_4.Items.Add("Bug");
                    forme_6_4.Items.Add("Ghost");
                    forme_6_4.Items.Add("Steel");
                    forme_6_4.Items.Add("Fire");
                    forme_6_4.Items.Add("Water");
                    forme_6_4.Items.Add("Grass");
                    forme_6_4.Items.Add("Electric");
                    forme_6_4.Items.Add("Psychic");
                    forme_6_4.Items.Add("Ice");
                    forme_6_4.Items.Add("Dragon");
                    forme_6_4.Items.Add("Dark");

                    if ((int)this.pl6_4.SelectedValue < 18)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 550:
                    forme_6_4.Items.Add("Red-Striped");
                    forme_6_4.Items.Add("Blue-Striped");
                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 555:
                    forme_6_4.Items.Add("Normal");
                    forme_6_4.Items.Add("Zen mode");
                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 585:
                case 586:

                    forme_6_4.Items.Add("Spring Form");
                    forme_6_4.Items.Add("Summer Form");
                    forme_6_4.Items.Add("Autumn Form");
                    forme_6_4.Items.Add("Winter Form");

                    if ((int)this.pl6_4.SelectedValue < 4)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 641:
                case 642:
                case 645:

                    forme_6_4.Items.Add("Incarnate Forme");
                    forme_6_4.Items.Add("Therian Forme");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 646:

                    forme_6_4.Items.Add("Kyurem");
                    forme_6_4.Items.Add("White Kyurem");
                    forme_6_4.Items.Add("Black Kyurem");

                    if ((int)this.pl6_4.SelectedValue < 3)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 647:

                    forme_6_4.Items.Add("Ordinary Form");
                    forme_6_4.Items.Add("Resolute Form");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 648:

                    forme_6_4.Items.Add("Aria Forme");
                    forme_6_4.Items.Add("Pirouette Forme");

                    if ((int)this.pl6_4.SelectedValue < 2)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                case 649:

                    forme_6_4.Items.Add("Normal");
                    forme_6_4.Items.Add("1");
                    forme_6_4.Items.Add("2");
                    forme_6_4.Items.Add("3");
                    forme_6_4.Items.Add("4");

                    if ((int)this.pl6_4.SelectedValue < 5)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }

                    break;

                default:
                    forme_6_4.Items.Add("Normal");

                    if ((int)this.pl6_4.SelectedValue < 1)
                    {
                        forme_6_4.SelectedIndex = ((int)this.pl6_4.SelectedValue);
                    }
                    else
                    {
                        forme_6_4.SelectedIndex = 0;
                    }
                    break;

            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            AHGE.Popup.Batch form = new AHGE.Popup.Batch(this);

            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ReadSourceData();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button2.Text = global::aleafia_reslang_en.Properties.Resources.String1;
                button1.Text = global::aleafia_reslang_en.Properties.Resources.String2;
                label2.Text = global::aleafia_reslang_en.Properties.Resources.String3;
                label36.Text = global::aleafia_reslang_en.Properties.Resources.String3;
                label39.Text = global::aleafia_reslang_en.Properties.Resources.String3;
                label25.Text = global::aleafia_reslang_en.Properties.Resources.String3;
                label48.Text = global::aleafia_reslang_en.Properties.Resources.String3;
                label55.Text = global::aleafia_reslang_en.Properties.Resources.String3;
                lm11.Text = global::aleafia_reslang_en.Properties.Resources.String4;
                lm12.Text = global::aleafia_reslang_en.Properties.Resources.String4;
                lm13.Text = global::aleafia_reslang_en.Properties.Resources.String4;
                lm14.Text = global::aleafia_reslang_en.Properties.Resources.String4;
                lm15.Text = global::aleafia_reslang_en.Properties.Resources.String4;
                lm16.Text = global::aleafia_reslang_en.Properties.Resources.String4;
                lm21.Text = global::aleafia_reslang_en.Properties.Resources.String5;
                lm22.Text = global::aleafia_reslang_en.Properties.Resources.String5;
                lm23.Text = global::aleafia_reslang_en.Properties.Resources.String5;
                lm24.Text = global::aleafia_reslang_en.Properties.Resources.String5;
                lm25.Text = global::aleafia_reslang_en.Properties.Resources.String5;
                lm26.Text = global::aleafia_reslang_en.Properties.Resources.String5;
                fel1.Text = global::aleafia_reslang_en.Properties.Resources.String6;
                fel2.Text = global::aleafia_reslang_en.Properties.Resources.String6;
                fel3.Text = global::aleafia_reslang_en.Properties.Resources.String6;
                fel4.Text = global::aleafia_reslang_en.Properties.Resources.String6;
                fel5.Text = global::aleafia_reslang_en.Properties.Resources.String6;
                fel6.Text = global::aleafia_reslang_en.Properties.Resources.String6;
                frme1.Text = global::aleafia_reslang_en.Properties.Resources.String7;
                frme2.Text = global::aleafia_reslang_en.Properties.Resources.String7;
                frme3.Text = global::aleafia_reslang_en.Properties.Resources.String7;
                frme4.Text = global::aleafia_reslang_en.Properties.Resources.String7;
                frme5.Text = global::aleafia_reslang_en.Properties.Resources.String7;
                frme6.Text = global::aleafia_reslang_en.Properties.Resources.String7;
                label20.Text = global::aleafia_reslang_en.Properties.Resources.String8;
                label22.Text = global::aleafia_reslang_en.Properties.Resources.String8;
                label7.Text = global::aleafia_reslang_en.Properties.Resources.String8;
                label10.Text = global::aleafia_reslang_en.Properties.Resources.String8;
                label43.Text = global::aleafia_reslang_en.Properties.Resources.String8;
                label50.Text = global::aleafia_reslang_en.Properties.Resources.String8;
                tabPage1.Text = global::aleafia_reslang_en.Properties.Resources.String9;
                tabPage2.Text = global::aleafia_reslang_en.Properties.Resources.String10;
                tabPage4.Text = global::aleafia_reslang_en.Properties.Resources.String11;
                groupBox1.Text = global::aleafia_reslang_en.Properties.Resources.String11;
                tabPage5.Text = global::aleafia_reslang_en.Properties.Resources.String12;
                label41.Text = global::aleafia_reslang_en.Properties.Resources.String13;
                label57.Text = global::aleafia_reslang_en.Properties.Resources.String13;
                groupBox2.Text = global::aleafia_reslang_en.Properties.Resources.String14;
                groupBox10.Text = global::aleafia_reslang_en.Properties.Resources.String15;
                groupBox12.Text = global::aleafia_reslang_en.Properties.Resources.String16;
                checkBox1.Text = global::aleafia_reslang_en.Properties.Resources.String17;
                checkBox2.Text = global::aleafia_reslang_en.Properties.Resources.String18;
                button4.Text = global::aleafia_reslang_en.Properties.Resources.String19;
                save.Text = global::aleafia_reslang_en.Properties.Resources.String20;
                button3.Text = global::aleafia_reslang_en.Properties.Resources.String21;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                button2.Text = global::aleafia_reslang_id.Properties.Resources.String1;
                button1.Text = global::aleafia_reslang_id.Properties.Resources.String2;
                label2.Text = global::aleafia_reslang_id.Properties.Resources.String3;
                label36.Text = global::aleafia_reslang_id.Properties.Resources.String3;
                label39.Text = global::aleafia_reslang_id.Properties.Resources.String3;
                label25.Text = global::aleafia_reslang_id.Properties.Resources.String3;
                label48.Text = global::aleafia_reslang_id.Properties.Resources.String3;
                label55.Text = global::aleafia_reslang_id.Properties.Resources.String3;
                lm11.Text = global::aleafia_reslang_id.Properties.Resources.String4;
                lm12.Text = global::aleafia_reslang_id.Properties.Resources.String4;
                lm13.Text = global::aleafia_reslang_id.Properties.Resources.String4;
                lm14.Text = global::aleafia_reslang_id.Properties.Resources.String4;
                lm15.Text = global::aleafia_reslang_id.Properties.Resources.String4;
                lm16.Text = global::aleafia_reslang_id.Properties.Resources.String4;
                lm21.Text = global::aleafia_reslang_id.Properties.Resources.String5;
                lm22.Text = global::aleafia_reslang_id.Properties.Resources.String5;
                lm23.Text = global::aleafia_reslang_id.Properties.Resources.String5;
                lm24.Text = global::aleafia_reslang_id.Properties.Resources.String5;
                lm25.Text = global::aleafia_reslang_id.Properties.Resources.String5;
                lm26.Text = global::aleafia_reslang_id.Properties.Resources.String5;
                fel1.Text = global::aleafia_reslang_id.Properties.Resources.String6;
                fel2.Text = global::aleafia_reslang_id.Properties.Resources.String6;
                fel3.Text = global::aleafia_reslang_id.Properties.Resources.String6;
                fel4.Text = global::aleafia_reslang_id.Properties.Resources.String6;
                fel5.Text = global::aleafia_reslang_id.Properties.Resources.String6;
                fel6.Text = global::aleafia_reslang_id.Properties.Resources.String6;
                frme1.Text = global::aleafia_reslang_id.Properties.Resources.String7;
                frme2.Text = global::aleafia_reslang_id.Properties.Resources.String7;
                frme3.Text = global::aleafia_reslang_id.Properties.Resources.String7;
                frme4.Text = global::aleafia_reslang_id.Properties.Resources.String7;
                frme5.Text = global::aleafia_reslang_id.Properties.Resources.String7;
                frme6.Text = global::aleafia_reslang_id.Properties.Resources.String7;
                label20.Text = global::aleafia_reslang_id.Properties.Resources.String8;
                label22.Text = global::aleafia_reslang_id.Properties.Resources.String8;
                label7.Text = global::aleafia_reslang_id.Properties.Resources.String8;
                label10.Text = global::aleafia_reslang_id.Properties.Resources.String8;
                label43.Text = global::aleafia_reslang_id.Properties.Resources.String8;
                label50.Text = global::aleafia_reslang_id.Properties.Resources.String8;
                tabPage1.Text = global::aleafia_reslang_id.Properties.Resources.String9;
                tabPage2.Text = global::aleafia_reslang_id.Properties.Resources.String10;
                tabPage4.Text = global::aleafia_reslang_id.Properties.Resources.String11;
                groupBox1.Text = global::aleafia_reslang_id.Properties.Resources.String11;
                tabPage5.Text = global::aleafia_reslang_id.Properties.Resources.String12;
                label41.Text = global::aleafia_reslang_id.Properties.Resources.String13;
                label57.Text = global::aleafia_reslang_id.Properties.Resources.String13;
                groupBox2.Text = global::aleafia_reslang_id.Properties.Resources.String14;
                groupBox10.Text = global::aleafia_reslang_id.Properties.Resources.String15;
                groupBox12.Text = global::aleafia_reslang_id.Properties.Resources.String16;
                checkBox1.Text = global::aleafia_reslang_id.Properties.Resources.String17;
                checkBox2.Text = global::aleafia_reslang_id.Properties.Resources.String18;
                button4.Text = global::aleafia_reslang_id.Properties.Resources.String19;
                save.Text = global::aleafia_reslang_id.Properties.Resources.String20;
                button3.Text = global::aleafia_reslang_id.Properties.Resources.String21;
            }
        }
 
    }
}
