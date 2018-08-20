namespace PacmanLibrary.Interfaces
{
    public interface IGame
    {
        void PlayGame(object o);
        IPoint[,] Field { get; }
        void GameOver();
        void ChangeDirection(string key);

        bool SaveScore { get; set; }

        int Score { get; }
        int Lifes { get; }
        int Points { get; set; }
    }
}
