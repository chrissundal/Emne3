using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossfight
{
    internal class GameCharacter
    {
        private static Random random = new Random();
        private string _name;
        private int _health;
        private int _strength;
        private int _stamina;
        private int _randomStrength;
        private int _initialStamina;

        public GameCharacter(string name, int health, int strength, int stamina)
        {
            _name = name;
            _health = health;
            _strength = strength;
            _stamina = stamina;
            _initialStamina = stamina;
        }
        public GameCharacter(string name, int health, int stamina)
        {
            _name = name;
            _health = health;
            _strength = random.Next(1, 31);
            _stamina = stamina;
            _initialStamina = stamina;
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Name: {_name}, Health: {_health}, Strength: {_strength}, Stamina: {_stamina}");
        }

        public void Fight(GameCharacter opponent)
        {
            if (_stamina > 0)
            {
                _stamina -= 10;
                if (_name == "Boss")
                {
                    _strength = random.Next(1, 31);
                }
                opponent._health -= _strength;
                Console.WriteLine($"{_name} just struck {opponent._name} with a swift blow of {_strength} damage");
                Console.WriteLine($"{opponent._name} has {opponent._health} left");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{_name} cant fight! Must recharge");
                Recharge();
                opponent.Fight(this);
            }
        }
        public void Recharge()
        {
            _stamina = _initialStamina;
            Console.WriteLine($"{_name} is all filled up");
        }

        public bool SurviveCheck(GameCharacter opponent)
        {
            if (_health < 0)
            {
                Console.WriteLine($"{_name} fought well, but in the end he was killed by {opponent._name}");
                Console.WriteLine($"{opponent._name} is the winner, winner, chicken dinner!");
                Console.ReadKey();
                return true;
            }

            return false;
        }
    }
}
