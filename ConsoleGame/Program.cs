using BlazorWeb.Models;
using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game engine = new Game();
            engine.StartNewGame();
            while (true)
            {
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow: engine.MoveLeft(); break;
                    case ConsoleKey.RightArrow:  engine.MoveRight();break;
                    case ConsoleKey.UpArrow: engine.MoveUp();break;
                    case ConsoleKey.DownArrow: engine.MoveDown(); break;
                    default:
                        break;
                }
                Console.WriteLine();
                for (int i = 0; i < engine.GameField.GetLength(0); i++)
                {
                    for (int j = 0; j < engine.GameField.GetLength(1); j++)
                    {
                        Console.Write($"{engine.GameField[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
