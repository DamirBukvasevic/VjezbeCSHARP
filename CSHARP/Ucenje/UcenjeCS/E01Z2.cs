namespace UcenjeCS
{
    internal class E01Z2
    {
        public static void Izvedi()
        {
            // zadatak
            // Korisnik će unijeti dvoznamenkasti broj
            // Ispisuje se prva znamenka
            // 56 => 5
            // 11 => 1

            int broj;

            Console.Write("Unesite dvoznamenkasti broj: ");
            broj = int.Parse(Console.ReadLine());

            Console.Write("Rezultat: ");
            Console.WriteLine(broj / 10);
        }
    }
}
