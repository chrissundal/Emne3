namespace InterfaceKlikkerSpill
{
    internal class UpgradeCommand : ICommand
    {

        public char Key { get; private set; }

        public UpgradeCommand()
        {
            Key = 'k';
        }
        public void Run(ClickerGame game)
        {
            if (game.GetPoints() >= 10)
            {
                game.Upgrade();
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
