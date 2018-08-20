namespace PacmanLibrary
{
    public class Wall : IPoint
    {
        Position position;

        public int X
        {
            get { return position.X; }
        }

        public int Y
        {
            get { return position.Y; }
        }

        public Wall(int x, int y)
        {
            position = new Position(x, y);
        }
    }
}
