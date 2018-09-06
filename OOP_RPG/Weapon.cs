using System;
namespace OOP_RPG
{
    public class Weapon : IItem
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
     
        public Weapon() { }
    
        public Weapon(string name, int strength) {
            this.Name = name;
            this.Strength = strength;
        }
        
        public Weapon(int originalValue, int ResellValue, int strength, string name)
        {
            this.OriginalValue = originalValue;
            this.ResellValue = ResellValue;
            this.Name = name;
            this.Strength = strength;
        }
       
    }
}