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
    public partial class Wypozyczenia : Form
    {
        IOEntities context = Config.context;
        

        public Wypozyczenia()
        {
            InitializeComponent();
            //pobiera liste klientow z bazy dancyh
            var kilentLista = (from c in Config.context.klient select c).ToList();

            dataGridView1.DataSource = kilentLista;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            //pobiera liste samochodow z bazy danych
            var samochodLista = (from c in Config.context.samochod select c).ToList();
           
            dataGridView2.DataSource = samochodLista;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
        }

        private void wypozycz_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && dataGridView2.SelectedRows.Count == 1)
            {
                    var klient = dataGridView1.SelectedRows[0].DataBoundItem as klient;
                    var samochod = dataGridView2.SelectedRows[0].DataBoundItem as samochod;

                    var listaWypozyczonych = (from s in context.wypozyczenia where s.id_klienta == klient.id && s.data_oddania == null select s).ToList();

                    if (listaWypozyczonych.Count >= 1 && klient.czlonek.Count == 0)
                    {
                        MessageBox.Show("Zwykły klient może wypożyczyć tylko jeden samochód.",
                        "Nie można wypożyczyć",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (samochod.stan == "dostepny")
                    {
                        samochod.stan = "zablokowany";
                        wypozyczenia wyp = new wypozyczenia()
                        {
                            data_wypozyczenia = DateTime.Now,
                            id_klienta = klient.id,
                            id_samochodu = samochod.id,
                            klient = klient,
                            platnosci = null,
                            rezerwacja = 0,
                            samochod = samochod,
                            data_oddania = dateTimePicker1.Value,
                            id_pracownika = 1,
                            id = Config.context.samochod.OrderByDescending(s => s.id).FirstOrDefault().id + 1,
                            pracownik = (from p in Config.context.pracownik where p.id == 1 select p).FirstOrDefault()
                        };
                        context.wypozyczenia.Add(wyp);
                        context.SaveChanges();
                        dataGridView2.Refresh();
                    }
                    else if (samochod.stan == "zablokowany")
                    {
                        MessageBox.Show("Samochód " + samochod.marka + " " + samochod.model + " jest niedostępny.",
                        "Samochód niedostępny",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                        return ; 
                    }
            }
        }
    }
}
