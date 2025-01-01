namespace Lagerstyring
{
    internal class View
    {
        private Storage _myStorage;
        public View()
        {
            _myStorage = new Storage();
            Run();
        }

        private void Run()
        {
            TopIntro();
            while (true)
            {
                Menu();
            }
        }

        private void TopIntro()
        {
            string text = "LagerMaister 3000\n";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(1);
            }
        }

        private void Menu()
        {
            string[] menuOptions = ["1. Show all products", "2. Show by Category", "3. Add new item", "Press Q to quit"];
            CenterText(menuOptions);
            MenuChoices();
        }

        private void CenterText(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.SetCursorPosition((Console.WindowWidth - lines[1].Length) / 2, Console.CursorTop); 
                Console.WriteLine(line);
            }
        }

        private void MenuChoices()
        {
            var input = Console.ReadKey().KeyChar;
            if (input == '1')
            {
                Console.Clear();
                _myStorage.ShowAllProducts();
                Console.Clear();
            }
            else if (input == '2')
            {
                _myStorage.SelectByCategory();
            }
            else if (input == '3')
            {
                _myStorage.AddNewItem();
            }
            else if (input == 'q')
            {
                Console.Clear();
                Console.WriteLine("Are you sure (y/n)");
                var inputConfirm = Console.ReadKey().KeyChar;
                if (inputConfirm == 'y')
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
