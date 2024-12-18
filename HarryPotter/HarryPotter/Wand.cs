using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Wand : IItems
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string TypeOf { get; private set; }
      
        public Wand(string name, string type, string typeOf)
        {
            Name = name;
            Type = type;
            TypeOf = typeOf;
        }

        public void ShowItems()
        {
            Console.WriteLine($"{Name} er {TypeOf}");

        }
    }
}
