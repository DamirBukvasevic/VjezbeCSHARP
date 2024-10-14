namespace UcenjeCS
{
    internal class E01Z5
    {
        public static void Izvedi()
        {
            {
                // Program od korisnika učitava decimalni broj
                // te ispisuje drugi korijen učitanog broja.

                decimal x;

                Console.Write("Unesi decimalni broj: ");
                x = decimal.Parse(Console.ReadLine());

                double y = Math.Sqrt(decimal.ToDouble(x));
                Console.WriteLine("Rezultat: " + y);

                Console.WriteLine("*******************************************");

                Console.Write("Unesi decimalni broj: ");
                Console.WriteLine("Rezultat: " + Math.Sqrt(double.Parse(Console.ReadLine())));
            }
        }
    }
}
