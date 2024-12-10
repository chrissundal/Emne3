namespace InterfaceIntroTerje
{
    internal class DummyQuestion : IQuestion
    {
        public bool Run()
        {
            Console.WriteLine("Dummy");
            return true;
        }
    }
}
