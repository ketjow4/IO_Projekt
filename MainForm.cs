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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentsForm formatka = new PaymentsForm();
            formatka.Show();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Form1 formatka = new Form1();
            formatka.Show();
        }
    }
}
