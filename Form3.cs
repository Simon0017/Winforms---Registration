using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class Form3 : Form
    {
        public Form3(string name, string username, string location, string idNo, string status, string employer)
        {
            InitializeComponent();

            label2.Text = name;
            label5.Text = username;
            label7.Text = location;
            label9.Text = idNo;
            label13.Text = status;
            label11.Text = employer;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
