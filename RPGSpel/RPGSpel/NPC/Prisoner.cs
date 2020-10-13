using PepsiMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGSpel.NPC
{
    class Prisoner : Positions
    {
        public string EnemyMarker;
        public ConsoleColor EnemyColor;

        // Deklarerar X & Y variablarna för att sedan i Draw() ge dom en plats i spelvärlden via X & Y variablarna
        // Initierar även EnemyMarker & Color (I detta fall ger vi dom en unik karaktär och färg.
        public Prisoner(int intX, int intY) // Konstruktor
        {
            X = intX;
            Y = intY;
            EnemyMarker = "\x20b0";
            EnemyColor = ConsoleColor.White;
        }

        // Ritar ut karaktären i spelvärlden, i detta fall en fiende.
        public void Draw()
        {
            Console.ForegroundColor = EnemyColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(EnemyMarker);
            Console.ResetColor();
        }
    }
}
