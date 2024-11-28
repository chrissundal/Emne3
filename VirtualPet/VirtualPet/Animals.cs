using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    internal class Animal
    {
        public string Name { get; private set; }
        public int Food { get; private set; }
        public int Bladder { get; private set; }
        public int Health { get; private set; }
        public static List<Animal> Animals { get; private set; } = new List<Animal>();

        public Animal(string name, int food, int bladder, int health)
        {
            Name = name;
            Food = food;
            Bladder = bladder;
            Health = health;
            Animals.Add(this);
        }

         public static Animal CreateNewAnimal()
        {
            Console.Clear();
            Console.WriteLine("Lag ditt dyr");
            Console.WriteLine("Hva er navnet?");
            var name = Console.ReadLine();
            return new Animal(name, 5, 5, 10);
        }

        public void FeedAnimal()
        {
            Food = 10; 
            Bladder -= 4; 
            Health -= 4;
        }
        public void SleepAnimal()
        {
            Food -= 5; 
            Bladder -= 4; 
            Health = 10;
        }
        public void WalkAnimal()
        {
            Food -= 3; 
            Bladder = 10; 
            Health -= 2;
        }
        static Animal()
        {
            new Animal("Mikke Mus", 5, 5, 10); 
            new Animal("Donald", 5, 5, 10); 
            new Animal("Dolly", 5, 5, 10);
        }
    }
}
