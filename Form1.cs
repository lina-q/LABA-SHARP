using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1_1
{
    public partial class Form1 : Form
    {
        int n;
        double[] X;
        double[] Y;
        double[,] mas;
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')) && !((e.KeyChar == ',')))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            {
                dataGridView1.Columns.Clear();
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                n = (int)numericUpDown1.Value;
                dataGridView1.AutoResizeColumns();
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns.Add("New", "Y" + i.ToString());
                }
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = n;
                X = new double[n];
                Y = new double[n];
                mas = new double[n, n];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewMethod();
        }
        private void NewMethod()
        {
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    mas[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
            for (int i = 0; i < n; i++)
            {
                dataGridView2.Columns.Add("New", "Y" + i.ToString());
            }
            dataGridView2.ColumnCount = n;
            dataGridView2.RowCount = n;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (mas[i, j] % 4 == 0)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = mas[i, j] * 1;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[j].Value = 0;
                    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowCounter = dataGridView2.RowCount;
            int columnCount = dataGridView2.ColumnCount;
            string[] line = new string[columnCount];
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            line[j] = Convert.ToString(dataGridView2.Rows[i].Cells[j].Value ?? "");
                        }
                        writer.WriteLine(string.Join("\t", line));
                    }
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
