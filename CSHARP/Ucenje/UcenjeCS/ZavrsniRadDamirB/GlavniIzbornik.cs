using Newtonsoft.Json;

using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class GlavniIzbornik
    {
        public ObradaDobavljac ObradaDobavljac { get; set; }
        public ObradaArtikl ObradaArtikl { get; set; }
        public ObradaNabava ObradaNabava { get; set; }
        public ObradaStavka ObradaStavka { get; set; }

        public GlavniIzbornik()
        {
            ObradaDobavljac = new ObradaDobavljac();
            ObradaArtikl = new ObradaArtikl(this);
            ObradaNabava = new ObradaNabava(this);
            ObradaStavka = new ObradaStavka(this);
            UcitajPodatkeDobavljaci();
            UcitajPodatkeArtikli();
            UcitajPodatkeNabava();
            UcitajPodatkeStavke();
            PozdravnaPoruka();
            PrikaziGlavniIzbornik();
        }

        private void UcitajPodatkeDobavljaci()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(Path.Combine(docPath, "Dobavljaci.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Dobavljaci.json"));
                ObradaDobavljac.Dobavljaci = JsonConvert.DeserializeObject<List<Dobavljac>>(file.ReadToEnd());
                file.Close();
            }
        }
        private void UcitajPodatkeArtikli()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(Path.Combine(docPath, "Artikli.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Artikli.json"));
                ObradaArtikl.Artikli = JsonConvert.DeserializeObject<List<Artikl>>(file.ReadToEnd());
                file.Close();
            }
        }
        private void UcitajPodatkeNabava()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(Path.Combine(docPath, "Nabave.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Nabave.json"));
                ObradaNabava.Nabave = JsonConvert.DeserializeObject<List<Nabava>>(file.ReadToEnd());
                file.Close();
            }
        }
        private void UcitajPodatkeStavke()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(Path.Combine(docPath, "Stavke.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Stavke.json"));
                ObradaStavka.Stavke = JsonConvert.DeserializeObject<List<Stavka>>(file.ReadToEnd());
                file.Close();
            }
        }

        public void PrikaziGlavniIzbornik()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("************************ GLAVNI IZBORNIK ************************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Dobavljači");
            Console.WriteLine("2. Artikli");
            Console.WriteLine("3. Stavke");
            Console.WriteLine("4. Nabave");
            Console.WriteLine("5. Izlaz iz programa");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Zastita.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ObradaDobavljac.PrikaziGlavniIzbornikDobavljac();
                    PrikaziGlavniIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaArtikl.PrikaziGlavniIzbornikArtikli();
                    PrikaziGlavniIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaStavka.PrikaziGlavniIzbornikStavke();
                    PrikaziGlavniIzbornik();
                    break;
                case 4:
                    Console.Clear();
                    ObradaNabava.PrikaziGlavniIzbornikNabave();
                    PrikaziGlavniIzbornik();
                    break;
                case 5:
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("---------- Hvala na korištenju aplikacije, doviđenja! -----------");
                    Console.WriteLine("*****************************************************************");
                    SpremiPodatkeNabava();
                    SpremiPodatkeStavke();
                    break;
            }
        }
        
        private void SpremiPodatkeNabava()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Nabave.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(ObradaNabava.Nabave));
            outputFile.Close();
        }
        private void SpremiPodatkeStavke()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Stavke.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(ObradaStavka.Stavke));
            outputFile.Close();
        }
        private void PozdravnaPoruka()
        {
            Console.WriteLine("");
            Console.WriteLine("**************** Skladiste DB Console App v 1.0 *****************");
            Console.WriteLine("");
        }
    }
}
