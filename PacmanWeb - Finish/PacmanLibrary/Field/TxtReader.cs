using PacmanLibrary.Interfaces;
using System.IO;

namespace PacmanLibrary
{
    public class TxtReader : IReader
    {
        public string Read(string url)
        {
            return File.ReadAllText(url);
        }
    }
}
