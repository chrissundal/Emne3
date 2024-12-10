using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariePokemon
{
    internal class Trainer
    {
        public PokemonWorld MyWorld { get; private set; }
        public List<string> Inventory { get; private set; }
        public Pokemon StartPokemon { get; private set; }
        public string Name { get; private set; }

        public Trainer(string name, PokemonWorld myWorld)
        {
            StartPokemon = new Pokemon("Pikachu", "Lightning");
            Name = name;
            Inventory = new List<string>();
            MyWorld = myWorld;
        }

        public Pokemon GoToWilderness()
        {

            while (true)
            {
                Console.WriteLine("Where do you want to go?");
                Console.WriteLine("1. Water");
                Console.WriteLine("2. Grass");
                Console.WriteLine("3. Mud");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    //Finne random vannpokemon
                    return MyWorld.GetRandomPokemon("Water");
                }
                else if (input == "2")
                {
                    //Finne random grasspokemon
                    return MyWorld.GetRandomPokemon("Grass");
                }
                else
                {
                    // Finne random mudpokemon
                    return MyWorld.GetRandomPokemon("Mud");
                }
            }


        }
        public void GoToGym()
        {

        }
        public void BattlePokemon(Pokemon pokemonToFight)
        {
            //Kampen varer til motstanderen ikke har mer health
            while (pokemonToFight.Health > 0)
            {
                //Angrep - min pokemon slår den han møter
                //Angrep - han vi sloss mot slår min
                //Evt Flukt
            }

        }
        public void CatchPokemon(Pokemon pokemonToCatch)
        {

        }
        public void EnterStore()
        {

        }
        public void BuyItem(string itemType)
        {

        }
    }
}
