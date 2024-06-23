namespace UcenjeCS
{
    internal class E01Z4
    {
        public static void Izvedi()
        {
            //Program od korisnika učitava dvije rečenice i
            //ispisuje jednu nakon druge u istom retku.

            Console.Write("Unesite 1. rečenicu: ");
            string rečenica1;
            rečenica1 = Console.ReadLine();

            Console.Write("Unesite 2. rečenicu: ");
            string rečenica2;
            rečenica2 = Console.ReadLine();

            Console.WriteLine(rečenica1 + " " + rečenica2);
        }
    }
}
