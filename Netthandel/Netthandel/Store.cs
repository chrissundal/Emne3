using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netthandel
{
    internal class Store
    {
        private string _storeName;
        private Person _employee;
        private List<IProducts> _products;
        private List<IProducts> _search;
        private Person _customer;
        public Store(string storeName, Person employee, List<IProducts> products)
        {
            _storeName = storeName;
            _employee = employee;
            _products = products;
            _search = [];
        }

        public string GetName()
        {
            return _storeName;
        }

        private void ShowSelectedItems()
        {
            if (_search.Count > 0)
            {
                while (true)
                {
                    Console.Clear();
                    _customer.ShowWallet();
                    ShowEachItem();
                    var input = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (input < _search.Count)
                    {
                        var selectedItem = _search[input];
                        Console.WriteLine("Hvor mange?");
                        var inputAmount = Convert.ToInt32(Console.ReadLine());
                        _customer.AddToCart(inputAmount, selectedItem);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ikke gyldig");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("Ingen produkter funnet");
                Console.ReadKey();
            }
        }

        private void ShowEachItem()
        {
            int num = 1;
            foreach (var item in _search)
            {
                if (num >= 10)
                {
                    Console.Write($"{num}. ");
                }
                else
                {
                    Console.Write($"{num}.  ");
                }
                item.ShowInfo();
                num++;
            }
        }

        private void GetSortedItems(string category)
        {
            _search = _products.Where(item => item.Category == category).ToList();
            ShowSelectedItems();
        }
        public void GoToStore(World world, Person loggedInPerson)
        {
            _customer = loggedInPerson;
            bool exitstore = false;
            while (!exitstore)
            {
                Console.Clear();
                Console.WriteLine($"Velkommen til {_storeName}");
                Console.WriteLine($"1. Spør {_employee.GetName()} om å se kjøtt");
                Console.WriteLine($"2. Spør {_employee.GetName()} om å se drikke");
                Console.WriteLine($"3. Spør {_employee.GetName()} om å se snacks");
                Console.WriteLine($"4. Spør {_employee.GetName()} om å se meieriprodukter");
                Console.WriteLine($"5. Spør {_employee.GetName()} om å se grønnsaker");
                Console.WriteLine($"6. Spør {_employee.GetName()} om å se frukt");
                Console.WriteLine($"7. Se alle produkter");
                Console.WriteLine($"8. Se handlekurven");
                Console.WriteLine($"9. Kjøp varer");
                Console.WriteLine($"0. Forlat butikken");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        GetSortedItems("Meat");
                        break;
                    case '2':
                        GetSortedItems("Drikke");
                        break;
                    case '3':
                        GetSortedItems("Snacks");
                        break;
                    case '4':
                        GetSortedItems("Meieri");
                        break;
                    case '5':
                        GetSortedItems("Grønnsak");
                        break;
                    case '6':
                        GetSortedItems("Frukt");
                        break;
                    case '7':
                        _search = _products;
                        ShowSelectedItems();
                        break;
                    case '8':
                        loggedInPerson.ShowShoppingbag();
                        break;
                    case '9':
                        loggedInPerson.Checkout();
                        break;
                    case '0':
                        exitstore = true;
                        break;
                }
            }

        }
    }
}
