using PacmanLibrary.Foods;
using PacmanLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PacmanLibrary
{
    public class Pacman : IMovable, IPoint
    {
        int score;
        IPoint[,] field; 
        Direction Direction;
        Direction oldMoving;
        Position position;
        Position oldPosition;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Direction CurrentMoving
        {
            get { return Direction; }
            set { Direction = value; }
        }

        public Direction OldMoving
        {
            get { return oldMoving; }
            set { oldMoving = value; }
        }

        public Position Position { get { return position; } }

        public Position OldPosition { get { return oldPosition; } }

        public int X
        {
            get { return position.X; }
        }

        public int Y
        {
            get { return position.Y; }
        }

        public Pacman(IPoint[,] field)
        {
            this.field =  field;
            position = new Position(23, 14);
            oldPosition = new Position(23, 14);
            StartPosition();
        }

        public void StartPosition()
        {
            field[position.X, position.Y] = new EmptyBlock(position.X, position.Y);
            field[oldPosition.X, oldPosition.Y] = new EmptyBlock(oldPosition.X, oldPosition.Y);
            position = new Position(23, 14);
            oldPosition = new Position(23, 14);
            Direction = Direction.left;
            oldMoving = Direction.stop;
            field[position.X, position.Y] = this;
        }

        public void IncreaseScore(int score)
        {
            this.score += score;
        }

        public void StopMoving()
        {
            Direction = Direction.stop;
            oldMoving = Direction.stop;
        }

        public void Go(object o)
        {
            oldPosition = position;

            switch (CurrentMoving)
            {
                case Direction.left:
                    if (!( field[X, Y - 1] is Wall))
                    {
                        MoveLeft();
                        OldMoving = Direction.stop;
                    }
                    else if ( field[X, Y - 1] is Wall)
                    {
                        GoForvard(field);
                    }
                    break;
                case Direction.right:
                    if (!( field[X, Y + 1] is Wall))
                    {
                        MoveRight();
                        OldMoving = Direction.stop;
                    }
                    else if ( field[X, Y + 1] is Wall)
                    {
                        GoForvard(field);
                    }
                    break;
                case Direction.up:
                    if (!( field[X - 1, Y] is Wall))
                    {
                        MoveUp();
                        OldMoving = Direction.stop;
                    }
                    else if ( field[X - 1, Y] is Wall)
                    {
                        GoForvard(field);
                    }
                    break;
                case Direction.down:
                    if (!( field[X + 1, Y] is Wall))
                    {
                        MoveDown();
                        OldMoving = Direction.stop;
                    }
                    else if ( field[X + 1, Y] is Wall)
                    {
                        GoForvard(field);
                    }
                    break;
                case Direction.stop:
                    break;
                default:
                    break;
            }
        }

        void GoForvard(IPoint[,] field)
        {
            switch (OldMoving)
            {
                case Direction.left:
                    if ( field[X, Y - 1] is Wall)
                    {
                        StopMoving();
                    }
                    else
                    {
                        MoveLeft();
                    }
                    break;
                case Direction.right:
                    if ( field[X, Y + 1] is Wall)
                    {
                        StopMoving();
                    }
                    else
                    {
                        MoveRight();
                    }
                    break;
                case Direction.up:
                    if ( field[X - 1, Y] is Wall)
                    {
                        StopMoving();
                    }
                    else
                    {
                        MoveUp();
                    }
                    break;
                case Direction.down:
                    if ( field[X + 1, Y] is Wall)
                    {
                        StopMoving();
                    }
                    else
                    {
                        MoveDown();
                    }
                    break;
                case Direction.stop:
                    break;
                default:
                    break;
            }
        }

        public void MoveLeft()
        {
            position.Y -= 1;
        }

        public void MoveRight()
        {
            position.Y += 1;
        }

        public void MoveUp()
        {
            position.X -= 1;
        }

        public void MoveDown()
        {
            position.X += 1;
        }
    }
}
