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
    public partial class Platnosci : Form
    {
        public Platnosci()
        {
            InitializeComponent();
            LadujUzytkownikow();
        }


        public void LadujUzytkownikow()
        {
            var clients = from p in Config.context.klient
                          select new
                          {
                              ID = p.id,
                              NAZW = p.nazwisko
                          };
            comboBoxUzytkownik.DataSource = clients.ToList();
            comboBoxUzytkownik.DisplayMember = "NAZW";
            comboBoxUzytkownik.ValueMember = "ID";
        }


        public void LadujNiezaplacone()
        {
            btnZaplac.Enabled = true;

            var platnosci = from p in Config.context.wypozyczenia
                           where (p.id_klienta == (int)comboBoxUzytkownik.SelectedValue && p.platnosci.Count == 0)
                           select p;

            var lista = platnosci.ToList();
            if (platnosci != null)
                dgvPlatnosci.DataSource = platnosci.ToList();

            dgvPlatnosci.Columns[0].Visible = false;
            dgvPlatnosci.Columns[10].Visible = false;
            dgvPlatnosci.Columns[7].Visible = false;
            dgvPlatnosci.Columns[8].Visible = false;
            dgvPlatnosci.Columns[9].Visible = false;
        }


        public void LadujZaplacone()
        {
            btnZaplac.Enabled = false;

            var platnosci = from p in Config.context.platnosci
                            where (p.wypozyczenia.id_klienta == (int)comboBoxUzytkownik.SelectedValue)
                            select p;

            var lista = platnosci.ToList();
            if (platnosci != null)
                dgvPlatnosci.DataSource = platnosci.ToList();

            dgvPlatnosci.Columns[0].Visible = false;
            dgvPlatnosci.Columns[1].Visible = false;
            dgvPlatnosci.Columns[2].Visible = false;
            dgvPlatnosci.Columns[3].Visible = false;
            dgvPlatnosci.Columns[4].Visible = false;
            dgvPlatnosci.Columns[7].Visible = false;
            dgvPlatnosci.Columns[8].Visible = false;
            dgvPlatnosci.Columns[9].Visible = false;
            dgvPlatnosci.Columns[10].Visible = false;
            dgvPlatnosci.Columns[11].Visible = false;

            dgvPlatnosci.Columns[5].HeaderText = "Kwota";
            dgvPlatnosci.Columns[6].HeaderText = "Data zapłaty";
            dgvPlatnosci.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonZaplacone_Click(object sender, EventArgs e)
        {
            LadujZaplacone();
        }


        private void dgvPlatnosci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPlatnosci.Columns["btn"].Index)
            {
                labelUzytkownik.Text = e.RowIndex.ToString();
            }
        }

        private void btnZaplac_Click(object sender, EventArgs e)
        {
            if (dgvPlatnosci.SelectedRows.Count == 1)
            {
                var klient = (from k in Config.context.klient where k.id == (int)comboBoxUzytkownik.SelectedValue select k).FirstOrDefault();
                var wypozyczenie = dgvPlatnosci.SelectedRows[0].DataBoundItem as wypozyczenia;

                TimeSpan? dni = (wypozyczenie.data_oddania - wypozyczenie.data_wypozyczenia);
                int cena = dni.Value.Days * wypozyczenie.samochod.kwota;                        //nie moze byc null w bazie
                int upust = 0;
                System.DateTime dat2 = DateTime.Now;
                var znizka = (from z in Config.context.znizki select z).ToList();
                var c = Config.context;
                var czy_czlonek = (from cz in c.czlonek where cz.id_klienta == klient.id select cz).FirstOrDefault();
                if (czy_czlonek != null)
                    dat2 = czy_czlonek.data_przystapienia;

                var ile_czasu_czlonek = System.DateTime.Now - dat2;  //info ile lat ktoś jest członkiem
                int lata = ile_czasu_czlonek.Days / 365;

                var wyp = from w in c.wypozyczenia where w.id_klienta == klient.id select w;    //wszystkie wypozyczenia od klienta

                foreach (var z in znizka)
                {
                    if (z.lacznosc == 1)
                    {

                        if (z.opis == "promocja dla nowozencow" && nowozency.Checked) { upust += (int)(z.kwota + z.procent * 0.01 * cena); }
                        if (z.opis == "swiateczna promocja" && promocjaSwiateczna.Checked) { upust += (int)(z.kwota + z.procent * 0.01 * cena); }
                        if (z.opis == "za 2 lata bycia czlonkiem standard" && klient.czlonek.Count == 1 &&
                           (from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 1 select cz).Any() && lata >= 2 && lata <= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }

                        if (z.opis == "za 4 lata bycia czlonkiem standard" && klient.czlonek.Count == 1 &&
(from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 1 select cz).Any() && lata >= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }

                        if (z.opis == "za 2 lata bycia czlonkiem silver" && klient.czlonek.Count == 1 &&
                       (from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 2 select cz).Any() && lata >= 2 && lata <= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }

                        if (z.opis == "za 4 lata bycia czlonkiem silver" && klient.czlonek.Count == 1 &&
(from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 2 select cz).Any() && lata >= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }

                        if (z.opis == "za 2 lata bycia czlonkiem gold" && klient.czlonek.Count == 1 &&
                    (from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 3 select cz).Any() && lata >= 2 && lata <= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }

                        if (z.opis == "za 4 lata bycia czlonkiem gold" && klient.czlonek.Count == 1 &&
(from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 3 select cz).Any() && lata >= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }


                        if (z.opis == "za 2 lata bycia czlonkiem premium" && klient.czlonek.Count == 1 &&
                 (from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 4 select cz).Any() && lata >= 2 && lata <= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }

                        if (z.opis == "za 4 lata bycia czlonkiem premium" && klient.czlonek.Count == 1 &&
(from cz in c.czlonek where cz.id_klienta == klient.id && cz.typ_czlonkowstwa == 4 select cz).Any() && lata >= 4)
                        {
                            upust += (int)(z.kwota + z.procent * 0.01 * cena);
                        }
                    }
                }
                int upust2 = 0;
                foreach (var z in znizka)
                {
                    if (z.opis == "liczba_wypozyczen>5" && wyp.Count() > 5)
                    {
                        int pomoc = (int)(z.kwota + z.procent * 0.01 * cena);
                        if (pomoc > upust2)
                            upust2 = pomoc;
                    }
                    if (z.opis == "liczba_wypozyczen=10" && wyp.Count() == 10)
                    {

                        int pomoc = (int)(z.kwota + z.procent * 0.01 * cena);
                        if (pomoc > upust2)
                            upust2 = pomoc;
                    }
                    if (z.opis == "liczba_wypozyczen=50" && wyp.Count() == 50)
                    {

                        int pomoc = (int)(z.kwota + z.procent * 0.01 * cena);
                        if (pomoc > upust2)
                            upust2 = pomoc;
                    }
                }

                if (upust2 > upust) upust = upust2; //liczymy upust na korzysc klienta


                platnosci pl = new platnosci()
                {
                    cena_koncowa = cena - upust,
                    data_realizacji = System.DateTime.Now,
                    typ_platnosc = 1,
                    id_wypozyczenia = wypozyczenie.id,
                    //wypozyczenia = wypozyczenie,   
                    //czlonek = klient.czlonek.FirstOrDefault(),
                    id_czlonka = null, //klient.czlonek.FirstOrDefault().id,
                    id = Config.context.platnosci.OrderByDescending(p => p.id).FirstOrDefault().id + 1,
                    //typ_platnosci = null
                    id_znizki_platnosci = null,
                };
                c.platnosci.Add(pl);
                c.SaveChanges();
            }
        }

        private void buttonNiezaplacone_Click(object sender, EventArgs e)
        {
            LadujNiezaplacone();
        }
    }
}
