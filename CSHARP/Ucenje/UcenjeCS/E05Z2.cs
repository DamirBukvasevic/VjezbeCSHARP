namespace UcenjeCS
{
    internal class E05Z2
    {
        public static void Izvedi()
        {
            //Korisnik upisuje vrijednosti.
            //Program ispisuje unesene brojeve jedno pokraj drugom odvojeno zarezom.

            int broj1;
            Console.Write("Unesite 1. broj: ");
            broj1 = int.Parse(Console.ReadLine());

            int broj2;
            Console.Write("Unesite 2. broj: ");
            broj2 = int.Parse(Console.ReadLine());

            int broj3;
            Console.Write("Unesite 3. broj: ");
            broj3 = int.Parse(Console.ReadLine());

            Console.WriteLine(broj1 + "," +broj2 + "," + broj3);

        }
    }
}
