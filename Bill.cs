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
    public partial class Bill : Form
    {
        int tax = 0;
        int finalcost = 0;
        int SrNo = 0;
        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Bill()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "SR_No";
            dataGridView1.Columns[1].Name = "Product_Name";
            dataGridView1.Columns[2].Name = "Price";
            dataGridView1.Columns[3].Name = "Discount";
            dataGridView1.Columns[4].Name = "Quantity";
            dataGridView1.Columns[5].Name = "Sub_Total";
            dataGridView1.Columns[6].Name = "Tax";
            dataGridView1.Columns[7].Name = "Total_Cost";
            
            GetProduct();
            GetProduct1();


        }
        


        
        void GetProduct()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from CartList";
            SqlCommand cmd2 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                string P_name = dr.GetString(1);
                Product.Items.Add(P_name);
            }



            con.Close();
        }
        void GetProduct1()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from CartList";
            SqlCommand cmd2 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                string P_name = dr.GetString(1);
                comboBox1.Items.Add(P_name);
            }



            con.Close();
        }
        void GetPrice()
        {
            if (Product.SelectedItem == null)
            {

            }
            else
            {
                int price = 0;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Price from CartList where name = @name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@name", Product.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    price = Convert.ToInt32(dt.Rows[0]["Price"]);
                }

                textBox8.Text = price.ToString();

            }

        }
        void GetPrice1()
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                int price = 0;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Price from CartList where name = @name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    price = Convert.ToInt32(dt.Rows[0]["Price"]);
                }

                textBox14.Text = price.ToString();

            }

        }
        void GetDiscount()
        {
            if (Product.SelectedItem == null)
            {

            }
            else
            {
                string Discount = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Discount from CartList where name = @name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@name", Product.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    Discount = Convert.ToString(dt.Rows[0]["Discount"]);
                }

                textBox6.Text = Discount.ToString();



            }
        }
        private void Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice();
            GetDiscount();
            textBox9.Enabled = true;
        }
        void calFinalCost()
        {
            finalcost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                finalcost = finalcost + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
            }
            textBox10.Text = finalcost.ToString();
        }
        void Addddata(string SR_No, string Product_Name, string price, string Discount, string Quantity, string Sub_Total, string Tax, String Total_Cost)
        {
            string[] row = { SR_No, Product_Name, price, Discount, Quantity, Sub_Total, Tax, Total_Cost };
            dataGridView1.Rows.Add(row);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
            }

            else
            {
                int price = Convert.ToInt32(textBox8.Text);
                int Discount = Convert.ToInt32(textBox6.Text);
                int Quantity = Convert.ToInt32(textBox9.Text);
                int Subtotal = price * Quantity;
                Subtotal = Subtotal - (Discount * Quantity);
                textBox7.Text = Subtotal.ToString();

            }
            }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {

            }
            else
            {


                int Subtotal = Convert.ToInt32(textBox7.Text);
                if (Subtotal >= 10000)
                {
                    tax = (int)(Subtotal * 0.5);
                    textBox11.Text = tax.ToString();
                }
                else if (Subtotal >= 6000)
                {
                    tax = (int)(Subtotal * 0.10);
                    textBox11.Text = tax.ToString();
                }
                else if (Subtotal >= 3000)
                {
                    tax = (int)(Subtotal * 0.06);
                    textBox11.Text = tax.ToString();
                }
                else if (Subtotal >= 1000)
                {
                    tax = (int)(Subtotal * 0.04);
                    textBox11.Text = tax.ToString();
                }
                else
                {
                    tax = (int)(Subtotal * 0.02);
                    textBox11.Text = tax.ToString();
                }
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {

            }
            else
            {


                int Subtotal = Convert.ToInt32(textBox7.Text);
                int tax = Convert.ToInt32(textBox11.Text);
                int totalcost = Subtotal + tax;
                textBox5.Text = totalcost.ToString();
            }
        }
        void reset()
        {
            Product.SelectedItem = null;
            textBox8.Clear();
            textBox6.Clear();
            textBox9.Clear();
            textBox7.Clear();
            textBox11.Clear();
            textBox5.Clear();
           


            textBox9.Enabled = false;


        }


        private void button1_click(object sender, EventArgs e)
        { 
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Addddata((++SrNo).ToString(), Product.SelectedItem.ToString(), textBox8.Text.ToString(), textBox6.Text.ToString(), textBox9.Text.ToString(), textBox7.Text.ToString(), textBox11.Text.ToString(), textBox5.Text.ToString());
            calFinalCost();

            reset();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SrNo = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query1 = "select * from customer_Details where Id = @id";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@id", textBox1.Text);
            con.Open();

            SqlDataReader fd = cmd2.ExecuteReader();

            if (fd.HasRows == true)
            {

                MessageBox.Show(textBox1.Text + " id already exists !!", " Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                con.Close();

                string query = "insert into customer_Details values(@id,@name,@Dept,@Year,@Semester,@Address,@Phone,@Email,@Product,@Price,@Quantity,@Rent_Date)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Dept", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Semester", numericUpDown2.Text);
                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox12.Text);
                cmd.Parameters.AddWithValue("@Product", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Price", textBox14.Text);
                cmd.Parameters.AddWithValue("@Quantity", textBox15.Text);
                cmd.Parameters.AddWithValue("@Rent_Date", dateTimePicker2.Text);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Thanks! Your Order has been Received");
                    

                     

                }
                else
                {
                    MessageBox.Show(" Failed ! please try again ");
                }
                con.Close();
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ub bs = new ub();
            this.Hide();
            bs.Show();
        }
    }
}
