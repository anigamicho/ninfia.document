using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APSV.pop_up
{
    public partial class Locationlist : Form
    {
        public DataGridViewTextBoxColumn Column1;
        public DataGridViewTextBoxColumn Column2;
        public DataGridViewTextBoxColumn Column3;

        public Locationlist(Form1 ownerForm)
        {
            InitializeComponent();
            tableset();
            this.dataGridView1[0, 0].Value = "a/2/1/2";
            this.dataGridView1[1, 0].Value = "a/2/1/1";
            this.dataGridView1[2, 0].Value = "battle subway - BW2";

            this.dataGridView1[0, 1].Value = "a/2/1/5";
            this.dataGridView1[1, 1].Value = "a/2/1/4";
            this.dataGridView1[2, 1].Value = "battle subway - BW";

            this.dataGridView1[0, 2].Value = "-";
            this.dataGridView1[1, 2].Value = "a/2/5/7";
            this.dataGridView1[2, 2].Value = "PWT - Rental Pokemon";

            this.dataGridView1[0, 3].Value = "a/2/6/2";
            this.dataGridView1[1, 3].Value = "a/2/6/1";
            this.dataGridView1[2, 3].Value = "PWT - Rental Trainer";

            this.dataGridView1[0, 4].Value = "a/2/4/9";
            this.dataGridView1[1, 4].Value = "a/2/5/0";
            this.dataGridView1[2, 4].Value = "PWT - Driftveil Tournament";

            this.dataGridView1[0, 5].Value = "a/2/4/8";
            this.dataGridView1[1, 5].Value = "a/2/5/0";
            this.dataGridView1[2, 5].Value = "PWT - Mix Single Tournament";

            this.dataGridView1[0, 6].Value = "a/2/5/2";
            this.dataGridView1[1, 6].Value = "a/2/5/3";
            this.dataGridView1[2, 6].Value = "PWT - Leader+champion Tournament";

            this.dataGridView1[0, 7].Value = "a/2/5/5";
            this.dataGridView1[1, 7].Value = "a/2/5/6";
            this.dataGridView1[2, 7].Value = "PWT - Mix Master Tournament";

            this.dataGridView1[0, 8].Value = "a/2/5/4";
            this.dataGridView1[1, 8].Value = "a/2/5/6";
            this.dataGridView1[2, 8].Value = "PWT - Single";

            this.dataGridView1[0, 9].Value = "a/2/5/1";
            this.dataGridView1[1, 9].Value = "a/2/5/3";
            this.dataGridView1[2, 9].Value = "PWT - Single - Bonus Teams";

            this.dataGridView1[0, 10].Value = "-";
            this.dataGridView1[1, 10].Value = "b_pl_stage/pl_bsdpm";
            this.dataGridView1[2, 10].Value = "Battle Frointer - Rental (Pt)";

            this.dataGridView1[0, 11].Value = "b_pl_tower/pl_btdtr";
            this.dataGridView1[1, 11].Value = "b_pl_tower/pl_btdpm";
            this.dataGridView1[2, 11].Value = "Battle Frointer - Tower (Pt)";

            this.dataGridView1[0, 12].Value = "b_tower/pl_btdtr";
            this.dataGridView1[1, 12].Value = "b_tower/pl_btdpm";
            this.dataGridView1[2, 12].Value = "Battle Frointer - Tower (Pt/DP)";
        }


        public void tableset()
        {
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();

            this.Column1.Name = "Trainer data";
            this.Column2.Name = "Pokemon data";
            this.Column3.Name = "Comment";

            this.Column1.Width = 70;
            this.Column2.Width = 70;
            this.Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column2.Resizable = DataGridViewTriState.False;
            this.Column3.Resizable = DataGridViewTriState.False;

            this.Column1.ReadOnly = true;
            this.Column2.ReadOnly = true;
            this.Column3.ReadOnly = true;

            this.Column1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Column2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Column3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 });

            this.dataGridView1.Rows.Add(20);
            this.dataGridView1.RowHeadersVisible = false;
        }
    }
}
