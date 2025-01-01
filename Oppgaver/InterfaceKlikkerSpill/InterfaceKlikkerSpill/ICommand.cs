namespace InterfaceKlikkerSpill
{
    internal interface ICommand
    {
        char Key { get; } 
        void Run(ClickerGame game);
    }
}
