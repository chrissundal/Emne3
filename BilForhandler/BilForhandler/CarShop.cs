using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler
{
    internal class CarShop
    {
        private Customer _selectedCustomer;
        private Car _selectedCar;
        private List<Car> _cars;
        private List<Car> _searchResults;

        public CarShop()
        {
            _cars =
            [
                new Car("Ford",1997,"KH51578",192000,10000),
                new Car("Toyota",2000,"KE81578",102000,40000),
                new Car("Jeep",1995,"EK56578",22000,50000),
                new Car("Ferrari",1992,"KP91578",196000,80000),
            ];
        }
        public void Run()
        {
            bool exit = false;
            _selectedCustomer = new Customer("Bjarne", 200000, []);
            while (!exit)
            {
                GetMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        
                        _searchResults = _cars;
                        GetAllCars();
                        break;
                    case "2":
                        
                        SortYear();
                        GetAllCars();
                        break;
                    case "3":
                        
                        SortKilo();
                        GetAllCars();
                        break;
                    case "4":
                        
                        _selectedCustomer.ShowGarage();
                        break;
                    case "5":
                        exit = true;
                        break;
                }
            }
        }

        private static void GetMenu()
        {
            Console.WriteLine("1. Show all cars");
            Console.WriteLine("2. Sort by year");
            Console.WriteLine("3. Sort by Km");
            Console.WriteLine("4. Go to garage");
            Console.WriteLine("5. Quit");
        }

        private void SortKilo()
        {
            Console.WriteLine("What is minimum km?");
            var inputMin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is maximum km?");
            var inputMax = Convert.ToInt32(Console.ReadLine());
            _searchResults = _cars.Where(car => car.Kilometerstand > inputMin && car.Kilometerstand < inputMax).ToList();
        }

        private void SortYear()
        {
            Console.WriteLine("What is minimum year?");
            var inputMin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is maximum year?");
            var inputMax = Convert.ToInt32(Console.ReadLine());
            _searchResults = _cars.Where(car => car.Årsmodell > inputMin && car.Årsmodell < inputMax).ToList();
        }

        private void GetAllCars()
        {
            if (_searchResults.Count > 0)
            {
                for (int i = 0; i < _searchResults.Count; i++)
                {
                    Console.WriteLine($"{i+1} {_searchResults[i].Merke}");
                }

                var input = Convert.ToInt32(Console.ReadLine());
                if (input < _searchResults.Count)
                {
                    _selectedCar = _searchResults[input-1];
                }
                
                SelectedCarMenu();
            }
            else
            {
                Console.WriteLine("No results");
            }
        }

        private void SelectedCarMenu()
        {
            while (true)
            {
                Console.WriteLine($"1. Show info about {_selectedCar.Merke}");
                Console.WriteLine($"2. Buy {_selectedCar.Merke}");
                Console.WriteLine($"3. Back to shop");
                var input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    _selectedCar.GetInfo();
                }
                else if(input == 2)
                {
                    _selectedCustomer.BuyCar(_selectedCar);
                    _cars.Remove(_selectedCar);
                    break;
                }
                else if (input == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not valid input");
                }
            }
        }
    }
}
