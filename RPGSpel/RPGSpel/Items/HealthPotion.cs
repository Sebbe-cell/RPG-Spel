using System;

namespace PepsiMan
{
    // Klassen för HP. 
    class HealthPotion : Positions
    {
        public string HPMarker;
        public ConsoleColor HPColor;

        public HealthPotion(int intX, int intY) // Konstruktor. argument för body och färg finsn med. 
                                        // man skriver in argument för positionsparametrar. Dessa är statiska. 
        {
            X = intX;
            Y = intY;
            HPMarker = "\x0488";
            HPColor = ConsoleColor.Cyan;
        }

        public void Draw() // ritar ut healthpotion på kartan, efter bestämd position från konstruktor. 
        {
            Console.ForegroundColor = HPColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(HPMarker);
            Console.ResetColor();
        }
    }
}
