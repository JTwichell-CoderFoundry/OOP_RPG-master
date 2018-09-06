using System;
using System.Collections.Generic;
using System.Linq;
namespace OOP_RPG
{
    public class Shop
    {
        public List<Armor> ArmorList { get; set; }
        public List<Weapon> WeaponsList { get; set; }
        public List<Potion> PotionsList { get; set; }

        //Here is where I can create a new property named ItemCatalog
        //that is of type Dictionary<string, object>. That means that
        //we will be storing a string as a key and an object of unknown type
        //as the value. We can then retrieve the object by searching the
        //Dictionary for a particular key.
        private Dictionary<string, object> ItemCatalog { get; set; }

        public Game Game { get; set; }

        public Shop(Game game)
        {
            this.ArmorList = new List<Armor>();
            this.WeaponsList = new List<Weapon>();
            this.PotionsList = new List<Potion>();
            this.ItemCatalog = new Dictionary<string, object>();
            this.Game = game;

            StockShop();

        }

        private void StockShop()
        {                    
            for(var loop = 1; loop <= 5; loop++)
            {
                //Add a bunch of Weapons to the Weapons list    
                WeaponsList.Add(new Weapon(10, 2, 3, "Sword"));
                WeaponsList.Add(new Weapon(12, 3, 4, "Axe"));
                WeaponsList.Add(new Weapon(20, 5, 7, "LongSword"));

                //Add a bunch of Armor to the Armor List           
                ArmorList.Add(new Armor(5, 1, 2, "Leather Armor"));
                ArmorList.Add(new Armor(10, 2, 3, "Wooden Armor"));
                ArmorList.Add(new Armor(20, 5, 7, "Metal Armor"));

                //Add a bunch of Potions to the Potions list
                PotionsList.Add(new Potion(5, 0, 5, "Healing Potion"));
                PotionsList.Add(new Potion(5, 0, 10, "Strength Potion"));
                PotionsList.Add(new Potion(5, 0, 20, "Berzerker Potion"));
            }            
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("“Welcome to my shop! What would you like to do?");
            Console.WriteLine("1. Buy Item");
            Console.WriteLine("2. Sell Item");
            Console.WriteLine("3. Return to Main Menu");

            Console.WriteLine("");
            Console.WriteLine("Enter your selection: ");
            var choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    ShowInventory();
                    Sell();                             
                    break;
                case "2":
                    BuyfromUser();
                    break;                                                           
            }

            Game.MainMenu();
        }

        public void ShowInventory()
        {
            FancyWrite($"Here is what we have in stock as of today, {DateTime.Now}");
            ItemCatalog.Clear();
            ListPotions();
            ListArmor();
            ListWeapons();
            
        }

        public void BuyfromUser()
        {

        }

        public void ListArmor()
        {
            try
            {
                var count = 1;
                Console.WriteLine("-- Armor for sale--");
                foreach (var armor in ArmorList.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"a{count}. {armor.Name} - Original Value: {armor.OriginalValue}, Resell Value: {armor.ResellValue}");
                    ItemCatalog.Add($"a{count}", armor);
                    count++;
                }
                Console.WriteLine("");
            }
            catch(Exception ex)
            {
                //Error handling can mention the name of the method Im in
            }
        }

        public void ListWeapons()
        {
            var count = 1;
            Console.WriteLine("-- Weapons for sale--");
            foreach(var weapon in WeaponsList.OrderBy(w => w.Name))
            {
                Console.WriteLine($"w{count}. {weapon.Name} - Original Value: {weapon.OriginalValue}, Resell Value: {weapon.ResellValue}");

                ItemCatalog.Add($"w{count}", weapon);
                count++;
            }
            Console.WriteLine("");
        }

        public void ListPotions()
        {
            var count = 1;
            Console.WriteLine("--Potions for sale--");
            foreach (var potion in PotionsList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"p{count}. {potion.Name} - Original Value: {potion.OriginalValue}, Resell Value: {potion.ResellValue}");
                ItemCatalog.Add($"p{count}", potion);
                count++;
            }
            Console.WriteLine("");
        }

        public void Sell()
        {            
            var selection = "";
            while (string.IsNullOrEmpty(selection))
            {
                FancyWrite("Which item would you like to purchase? ");
                selection = Console.ReadLine();
            }
          
            //Now I need to check to see if the user selection is present in the Dictionary before proceeding
            if (!ItemCatalog.ContainsKey(selection))
            {               
                FancyWrite("That selection is not valid please try again.");
                Sell();
            }

            if(VerifyFunds(selection))
            {
                FinalizeSale(selection);
            }

        }

        private void FinalizeSale(string selection)
        {
            switch (selection.Substring(0, 1))
            {
                case "a":
                    var armor = (Armor)ItemCatalog[selection];
                    Game.Hero.Gold -= armor.OriginalValue;
                    Game.Hero.ArmorsBag.Add(armor);
                    this.ArmorList.Remove(armor);
                    break;
                   
                case "p":
                    var potion = (Potion)ItemCatalog[selection];
                    Game.Hero.Gold -= potion.OriginalValue;
                    Game.Hero.PotionsBag.Add(potion);
                    this.PotionsList.Remove(potion);
                    break;
                case "w":
                    var weapon = (Weapon)ItemCatalog[selection];
                    Game.Hero.Gold -= weapon.OriginalValue;
                    Game.Hero.WeaponsBag.Add(weapon);
                    this.WeaponsList.Remove(weapon);
                    break;
                default:
                    break;      
            }

        }

        private bool VerifyFunds(string selection)
        {            
            switch (selection.Substring(0,1))
            {
                case "a":
                    var armor = (Armor)ItemCatalog[selection];
                    return Game.Hero.Gold >= armor.OriginalValue;
                case "p":
                    var potion = (Potion)ItemCatalog[selection];
                    return Game.Hero.Gold >= potion.OriginalValue;
                case "w":
                    var weapon = (Weapon)ItemCatalog[selection];
                    return Game.Hero.Gold >= weapon.OriginalValue;
                default:
                    return false;
            }
        }

        private void FancyWrite(string msg)
        {
            Console.WriteLine("");
            Console.WriteLine(msg);
        }
    }
}
