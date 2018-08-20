namespace PacmanLibrary
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position position1, Position position2)
        {
            if (position1.X == position2.X && position1.Y == position2.Y)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Position position1, Position position2)
        {
            if (position1.X != position2.X && position1.Y != position2.Y)
            {
                return true;
            }

            return false;
        }
    }
}
