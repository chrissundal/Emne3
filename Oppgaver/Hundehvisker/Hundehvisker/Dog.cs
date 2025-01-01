using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hundehvisker
{
    internal class Dog
    {
        public string Name { get; private set; }
        public string Breed { get; private set; }
        public string Color { get; private set; }
        public string Size { get; private set; }
        public string[] Toys { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public int Hunger { get; private set; }
        public int Fun { get; private set; }
        public int Energy { get; private set; }

        public Dog(string name, string breed, string color, string size, string[] toys, int age, string gender, int hunger, int fun, int energy)
        {
            Name = name;
            Breed = breed;
            Color = color;
            Size = size;
            Toys = toys;
            Age = age;
            Gender = gender;
            Hunger = hunger;
            Fun = fun;
            Energy = energy;
        }

        public Dog()
        {

        }
        private void Show()
        {
            string toyCollection = GetToyCollection();
            Console.WriteLine(
                $"Navn: {Name}, Rase: {Breed}, Farge: {Color}, Leker: {toyCollection}Størrelse: {Size}, Alder: {Age}, Kjønn: {Gender}");
        }

        private void StatsFun(int labelWidth)
        {
            var funBar = "";
            string funLabel = "Gøy";
            for (int i = 0; i < Fun; i++)
            {
                funBar += "\u2593\u2593";
            }

            if (Fun > 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Fun <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            labelWidth -= funLabel.Length;
            Console.WriteLine(funLabel + ":" + String.Empty.PadLeft(labelWidth, ' ') + funBar + Fun * 10+"%");
            
        }
        private void StatsEnergy(int labelWidth)
        {
            var energyBar = "";
            string energyLabel = "Energi";
            for (int i = 0; i < Energy; i++)
            {
                energyBar += "\u2593\u2593";
            }

            if (Energy > 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Energy <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            labelWidth -= energyLabel.Length;
            Console.WriteLine(energyLabel + ":" + String.Empty.PadLeft(labelWidth, ' ') + energyBar + Energy * 10 + "%");

        }
        private void StatsHunger(int labelWidth)
        {
            string hungerLabel = "Mat";
            var hungerBar = "";
            for (int i = 0; i < Hunger; i++)
            {
                hungerBar += "\u2593\u2593";
            }

            if (Hunger > 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Hunger <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            
            labelWidth -= hungerLabel.Length;
            Console.WriteLine(hungerLabel + ":" + String.Empty.PadLeft(labelWidth, ' ') + hungerBar + Hunger * 10 + "%");
        }
        private string GetToyCollection()
        {
            string toyCollection = "";
            for (int i = 0; i < Toys.Length; i++)
            {
                toyCollection += Toys[i];

                toyCollection += ", ";
            }

            return toyCollection;
        }

        private void Sleep()
        {
            if (Energy < 10)
            {
                Energy = 10;
                Hunger -= 4;
                Fun -= 2;
                Console.WriteLine($"{Name} hadde seg en real strekk.");
            }
            else
            {
                Fun -= 2;
                Console.WriteLine($"{Name} har ikke lyst til å sove nå...");
            }
        }
        private void Eat()
        {
            if (Hunger < 10)
            {
                Hunger = 10;
                Fun -= 2;
                if (Energy < 10)
                {
                    Energy += 2;
                }
                else if (Energy > 100)
                {
                    Energy = 100;
                }
                Console.WriteLine($"{Name} synes det var godt med mat.");
            }
            else
            {
                Fun -= 3;
                Console.WriteLine($"{Name} er stappa mett");
            }
        }

        private void Play()
        {
            Console.WriteLine($"Hvilken leke skal {Name} leke med?\n");
            for (int i = 0; i < Toys.Length; i++)
            {
                Console.WriteLine($"{i +1}.{Toys[i]}\n");
            }

            var playAnswer = Convert.ToInt32(Console.ReadLine()) -1;
            if (playAnswer < Toys.Length)
            {
                Console.WriteLine($"Du valgte {Toys[playAnswer]}\n");

                if (Fun < 10)
                {
                    if (playAnswer == 1)
                    {
                        Console.Clear();
                        Hunger -= 3;
                        Energy -= 3;
                        Fun += 4;
                        Console.WriteLine($"{Name} ble helt vill når {Gender} fikk sin {Toys[playAnswer]}, dette er nok favoritten");
                    }
                    else if (playAnswer == 2)
                    {
                        Console.Clear();
                        Hunger -= 2;
                        Energy -= 2;
                        Fun += 2;
                        Console.WriteLine($"{Name} synes sin {Toys[playAnswer]} var litt moro, men det dabbet fort av...");
                    }
                    else
                    {
                        Console.Clear();
                        Hunger -= 2;
                        Energy -= 3;
                        Fun += 3;
                        Console.WriteLine($"{Name} kastet seg rundt med sin {Toys[playAnswer]}, og ble veldig fornøyd");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{Name} vil ikke leke mer");
                }
            }
            else
            {
                Console.Clear();
                Fun -= 3;
                Console.WriteLine($"Ugyldig valg. {Name} fikk ingenting og ble ikke veldig fornøyd.");
            }
        }

        private void Treat()
        {
            Console.WriteLine("Hvordan godbit vil du gi?");
            Console.WriteLine("1.Bein");
            Console.WriteLine("2.Hundekjeks");
            Console.WriteLine("3.Griseøre");
            var treatAnswer = Console.ReadLine();
            if (Hunger < 10)
            {
                if (treatAnswer == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"{Name} kastet seg over beinet, og brukte god tid på det");
                    Hunger += 1;
                    Energy -= 2;
                    if (Fun < 10)
                    {
                        Fun += 1;
                    }
                }
                else if (treatAnswer == "2")
                {
                    Console.Clear();
                    Console.WriteLine($"{Name} ga pent labb og fikk en godbit");
                    Hunger += 1;
                    Energy -= 1;
                    if (Fun < 10)
                    {
                        Fun += 1;
                    }
                }
                else if (treatAnswer == "3")
                {
                    Console.Clear();
                    Console.WriteLine($"Her koset {Name} seg voldsomt, og den ble nesten slukt ned");
                    Hunger += 1;
                    Energy -= 1;
                    if (Fun < 10)
                    {
                        Fun += 1;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ugyldig svar, {Name} fikk ingenting :(");
                    Fun -= 1;
                }
            }
            else
            {
                Console.Clear();
                Energy -= 1;
                Console.WriteLine($"{Name} ga pent labb men orket ikke noe godbit");
            }
            
        }

        public void Run()
        {
            var labelWidth = 8;
            var exit = false;
            var start = true;
            var dog1 = new Dog("Fido", "Pitbull", "Svart", "Stor", ["Ball", "Bein", "Tau"], 10, "han", 5, 5, 5);
            var dog2 = new Dog("Sam", "Flatcoat Retriever", "Brun", "Stor", ["Tau", "Pipeleke"], 4, "han", 5, 5, 5);
            var dog3 = new Dog("Bella", "Beagle", "Hvit", "Middels", ["Ball", "Knute"], 4, "hun", 5, 5, 5);
            var dogs = new List<Dog>() { dog1, dog2, dog3 };
            var selectedDog = new Dog();

            while (!exit)
            {
                while (start)
                {
                    DogChoices(dog1, dog2, dog3);
                    var InputSelectDog = Console.ReadLine();
                    switch (InputSelectDog)
                    {
                        case "1":
                            selectedDog = dog1;
                            break;
                        case "2":
                            selectedDog = dog2;
                            break;
                        case "3":
                            selectedDog = dog3;
                            break;
                        default:
                            Console.WriteLine("Velg en av hundene");
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine($"Du har valgt: {selectedDog.Name}");
                    start = false;
                }
                selectedDog.StatsHunger(labelWidth);
                selectedDog.StatsEnergy(labelWidth);
                selectedDog.StatsFun(labelWidth);
                Console.ResetColor();
                Menu();
                var inputNumber = Console.ReadLine();

                switch (inputNumber)
                {
                    case "1":
                        {
                        Console.Clear();
                        selectedDog.Show();
                        break;
                        }
                    case "2":
                        Console.Clear();
                        selectedDog.Eat();
                        break;
                    case "3":
                        Console.Clear();
                        selectedDog.Play();
                        break;
                    case "4":
                        Console.Clear();
                        selectedDog.Treat();
                        break;
                    case "5":
                        Console.Clear();
                        selectedDog.Sleep();
                        break;
                    case "6":
                        start = true;
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Velg ett av alternativene");
                        break;
                }
            }
            
        }

        private void DogChoices(Dog dog1, Dog dog2, Dog dog3)
        {
            Console.WriteLine("Velg en av hundene:");
            Console.WriteLine($"1. {dog1.Name}");
            Thread.Sleep(100);
            Console.WriteLine($"2. {dog2.Name}");
            Thread.Sleep(100);
            Console.WriteLine($"3. {dog3.Name}");
            Thread.Sleep(100);
        }

        private void Menu()
        {
            Console.WriteLine("Velg ett alternativ:");
            Thread.Sleep(100);
            Console.WriteLine("\n1.Info om hund");
            Thread.Sleep(100);
            Console.WriteLine("\n2.Mat hund");
            Thread.Sleep(100);
            Console.WriteLine("\n3.Lek med hund");
            Thread.Sleep(100);
            Console.WriteLine("\n4.Gi hunden godbit");
            Thread.Sleep(100);
            Console.WriteLine("\n5.Ta en cowboystrekk");
            Thread.Sleep(100);
            Console.WriteLine("\n6.Velg ny hund");
            Thread.Sleep(100);
            Console.WriteLine("\n7.Avslutt\n");
            Thread.Sleep(100);
        }
    }
}

