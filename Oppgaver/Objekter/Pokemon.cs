
namespace Objekter
{
    internal class Pokemon
    {

        public string Name;
        public int Health;
        public int Level;

        public Pokemon(string name)
        {
            Name = name;
        }
        public Pokemon(string name, int health, int level)
        {
            Name = name;
            Health = health;
            Level = level;
        }

        internal void Show()
        {
            if (Health == 0)
            {
                Console.WriteLine($"Du fant {Name}");
            }
            else
                Console.WriteLine($"{Name} har {Health} hp og er level {Level}");
            {
            }
        }
    }
}
