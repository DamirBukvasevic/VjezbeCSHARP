using Newtonsoft.Json;
using UcenjeCS.ZavrsniRadDamirB.Model;

namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class GlavniIzbornik
    {
        public ObradaDobavljac ObradaDobavljac { get; set; }



        public GlavniIzbornik()
        {
            //Zastita.DEV = true;
            ObradaDobavljac = new ObradaDobavljac();
            UcitajPodatke();
            PozdravnaPoruka();
            PrikaziGlavniIzbornik();
        }

        private void UcitajPodatke()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(Path.Combine(docPath, "Dobavljaci.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "Dobavljaci.json"));
                ObradaDobavljac.Dobavljaci = JsonConvert.DeserializeObject<List<Dobavljac>>(file.ReadToEnd());
                file.Close();
            }
        }

        private void PrikaziGlavniIzbornik()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("************************ GLAVNI IZBORNIK ************************");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Dobavljaci");
            Console.WriteLine("2. Stavke");
            Console.WriteLine("3. Artikli");
            Console.WriteLine("4. Nabava");
            Console.WriteLine("5. Izlaz iz programa");
            Console.WriteLine("-----------------------------------------------------------------");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch(Zastita.UcitajRasponBroja("Odaberite stavku izbornika",1,5))
            {
                case 1:
                    Console.Clear();
                    ObradaDobavljac.PrikaziGlavniIzbornik();
                    PrikaziGlavniIzbornik();
                    break;
                case 5:
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("---------- Hvala na korištenju aplikacije, doviđenja! -----------");
                    Console.WriteLine("*****************************************************************");
                    SpremiPodatke();
                    break;
            }
        }

        private void SpremiPodatke()
        {
            if (Zastita.DEV)
            {
                return;
            }
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Dobavljaci.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(ObradaDobavljac.Dobavljaci));
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
