namespace UcenjeCS
{
    internal class E02VarijableTipoviPodatakaOperatori
    {
        // Formatiranje koda CTRL + K + D
        public static void Izvedi()
        {

            // Deklaracija varijabli
            int broj;

            // dodjeljivanje vrijednosti
            broj = 7;

            Console.WriteLine("Unesi broj: ");
            broj = int.Parse(Console.ReadLine());
            // korištenje varijable
            Console.WriteLine(broj +1);

            Console.WriteLine("Unesi decimalni broj: ");
            decimal db = decimal.Parse(Console.ReadLine());

            Console.WriteLine(db/10);


            // modulo: Ostatak nakon cjelobrojnog djeljenja
            int modulo = 4 % 2;
            Console.WriteLine(modulo);

            int i = 5;
            int j = 3;

            Console.WriteLine(i/(float)j); // (float) je cast

            bool logickaVrijednost = true; // to je u SQL bit

            // Do sada prikazani operator: 
            // = dodjeljivanje
            // % modulo

            // == provjera jednakosti

            Console.WriteLine(i==j);


            // != različito

            Console.WriteLine(i == j);

            int k = 5, l = j; // istovjetno linijama 30 i 31

            var ime = "Edunova"; // desna strana određuje tip


            // increment, decrement

            int b = 0;
            // uvećati za 1
            b = b + 1; // 1
            b += 1; //2
            b++; //3
            ++b; //4

            Console.WriteLine(++b); //5
            Console.WriteLine(b++); //5
            Console.WriteLine(b); //6

            // isto vrijedi i za decrement --b b--

            //Primjeri zadataka

            int x = 1, y = 2;
            Console.WriteLine("--------------------");
            x = ++y; // x = 3, y = 3
            //Console.WriteLine(x);
            //Console.WriteLine(y);
            Console.WriteLine("x={0}, y={1}",x,y);
            Console.WriteLine("*********************");

            y = x - --y; // 3 - 2, y=1, x = 3
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine("*********************");

            Console.WriteLine(x+y); //4







        }

    }
}
