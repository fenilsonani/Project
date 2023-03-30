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
using System.Data.Sql;

namespace Project
{
   
    public partial class Form1 : Form
    {
        String password, email, role;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SAKIP02;Initial Catalog=project;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }



        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            password = materialTextBox2.Text;
            email = materialTextBox1.Text;
            role = materialComboBox1.Text;

            con.Close();

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from users where email='" + email + "' and password='" + password + "' and role='" + role + "' ; ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (role == "Admin")
                {
                    this.Hide();
                    MessageBox.Show("Welcome Admin");
                    //will render the Form2
                }
                else if (role == "Staff")
                {
                    this.Hide();
                    MessageBox.Show("Welcome Staff");
                }
            }
            else
            {
                label2.Visible=true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
