namespace NyreTransplantasjon
{
    internal class Person
    {
        public static List<Person> People { get; private set; } = [];
        public static List<Person> Recovery { get; private set; } = [];
        public static List<Person> Failed { get; private set; } = [];
        public static string[] Blodtyper { get; private set; } = ["O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-"];
        public static List<Person> Pasient { get; private set; } = [];

        public string Navn { get; private set; }
        public int Nyrer { get; private set; }
        public string Blodtype { get; private set; }
        public int Vekt { get; private set; }
        public int Høyde { get; private set; }
        public int Alder { get; private set; }
        public bool Alive { get; private set; }

        public Person(string navn, int nyrer, string blodtype, int vekt, int høyde, int alder, bool alive)
        {
            Navn = navn;
            Nyrer = nyrer;
            Blodtype = blodtype;
            Vekt = vekt;
            Høyde = høyde;
            Alder = alder;
            Alive = alive;
        }

        public Person()
        {

        }
        public static void InitializePeople()
        {
            var existingPeople = new List<Person>
            {
                new Person("Kåre", 2, Blodtyper[2], 110, 177, 49,true),
                new Person("Svein", 2, Blodtyper[5], 140, 167, 58,true),
            };
            People.AddRange(existingPeople);
            var existingPatients = new List<Person>
            {
                new Person("Bernt", 0, Blodtyper[2], 95, 185, 55, true),
                new Person("Berit", 0, Blodtyper[3], 75, 170, 75, true),
            };
            Pasient.AddRange(existingPatients);
            var existingRecovery = new Person("Tore", 1, Blodtyper[4], 95, 185, 55, true);
            Recovery.Add(existingRecovery);
        }

        public static List<Person> GetPasient()
        {
            return Pasient;
        }

        public static List<Person> GetPeople()
        {
            return People;
        }
        public static List<Person> GetRecovery()
        {
            return Recovery;
        }
        public static List<Person> GetFailed()
        {
            return Failed;
        }

        public void GiNyre()
        {
            if (Nyrer > 1)
            {
                Nyrer--;
                Console.WriteLine($"{Navn} har gitt bort en nyre. Antall nyrer nå: {Nyrer}");
                Recovery.Add(this);
                if (People.Contains(this))
                {
                    People.Remove(this);
                } 
                else if (Pasient.Contains(this))
                {
                    Pasient.Remove(this);
                }
            }
            else
            {
                Console.WriteLine($"{Navn} har ikke nok nyrer til å gi bort.");
            }
        }

        public void MottaNyre()
        {
            Nyrer++;
            Console.WriteLine($"{Navn} har mottatt en nyre. Antall nyrer nå: {Nyrer}");
            Recovery.Add(this);
            if (People.Contains(this))
            {
                People.Remove(this);
            }
            else if (Pasient.Contains(this))
            {
                Pasient.Remove(this);
            }
        }

        public void Dead()
        {
            Alive = false;
            Failed.Add(this);
            if (People.Contains(this))
            {
                People.Remove(this);
            }
            else if (Pasient.Contains(this))
            {
                Pasient.Remove(this);
            }
        }
        public static Person AddNewPerson()
        {
            Console.Clear();
            Console.WriteLine("Hva er navnet på den mulige donoren?");
            var name = Console.ReadLine();
            int nyrer;
            while (true)
            {
                Console.WriteLine("Hvor mange nyrer har personen?");
                nyrer = Convert.ToInt32(Console.ReadLine());
                if (nyrer == 1 || nyrer == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ugyldig valg. Vennligst skriv inn 1 eller 2.");
                }
            }

            var selectedBlood = "";
            while (true)
            {
                Console.WriteLine("Hvilken blodtype har personen?");
                for (int i = 0; i < Blodtyper.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Blodtyper[i]}");
                }
                var bloodIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (bloodIndex < Blodtyper.Length && bloodIndex >= 0)
                {
                    selectedBlood = Blodtyper[bloodIndex];
                    break;
                }
                else
                {
                    Console.WriteLine("Ikke et gyldig valg");
                }
            }

            Console.WriteLine("Hvor høy er personen?");
            var tall = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor mye veier personen?");
            var weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor gammel er personen?");
            var age = Convert.ToInt32(Console.ReadLine());
            return new Person(name, nyrer, selectedBlood, weight, tall, age,true);
        }
        public static Person AddNewPatient()
        {
            Console.Clear();
            Console.WriteLine("Hva er navnet på pasienten?");
            var name = Console.ReadLine();
            int nyrer;
            while (true)
            {
                Console.WriteLine("Hvor mange nyrer har pasienten?");
                nyrer = Convert.ToInt32(Console.ReadLine());
                if (nyrer is 1 or 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ugyldig valg. Vennligst skriv inn 0 eller 1.");
                }
            }

            var selectedBlood = "";
            while (true)
            {
                Console.WriteLine("Hvilken blodtype har pasienten?");
                for (int i = 0; i < Blodtyper.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Blodtyper[i]}");
                }
                var bloodIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (bloodIndex < Blodtyper.Length && bloodIndex >= 0)
                {
                    selectedBlood = Blodtyper[bloodIndex];
                    break;
                }
                else
                {
                    Console.WriteLine("Ikke et gyldig valg");
                }
            }

            Console.WriteLine("Hvor høy er pasienten?");
            var tall = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor mye veier pasienten?");
            var weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor gammel er pasienten?");
            var age = Convert.ToInt32(Console.ReadLine());
            return new Person(name, nyrer, selectedBlood, weight, tall, age,true);
        }

        public void Show()
        {
            Console.WriteLine($"{Navn} Blodtype: {Blodtype} Nyrer: {Nyrer} Vekt: {Vekt} Høyde: {Høyde} Alder: {Alder}\n");
        }
    }
}