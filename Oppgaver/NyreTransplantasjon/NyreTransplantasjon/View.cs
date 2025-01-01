using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NyreTransplantasjon
{
    internal class View
    {
        public Person selectedFirstPerson { get; set; }
        public Person selectedSecondPerson { get; set; }

        private string[] MainMenu;

        public View()
        {
            {
                
                Run();
            }
        }

        public void GetMenu()
        {
            string firstPersonInfo = selectedFirstPerson != null ? $"Info om {selectedFirstPerson.Navn}" : "Velg en pasient først"; 
            string secondPersonInfo = selectedSecondPerson != null ? $"Info om {selectedSecondPerson.Navn}" : "Velg en donor først";
            MainMenu = new string[] { "Velg pasient", "Velg donor", firstPersonInfo, secondPersonInfo, "Legg til donor", "Legg til pasient", "Kjør tester","Pasienter rehablitering","Døde", "Avslutt" };
        }

        public void Run()
        {
            Person.InitializePeople();
            var people = Person.GetPeople();
            var patients = Person.GetPasient();
            var recovery = Person.GetRecovery();
            var dead = Person.GetFailed();
            bool exit = false;

            while (!exit)
            {
                GetMenu();
                Console.WriteLine("Nyre transplantasjon");
                
                for (int i = 0; i < MainMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {MainMenu[i]}");
                }

                var input = Convert.ToInt32(Console.ReadLine()) - 1;
                if (input < MainMenu.Length && input >= 0)
                {
                    Console.Clear();
                    Console.WriteLine(MainMenu[input]);
                    if (input == 0)
                    {
                        if (patients.Count > 0)
                        {
                            while (true)
                            {
                                for (int i = 0; i < patients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {patients[i].Navn} Blodtype: {patients[i].Blodtype} Nyrer: {patients[i].Nyrer} Vekt: {patients[i].Vekt} Høyde: {patients[i].Høyde} Alder: {patients[i].Alder}");
                                }
                                var inputPatients = Convert.ToInt32(Console.ReadLine()) - 1;
                                if (inputPatients < patients.Count && inputPatients >= 0)
                                {
                                    selectedFirstPerson = patients[inputPatients];
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ikke gyldig tall");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Her var det tomt");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                    }
                    else if (input == 1)
                    {
                        if (people.Count > 0)
                        {
                            while (true)
                            {
                                for (int i = 0; i < people.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {people[i].Navn} Blodtype: {people[i].Blodtype} Nyrer: {people[i].Nyrer} Vekt: {people[i].Vekt} Høyde: {people[i].Høyde} Alder: {people[i].Alder}");
                                }

                                var inputPeople = Convert.ToInt32(Console.ReadLine()) - 1;
                                if (inputPeople < people.Count && inputPeople >= 0)
                                {
                                    selectedSecondPerson = people[inputPeople];
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ikke gyldig tall");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Her var det tomt");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                    }
                    else if (input == 2 && selectedFirstPerson != null)
                    {
                        Console.Clear();
                        selectedFirstPerson.Show();
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else if (input == 3 && selectedSecondPerson != null)
                    {
                        Console.Clear();
                        selectedSecondPerson.Show();
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else if (input == 4)
                    {
                        people.Add(Person.AddNewPerson());
                        Console.Clear();
                    }
                    else if (input == 5)
                    {
                        patients.Add(Person.AddNewPatient());
                        Console.Clear();
                    }
                    else if (input == 6)
                    {
                        if (selectedSecondPerson != null && selectedFirstPerson != null)
                        {
                            Sykehus sykehus = new Sykehus();
                            sykehus.UtførTransplantasjon(selectedSecondPerson, selectedFirstPerson, this);
                        }
                        else
                        {
                            Console.WriteLine("Personer ikke valgt");
                        }
                    }
                    else if (input == 7)
                    {
                        if (recovery.Count > 0)
                        {
                            for (int i = 0; i < recovery.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {recovery[i].Navn} Blodtype: {recovery[i].Blodtype} Nyrer: {recovery[i].Nyrer} Vekt: {recovery[i].Vekt} Høyde: {recovery[i].Høyde} Alder: {recovery[i].Alder}");
                            }
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Her var det tomt");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                    }
                    else if (input == 8)
                    {
                        if (dead.Count > 0)
                        {
                            for (int i = 0; i < dead.Count; i++)
                            {
                                Console.WriteLine(
                                    $"{i + 1}. {dead[i].Navn} Blodtype: {dead[i].Blodtype} Nyrer: {dead[i].Nyrer} Vekt: {dead[i].Vekt} Høyde: {dead[i].Høyde} Alder: {dead[i].Alder}");
                            }

                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Her var det ingen...");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                    }
                    else if (input == 9)
                    {
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ikke gyldig valg");
                }
            }
        }
    }
}