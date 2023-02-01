using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenicekMaleC3
{
    internal class Zapisecek
    {
        public string Nadpis { get; private set; }
        public string Text { get; private set; }
        public bool Zamceno { get; private set; }
        public DateTime DatumVlozeni { get; private set; }

        public Zapisecek(string nadpis, string text, bool zamceno, DateTime datumVlozeni)
        {
            Nadpis = nadpis;
            Text = text;
            Zamceno = zamceno;
            DatumVlozeni = datumVlozeni;
        }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DatumVlozeni + "\t Nadpis: " + Nadpis);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();
        }
    }
}

