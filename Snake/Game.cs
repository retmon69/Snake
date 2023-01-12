using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Snake
{
    public class Game
    {
        Snake snake = new Snake();
        Food food = new Food();
        Map map = new Map();

        public Game()
        {
            food.Spawn(snake.parts);
        }
        public void Start()
        {
            ConsoleKey input = ConsoleKey.D;
            string direction = "Right";
            string oldDirection = direction;
            string bufferDirection = direction;
            map.IntializeWall();

            while (true)
            {
                oldDirection = direction;

                map.Draw(Console.CursorLeft, Console.CursorTop, snake.Length);

                do
                {  
                    snake.Move(direction);
                    snake.Crash(map);
                    food = snake.Eat(food);
                    Thread.Sleep(200);
                } while (!Console.KeyAvailable);
                input = Console.ReadKey(true).Key;
                map.Draw(Console.CursorLeft, Console.CursorTop, snake.Length);


                switch (input)
                {
                    case ConsoleKey.D:
                        bufferDirection = "Right";
                        break;
                    case ConsoleKey.A:
                        bufferDirection = "Left";
                        break;
                    case ConsoleKey.W:
                        bufferDirection = "Up";
                        break;
                    case ConsoleKey.S:
                        bufferDirection = "Down";

                        break;
                }

                if (snake.CheckDirection(bufferDirection, oldDirection))
                {
                    direction = bufferDirection;
                }
                
            }
        }
    }
}
