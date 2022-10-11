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
    public partial class CReturn : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CReturn()
        {
            InitializeComponent();
            GetIds();
        }
        void GetIds()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from Return_Item2";
            SqlCommand cmd2 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                string id = dr.GetString(0);
                comboBox3.Items.Add(id);
            }



            con.Close();
        }
        void GetCname()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string name = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select name from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    name = Convert.ToString(dt.Rows[0]["name"]);
                }

                textBox1.Text = name.ToString();

            }

        }
        void GetCDept()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string dept = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Dept from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    dept = Convert.ToString(dt.Rows[0]["Dept"]);
                }

                comboBox2.Text = dept.ToString();

            }

        }
        void GetProduct()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string item = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select product from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    item = Convert.ToString(dt.Rows[0]["product"]);
                }

                comboBox1.Text = item.ToString();

            }

        }
        void GetCYear()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                int year = 0;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Year from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    year = Convert.ToInt32(dt.Rows[0]["Year"]);
                }

                numericUpDown1.Text = year.ToString();

            }

        }
        void GetCsemester()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                int sem = 0;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select semester from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    sem = Convert.ToInt32(dt.Rows[0]["semester"]);
                }

                numericUpDown2.Text = sem.ToString();

            }

        }
        void GetQuantity()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string quan = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Quantity from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    quan = Convert.ToString(dt.Rows[0]["Quantity"]);
                }

                textBox10.Text = quan.ToString();

            }

        }
        void GetRentD()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string RD = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Rent_Date from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    RD = Convert.ToString(dt.Rows[0]["Rent_Date"]);
                }

                dateTimePicker1.Text = RD.ToString();

            }

        }
        void GetReturnD()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string RD = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Return_Date from Return_Item2 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    RD = Convert.ToString(dt.Rows[0]["Return_Date"]);
                }

                dateTimePicker1.Text = RD.ToString();

            }

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from Return_Details2";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        void clearC()
        {
            comboBox3.SelectedItem = null;
            textBox1.Clear();
            textBox10.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            comboBox3.Focus();






        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCname();
            GetCsemester();
            GetCYear();
            GetCDept();
            GetProduct();
            GetQuantity();
            GetRentD();
            GetReturnD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from Return_Details2 where Id = @id";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@id", comboBox3.Text);
            con.Open();

            SqlDataReader fd = cmd2.ExecuteReader();

            if (fd.HasRows == true)
            {

                MessageBox.Show(comboBox3.Text + " id already exists !!", " Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                con.Close();

                string query = "insert into Return_Details2  values(@id,@name,@Dept,@Year,@Semester,@product,@Quantity,@Rent_Date,@Return_Date)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Dept", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Semester", numericUpDown2.Text);
                cmd.Parameters.AddWithValue("@product", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Quantity", textBox10.Text);
                cmd.Parameters.AddWithValue("@Rent_Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Return_Date", dateTimePicker2.Text);




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

        private void button5_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearC();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Update  Return_Details2 set  @id= id,name = @name,Dept=@Dept,Year = @Year,Semester = @Semester,product = @product,Quantity = @Quantity,Rent_Date = @Rent_Date,Return_Date = @Return_Date where Id = @id ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", comboBox3.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Dept", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@Semester", numericUpDown2.Text);
            cmd.Parameters.AddWithValue("@product", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox10.Text);
            cmd.Parameters.AddWithValue("@Rent_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Return_Date", dateTimePicker2.Text);




            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Edited !!");
                BindGridView();





            }
            else
            {
                MessageBox.Show(" Failed ! please try again ");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Delete from  Return_Details2  where Id = @id ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", comboBox3.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Dept", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@Semester", numericUpDown2.Text);
            cmd.Parameters.AddWithValue("@product", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox10.Text);
            cmd.Parameters.AddWithValue("@Rent_Date", dateTimePicker1.Text);

            cmd.Parameters.AddWithValue("@Return_Date", dateTimePicker2.Text);


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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            numericUpDown2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }
    }
}
