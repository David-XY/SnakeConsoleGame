
namespace SnakeConsole
{
    class Collision
    {
        // Attributes
        public Snake Snake { get; set; }
        public PlayField PlayField { get; set; }
        public Apple Apple { get; set; }
        public Controller Controller { get; set; }
        public int BorderX { get; set; }
        public int BorderY { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snake"></param>
        /// <param name="playField"></param>
        /// <param name="apple"></param>
        /// <param name="controller"></param>
        public Collision(Snake snake, PlayField playField, Apple apple, Controller controller)
        {
            Snake = snake;
            PlayField = playField;
            Apple = apple;
            Controller = controller;
            BorderX = PlayField.Width;
            BorderY = PlayField.Height;
        }

        // Collision-Checks
        public void CheckAppleCollision()
        {
            if(Snake.PosX == Apple.PosX && Snake.PosY == Apple.PosY)
            {
                Snake.EatApple();
                Apple.SpawnApple();
            }
        }

        public void CheckPlayfieldCollision()
        {
            if (Snake.BodyPieces[0].PosX == 0)
            {
                Snake.MoveHeadTo(BorderX-1, Snake.PosY);
                Snake.MoveLeft();
            }
            else if (Snake.BodyPieces[0].PosX == BorderX-1)
            {
                Snake.MoveHeadTo(0, Snake.PosY);
                Snake.MoveRight();
            }
            else if (Snake.BodyPieces[0].PosY == 0)
            {
                Snake.MoveHeadTo(Snake.PosX, BorderY-1);
                Snake.MoveUp();
            }
            else if (Snake.BodyPieces[0].PosY == BorderY-1)
            {
                Snake.MoveHeadTo(Snake.PosX, 0);
                Snake.MoveDown();
            }
        }

        public bool CheckSnakeCollision()
        {
            bool IsCollision = false;

            foreach (var bodyPiece in Snake.BodyPieces)
            {
                if (bodyPiece != Snake.BodyPieces[0])
                {
                    if (Snake.BodyPieces[0].PosX == bodyPiece.PosX && Snake.BodyPieces[0].PosY == bodyPiece.PosY)
                    {
                        IsCollision = true;
                    }
                }
            }
            return IsCollision;
        }
    }
}
