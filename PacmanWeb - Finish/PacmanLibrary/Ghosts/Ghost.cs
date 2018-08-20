using PacmanLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace PacmanLibrary
{ 
    public abstract class Ghost : IMovable, IEatable
    {
        protected Position home;
        protected Position position;
        protected Position oldPosition;
        protected Timer chaseTimer = new Timer(10000);
        protected Timer scaterTimer = new Timer(4000);
        protected Timer frightTimer = new Timer(5000);

        protected Timer escaped = new Timer(400);

        public Behavior behavior = Behavior.chase;

        public IPoint nextItem { get; set; } = new Wall(0, 0);

        public Position Position { get { return position; } }

        public Position OldPosition { get { return oldPosition; } }

        //IAlgorithm algorithm;

        //public IAlgorithm Algorithm { set { algorithm = value; } }

        public Direction CurrentMoving { get; private set; } = Direction.stop;

        public int X
        {
            get { return position.X; }
        }

        public int Y
        {
            get { return position.Y; }
        }

        public int Score { get; } = 200;

        public abstract Position ChasingPoint(Pacman pacman);

        public abstract void StartPosition();

        public void Go(Pacman pacman, IPoint[,] field)
        {
            if (field[position.X, position.Y] is Ghost)
            {
                Ghost ghost = (Ghost)field[position.X, position.Y];
                field[position.X, position.Y] = ghost.nextItem;
            }
            else
            {
                field[position.X, position.Y] = nextItem;
            }

            oldPosition = position;

            switch (DirectionAlgorithm.BetterDirective(field, pacman,this))
            {
                case Direction.left:
                    MoveLeft();
                    break;
                case Direction.right:
                    MoveRight();
                    break;
                case Direction.up:
                    MoveUp();
                    break;
                case Direction.down:
                    MoveDown();
                    break;
                default:
                    break;
            }

            nextItem = field[position.X, position.Y];
            field[position.X, position.Y] = this;
        }

        public Position ChasingPoint()
        {
            return new Position(home.X, home.Y);
        }

        //double DefineDistance(int x, int y, Pacman pacman)
        //{
        //    Position chasingPoint;
        //    switch (behavior)
        //    {
        //        case Behavior.chase:
        //            chasingPoint = ChasingPoint(pacman);
        //            break;
        //        case Behavior.scatter:
        //            chasingPoint = ChasingPoint();
        //            break;
        //        case Behavior.frightened:
        //            random = new Random();
        //            chasingPoint = new Position(random.Next(randomMax), random.Next(randomMax));
        //            break;
        //        default:
        //            chasingPoint = new Position(0, 0);
        //            break;
        //    }

        //    return Distance.Solve(chasingPoint.X, chasingPoint.Y, x, y);
        //}

        //protected Direction BetterDirective(IPoint[,] field, Pacman pacman)
        //{
        //    Dictionary<Direction, double> directions = new Dictionary<Direction, double>();

        //    if (!(field[position.X, position.Y - 1] is Wall) && CurrentMoving != Direction.right)
        //    {
        //        directions.Add(Direction.left, DefineDistance(position.X, position.Y - 1, pacman));
        //    }
        //    if (!(field[position.X, position.Y + 1] is Wall) && CurrentMoving != Direction.left)
        //    {
        //        directions.Add(Direction.right, DefineDistance(position.X, position.Y + 1, pacman));
        //    }
        //    if (!(field[position.X - 1, position.Y] is Wall) && CurrentMoving != Direction.down)
        //    {a
        //        directions.Add(Direction.up, DefineDistance(position.X - 1, position.Y, pacman));
        //    }
        //    if (!(field[position.X + 1, position.Y] is Wall) && CurrentMoving != Direction.up)
        //    {
        //        directions.Add(Direction.down, DefineDistance(position.X + 1, position.Y, pacman));
        //    }

        //    return directions.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
        //}

        public void MoveLeft()
        {
            position.Y -= 1;
            CurrentMoving = Direction.left;
        }

        public void MoveRight()
        {
            position.Y += 1;
            CurrentMoving = Direction.right;
        }

        public void MoveUp()
        {
            position.X -= 1;
            CurrentMoving = Direction.up;
        }

        public void MoveDown()
        {
            position.X += 1;
            CurrentMoving = Direction.down;
        }

        public void BeEatenByPacman(Pacman pacman, Game game)
        {
            if (behavior == Behavior.frightened)
            {
                pacman.IncreaseScore(Score);
                StartPosition();
            }
            else
            {
                EatPacman(game);
            }
        }

        public void EatPacman(Game game)
        {
            game.LoseLife();
        }

        public void ChangeBehaviorOnFrightened(object o, EventArgs e)
        {
            chaseTimer.Enabled = false;
            scaterTimer.Enabled = false;
            frightTimer.Enabled = true;

            behavior = Behavior.frightened;

            chaseTimer.Enabled = true;
            frightTimer.Enabled = false;
        }

        protected void ChangeBehaviorOnChase(object o, EventArgs e)
        {
            frightTimer.Enabled = false;
            scaterTimer.Enabled = false;
            chaseTimer.Enabled = true;

            behavior = Behavior.chase;

            scaterTimer.Enabled = true;
            chaseTimer.Enabled = false;
        }

        protected void ChangeBehaviorOnScater(object o, EventArgs e)
        {
            frightTimer.Enabled = false;
            chaseTimer.Enabled = false;
            scaterTimer.Enabled = true;

            behavior = Behavior.scatter;

            scaterTimer.Enabled = false;
            chaseTimer.Enabled = true;

        }

    }
}
