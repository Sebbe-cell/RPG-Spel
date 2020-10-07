using System;

namespace PepsiMan
{
    // Klassen för Kaststjärnor
    class Throwingstar : Positions
    {
        public string SpecialMarker;
        public ConsoleColor SpecialColor;

        public Throwingstar(int intX, int intY)
        {
            X = intX;
            Y = intY;
            SpecialMarker = "\x1D74";
            SpecialColor = ConsoleColor.Yellow;
        }

        public void Draw()
        {
            Console.ForegroundColor = SpecialColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(SpecialMarker);
            Console.ResetColor();
        }
    }
}
