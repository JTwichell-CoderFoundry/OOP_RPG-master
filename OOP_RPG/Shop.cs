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

        #region Test Code
        //Here is where I can create a new property named ItemCatalog
        //that is of type Dictionary<string, object>. That means that
        //we will be storing a string as a key and an object of unknown type
        //as the value. We can then retrieve the object by searching the
        //Dictionary for a particular key.

        //private Dictionary<string, object> ItemCatalog { get; set; }

        //private Dictionary<string, Potion> PotionCatalog { get; set; }
        //private Dictionary<string, Weapon> WeaponCatalog { get; set; }
        //private Dictionary<string, Armor> ArmorCatalog { get; set; }
        #endregion

        public Game Game { get; set; }

        public Shop(Game game)
        {
            this.ArmorList = new List<Armor>();
            this.WeaponsList = new List<Weapon>();
            this.PotionsList = new List<Potion>();

            #region Old Catalog loading
            //this.ItemCatalog = new Dictionary<string, object>();
            //this.PotionCatalog = new Dictionary<string, Potion>();
            //this.WeaponCatalog = new Dictionary<string, Weapon>();
            //this.ArmorCatalog = new Dictionary<string, Armor>();
            #endregion

            this.Game = game;

            StockShop();

        }

        private void StockShop()
        {                    
            for(var loop = 1; loop <= 5; loop++)
            {
                //Add a bunch of Weapons to the Weapons list               
                WeaponsList.Add(new Weapon(12, 3, 4, "Axe"));
                WeaponsList.Add(new Weapon(20, 5, 7, "LongSword"));
                WeaponsList.Add(new Weapon(10, 2, 3, "Sword"));

                //Add a bunch of Armor to the Armor List           
                ArmorList.Add(new Armor(5, 1, 2, "Leather Armor"));
                ArmorList.Add(new Armor(10, 2, 3, "Wooden Armor"));
                ArmorList.Add(new Armor(20, 5, 7, "Metal Armor"));

                //Add a bunch of Potions to the Potions list
                PotionsList.Add(new Potion(5, 0, 5, "Healing Potion"));
                PotionsList.Add(new Potion(5, 0, 10, "Strength Potion"));
                PotionsList.Add(new Potion(5, 0, 20, "Berzerker Potion"));
            }

            var myWeaponStruct = new WeaponStruct();
            myWeaponStruct.OriginalValue = 10;
            myWeaponStruct.ResellValue = 5;
            myWeaponStruct.Strength = 10;
            myWeaponStruct.Name = "DemoWeapon";

            WeaponsList.Add(new Weapon(myWeaponStruct));

            OrderLists();

        }

        private void OrderLists()
        {
            ArmorList = ArmorList.OrderBy(x => x.Name).ToList();
            PotionsList = PotionsList.OrderBy(x => x.Name).ToList();
            WeaponsList = WeaponsList.OrderBy(x => x.Name).ToList();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to my shop! What would you like to do?");
            Console.WriteLine("1. Buy Item(s)");
            Console.WriteLine("2. Sell Item(s)");
            Console.WriteLine("3. Return to Main Menu");

           FancyWrite("Enter your selection: ");
            var choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    #region Old Code
                    //ShowInventory();
                    //Sell();   
                    #endregion
                    PresentItemMenu();
                    break;
                case "2":
                    BuyfromUser();
                    break;
                default:
                    this.Game.MainMenu();
                    break;
            }
         }

        public void PresentItemMenu()
        {
            FancyWrite("Which type of item would you like to buy?");
            Console.WriteLine("1. Armor");
            Console.WriteLine("2. Weapon");
            Console.WriteLine("3. Potion");
            Console.WriteLine("4. Go back to Shop Menu");

            var selection = "";
            do
            {
                selection = Console.ReadLine();
            } while (string.IsNullOrEmpty(selection));

            switch(selection)
            {
                case "1":
                    ListArmor();
                    break;
                case "2":
                    ListWeapons();
                    break;
                case "3":
                    ListPotions();
                    break;
                case "4":
                    this.Menu();
                    return;
                default:
                    break;
            }

            this.Menu();

                 
        }

        #region Armor Code
        private void ListArmor()
        {
            var count = 1;
            foreach (var armor in ArmorList)
            {
                Console.WriteLine($"{count}. {armor.Name} - Original Value = {armor.OriginalValue}, Resell Value = {armor.ResellValue}, Defense = {armor.Defense}");
                count++;
            }

            var strSelection = "";
            do
            {
                strSelection = Console.ReadLine();
            } while (string.IsNullOrEmpty(strSelection));

            var intSelection = Convert.ToInt32(strSelection);
            if(intSelection > 0 && intSelection <= ArmorList.Count())
            {
                var armor = ArmorList[intSelection - 1];
                if(Game.Hero.Gold >= armor.OriginalValue)
                {
                    Game.Hero.Gold -= armor.OriginalValue;
                    this.ArmorList.Remove(armor);
                    Game.Hero.ArmorsBag.Add(armor);
                }
            }
        }
        #endregion

        #region Potion Code
        private void ListPotions()
        {
            var count = 1;
            foreach (var potion in PotionsList)
            {
                Console.WriteLine($"{count}. {potion.Name} - Original Value = {potion.OriginalValue}, Resell Value = {potion.ResellValue}, HP = {potion.HP}");
                count++;
            }

            var strSelection = "";
            do
            {
                strSelection = Console.ReadLine();
            } while (string.IsNullOrEmpty(strSelection));

            var intSelection = Convert.ToInt32(strSelection);
            if (intSelection > 0 && intSelection <= PotionsList.Count())
            {
                var potion = PotionsList[intSelection - 1];
                if (Game.Hero.Gold >= potion.OriginalValue)
                {
                    Game.Hero.Gold -= potion.OriginalValue;
                    this.PotionsList.Remove(potion);
                    Game.Hero.PotionsBag.Add(potion);
                }
            }
        }
        #endregion

        #region Weapons Code
        private void ListWeapons()
        {
            var count = 1;
            foreach (var weapon in WeaponsList)
            {
                Console.WriteLine($"{count}. {weapon.Name} - Original Value = {weapon.OriginalValue}, Resell Value = {weapon.ResellValue}, Strnegth = {weapon.Strength}");
                count++;
            }


            var strSelection = "";
            do
            {
                strSelection = Console.ReadLine();
            } while (string.IsNullOrEmpty(strSelection));

            var intSelection = Convert.ToInt32(strSelection);
            if (intSelection > 0 && intSelection <= WeaponsList.Count())
            {
                var weapon = WeaponsList[intSelection - 1];
                if (Game.Hero.Gold >= weapon.OriginalValue)
                {
                    Game.Hero.Gold -= weapon.OriginalValue;
                    this.WeaponsList.Remove(weapon);
                    Game.Hero.WeaponsBag.Add(weapon);
                }
            }
        }
        #endregion

        //public void ShowInventory()
        //{
        //    FancyWrite($"Here is what we have in stock as of today, {DateTime.Now}");

        //ItemCatalog.Clear();

        //ListPotions();
        //ListArmor();
        //ListWeapons();

        //}

        #region Old Code using Dictionaries
        //public void ListArmor()
        //{
        //    try
        //    {
        //        ArmorCatalog.Clear();
        //        var count = 1;
        //        Console.WriteLine("-- Armor for sale--");
        //        foreach (var armor in ArmorList.OrderBy(x => x.Name))
        //        {
        //            Console.WriteLine($"a{count}. {armor.Name} - Original Value: {armor.OriginalValue}, Resell Value: {armor.ResellValue}");
        //            ArmorCatalog.Add($"a{count}", armor);
        //            count++;
        //        }
        //        Console.WriteLine("");
        //    }
        //    catch(Exception ex)
        //    {
        //        //Error handling can mention the name of the method Im in
        //    }
        //}

        //public void ListWeapons()
        //{
        //    WeaponCatalog.Clear();

        //    var count = 1;
        //    Console.WriteLine("-- Weapons for sale--");
        //    foreach(var weapon in WeaponsList.OrderBy(w => w.Name))
        //    {
        //        Console.WriteLine($"w{count}. {weapon.Name} - Original Value: {weapon.OriginalValue}, Resell Value: {weapon.ResellValue}");

        //        WeaponCatalog.Add($"w{count}", weapon);
        //        count++;
        //    }
        //    Console.WriteLine("");
        //}

        //public void ListPotions()
        //{
        //    PotionCatalog.Clear();

        //    var count = 1;
        //    Console.WriteLine("--Potions for sale--");
        //    foreach (var potion in PotionsList.OrderBy(x => x.Name))
        //    {
        //        Console.WriteLine($"p{count}. {potion.Name} - Original Value: {potion.OriginalValue}, Resell Value: {potion.ResellValue}");
        //        PotionCatalog.Add($"p{count}", potion);
        //        count++;
        //    }
        //    Console.WriteLine("");
        //}

        //public void Sell()
        //{            
        //    var selection = "";
        //    while (string.IsNullOrEmpty(selection))
        //    {
        //        FancyWrite("Which item would you like to purchase? ");
        //        selection = Console.ReadLine();
        //    }

        //    //Now I need to check to see if the user selection is present in the Dictionary before proceeding
        //    switch(selection.Substring(0,1))
        //    {
        //        case "a":
        //            if(!ArmorCatalog.ContainsKey(selection))
        //            {
        //                FancyWrite("There is no Armor that corresponds to the selection you made, please try again.");
        //                Sell();
        //            }
        //            break;
        //        case "p":
        //            if (!PotionCatalog.ContainsKey(selection))
        //            {
        //                FancyWrite("There is no Potion that corresponds to the selection you made, please try again.");
        //                Sell();
        //            }
        //            break;
        //        case "w":
        //            if (!WeaponCatalog.ContainsKey(selection))
        //            {
        //                FancyWrite("There is no Weapon that corresponds to the selection you made, please try again.");
        //                Sell();
        //            }
        //            break;
        //    }

        //    if(VerifyFunds(selection))
        //    {
        //        FinalizeSale(selection);
        //    }
        //}

        //private void FinalizeSale(string selection)
        //{
        //    switch (selection.Substring(0, 1))
        //    {
        //        case "a":                 
        //            Game.Hero.Gold -= ArmorCatalog[selection].OriginalValue;
        //            Game.Hero.ArmorsBag.Add(ArmorCatalog[selection]);
        //            this.ArmorList.Remove(ArmorCatalog[selection]);
        //            break;

        //        case "p":                   
        //            Game.Hero.Gold -= PotionCatalog[selection].OriginalValue;
        //            Game.Hero.PotionsBag.Add(PotionCatalog[selection]);
        //            this.PotionsList.Remove(PotionCatalog[selection]);
        //            break;
        //        case "w":

        //            Game.Hero.Gold -= WeaponCatalog[selection].OriginalValue;
        //            Game.Hero.WeaponsBag.Add(WeaponCatalog[selection]);
        //            this.WeaponsList.Remove(WeaponCatalog[selection]);
        //            break;
        //        default:
        //            break;      
        //    }

        //}

        //private bool VerifyFunds(string selection)
        //{            
        //    switch (selection.Substring(0,1))
        //    {
        //        case "a":                   
        //            return Game.Hero.Gold >= ArmorCatalog[selection].OriginalValue;
        //        case "p":                   
        //            return Game.Hero.Gold >= PotionCatalog[selection].OriginalValue;
        //        case "w":
        //            return Game.Hero.Gold >= WeaponCatalog[selection].OriginalValue;
        //        default:
        //            return false;
        //    }
        //}
        #endregion

        public void BuyfromUser()
        {
            this.Game.Hero.PresentItemMenu();          
        }

        private void FancyWrite(string msg)
        {
            Console.WriteLine("");
            Console.WriteLine(msg);
        }
    }
}
