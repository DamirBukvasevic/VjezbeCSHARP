namespace UcenjeCS
{
    internal class E03Z1
    {
        public static void Izvedi()
        {
            int brGodina;
            Console.Write("Unesite vaše godine: ");
            brGodina = int.Parse(Console.ReadLine());

            if (brGodina <= 17)
            {
                Console.WriteLine(brGodina + " NISTE PUNOLJETNI !!!");
            }
            else
            {
                Console.WriteLine(brGodina + " Punoljetni ste!");
            }
        }
    }
}
