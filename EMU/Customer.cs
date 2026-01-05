using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalManagementSystem.EMU;
//using System.Data;
using System.Data.SqlClient;

namespace CarRentalManagementSystem.EMU
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crossbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EMRAAN;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into customers Values(@customerid,@customername,@gender,@email,@phone)", con);

            cnn.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@CustomerName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", comboBox1.GetItemText(comboBox1.SelectedItem));
            cnn.Parameters.AddWithValue("@Email", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EMRAAN;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;

        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EMRAAN;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("update customers set customername=@customername,gender=@gender,email=@email,phone=@phone where customerid=@customerid", con);

            cnn.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@CustomerName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", comboBox1.GetItemText(comboBox1.SelectedItem));
            cnn.Parameters.AddWithValue("@Email", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EMRAAN;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete from customers where customerid=@customerid", con);

            cnn.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
          
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=EMRAAN;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
