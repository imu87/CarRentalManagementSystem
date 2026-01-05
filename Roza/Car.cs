using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRentalManagementSystem.Roza
{
    public partial class Car : Form
    {
        // Connection string defined once to avoid repetition
        string connectionString = @"Data Source=DESKTOP-GEJUJQ3;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True";

        public Car()
        {
            InitializeComponent();
        }

        private void Car_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Helper method to refresh the GridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cnn = new SqlCommand("Select * from cars", con);
                    SqlDataAdapter da = new SqlDataAdapter(cnn);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView2.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }



        private void saveR_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Updated 'CarName' to 'CarNamer' to match your database
                    string query = "INSERT INTO cars (CarId, CarNamer, CarNumber, CarModel, RentPrice, CarStatus) VALUES (@CarId, @CarName, @CarNumber, @CarModel, @Rentprice, @CarStatus)";

                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@CarId", int.Parse(textBox2.Text));
                        cnn.Parameters.AddWithValue("@CarName", textBox5.Text); // Parameter name is fine as is
                        cnn.Parameters.AddWithValue("@CarNumber", textBox4.Text);
                        cnn.Parameters.AddWithValue("@CarModel", textBox6.Text);
                        cnn.Parameters.AddWithValue("@Rentprice", int.Parse(textBox1.Text));
                        cnn.Parameters.AddWithValue("@CarStatus", textBox3.Text);

                        cnn.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record Saved");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record: " + ex.Message);
            }
        }
        private void UpdateR_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Fix: Corrected UPDATE syntax and removed trailing parenthesis
                    string query = "UPDATE cars SET CarName=@CarName, CarNumber=@CarNumber, CarModel=@CarModel, RentPrice=@Rentprice, CarStatus=@CarStatus WHERE CarId=@CarId";

                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@CarId", int.Parse(textBox2.Text));
                        cnn.Parameters.AddWithValue("@CarName", textBox5.Text);
                        cnn.Parameters.AddWithValue("@CarNumber", textBox4.Text);
                        cnn.Parameters.AddWithValue("@CarModel", textBox6.Text);
                        cnn.Parameters.AddWithValue("@Rentprice", int.Parse(textBox1.Text));
                        cnn.Parameters.AddWithValue("@CarStatus", textBox3.Text);

                        cnn.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record updated");
                LoadData(); // Refresh table
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void DeleteR_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cnn = new SqlCommand("DELETE FROM cars WHERE CarId=@CarId", con);
                    cnn.Parameters.AddWithValue("@CarId", int.Parse(textBox2.Text));

                    cnn.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted");
                LoadData(); // Refresh table
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }
        }

        private void AddR_Click(object sender, EventArgs e)
        {
            LoadData(); // Simply reloads the grid
        }

        // Empty event handlers kept to avoid designer errors
        private void label6_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}