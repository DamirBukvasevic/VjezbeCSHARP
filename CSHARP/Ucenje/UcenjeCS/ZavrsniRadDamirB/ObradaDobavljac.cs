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
            
        }

        public void PrikaziGlavniIzbornikDobavljac()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("***************** IZBORNIK ZA RAD S DOBAVLJAČIMA ****************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Pregled svih dobavljača");
            Console.WriteLine("2. Unos novog dobavljača");
            Console.WriteLine("3. Promjena podataka postojećeg dobavljača");
            Console.WriteLine("4. Brisanje postojećeg dobavljača");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("-----------------------------------------------------------------");
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

        private void ObrisiDobavljaca()
        {
            PrikaziDobavljace();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Dobavljaci[Zastita.UcitajRasponBroja("Odaberi redni broj dobavljača za brisanje", 1, Dobavljaci.Count) - 1];
            Console.WriteLine("-----------------------------------------------------------------");

            if (Zastita.UcitajBool(odabrani.Naziv + " ----OBRISATI DOBAVLJAČA---- " + "? (DA/NE)", "da"))
            {
                Dobavljaci.Remove(odabrani);
                Console.Clear() ;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("----------------------- DOBAVLJAČ OBRISAN -----------------------");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        private void PromjeniPodatkeDobavljaca()
        {
            PrikaziDobavljace();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Dobavljaci[Zastita.UcitajRasponBroja("Odaberi redni broj dobavljača za promjenu", 1, Dobavljaci.Count) - 1];

            odabrani.Sifra = Zastita.UcitajRasponBroja("Unesi šifru dobavljača", 1, int.MaxValue);
            odabrani.Naziv = Zastita.UcitajString("Unesi naziv dobavljača", 50, true);
            odabrani.Grad = Zastita.UcitajString("Unesi grad dobavljača", 50, true);
            odabrani.Adresa = Zastita.UcitajString("Unesi adresu dobavljača", 50, true);
            odabrani.OIB = Zastita.UcitajString("Unesi OIB dobavljača", 11, true);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("------------------ USPJEŠNA PROMJENA PODATAKA -------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public void PrikaziDobavljace()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("*********************** LISTA DOBAVLJAČA ************************");
            Console.WriteLine("-----------------------------------------------------------------");
            int rb = 0;
            foreach (var d in Dobavljaci)
            {
                Console.WriteLine(++rb + ". " + "Šifra: " + d.Sifra + " , " + d.Naziv + " , " + d.Grad + " " + d.Adresa + " , " + "OIB: " + d.OIB);
            }
        }

        private void UnosNovogDobavljaca()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("*************** UNESITE TRAŽENE PODATKE DOBAVLJAČA **************");
            Console.WriteLine("-----------------------------------------------------------------");
            Dobavljaci.Add(new()
            {
                Sifra = Zastita.UcitajRasponBroja("Unesi šifru dobavljača", 1, int.MaxValue),
                Naziv = Zastita.UcitajString("Unesi naziv dobavljača", 50, true),
                Grad = Zastita.UcitajString("Unesi grad dobavljača", 50, true),
                Adresa = Zastita.UcitajString("Unesi adresu dobavljača", 50, true),
                OIB = Zastita.UcitajString("Unesi OIB dobavljača", 11, true)
            });
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("--------------------- NOVI DOBAVLJAČ UNESEN ---------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
