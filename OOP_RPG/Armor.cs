using System;
namespace OOP_RPG
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Armor() { }

        public Armor(string name, int defense) {
            this.Name = name;
            this.Defense = defense;
        } 
        
        public Armor(int originalValue, int resellValue, int defense, string name)
        {
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
            this.Name = name;
            this.Defense = defense;
        }

    }
}