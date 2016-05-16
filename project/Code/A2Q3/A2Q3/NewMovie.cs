using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace A2Q3
{
    public partial class NewMovie : Form
    {
        public NewMovie()
        {
            InitializeComponent();
            label9.Text = "Notes: ";
            label10.Text = "1.The option with (*) means you can input\n  muti-values.";
            label11.Text = "2.For muti-values, please separated by \n  commas.";
            label12.Text = "3.Records with same title will be ignored.";
        }

        //methods for verificate the input====================================================
        private bool checkInteger(string check)
        {
            bool result = true;
            if (check != null && check != "")
            {
                foreach (char letter in check)
                {
                    if (letter < 48 || letter > 57)
                        result = false;
                }
            }
            return result;
        }

        private bool checkRating(string check)
        {
            bool result = true;
            if (check != null && check != "")
            {
                if (int.Parse(check) > 10 || int.Parse(check) < 0)
                    result = false;
            }
            return result;
        }
        //end of those methods=================================================================

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInteger(textBox2.Text))
                MessageBox.Show("Error in \"Release Year\"：Please enter integer only.");
            else if (!checkInteger(textBox5.Text))
                MessageBox.Show("Error in \"Length\"：Please enter integer only.");
            else if (!checkInteger(textBox3.Text) || !checkRating(textBox3.Text))
                MessageBox.Show("Error in \"Rating\"：Please enter integer in range 0 - 10 only.");
            else    //pass the verification
            {
                string[] separate;

                XmlDocument doc = new XmlDocument();
                doc.Load("movieRecord.xml");

                XmlNode movie = doc.CreateElement("movie");

                XmlNode title = doc.CreateElement("title");
                title.InnerText = textBox1.Text;
                movie.AppendChild(title);

                XmlNode year = doc.CreateElement("year");
                year.InnerText = textBox2.Text;
                movie.AppendChild(year);

                XmlNode length = doc.CreateElement("length");
                length.InnerText = textBox5.Text + " min";
                movie.AppendChild(length);

                if (textBox6.Text != null || textBox6.Text != "")
                {
                    XmlNode certification = doc.CreateElement("certification");
                    certification.InnerText = textBox6.Text;
                    movie.AppendChild(certification);
                }

                XmlNode director = doc.CreateElement("director");
                director.InnerText = textBox7.Text;
                movie.AppendChild(director);

                XmlNode rating = doc.CreateElement("rating");
                rating.InnerText = textBox3.Text;
                movie.AppendChild(rating);


                separate = textBox4.Text.Split(',');
                foreach (string word in separate)
                {
                    XmlNode genre = doc.CreateElement("genre");
                    genre.InnerText = word;
                    movie.AppendChild(genre);
                }

                separate = textBox8.Text.Split(',');
                foreach (string word in separate)
                {
                    XmlNode actor = doc.CreateElement("actor");
                    actor.InnerText = word;
                    movie.AppendChild(actor);
                }

                doc.DocumentElement.AppendChild(movie);
                doc.Save("movieRecord.xml");

                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
