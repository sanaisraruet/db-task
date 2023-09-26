using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Data; using
Microsoft.Data.SqlClient; using
System.Drawing; using
System.Linq; using System.Text; 
using System.Threading.Tasks; 
using System.Windows.Forms; 
using System.Diagnostics; 
namespace myfirstproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            txtMessageText.Text = "Startup..."; try
            {
                System.Diagnostics.Debug.WriteLine("within the try");
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KKE079F\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True");
                connection.Open();
                txtMessageText.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                txtMessageText.Text = "Error, " + ex;
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KKE079F\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True");
            connection.Open();
            txtMessageText.Text = "Retrieving Records...";
            command.Connection = connection;
            command.CommandText = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtMessageText.Text = "Retrieval Successful!";
            connection.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KKE079F\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True");
            connection.Open();
            txtMessageText.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (CustomerID, CompanyName) values('" +
           txtID.Text + "','" + txtCompanyName.Text + "')";
            command.ExecuteNonQuery();
            txtMessageText.Text = "Record Inserted...";
            connection.Close();
        }
        private void btnCount_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KKE079F\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True; TrustServerCertificate=True");
            connection.Open();
            txtMessageText.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            txtMessageText.Text = "Number of records: " + count;
            connection.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}