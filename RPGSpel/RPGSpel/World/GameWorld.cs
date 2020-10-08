using System;

namespace PepsiMan
{
    class GameWorld
    {

        private string[,] Grid;  // Fields som skapas för 2D-Array och dess kolumner och rader. 
        private int Rows;
        private int Cols;

        public GameWorld(string[,] grid) // KONSTRUKTOR med 2D-Array som parameter. 2D-Arrayen skapas i "Game"-klassen.
        {                                // Rows och Cols int värde får vi genom att kalla på GetLength metoden.
            Grid = grid;                 // Som är en Array klass metod, metoden räknar ut en dimensionlängd.  
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        // Ritar ut 2D-Arrayen. Yttre for - går genom Y-led och inre for - går denom X-led. 
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.Write(element);
                }
            }
            Console.WriteLine("Non Interactable Characters:");
        }

        // Denna metod tar fram Spelarens tillfälliga position. 
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        // Kollar om spelaren rör sig på en giltlig position. Hindrar spelaren från att sig genom väggen.
        // Argumentet är spelarens nuvarande position.
        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }

            return Grid[y, x] == " ";
        }
    }
}
