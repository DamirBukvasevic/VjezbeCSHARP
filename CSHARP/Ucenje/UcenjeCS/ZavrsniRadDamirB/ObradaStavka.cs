using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class ObradaStavka
    {
        public List<Stavka> Stavke { get; set; }

        public GlavniIzbornik IzbornikS;

        public ObradaStavka()
        {
            Stavke = new List<Stavka>();
        }

        public ObradaStavka(GlavniIzbornik IzbornikS): this()
        {
            this.IzbornikS = IzbornikS;
        }

        public void PrikaziGlavniIzbornikStavke()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("******************* IZBORNIK ZA RAD S STAVKAMA ******************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Pregled stavki detaljno");
            Console.WriteLine("2. Rad sa nabavama");
            Console.WriteLine("3. Rad sa artiklima");
            Console.WriteLine("4. Brisanje postojeće stavke");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornikaStavke();
        }

        private void OdabirOpcijeIzbornikaStavke()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziStavkeNabave();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 2:
                    Console.Clear();
                    PrikaziGlavniIzbornikStavkeNabave();
                    break;
                case 3:
                    Console.Clear();
                    PrikaziGlavniIzbornikStavkeArtikli();
                    break;
                case 4:
                    Console.Clear();
                    //BrisanjeStavki();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziGlavniIzbornikStavkeNabave()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("*************** IZBORNIK ZA RAD S STAVKAMA NABAVE ***************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Unos stavke nabave");
            Console.WriteLine("2. Brisanje stavke nabave");
            Console.WriteLine("3. Povratak na izbornik stavke");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornikaStavkeNabave();
        }

        private void OdabirOpcijeIzbornikaStavkeNabave()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 3))
            {
                case 1:
                    Console.Clear();
                    UnosStavki();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 2:
                    Console.Clear();
                    BrisanjeStavkeNabave();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 3:
                    Console.Clear();
                    PrikaziGlavniIzbornikStavke();
                    break;
            }
        }

        public void PrikaziStavkeNabave()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("************************** LISTA STAVKI NABAVA ****************************");
            Console.WriteLine("---------------------------------------------------------------------------");
            int rb = 0, rba = 0;
            foreach (var s1 in Stavke)
            {
                foreach (var s2 in s1.SifraNabave)
                {
                    Console.Write(++rb + ". " + "Broj nabave: " + s2.BrojNabave + " " + "Datum: " + s2.DatumNabave);
                    foreach (var s3 in s2.NazivDobavljaca)
                    {
                        Console.WriteLine(" " + s3.Naziv);
                    }
                }
            }
                Console.WriteLine("---------------------------------------------------------------------------");
                var odabrani = Stavke[Zastita.UcitajRasponBroja("Odaberi redni broj stavke za detaljan prikaz", 1, Stavke.Count) - 1];
                Console.Clear();

                foreach (var s2 in odabrani.SifraNabave)
                {
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.Write("Broj nabave: " + s2.BrojNabave + " " + "Datum: " + s2.DatumNabave);
                    foreach (var s3 in s2.NazivDobavljaca)
                    {
                        Console.WriteLine(" " + s3.Naziv);
                        Console.WriteLine("---------------------------------------------------------------------------");
                    }
                    foreach (var a1 in odabrani.SifraArtikla)
                    {
                        Console.WriteLine("\t" + ++rba + ". " + a1.Naziv);
                    }
                }  
        }

        private void UnosStavki()
        {
            Stavka stavka = new Stavka();

            stavka.SifraNabave = UcitajNabave();
            stavka.SifraArtikla = UcitajArtikle();

            Stavke.Add(stavka);
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("------------------ NOVE STAVKE NABAVE UNESENE -------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public void UnosStavkeArtikli()
        {
            
        }
        private void BrisanjeStavkeNabave()
        {
            PrikaziStavkeNabave();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Stavke[Zastita.UcitajRasponBroja("Odaberi redni broj nabave za brisanje", 1, Stavke.Count) - 1];
            Console.WriteLine("-----------------------------------------------------------------");

            if (Zastita.UcitajBool("-------------- OBRISATI NABAVU -------------- " + "? (DA/NE)", "da"))
            {
                Stavke.Remove(odabrani);
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("-------------------- STAVKA NABAVE OBRISANA ---------------------");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }
        private void PrikaziGlavniIzbornikStavkeArtikli()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("****************** IZBORNIK ZA RAD SA ARTIKLIMA *****************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Unos kolicine i cijene");
            Console.WriteLine("2. Izmjena podataka u nabavi");
            Console.WriteLine("3. Brisanje podataka u nabavi");
            Console.WriteLine("4. Povratak na izbornik stavke");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornikaStavkeArtikli();
        }

        private void OdabirOpcijeIzbornikaStavkeArtikli()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 4))
            {
                case 1:
                    Console.Clear();
                    UnosStavkeArtikli();
                    break;
                case 2:
                    

                    break;
                case 3:

                    break;
                case 4:

                    break;

            }
        }

        public List<Artikl> UcitajArtikle()
        {
            List<Artikl> listaA = new List<Artikl>();
            Console.WriteLine("-----------------------------------------------------------------");
            while (Zastita.UcitajBool("Dodaj artikl? (DA/NE)", "da"))
                {
                    Console.Clear();
                    IzbornikS.ObradaArtikl.PrikaziArtikle();
                    Console.WriteLine("-----------------------------------------------------------------");
                    listaA.Add(
                    IzbornikS.ObradaArtikl.Artikli[
                    Zastita.UcitajRasponBroja("Odaberite Rb. artika: ", 1,
                    IzbornikS.ObradaArtikl.Artikli.Count) - 1
                    ]);
                }
            return listaA;
        }
        public List<Nabava> UcitajNabave()
        {
            List<Nabava> listaN = new List<Nabava>();
            IzbornikS.ObradaNabava.PrikaziNabave();
            Console.WriteLine("-----------------------------------------------------------------");
            listaN.Add(
                    IzbornikS.ObradaNabava.Nabave[
                    Zastita.UcitajRasponBroja("Odaberi Rb. nabave za unos", 1,
                    IzbornikS.ObradaNabava.Nabave.Count) - 1
                    ]);
            return listaN;
        }
        public List<Stavka>UcitajStavkuNabave()
        {
            List<Stavka> listaS = new List<Stavka>();
            IzbornikS.ObradaStavka.PrikaziStavkeNabave();
            listaS.Add(
                IzbornikS.ObradaStavka.Stavke[
                Zastita.UcitajRasponBroja("Odaberi redni broj stavke nabave",1,
                IzbornikS.ObradaStavka.Stavke.Count) - 1    
                ]);
            return listaS;
        }
    }
}
