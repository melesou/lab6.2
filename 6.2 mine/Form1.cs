using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace _6._2_mine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rand.Next(0, 30);
                }
            }
            int[] n = new int[5];
            for (int i = 0; i < 5; i++)
            {
                n[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int t;
                    if (n[i] < n[j])
                    {
                        t = n[i];
                        n[i] = n[j];
                        n[j] = t;
                    }
                }
            }
            chart1.Series[0].Points.DataBindY(n);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                fName = saveFileDialog1.FileName + ".txt";

            int max = 0;
            string word;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                   word = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                    if (word.Length > max)
                    {
                        max = word.Length;
                    }
                }

            FileStream fs = new FileStream(fName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sw.Write(dataGridView1.Rows[i].Cells[j].Value);
                    word = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                    for (int k = word.Length; k <= max; k++)
                        sw.Write(" ");
                }
                sw.WriteLine();
            }

            sw.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
