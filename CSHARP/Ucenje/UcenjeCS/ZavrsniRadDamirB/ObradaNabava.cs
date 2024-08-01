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
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("******************* IZBORNIK ZA RAD S NABAVAMA ******************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Pregled svih nabava");
            Console.WriteLine("2. Unos nove nabave");
            Console.WriteLine("3. Promjena podataka postojeće nabave");
            Console.WriteLine("4. Brisanje postojeće nabave");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("-----------------------------------------------------------------");
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
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("************************* LISTA NABAVA **************************");
            Console.WriteLine("-----------------------------------------------------------------");

            int rbn = 0;
            foreach (var n in Nabave)
            {
                n.NazivDobavljaca.Sort();
                foreach (var d in n.NazivDobavljaca)
                {
                    Console.WriteLine("Rb. "+ ++rbn + ". " + d.Naziv);
                }
                Console.WriteLine(n.ToString());
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        public void UnosNoveNabave()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("***************** UNESITE TRAŽENE PODATKE NABAVE ****************");
            Console.WriteLine("-----------------------------------------------------------------");

            Nabava n = new Nabava();
            n.Sifra = Zastita.UcitajRasponBroja("Unesi Širu nabave", 1, int.MaxValue);
            n.BrojNabave = Zastita.UcitajRasponBroja("Unesi broj nabave", 1, int.MaxValue);
            n.DatumNabave = Zastita.UcitajDatum("Unesi datum nabave", true);

            n.NazivDobavljaca = UcitajDobavljace();

            Nabave.Add(n);
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("---------------------- NOVA NABAVA UNESENA ----------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public List<Dobavljac> UcitajDobavljace()
        {
            List<Dobavljac> lista = new List<Dobavljac>();
            {
                Izbornik.ObradaDobavljac.PrikaziDobavljace();
                Console.WriteLine("-----------------------------------------------------------------");
                lista.Add(
                    Izbornik.ObradaDobavljac.Dobavljaci[
                    Zastita.UcitajRasponBroja("Odaberite šifru dobavljača", 1,
                    Izbornik.ObradaDobavljac.Dobavljaci.Count) - 1
                    ]);
            }
            return lista;
        }

        private void PromjenaPodatakaNabave()
        {
            PrikaziNabave();
            Console.WriteLine("-----------------------------------------------------------------");
            var odabrani = Nabave[Zastita.UcitajRasponBroja("Odaberi redni broj nabave za promjenu", 1, Nabave.Count) - 1];

            odabrani.Sifra = Zastita.UcitajRasponBroja("Unesi Širu nabave", 1, int.MaxValue);
            odabrani.BrojNabave = Zastita.UcitajRasponBroja("Unesi broj nabave", 1, int.MaxValue);
            odabrani.DatumNabave = Zastita.UcitajDatum("Unesi datum nabave", true);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("------------------ USPJEŠNA PROMJENA PODATAKA -------------------");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private void BrisanjeNabave()
        {
            PrikaziNabave();
            var odabrani = Nabave[Zastita.UcitajRasponBroja("Odaberi redni broj nabave za brisanje", 1, Nabave.Count) - 1];
            Console.WriteLine("-----------------------------------------------------------------");

            if (Zastita.UcitajBool("Br.Nabave: " + odabrani.BrojNabave + " ---- OBRISATI NABAVU ---- " + "? (DA/NE)", "da"))
            {
                Nabave.Remove(odabrani);
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("------------------------ NABAVA OBRISANA ------------------------");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }
    }
}
