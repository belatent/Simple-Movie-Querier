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
    public partial class Graph : Form
    {
        public Graph(string attrX, string attrY, string x, string y)
        {
            InitializeComponent();

            string[] coordX = x.Split(',');
            string[] coordY = y.Split(',');

            label1.Text = attrY.ToUpper();
            label2.Text = attrX.ToUpper();

            for(int i = 0; i<coordX.Length;i++)
                chart1.Series["Movies"].Points.AddXY(int.Parse(coordX[i]),int.Parse(coordY[i]));
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            
        }
    }
}
