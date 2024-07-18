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
            Console.WriteLine("3. Promjena podataka nabave");
            Console.WriteLine("4. Brisanje nabave");
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
                    //PromjenaPodatakaNabave();
                    PrikaziGlavniIzbornikNabave();
                    break;
                case 4:
                    Console.Clear();
                    //BrisanjeNabave();
                    PrikaziGlavniIzbornikNabave();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        private void UnosNoveNabave()
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
            Console.WriteLine("***************** USPJEŠAN UNOS PODATAKA NABAVE *****************");
            Console.WriteLine("-----------------------------------------------------------------");
        }
        private List<Dobavljac> UcitajDobavljace()
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

        private void PrikaziNabave()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("************************* LISTA NABAVA **************************");
            Console.WriteLine("-----------------------------------------------------------------");
            int rb = 0, rbd;
            foreach (var n in Nabave)
            {
                n.NazivDobavljaca.Sort();
                foreach (var d in n.NazivDobavljaca)
                {
                    Console.WriteLine(d.Naziv);
                }

                Console.WriteLine("Šifra nabave: " + n.Sifra + " " + ", " + "Br.nabave: " + n.BrojNabave + " " + ", " + "Datum: " + n.DatumNabave);
                rbd = 0;
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }
    }
}
