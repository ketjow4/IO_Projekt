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
            var wyp = from w in DatabaseContext.getContext().wypozyczenia where w.id_klienta == do_zaplaty.id select w;
            bool nowozency = Nowozency.Checked;
            bool promocja = Promocja.Checked;

            if (dataGridView2.SelectedRows.Count == 1)
            {
                var temp = dataGridView2.SelectedRows;
                var temp2 = temp[0];
                var wypozyczenie = temp2.DataBoundItem as wypozyczenia;
                TimeSpan? dni = (wypozyczenie.data_oddania - wypozyczenie.data_wypozyczenia);
                int cena = dni.Value.Days * wypozyczenie.samochod.kwota;                        //uwaga tutaj na nulla
                int upust = 0;
               
                var znizka = (from z in DatabaseContext.getContext().znizki select z).ToList();
                var c = DatabaseContext.getContext();
                
                System.DateTime dat = (from cz in c.czlonek where cz.id_klienta == do_zaplaty.id && cz.typ_czlonkowstwa == 1 select cz).FirstOrDefault().data_przystapienia;

                var ile_czasu_czlonek = System.DateTime.Now - dat;  //info ile lat ktoś jest członkiem

                foreach (var z in znizka)
                {
                    if (z.lacznosc == 1)
                    {
                        if (z.opis == "liczba_wypozyczen>5" && wyp.Count() > 5) { upust += z.procent * cena + z.kwota; }
                        if (z.opis == "promocja dla nowozencow" && nowozency) { upust += z.kwota; }
                        if (z.opis == "za 2 lata bycia czlonkiem standard" && do_zaplaty.czlonek.Count == 1 &&
                           (from cz in c.czlonek where cz.id_klienta == do_zaplaty.id && cz.typ_czlonkowstwa == 1 select cz).Any()
                               ) { upust += z.procent * cena + z.kwota; }   //tutaj jeszcze trzeba dodać ten czas !!!!
                        
                    }
                }

                int upust2 = 0;
                foreach (var z in znizka)
                {
                    if (z.opis == "liczba_wypozyczen=10" && wyp.Count() == 10) { upust2 = z.procent * cena; }
                    if (z.opis == "liczba_wypozyczen=50" && wyp.Count() == 50) { upust2 = z.procent * cena; }
                }
                //tutaj zadbać o resztę zniżek

                //tutaj jakiś show messagebox z informacjami na temat płatności
                platnosci pl = new platnosci()
                {
                  cena_koncowa = cena - upust, data_realizacji = System.DateTime.Now,  typ_platnosc = 1, /*sprawdzić czy to jest dobre*/
                  id_wypozyczenia = wypozyczenie.id, wypozyczenia = wypozyczenie, id_czlonka = do_zaplaty.czlonek.FirstOrDefault().id,
                  czlonek = do_zaplaty.czlonek.FirstOrDefault() //tutaj jeszcze trzeba będzie coś uzupełnić 

                };
            }
            this.Hide();
            this.Close();
            Form1 f1 = new Form1(); //poprawić to !!!!
            f1.Show();
        }
    }
}
