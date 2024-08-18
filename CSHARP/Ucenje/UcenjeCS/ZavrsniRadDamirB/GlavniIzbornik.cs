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
            string folderName = "DamirBazaPodataka";
            string fullFolderPath = Path.Combine(docPath, folderName);

            string filePath = Path.Combine(fullFolderPath, "Dobavljaci.json");
            if (File.Exists(filePath))
            {
                StreamReader file = File.OpenText(filePath);
                ObradaDobavljac.Dobavljaci = JsonConvert.DeserializeObject<List<Dobavljac>>(file.ReadToEnd());
                file.Close();
            }
        }
        private void UcitajPodatkeArtikli()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderName = "DamirBazaPodataka";
            string fullFolderPath = Path.Combine(docPath, folderName);

            string filePath = Path.Combine(fullFolderPath, "Artikli.json");
            if (File.Exists(filePath))
            {
                StreamReader file = File.OpenText(filePath);
                ObradaArtikl.Artikli = JsonConvert.DeserializeObject<List<Artikl>>(file.ReadToEnd());
                file.Close();
            }
        }
        private void UcitajPodatkeNabava()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderName = "DamirBazaPodataka";
            string fullFolderPath = Path.Combine(docPath, folderName);

            string filePath = Path.Combine(fullFolderPath, "Nabave.json");
            if (File.Exists(filePath))
            {
                StreamReader file = File.OpenText(filePath);
                ObradaNabava.Nabave = JsonConvert.DeserializeObject<List<Nabava>>(file.ReadToEnd());
                file.Close();
            }
        }
        private void UcitajPodatkeStavke()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderName = "DamirBazaPodataka";
            string fullFolderPath = Path.Combine(docPath, folderName);

            string filePath = Path.Combine(fullFolderPath, "Stavke.json");
            if (File.Exists(filePath))
            {
                StreamReader file = File.OpenText(filePath);
                ObradaStavka.Stavke = JsonConvert.DeserializeObject<List<Stavka>>(file.ReadToEnd());
                file.Close();
            }
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine(" ");
            Console.WriteLine("- - - - - - - - - - - - -  Skladiste DB Console App v 1.0 - - - - - - - - - - - - - -");
            Console.WriteLine(" ");
        }

        public void PrikaziGlavniIzbornik()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("********************************** GLAVNI IZBORNIK **********************************");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("1. Dobavljači");
            Console.WriteLine("2. Artikli");
            Console.WriteLine("3. Nabave");
            Console.WriteLine("4. Stavke");
            Console.WriteLine("5. Izlaz iz programa");
            Console.WriteLine("-------------------------------------------------------------------------------------");
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
                    ObradaNabava.PrikaziGlavniIzbornikNabave();
                    PrikaziGlavniIzbornik();
                    break;
                case 4:
                    Console.Clear();
                    ObradaStavka.PrikaziGlavniIzbornikStavke();
                    PrikaziGlavniIzbornik();
                    break;
                case 5:
                    Console.WriteLine("*************************************************************************************");
                    Console.WriteLine("-------------------- Hvala na korištenju aplikacije, doviđenja! ---------------------");
                    Console.WriteLine("*************************************************************************************");
                    break;
            }
        }
    }
}
