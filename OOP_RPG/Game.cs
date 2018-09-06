using System;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; set; }
        public Shop Shop { get; set; }

        public Game() {
            Hero = new Hero();
            Shop = new Shop(this);
        }
            
        public void Start() {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");
            Hero.Name = Console.ReadLine();

            //Console.WriteLine("Hello " + hero.Name);
            //Console.WriteLine(string.Concat("Hello ", hero.Name));
            //Console.WriteLine(string.Format("Hello {0}", hero.Name));
            Console.WriteLine($"Hello {Hero.Name}");

            MainMenu();
        }
        
        public void MainMenu() {
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Go To Weapons Shop");

            Console.Write("Enter your selection: ");
            var input = Console.ReadLine();

            #region Old If Else If Else code
            //if (input == "1")
            //{
            //    this.Stats();
            //}
            //else if (input == "2")
            //{
            //    this.Inventory();
            //}
            //else if (input == "3")
            //{
            //    this.Fight();
            //}
            //else
            //{
            //    return;
            //}
            #endregion

            switch (input)
            {
                case "1":
                    Stats();
                    break;
                case "2":
                    Inventory();
                    break;
                case "3":
                    Fight();
                    break;
                case "4":
                    Shop.Menu();
                    break;
                default:
                    return;
            }
        }
        
        private void Stats() {
            Hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.MainMenu();
        }
        
        public void Inventory(){
            Hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.MainMenu();
        }
        
        public void Fight(){
            //var monsters = new List<Monster>();
            //monsters.Add(new Monster("Squid", 9, 8, 20));
            //monsters.Add(new Monster("Goblin", 10, 10, 10));
            //monsters.Add(new Monster("Ghost", 5, 2, 1));
            //monsters.Add(new Monster("Ghoul", 15, 15, 8));

            //var fight = new Fight(this.hero, this, monsters, new Monster("Gargamel", 12,5,3));

            var myMonster = new Monster("Gargamel", 12, 5, 3, 20);           
            var fight = new Fight(Hero, this, myMonster);
            
            fight.Start();
        }
        

    }
}