namespace InterfaceKlikkerSpill
{
    internal class CommandSet
    {
        private List<ICommand> _commands;

        public CommandSet()
        {
            _commands =
            [
                new ClickCommand(),
                new UpgradeCommand(),
                new SuperUpgradeCommand(),
                new ExitCommand()
            ];
        }
        public void RunCommand(char command,ClickerGame game)
        {
            foreach (var c in _commands)
            {
                if (c.Key == command)
                {
                    c.Run(game);
                }
            }
        }
    }
}
