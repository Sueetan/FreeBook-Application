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
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
        }
        public static string mail;
        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = 1; i <= 20; i++)
           // {
                if (textBox4.Text == textBox5.Text && textBox1.Text !="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    SqlConnection con = new SqlConnection(Form1.constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Utilizatori(email,parola,nume,prenume) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);  mail = textBox1.Text;
                MessageBox.Show("Inregistrarea a reusit");
                    this.Hide();
                    Meniu s = new Meniu();
                    s.Show();
              
                }
                else MessageBox.Show("Verifica datele");
            //}
            
        }

        private void Inregistrare_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
