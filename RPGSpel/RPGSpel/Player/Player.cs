using System;

namespace PepsiMan
{
    class Player : Positions
    {
        // skapar variabler för spelarens body och färg. 
        public string PlayerMarker;
        public ConsoleColor PlayerColor;




        public Player(int initialX, int initialY) // KONTRUKTOR med X/Y positioner som parameter. 
                                                  // spelaren får en startposition,  
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "\x263a";
            PlayerColor = ConsoleColor.Green;

        }

        // Ritar upp spelaren i världen
        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
    }
}
