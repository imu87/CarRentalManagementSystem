using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRentalManagementSystem.Anika
{
    public partial class Maintenance : Form
    {
        // Connection string as a constant for reusability
        private const string ConnectionString = @"Data Source=DESKTOP-DASLLN7;Initial Catalog=RentalDB;Integrated Security=True;TrustServerCertificate=True";

        public Maintenance()
        {
            InitializeComponent();
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            LoadMaintenanceData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // header
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //MID
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Type
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Cost
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grid
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cnn = new SqlCommand("INSERT INTO maintenance VALUES(@mid, @type, @cost)", con);
                    cnn.Parameters.AddWithValue("@mid", int.Parse(textBox4.Text));
                    cnn.Parameters.AddWithValue("@type", textBox2.Text);
                    cnn.Parameters.AddWithValue("@cost", decimal.Parse(textBox3.Text));
                    cnn.ExecuteNonQuery();
                }
                MessageBox.Show("Record Saved Successfully");
                LoadMaintenanceData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            LoadMaintenanceData();
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cnn = new SqlCommand("UPDATE maintenance SET type=@type, cost=@cost WHERE mid=@mid", con);
                    cnn.Parameters.AddWithValue("@mid", int.Parse(textBox4.Text));
                    cnn.Parameters.AddWithValue("@type", textBox2.Text);
                    cnn.Parameters.AddWithValue("@cost", decimal.Parse(textBox3.Text));
                    cnn.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated Successfully");
                LoadMaintenanceData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();
                        SqlCommand cnn = new SqlCommand("DELETE FROM maintenance WHERE mid=@mid", con);
                        cnn.Parameters.AddWithValue("@mid", int.Parse(textBox4.Text));
                        cnn.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record Deleted Successfully");
                    LoadMaintenanceData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Helper method to load data into DataGridView
        private void LoadMaintenanceData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cnn = new SqlCommand("SELECT * FROM maintenance", con);
                    SqlDataAdapter da = new SqlDataAdapter(cnn);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Helper method to clear input fields
        private void ClearFields()
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}