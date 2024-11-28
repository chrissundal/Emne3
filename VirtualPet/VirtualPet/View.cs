using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace VirtualPet
{
    internal class View
    {
        private string[] firstMenu = ["Velg dyr", "Lag nytt dyr", "Avslutt"];
        private string[] gameMenu = ["Mate", "Tur", "Sove","Hovedmeny"];
        private Animal selectedAnimal { get; set; }

        public View()
        {
            Run();
        }
        public void Run()
        {
            var animals = Animal.Animals;
            bool exit = false;
            bool gamemode = false;
            
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til dyrefabrikken");
                Console.WriteLine("Velg ett av alternativene:");
                for (int i = 0; i < firstMenu.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {firstMenu[i]}");
                }
                var readMenu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Du valgte {firstMenu[readMenu -1]}");
                if (readMenu == 1)
                {
                    ShowAnimals(animals);
                    Console.Clear();
                    if (selectedAnimal != null)
                    {
                        gamemode = true;
                    }
                }
                else if (readMenu == 2)
                {
                    var newAnimal = Animal.CreateNewAnimal();
                    Console.WriteLine($"Nytt dyr lagt til: {newAnimal.Name}");
                    
                }
                else if (readMenu == 3)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Ikke et gyldig valg");
                }

                while (gamemode)
                {
                    Console.WriteLine($"Valgt dyr: {selectedAnimal.Name}");
                    Stats();
                    for (var i = 0; i < gameMenu.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {gameMenu[i]} ");
                    }
                    var input = Convert.ToInt32(Console.ReadLine()) -1;
                    if (input < gameMenu.Length)
                    {
                        if (input == 0)
                        {
                            selectedAnimal.FeedAnimal();
                        }
                        else if (input == 1) 
                        {
                            selectedAnimal.WalkAnimal();
                        }
                        else if (input == 2) 
                        {
                            selectedAnimal.SleepAnimal();
                        }
                        else if (input == 3) 
                        {
                            gamemode = false;
                        }
                        else
                        {
                            Console.WriteLine("ikke ett gyldig valg");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Ikke gyldig tall");
                        
                    }
                }
            }
        }

        public void Stats()
        {
            var energyBar = ""; 
            var bladderBar = ""; 
            var hungerBar = ""; 
            var Barwidth = 10;
            for (int i = 0; i < selectedAnimal.Health; i++)
            {
                energyBar += "\u2593\u2593";
            }

            for (int i = 0; i < selectedAnimal.Bladder; i++)
            {
                bladderBar += "\u2593\u2593";
            }

            for (int i = 0; i < selectedAnimal.Food; i++)
            {
                hungerBar += "\u2593\u2593";
            } 
            Console.Clear();
            Console.WriteLine($"Energy : {energyBar.PadRight(Barwidth * 2)} {selectedAnimal.Health * 10}%\n"); 
            Console.WriteLine($"Bladder: {bladderBar.PadRight(Barwidth * 2)} {selectedAnimal.Bladder * 10}%\n"); 
            Console.WriteLine($"Hunger : {hungerBar.PadRight(Barwidth * 2)} {selectedAnimal.Food * 10}%\n"); 
            
        }
        private void ShowAnimals(List<Animal> animals)
        {
            Console.WriteLine("Select a animal");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i+1} {animals[i].Name}");
                
            }
            var input = Convert.ToInt32(Console.ReadLine()) -1;
            Console.WriteLine($"input {input}");
            if (input < animals.Count)
            {
                selectedAnimal = animals[input];
            }
            else
            {
                Console.WriteLine("Ikke gyldig svar");
            }
        }
    }
}
