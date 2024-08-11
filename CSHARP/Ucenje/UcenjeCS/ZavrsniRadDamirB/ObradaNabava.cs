using Newtonsoft.Json;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class ObradaNabava
    {
        public List<Nabava> Nabave { get; set; }

        public ObradaNabava()
        {
            Nabave = new List<Nabava>();
        }

        private GlavniIzbornik Izbornik;

        public ObradaNabava(GlavniIzbornik IzbornikN) : this()
        {
            this.Izbornik = IzbornikN;
        }

        public void PrikaziGlavniIzbornikNabave()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("***************************** IZBORNIK ZA RAD S NABAVAMA ****************************");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("1. Pregled svih nabava");
            Console.WriteLine("2. Unos nove nabave");
            Console.WriteLine("3. Promjena podataka postojeće nabave");
            Console.WriteLine("4. Brisanje postojeće nabave");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            OdabirOpcijeIzbornikaNabave();
        }

        private void OdabirOpcijeIzbornikaNabave()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziNabave();
                    PrikaziGlavniIzbornikNabave();
                    break;
                case 2:
                    Console.Clear();
                    UnosNoveNabave();
                    PrikaziGlavniIzbornikNabave();
                    break;
                case 3:
                    Console.Clear();
                    PromjenaPodatakaNabave();
                    PrikaziGlavniIzbornikNabave();
                    break;
                case 4:
                    Console.Clear();
                    BrisanjeNabave();
                    PrikaziGlavniIzbornikNabave();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziNabave()
        {
            if (Nabave.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------- LISTA NABAVA PRAZNA --------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("*********************************** LISTA NABAVA ************************************");
                Console.WriteLine("-------------------------------------------------------------------------------------");

                int rbn = 0;
                foreach (var n in Nabave)
                {
                    n.NazivDobavljaca.Sort();
                    foreach (var d in n.NazivDobavljaca)
                    {
                        Console.WriteLine(++rbn + ". " + n.ToString());
                        Console.WriteLine("   " + d.ToString());
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        public void UnosNoveNabave()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("*************************** UNESITE TRAŽENE PODATKE NABAVE **************************");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            while (Zastita.UcitajBool("Dodaj novu nabavu? (DA/NE)", "da"))
            {
                Nabava n = new Nabava();
                while (Zastita.UcitajBool("Unesi novu šifru nabave? (DA/NE)", "da"))
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    int SifraNabave = Zastita.UcitajRasponBroja("Unesi šifru nabave", 1, int.MaxValue);
                    if (Nabave.Any(nabava => nabava.Sifra == SifraNabave))
                    {
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Nabava s tom šifrom već postoji. Unos šifre nabave nije moguć.");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        continue;
                    }
                    else
                    {
                        n.Sifra = SifraNabave;
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                    }
                    break;
                }
                while (Zastita.UcitajBool("Unesi novi broj nabave? (DA/NE)", "da"))
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    int BrojNabave = Zastita.UcitajRasponBroja("Unesi broj nabave", 1, int.MaxValue);
                    if (Nabave.Any(nabava => nabava.BrojNabave == BrojNabave))
                    {
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Nabava s tim brojem već postoji. Unos broja nabave nije moguć.");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        continue;
                    }
                    else
                    {
                        n.BrojNabave = BrojNabave;
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                    }
                    break;
                }
                n.DatumNabave = Zastita.UcitajDatum("Unesi datum nabave", true);
                Console.Clear();
                n.NazivDobavljaca = UcitajDobavljace();
                Nabave.Add(n);
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------- NOVA NABAVA UNESENA --------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                SpremiPodatkeNabava();
                break;
            }
        }

        private void PromjenaPodatakaNabave()
        {
            if (Nabave.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------- NEMA DOSTUPNIH NABAVA -------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            PrikaziNabave();
            while (Zastita.UcitajBool("Nastaviti na promijenu podataka nabava? (DA/NE)", "da"))
            {
                Console.Clear();
                PrikaziNabave();
                var odabrani = Nabave[Zastita.UcitajRasponBroja("Odaberi redni broj nabave za promjenu", 1, Nabave.Count) - 1];
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------- ODABRANA NABAVA ZA PROMJENU ----------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine(odabrani.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------------");
                while (Zastita.UcitajBool("Promijeni šifru nabave? (DA/NE)", "da"))
                {
                    int Sifra = Zastita.UcitajRasponBroja("Unesi novu šifru nabave", 1, int.MaxValue);
                    if (Nabave.Any(nabava => nabava.Sifra == Sifra))
                    {
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Nabava s tom šifrom već postoji. Unos šifre nabave nije moguć.");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine(odabrani.ToString());
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        continue;
                    }
                    else
                    {
                        odabrani.Sifra = Sifra;
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("----------------------------- ŠIFRA NABAVE PROMJENJENA ------------------------------");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine(odabrani.ToString());
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        SpremiPodatkeNabava();
                    }
                    break;
                }
                while (Zastita.UcitajBool("Promijeni broj nabave? (DA/NE)", "da"))
                {
                    int BrojNabave = Zastita.UcitajRasponBroja("Unesi novi broj nabave", 1, int.MaxValue);
                    if (Nabave.Any(nabava => nabava.BrojNabave == BrojNabave))
                    {
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Nabava s tim brojem već postoji. Unos broja nabave nije moguć.");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine(odabrani.ToString());
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        continue;
                    }
                    else
                    {
                        odabrani.BrojNabave = BrojNabave;
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("------------------------------ BROJ NABAVE PROMJENJEN -------------------------------");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine(odabrani.ToString());
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        SpremiPodatkeNabava();
                    }
                    break;
                }
                if (Zastita.UcitajBool("Promijeni datum nabave? (DA/NE)", "da"))
                {
                    odabrani.DatumNabave = Zastita.UcitajDatum("Unesi novi datum nabave", true);
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("----------------------------- DATUM NABAVE PROMJENJEN -------------------------------");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine(odabrani.ToString());
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    SpremiPodatkeNabava();
                }
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------- USPJEŠNA PROMJENA PODATAKA -----------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                SpremiPodatkeNabava();  
                break;
            }
            Console.Clear();
        }

        private void BrisanjeNabave()
        {
            if (Nabave.Count == 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------- NEMA DOSTUPNIH NABAVA -------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziNabave();
                var odabrani = Nabave[Zastita.UcitajRasponBroja("Odaberi redni broj nabave za brisanje", 1, Nabave.Count) - 1];
                Console.WriteLine("-------------------------------------------------------------------------------------");

                if (Zastita.UcitajBool("ŠIFRA NABAVE: " + odabrani.Sifra + " <----  OBRISATI NABAVU ?  ----> " + "(DA/NE)", "da"))
                {
                    Nabave.Remove(odabrani);
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("---------------------------------- NABAVA OBRISANA ----------------------------------");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                }
                SpremiPodatkeNabava();
            }
        }

        public List<Dobavljac> UcitajDobavljace()
        {
            List<Dobavljac> lista = new List<Dobavljac>();
            {
                Izbornik.ObradaDobavljac.PrikaziDobavljace();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                lista.Add(
                    Izbornik.ObradaDobavljac.Dobavljaci[
                    Zastita.UcitajRasponBroja("Odaberite redni broj dobavljača", 1,
                    Izbornik.ObradaDobavljac.Dobavljaci.Count) - 1
                    ]);
            }
            return lista;
        }

        private void SpremiPodatkeNabava()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Nabave.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(Nabave));
            outputFile.Close();
        }
    }
}
