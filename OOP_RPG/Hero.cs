using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */

        // These are the Properties of our Class.
      
        public Game Game { get; set; }
        public Shop Shop { get; set; }

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Gold { get; set; }
        public double BAC { get; set; }

        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionsBag { get; set; }
        
        public Hero(Game game, Shop shop) {
            this.Game = game;
            this.Shop = shop;
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionsBag = new List<Potion>();
            this.Strength = 100;
            this.Defense = 100;
            this.OriginalHP = 300;
            this.CurrentHP = 300;
            this.Gold = 1000;
            this.BAC = 0;
        }

        public bool IsDrunk()
        {
            return BAC >= .5;
        }
           
        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Hitpoints: {CurrentHP} / {OriginalHP}");
            Console.WriteLine($"BAC level: {BAC}");
        }
        
        public void ShowInventory() {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach(var w in this.WeaponsBag){
                Console.WriteLine($"{w.Name} of {w.Strength} Strength");
            }
            Console.WriteLine("Armor: ");
            foreach(var a in this.ArmorsBag){
                Console.WriteLine($"{a.Name} of {a.Defense} Defense");
            }
            Console.WriteLine("Potion: ");
            foreach (var p in this.PotionsBag)
            {
                Console.WriteLine($"{p.Name} with {p.HP} HP");
            }
        }

        public void PresentItemMenu()
        {
            Console.WriteLine("Which type of item would you like to sell to the Shop?");
            Console.WriteLine("1. Armor");
            Console.WriteLine("2. Weapon");
            Console.WriteLine("3. Potion");
            Console.WriteLine("4. Go back to Shop Menu");
            Console.WriteLine("5. Go back to Main Menu");

            var selection = "";
            do
            {
                selection = Console.ReadLine();
            } while (string.IsNullOrEmpty(selection));

            switch (selection)
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
                    Shop.Menu();
                    break;
                case "5":
                    Game.MainMenu();
                    break;
                default:
                    break;
            }

            Shop.Menu();

        }

        #region Armor Code
        private void ListArmor()
        {
            if(ArmorsBag.Count() == 0)
            {
                Console.WriteLine("You have no Armor to sell.");
                return;
            }

            var count = 1;
            foreach (var armor in ArmorsBag)
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
            if (intSelection > 0 && intSelection <= ArmorsBag.Count())
            {
                var armor = ArmorsBag[intSelection - 1];
                
                Gold += armor.ResellValue;
                ArmorsBag.Remove(armor);
                this.Shop.ArmorList.Add(armor);                
            }
        }
        #endregion

        #region Potion Code
        private void ListPotions()
        {
            if (PotionsBag.Count() == 0)
            {
                Console.WriteLine("You have no Potion to sell.");
                return;
            }
            var count = 1;
            foreach (var potion in PotionsBag)
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
            if (intSelection > 0 && intSelection <= PotionsBag.Count())
            {
                var potion = PotionsBag[intSelection - 1];            
                Gold += potion.ResellValue;
                PotionsBag.Remove(potion);
                this.Shop.PotionsList.Add(potion);
                
            }
        }
        #endregion

        #region Weapons Code
        private void ListWeapons()
        {
            if (WeaponsBag.Count() == 0)
            {
                Console.WriteLine("You have no Weapons to sell.");
                return;
            }

            var count = 1;
            foreach (var weapon in WeaponsBag)
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
            if (intSelection > 0 && intSelection <= WeaponsBag.Count())
            {
                var weapon = WeaponsBag[intSelection - 1];               
                Gold += weapon.ResellValue;               
                WeaponsBag.Remove(weapon);
                Shop.WeaponsList.Add(weapon);                
            }
        }
        #endregion

        public void EquipWeapon() {
            if(WeaponsBag.Any()) {
                this.EquippedWeapon = this.WeaponsBag[0];
            }
        }
        
        public void EquipArmor() {
            if(ArmorsBag.Any()) {
                this.EquippedArmor = this.ArmorsBag[0];
            }
        }
        
    }
}