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
    public partial class EditMovie : Form
    {

        String title; //1
        string year;//2
        string length;//3
        string certification;//8
        string director;//4
        string rating;//5
        string[] genre;//6
        string[] actor;//7

        public EditMovie(string[] pass)
        {
            InitializeComponent();
            textBox1.Text = pass[0];
            textBox2.Text = pass[1];
            textBox5.Text = pass[2].Split(' ')[0];
            textBox7.Text = pass[4];
            textBox3.Text = pass[3];
            textBox4.Text = pass[5];
            textBox8.Text = pass[6];
            textBox6.Text = pass[7];

            label9.Text = "Notes: ";
            label10.Text = "1.The option with (*) means you can input\n  muti-values.";
            label11.Text = "2.For muti-values, please separated by \n  commas.";
            label12.Text = "3.Records with same title will be ignored.";

            backup();
        }

        private void backup()
        {
            title = textBox1.Text; //1
            year = textBox2.Text;//2
            length = textBox5.Text;//5
            certification = textBox6.Text;//6
            director = textBox7.Text;//7
            rating = textBox3.Text;//3
            genre = textBox4.Text.Split(',');//4
            actor = textBox8.Text.Split(',');//8
            //MessageBox.Show("backup：\n"+title+ "\n" + year + "\n" + length + "\n" + certification + "\n" + director + "\n" + rating + "\n" + gener + "\n" + actor);
        }

        private void EditPPL_Load(object sender, EventArgs e)
        {

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
            else   //pass the verification
            {
                XmlDocument doc = new XmlDocument();

                doc.Load("movieRecord.xml");

                foreach (XmlNode node in doc.SelectNodes("movielist/movie"))
                {
                    string[] separate;

                    String titleCurr = node.SelectSingleNode("title").InnerText; //1
                    string yearCurr = node.SelectSingleNode("year").InnerText;//2
                    string lengthCurr = node.SelectSingleNode("length").InnerText.Split(' ')[0];//5
                    string directorCurr = node.SelectSingleNode("director").InnerText;//7
                    string ratingCurr = node.SelectSingleNode("rating").InnerText;//3
                    XmlNodeList genreCurr = node.SelectNodes("genre");//4
                    XmlNodeList actorCurr = node.SelectNodes("actor");//8

                    string certificationCurr = null;
                    if (node.SelectSingleNode("certification") != null)
                        certificationCurr = node.SelectSingleNode("certification").InnerText;//6

                    //MessageBox.Show("backup：\n" + title + "\n" + year + "\n" + length + "\n" + certification + "\n" + director + "\n" + rating + "\n" + genre.Length + "\n" + actor.Length + "|||||||||\n" + titleCurr + "\n" + yearCurr + "\n" + lengthCurr + "\n" + certificationCurr + "\n" + directorCurr + "\n" + ratingCurr + "\n" + genreCurr.Count + "\n" + actorCurr.Count);

                    if (titleCurr == title && //verificate every single parts in each node
                        yearCurr == year &&
                        lengthCurr == length &&
                        certificationCurr == certification &&
                        directorCurr == director &&
                        ratingCurr == rating &&
                        genreCurr.Count == genre.Length &&
                        actorCurr.Count == actor.Length)
                    {
                        bool same = true;
                        for (int i = 0; i < genreCurr.Count; i++)
                        {
                            if (genreCurr[i].InnerText != genre[i])
                            {
                                MessageBox.Show("f1");
                                same = false;
                            }
                        }
                        for (int i = 0; i < actorCurr.Count; i++)
                        {
                            if (actorCurr[i].InnerText != actor[i])
                            {
                                MessageBox.Show("f2");
                                same = false;
                            }
                        }
                        if (same == true)
                        { //modify the data
                            node.SelectSingleNode("title").InnerText = textBox1.Text;
                            node.SelectSingleNode("year").InnerText = textBox2.Text;
                            node.SelectSingleNode("length").InnerText = textBox5.Text + " min";
                            node.SelectSingleNode("director").InnerText = textBox7.Text;
                            node.SelectSingleNode("rating").InnerText = textBox3.Text;

                            if (textBox6.Text != certification) //not every movie has certification, consider the case we need to new one or delete it
                            {
                                if (node.SelectSingleNode("certification") != null)
                                    node.SelectSingleNode("certification").InnerText = textBox6.Text;
                                else if(certificationCurr == null)
                                    node.RemoveChild(node.SelectSingleNode("certification"));
                                else   
                                {
                                    XmlNode certification = doc.CreateElement("certification");
                                    certification.InnerText = textBox6.Text;
                                    node.AppendChild(certification);
                                }
                            }

                            foreach (XmlNode rmv in genreCurr) //delete te muti-value first
                                node.RemoveChild(rmv);
                            foreach (XmlNode rmv in actorCurr)
                                node.RemoveChild(rmv);

                            separate = textBox4.Text.Split(','); //insert the new values back to avoid the difference of numbers between the old & new data
                            foreach (string word in separate)
                            {
                                XmlNode genre = doc.CreateElement("genre");
                                genre.InnerText = word;
                                node.AppendChild(genre);
                            }

                            separate = textBox8.Text.Split(',');
                            foreach (string word in separate)
                            {
                                XmlNode actor = doc.CreateElement("actor");
                                actor.InnerText = word;
                                node.AppendChild(actor);
                            }
                        }
                    }
                }

                doc.Save("movieRecord.xml");

                this.Close();
                //12573486
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
