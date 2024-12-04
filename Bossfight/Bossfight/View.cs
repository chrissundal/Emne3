using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossfight
{
    internal class View
    {
        private static Random random = new Random();
        private GameCharacter _hero;
        private GameCharacter _enemy;

        public View()
        {
            _hero = new GameCharacter("Hero", 100, 20, 40);
            _enemy = new GameCharacter("Boss", 400, 10);
        }
        public void Run()
        {
            Console.WriteLine("Bossfight");
            Console.WriteLine("Start Fight?");
            Console.ReadKey();
            while (true)
            {
                if (_hero.SurviveCheck(_enemy) || _enemy.SurviveCheck(_hero))
                {
                    break;
                }
                Console.Clear();
                _hero.ShowInfo();
                _enemy.ShowInfo();
                var randomNr = random.Next(1,3);
                if (randomNr == 1)
                {
                    _enemy.Fight(_hero);
                }
                else if (randomNr == 2)
                {
                    _hero.Fight(_enemy);
                }
            }
        }

    }
}
