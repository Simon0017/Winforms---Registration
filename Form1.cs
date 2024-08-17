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
using System.Threading;

namespace Registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RedirectForm2()
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == textBox7.Text.Trim())
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wekes\OneDrive\Documents\members.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    try
                    {
                        conn.Open();

                        // Use parameters to safely insert data and avoid SQL injection
                        string query = "INSERT INTO [Table] (Name, Username, Location, [ID no], Status, Employer, Password) " +
                                       "VALUES (@Name, @Username, @Location, @IDNo, @Status, @Employer, @Password)";

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            // Adding parameters to avoid SQL injection
                            command.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                            command.Parameters.AddWithValue("@Username", textBox2.Text.Trim());
                            command.Parameters.AddWithValue("@Location", textBox3.Text.Trim());
                            command.Parameters.AddWithValue("@IDNo", textBox4.Text.Trim());
                            command.Parameters.AddWithValue("@Status", textBox5.Text.Trim());
                            command.Parameters.AddWithValue("@Employer", textBox6.Text.Trim());
                            command.Parameters.AddWithValue("@Password", textBox7.Text.Trim());

                            // Execute the insert command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data inserted successfully!");
                                //Thread.Sleep(4000); // sleep for 4 seconfds
                                RedirectForm2();

                            }
                            else
                            {
                                MessageBox.Show("Insert failed.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RedirectForm2();
        }
    }
}
