using System;

namespace speltest
{
    // Klassen för HP
    class HealthPotion : Positions
    {
        public string HPMarker;
        public ConsoleColor HPColor;

        public HealthPotion(int intX, int intY)
        {
            X = intX;
            Y = intY;
            HPMarker = "\x0488";
            HPColor = ConsoleColor.Cyan;
        }

        public void Draw()
        {
            Console.ForegroundColor = HPColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(HPMarker);
            Console.ResetColor();
        }
    }
}
