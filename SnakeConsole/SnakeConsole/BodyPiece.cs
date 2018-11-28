using System;

namespace SnakeConsole
{
    class BodyPiece
    {
        // Fields
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int PrevPosX { get; private set; }
        public int PrevPosY { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public BodyPiece(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        // Movement handling
        public void Move(int x, int y)
        {
            PrevPosX = PosX;
            PrevPosY = PosY;

            PosX = x;
            PosY = y;
        }
         
        // Console drawing
        public void DrawHeadPiece()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('■');
        }

        public void DrawBodyPiece()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write('■');
        }
    }
}
