using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp3
{
    public partial class signup : Form
    {
        string pattern = "^([0-9a-zA]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        
        public signup()
        {
            InitializeComponent();
        }

        private void Fname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Fname.Text) == true)
            {
               Fname.Focus();
                errorProvider1.SetError(this.Fname, "pls enter your First Name !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void Fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(char.IsLetter(ch)== true)
            {
                e.Handled = false;
            }
            else if(ch == 8)
                {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }






        }

        private void Lname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Lname.Text) == true)
            {
                Lname.Focus();
                errorProvider2.SetError(this.Lname, "pls enter your Last Name !!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void Lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                comboBox2.Focus();
                errorProvider3.SetError(this.comboBox2, "pls select your Dept!!");
            }
            else
            {
                errorProvider3.Clear();
            }
            }

        private void Email_Leave(object sender, EventArgs e)
        {
         if(Regex.IsMatch(Email.Text,pattern)== false)
            {
                Email.Focus();
                errorProvider4.SetError(this.Email, "Invalid Email !!");
            }
         else
            {
                errorProvider4.Clear();
            }
        }

        private void Pass_Leave(object sender, EventArgs e)
        {
           

        }

        private void Cpass_Leave(object sender, EventArgs e)
        {
            if(Pass.Text != Cpass.Text)
            {
                errorProvider6.SetError(this.Cpass, "ReEnter Your Password !!");
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider7.SetError(this.comboBox1, "pls select your Dept!!");
            }
            else
            {
                errorProvider7.Clear();
            }
            }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                numericUpDown1.Focus();
                errorProvider8.SetError(this.numericUpDown1, "pls select the Year!!");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void numericUpDown2_Leave(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0)
            {
                numericUpDown2.Focus();
                errorProvider9.SetError(this.numericUpDown2, "pls select the semester !!");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider10.SetError(this.textBox1, "Please enter your ID !!");
            }
           
           else if (string.IsNullOrEmpty(Fname.Text) == true)
            {
                Fname.Focus();
                errorProvider1.SetError(this.Fname, "pls enter your First Name !!");
            }
            else if (string.IsNullOrEmpty(Lname.Text) == true)
            {
                Lname.Focus();
                errorProvider2.SetError(this.Lname, "pls enter your Last Name !!");
            }
            else if (comboBox2.SelectedItem == null)
            {
                comboBox2.Focus();
                errorProvider3.SetError(this.comboBox2, "pls select your Dept!!");
            }
            else if (Regex.IsMatch(Email.Text, pattern) == false)
            {
                Email.Focus();
                errorProvider4.SetError(this.Email, "Invalid Email !!");
            }
            else if (Pass.Text != Cpass.Text)
            {
                errorProvider6.SetError(this.Cpass, "ReEnter Your Password !!");
            }
            else if (Pass.Text == "")
            {
                Pass.Focus();
                errorProvider5.SetError(this.Pass, "Enter Your Password !!");
            }
            else if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider7.SetError(this.comboBox1, "pls select your Dept!!");
            }
            else if (numericUpDown1.Value == 0)
            {
                numericUpDown1.Focus();
                errorProvider8.SetError(this.numericUpDown1, "pls select the Year!!");
            }
            else if (numericUpDown2.Value == 0)
                {
                    numericUpDown2.Focus();
                    errorProvider9.SetError(this.numericUpDown2, "pls select the semester !!");
                }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query2 = "select * from sign_up where ID = @id";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@Id", Id.Text);

                
                con.Open();
             SqlDataReader rd = cmd2.ExecuteReader();
                if(rd.HasRows == true)
                {
                
                    MessageBox.Show(Id.Text +  "  Id Already Exists !!  ","Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "insert into sign_up1 values (@Id,@Fname,@Lname,@Gender,@Email,@Pass,@Dept,@Year,@Semester)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id",textBox1.Text);
                    cmd.Parameters.AddWithValue("@Fname", Fname.Text);
                    cmd.Parameters.AddWithValue("@Lname", Lname.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Pass", Pass.Text);
                    cmd.Parameters.AddWithValue("@Dept", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("Semester", numericUpDown2.Text);


                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Registered Succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("Registered Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    con.Close();
                }

                

               
            }







        }

        private void Pass_Leave_1(object sender, EventArgs e)
        {
            if (Pass.Text == "")
            {
                Pass.Focus();
                errorProvider5.SetError(this.Pass, "Enter Your Password !!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Fname.Clear();
            Lname.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            Email.Clear();
            Pass.Clear();
            Cpass.Clear();
                }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider10.SetError(this.textBox1, "Please enter your ID !!");
            }
            else
            {
                errorProvider10.Clear();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Log l = new Log();
            this.Hide();
            l.Show();
        }
    }
    }

