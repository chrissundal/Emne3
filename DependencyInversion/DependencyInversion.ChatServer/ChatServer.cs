namespace DependencyInversion.Server
{
    public class ChatServer
    {
        private List<IChatClient> _clients;

        public ChatServer()
        {
            _clients = [];
        }

        public void BroadCast(IChatClient client, string message)
        {
            foreach (var chatClient in _clients)
            {
                if (chatClient != client)
                {
                    chatClient.Recieve(message);
                }
            }
        }
        public void Register(IChatClient chatClient)
        {
            _clients.Add(chatClient);
        }
    }
}
