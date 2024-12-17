namespace Dealership
{
    internal class Person
    {
        private string _name;
        private List<ITransportation> _myTransportations;
        private int _wallet;

        public Person(string name, List<ITransportation> myTransportations, int wallet)
        {
            _name = name;
            _myTransportations = myTransportations;
            _wallet = wallet;
        }

        public Person(string name)
        {
            _name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Navn: {_name}");
            Console.WriteLine("Kjøretøy:");
            showMyTransportations();
            Console.WriteLine($"Lommebok: {_wallet}");
        }

        private void showMyTransportations()
        {
            Console.WriteLine("Mine kjøretøy:");
            if (_myTransportations.Count > 0)
            {
                int num = 1;
                foreach (var myTransportation in _myTransportations)
                {
                    Console.Write($"{num}. ");
                    myTransportation.ShowInfo();
                    num++;
                }
            }
            else
            {
                Console.WriteLine("Her var det tomt");
            }
        }

        public string GetName()
        {
            return _name;
        }


        public bool BuyTransport(ITransportation selectedTransport)
        {
            Console.Clear();
            if (_wallet >= selectedTransport.Price)
            {
                _myTransportations.Add(selectedTransport);
                Console.WriteLine($"{selectedTransport.Brand} er kjøpt");
                showMyTransportations();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowInventory()
        {
            if (_myTransportations.Count > 0)
            {

                int num = 1;
                foreach (var veh in _myTransportations)
                {
                    Console.WriteLine($"{num}. {veh.Brand}");
                    num++;
                }
            }
            else
            {
                Console.WriteLine("Ingen kjøretøy");
            }

            Console.ReadKey(true);
        }
    }
}
