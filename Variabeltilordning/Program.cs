namespace Variabeltilordning
{
    internal class Program
    {
            int tall = 1;
            float desimaltall = 1.01F;
            double desimaltall2 = 1.01;
            decimal desimaltall3 = 1.01M;
            char bokstav = 'a';
            string tekst = "Hei";
            bool santUsant = true;
            string[] tekstArray = { "hei", "på", "deg" };
            int[] tallArray = { 1, 2, 3 };
            List<int> listeMedTall = new List<int>();
            string returnVerdi = "Denne metoden returnerer ingenting";
            int firstNumber = 5;
            int secondNumber = 3;



        public int DenneReturnererTall()
        {
            int ettTall = 5;
            return ettTall;
        }

        public int DenneFunksjonenTarInnToTall(int input1, int input2)
        {
            return input1 + input2;
        }

        public string ReturnString()
        {
            return tekst;
        }
        int tall1 = 1;
        int tall2 = 2;

        public int ReturnWholeNumber(int number, int number2)
        {
            return number + number2;
        }

        public double ReturnDouble()
        {
            return 2.531;
        }

        public bool ReturnBoolean()
        {
            return santUsant;
        }

        public string ReturnNothing()
        {
            return returnVerdi;
        }
        public void Run()
        {
            Console.WriteLine($"Dette er en String:{ReturnString()}");
            Console.WriteLine($"Dette er en int:{ReturnWholeNumber(tall1, tall2)}");
            Console.WriteLine($"Dette er en double:{ReturnDouble()}");
            Console.WriteLine($"Dette er en Boolean:{ReturnBoolean()}");
            Console.WriteLine($"{ReturnNothing()}");
            Console.WriteLine($"\n Hva er størst av {firstNumber} og {secondNumber}? \n");
            var check = Console.ReadLine();
            int convNumber = Convert.ToInt32(check);
            if (convNumber == 5)
            {
                Console.WriteLine($"Det var riktig. Svaret er {firstNumber}");
            }
            else
            {
                Console.WriteLine($"Feil, svaret var {firstNumber}");
                
            }
        }

        static void Main(string[] args)
        {
            Program writeConsole = new Program();
            writeConsole.Run();
        }
    }
}
