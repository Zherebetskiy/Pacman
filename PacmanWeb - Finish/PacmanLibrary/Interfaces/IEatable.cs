namespace PacmanLibrary.Interfaces
{
    public interface IEatable : IPoint
    {
        void BeEatenByPacman(Pacman pacman, Game game=null);
        int Score { get; }
    }
}
