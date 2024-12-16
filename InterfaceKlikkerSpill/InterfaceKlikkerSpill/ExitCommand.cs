namespace InterfaceKlikkerSpill
{
    internal class ExitCommand : ICommand
    {
        public char Key { get; private set; }

        public ExitCommand()
        {
            Key = 'x';
        }
        public void Run(ClickerGame game)
        {
            Console.WriteLine("Are you sure? (y/n)");
            var input = Console.ReadKey().KeyChar;
            if (input == 'y')
            {
                Environment.Exit(0);
            }
        }
    }
}
