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
    public partial class OD1 : Form
    {
        int SrNo = 0;
        int finalcost;
        int tax = 0;


        string cs1 = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public OD1()
        {
            InitializeComponent();
            GetId();
            GetProduct();
            GetInvoice();

            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "SR_No";
            dataGridView1.Columns[1].Name = "Product_Name";
            dataGridView1.Columns[2].Name = "Price";
            dataGridView1.Columns[3].Name = "Discount";
            dataGridView1.Columns[4].Name = "Quantity";
            dataGridView1.Columns[5].Name = "Sub_Total";
            dataGridView1.Columns[6].Name = "Tax";
            dataGridView1.Columns[7].Name = "Total_Cost";

        }
        void GetId()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from customer_Details";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Id = dr.GetString(0);
                comboBox3.Items.Add(Id);
            }



            con.Close();
        }
        void GetProduct()
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "select * from BookList";
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
        void GetCname()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                string name = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select name from customer_Details where Id = @id";
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
                string query = "select Dept from customer_Details where Id = @id";
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
        void GetCYear()
        {
            if (comboBox3.SelectedItem == null)
            {

            }
            else
            {


                int year = 0;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Year from customer_Details where Id = @id";
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
                string query = "select semester from customer_Details where Id = @id";
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
        void GetPrice()
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {


                int price = 0;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Price from BookList where name = @name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    price = Convert.ToInt32(dt.Rows[0]["Price"]);
                }

                textBox2.Text = price.ToString();

            }

        }
        void Addddata(string SR_No, string Product_Name, string price, string Discount, string Quantity, string Sub_Total, string Tax, String Total_Cost)
        {
            string[] row = { SR_No, Product_Name, price, Discount, Quantity, Sub_Total, Tax, Total_Cost };
            dataGridView1.Rows.Add(row);
        }
        void GetInvoice()
        {





            SqlConnection con = new SqlConnection(cs1);
            string query = "select Invoice_no from Bill ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);



            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count < 1)
            {

                name.Text = "1";
            }

            else
            {
                string query1 = "select max(Invoice_no) from Bill ";
                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                a = a + 1;
                name.Text = a.ToString();

                con.Close();

            }



        }
        void calFinalCost()
        {
            finalcost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                finalcost = finalcost + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
            }
            textBox6.Text = finalcost.ToString();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetPrice();
            GetDiscount();

            textBox10.Enabled = true;
        }
        void GetDiscount()
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                string Discount = null;
                SqlConnection con = new SqlConnection(cs1);
                string query = "select Discount from BookList where name = @name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);


                sda.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    Discount = Convert.ToString(dt.Rows[0]["Discount"]);
                }

                textBox9.Text = Discount.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Addddata((++SrNo).ToString(), comboBox1.SelectedItem.ToString(), textBox2.Text.ToString(), textBox9.Text.ToString(), textBox10.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString());
                reset();
                calFinalCost();
            }
            else
            {
                MessageBox.Show("Please Select an Item !");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox10.Text))
            {

            }
            else
            {


                int price = Convert.ToInt32(textBox2.Text);
                int Discount = Convert.ToInt32(textBox9.Text);
                int Quantity = Convert.ToInt32(textBox10.Text);
                int Subtotal = price * Quantity;
                Subtotal = Subtotal - (Discount * Quantity);
                textBox3.Text = Subtotal.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {

            }
            else
            {
                int Subtotal = Convert.ToInt32(textBox3.Text);
                if (Subtotal >= 10000)
                {
                    tax = (int)(Subtotal * 0.5);
                    textBox4.Text = tax.ToString();
                }
                else if (Subtotal >= 6000)
                {
                    tax = (int)(Subtotal * 0.10);
                    textBox4.Text = tax.ToString();
                }
                else if (Subtotal >= 3000)
                {
                    tax = (int)(Subtotal * 0.06);
                    textBox4.Text = tax.ToString();
                }
                else if (Subtotal >= 1000)
                {
                    tax = (int)(Subtotal * 0.04);
                    textBox4.Text = tax.ToString();
                }
                else
                {
                    tax = (int)(Subtotal * 0.02);
                    textBox4.Text = tax.ToString();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {

            }
            else
            {



                int Subtotal = Convert.ToInt32(textBox3.Text);
                int tax = Convert.ToInt32(textBox4.Text);
                int totalcost = Subtotal + tax;
                textBox5.Text = totalcost.ToString();

            }
        }
        void reset()
        {
            comboBox1.SelectedItem = null;
            textBox2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            textBox10.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SrNo = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCname();
            GetCDept();
            GetCYear();
            GetCsemester();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs1);
            string query = "insert into Bill values(@invoice_id,@Id,@Name,@Dept,@Year,@Semester,@datetime,@finalcost)";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@invoice_id", name.Text);
            cmd.Parameters.AddWithValue("@Id", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Dept", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Year", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@Semester", numericUpDown2.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@finalcost", textBox6.Text);



            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Inserted !!");
                GetInvoice();
                clearC();



            }
            else
            {
                MessageBox.Show(" Failed ! please try again ");
            }
            con.Close();

        }
        void clearC()
        {

            comboBox3.SelectedItem = null;

            textBox1.Clear();
            comboBox2.SelectedItem = null;

            
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            textBox6.Clear();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox7.Text) == true)
            {

            }
            else
            {
                int AmountPaid = Convert.ToInt32(textBox7.Text);
                int finalcost = Convert.ToInt32(textBox6.Text);
                int change = AmountPaid - finalcost;
                textBox8.Text = change.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Invoice Id: " + name.Text,new Font("Ariel",15,FontStyle.Bold),Brushes.Black,new Point(30,300));
            e.Graphics.DrawString("Customer Id: " + comboBox3.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 330));
            e.Graphics.DrawString("Customer Name: " + textBox1.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 360));
          
            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 390));
            e.Graphics.DrawString("Time: " + DateTime.Now.ToLongTimeString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 420));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 450));
            e.Graphics.DrawString("Item: " , new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 480));
            e.Graphics.DrawString("Quantity: ", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(200, 480));
            e.Graphics.DrawString("Price: ", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(370, 480));
            e.Graphics.DrawString("Discount: ", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(540, 480));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------- " , new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 510));

            int gap = 540;
            
            if(dataGridView1.Rows.Count>0)
            {
                for (int i = 0; i< dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap));
                        gap = gap + 40;
                    }
                    catch
                    {

                    }
                }
            }

            int gap1 = 540;

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(384, gap1));
                        gap1 = gap1 + 40;
                    }
                    catch
                    {

                    }
                }
            }
            int gap2 = 540;

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(554, gap2));
                        gap2 = gap2 + 40;
                    }
                    catch
                    {

                    }
                }
            }
            int gap3 = 540;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(214, gap3));
                        gap3 = gap3 + 40;
                    }
                    catch
                    {

                    }
                }
            }
           
               int subtotalprint = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    subtotalprint = subtotalprint + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);

                }
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 800));

            e.Graphics.DrawString("Subtotal: " + subtotalprint.ToString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 830));


            int Taxprint = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Taxprint = Taxprint + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

            }
         

            e.Graphics.DrawString("Tax: " + Taxprint.ToString(), new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 860));

            e.Graphics.DrawString("FinalCost:  " + textBox6.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 890));

            e.Graphics.DrawString("Amount Paid : " + textBox7.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 920));

            e.Graphics.DrawString("Change : " + textBox8.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(30, 950));




        }

        private void button6_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BookShop bs = new BookShop();
            this.Hide();
            bs.Show();
        }
    }
            
    }
    




    
    

