namespace PacmanLibrary
{
    public class EmptyBlock : IPoint
    {
        const int score = 0;
        Position position;

        public int X
        {
            get { return position.X; }
        }

        public int Y
        {
            get { return position.Y; }
        }

        public EmptyBlock(int x, int y)
        {
            position = new Position(x, y);
        }
    }
}
