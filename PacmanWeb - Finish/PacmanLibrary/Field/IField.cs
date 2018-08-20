namespace PacmanLibrary.Interfaces
{
    public interface IField
    {
        IPoint[,] ChangedField { get; set; }
        IPoint[,] CurrentField { get; set; }
        int Width { get; }
        int Height { get; }
        string FileUrl { get; }
        int Points { get; }
            
        void PrintField(object o);
        void InitializeField();
    }
}
