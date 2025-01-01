namespace test
{
    internal class ifElse
    {
        Random rnd = new Random();
        int number;
        bool isEqual = false;

        
        public void Run()
        {
            number = rnd.Next(1, 20);
            while (!isEqual)
            {
                Console.WriteLine("Find the same Number");
                var number2 = Console.ReadLine();
                int Check = Convert.ToInt32(number2);
                int sum = number + Check;
                int multiSum = number * Check;
                if (number == Check)
                {
                    isEqual = true;
                    Console.WriteLine("Same numbers");
                }
                else
                {
                    isEqual = false;
                    Console.WriteLine("Numbers dont match");
                    Console.WriteLine($"Sum is {sum}");
                }

                if (sum == 30)
                {
                    isEqual = true;
                }
                else
                {
                    Console.WriteLine("Sum is not 30");
                }

                if (isEqual)
                {
                    Console.WriteLine($"You made it {multiSum}");
                }
            }
        }
        static void Main(string[] args)
        {
            ifElse executeRun = new ifElse();
            executeRun.Run();
            
        }
    }
}
