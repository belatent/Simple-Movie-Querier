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
    public partial class DetailPage : Form
    {
        string rate;
        string[] genres;
        string[] actors;
        public DetailPage(String info)
        {
            InitializeComponent();
            string[] infoSplit = info.Split('|');
            genres = infoSplit[5].Split(',');
            actors = infoSplit[6].Split(',');

            title.Text = infoSplit[0];
            year.Text += infoSplit[1];
            length.Text += infoSplit[2];

            for (int i = 0; i < int.Parse(infoSplit[3]); i++)
                rating.Text += "★ ";
            rating.Text += "(" + infoSplit[3] + ")";
            rate = infoSplit[3];

            director.Text += infoSplit[4];

            for (int i = 0; i < genres.Length; i++)
                genre.Text += "\n  " + genres[i];

            for (int i = 0; i < actors.Length; i++)
                cast.Text += "\n  " + actors[i];

            if (infoSplit[7] != "")
                cert.Text += infoSplit[7];
            else
                cert.Text += "No Certification.";

            readComment();

            if (isdup(title.Text))
            {
                addwl.BackColor = Color.Gray;
                addwl.Text = "In Watch List";
            }

        }

        private bool dupCheck(string movieNames, string currName)
        {
            bool dup = false;
            if (movieNames != null)
            {
                string[] movies = movieNames.Split(',');

                foreach (string movie in movies)
                {
                    if (movie == currName)
                        dup = true;
                }
            }
            return dup;
        }

        public void readComment()
        {
            string movieNames = null;
            XmlDocument xDoc = new XmlDocument(); //open xml file

            xDoc.Load("movieRecord.xml");

            foreach (XmlNode node in xDoc.SelectNodes("movielist/movie"))
            {
                string title = node.SelectSingleNode("title").InnerText;
                if (!dupCheck(movieNames, title))
                {
                    if (node.SelectSingleNode("title").InnerText == this.title.Text)
                    {
                        XmlNodeList comments = node.SelectNodes("comment");
                        foreach (XmlNode comment in comments)
                        {
                            //MessageBox.Show(node.SelectSingleNode("title").InnerText + "\n" + this.title.Text);
                            if (commentShow.Text == "" || commentShow.Text == null)
                                commentShow.Text = comment.InnerText + "\r\n=====================================================================";
                            else
                                commentShow.Text += "\r\n" + comment.InnerText + "\r\n=====================================================================";
                        }
                        if (movieNames == null)
                            movieNames += title;
                        else
                            movieNames += ("," + title);
                    }
                }
            }
        }

        public void addToComment()
        {
            XmlDocument xDoc = new XmlDocument(); //open xml file

            xDoc.Load("movieRecord.xml");

            foreach (XmlNode node in xDoc.SelectNodes("movielist/movie"))
            {
                string title = node.SelectSingleNode("title").InnerText;

                if (node.SelectSingleNode("title").InnerText == this.title.Text)
                {
                    //MessageBox.Show(node.SelectSingleNode("title").InnerText + "\n11111\n" + this.title.Text);
                    XmlNode comment = xDoc.CreateElement("comment");
                    comment.InnerText = "("+ DateTime.Now.ToLocalTime() + "):\r\n" + commentAdd.Text;
                    node.AppendChild(comment);
                }
            }
            xDoc.Save("movieRecord.xml");
        }

        private void submit_Click(object sender, EventArgs e)
        {
            addToComment();
            commentShow.Text = "";
            readComment();
        }

        private Boolean isdup(string name)
        {
            Boolean isdup = false;

            XmlDocument doc = new XmlDocument();
            doc.Load("watchlist.xml");

            foreach(XmlNode node in doc.SelectNodes("movielist/movie"))
            {
                if (node.SelectSingleNode("title").InnerText == name)
                    isdup = true;
            }

            return isdup;
        }

        private void addwl_Click(object sender, EventArgs e)
        {
            if (!isdup(this.title.Text))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("watchlist.xml");

                XmlNode movie = doc.CreateElement("movie");

                XmlNode title = doc.CreateElement("title");
                title.InnerText = this.title.Text;
                movie.AppendChild(title);

                XmlNode year = doc.CreateElement("year");
                year.InnerText = this.year.Text.Split(':')[1].Trim();
                movie.AppendChild(year);

                XmlNode length = doc.CreateElement("length");
                length.InnerText = this.length.Text.Split(':')[1].Trim() + " min";
                movie.AppendChild(length);

                if (cert.Text.Split(':')[1].Trim() != "No Certification.")
                {
                    XmlNode certification = doc.CreateElement("certification");
                    certification.InnerText = cert.Text.Split(':')[1].Trim();
                    movie.AppendChild(certification);
                }

                XmlNode director = doc.CreateElement("director");
                director.InnerText = this.director.Text.Split(':')[1].Trim();
                movie.AppendChild(director);

                XmlNode rating = doc.CreateElement("rating");
                rating.InnerText = rate;
                movie.AppendChild(rating);

                foreach (string word in genres)
                {
                    XmlNode genre = doc.CreateElement("genre");
                    genre.InnerText = word;
                    movie.AppendChild(genre);
                }

                foreach (string word in actors)
                {
                    XmlNode actor = doc.CreateElement("actor");
                    actor.InnerText = word;
                    movie.AppendChild(actor);
                }

                doc.DocumentElement.AppendChild(movie);
                doc.Save("watchlist.xml");

                addwl.BackColor = Color.Gray;
                addwl.Text = "In Watch List";
            }
        }

        private void share_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No yet completed.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void watch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No yet completed.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
