using PacmanLibrary.Interfaces;
using System;
using System.Timers;

namespace PacmanLibrary.Ghosts
{
    public class Clyde : Ghost
    {
        IField field;
        public Clyde(IField field)
        {
            this.field = field;
            StartPosition();
            home = new Position(field.Width, 0);

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
            position = oldPosition = new Position(11, 11);
            nextItem = new EmptyBlock(11, 11);
            field.ChangedField[position.X, position.Y] = this;
            behavior = Behavior.chase;
        }

        public override Position ChasingPoint(Pacman pacman)
        {
            if (Math.Sqrt(Math.Pow((pacman.X - X), 2) + Math.Pow((pacman.Y - Y), 2)) <= 13)
                return new Position(pacman.X, pacman.Y);
            else
                return new Position(0, field.Height);
        }     
    }
}
