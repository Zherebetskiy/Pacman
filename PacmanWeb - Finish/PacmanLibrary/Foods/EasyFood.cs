using PacmanLibrary.Interfaces;

namespace PacmanLibrary.Foods
{
    public class EasyFood : IEatable
    {
        const int score = 10;
        Position position;

        public EasyFood(int x, int y)
        {
            position = new Position(x, y);
        }

        public int Score
        {
            get { return score; }
        }

        public int X
        {
            get { return position.X; }
        }

        public int Y
        {
            get { return position.Y; }
        }

        public void BeEatenByPacman(Pacman pacman, Game game = null)
        {
            pacman.IncreaseScore(score);
            game.Points--;
        }
    }
}
