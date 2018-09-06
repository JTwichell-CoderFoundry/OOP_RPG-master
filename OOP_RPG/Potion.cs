
namespace OOP_RPG
{
    public class Potion : IItem
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Potion() { }

        public Potion(int hp, string name)
        {
            this.HP = hp;
            this.Name = name;
        }

        public Potion(int originalValue, int resellValue, int hp, string name)
        {
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
            this.HP = hp;
            this.Name = name;
        }

    }
}
