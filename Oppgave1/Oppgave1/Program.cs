namespace Oppgave1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hei, hva heter du?");
            var userInput = Console.ReadLine();
            
            Console.WriteLine($"\nVelkommen {userInput}\n");
            
            Console.WriteLine("Hvor gammel er du?");
            var ageInput = Console.ReadLine();
            
            Console.WriteLine($"\nEr du {ageInput} år?\n");
            
            Console.WriteLine("Er du elev?");
            var answerInput = Console.ReadLine();
            
            if (answerInput == "ja")
            {
                Console.WriteLine("\nLykke til videre\n");
            }
            else
            {
                Console.WriteLine("\nDu burde begynne\n");
            }
        }
    }
}
