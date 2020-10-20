using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsiMan
{
    class Stable : Positions
    {
        public string StableMarker;
        public ConsoleColor StableColor;

        // Deklarerar X & Y variablarna för att sedan i Draw() ge dom en plats i spelvärlden via X & Y variablarna
        // Initierar även EnemyMarker & Color (I detta fall ger vi dom en unik karaktär och färg.
        public Stable(int intX, int intY) // Konstruktor
        {
            X = intX;
            Y = intY;
            StableMarker = "\x03e0";
            StableColor = ConsoleColor.White;
        }

        // Ritar ut karaktären i spelvärlden, i detta fall en fiende.
        public void Draw()
        {
            Console.ForegroundColor = StableColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(StableMarker);
            Console.ResetColor();
        }
    }
}
