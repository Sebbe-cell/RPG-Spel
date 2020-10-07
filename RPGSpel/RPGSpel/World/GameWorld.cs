using System;

namespace PepsiMan
{
    class GameWorld
    {

        private string[,] Grid;  // fields som skapas för 2d array och dess kolumner och rader. 
        private int Rows;
        private int Cols;

        public GameWorld(string[,] grid) // KONSTRUKTOR med 2dArray som parameter. 2dArrayen skapas i "Game"klassen.
        {                                // rows och cols int värde fås genom att kalla på Getlength metoden.
            Grid = grid;                 // som är en Array klass metod, metoden räknar ut en dimensionlängd. 
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw() // ritar ut 2dArrayen. Yttre for - går genom y led och inte for - går denom X led. 
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

        public string GetElementAt(int x, int y) // denna metod tar fram Spelarens tillfälliga position. 
        {
            return Grid[y, x];
        }

        // Kollar om spelaren rör sig på en giltlig position. Hindrar spelaren från att sig genom väggen.
        // argumentet är spelarens nuvarande position.
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
