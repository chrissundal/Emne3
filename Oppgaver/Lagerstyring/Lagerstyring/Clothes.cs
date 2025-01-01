using System.Drawing;

namespace Lagerstyring
{
    internal class Clothes : IProduct
    {
        public Sizes Size { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Type { get; private set; }
        public int Stock { get; private set; }

        public Clothes(string name,int price,Sizes size,int stock)
        {
            Name = name;
            Size = size;
            Price = price;
            Type = "Clothes";
            Stock = stock;
        }

        public void ShowInfo()
        {
            Console.WriteLine($" Category: {Type,-15} | Product: {Name,-15} | Stock: {Stock,-7} | Price: {Price,-7} | Size: {Size}");
        }

        public void SetStock(IProduct newProduct)
        {
            Stock += newProduct.Stock;
        }

        public void GetInnerMenu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to change?");
            while (true)
            {
                
                Console.WriteLine("1. Product name");
                Console.WriteLine("2. Stock");
                Console.WriteLine("3. Price");
                Console.WriteLine("4. Size");
                Console.WriteLine("5. Back");
                var input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    Console.Clear();
                    Console.WriteLine($"Product name is: {Name}");
                    Console.WriteLine("Set new:");
                    var inputName = Console.ReadLine();
                    Name = inputName;
                    Console.WriteLine($"Product name is: {Name}");
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine($"Stock is: {Stock}");
                    Console.WriteLine("Set new:");
                    var inputStock = Convert.ToInt32(Console.ReadLine());
                    Stock = inputStock;
                    Console.WriteLine($"New stock is: {Stock}");
                }
                else if (input == '3')
                {
                    Console.Clear();
                    Console.WriteLine($"Price is: {Price}");
                    Console.WriteLine("Set new:");
                    var inputPrice = Convert.ToInt32(Console.ReadLine());
                    Price = inputPrice;
                    Console.WriteLine($"New price is: {Price}");
                }
                else if (input == '4')
                {
                    Console.Clear();
                    Console.WriteLine($"Size is: {Size}");
                    Console.WriteLine("Set new:");
                    var storage = new Storage();
                    var size = storage.GetSizeFromUser();
                    Size = size;
                    Console.WriteLine($"New size is: {Size}");
                }
                else
                {
                    break;
                }
            }
        }
    }
}
