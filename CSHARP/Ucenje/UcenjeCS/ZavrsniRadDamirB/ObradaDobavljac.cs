using System.Security.Cryptography;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class ObradaDobavljac
    {
        public List<Dobavljac> Dobavljaci { get; set; }

        public ObradaDobavljac()
        {
            Dobavljaci = new List<Dobavljac>();
            if (Zastita.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            Dobavljaci.Add(new() { Sifra = 1, Naziv = "Atlantic", Grad = "Osijek", Adresa = "Sv. Roka 39A", OIB = "12345678912" });
        }

        public void PrikaziGlavniIzbornik()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("***************** IZBORNIK ZA RAD S DOBAVLJAĆIMA ****************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Pregled svih dobavljaća");
            Console.WriteLine("2. Unos novog dobavljaća");
            Console.WriteLine("3. Promjena podataka postojećeg dobavljaća");
            Console.WriteLine("4. Brisanje dobavljaća");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziDobavljace();
                    PrikaziGlavniIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    UnosNovogDobavljaca();
                    PrikaziGlavniIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    PromjeniPodatkeDobavljaca();
                    PrikaziGlavniIzbornik();
                    break;
                case 4:
                    Console.Clear();
                    ObrisiDobavljaca();
                    PrikaziGlavniIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        private void ObrisiDobavljaca()
        {
            PrikaziDobavljace();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Dobavljaci[Zastita.UcitajRasponBroja("Odaberi redni broj dobavljaća za brisanje", 1, Dobavljaci.Count) - 1];

            if (Zastita.UcitajBool("****SIGURNO OBRISATI**** " + odabrani.Naziv + " ****DOBAVLJAĆA**** " + "? (DA/NE)", "da"))
            {
                Dobavljaci.Remove(odabrani);
                Console.WriteLine("------ " + odabrani.Naziv + " DOBAVLJAĆ OBRISAN" + " ------");
            }
        }

        private void PromjeniPodatkeDobavljaca()
        {
            PrikaziDobavljace();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Dobavljaci[Zastita.UcitajRasponBroja("Odaberi redni broj dobavljaća za promjenu", 1, Dobavljaci.Count) - 1];

            odabrani.Sifra = Zastita.UcitajRasponBroja("Unesi šifru dobavljaća", 1, int.MaxValue);
            odabrani.Naziv = Zastita.UcitajString("Unesi naziv dobavljaća", 50, true);
            odabrani.Grad = Zastita.UcitajString("Unesi grad dobavljaća", 50, true);
            odabrani.Adresa = Zastita.UcitajString("Unesi adresu dobavljaća", 50, true);
            odabrani.OIB = Zastita.UcitajString("Unesi OIB dobavljaća", 11, true);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("*** USPJEŠNA PROMJENA PODATAKA ***");
            Console.WriteLine("----------------------------------");
        }

        private void PrikaziDobavljace()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("*********************** LISTA DOBAVLJAĆA ************************");
            Console.WriteLine("-----------------------------------------------------------------");
            int rb = 0;
            foreach (var p in Dobavljaci)
            {
                Console.WriteLine(++rb + ". " + p.Naziv + " " + p.Grad + " " + p.Adresa + " " + p.OIB);
            }
        }

        private void UnosNovogDobavljaca()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("*************** UNESITE TRAŽENE PODATKE DOBAVLJAĆA **************");
            Console.WriteLine("-----------------------------------------------------------------");
            Dobavljaci.Add(new()
            {
                Sifra = Zastita.UcitajRasponBroja("Unesi šifru dobavljaća", 1, int.MaxValue),
                Naziv = Zastita.UcitajString("Unesi naziv dobavljaća", 50, true),
                Grad = Zastita.UcitajString("Unesi grad dobavljaća", 50, true),
                Adresa = Zastita.UcitajString("Unesi adresu dobavljaća", 50, true),
                OIB = Zastita.UcitajString("Unesi OIB dobavljaća", 11, true)
            });
            Console.WriteLine("---------------------------------");
            Console.WriteLine("***** NOVI DOBAVLJAĆ UNEŠEN *****");
            Console.WriteLine("---------------------------------");
        }
    }
}
