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
    public partial class Author : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Author()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs1);

            string query1 = "select * from Author_Info where Name = @Name";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@Name", name.Text);
            con.Open();

            SqlDataReader dr = cmd2.ExecuteReader();

            if (dr.HasRows == true)
            {

                MessageBox.Show(name.Text + " name already exists !!", " Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                con.Close();

                string query = "insert into Author_Info values(@name,@PublishBook,@Gender,@Country)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@name", name.Text);

                cmd.Parameters.AddWithValue("@PublishBook", textBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", AG.Text);
                cmd.Parameters.AddWithValue("@Country", Con.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Successfully Added !!");
                    BindGridView();



                }
                else
                {
                    MessageBox.Show("Inserttion failed, please try again");
                }
                con.Close();
                clearC();

            }

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from Author_Info";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "Update Author_Info set Name = @name,PublishBook=@PublishBook,Gender = @Gender,Country = @Country where Name = @name ";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@PublishBook", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", AG.Text);
            cmd.Parameters.AddWithValue("@Country", Con.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Edited");
                BindGridView();



            }
            else
            {
                MessageBox.Show("Failed, Please try again !!");
            }
            con.Close();
            clearC();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            name.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            AG.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Con.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
           
        {
            SqlConnection con = new SqlConnection(cs1);
            string query2 = "Delete from  Author_Info where Name = @name ";
            SqlCommand cmd = new SqlCommand(query2, con);

            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@PublishBook", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", AG.Text);
            cmd.Parameters.AddWithValue("@Contry", Con.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Deleted");
                BindGridView();



            }
            else
            {
                MessageBox.Show("Failed, Please try again !!");
            }
            con.Close();
            clearC();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            clearC();
        }
        void clearC()
        {
            name.Clear();
            AG.SelectedItem = null; 
            Con.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookList m = new BookList();
            m.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
