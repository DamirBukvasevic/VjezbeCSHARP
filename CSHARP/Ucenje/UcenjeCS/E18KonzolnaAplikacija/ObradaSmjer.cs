using UcenjeCS.E18KonzolnaAplikacija.Model;

namespace UcenjeCS.E18KonzolnaAplikacija
{
    internal class ObradaSmjer
    {

        public List<Smjer>  Smjerovi { get; set; }

        public ObradaSmjer() 
        { 
            Smjerovi = new List<Smjer>();
            if (Pomocno.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            Smjerovi.Add(new() { Naziv="Web programiranje"});
            Smjerovi.Add(new() { Naziv = "Web Dizajn" });
            Smjerovi.Add(new() { Naziv = "Serviser" });
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s smjerovima");
            Console.WriteLine("1. Pregled svih smjerova");
            Console.WriteLine("2. Unos novog smjera");
            Console.WriteLine("3. Promjena podataka postojećeg smjera");
            Console.WriteLine("4. Brisanje smjera");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
           switch(Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogSmjera();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPostojeciSmjer();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPostojeciSmjer();
                    PrikaziIzbornik();
                    break;
                case 5:                    
                    Console.Clear();
                    break;
            }
        }

        private void ObrisiPostojeciSmjer()
        {
            PrikaziSmjerove();
            var odabrani = Smjerovi[Pomocno.UcitajRasponBroja("Odaberi redni broj smjera za Brisanje",
                1, Smjerovi.Count) - 1];

            if(Pomocno.UcitajBool("Sigurno obrisati " +  odabrani.Naziv + "? (DA/NE)", "da"))
            {
                Smjerovi.Remove(odabrani);
            }

        }

        private void PromjeniPostojeciSmjer()
        {
            PrikaziSmjerove();
            var odabrani = Smjerovi[Pomocno.UcitajRasponBroja("Odaberi redni broj smjera za promjenu",
                1, Smjerovi.Count) - 1];
            odabrani.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue);
            odabrani.Naziv = Pomocno.UcitajString("Unesi naziv smjera", 50, true);
            odabrani.Trajanje = Pomocno.UcitajRasponBroja("Unesi trajanje smjera", 1, 500);
            odabrani.Cijena = Pomocno.UcitajDecimalniBroj("Unesi cijenu smjera", 0, 10000);
            odabrani.IzvodiSeOd = Pomocno.UcitajDatum("Unesi datum od kada se izvodi smjer", true);
            odabrani.Verificiran = Pomocno.UcitajBool("Da li je smjer verificiran (DA/NE)", "da");

            // gornjih 6 linija igra istu ulogu kao na 93 - 98. Izvući u metodu

        }

        public void PrikaziSmjerove()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Smjerovi u aplikaciji");
            int rb = 0;
            foreach(var s in Smjerovi)
            {
                Console.WriteLine(++rb + ". " + s.Naziv); 
            }
            Console.WriteLine("****************************");
        }

        private void UnosNovogSmjera()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o smjeru");
            Smjerovi.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue),
                Naziv = Pomocno.UcitajString("Unesi naziv smjera", 50, true),
                Trajanje = Pomocno.UcitajRasponBroja("Unesi trajanje smjera", 1, 500),
                Cijena = Pomocno.UcitajDecimalniBroj("Unesi cijenu smjera", 0, 10000),
                IzvodiSeOd = Pomocno.UcitajDatum("Unesi datum od kada se izvodi smjer", true),
                Verificiran = Pomocno.UcitajBool("Da li je smjer verificiran (DA/NE)","da")
            });
        }
    }
}
