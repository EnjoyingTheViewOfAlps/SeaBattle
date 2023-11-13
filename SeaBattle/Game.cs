using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Game
    {
        private Player player;
        private Player opponent;
        private int attempts;

        public Game()
        {
            player = new Player("Игрок");
            opponent = new Player("Противник");

            // Расставляем корабли для игрока и противника
            player.Board.PlaceShip(3);
            opponent.Board.PlaceShip(3);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{player.Name}, ваше поле:");
                player.Board.Print(true);

                Console.WriteLine($"{opponent.Name}, поле противника:");
                opponent.Board.Print(false);

                Console.Write("Введите координаты выстрела (например, A3): ");
                string input = Console.ReadLine().ToUpper();

                if (input.Length == 2 && input[0] >= 'A' && input[0] <= 'J' && input[1] >= '0' && input[1] <= '9')
                {
                    int row = input[1] - '0';
                    int col = input[0] - 'A';

                    bool hit = opponent.Board.Shoot(row, col);

                    if (hit)
                        Console.WriteLine("Попадание!");
                    else
                        Console.WriteLine("Промах!");

                    attempts++;

                    if (opponent.Board.AllShipsSunk())
                    {
                        Console.Clear();
                        Console.WriteLine($"Поздравляем, {player.Name}! Вы выиграли!");
                        player.Board.Print(true);
                        Console.WriteLine($"Количество попыток: {attempts}");
                        break;
                    }

                    Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите координаты в формате A3.");
                    Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                    Console.ReadLine();
                }
            }
        }
    }
}
