using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nini;
using Nini.Config;
using System.Security.Cryptography;

namespace AMSE
{
    public partial class Form1 : Form
    {
        public MemoryStream NarcFile = new MemoryStream();
        public MemoryStream MapFile = new MemoryStream();
        public uint FileCount;
        public uint FileOffset;
        public uint FileSize;
        public uint FATOffset;
        public uint moves;
        public uint min;
        public uint max;
        public int jumlah_File;
        public uint bytesx;
        public Add Modifie_move;
        public string pathlock = @"C:\";
        public string status;
        public string hash = "";

        public DataGridViewTextBoxColumn Column1;
        public DataGridViewTextBoxColumn Column2;
        public DataGridViewTextBoxColumn Column3;
        public DataGridViewTextBoxColumn Column4;

        private IConfigSource source = null;

        public void tablevalue(string x, int y, int z,int row)
        {
            this.Tabel1[1, row].Value = x;
            this.Tabel1[2, row].Value = y;
            this.Tabel1[3, row].Value = z;
        }

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

        public Form1()
        {
            InitializeComponent();
            LoadConfigs();
            tabel_set();

            
            this.Tabel1.SelectionChanged += new EventHandler(this.Tabel1_SelectionChanged);
            this.Tabel1.CellDoubleClick += new DataGridViewCellEventHandler(this.Tabel1_CellDoubleClick);
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);

            listBox1.ValueMember = "Value";
            listBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Name";


