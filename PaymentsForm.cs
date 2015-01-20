using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IO_Projekt.Payments
{
    public partial class PaymentsForm : Form
    {
        public PaymentsForm()
        {
            InitializeComponent();
            LoadUsers();
        }


        public void LoadUsers(){

            var clients = from p in Config.context.czlonek 
                            select new
                            {
                                ID = p.id,
                                NAZW = p.klient.nazwisko
                                
                                
                            };

            

            comboBoxUser.DataSource = clients.ToList();
            comboBoxUser.DisplayMember = "NAZW";
            comboBoxUser.ValueMember = "ID";
            

        }
        public void LoadPaid()
        {

            var payments = from p in Config.context.platnosci
                           where (p.czlonek == comboBoxUser.SelectedValue)
                          select new
                          {
                              ID = p.id,
                              CENA = p.cena_koncowa,
                              TYP = p.typ_platnosci.nazwa



                          };


            if(payments != null)
            dgvPayments.DataSource = payments.ToList();


        }

        private void buttonPaid_Click(object sender, EventArgs e)
        {
            LoadPaid();
        }
    }
}
