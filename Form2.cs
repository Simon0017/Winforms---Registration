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

namespace Registration
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private bool IsValid()
        {
            if (textBox1.Text.TrimStart() == string.Empty){
                MessageBox.Show("Enter Valid Username");
                return false;
            }
            if (textBox2.Text.TrimStart() == string.Empty){
                MessageBox.Show("Enter Valid Username");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         if (IsValid())
            {
                using(SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wekes\OneDrive\Documents\members.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = $"SELECT * FROM [Table] WHERE UserName = '{textBox1.Text.Trim()}' AND password = '{textBox2.Text.Trim()}' ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        //Populate the data
                        string name = dta.Rows[0]["Name"].ToString();
                        string username = dta.Rows[0]["UserName"].ToString();
                        string location = dta.Rows[0]["Location"].ToString();
                        string idNo = dta.Rows[0]["ID no"].ToString();
                        string status = dta.Rows[0]["status"].ToString();
                        string employer = dta.Rows[0]["Employer"].ToString();


                        MessageBox.Show("Login Successful");

                        // Pass data to Form3 and show it
                        Form3 form3 = new Form3(name, username, location, idNo, status, employer);
                        form3.Show();

                        // Close or hide the login form (Form1)
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Login Failed!!try again ");
                    }
                }
            }   
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // if sign up is clicked
        {
            RedirectForm1();   
        }

        private void RedirectForm1()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

    }
}
