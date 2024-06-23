namespace UcenjeCS
{
    internal class E01Z6
    {
        public static void Izvedi()
        {
            //Program od korisnika učitava ime grada i broj stanovnika.
            //Ispisuje rečenicu: U XXXXXXX živi XXXXX ljudi.

            Console.Write("Unesite grad: ");
            string grad = Console.ReadLine();

            Console.Write("Unesite broj stanovnika: ");
            int brojS = int.Parse(Console.ReadLine());

            Console.WriteLine("U {0} Živi {1} Stanovnika", grad, brojS);
        }
    }
}
