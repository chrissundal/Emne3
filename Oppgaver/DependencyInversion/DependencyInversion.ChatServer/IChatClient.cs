namespace DependencyInversion.Server
{
    public interface IChatClient
    {
        void Recieve(string message);
    }
}
