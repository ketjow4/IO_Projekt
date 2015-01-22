﻿using System;
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
    public partial class Form1 : Form
    {
        IOEntities context = new IO_Projekt.IOEntities();
        

        public Form1()
        {
            InitializeComponent();


            //var kilentList = from c in context.klient.Include("czlonek").Include("wypozyczenia") select c;
            var kilentList = from c in Config.context.klient.Include("czlonek").Include("wypozyczenia") select c;
            var list = kilentList.ToList();

            //moj komentarz damian


            dataGridView1.DataSource = list;

            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[7].Visible = false;



            //dataGridView1.Columns.Add("Column", "czlonek");
            //dataGridView1.Columns[9].ValueType = typeof(String);
            //dataGridView1.Rows[1].Cells[9].Value = "jakisteskst";
            //dataGridView1.Refresh();

            //int i = 0;
            //foreach (var klient in kilentList)
            //{
            //    if (klient.czlonek != null) ;
            //    dataGridView1.Rows[2].Cells[9].Value = "jakis tekst";
            //    //i++;
            //}



            //var samochodList = (from c in context.samochod select c).ToList();
            var samochodList = (from c in Config.context.samochod select c).ToList();

            dataGridView2.DataSource = samochodList;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;


        }

        private void wypozycz_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && dataGridView2.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow temp in dataGridView1.SelectedRows)
                {
                    var klinet = temp.DataBoundItem as klient;
                    var temp2 = dataGridView2.SelectedRows;
                    var temp3 = temp2[0];
                    var samochod = temp3.DataBoundItem as samochod;


                    if (samochod.stan == "dostepny")
                    {
                        samochod.stan = "zablokowany";
                        wypozyczenia wyp = new wypozyczenia()
                        {
                            data_wypozyczenia = DateTime.Now,
                            id_klienta = klinet.id,
                            id_samochodu = samochod.id,
                            klient = klinet,
                            platnosci = null,
                            rezerwacja = 0,
                            samochod = samochod,
                            data_oddania = null,
                            id_pracownika = 1,
                            //id = context.samochod.OrderByDescending(s => s.id).FirstOrDefault().id + 1,
                            //pracownik = (from p in context.pracownik where p.id == 1 select p).FirstOrDefault()
                            id = Config.context.samochod.OrderByDescending(s => s.id).FirstOrDefault().id + 1,
                            pracownik = (from p in Config.context.pracownik where p.id == 1 select p).FirstOrDefault()
                        };
                        context.wypozyczenia.Add(wyp);
                        context.SaveChanges();
                        Config.context.wypozyczenia.Add(wyp);
                        Config.context.SaveChanges();

                        //dodać jakiegoś odświeżanie tabeli

                    }
                    else if (samochod.stan == "zablokowany")
                    {
                        MessageBox.Show("Samochód " + samochod.marka + " " + samochod.model + " jest niedostępny.",
                        "Samochód niedostępny",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    }

                }
            }
        }

        private void zaplac_Click(object sender, EventArgs e)
        {

        }
    }
}
