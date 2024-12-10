using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariePokemon
{
    internal class Pokemon
    {
        public int Level { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strenghh { get; private set; }

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
            Health = 100;
        }

        public void Fight(Pokemon opponent)
        {
            opponent.LooseHealth(Strenghh);
        }

        public void LooseHealth(int strength)
        {
            Health -= strength;
        }
    }
}
