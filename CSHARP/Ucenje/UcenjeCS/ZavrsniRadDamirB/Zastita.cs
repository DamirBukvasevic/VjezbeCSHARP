namespace UcenjeCS.ZavrsniRadDamirB
{
    internal class Zastita
    {

        public static bool DEV = false;

        internal static bool UcitajBool(string poruka, string trueValue)
        {
            Console.Write(poruka + ": ");
            return Console.ReadLine().Trim().ToLower() == trueValue;
            
        }

        internal static bool UcitajBool2(string poruka)
        {
            while (true)
            {
                Console.Write(poruka + ": ");
                string unos = Console.ReadLine().Trim().ToLower();

                if (unos == "da")
                {
                    return true;
                }
                else if (unos == "ne")
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("Molimo unesite 'DA' ili 'NE'.");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                }
            }
        }
        internal static DateTime UcitajDatum(string poruka, bool kontrolaPrijeDanasnjegDatuma)
        {
            DateTime dt;
            while (true)
            {
                try
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("Današnji datum: {0}",
                        DateTime.Now.ToString("dd.MM.yyyy."));
                    if (kontrolaPrijeDanasnjegDatuma)
                    {
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("***** Uneseni datum ne smije biti poslije današnjeg datuma! *****");
                        Console.WriteLine("-----------------------------------------------------------------");
                    }
                    Console.Write(poruka + ": ");
                    dt = DateTime.Parse(Console.ReadLine());
                    if (kontrolaPrijeDanasnjegDatuma && dt > DateTime.Now)
                    {
                        throw new Exception();
                    }
                    return dt;
                }
                catch
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("******************** Unos datuma nije dobar! ********************");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
        }

        internal static float UcitajDecimalniBroj(string poruka, int min, float max)
        {
            float b;
            while (true)
            {
                try
                {
                    Console.Write(poruka + ": ");
                    b = float.Parse(Console.ReadLine());
                    if (b < min || b > max)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("Decimalni broj mora biti u rasponu {0} i {1}", min, max);
                    Console.WriteLine("*****************************************************************");
                }
            }
        }

        internal static int UcitajRasponBroja(string poruka, int min, int max)
        {
            int b;
            while (true)
            {
                try
                {
                    Console.Write(poruka + ": ");
                    b = int.Parse(Console.ReadLine());
                    if (b < min || b > max)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("Unos nije dobar, unos mora biti u rasponu {0} do {1}", min, max);
                    Console.WriteLine("*****************************************************************");
                }
            }
        }

        internal static string UcitajString(string poruka, int max, bool obavezno)
        {
            string s;
            while (true)
            {
                Console.Write(poruka + ": ");
                s = Console.ReadLine().Trim();
                if ((obavezno && s.Length == 0) || s.Length > max)
                {
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    Console.WriteLine("*****************************************************************");
                    continue;
                }
                return s;
            }
        }

        internal static string UcitajString(string stara, string poruka, int max, bool obavezno)
        {
            string s;
            while (true)
            {
                Console.Write(poruka + " (" + stara + "): ");
                s = Console.ReadLine().Trim();
                if (s.Length == 0)
                {
                    return stara;
                }
                if ((obavezno && s.Length == 0) || s.Length > max)
                {
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    Console.WriteLine("*****************************************************************");
                    continue;
                }
                return s;
            }
        }
    }
}

