namespace UcenjeCS
{
    internal class E05Z1
    {
        public static void Izvedi()
        {
            //Definirajte niz od tri cijela broja i svakome dodjelite vrijednost 7.

            int[] niz = new int[3];

            niz[0] = 7;
            niz[1] = 7;
            niz[2] = 7;

            Console.Write(niz[0] + ",");
            Console.Write(niz[1] + ",");
            Console.WriteLine(niz[2] + ",");

            Console.WriteLine("**************************");

            int[] niz2 = { 2, 4, 6, 3, 7, 9, 2, 7, 8, 7 };

            Console.Write(niz2[4] + ",");
            Console.Write(niz2[7] + ",");
            Console.Write(niz2[9] + ",");
        }
    }
}
