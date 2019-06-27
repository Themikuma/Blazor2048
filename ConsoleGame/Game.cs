using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Models
{
    public class Game
    {
        private const int GAME_SIZE = 4;

        public const int FOUR_CHANCE = 20;
        public int[,] GameField { get; private set; }
        public Game()
        {
            this.GameField = StartNewGame();
        }
        public int[,] StartNewGame()
        {
            int[,] field = new int[GAME_SIZE, GAME_SIZE];
            AddRandomNumbers(2, field);
            return field;
        }

        private void AddRandomNumbers(int count, int[,] gameField)
        {
            Random random = new Random();
            for (int i = 0; i < count;)
            {
                int x = random.Next(GAME_SIZE);
                int y = random.Next(GAME_SIZE);
                if (gameField[x, y] == 0)
                {
                    gameField[x, y] = random.Next(100) < FOUR_CHANCE ? 4 : 2;
                    i++;
                }
            }
        }

        public void MoveUp()
        {
            bool changed = false;
            for (int i = 0; i < GAME_SIZE; i++)
            {
                int found = 0;
                for (int j = 0; j < GAME_SIZE; j++)
                {
                    if (GameField[j, i] != 0)
                    {
                        if (found != 0 && GameField[found - 1, i] == GameField[j, i])
                        {
                            GameField[found - 1, i] += GameField[j, i];
                            GameField[j, i] = 0;
                            changed = true;
                            found--;
                        }
                        else if (found != j)
                        {
                            GameField[found, i] = GameField[j, i];
                            GameField[j, i] = 0;
                            changed = true;
                        }
                        found++;
                    }
                }
            }
            if (changed)
            {
                AddRandomNumbers(1, this.GameField);
            }
        }
        public void MoveDown()
        {
            bool changed = false;
            for (int i = 0; i < GAME_SIZE; i++)
            {
                int found = 0;
                for (int j = GAME_SIZE - 1; j >= 0; j--)
                {
                    if (GameField[j, i] != 0)
                    {
                        if (found != 0 && GameField[GAME_SIZE - found, i] == GameField[j, i])
                        {
                            GameField[GAME_SIZE - found, i] += GameField[j, i];
                            GameField[j, i] = 0;
                            changed = true;
                            found--;
                        }
                        else if (found != (GAME_SIZE - 1) - j)
                        {
                            GameField[GAME_SIZE - (found + 1), i] = GameField[j, i];
                            GameField[j, i] = 0;
                            changed = true;
                        }
                        found++;
                    }
                }
            }
            if (changed)
            {
                AddRandomNumbers(1, this.GameField);
            }
        }
        public void MoveRight()
        {
            bool changed = false;
            for (int i = 0; i < GAME_SIZE; i++)
            {
                int found = 0;
                for (int j = GAME_SIZE - 1; j >= 0; j--)
                {
                    if (GameField[i, j] != 0)
                    {
                        if (found != 0 && GameField[i, GAME_SIZE - found] == GameField[i, j])
                        {
                            GameField[i, GAME_SIZE - found] += GameField[i, j];
                            GameField[i, j] = 0;
                            changed = true;
                            found--;
                        }
                        else if (found != (GAME_SIZE - 1) - j)
                        {
                            GameField[i, GAME_SIZE - (found + 1)] = GameField[i, j];
                            GameField[i, j] = 0;
                            changed = true;
                        }
                        found++;
                    }
                }
            }
            if (changed)
            {
                AddRandomNumbers(1, this.GameField);
            }
        }

        public void MoveLeft()
        {
            bool changed = false;
            for (int i = 0; i < GAME_SIZE; i++)
            {
                int found = 0;
                for (int j = 0; j < GAME_SIZE; j++)
                {
                    if (GameField[i, j] != 0)
                    {
                        if (found != 0 && GameField[i, found - 1] == GameField[i, j])
                        {
                            GameField[i, found - 1] += GameField[i, j];
                            GameField[i, j] = 0;
                            changed = true;
                            found--;
                        }
                        else if (found != j)
                        {
                            GameField[i, found] = GameField[i, j];
                            GameField[i, j] = 0;
                            changed = true;
                        }
                        found++;
                    }
                }
            }
            if (changed)
            {
                AddRandomNumbers(1, this.GameField);
            }
        }
    }
}
