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
    public partial class ChooseAttr : Form
    {
        string x;
        string y;
        string z;
        public ChooseAttr(string year, string rating, string length)
        {
            InitializeComponent();
            this.x = year;
            this.y = length;
            z = rating;
        }

        public ChooseAttr()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = !checkBox2.Enabled;
            checkBox3.Enabled = !checkBox3.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = !checkBox2.Enabled;
            checkBox3.Enabled = !checkBox3.Enabled;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = !checkBox2.Enabled;
            checkBox2.Enabled = !checkBox3.Enabled;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Enabled = !checkBox5.Enabled;
            checkBox4.Enabled = !checkBox4.Enabled;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Enabled = !checkBox4.Enabled;
            checkBox6.Enabled = !checkBox6.Enabled;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Enabled = !checkBox5.Enabled;
            checkBox6.Enabled = !checkBox6.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string attrX = null;
            string attrY = null;

            if (checkBox1.Enabled && checkBox2.Enabled && checkBox3.Enabled)
                MessageBox.Show("Please choose an attribute for X-axis.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (checkBox4.Enabled && checkBox5.Enabled && checkBox6.Enabled)
                MessageBox.Show("Please choose an attribute for Y-axis.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (checkBox1.Enabled)
                {
                    attrX = "year";
                    if (checkBox6.Enabled)
                    {
                        MessageBox.Show("Please choose different attribute for X & Y axis.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                    else if (checkBox5.Enabled)
                    {
                        attrY = "length";
                        Graph g = new Graph(attrX, attrY, x, y);
                        g.Show();
                        this.Close();
                    }
                    else if (checkBox4.Enabled)
                    {
                        attrY = "rating";
                        Graph g = new Graph(attrX, attrY, x, z);
                        g.Show();
                        this.Close();
                    }
                }

                if (checkBox2.Enabled)
                {
                    attrX = "length";
                    if (checkBox6.Enabled)
                    {
                        attrY = "year";
                        Graph g = new Graph(attrX, attrY, y, x);
                        g.Show();
                        this.Close();
                    }
                    else if (checkBox5.Enabled)
                    {
                        MessageBox.Show("Please choose different attribute for X & Y axis.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkBox4.Enabled)
                    {
                        attrY = "rating";
                        Graph g = new Graph(attrX, attrY, y, z);
                        g.Show();
                        this.Close();
                    }
                }

                if (checkBox3.Enabled)
                {
                    attrX = "rating";
                    if (checkBox6.Enabled)
                    {
                        attrY = "year";
                        Graph g = new Graph(attrX, attrY, z, x);
                        g.Show();
                        this.Close();
                    }
                    else if (checkBox5.Enabled)
                    {
                        attrY = "length";
                        Graph g = new Graph(attrX, attrY, z, y);
                        g.Show();
                        this.Close();
                    }
                    else if (checkBox4.Enabled)
                    {
                        MessageBox.Show("Please choose different attribute for X & Y axis.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
