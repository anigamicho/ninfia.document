using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Nini.Config;
using Nini;
using System.IO;
using System.Security.Cryptography;
using System.Collections;

namespace AIGT
{
    public partial class Form1 : Form
    {
        #region Memory variables
        public MemoryStream NarcFile = new MemoryStream();
        public MemoryStream MapFile = new MemoryStream();
        public uint FileCount;
        public uint FileOffset;
        public uint FileSize;
        public uint FATOffset;
        public string hash = "Sorry, Not detected data loaded";
        public string hash2 = "Sorry, Not detected data loaded";
        public string hexview = "";
        public string hexview2 = "";
        public string saveauto = "0";
        public int hexvalview = 16;
        public string filepath = @"C:\";
        public string igtfpath = @"C:\";
        public string igttpath = @"C:\";

        //private IConfigSource source = null;
        #endregion

        #region read variables
        string gamess = "0";
        private bool drag;
        private Point start_point;

        public uint index0;
        public uint pkmid;
        public uint formeid;
        public uint level;
        public uint ivhp;
        public uint ivatk;
        public uint ivdef;
        public uint ivspatk;
        public uint ivspdef;
        public uint ivspeed;

        public uint ability;
        public uint nature;
        public uint genderpkm;
        public uint tid;
        public uint sid;
        public uint ctcool;
        public uint ctbeauty;
        public uint cscute;
        public uint cssmart;
        public uint cstought;

        public uint itemid;
        public uint otgender;
        public uint unk1;
        public uint country;
        public uint pkmreqid;
        public uint genderreq;
        public uint index1;
        public uint index2;

        public int languageset;

        #endregion

        #region ++form++
        public Form1()
        {
            InitializeComponent();
            this.Text = "A-In-game Trade Editor - " + ProductVersion;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = global::AIGT.Properties.Resources.aigte_icon;
            loadconfig();

            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox3.SelectedIndexChanged += new EventHandler(this.comboBox3_SelectedIndexChanged);
            this.comboBox7.SelectedIndexChanged += new EventHandler(this.comboBox7_SelectedIndexChanged);
            this.comboBox4.SelectedIndexChanged += new EventHandler(this.comboBox4_SelectedIndexChanged);
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;

            base.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            base.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            base.MouseMove += new MouseEventHandler(this.Form_MouseMove);

            toolStrip1.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            toolStrip1.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            toolStrip1.MouseMove += new MouseEventHandler(this.Form_MouseMove);
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

        private void loadconfig()
        {
            if (File.Exists(Application.StartupPath + @"\data\aigt_config.ini"))
            {
                IConfigSource source = new IniConfigSource(Application.StartupPath + @"\data\aigt_config.ini");
                IConfig config = source.Configs["General"];

                if (source.Configs["General"].Get("Language") == "1")
                {
                }
                else
                {
                }
                if (source.Configs["General"].Get("Hexview") == "1")
                {
                    this.viewModeToolStripMenuItem.Checked = false;
                }
                else
                {
                    this.viewModeToolStripMenuItem.Checked = true;
                }
                if (source.Configs["General"].Get("gamemode") == "1")
                {

                }
                else
                {
                }
                if (source.Configs["General"].Get("AdvancedMode") == "1")
                {

                }
                else
                {
                }
                if (source.Configs["General"].Get("AutoSaveConfig") == "1")
                {
                    saveauto = "1";
                }
                else
                {
                    saveauto = "0";
                }
                if (source.Configs["General"].Get("AutoSavelist") == "1")
                {
                }
                else
                {
                }
                if (source.Configs["General"].Get("SpriteSource") == "1")
                {
                }
                else
                {
                }

                hexvalview = int.Parse(source.Configs["File"].Get("Hexviewvalue"));
                filepath = source.Configs["File"].Get("filepath");
                igtfpath = source.Configs["File"].Get("igtfpath");
                igttpath = source.Configs["File"].Get("igttpath");
            }
            else
            {
                
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           SaveConfig();
        }

        private void SaveConfig()
        {
            if (File.Exists(Application.StartupPath + @"\data\aigt_config.ini"))
            {
                IConfigSource source = new IniConfigSource(Application.StartupPath + @"\data\aigt_config.ini");

                source.Configs["General"].Set("Language", "1");
                if (this.viewModeToolStripMenuItem.Checked)
                {
                    source.Configs["General"].Set("Hexview", "2");
                }
                else
                {
                    source.Configs["General"].Set("Hexview", "1");
                }
                source.Configs["General"].Set("gamemode", "1");
                source.Configs["General"].Set("AdvancedMode", "1");
                source.Configs["General"].Set("AutoSaveConfig", "1");
                source.Configs["General"].Set("AutoSavelist", "0");
                source.Configs["General"].Set("SpriteSource", "0");

                source.Configs["File"].Set("Hexviewvalue", hexvalview);
                source.Configs["File"].Set("filepath", filepath);
                source.Configs["File"].Set("igtfpath", igtfpath);
                source.Configs["File"].Set("igttpath", igttpath);

                source.Save();
            }
            else
            {
                IniConfigSource source = new IniConfigSource();

                IConfig config = source.AddConfig("General");
                config.Set("Language", "1");
                config.Set("Hexview", "1");
                config.Set("gamemode", "1");
                config.Set("AdvancedMode", "1");
                config.Set("AutoSaveConfig", "1");
                config.Set("AutoSavelist", "0");
                config.Set("SpriteSource", "0");

                config = source.AddConfig("File");
                config.Set("Hexviewvalue", "16");
                config.Set("filepath", filepath);
                config.Set("igtfpath", igtfpath);
                config.Set("igttpath", igttpath);

                source.Save(Application.StartupPath + @"\data\aigt_config.ini");
            }
        }
        #endregion

        #region jumpsection
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://leafia.tk");
        }

        private void threadPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://projectpokemon.org/forums/showthread.php?26663-Andi-Pok%E9mon-Black-amp-White-Tools");
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

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for use this tools ^^ ...");
            this.Close();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AIGT.pop_up.Options menu = new AIGT.pop_up.Options(this);

            menu.StartPosition = FormStartPosition.CenterParent;
            menu.ShowDialog();
        }

        private void checkHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Narc File\r\n    " + hash + "\r\n\r\nCurrent selected data :\r\n    "+hash2);
        }

