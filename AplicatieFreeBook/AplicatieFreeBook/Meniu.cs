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
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 3;
            label1.Text = "Email " + Logare.email;
            label5.Text = "Email " + Inregistrare.mail;
            adauga();
            this.chart2.Series["Teoria universala"].Points.AddXY(2, 2);
        }
        public static int nr = 1;
        public static string carte, titlu, autor;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (nr != 4)
            {
                if (e.ColumnIndex == 3)
                {
                    dataGridView2.Rows.Add(nr++, dataGridView1["Titlu", e.RowIndex].Value.ToString(), dataGridView1["Autor", e.RowIndex].Value.ToString(),DateTime.Now,DateTime.Now.AddDays(30));
                    progressBar1.Value++;
                    carte = dataGridView1["Titlu", e.RowIndex].Value.ToString();
                    autor = dataGridView1["Autor", e.RowIndex].Value.ToString();
                }
            }
            else MessageBox.Show("Ai imprumutat 3 carti");
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
         void adauga()
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("Titlu", typeof(string));
                dt.Columns.Add("Autor", typeof(string));
                dt.Columns.Add("Gen", typeof(string));
                    
            SqlCommand cmd;
                SqlDataReader dr;
                SqlConnection con = new SqlConnection(Form1.constr);
                con.Open();
                cmd = new SqlCommand("Select titlu,autor,gen from Carti", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt.Rows.Add(dr.GetValue(0), dr.GetValue(1), dr.GetValue(2));
                }
                dataGridView1.DataSource = dt;
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(btn1);
                    btn1.Name = "dataGridViewImprumutaButton";
                    btn1.HeaderText = "Imprumuta";
                    btn1.Text = "Imprumuta";
                    btn1.UseColumnTextForButtonValue = true;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                con.Close();
                cmd.Dispose();
            }
        public static int numara = 0;

        public string dt11 = "1/1/2019";
        public string dt12 = "12 / 29 / 2019";
        public string dt2 = "1/1/2018";
        public string dt22 = "12/29/2018";
        public string dt3 = "1/1/2017";
        public string dt33 = "12/29/2017";
        void graph()
        {
            SqlConnection con = new SqlConnection(Form1.constr);
            con.Open();
            SqlDataReader dr;
            if (comboBox1.Text == "2019")
            {
                SqlCommand cmd = new SqlCommand("select email,data_imprumut from Imprumut where data_imprumut between '" + dt11 + "' and '" + dt12 + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numara++;

                }
                this.chart1.Series["Anul"].Points.AddXY("2019", numara);
                con.Close();
                cmd.Dispose();
            }
            if (comboBox1.Text == "2018")
            {
                SqlCommand cmd = new SqlCommand("select email,data_imprumut from Imprumut where data_imprumut between '" + dt2 + "' and '" + dt22 + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numara++;

                }
                this.chart1.Series["Anul"].Points.AddXY("2018", numara);
                con.Close();
                cmd.Dispose();
            }
            if (comboBox1.Text == "2017")
            {
                SqlCommand cmd = new SqlCommand("select email,data_imprumut from Imprumut where data_imprumut between '" + dt3 + "' and '" + dt33 + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numara++;

                }
                this.chart1.Series["Anul"].Points.AddXY("2017", numara);
                con.Close();
                cmd.Dispose();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AfiseazaCarte s = new AfiseazaCarte();
            s.Show();
        }

        private void Meniu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
