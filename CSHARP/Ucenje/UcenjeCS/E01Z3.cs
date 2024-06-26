namespace UcenjeCS
{
    internal class E01Z3
    {
        public static void Izvedi()
        {
            // zadatak
            // Za uneseni cijeli broj ispisati True ako je parni ili False ako je neparni

            int broj;

            Console.Write("Unesite cijeli broj: ");
            broj = int.Parse(Console.ReadLine());

            Console.WriteLine(broj % 2 == 0);
        }
    }
}
