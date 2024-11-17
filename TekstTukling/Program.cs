namespace TekstTukling
{
    internal class Program
    {
        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nVelg ett alternativ\n");
                Console.WriteLine("1. RotateText\n");
                Console.WriteLine("2. ChangeWord\n");
                Console.WriteLine("3. Begge\n");
                Console.WriteLine("4. Exit\n");

                var numberSelector = Convert.ToInt32(Console.ReadLine());

                if (numberSelector == 1)
                {
                    Console.WriteLine("\nDu valgte å rotere teksten");
                    Console.WriteLine("Skriv inn ett ord");
                    var inputWord = Console.ReadLine();
                    string reversed = "";
                    for (int i = inputWord.Length - 1; i >= 0; i--)
                    {
                        reversed += inputWord[i];
                    }

                    Console.WriteLine(reversed);
                }
                else if (numberSelector == 2)
                {
                    Console.WriteLine("\nDu valgte å bytte ut e med a");
                    Console.WriteLine("Skriv inn ett ord");
                    var secondInput = Console.ReadLine();
                    string changeLetter = "";

                    foreach (char character in secondInput)
                    {
                        if (character == 'e')
                        {
                            changeLetter += 'a';
                        }
                        else
                        {
                            changeLetter += character;
                        }
                    }

                    Console.WriteLine(changeLetter);
                }
                else if (numberSelector == 3)
                {
                    Console.WriteLine("\nDu valgte begge");
                    Console.WriteLine("Skriv inn ett ord");
                    var inputBoth = Console.ReadLine();
                    string changeBoth = "";
                    for (int i = inputBoth.Length - 1; i >= 0; i--)
                    {
                        if (inputBoth[i] == 'e')
                        {
                            changeBoth += 'a';
                        }
                        else
                        {
                            changeBoth += inputBoth[i];
                        }
                    }
                    Console.WriteLine(changeBoth);
                }
                else if (numberSelector == 4)
                {
                    exit = true;
                    Console.WriteLine("Da var det over for denne gang");
                }
                else
                {
                    Console.WriteLine("Ugyldig valg");
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
