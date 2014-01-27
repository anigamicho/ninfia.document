using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMSE
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
            this.Icon = global::AMSE.Properties.Resources.amse_icon;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
