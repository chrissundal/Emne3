using DependencyInversion.Server;

namespace DependencyInversion
{
    internal class ChatClient : IChatClient
    {
        private string _name;
        private ChatServer _server;

        public ChatClient(string name, ChatServer server)
        {
            _name = name;
            _server = server;
            _server.Register(this);
        }
        public void Say(string message)
        {
            _server.BroadCast(this, $"{_name} sier {message}");
        }

        public void Recieve(string message)
        {
            Console.WriteLine($"{_name} mottok: {message}");
        }
    }
}
