using System;
using System.Text;

namespace SnakeConsole
{
    class PlayField
    {
        // Fields
        public int Width { get; private set; }
        public int Height { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public PlayField(int width, int height)
        {
            Width = width;
            Height = height;

            WindowAdjust();
            DrawField();
        }

        // Console-Window adjustement
        private void WindowAdjust()
        {
            Console.SetWindowSize(Width+1, Height+1);
            Console.SetBufferSize(Width+1, Height+1);
        }

        // Console drawing
        public void DrawField()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(HorizontalBorder());

            for (int i = 3; i <= Height; i++)
            {
                Console.WriteLine(VerticalBorder());
            }
            Console.WriteLine(HorizontalBorder());
        }

        private string HorizontalBorder()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= Width; i++)
            {
                sb.Append("■");
            }
            return sb.ToString();
        }

        private string VerticalBorder()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= Width; i++)
            {
                if (i == 1 || i == Width)
                {
                    sb.Append("█");
                }
                else
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        // Draw GameOver-Screen
        public void DrawGameOver(int score)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Width - 16) / 2, (Height / 2) - 2);
            Console.Write("Achieved Score: " + score);
            Console.SetCursorPosition((Width - 8) / 2, Height / 2);
            Console.Write("Game Over");
            Console.SetCursorPosition((Width - 22) / 2, (Height / 2) + 1);
            Console.Write("R: Restart | Enter: Quit");
        }

        // Console Refresher
        public void ClearConsole()
        {
            for (int i = 1; i <= Height-2; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', Width-2));
            }
        }
    }
}
