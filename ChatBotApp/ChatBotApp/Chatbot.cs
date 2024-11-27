using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotApp
{
    internal class Chatbot
    {
        public string Name { get; private set; }
        public List<string> Response { get; private set; }

        public Chatbot(string name)
        {
            Name = name;
            Response = new List<string>();
        }

        public string GetRandomResponse()
        {
            Random random = new Random();
            int index = random.Next(Response.Count);
            return Response[index];
        }
    }
}
