
namespace Objekter
{
    internal class Pokemon
    {

        public string Name;
        public int Health;
        public int Level;

        public Pokemon(string name, int health, int level)
        {
            Name = name;
            Health = health;
            Level = level;
        }

        internal void Show()
        {
            Console.WriteLine($"{Name} har {Health} hp og er level {Level}");
        }
    }
}
