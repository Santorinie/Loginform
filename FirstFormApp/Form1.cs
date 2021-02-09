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
//using Renci.SshNet;

namespace FirstFormApp
{
    public partial class Form1 : Form
    {
        static string connStr = "server=localhost;user=root;database=csharp;port=3306;password=password";
        MySqlConnection connection = new MySqlConnection(connStr);
        
    

        public Form1()
        {
            InitializeComponent();

        }

        

        private void regbutton_Click(object sender, EventArgs e)
        {
            

           string usrnm = username.Text;
           string pw = password.Text;
           string pwr = repassword.Text;


            if (pw == pwr == false)
            {
                MessageBox.Show("Passwords don't match");
            }
            else if(string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(repassword.Text))
            {
                MessageBox.Show("Missing field value");
            }
            else if ( username.TextLength > 20 || password.TextLength > 100 || repassword.TextLength > 100 )
            {
                MessageBox.Show("The username or password you entered is too long");
            }
            else
            {
                
                string insertQuery = $"INSERT INTO csharp.users(SQLusername,SQLpassword) VALUES('{username.Text}','{password.Text}'); ";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Perform database operations
                    MessageBox.Show("Refreshing SQL Database...");
                    connection.Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //if (command.ExecuteNonQuery() != 0)
                //{
                //    MessageBox.Show("Adatbázis frissítve!");
                //}
                // connection.Close();
                loginform loginform = new loginform();
                loginform.ShowDialog();
                this.Hide();

            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
            if (password.Text == repassword.Text == false)
            {
                label1.Text = "Passwords don't match";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void repassword_TextChanged(object sender, EventArgs e)
        {
            repassword.PasswordChar = '*';
            if (password.Text == repassword.Text == false)
            {
                label1.Text = "Passwords don't match";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginform alreadyRegistered = new loginform();
            this.Hide();
            alreadyRegistered.ShowDialog();
            
        }
    }
}
