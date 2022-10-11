using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class BookMain : Form
    {
        public BookMain()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            BookShop bs = new BookShop();
            this.Hide();
            bs.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            instruments i = new instruments();
            this.Hide();
            i.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bus b = new Bus();
            this.Hide();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Audi a = new Audi();
            this.Hide();
            a.Show();
        }
    }
}
