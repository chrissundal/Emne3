namespace Oppgave2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number = 55;
            Console.WriteLine($"Dette er et nummer {Number}");
            long BigNumber = 1231221;
            Console.WriteLine($"Stort nummer {BigNumber}");
            float FlotNumber = 1.55F;
            Console.WriteLine($"Floating {FlotNumber}");
            decimal DecimalNumber = 1.11M;
            Console.WriteLine($"Decimaltall {DecimalNumber}");
            double DoubleNumber = 12.454;
            Console.WriteLine($"double {DoubleNumber}");
            string Text = "Dette er en tekst";
            Console.WriteLine($"string {Text}");
            char Character = 'a';
            Console.WriteLine($"char {Character}");
            bool IsCorrect = false;
            Console.WriteLine($"boolean {IsCorrect}");

            int a = 5;
            int b = 3;
            int sum = a + b;

            Console.WriteLine($"Summen er: {sum}");
        }
    }
}
