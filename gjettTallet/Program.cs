namespace gjettTallet
{
    internal class Program
    {
        int RandomNumber;
        bool exit = false;
        int CountNumber = 0;
        bool isGameOver = false;
        public void InitRandom()
        {
            Random rnd = new Random();
            RandomNumber = rnd.Next(1, 100);
        }
        public void Run()
        {
            InitRandom();

            while (!exit)
            { 
                Console.WriteLine("Gjett ett tall mellom 1 - 100");
                var answer = Convert.ToInt32(Console.ReadLine());
                if (answer > 100)
                {
                    Console.WriteLine("Øy, hva sa jeg? Hold deg Under 100! Det her kosta deg ett trekk.");
                    CountNumber++;
                }
                else if (answer < RandomNumber)
                {
                    Console.WriteLine($"Nummeret er større enn {answer}");
                    CountNumber++;
                }
                else if (answer > RandomNumber)
                {
                    Console.WriteLine($"Nummeret er mindre enn {answer}");
                    CountNumber++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Tallet er riktig. Svaret var: {RandomNumber} og du klarte det på {CountNumber} forsøk.");
                    isGameOver = true;
                    GameOver();
                }

            }
        }

        public void GameOver()
        {
            while (isGameOver)
            { 
                Console.WriteLine("\nVil du spille igjen? Velg ett alternativ:");
                Console.WriteLine("\n1. Ja, skal gruse rekorden");
                Console.WriteLine("\n2. Nei, har fått nok");
                var restart = Console.ReadLine();
                if (restart == "1")
                {
                    Console.Clear();
                    CountNumber = 0;
                    isGameOver = false;
                    InitRandom();
                }
                else if (restart == "2")
                {
                    exit = true;
                    isGameOver = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sa jo at du skulle velge ett av de 2...");
                }
            }
        }
        static void Main(string[] args)
        {
            Program runProgram = new Program();
            runProgram.Run();
        }
    }
}
