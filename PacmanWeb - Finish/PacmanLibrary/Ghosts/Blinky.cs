using PacmanLibrary.Interfaces;
using System.Timers;

namespace PacmanLibrary.Ghosts
{
    public class Blinky : Ghost
    {
        IField field;
        public Blinky(IField field)
        {
            this.field = field;
            StartPosition();
            home = new Position(0, field.Height);

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
            position = oldPosition = new Position(11, 14);
            nextItem = new EmptyBlock(11, 14);
            field.ChangedField[position.X, position.Y] = this;
            behavior = Behavior.chase;
        }

        public override Position ChasingPoint(Pacman pacman)
        {
            return new Position(pacman.X, pacman.Y);
        }
    }
}
