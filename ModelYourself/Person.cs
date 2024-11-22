namespace ModelYourself
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string HairColor { get; set; }
        public string Hobby { get; set; }

        public Person(string name, int age, string haircolor, string hobby)
        {
            Name = name;
            Age = age;
            HairColor = haircolor;
            Hobby = hobby;
        }

        public static Person CreatePerson()
        {
            Console.Clear();
            Console.WriteLine("Lag din personlighet");
            Console.WriteLine("Hva er ditt navn?");
            var name = Console.ReadLine();
            Console.WriteLine("Hvor gammel er du?");
            var age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hva er din hårfarge?");
            var hairColor = Console.ReadLine();
            Console.WriteLine("Hva er din hobby?");
            var hobby = Console.ReadLine();
            return new Person(name, age, hairColor, hobby);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"\nHei, jeg heter {Name}! Jeg er {Age} år gammel og jeg har {HairColor} hår. Jeg liker å {Hobby} på fritiden.\n");
        }
    }
}
