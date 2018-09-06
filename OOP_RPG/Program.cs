using System;

namespace OOP_RPG
{
    public class Program
    {
        public static void Main() 
        {            
            var game = new Game();
            game.Start();

            Console.ReadKey();   
        }
    }
}