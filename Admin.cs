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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text ==  "admin"  && textBox2.Text == "123456789")
            {
                MessageBox.Show("Login Successfully");
                BookMain T = new BookMain();
                this.Hide();
                T.Show();
            }
            else
            {
                MessageBox.Show("Login failed ! Please try again");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
         
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your Username !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Your Password!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
