namespace InterfaceKlikkerSpill
{
    internal class ClickCommand : ICommand
    {
        
        public char Key { get; private set; }

        public ClickCommand()
        {
            Key = ' ';
        }
        public void Run(ClickerGame game)
        {
            game.ClickPoint();
        }
    }
}
