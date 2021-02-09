using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace FirstFormApp
{
    public partial class loginform : Form
    {
        static string connStr = "server=localhost;user=root;database=csharp;port=3306;password=password";
        MySqlConnection connection = new MySqlConnection(connStr);

        public loginform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Fields are empty");
            }
            else
            {


                try
                {
                    string getValuesQuery = $"SELECT * FROM users WHERE SQLusername = '{username.Text}' AND SQLpassword = '{password.Text}';";
                    MySqlCommand getValues = new MySqlCommand(getValuesQuery, connection);
                    connection.Open();
                    getValues.ExecuteNonQuery();
                    MySqlDataReader reader = getValues.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        MessageBox.Show("Login sucessful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                    reader.Close();
                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.Close();


                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 regpage = new Form1();
            this.Hide();
            regpage.ShowDialog();
        }
    }
}
