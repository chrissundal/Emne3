namespace Objekter2
{
    internal class Program
    {
        public void AddPeople()
        {
            //List<Person> people = new List<Person>();

            //Person person1 = new Person("Alice", 25);
            //Person person2 = new Person("Bob", 30);
            //Person person3 = new Person("Charlie", 28);
            //people.Add(person1);
            //people.Add(person2);
            //people.Add(person3);
            List<Person> people = new List<Person>
            {
                new Person("Alice", 25),
                new Person("Bob", 30),
                new Person("Charlie", 28)
            };
            Console.WriteLine("Personer i liste:");
            foreach (var human in people)
            {
                Console.WriteLine($"Navn: {human.Name}, Alder: {human.Age}");
            }

        }
        static void Main(string[] args)
        {
            Program runProgram = new Program();
            runProgram.AddPeople();
        }
    }
}
