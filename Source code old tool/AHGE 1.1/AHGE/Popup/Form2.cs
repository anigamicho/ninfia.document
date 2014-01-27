using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using aleafia_resicon;


namespace AHGE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Icon = global::aleafia_resicon.Properties.Resources.icons;
            //linkLabel1.Text = "http://serebii.net/black2white2/hiddengrotto.shtml";
            //linkLabel1.Links.Add(0, 0, "http://serebii.net/black2white2/hiddengrotto.shtml");

            label8.Text = "Version = " + ProductVersion;           
        }


        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            //System.Diagnostics.Process.Start("http://serebii.net/black2white2/hiddengrotto.shtml");

            ProcessStartInfo sInfo = new ProcessStartInfo("http://serebii.net/black2white2/hiddengrotto.shtml");
            Process.Start(sInfo);
        }
    }
}
