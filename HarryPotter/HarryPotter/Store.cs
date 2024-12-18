using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Store
    {
        private List<IItems> _items;
        private List<IItems> _results;

        public Store()
        {
            _items =
            [
                new Pet("Hedwig","Pet","Ugle"),
                new Pet("Scabbers","Pet","Rotte"),
                new Pet("Argus Filch","Pet","Katt"),
                new Wand("Føniksstav","Wand","Phoenix Feather"),
                new Wand("Unikornstav","Wand","Unicorn Hair"),
                new Wand("Trollstav","Wand","Troll Whisker"),
            ];
            _results = [];
        }

        public void GoToStore(Character character)
        {
            while (true)
            {
                Console.WriteLine("1. Pets");
                Console.WriteLine("2. Wands");
                Console.WriteLine("3. Avslutt");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        InputResult("Pet");
                        ShowResults(character);
                        
                        break;

                    case '2':
                        InputResult("Wand");
                        ShowResults(character);
                        break;
                    case '3':
                       return;

                    default:
                        Console.WriteLine("Ikke gyldig input");
                        break;

                }


            }
        }

        private void InputResult(string input)
        {
            _results = _items.Where(item => item.Type == input).ToList();
        }

        private void ShowResults(Character character)
        {
            if (_results.Count > 0)
            {
                int num = 1;
                foreach (var item in _results)
                {
                    Console.WriteLine($"{num}. {item.Name}");
                    num++;
                }
                var input = Convert.ToInt32(Console.ReadLine())-1;
                if (input < _results.Count)
                {
                    var selected = _results[input];
                    character.AddItem(selected);
                
                }
                else
                {
                    Console.WriteLine("Ikke gyldig");
                }
            }
            else
            {
                Console.WriteLine("Ingen resultat");
            }
        }
    }
}
