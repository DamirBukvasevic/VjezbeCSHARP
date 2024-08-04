using Newtonsoft.Json;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class ObradaDobavljac
    {
        public List<Dobavljac> Dobavljaci { get; set; }

        public ObradaDobavljac()
        {
            Dobavljaci = new List<Dobavljac>();
        }

        public void PrikaziGlavniIzbornikDobavljac()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("********************** IZBORNIK ZA RAD S DOBAVLJAČIMA *********************");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("1. Pregled svih dobavljača");
            Console.WriteLine("2. Unos novog dobavljača");
            Console.WriteLine("3. Promjena podataka postojećeg dobavljača");
            Console.WriteLine("4. Brisanje postojećeg dobavljača");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("---------------------------------------------------------------------------");
            OdabirOpcijeIzbornikaDobavljaca();
        }

        private void OdabirOpcijeIzbornikaDobavljaca()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziDobavljace();
                    PrikaziGlavniIzbornikDobavljac();
                    break;
                case 2:
                    Console.Clear();
                    UnosNovogDobavljaca();
                    PrikaziGlavniIzbornikDobavljac();
                    break;
                case 3:
                    Console.Clear();
                    PromjeniPodatkeDobavljaca();
                    PrikaziGlavniIzbornikDobavljac();
                    break;
                case 4:
                    Console.Clear();
                    ObrisiDobavljaca();
                    PrikaziGlavniIzbornikDobavljac();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziDobavljace()
        {
            if (Dobavljaci.Count == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("------------------- LISTA DOBAVLJAČA PRAZNA ---------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("**************************** LISTA DOBAVLJAČA *****************************");
                Console.WriteLine("---------------------------------------------------------------------------");
                int rb = 0;
                foreach (var d in Dobavljaci)
                {
                    Console.WriteLine(++rb + ". " + d.ToString());
                }
            }
        }

        private void UnosNovogDobavljaca()
        {
            PrikaziDobavljace();
            Console.WriteLine("---------------------------------------------------------------------------");
            while (Zastita.UcitajBool("Unesi novog dobavljača? (DA/NE)", "da"))
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("******************** UNESITE TRAŽENE PODATKE DOBAVLJAČA *******************");
                Console.WriteLine("---------------------------------------------------------------------------");
                Dobavljaci.Add(new()
                {
                    Sifra = Zastita.UcitajRasponBroja("Unesi šifru dobavljača", 1, int.MaxValue),
                    Naziv = Zastita.UcitajString("Unesi naziv dobavljača", 50, true),
                    Grad = Zastita.UcitajString("Unesi grad dobavljača", 50, true),
                    Adresa = Zastita.UcitajString("Unesi adresu dobavljača", 50, true),
                    OIB = Zastita.UcitajString("Unesi OIB dobavljača", 11, true)
                });
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("-------------------------- NOVI DOBAVLJAČ UNESEN --------------------------");
                Console.WriteLine("---------------------------------------------------------------------------");
                SpremiPodatkeDobavljaci();
            }
            Console.Clear();
        }

        private void PromjeniPodatkeDobavljaca()
        {
            if (Dobavljaci.Count == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("------------------- NEMA DOSTUPNIH DOBAVLJAČA--------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziDobavljace();
                Console.WriteLine("---------------------------------------------------------------------------");
                var odabrani = Dobavljaci[Zastita.UcitajRasponBroja("Odaberi Rb. dobavljača za promjenu", 1, Dobavljaci.Count) - 1];
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("--------------------- ODABRANI DOBAVLJAČ ZA PROMJENU ----------------------");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine(odabrani.ToString());
                Console.WriteLine("---------------------------------------------------------------------------");
                if (Zastita.UcitajBool("Promijeni šifru dobavljača? (DA/NE)", "da"))
                {
                    odabrani.Sifra = Zastita.UcitajRasponBroja("Unesi novu šifru dobavljača", 1, int.MaxValue);
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine("---------------------- ŠIFRA DOBAVLJAČA PROMJENJENA -----------------------");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine(odabrani.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                if (Zastita.UcitajBool("Promijeni naziv dobavljača? (DA/NE)", "da"))
                {
                    odabrani.Naziv = Zastita.UcitajString("Unesi novi naziv dobavljača", 50, true);
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine("----------------------- NAZIV DOBAVLJAČA PROMJENJEN -----------------------");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine(odabrani.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                if (Zastita.UcitajBool("Promijeni grad dobavljača? (DA/NE)", "da"))
                {
                    odabrani.Grad = Zastita.UcitajString("Unesi novi grad dobavljača", 50, true);
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine("----------------------- GRAD DOBAVLJAČA PROMJENJEN ------------------------");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine(odabrani.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                if (Zastita.UcitajBool("Promijeni adresu dobavljača? (DA/NE)", "da"))
                {
                    odabrani.Adresa = Zastita.UcitajString("Unesi novu adresu dobavljača", 50, true);
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine("--------------------- ADRESA DOBAVLJAČA PROMJENJENA -----------------------");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine(odabrani.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                if (Zastita.UcitajBool("Promijeni OIB dobavljača? (DA/NE)", "da"))
                {
                    odabrani.OIB = Zastita.UcitajString("Unesi novi OIB dobavljača", 11, true);
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine("----------------------- OIB DOBAVLJAČA PROMJENJEN -------------------------");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine(odabrani.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("----------------------- USPJEŠNA PROMJENA PODATAKA ------------------------");
                Console.WriteLine("---------------------------------------------------------------------------");
                SpremiPodatkeDobavljaci();
            }
        }

        private void ObrisiDobavljaca()
        {
            if (Dobavljaci.Count == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("------------------- NEMA DOSTUPNIH DOBAVLJAČA--------------------");
                Console.WriteLine("-----------------------------------------------------------------");
                return;
            }
            else
            {
                PrikaziDobavljace();
                Console.WriteLine("---------------------------------------------------------------------------");
                var odabrani = Dobavljaci[Zastita.UcitajRasponBroja("Odaberi redni broj dobavljača za brisanje", 1, Dobavljaci.Count) - 1];
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------");

                if (Zastita.UcitajBool(odabrani.ToString() + "\n" +
                    "---------------------------------------------------------------------------" + "\n" +
                    "---------------------- OBRISATI DOBAVLJAČA ------------------ " + "? (DA/NE)", "da"))
                {
                    Dobavljaci.Remove(odabrani);
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine("---------------------------- DOBAVLJAČ OBRISAN ----------------------------");
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                SpremiPodatkeDobavljaci();
            }
        }

        private void SpremiPodatkeDobavljaci()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Dobavljaci.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(Dobavljaci));
            outputFile.Close();
        }
    }
}
