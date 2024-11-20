namespace Overloads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OverloadExample example = new OverloadExample();
            example.PrintWelcomeMessage();
            Console.WriteLine($"{example.OpenText} {example.Compliment}");
            Console.WriteLine("Skriv inn et kompliment:"); 
            string newCompliment = Console.ReadLine();
            example.PrintWelcomeMessage(newCompliment);
            Console.WriteLine($"{example.OpenText} {example.Compliment}");
        }
    }
}
