using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsiMan
{
    class Pet : Positions
    {
        public string PetMarker;
        public ConsoleColor PetColor;

        public Pet(int intX, int intY)
        {
            X = intX;
            Y = intY;
            PetMarker = "\x2302";
            PetColor = ConsoleColor.White;
        }

        public void Draw()
        {
            Console.ForegroundColor = PetColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PetMarker);
            Console.ResetColor();
        }
    }
}
