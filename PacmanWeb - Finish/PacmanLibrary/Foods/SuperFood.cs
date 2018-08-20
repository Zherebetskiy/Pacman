using PacmanLibrary.Interfaces;

namespace PacmanLibrary.Foods
{
    public class SuperFood : IEatable
    {
        const int score = 50;
        Position position;

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

        public SuperFood(int x, int y)
        {
            position = new Position(x, y);
        }

        public void BeEatenByPacman(Pacman pacman, Game game)
        {
            pacman.IncreaseScore(score);
            game.Points--;
            game.ChangeBehaviorOnFrightened();
        }
    }
}
