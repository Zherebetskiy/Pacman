using PacmanLibrary.Foods;
using PacmanLibrary.Ghosts;
using PacmanLibrary.Interfaces;
using System;

namespace PacmanLibrary
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(IPoint[,] field)
        {
            Console.Clear();
            Console.ResetColor();

            for (int i = 0; i <  field.GetLength(0); i++)
            {
                for (int j = 0; j <  field.GetLength(1); j++)
                {
                    if ( field[i, j] is Clyde)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(3);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ( field[i, j] is Inky)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(3);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ( field[i, j] is Pinky)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(3);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ( field[i, j] is Blinky)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(3);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ( field[i, j] is Wall)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(3);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ( field[i, j] is EmptyBlock)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(3);
                    }
                    else if ( field[i, j] is Pacman)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(3);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ( field[i, j] is EasyFood)
                    {                       
                        Console.Write("*");
                    }
                    else if ( field[i, j] is SuperFood)
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
