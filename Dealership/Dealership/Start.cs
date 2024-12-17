namespace Dealership
{
    internal class Start
    {
        private List<Person> _users;
        private List<ITransportation> _allTransports;
        private Random random = new Random();
        private List<string> sellers;
        private List<string> dealershipName;
        private View _view;
        public Start()
        {
            dealershipName = ["Eventyr på Hjul og Vinger", "Alt på Fartøy", "MotorMagasinet", "Alt-i-ett Motorsenter", "TransportTårnet", "FartøyFesten"];
            sellers = ["Terje", "Martin", "Ellie", "Therese", "Marie", "Rebecka", "Dag"];
            _view = new View();
            _allTransports =
            [
                new Car("Ford F150", Type.Car, 450000, 325, 220, 2200),
                new Car("Toyota Camry", Type.Car, 300000, 245, 210, 1600), 
                new Car("Honda Civic", Type.Car, 250000, 220, 200, 1400),
                new Car("Chevrolet Corvette", Type.Car, 600000, 495, 310, 1500), 
                new Car("BMW M3", Type.Car, 550000, 473,290,1650),
                new Boat("Hydrolift x-22", Type.Boat, 700000, 225, 90, 1100),
                new Boat("Bayliner Element", Type.Boat, 500000, 150, 60, 1200), 
                new Boat("Sea Ray SPX 190", Type.Boat, 800000, 200, 85, 1400), 
                new Boat("Yamaha SX210", Type.Boat, 900000, 220, 75, 1300), 
                new Boat("Boston Whaler 170", Type.Boat, 600000, 115, 65, 1100),
                new Motorcycle("Ducati SuperSport", Type.Motorcycle, 255000, 110, 246, 184),
                new Motorcycle("Yamaha YZF-R1", Type.Motorcycle, 320000, 200, 299, 200),
                new Motorcycle("Honda CBR600RR", Type.Motorcycle, 280000, 120, 270, 194),
                new Motorcycle("Kawasaki Ninja ZX-6R", Type.Motorcycle, 290000, 135, 282, 198),
                new Motorcycle("BMW S1000RR", Type.Motorcycle, 330000, 199, 303, 197),
                new Plane("Cessna 182", Type.Plane, 7000000, 230, 324, 894),
                new Plane("Piper PA-28", Type.Plane, 6000000, 215, 300, 1200),
                new Plane("Beechcraft Bonanza", Type.Plane, 7500000, 240, 340, 1000),
                new Plane("Diamond DA40", Type.Plane, 5000000, 190, 290, 900),
                new Plane("Mooney M20", Type.Plane, 6500000, 220, 330, 1100),
                new Car("Tesla Model S", Type.Car, 850000, 670, 250, 2100),
                new Car("Audi A4", Type.Car, 400000, 261, 240, 1550),
                new Boat("Chaparral 21 SSi", Type.Boat, 600000, 200, 80, 1250),
                new Boat("Cobalt R3", Type.Boat, 1100000, 280, 95, 1300),
                new Motorcycle("Harley-Davidson Street Glide", Type.Motorcycle, 350000, 86, 175, 362),
                new Motorcycle("KTM 790 Duke", Type.Motorcycle, 280000, 105, 240, 189),
                new Plane("Cirrus SR22", Type.Plane, 9000000, 310, 350, 1000),
                new Plane("Piper Malibu", Type.Plane, 8500000, 350, 250, 1200),
                new Car("Mercedes-Benz E-Class", Type.Car, 650000, 429, 250, 1800),
                new Car("Volkswagen Golf", Type.Car, 320000, 228, 230, 1500),
                new Car("Subaru Outback", Type.Car, 400000, 260, 220, 1700),
                new Boat("Sunseeker Predator 50", Type.Boat, 2000000, 400, 100, 1600),
                new Boat("Jeanneau NC 37", Type.Boat, 1800000, 350, 90, 1500),
                new Boat("Princess V40", Type.Boat, 2200000, 410, 110, 1700),
                new Motorcycle("Triumph Bonneville T120", Type.Motorcycle, 310000, 80, 215, 224),
                new Motorcycle("Suzuki GSX-R750", Type.Motorcycle, 290000, 148, 299, 198),
                new Motorcycle("Indian Scout", Type.Motorcycle, 340000, 100, 245, 253),
                new Plane("Beechcraft King Air 350", Type.Plane, 12000000, 300, 350, 2500),
                new Plane("Embraer Phenom 300", Type.Plane, 18000000, 450, 420, 3000),
                new Plane("Gulfstream G650", Type.Plane, 65000000, 700, 600, 4500),
            ];
            _users =
            [
                new Person("Chris", [], 300000),
                new Person("Bjarne", [], 2500000),
                new Person("Line", [], 100000),
            ];
            StartGenerate();
        }

        private void StartGenerate()
        {
            for (int i = 0; i < 3; i++)
            {
                GenerateDealership();
            }

            while (true)
            {
                var selected = SelectPerson();
                Console.Clear();
                Console.WriteLine($"{selected.GetName()} er valgt");
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"1. Se {selected.GetName()} sin samling.");
                    Console.WriteLine($"2. Gå ut i verden.");
                    Console.WriteLine($"3. Tilbake.");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        selected.ShowInventory();
                    }
                    else if (input == "2")
                    {
                        _view.Run(selected);
                    }
                    else if (input == "3")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ikke gyldig input");
                        Console.ReadKey(true);
                    }
                }
            }
        }

        private void GenerateDealership()
        {
            var transports = new List<ITransportation>();
            ITransportation selectedtransport;
            for (int i = 0; i < random.Next(5,10); i++)
            {
                selectedtransport = _allTransports[random.Next(_allTransports.Count)];
                transports.Add(selectedtransport);
                _allTransports.Remove(selectedtransport);
            }
            var dealerName = dealershipName[random.Next(0,dealershipName.Count)];
            dealershipName.Remove(dealerName);
            var sellerName = sellers[random.Next(0, sellers.Count)];
            sellers.Remove(sellerName);
            var newSeller = new Person(sellerName);
            var newDealer = new Dealership(transports, dealerName, newSeller);
            _view.AddToList(newDealer);
        }

        private Person SelectPerson()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Velg en person:");
                int counter = 1;
                foreach (var person in _users)
                {
                    Console.WriteLine($"{counter}. {person.GetName()}");
                    counter++;
                }
                var exitsum = _users.Count;
                Console.WriteLine($"{exitsum+1}. Avslutt");
                var input = Convert.ToInt32(Console.ReadLine())-1;
                
                if (input < _users.Count)
                {
                    return _users[input];
                }
                else if (input == exitsum)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ikke gyldig");
                }
            }
        }
    }
}
