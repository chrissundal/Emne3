using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netthandel
{
    internal class World
    {
        private List<Store> _stores;
        private Person _loggedInPerson;
        public World()
        {
            _stores = [];
        }
        public void AddStore(Store store)
        {
            _stores.Add(store);
        }

        public void GoToWorld(Person selected)
        {
            _loggedInPerson = selected;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                selected.ShowWallet();
                Console.WriteLine("1. Dra ut å handle");
                Console.WriteLine("2. Se Inventaret");
                Console.WriteLine("3. Velg person");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        GetStore();
                        break;
                    case '2':
                        _loggedInPerson.ShowInventory();
                        break;
                    case '3':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ikke gyldig");
                        break;
                }
                
            }
            
        }

        private void GetStore()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velg en butikk eller trykk 'Q' for å gå tilbake");
                int num = 1;
                foreach (var store in _stores)
                {
                    Console.WriteLine($"{num}. {store.GetName()}");
                    num++;
                }
                var inputstring = Console.ReadLine();
                if (inputstring.ToLower() == "q")
                {
                    break;
                }
                var input = Convert.ToInt32(inputstring)-1;
                if (input < _stores.Count)
                {
                    var chosenstore = _stores[input];
                    chosenstore.GoToStore(this, _loggedInPerson);
                }
                else
                {
                    Console.WriteLine("Ikke gyldig");
                    Console.ReadKey();
                }
            }
        }
    }
}
