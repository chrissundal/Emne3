using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Character
    {
        public string Name { get; private set; }
        public string House { get; private set; }
        private List<IItems> _inventory;

        public Character(List<IItems> inventory, string name, string house)
        {
            _inventory = inventory;
            Name = name;
            House = house;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Jeg heter {Name} og er medlem i : {House}");
        }

        public void ShowInventory()
        {

            if (_inventory.Count > 0)
            {
                int num = 1;
                foreach (var item in _inventory)
                {
                    Console.WriteLine($"{num}. {item.Name}");
                    num++;
                }
            }
            else
            {
                Console.WriteLine("Ingenting her");
            }

            Console.ReadKey(true);
        }

        public void AddItem(IItems selected)
        {
            _inventory.Add(selected);
            Console.WriteLine($"{selected.Name} er lagt til");
        }

        public void DoMagic()
        {

            if (_inventory.Any(hasWand => hasWand.Type == "Wand"))
            {
                while (true)
                {
                    Console.Write("Skriv formelen din : ");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "vingardium leviosa":
                            Console.WriteLine($"Fjæren flyr (wooooah)");
                            return;

                        case "hokus pokus":
                            Console.WriteLine("Det smeller overalt.");
                            if (_inventory.Any(hasPet => hasPet.Type == "Pet"))
                            {
                                Console.WriteLine("Kjæledyret ditt likte ikke det assa...");
                            }

                            return;
                    }
                }
            }
            else
            {
                    Console.WriteLine("Du har ikke en tryllestav.");
                    return;
            }
        }
    }
} 



// Harry Potter - [Navn, Hus, Inventory, (Pet?)]