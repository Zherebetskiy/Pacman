using PacmanLibrary.Interfaces;
using System.Timers;

namespace PacmanLibrary.Ghosts
{
    public class Pinky : Ghost
    {
        const int chasingLength = 4;
        IField field;
        public Pinky(IField field)
        {
            this.field = field;
            StartPosition();
            home = new Position(0, 0);

            chaseTimer.Elapsed += new ElapsedEventHandler(ChangeBehaviorOnChase);
            chaseTimer.Enabled = true;

            frightTimer.Elapsed += new ElapsedEventHandler(ChangeBehaviorOnFrightened);
            frightTimer.Enabled = false;

            scaterTimer.Elapsed += new ElapsedEventHandler(ChangeBehaviorOnScater);
            scaterTimer.Enabled = false;
        }

        public override void StartPosition()
        {
            field.ChangedField[position.X, position.Y] = nextItem;
            position = oldPosition = new Position(11, 13);
            nextItem = new EmptyBlock(11, 13);
            field.ChangedField[position.X, position.Y] = this;
            behavior = Behavior.chase;

        }

        public override Position ChasingPoint(Pacman pacman)
        {
            Position chasingPoint = new Position(15, 15);

            switch (pacman.CurrentMoving)
            {
                case Direction.left:
                    chasingPoint = GetChasingPointLeft(pacman);
                    break;
                case Direction.right:
                    chasingPoint = GetChasingPointRight(pacman);
                    break;
                case Direction.up:
                    chasingPoint = GetChasingPointUp(pacman);
                    break;
                case Direction.down:
                    chasingPoint = GetChasingPointDown(pacman);
                    break;
                case Direction.stop:
                    break;
                default:
                    break;
            }

            return chasingPoint;
        }

        Position GetChasingPointDown(Pacman pacman)
        {
            if (pacman.X + chasingLength > field.Width)
                return new Position(pacman.X + chasingLength, pacman.Y);

            return new Position(field.Width, pacman.Y);
        }

        Position GetChasingPointUp(Pacman pacman)
        {
            if (pacman.X - chasingLength > 0)
                return new Position(pacman.X - chasingLength, pacman.Y);

            return new Position(1, pacman.Y);
        }

        Position GetChasingPointRight(Pacman pacman)
        {
            if (pacman.Y + chasingLength > field.Height)
                return new Position(pacman.X, pacman.Y + chasingLength);

            return new Position(pacman.X, field.Height);
        }

        Position GetChasingPointLeft(Pacman pacman)
        {
            if (pacman.Y - chasingLength > 0)
                return new Position(pacman.X, pacman.Y - chasingLength);

            return new Position(pacman.X, 1);
        }
    }
}
