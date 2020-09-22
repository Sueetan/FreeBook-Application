using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieFreeBook
{
    public partial class AfiseazaCarte : Form
    {
        public AfiseazaCarte()
        {
            InitializeComponent();
        }

        private void AfiseazaCarte_Load(object sender, EventArgs e)
        {
            label1.Text = "" + Meniu.carte;
            label3.Text = "" + Meniu.autor;

        }
    }
}
