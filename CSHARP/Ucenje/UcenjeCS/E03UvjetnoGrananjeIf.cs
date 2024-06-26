using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E03UvjetnoGrananjeIf
    {


        public static void Izvedi()
        {

            int i = 8; // Nisam koristio Console.ReadLine kako bi bili brži

            // uvjetno grananje if radi s bool tipom podatka

            bool uvjet = i == 7;

            Console.WriteLine(uvjet);

            // minimalna if sintaksa
            if (uvjet) // u if granu se ulazi ako je vrijednost uvjeta true
            {
                Console.WriteLine("1. Ušao sam u if granu, uvjet je zadovoljen");
            }
            // dodatak (neobavezni dio) if grananja
            else
            {
                Console.WriteLine("2. Uvjet nije zadovoljen, otišao u else granu");
            }

            // uobičajna sintaka što se tiče uvjeta
            if (i > 2) // ako ne postoje {} if se odnosi samo na 1. sljedeću liniju
                Console.WriteLine("3. Ušao u if bez vitičastih zagrada");
            Console.WriteLine("4. ovo se izvodi bez obzira na gornji if");


            var j = 2;

            // dodatni operatori & (and), &&, | (or), || (AltGr + W), ! (not)
            if (i < 2 && j == 2)
            {
                Console.WriteLine("5. logičko and &");
            }

            // & provjerava oba uvjeta bez obzira što možda prvi bude false
            // && Ukoliko prvi uvjet bude false drugi se ne provjerava


            if(j==2 || i < 2)
            {
                Console.WriteLine("6. logičko or | ");
            }

            // | Provjerava oba uvjeta bez obzira što prvi bude true
            // || Ukoliko prvi uvjet bude true drugi se ne provjerava


            if (i != 5)
            {
                Console.WriteLine("7. i nema vrijednost 5");
            }


            var ocjena = 4;

            if (ocjena == 1)
            {
                Console.WriteLine("8. nedovoljan");
            }else if(ocjena == 2)
            {
                Console.WriteLine("9. dovoljan");
            }
            // da ne pišem sve
            else
            {
                Console.WriteLine("10. Ocjena nije dobra");
            }

            // inline if
            if (ocjena == 4)
            {
                Console.WriteLine("11. Vrlo dobar si");
            }
            else
            {
                Console.WriteLine("12. OK si");
            }
            // ova lnijia je ekvivalent gornjem if else
            Console.WriteLine(ocjena==4 ? "11. Vrlo dobar si" : "12. OK si");

            // if se može gnjezditi
            if (i > 0)
            {
                if (ocjena == 4)
                {
                    Console.WriteLine("12. Gnježđenje se može zapravo zamjeniti s &&");
                }
            }

        }




    }
}
