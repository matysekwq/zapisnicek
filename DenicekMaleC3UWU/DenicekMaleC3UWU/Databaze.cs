using System;
using System.Collections.Generic;
using System.IO;
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
            // dočasně - vložení pár záznamů po startu
            zapisnik.Add(new Zapisecek("prvni poznamka", "text první poznamky", true, DateTime.Now));
            zapisnik.Add(new Zapisecek("Druha poznamka", "text druhé poznamky", false, DateTime.Now));
            zapisnik.Add(new Zapisecek("Třetí poznamka", "text třetí poznamky", true, DateTime.Now));
            zapisnik.Add(new Zapisecek("Čtvrtá poznamka", "text čtvrté poznamky", true, DateTime.Now));
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

        public void VypsatVerejne()
        {
            foreach (Zapisecek zapisecek in zapisnik)
            {
                if (zapisecek.Zamceno == false)
                {
                    zapisecek.Info();
                }
            }
        }

        public void VypsatSoukrome()
        {
            if (KontrolaHesla())
            {
                foreach (Zapisecek zapisecek in zapisnik)
                {
                    if (zapisecek.Zamceno == true)
                    {
                        zapisecek.Info();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Špatné heslo, pokračuj libovolnou klávesou....");
                Console.ResetColor();
                Console.ReadKey();
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

        public void Smazat()
        {
            int odpoved = CislovanySeznam();

            if (zapisnik[odpoved].Zamceno)
            {
                if (KontrolaHesla())
                {
                    zapisnik.RemoveAt(odpoved);
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Špatné heslo, pokračuj libovolnou klávesou....");
                    Console.ResetColor();
                    Console.ReadKey();

                }
            }
            else
            {
                zapisnik.RemoveAt(odpoved);
            }
        }

        int CislovanySeznam()
        {
            int index = 1;

            foreach (Zapisecek zapisecek in zapisnik)
            {
                if (zapisecek.Zamceno)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(index + ". " + zapisecek.Nadpis);
                    Console.ResetColor();
                    index++;
                }
                else
                {
                    Console.WriteLine(index + ". " + zapisecek.Nadpis);
                    index++;
                }
            }
            Console.Write("Který záznam chceš smazat?: ");
            int hodnota = int.Parse(Console.ReadLine());
            hodnota--;

            return hodnota;
        }
        // metoda vyexportuje celý obsah do textového souboru
        // každý záznam na samostném řádku, hodnoty odděleny středníkem
        public void Export()
        {
            StreamWriter zapis = new.StreamWriter("data.txt");
            foreach (Zapisecek zapisecek in zapisnik)
            {
                zapis.WriteLine(zapisecek.Nadpis + ";" + zapisecek.Text + ";" + zapisecek.Zamceno + ";" + zapisecek.DatumVlozeni);
            }

            zapis.Close();
        }
    }
}
