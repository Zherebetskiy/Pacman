using PacmanLibrary.Interfaces;
using System.Timers;

namespace PacmanLibrary.Ghosts
{
    public class Inky : Ghost
    {
        Blinky blinky;
        IField field;
        public Inky(Blinky blinky, IField field)
        {
            this.field = field;
            this.blinky = blinky;
            StartPosition();
            home = new Position(field.Width, field.Height);

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
            position = oldPosition = new Position(11, 12);
            nextItem = new EmptyBlock(11, 12);
            field.ChangedField[position.X, position.Y] = this;
            behavior = Behavior.chase;
        }

        public override Position ChasingPoint(Pacman pacman)
        {
            return new Position((2 * pacman.X - blinky.X) % field.Width, (2 * pacman.Y - blinky.Y) % field.Height);
        }
    }
}
