namespace UcenjeCS
{
    internal class E04Z1
    {
        public static void Izvedi()
        {
            // Korisnik unosi brojčani iznos ocjene. Program ispisuje
            // tekstualno ocjenu

            int i = 0;

            Console.Write("Unesite ocjenu: ");
            i = int.Parse(Console.ReadLine());

            switch (i)
            {
                case 1:
                    Console.WriteLine("Nedovoljan!");
                    break;
                case 2:
                    Console.WriteLine("Dovoljan!");
                    break;
                case 3:
                    Console.WriteLine("Dobar!");
                    break;
                case 4:
                    Console.WriteLine("Vrlo dobar!");
                    break;
                case 5:
                    Console.WriteLine("Odličan!");
                    break;
                default:
                    Console.WriteLine("Nije definirano");
                    break;
            }

        }
    }
}
