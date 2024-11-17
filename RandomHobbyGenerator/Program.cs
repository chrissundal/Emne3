using Microsoft.VisualBasic.CompilerServices;

namespace RandomHobbyGenerator
{
    internal class Program
    {
        string[] hobbies = { "Stamp-collecting", "football-playing", "lord of the rings re-enactor", "dancing", "Kickboxing", "Golfing", "Swimming" };

        string[] answers =
            { "it looks like your new hobby is", "is it true your hobby are", "wow, your hobby are" };
        Random rnd = new Random();
        int number = 0;
        public void Run()
        {
            while(number < hobbies.Length)
            {
                int AnswerIndex = rnd.Next(answers.Length);
                int index = rnd.Next(hobbies.Length);
                string randomHobby = hobbies[index];
                string randomAnswer = answers[AnswerIndex];
                Console.WriteLine("\nWho would like a new hobby?");
                var firstAnswer = Console.ReadLine();
                Console.WriteLine($"So {firstAnswer} {randomAnswer} {randomHobby}?");
                number++;
            }
        }


        public 
        static void Main(string[] args)
        {
            Program runRandom = new Program();
            runRandom.Run();
        }
    }
}
