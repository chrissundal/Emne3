namespace InterfaceKlikkerSpill
{
    internal class View
    {
        private ClickerGame _game;
        private CommandSet _commands;

        public View()
        {
            _game = new ClickerGame();
            _commands = new CommandSet();
            ShowFirstText();
        }

        private void ShowFirstText()
        {
            DisplayText("Velkommen til Klikkerspillet");
            Thread.Sleep(3000);
            while (true)
            {
                Console.Clear();
                DisplayCommands();
                _game.PointsBar("normal");
                _game.PointsBar("upgrade");
                _game.PointsBar("super");
                
                Console.WriteLine("\nTrykk tast for ønsket kommando.\n");
                var command = Console.ReadKey().KeyChar;
                _commands.RunCommand(command,_game);
            }
        }

        private void DisplayCommands()
        {
            Console.WriteLine("Kommandoer:");
            Console.WriteLine("- SPACE = klikk (og få poeng)");
            Console.WriteLine("- K = kjøp oppgradering (øker poeng per klikk, koster 10 poeng)");
            Console.WriteLine("- S = kjøp superoppgradering (øker poeng per klikk for den vanlige oppgraderingen, koster 100 poeng)");
            Console.WriteLine("- X = avslutt applikasjonen.\n");
        }

        private void DisplayText(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(1);
            }
        }
    }
}
