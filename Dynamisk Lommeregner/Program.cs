using System;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamisk_Lommeregner
{

    class Program
    {
        static void Main(string[] args)
        {
            bool power = true;
            while (power)
            {
                Console.Clear();

                Console.WriteLine("Hej og velkommen til lommeregner 3000\n");
                Console.WriteLine("1. Brug lommeregner");
                Console.WriteLine("2. Afslut\n");

                

                //Brugeren vælger 
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        lommeregner();
                        break;
                    case ConsoleKey.D2:
                        Environment.Exit(1);
                        break;
                    default:
                        Console.Write("Du klikkede ikke på en af de viste muligere, genstarter program");
                        Thread.Sleep(100);
                        break;
                }


            }

        }

        static void lommeregner()
        {
            List<double> brugerTal = new List<double>();
            List<int> tegn = new List<int>();

            Console.WriteLine("Skriv et tal: ");
            brugerTal.Add(UserStringToDouble());

            bool power = true;
            while (power)
            {
                Console.WriteLine("Skriv et tal: ");
                brugerTal.Add(UserStringToDouble());
                tegn.Add(tegnChecker());
                

                Console.WriteLine("Forsæt? (Y / N)");
                string brugerInput = Console.ReadLine();
                if (brugerInput.ToLower() == "n")
                {
                    power = false;
                }

                udskrivStykke(brugerTal,tegn);
            }

            double res = udregner(brugerTal, tegn);
            Console.Write($"= {res}");

            Console.ReadKey();
        }

        static void udskrivStykke(List<double> brugertal, List<int> tegn)
        {
            int hej = 0;
            Console.Write("Her er dit regnestykke: ");
            for (int i = 0; i < brugertal.Count; i++)
            {
                Console.Write($"{brugertal[i]} ");

                for (int j = i; j < tegn.Count; j++)
                {
                    if (hej == 0)
                    {
                        Console.Write($"{getTegnToString(tegn[j])} ");
                        hej++;
                    }

                    
                }
                hej = 0;
            }
        }

        static double udregner(List<double> brugertal, List<int> tegn)
        {
            double res = brugertal[0];

            for (int i = 0; i < brugertal.Count - 1; i++)
            {
                switch (tegn[i])
                {
                    case 1:
                        res = res + brugertal[i + 1];
                        break;
                    case 2:
                        res = res - brugertal[i + 1];
                        break;
                    case 3:
                        res = res * brugertal[i + 1];
                        break;
                    case 4:
                        res = res / brugertal[i + 1];
                        break;
                }
            }

            return res;
        }

        static double UserStringToDouble()
        {
            double res;
            string userString = Console.ReadLine();
            while (!double.TryParse(userString, out res))
            {
                Console.WriteLine("Du skrev ikke et gyldigt tal, prøv igen");
                userString = Console.ReadLine();

            }

            return res;
        }

        static string getTegnToString(int tegn)
        {
            switch (tegn)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "/";
                default:
                    
                    return "";
            }
        }
        static int tegnChecker()
        {
            Console.WriteLine("1. + ");
            Console.WriteLine("2. - ");
            Console.WriteLine("3. * ");
            Console.WriteLine("4. / ");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
                case ConsoleKey.D4:
                    return 4;
                default:
                    Console.Write("Du klikkede ikke på en af de viste muligere, kan ikke beregne dit resultat, lukker programmet..");
                    Thread.Sleep(1000);
                    Environment.Exit(1);
                    return 0;
            }
        }
    }
    
}
