using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class World
    {
        private Character _character;
        private Store _magicStore;
        
        public World()
        {
            _magicStore = new Store();
            _character = new Character([], "Harry Potter", "Gryffindors");
            Run();
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void Run()
        {
            bool exit = false;
            while(!exit)
            {
                
                Console.WriteLine("1. Se info");
                Console.WriteLine("2. Se inventory");
                Console.WriteLine("3. Gå til butikk");
                Console.WriteLine("4. Trylleformel");
                Console.WriteLine("5. Avslutt");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Clear();
                        _character.ShowInfo();
                        break;

                    case '2':
                        Clear();
                        _character.ShowInventory();
                        break;

                    case '3':
                        Clear();
                        _magicStore.GoToStore(_character);
                        break;

                    case '4':
                        Clear();
                        _character.DoMagic();
                        break;

                    case '5':
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("ikke gyldig");
                        break;
                }
            }
        }
    }
}
