namespace innkapsling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var stats = new Stats();
            while (true)
            {
                Console.WriteLine("Skriv et tall (eller blankt for å avslutte): ");
                var numberStr = Console.ReadLine();
                if (string.IsNullOrEmpty(numberStr)) break;
                var number = Convert.ToInt32(numberStr);
                stats.AddNumber(number);
                var sum = stats.Sum;
                Console.WriteLine(
                    $"Antall tall: {stats.NumberCount}" +
                    $"Sum: {stats.Sum} " +
                    $"Snitt: {stats.Mean}");
            }
        }
    }
}
