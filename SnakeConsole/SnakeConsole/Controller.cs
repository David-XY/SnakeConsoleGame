using System;

namespace SnakeConsole
{
    class Controller
    {
        // Attributes
        public Snake Snake { get; set; }
        public Direction CurrentDirection { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snake"></param>
        public Controller(Snake snake)
        {
            CurrentDirection = Direction.Right;
            Snake = snake;
        }

        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        // Reads Arrowkey inputs and returns the direction
        public Direction GetInputDirection()
        {
            if (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == ConsoleKey.UpArrow && CurrentDirection != Direction.Down)
                {
                    CurrentDirection = Direction.Up;
                }
                else if (pressedKey == ConsoleKey.DownArrow && CurrentDirection != Direction.Up)
                {
                    CurrentDirection = Direction.Down;
                }
                else if (pressedKey == ConsoleKey.LeftArrow && CurrentDirection != Direction.Right)
                {
                    CurrentDirection = Direction.Left;
                }
                else if (pressedKey == ConsoleKey.RightArrow && CurrentDirection != Direction.Left)
                {
                    CurrentDirection = Direction.Right;
                }
            }
            return CurrentDirection;
        }

        // Moves the snake based on the current direction attribute
        public void MoveSnake()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Snake.MoveUp();
                    break;
                case Direction.Down:
                    Snake.MoveDown();
                    break;
                case Direction.Left:
                    Snake.MoveLeft();
                    break;
                case Direction.Right:
                    Snake.MoveRight();
                    break;
            }
        }
    }
}
