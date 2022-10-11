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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class ReturnBook : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from Return_Item where Id = @id";
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

                string query = "insert into Return_Item  values(@id,@name,@Dept,@Year,@Semester,@product,@Quantity,@Rent_Date,@Return_Date)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Dept", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Semester", numericUpDown2.Text);
                cmd.Parameters.AddWithValue("@product", textBox2.Text);
                cmd.Parameters.AddWithValue("@Quantity", textBox10.Text);
                cmd.Parameters.AddWithValue("@Rent_Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Return_Date", dateTimePicker2.Text);




                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Return Successfully !!");







                }
                else
                {
                    MessageBox.Show(" Failed ! please try again ");
                }
                con.Close();
            }
        }
    }
}
