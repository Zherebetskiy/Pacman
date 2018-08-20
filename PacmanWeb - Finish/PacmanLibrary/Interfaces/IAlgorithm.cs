namespace PacmanLibrary
{
    public interface IAlgorithm
    {
        Direction BetterDirective(IPoint[,] field, Pacman pacman, Ghost ghost);
    }
}