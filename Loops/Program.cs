namespace Loops
{
    internal class Program
    {
        public void Run()
        {
            string text = "Terje er kul!";

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(text);
            }

            foreach (var chara in text)
            {
                Console.WriteLine(chara);
            }
            int RoundNumber = 1;
            while (RoundNumber <= 10)
            {
                Console.WriteLine($"Runde nummer: {RoundNumber}");
                RoundNumber++;
            }
        }

        static void Main(string[] args)
        {
            Program runProgram = new Program();
            runProgram.Run();
        }
    }
}
