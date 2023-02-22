using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenicekMaleC3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string volba;
            Databaze databaze = new Databaze();
            databaze.Import();



            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Deníček malého poseroutky C3\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Menu: \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Přidat zápiseček: ");
                Console.WriteLine("2. Vypsat vše");
                Console.WriteLine("3. Vypsat tajné zápisečky");
                Console.WriteLine("4. Smazat zápiseček");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("k. Konec");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Tvoje volba: ");

                volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        databaze.Pridat();
                        Console.WriteLine("Pokačuj libovolnou klávesou");
                        Console.ReadKey();
                        break;
                    case "2":
                        databaze.VypsatVerejne();
                        Console.WriteLine("Pokačuj libovolnou klávesou");
                        Console.ReadKey();
                        break;
                    case "3":
                        databaze.VypsatSoukrome();
                        Console.WriteLine("Pokačuj libovolnou klávesou");
                        Console.ReadKey();
                        break;
                    case "4":
                        databaze.Smazat();
                        break;
                    case "k":
                        break;
                    default:
                        Console.WriteLine("Zadal jsi špatnou volbu, pokačuj libovolnou klávesou");
                        Console.ReadKey();
                        break;
                }
            } while (volba != "k");
            databaze.Export();
        }
    }
}
