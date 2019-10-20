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

namespace hahahaha
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-KQ82Q0O;Initial Catalog=login;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(@"select *from logpass where login = '" +
            textBox1.Text + "' and password = '" + textBox2.Text + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                Form1 f1 = new Form1();
                //log log = new log();
                //log.Close();
                f1.Show();

            }
            else
                MessageBox.Show("Не верно введен логин или пароль");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
