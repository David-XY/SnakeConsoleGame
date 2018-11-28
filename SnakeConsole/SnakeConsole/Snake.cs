using System.Collections.Generic;

namespace SnakeConsole
{
    class Snake
    {
        // Fields
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Joints { get; private set; }
        public List<BodyPiece> BodyPieces { get; private set; }
        public PlayField PlayField { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="joints"></param>
        /// <param name="playField"></param>
        public Snake(int joints, PlayField playField)
        {
            Joints = joints;
            PlayField = playField;
            PosX = (PlayField.Width)/2;
            PosY = (PlayField.Height)/2;

            // Create BodyPieces based on number of Joints
            BodyPieces = new List<BodyPiece>();
            for (int i = 0; i < Joints; i++)
            {
                BodyPieceCreate(PosX - i, PosY);
            }
            DrawSnake();
        }

        // Movement handling
        public void MoveUp() {
            PosY--;
            MoveBodyPieces();
        }
        public void MoveDown() {
            PosY++;
            MoveBodyPieces();
        }
        public void MoveLeft() {
            PosX--;
            MoveBodyPieces();
        }
        public void MoveRight() {
            PosX++;
            MoveBodyPieces();
        }

        // Move SnakeHead to specified location
        public void MoveHeadTo(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        // Joints/Size incrementor
        public void EatApple()
        {
            Joints++;
            BodyPieceCreate(BodyPieces[BodyPieces.Count-1].PosX, BodyPieces[BodyPieces.Count - 1].PosY);
        }

        public void BodyPieceCreate(int x, int y)
        {
            BodyPieces.Add(new BodyPiece(x, y));
        }

        // Manages movement of BodyPieces
        public void MoveBodyPieces()
        {
            int PrevX = PosX, PrevY = PosY;

            foreach (BodyPiece bodyPiece in BodyPieces)
            {
                bodyPiece.Move(PrevX, PrevY);

                PrevX = bodyPiece.PrevPosX;
                PrevY = bodyPiece.PrevPosY;
            }
        }

        public void DrawSnake()
        {
            foreach(BodyPiece bodyPiece in BodyPieces)
            {
                if(bodyPiece.Equals(BodyPieces[0]))
                {
                    bodyPiece.DrawHeadPiece();
                }
                else
                {
                    if (bodyPiece.PosX != 0 && bodyPiece.PosX != PlayField.Width-1 && bodyPiece.PosY != 0 && bodyPiece.PosY != PlayField.Height-1)
                    {
                        bodyPiece.DrawBodyPiece();
                    }
                }
            }
        }
    }
}
