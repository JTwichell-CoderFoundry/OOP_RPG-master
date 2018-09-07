using System;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; set; }
        public Shop Shop { get; set; }
        public AleHouse AleHouse { get; set; }

        public Game() {
            Shop = new Shop(this);
            Hero = new Hero(this, this.Shop);
            AleHouse = new AleHouse(this, Shop);
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
            Console.WriteLine("5. Equip Armor");
            Console.WriteLine("6. Equip Weapon");
            Console.WriteLine("7. Visit Ale House");
            Console.WriteLine("8. Quit");

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
                case "5":
                    EquipArmor();
                    break;
                case "6":
                    EquipWeapon();
                    break;
                case "7":
                    AleHouse.Menu();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    return;
            }
        }
        
        private void EquipArmor()
        {
            if (Hero.ArmorsBag.Count == 0)
                Console.WriteLine("You have no Armor to equip");
            else
            {
                var count = 1;
                Console.WriteLine("-- Here is your Armor selection --");
                foreach(var armor in Hero.ArmorsBag)
                {
                    Console.WriteLine($"{count}. {armor.Name} - Defense: {armor.Defense}");
                    count++;
                }

                var selection = "";
                do
                {
                    Console.Write("Which Armor would you like to equip?");
                    selection = Console.ReadLine();
                } while (string.IsNullOrEmpty(selection));

                var intSelection = Convert.ToInt32(selection);
                if(intSelection < 1 || intSelection > Hero.ArmorsBag.Count)
                {
                    Console.WriteLine("That is an invalid selection, please try again");
                    EquipArmor();
                }
                else
                {
                    var armor = Hero.ArmorsBag[intSelection - 1];
                    Hero.EquippedArmor = armor;
                    Console.WriteLine($"You have equipped yourself with {armor.Name} and gained {armor.Defense} Defense");
                    Hero.ArmorsBag.Remove(armor);
                    Hero.Defense += armor.Defense;
                }
            }
            MainMenu();

        }

        private void EquipWeapon()
        {
            if (Hero.WeaponsBag.Count == 0)
                Console.WriteLine("You have no Weapons to equip");
            else
            {
                var count = 1;
                foreach (var weapon in Hero.WeaponsBag)
                {
                    Console.WriteLine($"{count}. {weapon.Name} - Strength: {weapon.Strength}");
                    count++;
                }

                var selection = "";
                do
                {
                    Console.Write("Which Weapon would you like to equip?");
                    selection = Console.ReadLine();
                } while (string.IsNullOrEmpty(selection));

                var intSelection = Convert.ToInt32(selection);
                if (intSelection < 1 || intSelection > Hero.WeaponsBag.Count)
                {
                    Console.WriteLine("That is an invalid selection, please try again");
                    EquipWeapon();
                }
                else
                {
                    var weapon = Hero.WeaponsBag[intSelection - 1];
                    Hero.EquippedWeapon = weapon;
                    Console.WriteLine($"You have equipped yourself with the {weapon.Name} and gained {weapon.Strength} Strength");
                    Hero.WeaponsBag.Remove(weapon);
                    Hero.Strength += weapon.Strength;
                }
            }
            MainMenu();
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