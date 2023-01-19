using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{


    public class Snake
    {
        public List<SnakeBodyPart> parts;
        public int Length;
        

        public Snake()
        {
            parts = new List<SnakeBodyPart>();
            parts = new List<SnakeBodyPart>();
            parts.Add(new SnakeBodyPart(new Point(10,10), "Right"));
            SnakeBodyPart head = parts[0];
            parts.Add(new SnakeBodyPart(new Point(head.Location.X - 1, head.Location.Y), head.Direction));
            Length = parts.Count;
            Draw();
        }

        public Food Eat(Food food)
        {
            if (parts[0].Location.CompareTo(food.Location))
            {
                food.Despawn();
                Delete(parts);
                
                SnakeBodyPart lastPart = parts[parts.Count - 1];
                Point newLocation = new Point();
                switch (lastPart.Direction)
                {
                    case "Right":
                        newLocation = new Point(lastPart.Location.X - 1, lastPart.Location.Y);
                        parts.Add(new SnakeBodyPart(newLocation, lastPart.Direction));
                        break;
                    case "Left":
                        newLocation = new Point(lastPart.Location.X + 1, lastPart.Location.Y);
                        parts.Add(new SnakeBodyPart(newLocation, lastPart.Direction));
                        break;
                    case "Up":
                        newLocation = new Point(lastPart.Location.X, lastPart.Location.Y + 1);
                        parts.Add(new SnakeBodyPart(newLocation, lastPart.Direction));
                        break;
                    case "Down":
                        newLocation = new Point(lastPart.Location.X, lastPart.Location.Y - 1);
                        parts.Add(new SnakeBodyPart(newLocation, lastPart.Direction));
                        break;
                }               
                Draw();
                Thread.Sleep(1);
                food.Spawn(parts);
                Length = parts.Count;
                return food;
            }
            return food;

        }

        private void Draw()
        {
            int count = 0;
            
            foreach (SnakeBodyPart part in parts)
            {
                if (count == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else 
                   Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(part.Location.X, part.Location.Y);
                Console.Write("O");    
                count++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Delete(List<SnakeBodyPart> bodyparts)
        {
            Point bufferPos = new Point(Console.CursorTop, Console.CursorLeft);
            foreach (SnakeBodyPart part in bodyparts)
            {
                Console.SetCursorPosition(part.Location.X, part.Location.Y);
                Console.WriteLine(" ");
            }
            Console.SetCursorPosition(bufferPos.X, bufferPos.Y);
        }

        public void Move(string direction)
        {
            SnakeBodyPart head = parts[0];
            Point newLocation = new Point();

            Delete(parts);
            switch (direction)
            {
                case "Right":
                    newLocation = new Point(head.Location.X + 1, head.Location.Y);
                    break;
                case "Left":
                    newLocation = new Point(head.Location.X - 1, head.Location.Y);
                    break;
                case "Up":
                    newLocation = new Point(head.Location.X, head.Location.Y - 1);
                    break;
                case "Down":
                    newLocation = new Point(head.Location.X, head.Location.Y + 1);
                    break;
            }
            UpdateBodyLocations();
            parts[0] = new SnakeBodyPart(newLocation, direction);            
            Draw();



        }

        public bool CheckDirection(string direction, string oldDirection)
        {
            if (direction == "Right" && oldDirection == "Left")
            {
                return false;
            }
            else if (direction == "Left" && oldDirection == "Right")
            {
                return false;
            }
            else if (direction == "Up" && oldDirection == "Down")
            {
                return false;
            }
            else if (direction == "Down" && oldDirection == "Up")
            {
                return false;
            }
            return true;
        }

        public void Crash(Map map)
        {
            foreach (Point block in map.Wall)
            {
                if (parts[0].Location.CompareTo(block))
                {
                    Environment.Exit(0);
                }
            }
            for (int i = 1; i < parts.Count - 1; i++)
            {
                if (parts[0].Location.CompareTo(parts[i].Location))
                {
                    Environment.Exit(0);
                }
            }
        }
       
        private void UpdateBodyLocations()
        {
            for (int i = parts.Count - 1; i > 0; i--)
            {
                parts[i] = parts[i - 1];
            }
        }
    }
}
