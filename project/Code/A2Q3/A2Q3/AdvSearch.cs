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
    public partial class AdvSearch : Form
    {
        public AdvSearch()
        {
            InitializeComponent();
            label9.Text = "Notes: ";
            label10.Text = "1.The option with (*) means you can input muti-values.";
            label11.Text = "2.For muti-values, please separated by commas.";
            label12.Text = "3.Records with same title will be ignored.";
            label17.Text = "4.For range search, you can just fill arbitrary one of textboxs\n  for accurate search.";
        }

        private string combineKeyWord()
        {
            //236 91011
            string yearRange = "";
            string lengthRange = "";
            string ratingRange = "";

            if (textBox2.Text != "")
                yearRange += textBox2.Text + ",";
            else
                yearRange += ",";
            if (textBox9.Text != "")
            {
                yearRange += textBox9.Text;
            }

            if (textBox3.Text != "")
                lengthRange += textBox3.Text + ",";
            else
                lengthRange += ",";
            if (textBox10.Text != "")
            {
                lengthRange += textBox10.Text;
            }

            if (textBox6.Text != "")
                ratingRange += textBox6.Text + ",";
            else
                ratingRange += ",";
            if (textBox11.Text != "")
            {
                ratingRange += textBox11.Text;
            }

            string keyword = textBox1.Text + "|" + yearRange + "|" + lengthRange + "|"
                + textBox4.Text + "|" + textBox5.Text + "|" + ratingRange + "|" + textBox7.Text
                + "|" + textBox8.Text;

            //MessageBox.Show(keyword);

            return keyword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result rp = new Result(2,combineKeyWord(),null);
            rp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
