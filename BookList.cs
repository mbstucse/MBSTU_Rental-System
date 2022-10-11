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
    public partial class BookList : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public BookList()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from BookList where isbn = @isbn";
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

                string query = "insert into BookList values(@isbn,@name,@Author,@Edition,@Price,@Discount,@Avaiable,@Quantity,@Catagory)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@isbn", Id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@Author", Author.Text);
                cmd.Parameters.AddWithValue("@Edition", Edition.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox2.Text);
                cmd.Parameters.AddWithValue("@Avaiable", Available.Text);
                cmd.Parameters.AddWithValue("@Quantity", textBox1.Text);
                cmd.Parameters.AddWithValue("@Catagory", comboBox2.Text);


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
                clearC();
            }
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from BookList";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        



        private void button6_Click(object sender, EventArgs e)
        {
            clearC();
        }
        void clearC()
        {
            Id.Clear();
            name.Clear();
            Author.Clear();
            Edition.Clear();
            Price.Clear();
            textBox1.Clear();
            Available.SelectedItem = null;
            textBox2.Clear();
            comboBox2.SelectedItem = null;
            Id.Focus();
  

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Author.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Edition.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Price.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Available.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Update BookList  set isbn = @isbn,name = @name, Author = @Author ,Edition = @Edition, Price = @Price,Discount = @Discount ,Avaiable = @Avaiable,Quantity=@Quantity,Catagory = @Catagory where isbn = @isbn ";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@isbn", Id.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@Author", Author.Text);
            cmd.Parameters.AddWithValue("@Edition", Edition.Text);
            cmd.Parameters.AddWithValue("@Price", Price.Text);
            cmd.Parameters.AddWithValue("@Discount", textBox2.Text);
            cmd.Parameters.AddWithValue("@Avaiable", Available.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox1.Text);
            cmd.Parameters.AddWithValue("@Catagory", comboBox2.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Edited!!");
                BindGridView();



            }
            else
            {
                MessageBox.Show(" Failed ! please try again ");
            }
            con.Close();
            clearC();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Delete from BookList where isbn = @isbn ";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@isbn", Id.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@Author", Author.Text);
            cmd.Parameters.AddWithValue("@Edition", Edition.Text);
            cmd.Parameters.AddWithValue("@Price", Price.Text);
            cmd.Parameters.AddWithValue("@Discount", textBox2.Text);
            cmd.Parameters.AddWithValue("@Avaiable", Available.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox1.Text);
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
            clearC();
        }

        private void label12_Click(object sender, EventArgs e)
        {
           
        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            BookShop bs = new BookShop();
            this.Hide();
            bs.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Author us1 = new Author();
            us1.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
       
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
