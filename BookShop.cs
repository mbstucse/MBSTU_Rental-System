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
    public partial class BookShop : Form
    {
        public BookShop()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookList b = new BookList();
            this.Hide();
            b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            U  us = new U();
            this.Hide();
            us.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            this.Hide();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BookMain bm = new BookMain();
            this.Hide();
            bm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OD1 od = new OD1();   
            this.Hide();
            od.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Rent r = new Rent();
            this.Hide();
            r.Show();   
               
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Return rm = new Return();
            this.Hide();
            rm.Show();
        }
    }
}
