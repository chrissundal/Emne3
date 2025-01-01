using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotApp
{
    internal class View
    {
        private static List<Chatbot> chatbots = new List<Chatbot>();
        public View()
        {
            Run();
        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {

            Console.WriteLine("Velkommen til Chatbot");
            Console.WriteLine("1. mekke en chættbått");
            Console.WriteLine("2. preke med en chættbått");
            Console.WriteLine("3. Avslutt");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateChatbot();
                    break;
                case "2":
                    TalkToChatBot();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Ugyldig");
                    break;
            }
            }
        }

        static void CreateChatbot()
        {
            Console.WriteLine("Gi et nytt navn til båtten");
            var name = Console.ReadLine();
            var newChatbot = new Chatbot(name);
            chatbots.Add(newChatbot);
            while (true)
            {
                Console.WriteLine("Skriv inn ett svar for chættbått'n (eller skriv 'ferdig' for å avslutte");
                var response = Console.ReadLine();
                if (response.ToLower() == "ferdig")
                {
                    break;
                }
                else
                {
                    newChatbot.Response.Add(response);
                }
            }

            Console.WriteLine($"Chættbått'n '{newChatbot.Name}' er laget med {newChatbot.Response.Count} svar!");
        }

        static void TalkToChatBot()
        {
            if (chatbots.Count == 0)
            {
                Console.WriteLine("Det finnes ingen chættbåtts her enda. Lag en først");
                return;
            }

            Console.WriteLine("Velg en chættbot å snakke med:");
            for (int i = 0; i < chatbots.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chatbots[i].Name}");
            }
            var BotIndex = Convert.ToInt32(Console.ReadLine()) -1;
            if (BotIndex >= 0 && BotIndex < chatbots.Count)
            {
            var selectedChatBot = chatbots[BotIndex];
            Console.WriteLine($"Du preker nå med {selectedChatBot.Name}. Skriv inn meldingen din");

            while (true)
            {
                Console.WriteLine("skriv avslutt for å avslutte");
                var userMessage = Console.ReadLine();
                if (userMessage.ToLower() == "avslutt")
                {
                    break;
                }

                var chatbotResponse = selectedChatBot.GetRandomResponse();
                Console.WriteLine($"{selectedChatBot.Name}: {chatbotResponse}");
            }
            }
            else
            {
                Console.WriteLine("Velg en tilgjengelig");
            }
        }
    }
}
