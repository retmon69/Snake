using System;
using System.Collections.Generic;

namespace Snake
{
    public class Map
    {
        public List<Point> Wall = new List<Point>();
        public void Draw(int x, int y, int score)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("---------------------");
            Console.SetCursorPosition(0, 21);
            Console.Write("---------------------");
            for (int i = 0; i <= 21; i++)
            {
                Console.SetCursorPosition(21, i);
                Console.Write("|");
            }
            for (int i = 0; i <= 21; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(x, y);
            Score(score);
        }
       
        public void IntializeWall()
        {
            for (int i = 0; i <= 21; i++)
            {
                Wall.Add(new Point(i, 21));
            }
            for (int i = 0; i <= 21; i++)
            {
                Wall.Add(new Point(i, 0));
            }
            for (int i = 0; i <= 21 ; i++)
            {
                Wall.Add(new Point(21, i));
            }
            for (int i = 0; i <= 21; i++)
            {
                Wall.Add(new Point(0, i));
            }
        }

        private void Score(int score)
        {
            if (score <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (score <= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (score <= 150)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            
            Point point = new Point(Console.CursorLeft, Console.CursorTop);
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Score: " + score);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
