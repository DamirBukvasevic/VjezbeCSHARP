namespace UcenjeCS
{
    internal class E03Z4
    {
        public static void Izvedi()
        {
            /*
            Program učitava od korisnika ime grada.
            U ovisnosti o imenu grada ispisuje regiju prema sljedećim pravilima:
            Osijek -> Slavonija
            Zadar -> Dalmacija
            Čakovec -> Međimurje
            Pula -> Istra
            Za ostale unose program ispisuje: Ne znam koja je to regija.
            * */

            string grad = "";
            
            Console.Write("Unesite ime grada: ");
            grad = Console.ReadLine();

            if (grad == "Osijek")
            {
                Console.WriteLine("Slavonija");
            }
            else if (grad == "Zadar")
            {
                Console.WriteLine("Dalmacija");
            }
            else if (grad == "Čakovec")
            {
                Console.WriteLine("Međimurje");
            }
            else if (grad == "Pula")
            {
                Console.WriteLine("Istra");
            }
            else
            {
                Console.WriteLine("Ne znam koja je to regija!");
            }



        }
    }
}
