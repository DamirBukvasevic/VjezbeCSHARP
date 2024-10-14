namespace UcenjeCS
{
    internal class E03Z3
    {
        public static void Izvedi()
        {
            //Za tri učitana cijela broja od strane korisnika program ispisuje najmanji

            int br1;
            int br2;
            int br3;

            Console.Write("Unesite 1. cijeli broj: ");
            br1 = int.Parse(Console.ReadLine());

            Console.Write("Unesite 2. cijeli broj: ");
            br2 = int.Parse(Console.ReadLine());

            Console.Write("Unesite 3. cijeli broj: ");
            br3 = int.Parse(Console.ReadLine());

            if (br1 < br2 && br1 < br3)
            {
                Console.WriteLine(br1 + " Najmanji broj!");
            }
            if (br2 < br1 && br2 < br3)
            {
                Console.WriteLine(br2 + " Najmanji broj!");
            }
            if (br3 < br1 && br3 < br2)
            {
                Console.WriteLine(br3 + " Najmanji broj!");
            }
        }
    }
}
