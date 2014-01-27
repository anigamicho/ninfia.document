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
    public partial class offsetview : Form
    {
        public DataGridViewTextBoxColumn Column1;
        public DataGridViewTextBoxColumn Column2;
        public DataGridViewTextBoxColumn Column3;

        public uint offsetcount;
        public uint offsetcount1;
        public uint countl;

        public offsetview(Form1 ownerForm)
        {
            countl = ownerForm.FileCount;

            if (countl != 0)
            {
                InitializeComponent();
                tableset();

                ownerForm.NarcFile.Position = 0x1C;

                for (int i = 0; i < (int)countl; i++)
                {
                    this.offsetcount = (uint)(ownerForm.NarcFile.ReadByte() + (ownerForm.NarcFile.ReadByte() * 0x100) + (ownerForm.NarcFile.ReadByte() * 0x10000) + (ownerForm.NarcFile.ReadByte() * 0x1000000));
                    this.offsetcount1 = (uint)(ownerForm.NarcFile.ReadByte() + (ownerForm.NarcFile.ReadByte() * 0x100) + (ownerForm.NarcFile.ReadByte() * 0x10000) + (ownerForm.NarcFile.ReadByte() * 0x1000000));

                    this.dataGridView1[0, i].Value = i;
                    this.dataGridView1[1, i].Value = "0x" + ((int)offsetcount).ToString("X");
                    this.dataGridView1[2, i].Value = "0x" + ((int)offsetcount1).ToString("X");
                }
            }
        }

        public void tableset()
        {
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();

            this.Column1.Name = "Data #";
            this.Column2.Name = "Start Offset";
            this.Column3.Name = "End Offset";

            this.Column1.Width = 50;
            this.Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column2.Resizable = DataGridViewTriState.False;
            this.Column3.Resizable = DataGridViewTriState.False;

            this.Column1.ReadOnly = true;
            this.Column2.ReadOnly = true;
            this.Column3.ReadOnly = true;

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

            this.dataGridView1.Rows.Add((int)this.countl);
            this.dataGridView1.RowHeadersVisible = false;
        }
    }
}
