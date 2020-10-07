using System;

namespace PepsiMan
{
    class Enemy : Positions
    {
        public string EnemyMarker;
        public ConsoleColor EnemyColor;

        // Deklarerar X & Y variablarna för att sedan i Draw() ge dom en plats i spelvärlden via X & Y variablarna
        // Initierar även EnemyMarker & Color (I detta fall ger vi dom en unik karaktär och färg.
        public Enemy(int intX, int intY) // Konstruktor
        {
            X = intX;
            Y = intY;
            EnemyMarker = "\x046a";
            EnemyColor = ConsoleColor.Red;
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
