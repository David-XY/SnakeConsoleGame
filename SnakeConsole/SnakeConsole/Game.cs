using System;
using System.Diagnostics;

namespace SnakeConsole
{
    class Game
    {
        static void Main(string[] args)
        {
            /* Setup */
            Console.CursorVisible = false;

            // Values that can be modified
            const int snakeStartingSize = 4;
            const int fieldSizeX = 80;
            const int fieldSizeY = 25;
            const int gameSpeed = 50;

            // Create all objects
            var playField = new PlayField(fieldSizeX , fieldSizeY);
            var snake = new Snake(snakeStartingSize, playField);
            var apple = new Apple(snake, playField);
            var controller = new Controller(snake);
            var collision = new Collision(snake, playField, apple, controller);

            // Spawn first Apple
            apple.SpawnApple();

            /* Mainloop */
            while (true)
            {
                // Stopwatch to set ingame delay
                var sw = Stopwatch.StartNew();
                for (int i = 0;  sw.ElapsedMilliseconds <= gameSpeed; i++)
                {
                    if (i == 0)
                    {
                        // Get Keyboard Input
                        controller.GetInputDirection();
                    }
                }
                // Refresh the PlayField
                playField.ClearConsole();

                // Move the Snake according to the given direction
                controller.MoveSnake();

                // Check for collisions
                collision.CheckPlayfieldCollision();
                collision.CheckAppleCollision();

                // If the snake overlapped itself show GameOver screen
                if (collision.CheckSnakeCollision())
                {
                    playField.DrawGameOver(snake.Joints);
                    
                    // If enter is hit application will be closed or if R is hit the game will restart itself
                    if (IsGameOver())
                    {
                        Environment.Exit(1);
                    }
                    else
                    {
                        // Recreate all objects
                        playField = new PlayField(fieldSizeX, fieldSizeY);
                        snake = new Snake(snakeStartingSize, playField);
                        apple = new Apple(snake, playField);
                        controller = new Controller(snake);
                        collision = new Collision(snake, playField, apple, controller);

                        // Spawn first Apple
                        apple.SpawnApple();
                    }  
                }
                else
                {
                    snake.DrawSnake();
                    apple.DrawApple();
                }
            }
        }
        // Returns wether the User pressed R or Enter
        static bool IsGameOver()
        {
            bool IsGameOver = false;
            var pressedKey = Console.ReadKey(true).Key;

            while (pressedKey != ConsoleKey.R)
            {
                if (pressedKey == ConsoleKey.Enter)
                {
                    IsGameOver = true;
                    break;
                }
                else if (pressedKey == ConsoleKey.R)
                {
                    IsGameOver = false;
                }
                else
                {
                    pressedKey = Console.ReadKey(true).Key;
                }
            }
            return IsGameOver;
        }
    }
}
