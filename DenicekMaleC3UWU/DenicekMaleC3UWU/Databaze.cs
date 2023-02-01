using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenicekMaleC3
{
    internal class Databaze
    {
        // konstanta - specielní typ "proměnné" do které se na začátku uloží hodnota
        // a v průběhu programu ji nelze měnit
        const string heslo = "heslo";

        public List<Zapisecek> zapisnik { get; private set; }

        public Databaze()
        {
            zapisnik = new List<Zapisecek>();
        }

        public void Pridat()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Zadej nadpis zápisečku: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string nadpis = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Zadej text zápisečku: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string text = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Má být zápis soukromý? a/n: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string odpoved = Console.ReadLine();
            Console.ResetColor();

            switch (odpoved)
            {
                case "a":
                    if (KontrolaHesla())
                    {
                        zapisnik.Add(new Zapisecek(nadpis, text, true, DateTime.Now));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Zápiseček byl vložen, pokračuj libovolnou klávesou...");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zadal jsi špatné heslo, pokračuj zmáčknutím libovolné klávesy");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    break;
                case "n":
                    zapisnik.Add(new Zapisecek(nadpis, text, false, DateTime.Now));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Zápiseček byl vložen, pokračuj libovolnou klávesou...");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Špatná odpověď, zadej a nebo n.");
                    Console.WriteLine("Pokračuj libovolnou klávesou....");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

        }

        bool KontrolaHesla()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Zadej heslo: ");
            Console.ForegroundColor = ConsoleColor.Black;

            string zadaneHeslo = Console.ReadLine();

            if (heslo == zadaneHeslo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

