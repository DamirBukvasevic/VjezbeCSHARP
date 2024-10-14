namespace UcenjeCS
{
    internal class E01Z1
    {
        public static void Izvedi()
        {
            // zadatak: Unijeti Adresu i grad te ispisati jedno ispod drugog adresu i grad

            string adresa;
            string grad;

            Console.Write("Unesite adresu: ");
            adresa = Console.ReadLine();

            Console.Write("Unesite grad: ");
            grad = Console.ReadLine();

            Console.WriteLine(adresa);
            Console.WriteLine(grad);
        }
    }
}
