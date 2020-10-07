using System;

namespace PepsiMan
{
    class Chest : Positions
    {
        public string ChestMarker;
        public ConsoleColor ChestColor;

        public Chest(int intX, int intY)
        {
            X = intX;
            Y = intY;
            ChestMarker = "\x2580";
            ChestColor = ConsoleColor.Yellow;
        }

        public void Draw()
        {
            Console.ForegroundColor = ChestColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(ChestMarker);
            Console.ResetColor();
        }
    }
}
