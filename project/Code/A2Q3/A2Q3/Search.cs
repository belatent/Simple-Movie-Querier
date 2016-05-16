using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2Q3
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please enter a keyword for search.\nFor range search, please use Advance Search.","No keyword",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please choose a category before start a search.\nFor range search, please use Advance Search.", "No category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text != "" && comboBox1.Text != "") {
                string type;
                if (comboBox1.Text == "Release Year")
                    type = "year";
                else
                    type = comboBox1.Text;
                Result rp = new Result(1, textBox1.Text, type.ToLower());
                rp.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdvSearch ap = new AdvSearch();
            ap.ShowDialog();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataManager dm = new DataManager();
            dm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WatchList wl = new WatchList();
            wl.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label7.Text = "Current time: " + dt.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("readme.txt");
        }
    }
}
