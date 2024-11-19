namespace OppgaveHvakodengjor
{
    public class CharObject
    {
        public char Character { get; set; }
        public int Count { get; set; }
        public double Prosent { get; set; }
    }

    internal class Program
    {
        public void Run()
        {
            var range = 250;
            var counts = new int[range];
            double totalChar = 0.00;
            string text = "something";
            Console.WriteLine("Skriv ett ord");
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine();
                string fixText = text.ToLower();
                foreach (var character in fixText ?? string.Empty)
                {
                    counts[(int)character]++;
                    totalChar++;
                }
                var charList = new List<CharObject>();

                for (var i = 0; i < range; i++)
                {
                    if (counts[i] > 0)
                    {
                        var character = (char)i;
                        double prosenter = counts[i] / totalChar * 100;
                        charList.Add(new CharObject
                        {
                            Character = character, 
                            Count = counts[i], 
                            Prosent = prosenter
                        });
                    }
                }
                charList.Sort((a, b) => b.Prosent.CompareTo(a.Prosent));
                foreach (var sorted in charList)
                {
                        Console.WriteLine($"{sorted.Character} - {sorted.Count} {sorted.Prosent:F2}%");
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
