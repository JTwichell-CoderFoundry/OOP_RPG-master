using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        //List<Monster> Monsters { get; set; }

        public Monster Enemy { get; set; }

        public Game Game { get; set; }
        public Hero Hero { get; set; }
        
        public Fight(Hero hero, Game game, Monster enemy) {
            //this.Monsters = new List<Monster>();     
            this.Enemy = enemy;
            this.Hero = hero;
            this.Game = game;
            //this.AddMonster("Squid", 9, 8, 20);
            //this.AddMonster("Goblin", 10, 10, 10);
            //this.AddMonster("Ghost", 5, 2, 1);
            //this.AddMonster("Ghoul", 15, 15, 8);
        }

        //public void AddMonster(string name, int strength, int defense, int hp) {
            //Original
            //var monster = new Monster();
            //monster.Name = name;
            //monster.Strength = strength;
            //monster.Defense = defense;
            //monster.OriginalHP = hp;
            //monster.CurrentHP = hp;
            //this.Monsters.Add(monster);

            //Overloaded Constructor
            //var monster = new Monster(name, strength, defense, hp);
            //this.Monsters.Add(monster);

            //More compact code
            //this.Monsters.Add(new Monster(name, strength, defense, hp));

        //}

        public void Start() {

            if(Hero.BAC > .5)
            {
                Console.WriteLine($"{Hero.Name}'s BAC is {Hero.BAC} and is too drunk to fight. Go sleep it off!");
                Game.MainMenu();
            }
                //This is how we are fighting the 1st Monster in the list

                //Default: Fight 1st Monster
                //var enemy = this.Monsters[0];

                //Fight Last Monster
                //var enemy = this.Monsters[this.Monsters.Count -1];

                //Fight Second Monster
                //var enemy = this.Monsters[1];

                //The first monster with less than 20 hitpoints
                //var enemy = this.Monsters.FirstOrDefault(m => m.CurrentHP < 20);

                //The first monster with a strength of at least 11
                //var enemy = this.Monsters.FirstOrDefault(m => m.Strength >= 11);

                //A random monster - How do I generate a Random Numer between 0 and Monsters.Count -1??
                //var random = new Random();

                //var enemy = this.Monsters[random.Next(0, this.Monsters.Count)];
                //this.Enemy = this.Monsters[random.Next(0, this.Monsters.Count)];



                Console.WriteLine("You've encountered a " + Enemy.Name + "! " + Enemy.Strength + " Strength/" + Enemy.Defense + " Defense/" +
            Enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn();
            }
            else { 
                this.Game.MainMenu();
            }
        }
        
        public void HeroTurn(){

           var compare = Hero.Strength - Enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               Enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
               this.Enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(this.Enemy.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           
           int damage;
           var compare = this.Enemy.Strength - Hero.Defense;
           if(compare <= 0) {
               damage = 1;
               Hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               Hero.CurrentHP -= damage;
           }
           Console.WriteLine(Enemy.Name + " does " + damage + " damage!");
           if(Hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {    
            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle!");
            this.Hero.Gold += this.Enemy.Gold;
            Console.WriteLine($"You earned {this.Enemy.Gold} pieces of Gold and now have {this.Hero.Gold} Gold pieces");

            //I want to add the Monster's gold to the Hero's Gold...
            this.Hero.Gold += this.Enemy.Gold;

            Game.MainMenu();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.ReadKey();
            return;
        }
        
    }
    
}