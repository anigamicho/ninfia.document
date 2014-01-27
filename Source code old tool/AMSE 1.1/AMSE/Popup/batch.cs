using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMSE.Popup
{
    public partial class batch : Form
    {
        private Form1 form1;

        public batch(Form1 ownerForm)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Icon = global::AMSE.Properties.Resources.amse_icon;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
