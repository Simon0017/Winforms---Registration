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

        private void label4_Click(object sender, EventArgs e)
        {

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
                    string query = $"SELECT * FROM Table WHERE UserName = {textBox1.Text.Trim()} AND password = {textBox2.Text.Trim()} ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        
                    }
                }
            }   
        }

      
    }
}
