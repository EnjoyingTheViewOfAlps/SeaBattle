using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Board
    {
        protected char[,] grid;

        public Board()
        {
            grid = new char[10, 10];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }


        public void Print(bool showShips)
        {
            Console.WriteLine("   A B C D E F G H I J");
            Console.WriteLine("  ---------------------");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i} |");

                for (int j = 0; j < 10; j++)
                {
                    if (grid[i, j] == 'S' && !showShips)
                        Console.Write("  ");
                    else
                        Console.Write($"{grid[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public bool PlaceShip(int size)
        {
            Random random = new Random();
            int direction = random.Next(2);

            if (direction == 0) // горизонтальное расположение
            {
                int row = random.Next(10);
                int col = random.Next(10 - size + 1);

                for (int i = 0; i < size; i++)
                {
                    if (grid[row, col + i] != ' ')
                        return false;
                }

                for (int i = 0; i < size; i++)
                {
                    grid[row, col + i] = 'S';
                }
            }
            else // вертикальное расположение
            {
                int row = random.Next(10 - size + 1);
                int col = random.Next(10);

                for (int i = 0; i < size; i++)
                {
                    if (grid[row + i, col] != ' ')
                        return false;
                }

                for (int i = 0; i < size; i++)
                {
                    grid[row + i, col] = 'S';
                }
            }

            return true;
        }

        public bool Shoot(int row, int col)
        {
            if (grid[row, col] == ' ')
            {
                grid[row, col] = 'O'; // промах
                return false;
            }
            else if (grid[row, col] == 'S')
            {
                grid[row, col] = 'X'; // попадание
                return true;
            }

            return false;
        }

        public bool AllShipsSunk()
        {
            foreach (char cell in grid)
            {
                if (cell == 'S')
                    return false;
            }

            return true;
        }
    }
}