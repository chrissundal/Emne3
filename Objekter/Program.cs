namespace Objekter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var pikachu = new Pokemon("Pikachu",50,21);
            var bulbasaur = new Pokemon("Bulbasaur",65,15);
            while (!exit)
            {
                Console.WriteLine("\nHvilken Pokemon vil du se? Velg 1,2 eller 3\n");
                Console.WriteLine("1. Pikachu\n");
                Console.WriteLine("2. Bulbasaur\n");
                Console.WriteLine("3. Avslutt\n");
                    var selectNumber = Console.ReadLine();
                if (selectNumber == "1")
                {
                    pikachu.Show();
                }
                else if (selectNumber == "2")
                {
                    bulbasaur.Show();
                }
                else if (selectNumber == "3")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Sa ikke jeg at du skulle velge 1,2 eller 3?");
                }
            }
        }
    }
}
