using PacmanLibrary.Foods;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Parser : IParser
    {
        public void ParseToMtr(ref IPoint[,] field, ref int points, string text)
        {
            int i = 0, j = 0;
            foreach (var row in text.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    //for super food
                    if (int.Parse(col.Trim()) == 9)
                    {
                         field[i, j] = new SuperFood(i, j);
                        points++;
                    }
                    else
                    // for easy food
                    if (int.Parse(col.Trim()) == 0)
                    {
                         field[i, j] = new EasyFood(i, j);
                        points++;
                    }
                    else
                    // for wall
                    if (int.Parse(col.Trim()) == 1)
                    {
                         field[i, j] = new Wall(i, j);
                    }
                    else
                    //for empty block
                    if (int.Parse(col.Trim()) == 2)
                    {
                         field[i, j] = new EmptyBlock(i, j);
                    }
                    else
                    {
                        field[i, j] = new Wall(i, j);
                    }
                    j++;
                }
                i++;
            }
        }
    }
}
