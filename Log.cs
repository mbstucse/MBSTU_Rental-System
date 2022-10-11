using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {


                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query2 = "select * from sign_up1 where Email = @Email and Pass = @Pass";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@Email", textBox1.Text);
                cmd2.Parameters.AddWithValue("@Pass", textBox2.Text);
                con.Open();

                SqlDataReader rd = cmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show("Login Succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Template f = new Template();
                    this.Hide();
                    f.Show();

                }
                else
                {
                    MessageBox.Show("Login Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("please fill both fields !!", "failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;

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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup su = new signup();
            this.Hide();
            su.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            this.Hide();
            a.Show();
        }
    }
}
