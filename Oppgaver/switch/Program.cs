namespace switchOppgave;

internal class Program
{
    string[] dayArray = { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" };

    public void Run()
    {
        int index = dayArray.Length;

        Console.WriteLine("Hvilken dag er det?");
        var input = Convert.ToInt32(Console.ReadLine());

        //if (input >= 1 && input <= 7)
        //{
        //    Console.WriteLine($"Dagen er: {dayArray[input - 1]}");
        //}
        //else
        //{
        //    Console.WriteLine("Ugyldig input. Skriv inn et nummer fra 1 til 7."); 
        //    Run();
        //}

        switch (input)
        {
            case int day when day >= 1 && day <= 7:
                Console.WriteLine($"Dagen er: {dayArray[input - 1]}");
                break;
            default:
                Console.WriteLine("Ugyldig input. Skriv inn et nummer fra 1 til 7.");
                Run();
                break;
        }

        //switch (input)
        //{
        //    case 1:
        //        Console.WriteLine($"Dagen er: {dayArray[0]}");
        //        break;
        //    case 2:
        //        Console.WriteLine($"Dagen er: {dayArray[1]}");
        //        break;
        //    case 3:
        //        Console.WriteLine($"Dagen er: {dayArray[2]}");
        //        break;
        //    case 4:
        //        Console.WriteLine($"Dagen er: {dayArray[3]}");
        //        break;
        //    case 5:
        //        Console.WriteLine($"Dagen er: {dayArray[4]}");
        //        break;
        //    case 6:
        //        Console.WriteLine($"Dagen er: {dayArray[5]}");
        //        break;
        //    case 7:
        //        Console.WriteLine($"Dagen er: {dayArray[6]}");
        //        break;
        //    default:
        //        Console.WriteLine("Ugyldig input. Skriv inn et nummer fra 1 til 7.");
        //        Run();
        //        break;
        //}

        //switch (input)
                //{
                //    case "1":
                //        Console.WriteLine("Mandag");
                //        break;
                //    case "2":
                //        Console.WriteLine("Tirsdag");
                //        break;
                //    case "3":
                //        Console.WriteLine("Onsdag");
                //        break;
                //    case "4":
                //        Console.WriteLine("Torsdag");
                //        break;
                //    case "5":
                //        Console.WriteLine("Fredag");
                //        break;
                //    case "6":
                //        Console.WriteLine("Lørdag");
                //        break;
                //    case "7":
                //        Console.WriteLine("Søndag");
                //        break;
                //    default:
                //        Run();
                //        break;
                //}

        }
    static void Main(string[] args)
    {
        Program runProgram = new Program();
        runProgram.Run();
    }
}
