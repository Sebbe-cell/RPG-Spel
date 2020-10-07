using System;

namespace PepsiMan
{
    class Enemy : Positions
    {
        public string EnemyMarker;
        public ConsoleColor EnemyColor;

        public Enemy(int intX, int intY)
        {
            X = intX;
            Y = intY;
            EnemyMarker = "\x046a";
            EnemyColor = ConsoleColor.Red;
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
