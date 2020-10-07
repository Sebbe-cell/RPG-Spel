using System;

namespace PepsiMan
{
    class Armor : Positions
    {
        public string ArmorMarker;
        public ConsoleColor ArmorColor;

        public Armor(int intX, int intY)
        {
            X = intX;
            Y = intY;
            ArmorMarker = "\x20aa";
            ArmorColor = ConsoleColor.DarkGray;
        }

        public void Draw()
        {
            Console.ForegroundColor = ArmorColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(ArmorMarker);
            Console.ResetColor();
        }
    }
}
