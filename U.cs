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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class U : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public U()
        {
            InitializeComponent();
            GetIds();
        }
        void GetIds()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from sign_up1";
            SqlCommand cmd2 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            while(dr.Read())
            {
                string id = dr.GetString(0);
                combobox1.Items.Add(id);
            }



            con.Close();
        }
        void GetName()

        {
            if (combobox1.SelectedItem == null)
            {

            }
            else


            {
                string Fname = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Fname from sign_up1 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", combobox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Fname = Convert.ToString(dt.Rows[0]["Fname"]);
                }

                name.Text = Fname.ToString();



            }
        }

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetName();
            GetName1();
            GetUName();
            GetDept();
            year();
            semester();
        }
        void GetName1()
        {
            if (combobox1.SelectedItem == null)
            {

            }
            else
            {
                string lname = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Lname from sign_up1 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", combobox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lname = Convert.ToString(dt.Rows[0]["Lname"]);
                }

                textBox1.Text = lname.ToString();



            }
        }
        void GetUName()
        {
            if (combobox1.SelectedItem == null)
            {

            }
            else
            {
                string email = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Email from sign_up1 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", combobox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    email = Convert.ToString(dt.Rows[0]["Email"]);
                }

                uname.Text = email.ToString();

            }

        }
        void GetDept()
        {
            if (combobox1.SelectedItem == null)
            {

            }
            else
            {

                string dept = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Combobox1 from sign_up1 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", combobox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    dept = Convert.ToString(dt.Rows[0]["Combobox1"]);
                }

                DEPT.Text = dept.ToString();


            }
        }
        void year()
        {
            if (combobox1.SelectedItem == null)
            {

            }
            else
            {

                string year = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select numericUpDown1 from sign_up1 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", combobox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    year = Convert.ToString(dt.Rows[0]["numericUpDown1"]);
                }

                textBox2.Text = year.ToString();

            }

        }
        void semester()
        {
            if (combobox1.SelectedItem == null)
            {

            }
            else
            {
                string sem = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select numericUpDown2 from sign_up1 where Id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@id", combobox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    sem = Convert.ToString(dt.Rows[0]["numericUpDown2"]);
                }

                textBox3.Text = sem.ToString();

            }

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from User_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        void clearC()
        {
            combobox1.SelectedItem = null;
            name.Clear();
            textBox1.Clear();
            uname.Clear();
            DEPT.Clear();
            textBox2.Clear();

            textBox3.Clear();

            combobox1.Focus();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            


                SqlConnection con = new SqlConnection(cs1);
                string query1 = "select * from User_tbl where Id = @id";
                SqlCommand cmd2 = new SqlCommand(query1, con);
                cmd2.Parameters.AddWithValue("@id", combobox1.Text);
                con.Open();

                SqlDataReader fd = cmd2.ExecuteReader();

                if (fd.HasRows == true)
                {

                    MessageBox.Show(combobox1.Text + " id already exists !!", " Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    con.Close();

                    string query = "insert into  User_tbl values(@id,@Fname,@Lname,@Uname,@Dept,@Year,@Semester)";
                    SqlCommand cmd = new SqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@id", combobox1.Text);
                    cmd.Parameters.AddWithValue("@Fname", name.Text);
                    cmd.Parameters.AddWithValue("@Lname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Uname", uname.Text);
                    cmd.Parameters.AddWithValue("@Dept", DEPT.Text);
                    cmd.Parameters.AddWithValue("@Year", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Semester", textBox3.Text);



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

        private void button4_Click(object sender, EventArgs e)
        {
            BookMain bm = new BookMain();
            this.Hide();
             bm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearC();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           combobox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            uname.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            DEPT.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "Update  User_tbl set Id = @id,Fname = @Fname, Lname = @Lname ,Uname = @Uname, Dept = @Dept,Year = @Year ,Semester = @Semester where  Id= @id ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", combobox1.Text);
            cmd.Parameters.AddWithValue("@Fname", name.Text);
            cmd.Parameters.AddWithValue("@Lname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Uname", uname.Text);
            cmd.Parameters.AddWithValue("@Dept", DEPT.Text);
            cmd.Parameters.AddWithValue("@Year", textBox2.Text);
            cmd.Parameters.AddWithValue("@Semester", textBox3.Text);


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
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            


                SqlConnection con = new SqlConnection(cs1);
                string query = "Delete from User_tbl where  Id= @id ";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", combobox1.Text);
                cmd.Parameters.AddWithValue("@Fname", name.Text);
                cmd.Parameters.AddWithValue("@Lname", textBox1.Text);
                cmd.Parameters.AddWithValue("@Uname", uname.Text);
                cmd.Parameters.AddWithValue("@Dept", DEPT.Text);
                cmd.Parameters.AddWithValue("@Year", textBox2.Text);
                cmd.Parameters.AddWithValue("@Semester", textBox3.Text);


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
    }
}
