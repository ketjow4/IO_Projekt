using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IO_Projekt
{
    public partial class Form2 : Form
    {
        public klient do_zaplaty;

        public Form2()
        {
            InitializeComponent();     
        }

        public void Create()
        {
            dataGridView1.DataSource = (from k in DatabaseContext.getContext().klient where k.id == do_zaplaty.id select k).ToList();
            var wyp = from w in DatabaseContext.getContext().wypozyczenia where w.id_klienta == do_zaplaty.id select w;     //pokombinować z datą oddania
            dataGridView2.DataSource = wyp.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tutaj wstawić kod ktory będzie odpowiedzialny za wyliczenie płatności i wpisanie jej do bazy

            this.Hide();
            this.Close();
            Form1 f1 = new Form1(); //poprawić to !!!!
            f1.Show();
        }
    }
}
