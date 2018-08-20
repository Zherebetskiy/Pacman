namespace PacmanLibrary.Interfaces
{
    public interface IParser
    {
       void ParseToMtr(ref IPoint[,] field, ref int points, string text);
    }
}