            this.Icon = global::AMSE.Properties.Resources.amse_icon;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadConfigs()
        {
            source = new IniConfigSource(Application.StartupPath + @"\amse_config.ini");

            IConfig config = source.Configs["Features"];

            if(source.Configs["Features"].Get("Tooltip") == "1"){
                toolTipToolStripMenuItem.Checked = true;
                toolTip1.Active = true;
            }
            else{
                toolTipToolStripMenuItem.Checked = false;
                toolTip1.Active = false;
            }

            if (source.Configs["Features"].Get("DoubleClicked") == "1")
            {
                doubleClickEditToolStripMenuItem.Checked = true;
                comboBox1.Visible = false;
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                button2.Visible = false;
            }
            else
            {
                doubleClickEditToolStripMenuItem.Checked = false;
                comboBox1.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                button2.Visible = true;
            }

            textBox3.Text = source.Configs["Features"].Get("Source_val");

            pathlock = source.Configs["Path"].Get("FileNarc");

            if (source.Configs["Features"].Get("SearchMode") == "1")
            {
                byStartToolStripMenuItem.Checked = true;
                byIndexOfToolStripMenuItem.Checked = false;
                byEndsWithToolStripMenuItem.Checked = false;
            }
            else if (source.Configs["Features"].Get("SearchMode") == "2")
            {
                byStartToolStripMenuItem.Checked = false;
                byIndexOfToolStripMenuItem.Checked = true;
                byEndsWithToolStripMenuItem.Checked = false;
            }
            else if (source.Configs["Features"].Get("SearchMode") == "3")
            {
                byStartToolStripMenuItem.Checked = false;
                byIndexOfToolStripMenuItem.Checked = false;
                byEndsWithToolStripMenuItem.Checked = true;
            }
            else
            {
                byStartToolStripMenuItem.Checked = true;
                byIndexOfToolStripMenuItem.Checked = false;
                byEndsWithToolStripMenuItem.Checked = false;
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (autoSaveConfigToolStripMenuItem.Checked)
            {
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
           if (toolTipToolStripMenuItem.Checked)
           {
                source.Configs["Features"].Set("Tooltip", "1");
           }
           else
           {
                source.Configs["Features"].Set("Tooltip", "0");
           }

           if (doubleClickEditToolStripMenuItem.Checked)
           {
                source.Configs["Features"].Set("DoubleClicked", "1");
           }
           else
           {
                source.Configs["Features"].Set("DoubleClicked", "0");
           }

           source.Configs["Features"].Set("Source_val", textBox3.Text);

           if (byStartToolStripMenuItem.Checked)
           {
               source.Configs["Features"].Set("SearchMode", "1");
           }
           if (byIndexOfToolStripMenuItem.Checked)
           {
               source.Configs["Features"].Set("SearchMode", "2");
           }
           if (byEndsWithToolStripMenuItem.Checked)
           {
               source.Configs["Features"].Set("SearchMode", "3");
           }

           source.Configs["Path"].Set("FileNarc", pathlock);
           source.Configs["Table"].Set("rows", "0x1A");

           source.Save();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }





        private void Open_NARC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Narc File";
            dialog.Filter = "Nitro Archive (a/0/1/8) (*.narc)|*.narc|All Files (*.*)|*.*";
            dialog.InitialDirectory = pathlock;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathlock = dialog.FileName.Replace(dialog.SafeFileName,"");
                BinaryReader reader = new BinaryReader(File.OpenRead(dialog.FileName));
                byte[] buffer = new byte[reader.BaseStream.Length];
                reader.BaseStream.Position = 0L;
                this.NarcFile.Position = 0L;
                reader.Read(buffer, 0, (int)reader.BaseStream.Length);
                this.NarcFile.Write(buffer, 0, (int)reader.BaseStream.Length);
                reader.Close();
                this.NarcFile.Position = 0x18L;
                this.FileCount = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() << 8)) + (this.NarcFile.ReadByte() << 0x10)) + (this.NarcFile.ReadByte() << 0x18));

                this.FATOffset = (0x1c + (this.FileCount * 8)) + 0x18;

                using (var cryptoProvider = new SHA1CryptoServiceProvider())
                {
                    hash = (BitConverter
                            .ToString(cryptoProvider.ComputeHash(buffer)).Replace("-", String.Empty));
                }


                string gamever_str = "";

                if (this.FileCount == 709)
                {
                    string yu = "CC1AB5B12460A1C1DAB6D6965DAACD0646CD1586";

                    if (hash == yu)
                    {
                        gamever_str = "BW2";
                    }
                    else
                    {
                        gamever_str = "BW2-modified";
                    }

                    listBox1.DataSource = (ArrayList)Program.Pokeabw2List.GetArrayList().Clone();
                    comboBox1.DataSource = (ArrayList)Program.PokeabwmoveList.GetArrayList().Clone();
                    status = "1";
                }
                else if (this.FileCount == 668)
                {
                    string yu = "F1D190627B1E64E35FE82CEE9633B33DB0EE9B08";

                    if (hash == yu)
                    {
                        gamever_str = "BW";
                    }
                    else
                    {
                        gamever_str = "BW-modified";
                    }

                    gamever_str = "BW";
                    listBox1.DataSource = (ArrayList)Program.Pokeabw1List.GetArrayList().Clone();
                    comboBox1.DataSource = (ArrayList)Program.PokeabwmoveList.GetArrayList().Clone();
                    status = "2";
                }
                else if (this.FileCount == 710)
                {
                    gamever_str = "BBVW2";
                    listBox1.DataSource = (ArrayList)Program.Pokeabw2List.GetArrayList().Clone();
                    comboBox1.DataSource = (ArrayList)Program.PokeabwmoveList.GetArrayList().Clone();
                    status = "3";
                }
                else
                {
                    gamever_str = "Undetected Version!";
                    status = "4";
                }

                this.File_Cnt.Text = "" + this.FileCount + " files";
                this.game_ver.Text = "" + gamever_str;


                if (status == "4")
                {
                    this.tabControl1.Enabled = false;
                    this.Save_NARC.Enabled = false;
                    this.toolTipToolStripMenuItem.Enabled = false;
                    this.listBox1.Enabled = false;
                    this.button1.Enabled = false;
                    this.textBox1.Enabled = false;

                    for (int i = 0; i < 26; i++)
                    {
                        this.Tabel1[0, (i)].Value = "";
                        this.Tabel1[1, (i)].Value = "";
                        this.Tabel1[2, (i)].Value = "";
                    }

                    listBox1.DataSource = null;
                    comboBox1.DataSource = null;

                    System.Windows.Forms.MessageBox.Show("Sorry, you just open wrong file!");
                }
                else
                {
                    this.tabControl1.Enabled = true;
                    this.Save_NARC.Enabled = true;
                    this.toolTipToolStripMenuItem.Enabled = true;
                    this.listBox1.Enabled = true;
                    this.button1.Enabled = true;
                    this.textBox1.Enabled = true;
                    this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);

                    this.listBox1.SelectedIndex = 1;
                    this.Move_NUM.SelectedIndex = 0;



                    if (status == "1")
                    {
                        System.Windows.Forms.MessageBox.Show("Game : BW2 \r\nFile Count : " + FileCount + " file\r\nSize : " + (float)NarcFile.Length / 1024 + " KB (" + NarcFile.Length + " byte)\r\nHash : " + hash, "Detail about this narc");
                    }
                    if (status == "2")
                    {
                        System.Windows.Forms.MessageBox.Show("Game : BW \r\nFile Count : " + FileCount + " file\r\nSize : " + (float)NarcFile.Length / 1024 + " KB (" + NarcFile.Length + " byte)", "Detail about this narc");
                    }
                    if (status == "3")
                    {
                        System.Windows.Forms.MessageBox.Show("Game : BBVW2 \r\nFile Count : " + FileCount + " file\r\nSize : " + (float)NarcFile.Length / 1024 + " KB (" + NarcFile.Length + " byte)", "Detail about this narc");
                    }
                    if (status == "5")
                    { //HGSS
                    }
                    if (status == "6")
                    { //DP
                    }
                    if (status == "7")
                    { //Pt
                    }
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Sorry, you abort to select a file", "?");
            }
        }

        private void ReadData()
        {
            this.MapFile.Position = 0L;

            for (int i = 0; i < jumlah_File; i++)
            {
                if (i == jumlah_File - 1)
                {
                    Tabel1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    Tabel1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                ReadNextEntry();
                this.Tabel1[1, i].Value = Program.PokeabwmoveList.SearchByValue((int)this.moves);
                this.Tabel1[2, i].Value = (int)this.max;
                this.Tabel1[3, i].Value = (int)this.min;
            }
        }

        private void ReadNextEntry()
        {
            this.moves = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));

            this.max = 0;
            this.min = 0;

            this.max = (uint)this.MapFile.ReadByte();
            this.min = (uint)this.MapFile.ReadByte();
        }



        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == "4")
            {

            }
            else
            {
                int jumlah_row;

                if (this.listBox1.SelectedIndex < 0)
                {
                    this.listBox1.SelectedIndex = 0;
                }
                else if (this.listBox1.SelectedIndex >= this.listBox1.Items.Count)
                {
                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                }

                this.NarcFile.Position = 0x1c + (((int)this.listBox1.SelectedValue) * 8);
                this.FileOffset = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000));
                this.FileSize = ((uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000))) - this.FileOffset;
                this.MapFile = new MemoryStream();
                this.MapFile.Position = 0L;
                this.MapFile.Write(this.NarcFile.ToArray(), (int)(this.FileOffset + this.FATOffset), (int)this.FileSize);

                this.MapFile.Position = 0L;
                this.ReadData();

                jumlah_File = (int)(FileSize / 4);

                if (FileSize % 4 != 0) 
                {
                    this.tabControl1.Enabled = false;
                    this.Save_NARC.Enabled = false;
                    this.toolTipToolStripMenuItem.Enabled = false;
                    this.listBox1.Enabled = false;
                    this.button1.Enabled = false;
                    this.textBox1.Enabled = false;

                    for (int i = 0; i < 26; i++)
                    {
                        this.Tabel1[0, (i)].Value = "";
                        this.Tabel1[1, (i)].Value = "";
                        this.Tabel1[2, (i)].Value = "";
                    }

                    this.comboBox1.DataSource = null;
                    this.listBox1.DataSource = null;
                    System.Windows.Forms.MessageBox.Show("Sorry, this data not match with moveset format!");

                }
                else
                {
                    jumlah_row = this.Tabel1.Rows.Count;

                    this.Move_NUM.SelectedIndex = ((jumlah_File) - 1);
                    this.toolStripStatusLabel8.Text = "ID : " + this.listBox1.SelectedValue;
                    this.toolStripStatusLabel4.Text = "0x" + ((this.FATOffset) + (FileOffset)).ToString("X");
                    this.toolStripStatusLabel6.Text = "Size : " + (FileSize) + " byte";
                    this.toolStripStatusLabel2.Text = ((jumlah_File) - 1) + " Move's";

                    for (int i = 0; i < jumlah_row; i++)
                    {
                        this.Tabel1[0, i].Value = "";
                        this.Tabel1[1, i].Value = "";
                        this.Tabel1[2, i].Value = "";
                        this.Tabel1[3, i].Value = "";

                        if (i == jumlah_File - 1)
                        {
                        }
                        else if (i > jumlah_File - 1)
                        {
                            Tabel1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        }
                        else
                        {
                            Tabel1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                    }


                    for (int i = 1; i < jumlah_File; i++)
                    {
                        this.Tabel1[0, (i - 1)].Value = i + "";
                    }

                    this.toolTip1.SetToolTip(this.listBox1, "Pokemon : " + this.listBox1.Text + "\r\nID : " + this.listBox1.SelectedValue + "\r\nBio : " + Program.Pokeabw2List.SearchBySpecies((int)this.listBox1.SelectedValue));

                    ReadData();
                    ReadSourceData();
                }
                
            }
        }

        private void Tabel1_CellDoubleClick(object sender, EventArgs e)
        {
            if (doubleClickEditToolStripMenuItem.Checked)
            {
                Add f2 = new Add(this);

                int ba = Tabel1.CurrentCell.RowIndex;

                if (ba < jumlah_File)
                {

                    this.textBox4.Text = "" + ba;
                    int count = this.Tabel1.SelectedRows.Count;

                    if ((string)this.Tabel1[1, ba].Value != null)
                    {
                        if (Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, ba].Value) > 559)
                        {
                            f2.comboBox1.SelectedIndex = 0;
                            f2.numericUpDown1.Value = 0;
                            f2.numericUpDown2.Value = 0;
                        }
                        else
                        {
                            f2.comboBox1.SelectedIndex = Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, ba].Value);


                            if ((int)this.Tabel1[2, ba].Value > 100)
                            {
                                f2.numericUpDown1.Maximum = 255;
                            }
                            else
                            {
                                f2.numericUpDown1.Maximum = 100;
                            }

                            f2.numericUpDown1.Value = (int)this.Tabel1[2, ba].Value;
                            f2.numericUpDown2.Value = (int)this.Tabel1[3, ba].Value;
                        }
                        f2.Row = Tabel1.CurrentCell.RowIndex;
                        f2.StartPosition = FormStartPosition.CenterParent;
                        f2.ShowDialog();
                    }
                    else
                    {
                        f2.comboBox1.SelectedIndex = 0;
                    }
                }
            }       
        }

        private void ReadSourceData()
        {
            int yu;
            StringBuilder builder = new StringBuilder();
            yu = int.Parse(textBox3.Text);

            this.MapFile.Position = 0L;
            this.bytesx = 0;

            for (int i = 0; i < (jumlah_File * 4); i++)
            {
                this.bytesx = (uint)this.MapFile.ReadByte();
                string str = Convert.ToString((int)this.bytesx, 0x10).ToUpper();
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
            this.textBox2.Text = builder.ToString();
        }

        private void Tabel1_SelectionChanged(object sender, EventArgs e)
        {
            int ba = Tabel1.CurrentCell.RowIndex;
            int zs = (Tabel1.SelectedRows.Count);

            if (ba < jumlah_File)
            {

                this.textBox4.Text = "" + ba;
                int count = this.Tabel1.SelectedRows.Count;

                if ((string)this.Tabel1[1, ba].Value != null)
                {
                    if (Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, ba].Value) > 559)
                    {
                        this.comboBox1.SelectedIndex = 0;
                        this.numericUpDown1.Value = 0;
                        this.numericUpDown2.Value = 0;
                    }
                    else
                    {
                        this.comboBox1.SelectedIndex = Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, ba].Value);

                        if ((int)this.Tabel1[2, ba].Value > 100)
                        {
                            numericUpDown1.Maximum = 255;
                        }
                        else
                        {
                            numericUpDown1.Maximum = 100;
                        }

                        this.numericUpDown1.Value = (int)this.Tabel1[2, ba].Value;
                        this.numericUpDown2.Value = (int)this.Tabel1[3, ba].Value;

                        if (zs < 2)
                        {
                            this.toolStripStatusLabel12.Text = "ID Move : " + Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, ba].Value) + " (" + Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, ba].Value).ToString("X") + ")";
                        }
                        else {
                            this.toolStripStatusLabel12.Text = "Move selected : " + zs + " move's";
                        }
                        
                    }
                }
                else
                {
                    this.comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int y, z,row;
            string x;

            row = int.Parse(textBox4.Text);
            x = this.comboBox1.Text;
            y = (int)this.numericUpDown1.Value;
            z = (int)this.numericUpDown2.Value;

                this.Tabel1[1, row].Value = x;
                this.Tabel1[2, row].Value = y;
                this.Tabel1[3, row].Value = z; 
        }

        private void WriteNextEntry()
        {
            this.MapFile.WriteByte((byte)(this.moves - ((this.moves >> 8) << 8)));
            this.MapFile.WriteByte((byte)(this.moves >> 8));

            this.MapFile.WriteByte((byte)this.max);
            this.MapFile.WriteByte((byte)this.min);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.MapFile.Position = 0L;
            for (int i = 0; i < (jumlah_File-1); i++)
            {
                this.moves = (uint)((int)Program.PokeabwmoveList.SearchByName((string)this.Tabel1[1, i].Value));
                this.max = (uint)((int)this.Tabel1[2, i].Value);
                this.min = (uint)((int)this.Tabel1[3, i].Value);
                WriteNextEntry();
            }

            this.NarcFile.Position = this.FileOffset + this.FATOffset;
            this.NarcFile.Write(this.MapFile.ToArray(), 0, (int)this.FileSize);

            ReadSourceData();
        }

        private void Save_NARC_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Narc File";
            dialog.Filter = "Nitro Archive (*.narc)|*.narc|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, this.NarcFile.ToArray());
            }
        }

        private void toolTipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolTipToolStripMenuItem.Checked)
            {
                toolTipToolStripMenuItem.Checked = false;
                toolTip1.Active = false;
            }
            else
            {
                toolTipToolStripMenuItem.Checked = true;
                toolTip1.Active = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void narcLocationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information f2 = new Information();
            f2.textBox1.Text = "Pokemon BW and BW2 narc location for \r\nPokemon Moveset list : \r\n\r\n      a/0/1/8\r\n\r\nPokemon DPPt narc location for \r\nPokemon Moveset list : \r\n\r\n     /poketool/personal/wotbl.narc\r\n\r\nPokemon HGSS narc location for \r\nPokemon Moveset list : \r\n\r\n     /a/0/3/3";
            f2.StartPosition = FormStartPosition.CenterParent;
            f2.ShowDialog();
            //f2.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList list ;

            if (this.FileCount == 709)
            {
                list = (ArrayList)Program.Pokeabw2List.GetArrayList().Clone();
            }
            else if (this.FileCount == 668)
            {
                list = (ArrayList)Program.Pokeabw1List.GetArrayList().Clone();
            }
            else if (this.FileCount == 710)
            {
                list = (ArrayList)Program.Pokeabw2List.GetArrayList().Clone();
            }
            else
            {
                list = (ArrayList)Program.Pokeabw2List.GetArrayList().Clone();
            }

            if (this.textBox1.Text == string.Empty)
            {
                this.listBox1.DataSource = list;
            }
            else
            {
                ArrayList list2 = new ArrayList();
                if (this.byStartToolStripMenuItem.Checked)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (((SelectBoxItem)list[i]).Name.StartsWith((this.textBox1.Text)))
                        {
                            list2.Add(list[i]);
                        }
                    }
                }
                if (this.byIndexOfToolStripMenuItem.Checked)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (((SelectBoxItem)list[j]).Name.IndexOf(this.textBox1.Text) != -1)
                        {
                            list2.Add(list[j]);
                        }
                    }
                }
                if (this.byEndsWithToolStripMenuItem.Checked)
                {
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (((SelectBoxItem)list[k]).Name.EndsWith(this.textBox1.Text))
                        {
                            list2.Add(list[k]);
                        }
                    }
                }
                this.listBox1.DataSource = list2;
                this.listBox1.Select();
            }
        }

        private void byStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byIndexOfToolStripMenuItem.Checked = false;
            byEndsWithToolStripMenuItem.Checked = false;
            byStartToolStripMenuItem.Checked = true;
        }

        private void byIndexOfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byIndexOfToolStripMenuItem.Checked = true;
            byEndsWithToolStripMenuItem.Checked = false;
            byStartToolStripMenuItem.Checked = false;
        }

        private void byEndsWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byIndexOfToolStripMenuItem.Checked = false;
            byEndsWithToolStripMenuItem.Checked = true;
            byStartToolStripMenuItem.Checked = false;
        }

        private void howToAddMoveSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information f2 = new Information();
            f2.textBox1.Text = "Steps:\r\n\r\n1)extract all file from narc \r\n2)added 4 byte for 1 slot move \r\n3)repack with a tools like puyo/ tinke/ kiwi.ds/ PPNR";
            f2.StartPosition = FormStartPosition.CenterParent;
            f2.ShowDialog();
            //f3.Show(this);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                toolStrip1.BackColor = colorDlg.Color;
                tabControl1.BackColor = colorDlg.Color;
                statusStrip1.BackColor = colorDlg.Color;
                this.BackColor = colorDlg.Color;
            }
        }

        private void backgroundTableColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Tabel1.BackColor = colorDlg.Color;
                Tabel1.BackgroundColor = colorDlg.Color;
                textBox2.BackColor = colorDlg.Color;
            }
        }

        private void doubleClickEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doubleClickEditToolStripMenuItem.Checked)
            {
                doubleClickEditToolStripMenuItem.Checked = false;
                comboBox1.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                button2.Visible = true;
            }
            else
            {
                doubleClickEditToolStripMenuItem.Checked = true;
                comboBox1.Visible = false;
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                button2.Visible = false;
            }
        }

        private void tabel_set()
        {
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.Column1.Name = "#";
            this.Column2.Name = "Move";
            this.Column3.Name = "lv";
            this.Column4.Name = "?";
            this.Column1.Width = 50;
            this.Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.Width = 50;
            this.Column4.Width = 50;
            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column2.Resizable = DataGridViewTriState.False;
            this.Column3.Resizable = DataGridViewTriState.False;
            this.Column4.Resizable = DataGridViewTriState.False;
            this.Column1.ReadOnly = true;
            this.Column2.ReadOnly = true;
            this.Column3.ReadOnly = true;
            this.Column4.ReadOnly = true;
            this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Tabel1.AllowUserToAddRows = false;
            this.Tabel1.AllowUserToDeleteRows = false;
            this.Tabel1.AllowUserToResizeColumns = false;
            this.Tabel1.AllowUserToResizeRows = false;
            this.Tabel1.ReadOnly = true;
            this.Tabel1.RowHeadersVisible = false;
            this.Tabel1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Tabel1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4 });
            this.Tabel1.Rows.Add(0x1A);
            this.Tabel1.RowHeadersVisible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void batchEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int za, zs, zz;
            za = Tabel1.CurrentCell.RowIndex;
            zs = Tabel1.SelectedRows.Count;
            zz = za - (zs - 1);

            if (zs > 1)
            {
                AMSE.Popup.batch w2 = new AMSE.Popup.batch(this);

                w2.textBox1.Text = "" + zz;
                w2.textBox2.Text = "" + za;

                w2.label1.Text = zs + " Move's selected";

                w2.StartPosition = FormStartPosition.CenterParent;
                w2.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Sorry, you must select more than" + zs +" move!");
            }
            
        }

        private void addRemoveMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, This feature was disabled (was removed) on public version!");
        }
    }
}

