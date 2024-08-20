using Newtonsoft.Json;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class ObradaStavka
    {
        public List<Stavka> Stavke { get; set; }

        private GlavniIzbornik IzbornikS;

        public ObradaStavka()
        {
            Stavke = new List<Stavka>();
        }

        public ObradaStavka(GlavniIzbornik IzbornikS) : this()
        {
            this.IzbornikS = IzbornikS;
        }

        public void PrikaziGlavniIzbornikStavke()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("***************************** IZBORNIK ZA RAD S STAVKAMA ****************************");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("1. Pregled stavki nabava");
            Console.WriteLine("2. Pregled stavki nabava detaljno");
            Console.WriteLine("3. Unos stavki");
            Console.WriteLine("4. Promjena podataka stavki");
            Console.WriteLine("5. Brisanje stavki");
            Console.WriteLine("6. Povratak na glavni izbornik");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            OdabirOpcijeIzbornikaStavke();
        }

        private void OdabirOpcijeIzbornikaStavke()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    Console.Clear();
                    PrikaziStavkeNabave2();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 2:
                    Console.Clear();
                    PrikaziStavkeNabave();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 3:
                    Console.Clear();
                    UnosStavke();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 4:
                    Console.Clear();
                    PromijeniPodatkeStavke();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 5:
                    Console.Clear();
                    BrisanjeStavke();
                    PrikaziGlavniIzbornikStavke();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziStavkeNabave()
        {
            if (Stavke.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------- LISTA STAVKI PRAZNA --------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("******************************* LISTA STAVKI NABAVA *********************************");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                int rb = 0;
                foreach (var s1 in Stavke)
                {
                    Console.WriteLine(++rb + ". " + s1.SifraNabave?.ToString());
                    foreach (var s2 in s1.SifraNabave.NazivDobavljaca)
                    {
                        Console.WriteLine("   " + s2.ToString());
                        Console.WriteLine("   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                        float Ukupno = (s1.KolicinaArtikla ?? 0) * (s1.CijenaArtikla ?? 0);
                        Console.WriteLine("   " + s1.SifraArtikla?.ToString() + " , " + s1.ToString() + " EUR" + " , " + "UKUPNO: " + Ukupno + " EUR");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        public void PrikaziStavkeNabave2()
        {
            if (Stavke.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------- LISTA STAVKI PRAZNA --------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("******************************* LISTA STAVKI NABAVA *********************************");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                int rb = 0;
                foreach (var StavkeNabave in Stavke)
                {
                    foreach (var NazivD in StavkeNabave.SifraNabave.NazivDobavljaca)
                    {
                        float Ukupno = (StavkeNabave.KolicinaArtikla ?? 0) * (StavkeNabave.CijenaArtikla ?? 0);
                        Console.WriteLine(++rb + ". " + "Š.Nabave: " + StavkeNabave.SifraNabave?.Sifra + " , " + "Br.Nabave: " + StavkeNabave.SifraNabave?.BrojNabave + " , " + NazivD.Naziv);
                        Console.WriteLine("   " + StavkeNabave.SifraArtikla?.Naziv + " , " + " Količina: " + StavkeNabave.KolicinaArtikla + " kom" + " , " + " Cijena: " + StavkeNabave.CijenaArtikla + "   " + " UKUPNO: " + Ukupno + " EUR");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        private void UnosStavke()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("********************************** RAD SA STAVKAMA **********************************");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            IzbornikS.ObradaNabava.PrikaziNabave();
            var SifraNabave = IzbornikS.ObradaNabava.Nabave[Zastita.UcitajRasponBroja("Odaberi redni broj nabave", 1, IzbornikS.ObradaNabava.Nabave.Count) - 1];
            Console.WriteLine("-------------------------------------------------------------------------------------");
            while (Zastita.UcitajBool2("Dodaj novu stavku? (DA/NE)"))
            {
                Console.Clear();
                Stavka Stavka = new Stavka
                {
                    SifraNabave = SifraNabave
                };
                IzbornikS.ObradaArtikl.PrikaziArtikle();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Stavka.SifraArtikla = IzbornikS.ObradaArtikl.Artikli[Zastita.UcitajRasponBroja("Odaberi redni broj artikla", 1, IzbornikS.ObradaArtikl.Artikli.Count) - 1];
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Stavka.KolicinaArtikla = Zastita.UcitajRasponBroja("Unesi količinu artikla", 1, int.MaxValue);
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Stavka.CijenaArtikla = Zastita.UcitajDecimalniBroj("Unesi cijenu artikla (0,00)", 0, 10000);
                
                Stavke.Add(Stavka);

                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------- NOVA STAVKA UNESENA ---------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                SpremiPodatkeStavke();
            }
        }

        private void PromijeniPodatkeStavke()
        {
            if (Stavke.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------- NEMA DOSTUPNIH STAVKI -------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziStavkeNabave2();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                var odabrani = Stavke[Zastita.UcitajRasponBroja("Odaberi Rb. stavke za promjenu", 1, Stavke.Count) - 1];
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------- ODABRANA STAVKA ZA PROMJENU ----------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("ARTIKL: " + odabrani.SifraArtikla?.Naziv);
                float Ukupno = (odabrani.KolicinaArtikla ?? 0) * (odabrani.CijenaArtikla ?? 0);
                Console.WriteLine("KOLIČINA: " + odabrani.KolicinaArtikla + " KOM" + " , " + "CIJENA: " + odabrani.CijenaArtikla + " EUR" + " , " + "UKUPNO: " + Ukupno + " EUR");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                if (Zastita.UcitajBool2("Promijeni količinu artikla? (DA/NE)"))
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    odabrani.KolicinaArtikla = Zastita.UcitajRasponBroja("Unesi novu količinu artikla", 1, int.MaxValue);
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("--------------------------- KOLIČINA ARTIKLA PROMIJENJENA ---------------------------");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("ARTIKL: " + odabrani.SifraArtikla?.Naziv);
                    float Ukupno2 = (odabrani.KolicinaArtikla ?? 0) * (odabrani.CijenaArtikla ?? 0);
                    Console.WriteLine("KOLIČINA: " + odabrani.KolicinaArtikla + " KOM" + " , " + "CIJENA: " + odabrani.CijenaArtikla + " EUR" + " , " + "UKUPNO: " + Ukupno2 + " EUR");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    SpremiPodatkeStavke();
                }
                if (Zastita.UcitajBool2("Promijeni cijenu artikla? (DA/NE)"))
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    odabrani.CijenaArtikla = Zastita.UcitajDecimalniBroj("Unesi novu cijenu artikla (0,00)", 1, 10000);
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("---------------------------- CIJENA ARTIKLA PROMIJENJENA ----------------------------");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("ARTIKL: " + odabrani.SifraArtikla?.Naziv);
                    float Ukupno3 = (odabrani.KolicinaArtikla ?? 0) * (odabrani.CijenaArtikla ?? 0);
                    Console.WriteLine("KOLIČINA: " + odabrani.KolicinaArtikla + " KOM" + " , " + "CIJENA: " + odabrani.CijenaArtikla + " EUR" + " , " + "UKUPNO: " + Ukupno3 + " EUR");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    SpremiPodatkeStavke();
                }
                Console.WriteLine("-------------------------------------------------------------------------------------");
                if (Zastita.UcitajBool2("Nastaviti s promjenom podataka? (DA/NE)"))
                {
                    Console.Clear();
                    PromijeniPodatkeStavke();
                }
                Console.Clear();
                SpremiPodatkeStavke();
            }
        }

        private void BrisanjeStavke()
        {
            if (Stavke.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------- NEMA DOSTUPNIH STAVKI -------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziStavkeNabave2();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                var odabrani = Stavke[Zastita.UcitajRasponBroja("Odaberi redni broj stavke za brisanje", 1, Stavke.Count) - 1];
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------- ODABRANA STAVKA ZA BRISANJE ----------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine(" *** " +"Š.N. " + odabrani.SifraNabave.Sifra + " ARTIKL: " + odabrani.SifraArtikla.Naziv + " KOLIČINA: " + odabrani.KolicinaArtikla + " KOM " + " CIJENA: " +odabrani.CijenaArtikla + " EUR" + " *** ");
                Console.WriteLine("-------------------------------------------------------------------------------------");

                if (Zastita.UcitajBool2("<------------------------- OBRISATI STAVKU ?  -------------------------> (DA/NE)"))
                {
                    Stavke.Remove(odabrani);
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("---------------------------------- STAVKA OBRISANA ----------------------------------");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    SpremiPodatkeStavke();
                }
                Console.WriteLine("-------------------------------------------------------------------------------------");
                if (Zastita.UcitajBool2("Nastaviti s brisanjem stavki? (DA/NE)"))
                {
                    Console.Clear();
                    BrisanjeStavke();
                }
                Console.Clear();
            }
        }

        private void SpremiPodatkeStavke()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderName = "DamirBazaPodataka";

            string fullFolderPath = Path.Combine(docPath, folderName);
            string filePath = Path.Combine(fullFolderPath, "Stavke.json");
            using StreamWriter outputFile = new StreamWriter(filePath);
            outputFile.WriteLine(JsonConvert.SerializeObject(Stavke));
            outputFile.Close();
        }
    }
}
