using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My3DChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();




        }

  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string mystring = textBox1.Text;     ///stringi alıp string [] yapan kodlar.
            my3DClusteredBar1.XValue = mystring.Split(',');

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string mystring2 = textBox2.Text;
            my3DClusteredBar1.YValue = Array.ConvertAll(mystring2.Split(','), int.Parse); ///stringi int array yapan komut




        }
        private void my3DClusteredBar1_Click(object sender, EventArgs e)
        {

        }

        private void my3DClusteredBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void my3DClusteredBar1_Click_2(object sender, EventArgs e)
        {

        }
  
        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
