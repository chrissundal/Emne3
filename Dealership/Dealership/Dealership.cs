namespace Dealership
{
    internal class Dealership
    {
        private List<ITransportation> _DealershipTransports;
        private List<ITransportation> _searchList = [];
        private string _dealershipName;
        private Person _seller;
        private Person _selectedUser;
        private ITransportation _selectedTransport;
        public Dealership(List<ITransportation> dealershipTransports, string dealershipName, Person seller)
        {
            _DealershipTransports = dealershipTransports;
            _dealershipName = dealershipName;
            _seller = seller;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Velkommen til {_dealershipName}");
            Console.WriteLine($"Din selger er: {_seller.GetName()}");
            Console.WriteLine($"Antall kjøretøy: {_DealershipTransports.Count}");
            ShowInventory();
        }

        public void ShowInventory()
        {
            if (_searchList.Count > 0)
            {
                int counter = 1;
                foreach (var t in _searchList)
                {
                    if (counter >= 10)
                    {
                        Console.Write($"{counter}.");
                    }
                    else
                    {
                        Console.Write($"{counter}. ");
                    }
                    t.ShowInfo();
                    counter++;
                }

                
            }
            else
            {
                Console.WriteLine("Her var det tomt");
            }
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine(_dealershipName);
        }

        private void SelectTransport()
        {   
                Console.Clear();
                ShowInventory();
                if (_searchList.Count > 0)
                {
                    Console.WriteLine("Velg ett kjøretøy:");
                    var converted = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (converted < _searchList.Count)
                    {
                        _selectedTransport = _searchList[converted];
                        Console.WriteLine($"{_selectedTransport.Brand} er valgt");
                        Console.ReadKey();
                        GetTransportMenu();
                    }
                    else
                    {
                        Console.WriteLine("Ikke ett alternativ");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingen tilgjengelig");
                    Console.ReadKey();
                }
        }

        private void GetTransportMenu()
        {
            bool exitSelectCar = false;
            var random = new Random();
            while (!exitSelectCar)
            {
                Console.Clear();
                Console.WriteLine($"Hva vil du gjøre?");
                Console.WriteLine($"1. Ta {_selectedTransport.Brand} på en prøvetur");
                Console.WriteLine($"2. Kjøp {_selectedTransport.Brand}");
                Console.WriteLine($"3. Tilbake");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        _selectedTransport.GoForARide(random);
                        Console.ReadKey(true);
                        break;
                    case '2':
                        if (_selectedUser.BuyTransport(_selectedTransport))
                        {
                            _searchList.Remove(_selectedTransport);
                            exitSelectCar = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Du har ikke råd til denne");
                            Console.ReadKey(true);
                            exitSelectCar = true;
                        }
                        break;
                    case '3':
                        exitSelectCar = true;
                        break;
                    default:
                        Console.WriteLine("Ikke gyldig");
                        break;
                }
            }
        }

        public void RunSearch(Type index)
        {
            _searchList = _DealershipTransports.Where(t => t.Category == index).ToList();
        }
        public void GotoStore(Person selected)
        {
            _selectedUser = selected;
            bool exitStore = false;
            Console.Clear();
            Console.WriteLine($"Velkommen til {_dealershipName}, {_selectedUser.GetName()}");
            Console.WriteLine($"Din selger er {_seller.GetName()}");
            Console.ReadKey(true);
            while (!exitStore)
            {
                Console.Clear();
                Console.WriteLine($"1. Spør {_seller.GetName()} om å se alle kjøretøy");
                Console.WriteLine($"2. Spør {_seller.GetName()} om å se biler");
                Console.WriteLine($"3. Spør {_seller.GetName()} om å se båter");
                Console.WriteLine($"4. Spør {_seller.GetName()} om å se fly");
                Console.WriteLine($"5. Spør {_seller.GetName()} om å se motorsykler");
                Console.WriteLine("6. Forlat butikken");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        _searchList = _DealershipTransports;
                        SelectTransport();
                        Console.ReadKey(true);
                        break;
                    case '2':
                        Console.Clear();
                        RunSearch(Type.Car);
                        SelectTransport();
                        Console.ReadKey(true);
                        break;
                    case '3':
                        Console.Clear();
                        RunSearch(Type.Boat);
                        SelectTransport();
                        Console.ReadKey(true);
                        break;
                    case '4':
                        Console.Clear();
                        RunSearch(Type.Plane);
                        SelectTransport();
                        Console.ReadKey(true);
                        break;
                    case '5':
                        Console.Clear();
                        RunSearch(Type.Motorcycle);
                        SelectTransport();
                        Console.ReadKey(true);
                        break;
                    case '6':
                        Console.Clear();
                        exitStore = true;
                        break;
                    default:
                        Console.WriteLine("ikke gyldig");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }
}
