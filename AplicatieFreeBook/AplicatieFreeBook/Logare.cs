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
using System.IO;

namespace AplicatieFreeBook
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
        }
        public static string email;
        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = false;
            SqlConnection con = new SqlConnection(Form1.constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select email,parola from Utilizatori", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                if (textBox1.Text == dr.GetValue(0).ToString() && textBox2.Text == dr.GetValue(1).ToString())
                {
                    email = dr.GetValue(0).ToString();
                    ok = true;
                    MessageBox.Show("Connectarea reusita");
                    Meniu s = new Meniu();
                    this.Hide();
                    s.Show();
                } 
            } if (!ok)
                {
                    MessageBox.Show("Verifica datele");
                }
            con.Close();
            cmd.Dispose();
        }

        private void Logare_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
