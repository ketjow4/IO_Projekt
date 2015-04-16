using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IO_Projekt.Payments;

namespace IO_Projekt
{
    public partial class GlownaFormatka : Form
    {
        public GlownaFormatka()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Platnosci formatka = new Platnosci();
            formatka.Show();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Wypozyczenia formatka = new Wypozyczenia();
            formatka.Show();
        }
    }
}
