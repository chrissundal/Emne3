namespace InterfaceKlikkerSpill
{
    public class ClickerGame
    {
        private int _points;
        private int _pointsPerClick;
        private int _pointsPerClickIncrease;

        public ClickerGame()
        {
            _points = 0;
            _pointsPerClick = 1;
            _pointsPerClickIncrease = 1;
        }

        public int GetPoints()
        {
            return _points;
        }

        public void ClickPoint()
        {
            _points += _pointsPerClick;
        }

        public void Upgrade()
        {
            Console.Clear();
            _points -= 10;
            _pointsPerClick += _pointsPerClickIncrease;
            Console.WriteLine("You bought yourself a Upgrade!");
            Console.ReadKey();
        }
        public void SuperUpgrade()
        {
            Console.Clear();
            _points -= 100;
            _pointsPerClickIncrease++;
            _pointsPerClick += _pointsPerClickIncrease;
            Console.WriteLine("You bought yourself a SuperUpgrade!");
            Console.ReadKey();
        }
        public void PointsBar(string type)
        {
            var poeng = 0;
            switch (type)
            {
                case "normal":
                    Console.WriteLine("Points: ");
                    poeng = _points;
                    break;
                case "upgrade":
                    Console.WriteLine("Upgrade points: ");
                    poeng = _pointsPerClick;
                    break;
                case "super":
                    Console.WriteLine("Super upgrade points: ");
                    poeng = _pointsPerClickIncrease;
                    break;
            }
            
            for (int i = 0; i < poeng; i++)
            {
                Console.Write("\u2593");
            }
            Console.Write(poeng + "\n");
        }
    }
}
