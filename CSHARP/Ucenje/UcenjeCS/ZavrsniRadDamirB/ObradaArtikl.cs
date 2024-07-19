

using UcenjeCS.E18KonzolnaAplikacija;
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

        private void ObrisiArtikl()
        {
            PrikaziArtikle();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Artikli[Zastita.UcitajRasponBroja("Odaberi redni broj artikla za brisanje", 1, Artikli.Count) - 1];
            Console.WriteLine("-----------------------------------------------------------------");

            if (Zastita.UcitajBool(odabrani.NazivArtikla + " ---- OBRISATI ARTIKL ---- " + "? (DA/NE)", "da"))
            {
                Artikli.Remove(odabrani);
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("------------------------ ARTIKL OBRISAN -------------------------");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        private void PromjeniPodatkeArtikla()
        {
            PrikaziArtikle();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Artikli[Zastita.UcitajRasponBroja("Odaberi redni broj artikla za promjenu", 1, Artikli.Count) - 1];

            odabrani.Sifra = Zastita.UcitajRasponBroja("Unesi šifru artikla", 1, int.MaxValue);
            odabrani.NazivArtikla = Zastita.UcitajString("Unesi naziv artikla", 50, true);
            odabrani.Cijena = Zastita.UcitajDecimalniBroj("Unesi cijenu artikla", 0, 10000);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("------------------ USPJEŠNA PROMJENA PODATAKA -------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private void UnosNovogArtikla()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("**************** UNESITE TRAŽENE PODATKE ARTIKLA ****************");
            Console.WriteLine("-----------------------------------------------------------------");
            Artikli.Add(new()
            {
                Sifra = Zastita.UcitajRasponBroja("Unesi šifru artikla", 1, int.MaxValue),
                NazivArtikla = Zastita.UcitajString("Unesi naziv artikla", 50, true),
                Cijena = Zastita.UcitajDecimalniBroj("Unesi cijenu artikla", 0, 10000)
            });
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("---------------------- NOVI ARTIKL UNESEN -----------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private void PrikaziArtikle()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("************************ LISTA ARTIKALA *************************");
            Console.WriteLine("-----------------------------------------------------------------");
            int rb = 0;
            foreach (var a in Artikli)
            {
                Console.WriteLine(++rb + ". " + "Šifra: " + a.Sifra + " , " + a.NazivArtikla + " " + a.Cijena + " EUR");
            }
        }
    }
}
