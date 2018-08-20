using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacmanLibrary
{
    public static class DirectionAlgorithm 
    {
       static Random random;
       const int randomMax = 30;

       static public Direction BetterDirective(IPoint[,] field, Pacman pacman, Ghost ghost)
        {
            Dictionary<Direction, double> directions = new Dictionary<Direction, double>();

            if(IsNotWall(field[ghost.X, ghost.Y - 1]) && DirecctionIsAllow(ghost.CurrentMoving, Direction.right)) 
            {
                directions.Add(Direction.left, DefineDistance(ghost.X, ghost.Y - 1, pacman, ghost));
            }
            if (IsNotWall(field[ghost.X, ghost.Y + 1]) && DirecctionIsAllow(ghost.CurrentMoving, Direction.left))
            {
                directions.Add(Direction.right, DefineDistance(ghost.X, ghost.Y + 1, pacman, ghost));
            }
            if (IsNotWall(field[ghost.X - 1, ghost.Y]) && DirecctionIsAllow(ghost.CurrentMoving, Direction.down))
            {
                directions.Add(Direction.up, DefineDistance(ghost.X - 1, ghost.Y, pacman, ghost));
            }
            if (IsNotWall(field[ghost.X + 1, ghost.Y]) && DirecctionIsAllow(ghost.CurrentMoving, Direction.up))
            {
                directions.Add(Direction.down, DefineDistance(ghost.X + 1, ghost.Y, pacman, ghost));
            }

            return directions.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
        }

        static bool IsNotWall(IPoint point)
        {
            if (!(point is Wall))
            {
                return true;
            }

            return false;
        }

        static bool DirecctionIsAllow(Direction currentDirection, Direction notAllowedDirection)
        {
            if (currentDirection!= notAllowedDirection)
            {
                return true;
            }

            return false;
        }

       static double DefineDistance(int x, int y, Pacman pacman,Ghost ghost)
        {
            Position chasingPoint;
            switch (ghost.behavior)
            {
                case Behavior.chase:
                    chasingPoint = ghost.ChasingPoint(pacman);
                    break;
                case Behavior.scatter:
                    chasingPoint = ghost.ChasingPoint();
                    break;
                case Behavior.frightened:
                    random = new Random();
                    chasingPoint = new Position(random.Next(randomMax), random.Next(randomMax));
                    break;
                default:
                    chasingPoint = new Position(0, 0);
                    break;
            }

            return Distance.Solve(chasingPoint.X, chasingPoint.Y, x, y);
        }
    }
}
