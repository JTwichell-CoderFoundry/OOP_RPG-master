using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class AleHouse
    {
        public List<Ale> Ales { get; set; }
        public Game Game { get; set; }
        public Shop Shop { get; set; }

        public AleHouse(Game game, Shop shop)
        {
            Ales = new List<Ale>();
            Game = game;
            Shop = shop;

            for (var loop = 1; loop <= 2; loop++)
            {
                Ales.Add(new Ale("WhaleHead Lager", "16 oz", 4, .1));
                Ales.Add(new Ale("WhaleHead Lager", "32 oz", 7, .2));

                Ales.Add(new Ale("Viking's Hair Stout", "16 oz", 3, .15));
                Ales.Add(new Ale("Viking's Hair Stout", "32 oz", 5, .3));

                Ales.Add(new Ale("Mermaid's Breath Ale", "16 oz", 5, .2));
                Ales.Add(new Ale("Mermaid's Breath Ale", "32 oz", 9, .4));

                Ales.Add(new Ale("Rat Sweat Broth", "16 oz", 2, .25));
                Ales.Add(new Ale("Rat Sweat Broth", "32 oz", 3, .5));

                Ales.Add(new Ale("Pillage Dark", "16 oz", 10, .3));
                Ales.Add(new Ale("Pillage Dark", "32 oz", 19, .6));
                Ales.Add(new Ale("Pillage Dark", "48 oz", 27, .9));
            }
            Ales = Ales.OrderBy(a => a.Name).ToList();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Ale House, please make a selection.");
            Console.WriteLine("1. Buy Ale");
            Console.WriteLine("2. Back to Shop Menu");
            Console.WriteLine("3. Back to Main Menu");
           
            var selection = "";
            do
            {
                Console.Write("Enter selection: ");
                selection = Console.ReadLine();
            } while (string.IsNullOrEmpty(selection));

            switch(selection)
            {
                case "1":
                    Sell();
                    break;
                case "2":
                    Shop.Menu();
                    break;
                case "3":
                    Game.MainMenu();
                    break;
            }

            Menu();
        }

        public void Sell()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("-- Please select from our extensive list of Ales --");
            Console.WriteLine("---------------------------------------------------");

            var count = 1;
            foreach(var ale in Ales)
            {
                Console.WriteLine($"{count}. {ale.Name} - Size: {ale.Size}, Cost: {ale.Cost}, Strength: {ale.Strength}");
                count++;
            }

            Console.Write("Enter your selection: ");

            var selection = "";
            do
            {
                selection = Console.ReadLine();
            } while (string.IsNullOrEmpty(selection));

            var intSelection = Convert.ToInt32(selection);
            if(intSelection < 1 || intSelection > Ales.Count())
            {
                Console.WriteLine($"{selection} is an invalid selection, please try again.");
                Sell();
            }

            if(Game.Hero.Gold < Ales[intSelection - 1].Cost)
            {
                Console.WriteLine($"Sorry, you do not have enough Gold to buy the {Ales[intSelection - 1].Name}");
                Console.WriteLine($"Your Gold: {Game.Hero.Gold}");
                Console.WriteLine($"Cost of a {Ales[intSelection - 1].Size} {Ales[intSelection - 1].Name}: {Ales[intSelection - 1].Cost}");

            }
            else
            {
                Game.Hero.BAC += Ales[intSelection - 1].Strength;
                Console.WriteLine("Thank you for your patronage!");
                Console.WriteLine($"Drinking {Ales[intSelection - 1].Name} has added {Ales[intSelection - 1].Strength} to {Game.Hero.Name}'s BAC");
                Console.WriteLine($"{Game.Hero.Name}'s BAC level is now {Game.Hero.BAC}");
            }

            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }

    }

    public class Ale
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int Cost { get; set; }
        public double Strength { get; set; }

        public Ale(string name, string size, int cost, double strength)
        {
            Name = name;
            Size = size;
            Cost = cost;
            Strength = strength;
        }
    }
}
