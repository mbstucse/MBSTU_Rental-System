using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.NetworkInformation;

namespace WindowsFormsApp3
{
    public partial class ub : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        

        public ub()
        {
            InitializeComponent();
           



        }
       


        private void button2_Click(object sender, EventArgs e)
        {
            ub u = new ub();
            this.Hide();
            u.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Template t = new Template();
            this.Hide();
            t.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Author.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Edition.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Price.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();


        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from BookList where name like @name + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name", textBox1.Text.Trim());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            if(dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Rows Found !!");
                dataGridView1.DataSource = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from BookList where name like @name + '%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@name", textBox1.Text.Trim());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Rows Found !!");
                dataGridView1.DataSource = null;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from CartList where isbn = @isbn";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@isbn", Id.Text);
            con.Open();

            SqlDataReader fd = cmd2.ExecuteReader();

            if (fd.HasRows == true)
            {

                MessageBox.Show(Id.Text + " id already exists !!", " Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }


            else
            {
                con.Close();

                string query = "insert into CartList values(@isbn,@name,@Author,@Edition,@Price,@Discount,@Catagory,@Quantity)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@isbn", Id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@Author", Author.Text);
                cmd.Parameters.AddWithValue("@Edition", Edition.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox2.Text);
                cmd.Parameters.AddWithValue("@Catagory", comboBox2.Text);

                cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Successfully Added !!");

                    BindGridView();


                }
                else
                {
                    MessageBox.Show(" Failed ! please try again ");
                }
                con.Close();

            }




        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from CartList";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            da.Fill(data);
            dataGridView2.DataSource = data;


        }

        private void button10_Click(object sender, EventArgs e)
        {
            BindGridView();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Delete from CartList where isbn = @isbn ";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@isbn", Id.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@Author", Author.Text);
            cmd.Parameters.AddWithValue("@Edition", Edition.Text);
            cmd.Parameters.AddWithValue("@Price", Price.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@Discount", textBox2.Text);
            cmd.Parameters.AddWithValue("@Catagory", comboBox2.Text);




            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Deleted!!");
                BindGridView();
            }
            else
            {
                MessageBox.Show(" Failed ! please try again ");
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bill b = new Bill();
            this.Hide();
            b.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from CartList where isbn = @isbn";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@isbn", Id.Text);
            con.Open();

            SqlDataReader fd = cmd2.ExecuteReader();

            if (fd.HasRows == true)
            {

                MessageBox.Show(Id.Text + " id already exists !!", " Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }


            else
            {
                con.Close();

                string query = "insert into CartList values(@isbn,@name,@Author,@Edition,@Price,@Discount,@Catagory,@Quantity)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@isbn", Id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@Author", Author.Text);
                cmd.Parameters.AddWithValue("@Edition", Edition.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox2.Text);
                cmd.Parameters.AddWithValue("@Catagory", comboBox2.Text);

                cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Successfully Added !!");

                    BindGridView();


                }
                else
                {
                    MessageBox.Show(" Failed ! please try again ");
                }
                con.Close();
            }
            }

        private void button10_Click_1(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            this.Hide();
            rb.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
