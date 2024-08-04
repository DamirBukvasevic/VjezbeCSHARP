using Newtonsoft.Json;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class ObradaArtikl
    {
        public List<Artikl> Artikli { get; set; }

        public ObradaArtikl()
        {
            Artikli = new List<Artikl>();
        }

        private GlavniIzbornik IzbornikA;

        public ObradaArtikl(GlavniIzbornik IzbornikA) : this()
        {
            this.IzbornikA = IzbornikA;
        }

        public void PrikaziGlavniIzbornikArtikli()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("******************* IZBORNIK ZA RAD S ARTIKLIMA *****************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Pregled svih artikala");
            Console.WriteLine("2. Unos novog artikla");
            Console.WriteLine("3. Promjena podataka postojećeg artikla");
            Console.WriteLine("4. Brisanje postojećeg artikla");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornikaArtikla();
        }

        private void OdabirOpcijeIzbornikaArtikla()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziArtikle();
                    PrikaziGlavniIzbornikArtikli();
                    break;
                case 2:
                    Console.Clear();
                    UnosNovogArtikla();
                    PrikaziGlavniIzbornikArtikli();
                    break;
                case 3:
                    Console.Clear();
                    PromjeniPodatkeArtikla();
                    PrikaziGlavniIzbornikArtikli();
                    break;
                case 4:
                    Console.Clear();
                    ObrisiArtikl();
                    PrikaziGlavniIzbornikArtikli();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziArtikle()
        {
            if (Artikli.Count == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("--------------------- LISTA ARTIKALA PRAZNA ---------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("************************ LISTA ARTIKALA *************************");
                Console.WriteLine("-----------------------------------------------------------------");

                int rb = 0;
                foreach (var a in Artikli)
                {
                    Console.WriteLine(++rb + ". " + a.ToString());
                }
            }
        }

        private void UnosNovogArtikla()
        {
            PrikaziArtikle();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("**************** UNESITE TRAŽENE PODATKE ARTIKLA ****************");
            Console.WriteLine("-----------------------------------------------------------------");
            while (Zastita.UcitajBool("Unesi novi artikl? (DA/NE)", "da"))
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Artikli.Add(new()
                {
                    Sifra = Zastita.UcitajRasponBroja("Unesi šifru artikla", 1, int.MaxValue),
                    Naziv = Zastita.UcitajString("Unesi naziv artikla", 50, true)
                });
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("---------------------- NOVI ARTIKL UNESEN -----------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                SpremiPodatkeArtikli();
            }
            Console.Clear();
        }

        private void PromjeniPodatkeArtikla()
        {
            if (Artikli.Count == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("-------------------- NEMA DOSTUPNIH ARTIKALA --------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziArtikle();
                Console.WriteLine("-----------------------------------------------------------------");
                var odabrani = Artikli[Zastita.UcitajRasponBroja("Unesi Rb. artikla za promjenu", 1, Artikli.Count) - 1];
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("----------------- ODABRANI ARTIKL ZA PROMJENU -------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\t" + odabrani.ToString());
                Console.WriteLine("-----------------------------------------------------------------");
                if (Zastita.UcitajBool("Promijeni šifru artikla? (DA/NE)", "da"))
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    odabrani.Sifra = Zastita.UcitajRasponBroja("Unesi novu šifru artikla", 1, int.MaxValue);
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("------------------- ŠIFRA ARTIKLA PROMJENJENA -------------------");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\t" + odabrani.ToString());
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                if (Zastita.UcitajBool("Promijeni naziv artikla? (DA/NE)", "da"))
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    odabrani.Naziv = Zastita.UcitajString("Unesi novi naziv artikla", 50, true);
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("------------------- NAZIV ARTIKLA PROMJENJEN --------------------");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\t" + odabrani.ToString());
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                Console.WriteLine("-----------------------------------------------------------------");
                if (Zastita.UcitajBool("Nastaviti s promjenom podataka? (DA/NE)", "da"))
                {
                    Console.Clear();
                    PromjeniPodatkeArtikla();
                }
                SpremiPodatkeArtikli();
                Console.Clear();
            }
        }

        private void ObrisiArtikl()
        {
            if (Artikli.Count == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("-------------------- NEMA DOSTUPNIH ARTIKALA --------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziArtikle();
                Console.WriteLine("-----------------------------------------------------------------");
                var odabrani = Artikli[Zastita.UcitajRasponBroja("Odaberi Rb. artikla za brisanje", 1, Artikli.Count) - 1];
                Console.WriteLine("-----------------------------------------------------------------");

                if (Zastita.UcitajBool(odabrani.Naziv + " ---- OBRISATI ARTIKL ---- " + "? (DA/NE)", "da"))
                {
                    Artikli.Remove(odabrani);
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("------------------------ ARTIKL OBRISAN -------------------------");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                SpremiPodatkeArtikli();
            }
        }

        private void SpremiPodatkeArtikli()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Artikli.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(Artikli));
            outputFile.Close();
        }
    }
}
