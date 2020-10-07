using System;

namespace PepsiMan
{
    class GameWorld
    {

        private string[,] Grid;
        private int Rows;
        private int Cols;

        public GameWorld(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

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

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        // Kollar om spelaren rör sig på en giltlig position
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
