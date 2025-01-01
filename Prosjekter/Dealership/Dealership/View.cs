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
                Console.WriteLine($"Velg en butikk:");
                showDealerShips();
                int exitnum = _dealerships.Count;
                Console.WriteLine($"{exitnum+1}. Tilbake");
                var input = Convert.ToInt32(Console.ReadLine()) -1;
                if (input < _dealerships.Count)
                {
                    _selectedDealer = _dealerships[input];
                    _selectedDealer.GotoStore(selected);
                }
                else if (input == exitnum)
                {
                    exit = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Ikke gyldig butikk");
                    Console.ReadKey(true);
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
