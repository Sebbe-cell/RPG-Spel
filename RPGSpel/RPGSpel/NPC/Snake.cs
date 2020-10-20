using PepsiMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGSpel.NPC
{
    class Snake : Positions
    {
        public string SnakeMarker;
        public ConsoleColor SnakeColor;

        public Snake(int intX, int intY)
        {
            X = intX;
            Y = intY;
            SnakeMarker = "\x02ad";
            SnakeColor = ConsoleColor.White;
        }

        public void Draw()
        {
            Console.ForegroundColor = SnakeColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(SnakeMarker);
            Console.ResetColor();
        }
    }
}
