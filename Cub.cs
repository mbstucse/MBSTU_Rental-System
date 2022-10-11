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
    public partial class Cub : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Cub()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from CycleList where Name like @name + '%'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from CycleList where name like @name + '%'";
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
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from CartList2";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            da.Fill(data);
            dataGridView2.DataSource = data;


        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            Model.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Price.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Quantity.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            Available.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Discount.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from CartList2 where  Id = @id";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@id", Id.Text);
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

                string query = "insert into CartList2 values(@id,@name,@Model,@Price,@Quantity,@Avaiable,@Discount)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", Id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);

                cmd.Parameters.AddWithValue("@Model", Model.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);
                cmd.Parameters.AddWithValue("@Avaiable", Available.Text);

                cmd.Parameters.AddWithValue("@Discount", Discount.Text);


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

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Delete from CartList2 where Id = @id ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", Id.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);

            cmd.Parameters.AddWithValue("@Model", Model.Text);
            cmd.Parameters.AddWithValue("@Price", Price.Text);
            cmd.Parameters.AddWithValue("@Discount", Discount.Text);
            cmd.Parameters.AddWithValue("@Avaiable", Available.Text);
            cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);





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
    }
}
