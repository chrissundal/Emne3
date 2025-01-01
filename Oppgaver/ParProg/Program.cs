using System;
using System.Threading;

namespace ParProg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var runProgram = new Program();
            runProgram.Run(exit);
        }

        private void Run(bool exit)
        {
            Console.WriteLine("Skriv en tekst");
            var input = Console.ReadLine();
            while (!exit)
            {
                Console.WriteLine("Velg ett alternativ\n");
                Console.WriteLine("1.Reverser\n");
                Thread.Sleep(500);
                Console.WriteLine("2.Uppercase\n");
                Thread.Sleep(500);
                Console.WriteLine("3.Lowercase\n");
                Thread.Sleep(500);
                Console.WriteLine("4.Exit\n");
                Thread.Sleep(500);

                var nSelector = Convert.ToInt32(Console.ReadLine());

                if (nSelector == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string reversed = "";
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        reversed += input[i];
                    }
                    Console.WriteLine($"konvertert til {reversed}\n");
                }
                else if (nSelector == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"konvertert til {input.ToUpper()}\n");
                }
                else if (nSelector == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"konvertert til {input.ToLower()}\n");
                }
                else if (nSelector == 4)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("skriv bare ett av alternativene sa jeg jo!\n");
                }
            }
        }
    }
}
