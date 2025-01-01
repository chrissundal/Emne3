using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Netthandel
{
    internal class Person
    {
        private string _name;
        private List<IProducts> _shoppingbag;
        private List<IProducts> _inventory;
        private int _wallet;

        public Person(string name, List<IProducts> shoppingbag, List<IProducts> inventory, int wallet)
        {
            _name = name;
            _shoppingbag = shoppingbag;
            _inventory = inventory;
            _wallet = wallet;
        }

        public Person(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }

        public void ShowShoppingbag()
        {
            Console.Clear();
            if (_shoppingbag.Count > 0)
            {
                Console.Clear();
                int num = 1;
                foreach (var item in _shoppingbag)
                {
                    Console.Write($"{num}. ");
                    item.ShowInfo();
                    num++;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen varer i handlekurven");
            }
            Console.ReadKey();
        }

        public void AddToCart(int amount,IProducts product)
        {
            Console.Clear();
            product.RemoveFromStock(amount);
            var newItem = product.Clone(amount);
            
            _shoppingbag.Add(newItem);
            Console.WriteLine($"{newItem.Stock} {newItem.Measurement} av {newItem.Name} er lagt til.");
            Console.ReadKey();
        }

        public void Checkout()
        {
            Console.Clear();
            if (_shoppingbag.Count > 0)
            {
                var _shoppingbagSum = 0;
                foreach (var p in _shoppingbag)
                {
                    var sum = p.Price * p.Stock; 
                    _shoppingbagSum += sum;
                    _inventory.Add(p);
                    
                }
                _wallet -= _shoppingbagSum;
                _shoppingbag.Clear();
                Console.WriteLine($"Totalsummen var {_shoppingbagSum} kroner");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen varer i handlekurven");
            }
            Console.ReadKey();
        }

        public void ShowWallet()
        {
            Console.WriteLine("Du har:");
            Console.WriteLine($"{_wallet}  kroner");
            Console.WriteLine($"{_inventory.Count}  varer hjemme");
            var line = new string('-', 20);
            Console.WriteLine(line);
        }

        public void ShowInventory()
        {
            Console.Clear();
            if (_inventory.Count > 0)
            {
                foreach (var item in _inventory)
                {
                    item.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Ingen varer hjemme");
            }
            Console.ReadKey();
        }
    }
}
