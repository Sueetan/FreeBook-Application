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
    public partial class Form1 : Form
    {
        public static string constr = Properties.Settings.Default.FreeBookConnectionString;
        //public static string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FreeBook.mdf;Integrated Security=True;";

       // public static string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mures\Desktop\OTI_SJ_D_03\AplicatieFreeBook\AplicatieFreeBook\bin\Debug\FreeBookneport.mdf;Integrated Security=True;Connect Timeout=30;";
        public Form1()
        {
            InitializeComponent();
        }
        void stergere()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("Delete from Carti", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Carti", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Delete from Imprumut", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Imprumut", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Delete from Utilizatori", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        void initializare1()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            StreamReader sr = new StreamReader(Application.StartupPath + @"\..\..\utilizatori.txt");
            string sir;
            char[] split = { '*' };
            con.Open();
            
            while((sir =  sr.ReadLine())!=null)
            {
                string[] siruri = sir.Split(split);

            
            cmd = new SqlCommand("Insert into Utilizatori(email,parola,nume,prenume) values ('" + siruri[0] + "','" + siruri[1] + "','" + siruri[2] + "','" + siruri[3] + "')", con);
                cmd.ExecuteNonQuery();
                /* cmd.Parameters.AddWithValue("email", siruri[0].Trim());
                cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("parola", siruri[1].Trim());
                cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("nume", siruri[2].Trim());
                cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("prenume", siruri[3].Trim());
                cmd.ExecuteNonQuery();
                */
            }
            MessageBox.Show("bv");
            con.Close();

        }
        
        public static string[] sir = new string[100];
        public int i;
        void stringg()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open(); SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select email from Utilizatori", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sir[i] = dr.GetString(0);
                i++;
            }

        }
        void Formi()
        {
            stergere();
            initializare1();
            initializare2();
            initializare3();
            stringg();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Initializare realizata");
           //Formi();
        }
        public int id;
        
        void select()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select id_carte from Carti", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                id = dr.GetInt32(0);
            }
            cmd.Dispose();
            con.Close();
        }
        void initializare2()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            StreamReader sr = new StreamReader(Application.StartupPath + @"\..\..\carti.txt");
            StreamReader sr1 = new StreamReader(Application.StartupPath + @"\..\..\imprumuturi.txt");
            string sir;
            char[] split = { '*' };
            char[] split1 = { '*' };
            con.Open();

            while ((sir = sr.ReadLine()) != null)
            {
                string[] siruri = sir.Split(split);


                cmd = new SqlCommand("Insert into Carti(titlu,autor,gen) values ('" + siruri[0] + "','" + siruri[1] + "','" + siruri[2] + "')", con);
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("sdf");
            con.Close();
        }
        void initializare3()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            StreamReader sr1 = new StreamReader(Application.StartupPath + @"\..\..\imprumuturi.txt");
            string sir1;
            char[] split1 = { '*' };
            con.Open();

            while ((sir1 = sr1.ReadLine()) != null)
            {
                
                
                string[] siruri = sir1.Split(split1);
               // string d1 = DateTime(siruri[2]);
                //dt = Convert.ToDateTime(d1.Trim(), System.Globalization.CultureInfo.GetCultureInfo("fr-FR"));
                cmd = new SqlCommand("Select id_carte from carti where titlu=@nume", con);
            cmd.Parameters.AddWithValue("nume", siruri[0].Trim());
            int idcarte = Convert.ToInt32(cmd.ExecuteScalar());
                cmd = new SqlCommand("Insert into Imprumut(id_carte,email,data_imprumut) values ('" + idcarte + "','" + siruri[1] + "','" + siruri[2] + "')", con);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("sdfsss");
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Logare ss = new Logare();
            this.Hide();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inregistrare s = new Inregistrare();
            this.Hide();
            s.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
