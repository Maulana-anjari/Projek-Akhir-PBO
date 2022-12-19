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

namespace Projek_Akhir_PBO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-8PE9MPU2\SQLEXPRESS;Initial Catalog=dvfvwork;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from Table_User where username = '" + textBoxUsername.Text + "' and password = '" + textBoxPassword.Text + "'", conn );
            DataTable dt = new DataTable();
            sda.Fill( dt );
            if (dt.Rows[0][0].ToString() == "1" )
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah!", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
