namespace Objekter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var pikachu = new Pokemon("Pikachu",50,21);
            var bulbasaur = new Pokemon("Bulbasaur",65,15);
            var testPokemon = new Pokemon("Drowzee");

            while (!exit)
            {
                Console.WriteLine("\nHvilken Pokemon vil du se? Velg 1,2,3 eller 4\n");
                Console.WriteLine("1. Pikachu\n");
                Console.WriteLine("2. Bulbasaur\n");
                Console.WriteLine("3. Overload\n");
                Console.WriteLine("4. Avslutt\n");
                var selectNumber = Console.ReadLine();
                switch (selectNumber)
                {
                    case "1":
                        pikachu.Show();
                        break;
                    case "2":
                        bulbasaur.Show();
                        break;
                    case "3":
                        testPokemon.Show();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Sa ikke jeg at du skulle velge 1,2,3 eller 4?");
                        break;
                }
            }
        }
    }
}
