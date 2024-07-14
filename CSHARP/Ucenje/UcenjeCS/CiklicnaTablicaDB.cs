using System.Collections;

namespace UcenjeCS
{
    internal class CiklicnaTablicaDB
    {

        public static void Izvedi()
        {
            string Izlaz;
            do
            {
                Console.WriteLine("***************TABLICA MAX 10*10***************");
                Console.Write("Unesite broj redova: ");
                int BrRedova = int.Parse(Console.ReadLine());

                Console.Write("Unesite broj kolona: ");
                int BrKolona = int.Parse(Console.ReadLine());

                int[,] Tablica = new int[BrRedova,BrKolona];
                Console.WriteLine();
                Console.WriteLine("Broj Redova: {0} // Broj Kolona: {1} // Ukupno: {2}", BrRedova, BrKolona, Tablica.Length);
                Console.WriteLine();

                int DRed = BrRedova - 1;
                int LKolona = 0;
                int GRed = 0;
                int DKolona = BrKolona - 1;
                int broj = 1;

                for (int x = 0; broj <= Tablica.Length; x++)
                {
                    for (int i = DKolona; i >= LKolona; i--)
                    {
                        Tablica[DRed, i] = broj++;
                    }
                    DRed--;

                    for (int i = DRed; i >= GRed; i--)
                    {
                        Tablica[i, LKolona] = broj++;
                    }
                    LKolona++;

                    if (GRed <= DRed)
                    {
                        for (int i = LKolona; i <= DKolona; i++)
                        {
                            Tablica[GRed, i] = broj++;
                        }
                        GRed++;
                    }
                    if (LKolona <= DKolona)
                    {
                        for (int i = GRed; i <= DRed; i++)
                        {
                            Tablica[i, DKolona] = broj++;
                        }
                        DKolona--;
                    }
                }

                for (int red = 0; red < BrRedova; red++)
                {
                    for (int kolona = 0; kolona < BrKolona; kolona++)
                    {
                        Console.Write("{0, 5}", Tablica[red, kolona]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("****************************************");
                Console.Write("Želite li nastaviti? (d/n): ");
                Izlaz = Console.ReadLine();
            }
            while (Izlaz == "d" || Izlaz == "D");
        }
    }
}
