using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsiMan
{
    class QuestGiver : Positions
    {
        public string QuestGiverMarker;
        public ConsoleColor QuestGiverColor;

        // Deklarerar X & Y variablarna för att sedan i Draw() ge dom en plats i spelvärlden via X & Y variablarna
        // Initierar även EnemyMarker & Color (I detta fall ger vi dom en unik karaktär och färg.
        public QuestGiver(int intX, int intY) // Konstruktor
        {
            X = intX;
            Y = intY;
            QuestGiverMarker = "\x20b9";
            QuestGiverColor = ConsoleColor.DarkMagenta;
        }

        // Ritar ut karaktären i spelvärlden, i detta fall en fiende.
        public void Draw()
        {
            Console.ForegroundColor = QuestGiverColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(QuestGiverMarker);
            Console.ResetColor();
        }
    }
}
