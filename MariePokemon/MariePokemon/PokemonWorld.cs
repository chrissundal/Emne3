using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariePokemon
{
    internal class PokemonWorld
    {
        public Trainer MyTrainer { get; set; }
        public List<Pokemon> WildPokemons { get; private set; }
        Random Random { get; set; } = new Random();

        public PokemonWorld()
        {
            MyTrainer = new Trainer("Ash", this);
            WildPokemons = new List<Pokemon>() { new Pokemon("Lucario", "Grass"), new Pokemon("Bulbasaur", "Grass"),
            new Pokemon("Gyarados", "Water"),new Pokemon("Oshawott", "Water"), new Pokemon("Grimer", "Mud"),new Pokemon("Diglett", "Mud") };
            Menu();
        }

        public void Menu()
        {
            bool appRunning = true;
            while (appRunning)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Go to wilderness");
                Console.WriteLine("2. Go to store");
                Console.WriteLine("3. Go to pokemon gym");
                Console.WriteLine("4. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        WildernessMenu();
                        break;
                    case "2":
                        MyTrainer.EnterStore();
                        break;
                    case "3":
                        MyTrainer.GoToGym();
                        break;
                    case "4":
                        appRunning = false;
                        break;
                    default:
                        Console.WriteLine("Wrong option, try again");
                        break;
                }
            }
        }

        public void WildernessMenu()
        {
            var foundPokemon = MyTrainer.GoToWilderness();
            Console.WriteLine("YOu Found " + foundPokemon.Name);
            Console.WriteLine("Do you want to fight (f) or catch? (c)");
            var input = Console.ReadLine();
            if (input == "f")
            {
                MyTrainer.BattlePokemon(foundPokemon);
            }
            else
            {
                MyTrainer.CatchPokemon(foundPokemon);
            }
        }
        public Pokemon GetRandomPokemon(string type)
        {
            var pokemen = WildPokemons.Where(pokemon => pokemon.Type == type).ToList();
            var randIndex = Random.Next(0, pokemen.Count);
            return pokemen[randIndex];
        }
    }
}