        private void saveTextcurrentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save File";
            dialog.Filter = "In-trade game file format (*.igtf)|*.igtf";
            dialog.FileName = "file_" + comboBox1.SelectedValue;
            dialog.InitialDirectory = igtfpath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //igtfpath = dialog.FileName.Replace(dialog.file, "");
                File.WriteAllBytes(dialog.FileName, this.MapFile.ToArray());
                MessageBox.Show("Data was saved !");
            }
            else
            {
                MessageBox.Show("Data was not saved !");
            }
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string hashfile;

            hashfile = "Narc checksum : \r\n    " + hash;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save File";
            dialog.Filter = "SHA-1 checksum file (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, hashfile);
            }
        }

        private void toolStripButton2_ButtonClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Narc File";
            dialog.Filter = "Nitro Archive (*.narc)|*.narc|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, this.NarcFile.ToArray());
                MessageBox.Show("Your data was saved ^^");
            }
        }

        private void autoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoSaveToolStripMenuItem.Checked)
            {
                autoSaveToolStripMenuItem.Checked = false;
            }
            else
            {
                autoSaveToolStripMenuItem.Checked = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region read data
        private void ReadData()
        {
            this.MapFile.Position = 0L;

            this.Readbwbw2();
            this.textBox1.Text = ((int)this.index0).ToString();
            this.comboBox2.SelectedValue = (int)this.pkmid;
            this.comboBox3.SelectedIndex = (int)this.formeid;
            this.numericUpDown1.Value = this.level;
            this.comboBox11.SelectedValue = (int)this.ivhp;
            this.comboBox12.SelectedValue = (int)this.ivatk;
            this.comboBox13.SelectedValue = (int)this.ivdef;
            this.comboBox14.SelectedValue = (int)this.ivspatk;
            this.comboBox15.SelectedValue = (int)this.ivspdef;
            this.comboBox16.SelectedValue = (int)this.ivspeed;
            this.comboBox5.SelectedIndex = (int)this.ability;
            this.comboBox6.SelectedValue = (int)this.nature;
            this.comboBox22.SelectedValue = (int)this.genderpkm;
            this.numericUpDown2.Value = this.tid;
            this.numericUpDown3.Value = this.sid;
            this.comboBox17.SelectedIndex = (int)this.ctcool;
            this.comboBox18.SelectedIndex = (int)this.ctbeauty;
            this.comboBox19.SelectedIndex = (int)this.cscute;
            this.comboBox20.SelectedIndex = (int)this.cssmart;
            this.comboBox21.SelectedIndex = (int)this.cstought;
            this.comboBox4.SelectedValue = (int)this.itemid;
            this.comboBox8.SelectedIndex = (int)this.otgender;
            this.numericUpDown16.Value = this.unk1;
            this.comboBox10.SelectedIndex = (int)this.country;
            this.comboBox7.SelectedValue = (int)this.pkmreqid;
            this.comboBox9.SelectedIndex = (int)this.genderreq;
            this.textBox2.Text = this.index1.ToString();
            this.textBox3.Text = this.index2.ToString();
        }

        private void ReadDatahgss()
        {
            this.MapFile.Position = 0L;

            this.ReadHGSS();
            this.textBox1.Text = "0";
            this.comboBox2.SelectedValue = (int)this.pkmid;
            this.comboBox3.SelectedIndex = 0;
            this.numericUpDown1.Value = 0;
            this.comboBox11.SelectedValue = (int)this.ivhp;
            this.comboBox12.SelectedValue = (int)this.ivatk;
            this.comboBox13.SelectedValue = (int)this.ivdef;
            this.comboBox14.SelectedValue = (int)this.ivspatk;
            this.comboBox15.SelectedValue = (int)this.ivspdef;
            this.comboBox16.SelectedValue = (int)this.ivspeed;
            this.numericUpDown4.Value = this.ability;
            this.comboBox6.SelectedValue = 0;
            this.comboBox22.SelectedValue = 0;
            this.numericUpDown2.Value = this.tid;
            this.numericUpDown3.Value = this.sid;
            this.comboBox17.SelectedIndex = (int)this.ctcool;
            this.comboBox18.SelectedIndex = (int)this.ctbeauty;
            this.comboBox19.SelectedIndex = (int)this.cscute;
            this.comboBox20.SelectedIndex = (int)this.cssmart;
            this.comboBox21.SelectedIndex = (int)this.cstought;
            this.numericUpDown5.Value = this.index2;
            this.comboBox4.SelectedValue = (int)this.itemid;
            this.comboBox8.SelectedIndex = (int)this.otgender;
            this.numericUpDown16.Value = this.unk1;
            this.comboBox10.SelectedIndex = (int)this.country;
            this.comboBox7.SelectedValue = (int)this.pkmreqid;
            this.comboBox9.SelectedIndex = (int)this.genderreq;
        }

        private void ReadDatadppt()
        {
            this.MapFile.Position = 0L;

            this.ReadDPPt();
            this.textBox1.Text = "0";
            this.comboBox2.SelectedValue = (int)this.pkmid;
            this.comboBox3.SelectedIndex = 0;
            this.numericUpDown1.Value = 0;
            this.comboBox11.SelectedValue = (int)this.ivhp;
            this.comboBox12.SelectedValue = (int)this.ivatk;
            this.comboBox13.SelectedValue = (int)this.ivdef;
            this.comboBox14.SelectedValue = (int)this.ivspatk;
            this.comboBox15.SelectedValue = (int)this.ivspdef;
            this.comboBox16.SelectedValue = (int)this.ivspeed;
            this.numericUpDown4.Value = this.ability;
            this.comboBox6.SelectedValue = 0;
            this.comboBox22.SelectedValue = 0;
            this.numericUpDown2.Value = this.tid;
            this.numericUpDown3.Value = this.sid;
            this.comboBox17.SelectedIndex = (int)this.ctcool;
            this.comboBox18.SelectedIndex = (int)this.ctbeauty;
            this.comboBox19.SelectedIndex = (int)this.cscute;
            this.comboBox20.SelectedIndex = (int)this.cssmart;
            this.comboBox21.SelectedIndex = (int)this.cstought;
            this.numericUpDown5.Value = this.index2;
            this.comboBox4.SelectedValue = (int)this.itemid;
            this.comboBox8.SelectedIndex = (int)this.otgender;
            this.numericUpDown16.Value = this.unk1;
            this.comboBox10.SelectedIndex = (int)this.country;
            this.comboBox7.SelectedValue = (int)this.pkmreqid;
            this.comboBox9.SelectedIndex = 0;
        }

        private void Readbwbw2()
        {
            this.index0 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.pkmid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.formeid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.level = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivhp = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivatk = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivdef = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspatk = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspdef = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspeed = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ability = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.nature = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.genderpkm = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.tid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.sid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.ctcool = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ctbeauty = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cscute = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cssmart = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cstought = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.itemid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.otgender = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.unk1 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.country = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.pkmreqid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.genderreq = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.index1 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.index2 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
        }

        private void ReadHGSS()
        {
            this.pkmid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivhp = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivatk = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivdef = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspatk = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspdef = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspeed = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ability = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.tid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.sid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.ctcool = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ctbeauty = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cscute = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cssmart = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cstought = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.index2 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.itemid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.otgender = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.unk1 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.country = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.pkmreqid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.genderreq = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
        }

        private void ReadDPPt()
        {
            this.pkmid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivhp = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivatk = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivdef = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspatk = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspdef = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ivspeed = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ability = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.tid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.sid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100));
            this.ctcool = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.ctbeauty = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cscute = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cssmart = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.cstought = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.index2 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.itemid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.otgender = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.unk1 = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.country = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
            this.pkmreqid = (uint)(this.MapFile.ReadByte() + (this.MapFile.ReadByte() * 0x100) + (this.MapFile.ReadByte() * 0x10000) + (this.MapFile.ReadByte() * 0x1000000));
        }
        #endregion

        #region write data

        private void ReadSourceData()
        {
            uint bytesx = 0;
            this.hexview2 = null;
            this.hexview = null;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
                //int.Parse(textBox2.Text);

            this.MapFile.Position = 0L;
            bytesx = 0;

            if (viewModeToolStripMenuItem.Checked)
            {
                this.NarcFile.Position = 0L;
                bytesx = 0;

                for (int i = 0; i < NarcFile.Length; i++)
                {
                    bytesx = (uint)this.NarcFile.ReadByte();
                    string str = Convert.ToString((int)bytesx, 0x10).ToUpper();
                    if (str.Length == 1)
                    {
                        str = "0" + str;
                    }
                    builder2.Append(str + " ");
                    if ((i % hexvalview) == (hexvalview - 1))
                    {
                        builder2.Append(Environment.NewLine);
                    }
                }

                hexview2 = builder2.ToString();
            }
            else
            {
                for (int i = 0; i < FileSize; i++)
                {
                    bytesx = (uint)this.MapFile.ReadByte();
                    string str = Convert.ToString((int)bytesx, 0x10).ToUpper();
                    if (str.Length == 1)
                    {
                        str = "0" + str;
                    }
                    builder.Append(str + " ");
                    if ((i % hexvalview) == (hexvalview - 1))
                    {
                        builder.Append(Environment.NewLine);
                    }
                }

                hexview = builder.ToString();
            }
        }

        private void Writebwbw2()
        {
            this.MapFile.WriteByte((byte)(((this.index0)) - ((this.index0 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.index0) >> 8) << 8) - ((this.index0 >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.index0) >> 16) << 16) - ((this.index0 >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.index0) >> 24)));

            this.MapFile.WriteByte((byte)(((this.pkmid)) - ((this.pkmid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.pkmid) >> 8) << 8) - ((this.pkmid >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.pkmid) >> 16) << 16) - ((this.pkmid >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.pkmid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.formeid)) - ((this.formeid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.formeid) >> 8) << 8) - ((this.formeid >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.formeid) >> 16) << 16) - ((this.formeid >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.formeid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.level)) - ((this.level >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.level) >> 8) << 8) - ((this.level >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.level) >> 16) << 16) - ((this.level >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.level) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivhp)) - ((this.ivhp >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivhp) >> 8) << 8) - ((this.ivhp >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ivhp) >> 16) << 16) - ((this.ivhp >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ivhp) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivatk)) - ((this.ivatk >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivatk) >> 8) << 8) - ((this.ivatk >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ivatk) >> 16) << 16) - ((this.ivatk >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ivatk) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivdef)) - ((this.ivdef >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivdef) >> 8) << 8) - ((this.ivdef >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ivdef) >> 16) << 16) - ((this.ivdef >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ivdef) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspatk)) - ((this.ivspatk >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspatk) >> 8) << 8) - ((this.ivspatk >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ivspatk) >> 16) << 16) - ((this.ivspatk >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ivspatk) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspdef)) - ((this.ivspdef >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspdef) >> 8) << 8) - ((this.ivspdef >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ivspdef) >> 16) << 16) - ((this.ivspdef >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ivspdef) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspeed)) - ((this.ivspeed >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspeed) >> 8) << 8) - ((this.ivspeed >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ivspeed) >> 16) << 16) - ((this.ivspeed >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ivspeed) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ability)) - ((this.ability >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ability) >> 8) << 8) - ((this.ability >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ability) >> 16) << 16) - ((this.ability >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ability) >> 24)));

            this.MapFile.WriteByte((byte)(((this.nature)) - ((this.nature >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.nature) >> 8) << 8) - ((this.nature >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.nature) >> 16) << 16) - ((this.nature >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.nature) >> 24)));

            this.MapFile.WriteByte((byte)(((this.genderpkm)) - ((this.genderpkm >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.genderpkm) >> 8) << 8) - ((this.genderpkm >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.genderpkm) >> 16) << 16) - ((this.genderpkm >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.genderpkm) >> 24)));

            this.MapFile.WriteByte((byte)(((this.tid)) - ((this.tid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((this.tid) >> 8)));

            this.MapFile.WriteByte((byte)(((this.sid)) - ((this.sid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((this.sid) >> 8)));

            this.MapFile.WriteByte((byte)(((this.ctcool)) - ((this.ctcool >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ctcool) >> 8) << 8) - ((this.ctcool >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ctcool) >> 16) << 16) - ((this.ctcool >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ctcool) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ctbeauty)) - ((this.ctbeauty >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ctbeauty) >> 8) << 8) - ((this.ctbeauty >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.ctbeauty) >> 16) << 16) - ((this.ctbeauty >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.ctbeauty) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cscute)) - ((this.cscute >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cscute) >> 8) << 8) - ((this.cscute >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.cscute) >> 16) << 16) - ((this.cscute >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.cscute) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cssmart)) - ((this.cssmart >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cssmart) >> 8) << 8) - ((this.cssmart >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.cssmart) >> 16) << 16) - ((this.cssmart >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.cssmart) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cstought)) - ((this.cstought >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cstought) >> 8) << 8) - ((this.cstought >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.cstought) >> 16) << 16) - ((this.cstought >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.cstought) >> 24)));

            this.MapFile.WriteByte((byte)(((this.itemid)) - ((this.itemid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.itemid) >> 8) << 8) - ((this.itemid >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.itemid) >> 16) << 16) - ((this.itemid >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.itemid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.otgender)) - ((this.otgender >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.otgender) >> 8) << 8) - ((this.otgender >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.otgender) >> 16) << 16) - ((this.otgender >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.otgender) >> 24)));

            this.MapFile.WriteByte((byte)(((this.unk1)) - ((this.unk1 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.unk1) >> 8) << 8) - ((this.unk1 >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.unk1) >> 16) << 16) - ((this.unk1 >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.unk1) >> 24)));

            this.MapFile.WriteByte((byte)(((this.country)) - ((this.country >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.country) >> 8) << 8) - ((this.country >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.country) >> 16) << 16) - ((this.country >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.country) >> 24)));

            this.MapFile.WriteByte((byte)(((this.pkmreqid)) - ((this.pkmreqid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.pkmreqid) >> 8) << 8) - ((this.pkmreqid >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.pkmreqid) >> 16) << 16) - ((this.pkmreqid >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.pkmreqid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.genderreq)) - ((this.genderreq >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.genderreq) >> 8) << 8) - ((this.genderreq >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.genderreq) >> 16) << 16) - ((this.genderreq >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.genderreq) >> 24)));

            this.MapFile.WriteByte((byte)(((this.index1)) - ((this.index1 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.index1) >> 8) << 8) - ((this.index1 >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.index1) >> 16) << 16) - ((this.index1 >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.index1) >> 24)));

            this.MapFile.WriteByte((byte)(((this.index2)) - ((this.index2 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.index2) >> 8) << 8) - ((this.index2 >> 16) << 16))>>8));
            this.MapFile.WriteByte((byte)(((((this.index2) >> 16) << 16) - ((this.index2 >> 24) << 24))>>16));
            this.MapFile.WriteByte((byte)(((this.index2) >> 24)));
        }

        private void Writehgss()
        {
            this.MapFile.WriteByte((byte)(((this.pkmid)) - ((this.pkmid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.pkmid) >> 8) << 8) - ((this.pkmid >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.pkmid) >> 16) << 16) - ((this.pkmid >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.pkmid) >> 24)));
            
            this.MapFile.WriteByte((byte)(((this.ivhp)) - ((this.ivhp >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivhp) >> 8) << 8) - ((this.ivhp >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivhp) >> 16) << 16) - ((this.ivhp >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivhp) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivatk)) - ((this.ivatk >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivatk) >> 8) << 8) - ((this.ivatk >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivatk) >> 16) << 16) - ((this.ivatk >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivatk) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivdef)) - ((this.ivdef >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivdef) >> 8) << 8) - ((this.ivdef >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivdef) >> 16) << 16) - ((this.ivdef >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivdef) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspatk)) - ((this.ivspatk >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspatk) >> 8) << 8) - ((this.ivspatk >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivspatk) >> 16) << 16) - ((this.ivspatk >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivspatk) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspdef)) - ((this.ivspdef >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspdef) >> 8) << 8) - ((this.ivspdef >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivspdef) >> 16) << 16) - ((this.ivspdef >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivspdef) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspeed)) - ((this.ivspeed >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspeed) >> 8) << 8) - ((this.ivspeed >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivspeed) >> 16) << 16) - ((this.ivspeed >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivspeed) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ability)) - ((this.ability >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ability) >> 8) << 8) - ((this.ability >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ability) >> 16) << 16) - ((this.ability >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ability) >> 24)));

            this.MapFile.WriteByte((byte)(((this.tid)) - ((this.tid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((this.tid) >> 8)));

            this.MapFile.WriteByte((byte)(((this.sid)) - ((this.sid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((this.sid) >> 8)));

            this.MapFile.WriteByte((byte)(((this.ctcool)) - ((this.ctcool >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ctcool) >> 8) << 8) - ((this.ctcool >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ctcool) >> 16) << 16) - ((this.ctcool >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ctcool) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ctbeauty)) - ((this.ctbeauty >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ctbeauty) >> 8) << 8) - ((this.ctbeauty >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ctbeauty) >> 16) << 16) - ((this.ctbeauty >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ctbeauty) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cscute)) - ((this.cscute >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cscute) >> 8) << 8) - ((this.cscute >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.cscute) >> 16) << 16) - ((this.cscute >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.cscute) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cssmart)) - ((this.cssmart >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cssmart) >> 8) << 8) - ((this.cssmart >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.cssmart) >> 16) << 16) - ((this.cssmart >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.cssmart) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cstought)) - ((this.cstought >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cstought) >> 8) << 8) - ((this.cstought >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.cstought) >> 16) << 16) - ((this.cstought >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.cstought) >> 24)));

            this.MapFile.WriteByte((byte)(((this.index2)) - ((this.index2 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.index2) >> 8) << 8) - ((this.index2 >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.index2) >> 16) << 16) - ((this.index2 >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.index2) >> 24)));

            this.MapFile.WriteByte((byte)(((this.itemid)) - ((this.itemid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.itemid) >> 8) << 8) - ((this.itemid >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.itemid) >> 16) << 16) - ((this.itemid >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.itemid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.otgender)) - ((this.otgender >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.otgender) >> 8) << 8) - ((this.otgender >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.otgender) >> 16) << 16) - ((this.otgender >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.otgender) >> 24)));

            this.MapFile.WriteByte((byte)(((this.unk1)) - ((this.unk1 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.unk1) >> 8) << 8) - ((this.unk1 >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.unk1) >> 16) << 16) - ((this.unk1 >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.unk1) >> 24)));

            this.MapFile.WriteByte((byte)(((this.country)) - ((this.country >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.country) >> 8) << 8) - ((this.country >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.country) >> 16) << 16) - ((this.country >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.country) >> 24)));

            this.MapFile.WriteByte((byte)(((this.pkmreqid)) - ((this.pkmreqid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.pkmreqid) >> 8) << 8) - ((this.pkmreqid >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.pkmreqid) >> 16) << 16) - ((this.pkmreqid >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.pkmreqid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.genderreq)) - ((this.genderreq >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.genderreq) >> 8) << 8) - ((this.genderreq >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.genderreq) >> 16) << 16) - ((this.genderreq >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.genderreq) >> 24)));
        }

        private void Writedppt()
        {
            this.MapFile.WriteByte((byte)(((this.pkmid)) - ((this.pkmid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.pkmid) >> 8) << 8) - ((this.pkmid >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.pkmid) >> 16) << 16) - ((this.pkmid >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.pkmid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivhp)) - ((this.ivhp >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivhp) >> 8) << 8) - ((this.ivhp >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivhp) >> 16) << 16) - ((this.ivhp >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivhp) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivatk)) - ((this.ivatk >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivatk) >> 8) << 8) - ((this.ivatk >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivatk) >> 16) << 16) - ((this.ivatk >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivatk) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivdef)) - ((this.ivdef >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivdef) >> 8) << 8) - ((this.ivdef >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivdef) >> 16) << 16) - ((this.ivdef >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivdef) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspatk)) - ((this.ivspatk >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspatk) >> 8) << 8) - ((this.ivspatk >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivspatk) >> 16) << 16) - ((this.ivspatk >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivspatk) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspdef)) - ((this.ivspdef >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspdef) >> 8) << 8) - ((this.ivspdef >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivspdef) >> 16) << 16) - ((this.ivspdef >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivspdef) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ivspeed)) - ((this.ivspeed >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ivspeed) >> 8) << 8) - ((this.ivspeed >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ivspeed) >> 16) << 16) - ((this.ivspeed >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ivspeed) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ability)) - ((this.ability >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ability) >> 8) << 8) - ((this.ability >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ability) >> 16) << 16) - ((this.ability >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ability) >> 24)));

            this.MapFile.WriteByte((byte)(((this.tid)) - ((this.tid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((this.tid) >> 8)));

            this.MapFile.WriteByte((byte)(((this.sid)) - ((this.sid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((this.sid) >> 8)));

            this.MapFile.WriteByte((byte)(((this.ctcool)) - ((this.ctcool >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ctcool) >> 8) << 8) - ((this.ctcool >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ctcool) >> 16) << 16) - ((this.ctcool >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ctcool) >> 24)));

            this.MapFile.WriteByte((byte)(((this.ctbeauty)) - ((this.ctbeauty >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.ctbeauty) >> 8) << 8) - ((this.ctbeauty >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.ctbeauty) >> 16) << 16) - ((this.ctbeauty >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.ctbeauty) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cscute)) - ((this.cscute >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cscute) >> 8) << 8) - ((this.cscute >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.cscute) >> 16) << 16) - ((this.cscute >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.cscute) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cssmart)) - ((this.cssmart >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cssmart) >> 8) << 8) - ((this.cssmart >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.cssmart) >> 16) << 16) - ((this.cssmart >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.cssmart) >> 24)));

            this.MapFile.WriteByte((byte)(((this.cstought)) - ((this.cstought >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.cstought) >> 8) << 8) - ((this.cstought >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.cstought) >> 16) << 16) - ((this.cstought >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.cstought) >> 24)));

            this.MapFile.WriteByte((byte)(((this.index2)) - ((this.index2 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.index2) >> 8) << 8) - ((this.index2 >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.index2) >> 16) << 16) - ((this.index2 >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.index2) >> 24)));

            this.MapFile.WriteByte((byte)(((this.itemid)) - ((this.itemid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.itemid) >> 8) << 8) - ((this.itemid >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.itemid) >> 16) << 16) - ((this.itemid >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.itemid) >> 24)));

            this.MapFile.WriteByte((byte)(((this.otgender)) - ((this.otgender >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.otgender) >> 8) << 8) - ((this.otgender >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.otgender) >> 16) << 16) - ((this.otgender >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.otgender) >> 24)));

            this.MapFile.WriteByte((byte)(((this.unk1)) - ((this.unk1 >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.unk1) >> 8) << 8) - ((this.unk1 >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.unk1) >> 16) << 16) - ((this.unk1 >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.unk1) >> 24)));

            this.MapFile.WriteByte((byte)(((this.country)) - ((this.country >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.country) >> 8) << 8) - ((this.country >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.country) >> 16) << 16) - ((this.country >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.country) >> 24)));

            this.MapFile.WriteByte((byte)(((this.pkmreqid)) - ((this.pkmreqid >> 8) << 8)));
            this.MapFile.WriteByte((byte)(((((this.pkmreqid) >> 8) << 8) - ((this.pkmreqid >> 16) << 16)) >> 8));
            this.MapFile.WriteByte((byte)(((((this.pkmreqid) >> 16) << 16) - ((this.pkmreqid >> 24) << 24)) >> 16));
            this.MapFile.WriteByte((byte)(((this.pkmreqid) >> 24)));
        }

        private void SaveE()
        {
            if (gamess == "1" || gamess == "2")
            {
                this.MapFile.Position = 0L;
                this.index0 = (uint)(int.Parse(this.textBox1.Text));
                this.pkmid = (uint)((int)(this.comboBox2.SelectedValue));
                this.formeid = (uint)((int)(this.comboBox3.SelectedIndex));
                this.level = (uint)this.numericUpDown1.Value;
                this.ivhp = (uint)((int)(this.comboBox11.SelectedValue));
                this.ivatk = (uint)((int)(this.comboBox12.SelectedValue));
                this.ivdef = (uint)((int)(this.comboBox13.SelectedValue));
                this.ivspatk = (uint)((int)(this.comboBox14.SelectedValue));
                this.ivspdef = (uint)((int)(this.comboBox15.SelectedValue));
                this.ivspeed = (uint)((int)(this.comboBox16.SelectedValue));
                this.ability = (uint)((int)(this.comboBox5.SelectedIndex));
                this.nature = (uint)((int)(this.comboBox6.SelectedValue));
                this.genderpkm = (uint)((int)(this.comboBox22.SelectedValue));
                this.tid = (uint)this.numericUpDown2.Value;
                this.sid = (uint)this.numericUpDown3.Value;
                this.ctcool = (uint)((int)(this.comboBox17.SelectedIndex));
                this.ctbeauty = (uint)((int)(this.comboBox18.SelectedIndex));
                this.cscute = (uint)((int)(this.comboBox19.SelectedIndex));
                this.cssmart = (uint)((int)(this.comboBox20.SelectedIndex));
                this.cstought = (uint)((int)(this.comboBox21.SelectedIndex));
                this.itemid = (uint)((int)(this.comboBox4.SelectedValue));
                this.otgender = (uint)((int)(this.comboBox8.SelectedIndex));
                this.unk1 = (uint)this.numericUpDown16.Value;
                this.country = (uint)((int)(this.comboBox10.SelectedIndex));
                this.pkmreqid = (uint)((int)(this.comboBox7.SelectedValue));
                this.genderreq = (uint)((int)(this.comboBox9.SelectedIndex));
                this.index1 = (uint)(int.Parse(this.textBox2.Text));
                this.index2 = (uint)(int.Parse(this.textBox3.Text));
                this.Writebwbw2();
            }
            else if (gamess == "3")
            {
                this.MapFile.Position = 0L;
                this.pkmid = (uint)((int)(this.comboBox2.SelectedValue));
                this.ivhp = (uint)((int)(this.comboBox11.SelectedValue));
                this.ivatk = (uint)((int)(this.comboBox12.SelectedValue));
                this.ivdef = (uint)((int)(this.comboBox13.SelectedValue));
                this.ivspatk = (uint)((int)(this.comboBox14.SelectedValue));
                this.ivspdef = (uint)((int)(this.comboBox15.SelectedValue));
                this.ivspeed = (uint)((int)(this.comboBox16.SelectedValue));
                this.ability = (uint)((int)(this.numericUpDown4.Value));
                this.tid = (uint)this.numericUpDown2.Value;
                this.sid = (uint)this.numericUpDown3.Value;
                this.ctcool = (uint)((int)(this.comboBox17.SelectedIndex));
                this.ctbeauty = (uint)((int)(this.comboBox18.SelectedIndex));
                this.cscute = (uint)((int)(this.comboBox19.SelectedIndex));
                this.cssmart = (uint)((int)(this.comboBox20.SelectedIndex));
                this.cstought = (uint)((int)(this.comboBox21.SelectedIndex));
                this.index2 = (uint)(this.numericUpDown5.Value);
                this.itemid = (uint)((int)(this.comboBox4.SelectedValue));
                this.otgender = (uint)((int)(this.comboBox8.SelectedIndex));
                this.unk1 = (uint)this.numericUpDown16.Value;
                this.country = (uint)((int)(this.comboBox10.SelectedIndex));
                this.pkmreqid = (uint)((int)(this.comboBox7.SelectedValue));
                this.Writedppt();
            }
            else if (gamess == "4")
            {
                this.MapFile.Position = 0L;
                this.pkmid = (uint)((int)(this.comboBox2.SelectedValue));
                this.ivhp = (uint)((int)(this.comboBox11.SelectedValue));
                this.ivatk = (uint)((int)(this.comboBox12.SelectedValue));
                this.ivdef = (uint)((int)(this.comboBox13.SelectedValue));
                this.ivspatk = (uint)((int)(this.comboBox14.SelectedValue));
                this.ivspdef = (uint)((int)(this.comboBox15.SelectedValue));
                this.ivspeed = (uint)((int)(this.comboBox16.SelectedValue));
                this.ability = (uint)((int)(this.numericUpDown4.Value));
                this.tid = (uint)this.numericUpDown2.Value;
                this.sid = (uint)this.numericUpDown3.Value;
                this.ctcool = (uint)((int)(this.comboBox17.SelectedIndex));
                this.ctbeauty = (uint)((int)(this.comboBox18.SelectedIndex));
                this.cscute = (uint)((int)(this.comboBox19.SelectedIndex));
                this.cssmart = (uint)((int)(this.comboBox20.SelectedIndex));
                this.cstought = (uint)((int)(this.comboBox21.SelectedIndex));
                this.index2 = (uint)(this.numericUpDown5.Value);
                this.itemid = (uint)((int)(this.comboBox4.SelectedValue));
                this.otgender = (uint)((int)(this.comboBox8.SelectedIndex));
                this.unk1 = (uint)this.numericUpDown16.Value;
                this.country = (uint)((int)(this.comboBox10.SelectedIndex));
                this.pkmreqid = (uint)((int)(this.comboBox7.SelectedValue));
                this.genderreq = (uint)((int)(this.comboBox9.SelectedIndex));
                
                this.Writehgss();
            }
            this.NarcFile.Position = this.FileOffset + this.FATOffset;
            this.NarcFile.Write(this.MapFile.ToArray(), 0, (int)this.FileSize);
        }

        private void toolStripButton3_ButtonClick(object sender, EventArgs e)
        {
            if (autoSaveToolStripMenuItem.Checked)
            {
                MessageBox.Show("Please turn off auto save ^^ ...");
            }
            else
            {
                if (gamess == "1" || gamess == "2" || gamess == "3" || gamess == "4")
                {
                    this.SaveE();
                }
            }

        }
        #endregion

        //+++Main Method+++//

        private void toolStripButton1_ButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog narcopen = new OpenFileDialog();
            narcopen.Title = "Open Narc File";
            narcopen.Filter = "Nitro Archive (*.narc)|*.narc|A-binary Extract file (*.bin)|*.bin|All Files (*.*)|*.*";
            narcopen.InitialDirectory = filepath;
            if (narcopen.ShowDialog() == DialogResult.OK)
            {
                this.Text = "A-In-game Trade Editor - [" + narcopen.SafeFileName + "]";
                NarcFile.SetLength(0);
                MapFile.SetLength(0);

                filepath = narcopen.FileName.Replace(narcopen.SafeFileName, "");
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

                #region checking is narc or not
                this.NarcFile.Position = 0L;
                byte[] bytt1= new byte[] { 0x4e, 0x41, 0x52, 0x43 }; //narc extension name
                byte[] bytt2 = new byte[] { (byte)this.NarcFile.ReadByte(), (byte)this.NarcFile.ReadByte(), (byte)this.NarcFile.ReadByte(), (byte)this.NarcFile.ReadByte() };

                bool flag = true;

                for (int i = 0; i < 4; i++)
                {
                    if (bytt1[i] != bytt2[i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    //toolStripStatuAsLabel2.Text = "is narc file.";
                }
                #endregion

                #region hash SHA-1
                using (var cryptoProvider = new SHA1CryptoServiceProvider())
                {
                    hash = (BitConverter
                            .ToString(cryptoProvider.ComputeHash(buffer)).Replace("-", String.Empty));
                }
                #endregion

                file0FilesToolStripMenuItem.Text = "File : " + FileCount + " file's";
                sizeToolStripMenuItem.Text = "Size : " + ((float)NarcFile.Length / 1024).ToString().Replace(".", ",") + " KB (" + NarcFile.Length + " byte)";

                #region clone datasource
                comboBox6.DataSource = (ArrayList)Program.pntl.GetArrayList().Clone();
                comboBox22.DataSource = (ArrayList)Program.pgdrl.GetArrayList().Clone();
                comboBox2.DataSource = (ArrayList)Program.plbw.GetArrayList().Clone();
                comboBox7.DataSource = (ArrayList)Program.plbw.GetArrayList().Clone();
                comboBox11.DataSource = (ArrayList)Program.ivl.GetArrayList().Clone();
                comboBox12.DataSource = (ArrayList)Program.ivl.GetArrayList().Clone();
                comboBox13.DataSource = (ArrayList)Program.ivl.GetArrayList().Clone();
                comboBox14.DataSource = (ArrayList)Program.ivl.GetArrayList().Clone();
                comboBox15.DataSource = (ArrayList)Program.ivl.GetArrayList().Clone();
                comboBox16.DataSource = (ArrayList)Program.ivl.GetArrayList().Clone();
                #endregion

                if (this.FileCount == 31) //bw2
                {
                    gamess = "1"; 
                    comboBox4.DataSource = (ArrayList)Program.ilbw2.GetArrayList().Clone();
                    comboBox1.DataSource = (ArrayList)Program.itrl2.GetArrayList().Clone();

                    bW2A163ToolStripMenuItem.Checked = true;
                    bWA165ToolStripMenuItem.Checked = false;
                    hGSSTradelistnarcToolStripMenuItem.Checked = false;
                    dPToolStripMenuItem1.Checked = false;
                }
                else if (this.FileCount == 13) 
                {
                    this.NarcFile.Position = 0x9c;
                    uint check;

                    check = (uint)this.NarcFile.ReadByte();

                    if (check == 0)//bw
                    {
                        gamess = "2";
                        comboBox4.DataSource = (ArrayList)Program.ilbw1.GetArrayList().Clone();
                        comboBox1.DataSource = (ArrayList)Program.itrl1.GetArrayList().Clone();

                        bW2A163ToolStripMenuItem.Checked = false;
                        hGSSTradelistnarcToolStripMenuItem.Checked = false;
                        dPToolStripMenuItem1.Checked = false;
                        bWA165ToolStripMenuItem.Checked = true;
                    }
                    else//hgss
                    {
                        gamess = "4";
                        comboBox2.DataSource = (ArrayList)Program.plg4.GetArrayList().Clone();
                        comboBox7.DataSource = (ArrayList)Program.plg4.GetArrayList().Clone();
                        
                        comboBox4.DataSource = (ArrayList)Program.ilbw1.GetArrayList().Clone();
                        comboBox1.DataSource = (ArrayList)Program.itrl3.GetArrayList().Clone();
                        bW2A163ToolStripMenuItem.Checked = false;
                        hGSSTradelistnarcToolStripMenuItem.Checked = true;
                        dPToolStripMenuItem1.Checked = false;
                        bWA165ToolStripMenuItem.Checked = false;
                    }
                }
                else if (this.FileCount == 4) //dppt
                {
                    gamess = "3";
                    comboBox2.DataSource = (ArrayList)Program.plg4.GetArrayList().Clone();
                    comboBox7.DataSource = (ArrayList)Program.plg4.GetArrayList().Clone();

                    comboBox4.DataSource = (ArrayList)Program.ilbw1.GetArrayList().Clone();
                    comboBox1.DataSource = (ArrayList)Program.itrl4.GetArrayList().Clone();
                    bW2A163ToolStripMenuItem.Checked = false;
                    hGSSTradelistnarcToolStripMenuItem.Checked = false;
                    dPToolStripMenuItem1.Checked = true;
                    bWA165ToolStripMenuItem.Checked = false;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("seems is not detected correctly or it was modified, you will read as BW/BW2 in game trade format?", "Your file format is not detected!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        gamess = "1";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show("or, you will read as DPPt in game trade format?", "Your file format is not detected!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            gamess = "3";
                        }
                        else
                        {
                            gamess = "0";
                        }
                    }
                }

                if (gamess == "0")
                {
                    #region disable component
                    comboBox6.DataSource = null;
                    comboBox22.DataSource = null;
                    comboBox11.DataSource = null;
                    comboBox12.DataSource = null;
                    comboBox13.DataSource = null;
                    comboBox14.DataSource = null;
                    comboBox15.DataSource = null;
                    comboBox16.DataSource = null;
                    comboBox2.DataSource = null;
                    comboBox7.DataSource = null;
                    comboBox4.DataSource = null;
                    comboBox1.DataSource = null;
                    groupBox3.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox4.Enabled = false;
                    comboBox1.Enabled = false;
                    button4.Enabled = false;
                    this.pictureBox1.Image = null;
                    this.pictureBox2.Image = null;
                    this.pictureBox3.Image = null;
                    toolStripButton2.Enabled = false;
                    toolStripButton3.Enabled = false;
                    toolStripButton4.Enabled = false;
                    #endregion
                    MessageBox.Show("Ops, You was wrong open supported file ...");
                }
                else if (gamess == "1" || (gamess == "2"))
                {
                    #region enable component
                    comboBox1.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox5.Enabled = true;
                    groupBox4.Enabled = true;
                    comboBox3.Enabled = true;
                    comboBox5.Enabled = true;
                    comboBox22.Enabled = true;
                    comboBox6.Enabled = true;
                    comboBox9.Enabled = true;
                    numericUpDown1.Enabled = true;
                    numericUpDown5.Enabled = false;
                    toolStripButton2.Enabled = true;
                    toolStripButton3.Enabled = true;
                    toolStripButton4.Enabled = true;
                    button4.Enabled = false;
                    this.numericUpDown4.Value = 0;
                    this.numericUpDown5.Value = 0;
                    #endregion
                    MessageBox.Show("Your data successfully to load ^^");

                    this.comboBox1.SelectedValue = 0;
                }
                else if (gamess == "3")
                {
                    comboBox1.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox5.Enabled = true;
                    groupBox4.Enabled = true;
                    comboBox3.Enabled = false;
                    comboBox5.Enabled = false;
                    comboBox22.Enabled = false;
                    comboBox6.Enabled = false;
                    comboBox9.Enabled = false;
                    numericUpDown5.Enabled = true;
                    numericUpDown1.Enabled = false;
                    toolStripButton2.Enabled = true;
                    toolStripButton3.Enabled = true;
                    toolStripButton4.Enabled = true;
                    button4.Enabled = true;

                    this.comboBox1.SelectedValue = 0;
                }
                else if (gamess == "4")
                {
                    numericUpDown5.Enabled = true;
                    comboBox1.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox5.Enabled = true;
                    groupBox4.Enabled = true;
                    comboBox3.Enabled = false;
                    comboBox5.Enabled = false;
                    comboBox22.Enabled = false;
                    comboBox6.Enabled = false;
                    comboBox9.Enabled = false;
                    numericUpDown1.Enabled = false;
                    toolStripButton2.Enabled = true;
                    toolStripButton3.Enabled = true;
                    toolStripButton4.Enabled = true;
                    button4.Enabled = true;

                    this.comboBox1.SelectedValue = 0;
                }
            }
            else
            {
                // buat peringatan jika file tidak dipilih (memilih selain ok)
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamess == "0")
            {
                #region disable component
                comboBox6.DataSource = null;
                comboBox22.DataSource = null;
                comboBox11.DataSource = null;
                comboBox12.DataSource = null;
                comboBox13.DataSource = null;
                comboBox14.DataSource = null;
                comboBox15.DataSource = null;
                comboBox16.DataSource = null;
                comboBox2.DataSource = null;
                comboBox7.DataSource = null;
                comboBox4.DataSource = null;
                comboBox1.DataSource = null;
                groupBox3.Enabled = false;
                groupBox5.Enabled = false;
                groupBox4.Enabled = false;
                comboBox1.Enabled = false;
                this.pictureBox1.Image = null;
                this.pictureBox2.Image = null;
                this.pictureBox3.Image = null;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                #endregion
            }
            else
            {
                if (this.comboBox1.SelectedIndex < 0)
                {
                    this.comboBox1.SelectedIndex = 0;
                }
                else if (this.comboBox1.SelectedIndex >= this.comboBox1.Items.Count)
                {
                    this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
                }

                this.NarcFile.Position = 0x1c + (((int)this.comboBox1.SelectedValue) * 8);
                this.FileOffset = (uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000));
                this.FileSize = ((uint)(((this.NarcFile.ReadByte() + (this.NarcFile.ReadByte() * 0x100)) + (this.NarcFile.ReadByte() * 0x10000)) + (this.NarcFile.ReadByte() * 0x1000000))) - this.FileOffset;
                this.MapFile = new MemoryStream();
                this.MapFile.Position = 0L;
                this.MapFile.Write(this.NarcFile.ToArray(), (int)(this.FileOffset + this.FATOffset), (int)this.FileSize);

                this.MapFile.Position = 0L;

                using (var cryptoProvider = new SHA1CryptoServiceProvider())
                {
                    hash2 = (BitConverter
                            .ToString(cryptoProvider.ComputeHash(MapFile)).Replace("-", String.Empty));
                }

                offsetToolStripMenuItem.Text = "Offset :  0x" + ((this.FATOffset) + (FileOffset)).ToString("X");
                idToolStripMenuItem.Text = "ID : " + comboBox1.SelectedValue;

                if (gamess == "1" || gamess == "2" || gamess == "3" || gamess == "4")
                {
                    if (FileSize % 4 != 0)
                    {
                        #region disable component
                        comboBox6.DataSource = null;
                        comboBox22.DataSource = null;
                        comboBox11.DataSource = null;
                        comboBox12.DataSource = null;
                        comboBox13.DataSource = null;
                        comboBox14.DataSource = null;
                        comboBox15.DataSource = null;
                        comboBox16.DataSource = null;
                        comboBox2.DataSource = null;
                        comboBox7.DataSource = null;
                        comboBox4.DataSource = null;
                        comboBox1.DataSource = null;
                        groupBox3.Enabled = false;
                        groupBox5.Enabled = false;
                        groupBox4.Enabled = false;
                        comboBox1.Enabled = false;
                        this.pictureBox1.Image = null;
                        this.pictureBox2.Image = null;
                        this.pictureBox3.Image = null;
                        toolStripButton2.Enabled = false;
                        toolStripButton3.Enabled = false;
                        toolStripButton4.Enabled = false;
                        #endregion
                        MessageBox.Show("Ops, Is seems not valid format.");
                    }
                    else
                    {
                        if (gamess == "1" || gamess == "2")
                        {
                            this.ReadData();
                        }
                        else if (gamess == "3")
                        {
                            this.ReadDatadppt();
                        }
                        else if (gamess == "4")
                        {
                            this.ReadDatahgss();
                        }
                    }
                }   
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();

            if (gamess == "0")
            {
            }
            else
            {
                switch ((int)this.comboBox2.SelectedValue)
                {
                    case 172: //Pichu
                        comboBox3.Items.Add("Normal");

                        if ((int)this.comboBox2.SelectedValue < 1)
                        {
                            comboBox3.SelectedIndex = (int)this.comboBox2.SelectedValue;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 201: // Unown

                        comboBox3.Items.Add("A");
                        comboBox3.Items.Add("B");
                        comboBox3.Items.Add("C");
                        comboBox3.Items.Add("D");
                        comboBox3.Items.Add("E");
                        comboBox3.Items.Add("F");
                        comboBox3.Items.Add("G");
                        comboBox3.Items.Add("H");
                        comboBox3.Items.Add("I");
                        comboBox3.Items.Add("J");
                        comboBox3.Items.Add("K");
                        comboBox3.Items.Add("L");
                        comboBox3.Items.Add("M");
                        comboBox3.Items.Add("N");
                        comboBox3.Items.Add("O");
                        comboBox3.Items.Add("P");
                        comboBox3.Items.Add("Q");
                        comboBox3.Items.Add("R");
                        comboBox3.Items.Add("S");
                        comboBox3.Items.Add("T");
                        comboBox3.Items.Add("U");
                        comboBox3.Items.Add("V");
                        comboBox3.Items.Add("W");
                        comboBox3.Items.Add("X");
                        comboBox3.Items.Add("Y");
                        comboBox3.Items.Add("Z");
                        comboBox3.Items.Add("!");
                        comboBox3.Items.Add("?");

                        if ((int)this.comboBox2.SelectedValue < 28)
                        {
                            comboBox3.SelectedIndex = (int)this.comboBox2.SelectedValue;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 351:

                        comboBox3.Items.Add("Normal");
                        comboBox3.Items.Add("Sunny Form");
                        comboBox3.Items.Add("Rainy Form");
                        comboBox3.Items.Add("Snowy Form");

                        if ((int)this.comboBox2.SelectedValue < 4)
                        {
                            comboBox3.SelectedIndex = (int)this.comboBox2.SelectedValue;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;
                    case 386: // Deoxys

                        comboBox3.Items.Add("Normal");
                        comboBox3.Items.Add("Attack");
                        comboBox3.Items.Add("Defense");
                        comboBox3.Items.Add("Speed");

                        if ((int)this.comboBox2.SelectedValue < 4)
                        {
                            comboBox3.SelectedIndex = (int)this.comboBox2.SelectedValue;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;


                    case 412: // Burmy
                    case 413: // Wormadam

                        comboBox3.Items.Add("Plant");
                        comboBox3.Items.Add("Sand");
                        comboBox3.Items.Add("Trash");

                        if ((int)this.comboBox2.SelectedValue < 3)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 421:

                        comboBox3.Items.Add("Overcast Form");
                        comboBox3.Items.Add("Sunshine Form");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;
                    case 422: // Shellos
                    case 423: // Gastrodon

                        comboBox3.Items.Add("West");
                        comboBox3.Items.Add("East");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = (int)this.comboBox2.SelectedValue;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 479: // Rotom

                        comboBox3.Items.Add("Normal");
                        comboBox3.Items.Add("Heat");
                        comboBox3.Items.Add("Wash");
                        comboBox3.Items.Add("Frost");
                        comboBox3.Items.Add("Spin");
                        comboBox3.Items.Add("Cut");

                        if ((int)this.comboBox2.SelectedValue < 6)
                        {
                            comboBox3.SelectedIndex = (int)this.comboBox2.SelectedValue;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }
                        break;

                    case 487: // Giratina

                        comboBox3.Items.Add("Altered");
                        comboBox3.Items.Add("Origin");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 492: // Shaymin

                        comboBox3.Items.Add("Land");
                        comboBox3.Items.Add("Sky");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 493: // Arceus

                        comboBox3.Items.Add("Normal");
                        comboBox3.Items.Add("Fighting");
                        comboBox3.Items.Add("Flying");
                        comboBox3.Items.Add("Poison");
                        comboBox3.Items.Add("Ground");
                        comboBox3.Items.Add("Rock");
                        comboBox3.Items.Add("Bug");
                        comboBox3.Items.Add("Ghost");
                        comboBox3.Items.Add("Steel");
                        comboBox3.Items.Add("Fire");
                        comboBox3.Items.Add("Water");
                        comboBox3.Items.Add("Grass");
                        comboBox3.Items.Add("Electric");
                        comboBox3.Items.Add("Psychic");
                        comboBox3.Items.Add("Ice");
                        comboBox3.Items.Add("Dragon");
                        comboBox3.Items.Add("Dark");

                        if ((int)this.comboBox2.SelectedValue < 18)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 550:
                        comboBox3.Items.Add("Red-Striped");
                        comboBox3.Items.Add("Blue-Striped");
                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 555:
                        comboBox3.Items.Add("Normal");
                        comboBox3.Items.Add("Zen mode");
                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 585:
                    case 586:

                        comboBox3.Items.Add("Spring Form");
                        comboBox3.Items.Add("Summer Form");
                        comboBox3.Items.Add("Autumn Form");
                        comboBox3.Items.Add("Winter Form");

                        if ((int)this.comboBox2.SelectedValue < 4)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 641:
                    case 642:
                    case 645:

                        comboBox3.Items.Add("Incarnate Forme");
                        comboBox3.Items.Add("Therian Forme");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 646:

                        comboBox3.Items.Add("Kyurem");
                        comboBox3.Items.Add("White Kyurem");
                        comboBox3.Items.Add("Black Kyurem");

                        if ((int)this.comboBox2.SelectedValue < 3)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 647:

                        comboBox3.Items.Add("Ordinary Form");
                        comboBox3.Items.Add("Resolute Form");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 648:

                        comboBox3.Items.Add("Aria Forme");
                        comboBox3.Items.Add("Pirouette Forme");

                        if ((int)this.comboBox2.SelectedValue < 2)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    case 649:

                        comboBox3.Items.Add("Normal");
                        comboBox3.Items.Add("1");
                        comboBox3.Items.Add("2");
                        comboBox3.Items.Add("3");
                        comboBox3.Items.Add("4");

                        if ((int)this.comboBox2.SelectedValue < 5)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }

                        break;

                    default:
                        comboBox3.Items.Add("None");

                        if ((int)this.comboBox2.SelectedValue < 1)
                        {
                            comboBox3.SelectedIndex = ((int)this.comboBox2.SelectedValue);
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 0;
                        }
                        break;

                }  
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamess == "0")
            {
            }
            else
            {

                if (this.comboBox3.SelectedIndex > 0)
                {
                    switch ((int)this.comboBox2.SelectedValue)
                    {
                        case 133:
                        case 134:
                        case 135:
                        case 136:
                        case 196:
                        case 197:
                        case 334:
                        case 468:
                        case 470:
                        case 471:
                        case 478:
                        case 542:
                        case 547:
                        case 572:
                        case 587:
                        case 647:
                        case 648:
                            this.pictureBox1.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("psr_" + (int)this.comboBox2.SelectedValue + "_" + (int)this.comboBox3.SelectedIndex + "_a");
                            break;
                        default:
                            this.pictureBox1.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("psr_" + (int)this.comboBox2.SelectedValue + "_" + (int)this.comboBox3.SelectedIndex);
                            break;
                    }
                }
                else
                {
                    switch ((int)this.comboBox2.SelectedValue)
                    {
                        case 133:
                        case 134:
                        case 135:
                        case 136:
                        case 196:
                        case 197:
                        case 334:
                        case 468:
                        case 470:
                        case 471:
                        case 478:
                        case 542:
                        case 547:
                        case 572:
                        case 587:
                        case 647:
                            this.pictureBox1.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("psr_" + (int)this.comboBox2.SelectedValue + "_a");
                            break;
                        default:
                            this.pictureBox1.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("psr_" + (int)this.comboBox2.SelectedValue);
                            break;
                    }
                }
            }

            this.toolTip1.SetToolTip(this.pictureBox1, comboBox2.SelectedValue + " - " + comboBox2.Text + " (" + comboBox3.Text + ")");

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamess == "0")
            {
            }
            else
            {
                switch ((int)this.comboBox7.SelectedValue)
                {
                    case 133:
                    case 134:
                    case 135:
                    case 136:
                    case 196:
                    case 197:
                    case 334:
                    case 468:
                    case 470:
                    case 471:
                    case 478:
                    case 542:
                    case 547:
                    case 572:
                    case 587:
                    case 647:
                        this.pictureBox3.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("psr_" + (int)this.comboBox7.SelectedValue + "_a");
                        break;
                    default:
                        this.pictureBox3.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("psr_" + (int)this.comboBox7.SelectedValue);
                        break;

                }
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamess == "0")
            {
            }
            else
            {
                this.pictureBox2.Image = (Image)global::AIGT.Properties.Resources.ResourceManager.GetObject("isp_" + (int)this.comboBox4.SelectedValue);
            }

            this.toolTip1.SetToolTip(this.pictureBox2, comboBox4.SelectedValue + " - " + comboBox4.Text);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ReadSourceData();

            AIGT.pop_up.source form = new AIGT.pop_up.source(this);

            if (viewModeToolStripMenuItem.Checked)
            {
                form.textBox1.Text = "" + hexview2;
            }
            else
            {
                form.textBox1.Text = "" + hexview;
            }

            form.StartPosition = FormStartPosition.CenterParent;
            form.Opacity = 0.95;
            form.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AIGT.pop_up.about form = new AIGT.pop_up.about(this);

            form.StartPosition = FormStartPosition.CenterParent;
            form.Opacity = 0.8;
            form.ShowDialog();
        }

        private void viewModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModeToolStripMenuItem.Checked)
            {
                viewModeToolStripMenuItem.Checked = false;
            }
            else
            {
                viewModeToolStripMenuItem.Checked = true;
            }
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Diamond ,Pearl , and Platinum : \r\n     /fielddata/pokemon_trade/fld_trade.narc\r\nHeartGold and SoulSilver : \r\n      a/1/1/2");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r_iv = new Random();

            this.comboBox11.SelectedValue = r_iv.Next(0, 31);
            this.comboBox12.SelectedValue = r_iv.Next(0, 31);
            this.comboBox13.SelectedValue = r_iv.Next(0, 31);
            this.comboBox14.SelectedValue = r_iv.Next(0, 31);
            this.comboBox15.SelectedValue = r_iv.Next(0, 31);
            this.comboBox16.SelectedValue = r_iv.Next(0, 31);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r_iv = new Random();

            this.comboBox17.SelectedIndex = r_iv.Next(0, 255);
            this.comboBox18.SelectedIndex = r_iv.Next(0, 255);
            this.comboBox19.SelectedIndex = r_iv.Next(0, 255);
            this.comboBox20.SelectedIndex = r_iv.Next(0, 255);
            this.comboBox21.SelectedIndex = r_iv.Next(0, 255);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random r_iv = new Random();
            this.numericUpDown2.Value = r_iv.Next(0, 65000);
            this.numericUpDown3.Value = r_iv.Next(0, 65000);
            this.comboBox8.SelectedIndex = r_iv.Next(0, 1);
            this.comboBox10.SelectedIndex = r_iv.Next(1, 7);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AIGT.pop_up.pidview form = new AIGT.pop_up.pidview(this);
            form.textBox1.Text = this.numericUpDown5.Value.ToString();

            form.StartPosition = FormStartPosition.CenterParent;
            form.Opacity = 0.95;
            form.ShowDialog();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (gamess == "4" || gamess == "3")
            {
                int nature = int.Parse(((this.numericUpDown5.Value).ToString()).Substring(((this.numericUpDown5.Value).ToString()).Length - 2));

                if (nature > 24)
                {
                    nature = nature % 25;
                }

                this.comboBox6.SelectedValue = nature;

                string binary = (Convert.ToString((int)this.numericUpDown5.Value, 2)).Substring((Convert.ToString((int)this.numericUpDown5.Value, 2)).Length - 1);

                int ability;

                if (binary == "1")
                {
                    ability = 1;
                }
                else
                {
                    ability = 0;
                }

                this.comboBox5.SelectedIndex = ability;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Narc File";
            dialog.Filter = "Nitro Archive (*.narc)|*.narc|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, this.NarcFile.ToArray());
            }
        }


    }
}
