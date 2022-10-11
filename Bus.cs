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
    public partial class Bus : Form
    {
        public Bus()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BookMain bm = new BookMain();
            this.Hide();
            bm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            U cm = new U();
            this.Hide();
            cm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusMain bm = new BusMain();
            this.Hide();
            bm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Brent cm = new Brent();
            this.Hide();
            cm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BReturn cm = new BReturn();
            this.Hide();
            cm.Show();
        }
    }
}
