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
//using System.Data;

namespace CarRentalManagementSystem
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_3(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_4(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            
            txtUsername.Focus();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=EMRAAN;Initial Catalog=CarRentalManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            SqlCommand cmd = new SqlCommand("select UserName,Password from logintab where UserName='"
                + txtUsername.Text + "' and Password='" + txtPassword.Text + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Success");
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }

            con.Close();
        }
    }
}
