using System;
using System.Collections.Generic;

namespace Snake
{
    public class Food
    {
        public Point Location;

        public Food()
        {  
            Location = new Point();

        }

        private void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Point oldCursorLocation = new Point(Console.CursorTop, Console.CursorLeft);
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write("F");
            Console.SetCursorPosition(oldCursorLocation.X, oldCursorLocation.Y);
            Console.ForegroundColor = ConsoleColor.White;


        }

        public void Spawn(List<SnakeBodyPart> snakeBodyParts)
        {
            bool same = false;
            do
            {
                Random random = new Random();
                Location.X = random.Next(1, 20);
                Location.Y = random.Next(1, 20);
                foreach (SnakeBodyPart part in snakeBodyParts)
                {
                    if (part.Location == Location)
                    {
                        same = true;
                    }
                }

            } while (same);
            Despawn();
            Draw();
        }

        private void Despawn()
        {
            Point oldCursorLocation = new Point(Console.CursorTop, Console.CursorLeft);
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(" ");
            Console.SetCursorPosition(oldCursorLocation.X, oldCursorLocation.Y);
        }
    }
}
