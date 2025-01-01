using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler
{
    internal class Customer
    {
        private string _name;
        private int _wallet;
        private List<Car> _myCars;

        public Customer(string name, int wallet, List<Car> myCars)
        {
            _name = name;
            _wallet = wallet;
            _myCars = myCars;
        }

        public void BuyCar(Car _selectedCar)
        {
            _myCars.Add(_selectedCar);
            _wallet -= _selectedCar.Pris;
            Console.WriteLine($"You just bought {_selectedCar.Merke} for {_selectedCar.Pris} kroner");
            Console.WriteLine($"You have {_wallet} kroner left");
        }

        public void ShowGarage()
        {
            if (_myCars.Count > 0)
            {

                for (int i = 0; i < _myCars.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {_myCars[i].Merke}");
                }
            }
            else
            {
                Console.WriteLine("no cars");
            }
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
