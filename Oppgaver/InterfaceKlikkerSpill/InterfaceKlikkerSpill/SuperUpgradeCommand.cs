namespace InterfaceKlikkerSpill
{
    internal class SuperUpgradeCommand : ICommand
    {

        public char Key { get; private set; }

        public SuperUpgradeCommand()
        {
            Key = 's';
        }
        public void Run(ClickerGame game)
        {
            if (game.GetPoints() >= 100)
            {
                game.SuperUpgrade();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You dont have enough points");
                Console.ReadKey();
            }

        }
    }
}
