using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(35, 22);
            Console.SetBufferSize(35, 22);                
            Console.CursorVisible = false;
            Console.WriteLine("Press any Key to start");
            Console.ReadKey();
            Game game = new Game();
            game.Start();
        }


    }
}
