using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netthandel
{
    internal class Fruit : IProducts
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public int Stock { get; private set; }
        public int Price { get; private set; }
        public string Measurement { get; private set; }

        public Fruit(string name, string category, int stock, int price, string measurement)
        {
            Name = name;
            Category = category;
            Stock = stock;
            Price = price;
            Measurement = measurement;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Kategori: {Category}    | Vare: {Name}          | På lager: {Stock} | Pris: {Price}  | Pris pr: {Measurement} ");
        }

        public void RemoveFromStock(int amount)
        {
            Stock -= amount;
        }

        public void SetStock(int amount)
        {
            Stock = amount;
        }
        public IProducts Clone(int stock)
        {
            return new Fruit(Name, Category, stock, Price, Measurement);
        }
    }
}
