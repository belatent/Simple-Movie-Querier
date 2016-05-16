using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace A2Q3
{
    public partial class Result : Form
    {
        string keyword;
        public Result(int sign, string keyword, string type)
        {
            InitializeComponent();
            if (sign == 1)
                findResult(keyword, type);
            else if (sign == 2)
                advanceFind(keyword);

            this.keyword = keyword;
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

        private void findResult(string keyword, string type)
        {
            XmlDocument xDoc = new XmlDocument(); //open xml file

            xDoc.Load("movieRecord.xml");

            string movieNames = null;
            int numOfMovies = 0;

            foreach (XmlNode node in xDoc.SelectNodes("movielist/movie")) //choose movies
            {
                XmlNodeList movie = node.SelectNodes(type);
                if (movie != null)
                {
                    string title = node.SelectSingleNode("title").InnerText;
                    if (!dupCheck(movieNames, title))
                    {
                        foreach (XmlNode attribute in movie) //choose attributes
                        {
                            //MessageBox.Show(keyword + "\n" + attribute.InnerText);
                            if (type == "length")
                                keyword += " min";
                            if (attribute.InnerText.Replace(" ", "").ToLower() == keyword.Replace(" ", "").ToLower())
                            {
                                //MessageBox.Show("adding~");
                                string combo = null;

                                ListViewItem holder = new ListViewItem(node.SelectSingleNode("title").InnerText);
                                holder.SubItems.Add(node.SelectSingleNode("year").InnerText);
                                holder.SubItems.Add(node.SelectSingleNode("length").InnerText);
                                holder.SubItems.Add(node.SelectSingleNode("rating").InnerText);
                                holder.SubItems.Add(node.SelectSingleNode("director").InnerText);

                                foreach (XmlNode singleNode in node.SelectNodes("genre")) //for muti-value node, combine each node into a string to dislay at once
                                {
                                    if (combo == null)
                                        combo += (singleNode.InnerText);
                                    else
                                        combo += ("," + singleNode.InnerText);
                                }
                                holder.SubItems.Add(combo);

                                combo = null;
                                foreach (XmlNode singleNode in node.SelectNodes("actor"))
                                {
                                    if (combo == null)
                                        combo += (singleNode.InnerText);
                                    else
                                        combo += ("," + singleNode.InnerText);
                                }
                                holder.SubItems.Add(combo);

                                if (node.SelectSingleNode("certification") != null)
                                    holder.SubItems.Add(node.SelectSingleNode("certification").InnerText);

                                listView1.Items.Add(holder);
                                numOfMovies++;

                                if (movieNames == null)
                                    movieNames += title;
                                else
                                    movieNames += ("," + title);

                                break;
                            } 
                        }
                    }
                }
            }
            if (numOfMovies == 0)
            {
                MessageBox.Show("No result found. Here might be the reasons:\n1.Check & change your keyword :)\n2.Use advance search and provide more information.\nIf you hit this message several times, there might have no information you want. Sorry about that.", "No result found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
            }
            else
                label1.Text += " " + numOfMovies;
        }

        private void advanceFind(String keyword)
        {
            String[] keys = keyword.Split('|');
            int numOfMovies = 0;
            //MessageBox.Show(keyword);
            String title = keys[0];
            string year = keys[1];
            string length = keys[2];
            string certification = keys[3];
            string director = keys[4];
            string rating = keys[5];
            String genre = keys[6];
            String actor = keys[7];

            XmlNode contain = readAll();
            if (title != "")
                contain = stringFilter(contain, title, "title");
            if (year != ",")
            {
                contain = numberFilter(contain, year, "year");
                //MessageBox.Show(year);
            }
            if (length != ",")
            {
                contain = numberFilter(contain, length, "length");
                //MessageBox.Show(length);
            }
            if (certification != "")
                contain = stringFilter(contain, certification, "certification");
            if (director != "")
                contain = stringFilter(contain, director, "director");
            if (rating != ",")
                contain = numberFilter(contain, rating, "rating");
            if (genre != "")
                contain = stringFilter(contain, genre, "genre");
            if (actor != "")
                contain = numberFilter(contain, actor, "actor");

            foreach (XmlNode node in contain.SelectNodes("movie")) //choose movies
            {
                string combo = null;

                ListViewItem holder = new ListViewItem(node.SelectSingleNode("title").InnerText);
                holder.SubItems.Add(node.SelectSingleNode("year").InnerText);
                holder.SubItems.Add(node.SelectSingleNode("length").InnerText);
                holder.SubItems.Add(node.SelectSingleNode("rating").InnerText);
                holder.SubItems.Add(node.SelectSingleNode("director").InnerText);

                foreach (XmlNode singleNode in node.SelectNodes("genre")) //for muti-value node, combine each node into a string to dislay at once
                {
                    if (combo == null)
                        combo += (singleNode.InnerText);
                    else
                        combo += ("," + singleNode.InnerText);
                }
                //MessageBox.Show(combo);
                holder.SubItems.Add(combo);

                combo = null;
                foreach (XmlNode singleNode in node.SelectNodes("actor"))
                {
                    if (combo == null)
                        combo += (singleNode.InnerText);
                    else
                        combo += ("," + singleNode.InnerText);
                }
                holder.SubItems.Add(combo);

                if (node.SelectSingleNode("certification") != null)
                    holder.SubItems.Add(node.SelectSingleNode("certification").InnerText);

                listView1.Items.Add(holder);
                numOfMovies++;

            }

            if (numOfMovies == 0)
            {
                MessageBox.Show("No result found. Here might be the reasons:\n1.Check & change your keyword :)\n2.Use advance search and provide more information.\nIf you hit this message several times, there might have no information you want. Sorry about that.", "No result found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
            }
            else
                label1.Text += " " + numOfMovies;
        }


        private XmlNode readAll()
        {
            int count = 0;
            string movieNames = null;
            XmlDocument doc = new XmlDocument(); //open xml file
            XmlNode holder = doc.CreateElement("movielist");

            doc.Load("movieRecord.xml");
            foreach (XmlNode node in doc.SelectNodes("movielist/movie")) //read each node then sent it into list view
            {
                string name = node.SelectSingleNode("title").InnerText;
                if (!dupCheck(movieNames, name))
                {
                    string[] separate = null;

                    XmlNode movie = doc.CreateElement("movie");

                    XmlNode title = doc.CreateElement("title");
                    title.InnerText = node.SelectSingleNode("title").InnerText;
                    movie.AppendChild(title);

                    XmlNode year = doc.CreateElement("year");
                    year.InnerText = node.SelectSingleNode("year").InnerText;
                    movie.AppendChild(year);

                    XmlNode length = doc.CreateElement("length");
                    length.InnerText = node.SelectSingleNode("length").InnerText;
                    movie.AppendChild(length);

                    if (node.SelectSingleNode("certification") != null)
                    {
                        XmlNode certification = doc.CreateElement("certification");
                        certification.InnerText = node.SelectSingleNode("certification").InnerText;
                        movie.AppendChild(certification);
                    }

                    XmlNode director = doc.CreateElement("director");
                    director.InnerText = node.SelectSingleNode("director").InnerText;
                    movie.AppendChild(director);

                    XmlNode rating = doc.CreateElement("rating");
                    rating.InnerText = node.SelectSingleNode("rating").InnerText;
                    movie.AppendChild(rating);

                    XmlNodeList atts = node.SelectNodes("genre");
                    foreach(XmlNode att in atts)
                    {
                        XmlNode genre = doc.CreateElement("genre");
                        genre.InnerText = att.InnerText;
                        movie.AppendChild(genre);
                    }

                    atts = node.SelectNodes("actor");
                    foreach (XmlNode att in atts)
                    {
                        XmlNode actor = doc.CreateElement("actor");
                        actor.InnerText = att.InnerText;
                        movie.AppendChild(actor);
                    }

                    holder.AppendChild(movie);

                    count++;
                    if (movieNames == null)
                        movieNames += title.InnerText;
                    else
                        movieNames += ("," + title.InnerText);
                }
                
            }
            //MessageBox.Show(count+"");
            return holder;
        }

        private XmlNode stringFilter(XmlNode movielist, string keyword, string type)
        {
            int count = 0;
            string[] keys = keyword.Split(',');

            foreach (XmlNode node in movielist.SelectNodes("movie")) //choose movies
            {
                bool need = false;
                XmlNodeList attributes = node.SelectNodes(type);
                if (attributes != null)
                {
                    foreach (XmlNode attribute in attributes) //choose attributes
                    {
                        //MessageBox.Show(keyword + "\n" + attribute.InnerText);
                        foreach (string key in keys)
                        {
                            //MessageBox.Show(key + "\n" + attribute.InnerText);
                            if (attribute.InnerText.Replace(" ", "").ToLower() == key.Replace(" ", "").ToLower())
                            {
                                need = true;
                                count++;
                                break;
                            }
                        }
                        if (need == true)
                            break;
                    }

                }
                if (need == false)
                {
                    movielist.RemoveChild(node);
                }
            }
            //MessageBox.Show(count + type);
            return movielist;
        }

        private XmlNode numberFilter(XmlNode movielist, string keyword, string type)
        {
            string[] keys = keyword.Split(',');
            int text;

            foreach (XmlNode node in movielist.SelectNodes("movie")) //choose movies
            {
                bool need = false;
                XmlNodeList attributes = node.SelectNodes(type);
                if (attributes != null)
                {
                    foreach (XmlNode attribute in attributes) //choose attributes
                    {
                        //MessageBox.Show(keyword + "\n" + attribute.InnerText);
                        int lowwerKey = -1;
                        int upperKey = -1;

                        if (keys.Length >1 && keys[0] == "" && keys[1] != "")
                            lowwerKey = int.Parse(keys[1]);
                        else if (keys.Length > 1 && keys[1] == "" && keys[0] != "")
                            lowwerKey = int.Parse(keys[0]);
                        else if (keys[0] != "" && keys[1] != "")
                        {
                            lowwerKey = int.Parse(keys[0]);
                            upperKey = int.Parse(keys[1]);
                        }

                        if (lowwerKey >= 0)
                        {

                            if (type == "length")
                                text = int.Parse(attribute.InnerText.Split(' ')[0]);
                            else
                                text = int.Parse(attribute.InnerText);
                            //MessageBox.Show(text+"");
                            if (upperKey > -1)
                            {
                                if (text <= upperKey && text >= lowwerKey)
                                {
                                    need = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (text == lowwerKey)
                                {
                                    need = true;
                                    break;
                                }
                            }
                        }

                    }

                }
                if (need == false)
                {
                    movielist.RemoveChild(node);
                }
            }
            return movielist;
        }

        private void showGraph(string keyword)
        {
            string x = null;
            string y = null;
            string z = null;
            String[] keys = keyword.Split('|');
            int numOfMovies = 0;
            //MessageBox.Show(keyword);
            String title = keys[0];
            string year = keys[1];
            string length = keys[2];
            string certification = keys[3];
            string director = keys[4];
            string rating = keys[5];
            String genre = keys[6];
            String actor = keys[7];

            XmlNode contain = readAll();
            if (title != "")
                contain = stringFilter(contain, title, "title");
            if (year != ",")
            {
                contain = numberFilter(contain, year, "year");
                //MessageBox.Show(year);
            }
            if (length != ",")
            {
                contain = numberFilter(contain, length, "length");
                //MessageBox.Show(length);
            }
            if (certification != "")
                contain = stringFilter(contain, certification, "certification");
            if (director != "")
                contain = stringFilter(contain, director, "director");
            if (rating != ",")
                contain = numberFilter(contain, rating, "rating");
            if (genre != "")
                contain = stringFilter(contain, genre, "genre");
            if (actor != "")
                contain = numberFilter(contain, actor, "actor");

            foreach (XmlNode node in contain.SelectNodes("movie")) //choose movies
            {
                if (x == null)
                    x += node.SelectSingleNode("year").InnerText;
                else
                    x += "," + node.SelectSingleNode("year").InnerText;

                if (y == null)
                    y += node.SelectSingleNode("rating").InnerText;
                else
                    y += "," + node.SelectSingleNode("rating").InnerText;

                if (z == null)
                    z += node.SelectSingleNode("length").InnerText.Split(' ')[0];
                else
                    z += "," + node.SelectSingleNode("length").InnerText.Split(' ')[0];

                numOfMovies++;

            }

            if (numOfMovies == 0)
                MessageBox.Show("No result found. Here might be the reasons:\n1.Check & change your keyword :)\n2.Use advance search and provide more information.\nIf you hit this message several times, there might have no information you want. Sorry about that.", "No result found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ChooseAttr ca = new ChooseAttr(x, y, z);
                ca.ShowDialog();
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string info;

                info = listView1.SelectedItems[0].SubItems[0].Text;
                info += "|" + listView1.SelectedItems[0].SubItems[1].Text;
                info += "|" + listView1.SelectedItems[0].SubItems[2].Text;
                info += "|" + listView1.SelectedItems[0].SubItems[3].Text;
                info += "|" + listView1.SelectedItems[0].SubItems[4].Text;
                info += "|" + listView1.SelectedItems[0].SubItems[5].Text;
                info += "|" + listView1.SelectedItems[0].SubItems[6].Text;

                if (listView1.SelectedItems[0].SubItems.Count > 7)
                    info += "|" + listView1.SelectedItems[0].SubItems[7].Text;
                else
                    info += "|";

                DetailPage dp = new DetailPage(info);
                dp.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showGraph(keyword);
        }
    }
}
