namespace Krokodillespill
{
    internal class Program
    {
        Random rnd = new Random();
        public void Run()
        {
            int score = 0;
            bool exit = false;
            Console.WriteLine("Krokodillespill");
            Console.WriteLine("Skriv inn < = >");
            while (exit == false)
        {
            int firstNumber = rnd.Next(1, 11);
            int secondNumber = rnd.Next(1, 11);

            Console.WriteLine($"Du har {score} poeng\n"); 
            Console.WriteLine(firstNumber + " _ " + secondNumber);

            var input = Console.ReadLine();

            if (input == "<" || input == ">" || input == "=")
            {
                if (firstNumber < secondNumber && input == "<")
                {
                    Console.WriteLine("\nRiktig");
                    score++;
                }
                else if (firstNumber > secondNumber && input == ">")
                {
                    Console.WriteLine("\nRiktig");
                    score++;
                }
                else if (firstNumber == secondNumber && input == "=")
                {
                    Console.WriteLine("\nRiktig");
                    score++;
                }
                else
                {
                    Console.WriteLine("\nFeil");
                    score--;
                }
            }
            else
            {
                exit = true;
            }
        }
        Console.WriteLine($"Spillet er Avsluttet. Din totalsum ble: {score}");
        }
        static void Main(string[] args)
        {
            Program runProgram = new Program();
            runProgram.Run();
        }
    }
}
