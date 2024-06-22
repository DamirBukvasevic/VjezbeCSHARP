namespace UcenjeCS
{
    internal class E03Z2
    {
        public static void Izvedi()
        {
            // Korisnik unosi dva decimalna broja
            // Program ispisuje Veći ili Jednaki su ako su uneseni brojevi jednaki

            decimal br1;
            decimal br2;

            Console.Write("Unesite PRVI dec. broj: ");
            br1 = decimal.Parse(Console.ReadLine());

            Console.Write("Unesite DRUGI dec. broj: ");
            br2 = decimal.Parse(Console.ReadLine());

            if (br1 == br2)
            {
                Console.WriteLine("JEDNAKI SU!");
            }
            else
            {
                Console.WriteLine("VEĆI SU!");
            }
        }
    }
}
