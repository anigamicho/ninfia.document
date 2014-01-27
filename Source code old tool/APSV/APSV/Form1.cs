using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace APSV
{
    public partial class Form1 : Form
    {
        #region variabel
        public MemoryStream NarcFile = new MemoryStream(); //Pokemon list data
        public MemoryStream NarcFile1 = new MemoryStream(); //Pokemon list data
        public MemoryStream MapFile = new MemoryStream(); // Pokemon list data
        public MemoryStream MapFile1 = new MemoryStream(); //Trainer list data

        public MemoryStream Header = new MemoryStream(); //Narc Header Data
        public MemoryStream Offset = new MemoryStream(); //Narc Header Data

        public uint FileCount;
        public uint FileOffset;
        public uint FileSize;
        public uint FATOffset;
        public uint FileCount1;
        public uint FileOffset1;
        public uint FileSize1;
        public uint FATOffset1;
        public uint Trainers;
        public uint listpokemon;
        public uint listpokemon1;

        public uint pokemons;
        public uint move1s;
        public uint move2s;
        public uint move3s;
        public uint move4s;
        public uint ev;
        public uint natures;
        public uint itemx;
        public uint unknown1x;
        public int filledpokemon;

        public uint sumpokemon;
        public int evs;
        public string evx;

        public string typeopen;
        public string a1, a2;
        public string pkmnolist;
        string Listnumber;

        public int checkt = 0;
        public string hexview;
        #endregion

        // margins for API call used in Paint
        private VistaApi.Margins marg;

        // Rectangles; one for each edge of the form
        private Rectangle topRect = Rectangle.Empty;
        private Rectangle botRect = Rectangle.Empty;
        private Rectangle lefRect = Rectangle.Empty;
        private Rectangle rigRect = Rectangle.Empty;
        
        public Form1()
        {
            this.Load += new System.EventHandler(this.Form1_Load);
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(591, 342);

            this.Text = "A-Battle Subway Editor " + ProductVersion;

            this.FitGlass();
            VistaApi.DwmExtendFrameIntoClientArea(this.Handle, ref marg); 
        }

        #region aero
        private void FitGlass()
        {
            // If DWM is not enabled then get out
            if (!this.IsGlassEnabled())
            {
                return;
            }

            // Set the Margins to their default values
            marg.Top = this.ClientSize.Height; // extend from the top
            marg.Left = 0;  // not used in this sample but could be
            marg.Right = 0; // not used in this sample but could be
            marg.Bottom = 0;// not used in this sample but could be

            this.Paint += new PaintEventHandler(this.Form1_Paint);

            // call the function that gives us glass, 
            // passing a reference to our inset Margins
            VistaApi.DwmExtendFrameIntoClientArea(this.Handle, ref marg);
        }

        private bool IsGlassEnabled()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                Debug.WriteLine("How about trying this on Vista?");
                return false;
            }

            //Check if DWM is enabled
            bool isGlassSupported = false;
            VistaApi.DwmIsCompositionEnabled(ref isGlassSupported);
            return isGlassSupported;
        }

        // Alpha-blending Paint after the glass extension
        // this seems better than the winforms transparency approach because here we can click on the glass!
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // black brush for Alpha transparency
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            Graphics g = e.Graphics;

            if (this.IsGlassEnabled())
            {
                // setup the rectangles
                topRect = new Rectangle(0, 0, this.ClientSize.Width, marg.Top);
                lefRect = new Rectangle(0, 0, marg.Left, this.ClientSize.Height);
                rigRect = new Rectangle(this.ClientSize.Width - marg.Right, 0, marg.Right, this.ClientSize.Height);
                botRect = new Rectangle(0, this.ClientSize.Height - marg.Bottom, this.ClientSize.Width, marg.Bottom);

                // Fill Rectangles
                g.FillRectangle(blackBrush, topRect);
                g.FillRectangle(blackBrush, lefRect);
                g.FillRectangle(blackBrush, rigRect);
                g.FillRectangle(blackBrush, botRect);
            }

            g.DrawString("hello. Am I on glass?", this.Font, blackBrush, 10, 10);

            blackBrush.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == VistaApi.WM_NCHITTEST // if this is a click
              && m.Result.ToInt32() == VistaApi.HTCLIENT // ...and it is on the client
              && this.IsOnGlass(m.LParam.ToInt32())) // ...and specifically in the glass area
            {
                m.Result = new IntPtr(VistaApi.HTCAPTION); // lie and say they clicked on the title bar
            }
        }

        private bool IsOnGlass(int lParam)
        {
            // sanity check
            if (!this.IsGlassEnabled())
            {
                return false;
            }

            // get screen coordinates
            int x = (lParam << 16) >> 16; // lo order word
            int y = lParam >> 16; // hi order word

            // translate screen coordinates to client area
            Point p = this.PointToClient(new Point(x, y));

            // work out if point clicked is on glass
            if (topRect.Contains(p) || lefRect.Contains(p) || rigRect.Contains(p) || botRect.Contains(p))
            {
                return true;
            }

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(255, 221, 220, 220);
            this.TransparencyKey = c;
            panel1.BackColor = c;
            menuStrip1.BackColor = c;
            toolStripStatusLabel4.BackColor = c;
        }
        #endregion

        #region read data
        private void ReadSourceData()
        {
            uint bytesx = 0;
            this.hexview = null;
            StringBuilder builder = new StringBuilder();
            //int.Parse(textBox2.Text);

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
                if ((i % 9) == (9 - 1))
                {
                    builder.Append(Environment.NewLine);
                }
            }

            hexview = builder.ToString();
        }

        private void ReadSourceData1()
        {
            uint bytesx = 0;
            this.hexview = null;
            StringBuilder builder = new StringBuilder();
            //int.Parse(textBox2.Text);

            this.MapFile1.Position = 0L;
            bytesx = 0;

            for (int i = 0; i < FileSize1; i++)
            {
                bytesx = (uint)this.MapFile1.ReadByte();
                string str = Convert.ToString((int)bytesx, 0x10).ToUpper();
                if (str.Length == 1)
                {
                    str = "0" + str;
                }
                builder.Append(str + " ");
                if ((i % 8) == (8 - 1))
                {
                    builder.Append(Environment.NewLine);
                }
            }

            hexview = builder.ToString();
        }


        private void ReadData()
        {
            int n;
            string m;

            this.MapFile.Position = 0L;

            this.ReadNext();
            this.Pokemon.SelectedValue = (int)this.pokemons;
            this.move_1.SelectedValue = (int)this.move1s;
            this.move_2.SelectedValue = (int)this.move2s;
            this.move_3.SelectedValue = (int)this.move3s;
            this.move_4.SelectedValue = (int)this.move4s;
            this.evs = (int)this.ev;
            this.evx = (Convert.ToString((int)this.evs, 2));
            this.textBox2.Text = (this.evs).ToString();

            if (evx.Length == 1)
            {
                this.evx = "00000" + this.evx;
            }

            if (evx.Length == 2)
            {
                this.evx = "0000" + this.evx;
            }

            if (evx.Length == 3)
            {
                this.evx = "000" + this.evx;
            }

            if (evx.Length == 4)
            {
                this.evx = "00" + this.evx;
            }

            if (evx.Length == 5)
            {
                this.evx = "0" + this.evx;
            }

            char[] array = this.evx.ToCharArray();

            if (array.Length < 7)
            {
                n = 0;

                comboBox2.SelectedIndex = 0;
            }
            else
            {
                n = array.Length - 6;
            }

            if (array.Length > 6)
            {
                if (array.Length < 8)
                {
                    if (array[0].ToString() == "1")
                    {
                        comboBox2.SelectedIndex = 1;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                }
                else
                {
                    m = array[0].ToString() + array[1].ToString();

                    if (m == "11")
                    {
                        comboBox2.SelectedIndex = 3;
                    }
                    else if (m == "10")
                    {
                        comboBox2.SelectedIndex = 2;
                    }
                    else if (m == "01")
                    {
                        comboBox2.SelectedIndex = 1;
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                }
            }

            if (array[0 + n].ToString() == "1")
            {
                
                ev_spdef.Checked = true;
            }
            else
            {
                ev_spdef.Checked = false;
            }
            if (array[1 + n].ToString() == "1")
            {
                ev_spatk.Checked = true;
            }
            else
            {
                ev_spatk.Checked = false;
            }
            if (array[2 + n].ToString() == "1")
            {
                ev_speed.Checked = true;
            }
            else
            {
                ev_speed.Checked = false;
            }
            if (array[3 + n].ToString() == "1")
            {
                ev_def.Checked = true;
            }
            else
            {
                ev_def.Checked = false;
            }
            if (array[4 + n].ToString() == "1")
            {
                ev_atk.Checked = true;
            }
            else
            {
                ev_atk.Checked = false;
            }
            if (array[5 + n].ToString() == "1")
            {
                ev_hp.Checked = true;
            }
            else
            {
                ev_hp.Checked = false;
            }
            this.textBox1.Text = this.evx;

            this.nature.SelectedValue = (int)this.natures;
            this.item.SelectedValue = (int)this.itemx;
            this.unknown1.Text = ((int)this.unknown1x).ToString();
        }

        private void ReadNext()
        {
            this.pokemons = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.move1s = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.move2s = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.move3s = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.move4s = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));

            while (this.pokemons > 0x800)
            {
                this.pokemons -= 0x800;
            }
            while (this.move1s > 0x800)
            {
                this.move1s -= 0x800;
            }
            while (this.move2s > 0x800)
            {
                this.move2s -= 0x800;
            }
            while (this.move3s > 0x800)
            {
                this.move3s -= 0x800;
            }
            while (this.move4s > 0x800)
            {
                this.move4s -= 0x800;
            }

            this.ev = 0;
            this.natures = 0;

            this.ev = (uint)this.MapFile.ReadByte();
            this.natures = (uint)this.MapFile.ReadByte();

            this.itemx = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.unknown1x = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
        }


        private void ReadTrainerdata()
        {
            this.MapFile1.Position = 0L;
            this.ReadNextTrainer();
            this.textBox4.Text = ((int)this.Trainers).ToString();
            this.textBox3.Text = ((int)this.sumpokemon).ToString();

            listBox1.Items.Clear();
            for (int i = 0; i < (int)this.sumpokemon; i++)
            {
                ReadNextTrainer1();
                Listnumber = ((int)this.listpokemon1).ToString();

                if (Listnumber.Length == 1)
                {
                    Listnumber = "0000" + Listnumber;
                }
                else if (Listnumber.Length == 2)
                {
                    Listnumber = "000" + Listnumber;
                }
                else if (Listnumber.Length == 3)
                {
                    Listnumber = "00" + Listnumber;
                }
                else if (Listnumber.Length == 4)
                {
                    Listnumber = "0" + Listnumber;
                }

                listBox1.Items.Add("# " + Listnumber);
            }

            listBox1.SelectedIndex = 0;
        }

        private void ReadNextTrainer()
        {
            this.Trainers = (uint)(this.MapFile1.ReadByte() + (this.MapFile1.ReadByte() * 0x100));
            this.sumpokemon = (uint)(this.MapFile1.ReadByte() + (this.MapFile1.ReadByte() * 0x100));
        }
        private void ReadNextTrainer1()
        {
            this.listpokemon1 = (uint)(this.MapFile1.ReadByte() + (this.MapFile1.ReadByte() * 0x100));
        }
        #endregion

        private void OpenPokemonList_Click(object sender, EventArgs e)
        {
            OpenFileDialog narcopen = new OpenFileDialog();
            narcopen.Title = "Open Battle Subway / PWT Pokemon data";
            narcopen.Filter = "Pkm Subway/PWT(*.narc)|*.narc|All Files (*.*)|*.*";
            if (narcopen.ShowDialog() == DialogResult.OK)
            {
                this.Text = "A-Battle Subway Editor [Pokemon Mode]";
                typeopen = "openpokemon";
                filledpokemon = 0;
                
                //this.Text = "Battle Subway/PWT [" + narcopen.SafeFileName + "]";

                NarcFile.SetLength(0);
                MapFile.SetLength(0);
                NarcFile1.SetLength(0);
                MapFile1.SetLength(0);

                BinaryReader reader = new BinaryReader(File.OpenRead(narcopen.FileName));
                byte[] buffer = new byte[reader.BaseStream.Length];
                reader.BaseStream.Position = 0L;
                this.NarcFile.Position = 0L;
                reader.Read(buffer, 0, (int)reader.BaseStream.Length);
                this.NarcFile.Write(buffer, 0, (int)reader.BaseStream.Length);
                reader.Close();
                this.NarcFile.Position = 0x18L;
                this.FileCount = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() << 8)) + (this.NarcFile.ReadByte() << 0x10)) + (this.NarcFile.ReadByte() << 0x18));

                this.FATOffset = (0x1c + (this.FileCount * 8)) + 0x18;

                //Pokemon.Items.Clear();
                //move_1.Items.Clear();
                //move_2.Items.Clear();
                //move_3.Items.Clear();
                //move_4.Items.Clear();
                //nature.Items.Clear();
                //item.Items.Clear();
                comboBox1.Items.Clear();
                listBox1.Items.Clear();

                this.Pokemon.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
                this.move_1.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.move_2.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.move_3.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.move_4.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.nature.DataSource = (ArrayList)Program.naturelist.GetArrayList().Clone();
                this.item.DataSource = (ArrayList)Program.itemlist.GetArrayList().Clone();

                reloadpkmlist();

                listBox1.SelectedIndex = 0;

                panel1.Enabled = true;

                this.toolStripStatusLabel3.Text = "Pokemon : " + narcopen.SafeFileName;
                this.toolStripStatusLabel1.Text = "Trainer : ";

                comboBox1.Enabled = false;
                comboBox1.Text = "Trainer";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                this.textBox5.Text = "";
            }

            button3.Enabled = true;
            button4.Enabled = false;
            savePokemonDataAsToolStripMenuItem.Enabled = false;
            saveTrainerPokemonAsToolStripMenuItem.Enabled = false;
            savePokemonDataAsToolStripMenuItem.Enabled = true;


            toolStripStatusLabel5.Text = + filledpokemon + " / " + FileCount + ", was registered a pokemon.";
        }

        private void reloadpkmlist()
        {
            for (int i = 0; i < FileCount; i++)
            {
                this.NarcFile.Position = 0x1c + (i * 8);
                this.FileOffset = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000));

                this.NarcFile.Position = this.FileOffset + this.FATOffset;

                this.pokemons = (uint)(this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100));

                if (i.ToString().Length == 1)
                {
                    pkmnolist = "0000" + i;
                }
                else if (i.ToString().Length == 2)
                {
                    pkmnolist = "000" + i;
                }
                else if (i.ToString().Length == 3)
                {
                    pkmnolist = "00" + i;
                }
                else if (i.ToString().Length == 4)
                {
                    pkmnolist = "0" + i;
                }

                if ((int)this.pokemons != 0)
                {
                    listBox1.Items.Add("#" + pkmnolist + " - " + Program.PokeList.SearchByValue((int)this.pokemons));
                    filledpokemon = filledpokemon + 1;
                }
                else
                {
                    listBox1.Items.Add("#" + pkmnolist + " (Empty)");
                }
            }
        }

        private void openTrainerPokemonDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a1 = "0";
            a2 = "0";

            OpenFileDialog narcopen = new OpenFileDialog();
            narcopen.Title = "Open Battle Subway / PWT Trainer data";
            narcopen.Filter = "Trainer Subway/PWT(*.narc)|*.narc|All Files (*.*)|*.*";
            if (narcopen.ShowDialog() == DialogResult.OK)
            {
                typeopen = "openpokemontrainer";

                NarcFile.SetLength(0);
                MapFile.SetLength(0);
                NarcFile1.SetLength(0);
                MapFile1.SetLength(0);

                a1 = "1";
            }

            OpenFileDialog narcopen1 = new OpenFileDialog();
            narcopen1.Title = "Open Battle Subway / PWT Pokemon data";
            narcopen1.Filter = "Pkm Subway/PWT(*.narc)|*.narc|All Files (*.*)|*.*";
            if (narcopen1.ShowDialog() == DialogResult.OK)
            {
                a2 = "1";
            }
            if (a1 == "1" && a2 == "1")
            {
                this.Text = "A-Battle Subway Editor [Pokemon + Trainer Mode]";

                if (a1 == "1")
                {
                    BinaryReader reader = new BinaryReader(File.OpenRead(narcopen.FileName));
                    byte[] buffer = new byte[reader.BaseStream.Length];
                    reader.BaseStream.Position = 0L;
                    this.NarcFile1.Position = 0L;
                    reader.Read(buffer, 0, (int)reader.BaseStream.Length);
                    this.NarcFile1.Write(buffer, 0, (int)reader.BaseStream.Length);
                    reader.Close();
                    this.NarcFile1.Position = 0x18L;
                    this.FileCount1 = (uint)(((this.NarcFile1.ReadByte() + (this.NarcFile1.ReadByte() << 8)) + (this.NarcFile1.ReadByte() << 0x10)) + (this.NarcFile1.ReadByte() << 0x18));

                    this.FATOffset1 = (0x1c + (this.FileCount1 * 8)) + 0x18;
                }
                if (a2 == "1")
                {
                    BinaryReader reader1 = new BinaryReader(File.OpenRead(narcopen1.FileName));
                    byte[] buffer1 = new byte[reader1.BaseStream.Length];
                    reader1.BaseStream.Position = 0L;
                    this.NarcFile.Position = 0L;
                    reader1.Read(buffer1, 0, (int)reader1.BaseStream.Length);
                    this.NarcFile.Write(buffer1, 0, (int)reader1.BaseStream.Length);
                    reader1.Close();
                    this.NarcFile.Position = 0x18L;
                    this.FileCount = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() << 8)) + (this.NarcFile.ReadByte() << 0x10)) + (this.NarcFile.ReadByte() << 0x18));

                    this.FATOffset = (0x1c + (this.FileCount * 8)) + 0x18;
                }

                comboBox1.Items.Clear();
                listBox1.Items.Clear();

                this.Pokemon.DataSource = (ArrayList)Program.PokeList.GetArrayList().Clone();
                this.move_1.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.move_2.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.move_3.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.move_4.DataSource = (ArrayList)Program.movelist.GetArrayList().Clone();
                this.nature.DataSource = (ArrayList)Program.naturelist.GetArrayList().Clone();
                this.item.DataSource = (ArrayList)Program.itemlist.GetArrayList().Clone();

                for (int i = 0; i < FileCount1; i++)
                {
                    comboBox1.Items.Add("Trainer #" + i);
                }

                comboBox1.Enabled = true;

                //this.Text = "Battle Subway/PWT [" + narcopen.SafeFileName + "/" + narcopen1.SafeFileName + "]";
                this.toolStripStatusLabel1.Text = "Trainer : " + narcopen.SafeFileName;
                this.toolStripStatusLabel3.Text = "Pokemon : " + narcopen1.SafeFileName;
                panel1.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }

            button3.Enabled = false;
            button4.Enabled = false;
            savePokemonDataAsToolStripMenuItem.Enabled = false;
            saveTrainerPokemonAsToolStripMenuItem.Enabled = false;
            savePokemonDataAsToolStripMenuItem.Enabled = true;

            toolStripStatusLabel5.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                this.listBox1.SelectedIndex = 0;
            }
            else if (this.listBox1.SelectedIndex >= this.listBox1.Items.Count)
            {
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            }

            if (typeopen == "openpokemon")
            {
                this.NarcFile.Position = 0x1c + (((int)this.listBox1.SelectedIndex) * 8);
            }
            if (typeopen == "openpokemontrainer")
            {
                this.textBox6.Text = listBox1.SelectedIndex.ToString();
                this.textBox5.Text = (this.listBox1.Text).Substring((this.listBox1.Text).Length - 5);
            }
            else
            {
                this.FileOffset = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000));
                this.FileSize = ((uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000))) - this.FileOffset;
                this.MapFile = new MemoryStream();
                this.MapFile.Position = 0L;
                this.MapFile.Write(this.NarcFile.ToArray(), (int)(this.FileOffset + this.FATOffset), (int)this.FileSize);

                this.MapFile.Position = 0L;

                ReadData();

                ReadSourceData();
                textBox7.Text = hexview;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex < 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            else if (this.comboBox1.SelectedIndex >= this.comboBox1.Items.Count)
            {
                this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
            }

            this.NarcFile1.Position = 0x1c + (((int)this.comboBox1.SelectedIndex) * 8);
            this.FileOffset1 = (uint)(((this.NarcFile1.ReadByte() + (this.NarcFile1.ReadByte() * 0x100)) + (this.NarcFile1.ReadByte() * 0x10000)) + (this.NarcFile1.ReadByte() * 0x1000000));
            this.FileSize1 = ((uint)(((this.NarcFile1.ReadByte() + (this.NarcFile1.ReadByte() * 0x100)) + (this.NarcFile1.ReadByte() * 0x10000)) + (this.NarcFile1.ReadByte() * 0x1000000))) - this.FileOffset1;
            this.MapFile1 = new MemoryStream();
            this.MapFile1.Position = 0L;
            this.MapFile1.Write(this.NarcFile1.ToArray(), (int)(this.FileOffset1 + this.FATOffset1), (int)this.FileSize1);

            this.MapFile1.Position = 0L;

            ReadSourceData1();
            textBox8.Text = hexview;

            ReadTrainerdata();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pokemonOffsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APSV.pop_up.offsetview f2 = new APSV.pop_up.offsetview(this);

            f2.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (typeopen == "openpokemontrainer")
            {
                this.NarcFile.Position = 0x1c + (int.Parse(this.textBox5.Text) * 8);

                this.FileOffset = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000));
                this.FileSize = ((uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000))) - this.FileOffset;
                this.MapFile = new MemoryStream();
                this.MapFile.Position = 0L;
                this.MapFile.Write(this.NarcFile.ToArray(), (int)(this.FileOffset + this.FATOffset), (int)this.FileSize);

                this.MapFile.Position = 0L;

                ReadData();

                ReadSourceData();
                textBox7.Text = hexview;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkt == 0)
            {
                checkt = 1;
                this.ClientSize = new System.Drawing.Size(843, 342);
                button5.Text = "<<";
            }
            else
            {
                checkt = 0;
                this.ClientSize = new System.Drawing.Size(591, 342);
                button5.Text = ">>";
            }
        }

        private void dataLocationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APSV.pop_up.Locationlist f2 = new APSV.pop_up.Locationlist(this);

            f2.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            typeopen = "";

            NarcFile.SetLength(0);
            MapFile.SetLength(0);
            NarcFile1.SetLength(0);
            MapFile1.SetLength(0);

            //comboBox1.Enabled = false;
            comboBox1.Items.Clear();
            comboBox1.Text = "Trainer";
            listBox1.Items.Clear();
            //listBox1.Enabled = false;
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            Pokemon.Text = "";
            comboBox2.Text = "";
            move_1.Text = "move 1";
            move_2.Text = "move 2";
            move_3.Text = "move 3";
            move_4.Text = "move 4";
            nature.Text = "";
            item.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            unknown1.Text = "";
            toolStripStatusLabel5.Text = "";
            this.toolStripStatusLabel1.Text = "Trainer :";
            this.toolStripStatusLabel3.Text = "Pokemon :";

            savePokemonDataAsToolStripMenuItem.Enabled = false;
        }
    }
}
