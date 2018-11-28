using System;

namespace SnakeConsole
{
    class Apple
    {
        // Fields
        public int PosX { get; set; }
        public int PosY { get; set; }
        public PlayField PlayField { get; set; }
        public Snake Snake { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snake"></param>
        /// <param name="playField"></param>
        public Apple(Snake snake, PlayField playField)
        {
            Snake = snake;
            PlayField = playField;
        }

        public void SpawnApple()
        {
            var rndX = new Random();
            var rndY = new Random();
            PosX = rndX.Next(2, PlayField.Width-2);
            PosY = rndY.Next(2, PlayField.Height-2);

            foreach (var bodyPiece in Snake.BodyPieces)
            {
                if (bodyPiece.PosX == PosX && bodyPiece.PosY == PosY)
                {
                    PosX = rndX.Next(2, PlayField.Width - 2);
                    PosY = rndY.Next(2, PlayField.Height - 2);
                }
                else
                {
                    DrawApple();
                }
            }
        }

        public void DrawApple()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write('■');
        }
    }
}
