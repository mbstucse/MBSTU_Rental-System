using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Customer : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from customer where Id = @Id";
            SqlCommand cmd2 = new SqlCommand(query, con);
            cmd2.Parameters.AddWithValue("@ID", Id.Text);
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

                string query1 = "insert into customer values(@Id,@name,@Address,@Phone,@Dept,@Year,@Semester)";
                SqlCommand cmd = new SqlCommand(query1, con);


                cmd.Parameters.AddWithValue("@Id", Id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@Address", Add.Text);
                cmd.Parameters.AddWithValue("@Phone", phone.Text);
                cmd.Parameters.AddWithValue("@Dept", dept.Text);
                cmd.Parameters.AddWithValue("@Year", Year.Text);
                cmd.Parameters.AddWithValue("@Semester", sem.Text);



                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Successfully Added !!");
                    BindGridView2();



                }
                else
                {
                    MessageBox.Show(" Failed ! please try again ");
                }
                con.Close();
                clearC();
            }
        }
        void BindGridView2()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from customer";
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
            Add.Clear();
            phone.Clear();
            dept.SelectedItem = null;
          Year.Value = 0;
            sem.Value = 0;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindGridView2();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           Add.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           phone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           dept.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
           Year.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            sem.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "Update customer set Id = @Id,name = @name,Address = @Address,Phone = @Phone,Dept = @Dept,Year=@Year,Semester = @Semester where Id = @Id";
            SqlCommand cmd2 = new SqlCommand(query1, con);


            cmd2.Parameters.AddWithValue("@Id", Id.Text);
            cmd2.Parameters.AddWithValue("@name", name.Text);
            cmd2.Parameters.AddWithValue("@Address", Add.Text);
            cmd2.Parameters.AddWithValue("@Phone", phone.Text);
            cmd2.Parameters.AddWithValue("@Dept", dept.Text);
            cmd2.Parameters.AddWithValue("@Year", Year.Text);
            cmd2.Parameters.AddWithValue("@Semester", sem.Text);



            con.Open();
            int a = cmd2.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Edited !!");
                BindGridView2();



            }
            else
            {
                MessageBox.Show(" Failed ! please try again ");
            }
            con.Close();
            clearC();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query2 = "Delete from customer where Id = @Id";
            SqlCommand cmd = new SqlCommand(query2, con);


            cmd.Parameters.AddWithValue("@Id", Id.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@Address", Add.Text);
            cmd.Parameters.AddWithValue("@Phone", phone.Text);
            cmd.Parameters.AddWithValue("@Dept", dept.Text);
            cmd.Parameters.AddWithValue("@Year", Year.Text);
            cmd.Parameters.AddWithValue("@Semester", sem.Text);



            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Deleted !!");
                BindGridView2();



            }
            else
            {
                MessageBox.Show(" Failed ! please try again ");
            }
            con.Close();
            clearC();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookShop bs = new BookShop();
            this.Hide();
            bs.Show();
        }
    }
}
