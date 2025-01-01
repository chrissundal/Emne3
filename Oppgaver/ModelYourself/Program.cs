using System;
using System.Threading;

namespace ModelYourself
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            var person1 = new Person("Chris", 37, "brunt", "kjøre racedroner");
            var person2 = new Person("Nico", 31, "brunt", "spille fotball");
            while (!exit)
            {
                Console.WriteLine("Velg ett av alternativene");
                Thread.Sleep(200);
                Console.WriteLine("1. Test person 1");
                Thread.Sleep(200);
                Console.WriteLine("2. Test person 2");
                Thread.Sleep(200);
                Console.WriteLine("3. Bygg din Person");
                Thread.Sleep(200);
                Console.WriteLine("4. Exit");
                Thread.Sleep(200);
                var choices = Convert.ToInt32(Console.ReadLine());
                switch (choices)
                {
                    case 1:
                        person1.Show();
                        break;
                    case 2:
                        person2.Show(); 
                        break;
                    case 3:
                        Console.Clear();
                        var userCreatedPerson = Person.CreatePerson();  
                        userCreatedPerson.Show();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Sa ikke jeg att du skulle velge ett av alternativene?");
                        break;
                }
            }
        }
    }
}
