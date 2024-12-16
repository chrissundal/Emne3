using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership
{
    internal class View
    {
        private List<Dealership> _dealerships;
        private Dealership _selectedDealer;

        public View()
        {
            _dealerships = [];
        }
        public void AddToList(Dealership newDealer)
        {
            _dealerships.Add(newDealer);
        }

        public void Run(Person selected)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Velg en butikk eller trykk 'Q' for å avslutte");
                showDealerShips();
                var raw = Console.ReadLine();
                if (raw.ToLower() == "q")
                {
                    exit = true;
                }
                var input = Convert.ToInt32(raw)-1;
                if (input < _dealerships.Count)
                {
                    _selectedDealer = _dealerships[input];
                    _selectedDealer.GotoStore(selected);
                }
                else
                {
                    Console.WriteLine("Ikke gyldig butikk");
                    Console.ReadKey();
                }
            }
        }

        private void showDealerShips()
        {
            int counter = 1;
            foreach (var d in _dealerships)
            {
                Console.Write($"{counter}. ");
                d.ShowBasicInfo();
                counter++;
            }
        }
    }
}
