using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public enum Direction { left, right, up, down, stop }

    public class  Field : IField
    {
        int points;
        IPoint[,] changedField;
        IReader reader;
        IParser parser;
        IPrinter printer;
        
        public int Points { get { return points; } }

        public IPoint[,] ChangedField
        {
            get { return changedField; }
            set { changedField = value; }
        }

        public IPoint[,] CurrentField { get; set; }

        public string FileUrl { get; } = @"C:\Users\zhere\OneDrive\Документи\pacman\PacmanConsole\field2.txt";
        public int Width { get; } = 30;

        public int Height { get; } = 27;

        public Field(IReader reader, IParser parser, IPrinter printer = null)
        {
            CurrentField = new IPoint[Width + 1, Height + 1];
            changedField = new IPoint[Width + 1, Height + 1];
            this.reader = reader;
            this.parser= parser;
            this.printer = printer;

            InitializeField();

            for (int i = 0; i < changedField.GetLength(0); i++)
            {
                for (int j = 0; j < changedField.GetLength(1); j++)
                {
                    CurrentField[i,j] = changedField[i,j];
                }
            }
        }

        public void InitializeField()
        {
            string text = reader.Read(FileUrl);
            parser.ParseToMtr(ref changedField, ref points, text);           
        }

        public void PrintField(object o)
        {
            printer.Print(changedField);
        }
    }
}
