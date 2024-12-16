using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netthandel
{
    internal class Config
    {
        private List<IProducts> _allProducts;
        private World _myWorld;
        private List<string> _storenames;
        private List<string> _employeesnames;
        private Random _random;
        private List<Person> _users;
        public Config()
        {
            _users =
            [
                new Person("Chris", [], [], 28000),
                new Person("Lisa", [], [], 150000),
                new Person("Monica", [], [], 1000)
            ];
            _random = new Random();
            _employeesnames = ["Tore", "Bernt", "Svein", "Else", "Mona", "Roger"];
            _storenames =
            [
                "Superfood", "QuickMat", "Gourmet Mat", "Hurtigkassa", "Mye Varer", "Handlevogn Himmelen",
                "DagligVarianter", "VareVaganza"
            ];
            _myWorld = new World();
            _allProducts =
            [
                new Meat("Entrecote", "Meat", 100, 429, "KG"),
                new Dairy("Melk","Meieri",300,36,"Stk"),
                new Drinks("Cola 0,5","Drikke",150,28,"Stk"),
                new Fruit("Banan","Frukt",60,49,"KG"),
                new Snacks("Melkesjoko","Snacks",200,45,"Stk"),
                new Vegetables("Gulrot","Grønnsak",150,29,"KG"),
            ];
                AddItems();
        }

        private void AddItems()
        {
            AddStore();
            int num = 1;
            while (true)
            {
                Console.Clear();
                foreach (var person in _users)
                {
                    Console.WriteLine($"{num}. {person.GetName()}");
                    num++;
                }
                var input = Convert.ToInt32(Console.ReadLine()) - 1;
                if (input < _users.Count)
                {
                    var selected = _users[input];
                    _myWorld.GoToWorld(selected);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ikke gyldig");
                    Console.ReadKey();
                }
            }
        }

        private void AddStore()
        {
            List<IProducts> itemList = new List<IProducts>();
            for (int i = 0; i < _random.Next(4,6); i++)
            {
                if (!itemList.Contains(_allProducts[i]))
                {
                    itemList.Add(_allProducts[i]);
                }
            }
            var randomEmployee = _employeesnames[_random.Next(_employeesnames.Count)];
            var employee = new Person(randomEmployee);
            _employeesnames.Remove(randomEmployee);
            var randomStoreName = _storenames[_random.Next(_storenames.Count)];
            _storenames.Remove(randomStoreName);
            var store = new Store(randomStoreName, employee, itemList);
            _myWorld.AddStore(store);
        }
    }
}
