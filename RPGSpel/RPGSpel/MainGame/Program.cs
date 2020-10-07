using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Security.Cryptography;
using System.Net;
using System.Data.SqlTypes;

namespace PepsiMan
{
    class Program
    {
        public static PlayerAttributes currentPlayer = new PlayerAttributes();

        public static void Main(string[] args)
        {
            Game currentGame = new Game();
            currentGame.Start();
        }
    }

    // Deklarerar ett par variablar som bestämmer position för spelaren, varelserna samt objekten i spelet.
    abstract class Positions
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
}
