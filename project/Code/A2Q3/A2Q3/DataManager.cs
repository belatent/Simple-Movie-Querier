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
    public partial class DataManager : Form
    {
        

        public DataManager()
        {
            InitializeComponent();
            readMov();
            checkBox1.Checked = true;
        }

        public string[] getItem()
        {
            string[] info = new string[8];

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem send = listView1.SelectedItems[0];

                info[0] = send.SubItems[0].Text;
                info[1] = send.SubItems[1].Text;
                info[2] = send.SubItems[2].Text;
                info[3] = send.SubItems[3].Text;
                info[4] = send.SubItems[4].Text;
                info[5] = send.SubItems[5].Text;
                info[6] = send.SubItems[6].Text;
                if (send.SubItems.Count > 7)
                    info[7] = send.SubItems[7].Text;
                else
                    info[7] = null;
            }
            else
                info = null;

            return info;
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            
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

        private void readMov()
        {
            string movieNames = null;
            int numOfMovies = 0;
            int dup = 0;
            XmlDocument xDoc = new XmlDocument(); //open xml file

            xDoc.Load("movieRecord.xml");
            foreach (XmlNode node in xDoc.SelectNodes("movielist/movie")) //read each node then sent it into list view
            {
                string title = node.SelectSingleNode("title").InnerText;
                if (!dupCheck(movieNames, title))
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
                }
                else
                    dup++;


            }
            label1.Text = numOfMovies + " movie infomation load. " + dup + " duplication ignored.";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            NewMovie np = new NewMovie();
            
            np.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (getItem() != null)
            {
                EditMovie ep = new EditMovie(getItem());
                ep.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the movie :《" + listView1.SelectedItems[0].SubItems[0].Text + "》?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XmlDocument doc = new XmlDocument();

                doc.Load("movieRecord.xml");
                XmlNodeList nodeList = doc.SelectNodes("movielist/movie");
                foreach (XmlNode node in nodeList)
                {
                    if (node.SelectSingleNode("title").InnerText == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
                doc.Save("movieRecord.xml");
                listView1.Items.Clear();
                label1.Text = "";
                readMov();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label1.Text = "";
            readMov();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMovie nm = new NewMovie();
            nm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getItem() != null)
            {
                EditMovie em = new EditMovie(getItem());
                em.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clean all comments of the movie :《" + listView1.SelectedItems[0].SubItems[0].Text + "》?", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XmlDocument doc = new XmlDocument();

                doc.Load("movieRecord.xml");
                XmlNodeList nodeList = doc.SelectNodes("movielist/movie");
                foreach (XmlNode node in nodeList)
                {
                    if (node.SelectSingleNode("title").InnerText == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        foreach(XmlNode comment in node.SelectNodes("comment") )
                            node.RemoveChild(comment);
                    }
                }
                doc.Save("movieRecord.xml");
                listView1.Items.Clear();
                label1.Text = "";
                readMov();
            }
        }

        Boolean dpSwitch = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //dpSwitch = !dpSwitch;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && listView1.SelectedItems.Count > 0)
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
