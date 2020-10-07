using PepsiMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGSpel.NPC
{
    class Shopkeep : Positions
    {
        public string EnemyMarker;
        public ConsoleColor EnemyColor;

        public Shopkeep(int intX, int intY)
        {
            X = intX;
            Y = intY;
            EnemyMarker = "\x20a9";
            EnemyColor = ConsoleColor.DarkMagenta;
        }

        public void Draw()
        {
            Console.ForegroundColor = EnemyColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(EnemyMarker);
            Console.ResetColor();
        }
    }
}
