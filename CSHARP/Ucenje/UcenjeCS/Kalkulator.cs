using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class Kalkulator
    {
        public static void Izvedi()
        {
            string Izlaz;
            do
            {
                Console.WriteLine("***************KALKULATOR***************");
                Console.Write("Unesite broj: ");
                int broj1 = int.Parse(Console.ReadLine());

                Console.Write("R. operacija (+,-,*,/): ");
                string racunskaOperacija = Console.ReadLine();

                Console.Write("Unesite broj: ");
                int broj2 = int.Parse(Console.ReadLine());
                Console.WriteLine("****************************************");

                int Rezultat;

                switch (racunskaOperacija)
                {
                    case "+":
                        Rezultat = broj1 + broj2;
                        Console.WriteLine("Rezultat: " + Rezultat);
                        break;

                    case "-":
                        Rezultat = broj1 - broj2;
                        Console.WriteLine("Rezultat: " + Rezultat);
                        break;

                    case "*":
                        Rezultat = broj1 * broj2;
                        Console.WriteLine("Rezultat: " + Rezultat);
                        break;

                    case "/":
                        Rezultat = broj1 / broj2;
                        Console.WriteLine("Rezultat: " + Rezultat);
                        break;
                    default:
                        Console.WriteLine("Krivi unos!");
                        break;
                }
                Console.WriteLine("****************************************");
                Console.Write("Želite li nastaviti? (d/n): ");
                Izlaz = Console.ReadLine();
            }
            while (Izlaz == "d" || Izlaz == "D");
        }

    }
}
