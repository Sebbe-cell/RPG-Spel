using System;

namespace speltest
{
    class Note : Positions
    {
        public string NoteMarker;
        public ConsoleColor NoteColor;

        public Note(int intX, int intY)
        {
            X = intX;
            Y = intY;
            NoteMarker = "\x25b2";
            NoteColor = ConsoleColor.White;
        }

        public void Draw()
        {
            Console.ForegroundColor = NoteColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(NoteMarker);
            Console.ResetColor();
        }
    }
}
