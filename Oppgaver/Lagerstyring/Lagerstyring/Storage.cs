using System;
using System.Reflection;

namespace Lagerstyring
{
    internal class Storage
    {
        private List<IProduct> _products;
        private IProduct _selectedProduct;
        public Storage()
        {
            _products =
            [
                new Clothes("Jeans", 499, Sizes.S, 25),
                new Clothes("Jeans", 499, Sizes.M, 25),
                new Clothes("Jeans", 499, Sizes.L, 25),
                new Clothes("Jeans", 499, Sizes.XL, 25),
                new Clothes("Jeans", 499, Sizes.XXL, 25),
                new Electronic("TV", 6995, 24, 10),
                new Electronic("HIFI", 2699, 12, 20),
                new Electronic("Playstation 5", 4699, 36, 50),
                new Food("Brød", 38, new DateOnly(2024, 12, 20), 42),
                new Food("Melk", 15, new DateOnly(2024, 11, 15), 30),
                new Food("Egg", 25, new DateOnly(2024, 10, 10), 50),
                new Food("Yoghurt", 12, new DateOnly(2024, 12, 5), 20),
                new Food("Ost", 45, new DateOnly(2024, 9, 18), 15),
            ];
        }

        public void ShowNumberedProducts()
        {
            Console.Clear();
            int counter = 1;
            foreach (var p in _products)
            {
                if (counter >= 10)
                {
                    Console.Write($"{counter}.");
                }
                else
                {
                    Console.Write($"{counter}. ");
                }
                p.ShowInfo();
                counter++;
            }
        }
        public void ShowAllProducts()
        {
            Console.Clear();
            ShowNumberedProducts();
            var input = Console.ReadLine();
            if (input == "q")
            {
                return;
            }
            var converted = Convert.ToInt32(input) -1;
            if (converted < _products.Count && converted >= 0)
            {
                _selectedProduct = _products[converted];
                Console.Clear();
                Console.WriteLine($"{_selectedProduct.Name} is selected");
                ShowSelectedOptions();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not a valid number");
            }
        }


        private void ShowSelectedOptions()
        {
            Console.WriteLine("1. Edit product");
            Console.WriteLine("2. Delete product");
            Console.WriteLine("3. Back");
            var inputMenu = Console.ReadKey().KeyChar;
            if (inputMenu == '1')
            {
                _selectedProduct.GetInnerMenu();
                Console.Clear();
            }
            else if (inputMenu == '2')
            {
                Console.Clear();
                Console.WriteLine($"{_selectedProduct.Name} is deleted");
                _products.Remove(_selectedProduct);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                return;
            }
        }

        public void AddNewItem()
        {
            Console.Clear();
            Console.WriteLine("Choose the type of product to add:");
            Console.WriteLine("1. Clothes");
            Console.WriteLine("2. Food");
            Console.WriteLine("3. Electronics");
            var choice = Console.ReadKey().KeyChar;
            Console.Clear();
            Console.WriteLine("Enter the name of the product:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the price of the product:");
            int price = Convert.ToInt32(Console.ReadLine());
            IProduct newProduct = null;
            switch (choice)
            {
                case '1':
                    var size = GetSizeFromUser();
                    Console.WriteLine("Enter the stock quantity:");
                    var stockClothes = Convert.ToInt32(Console.ReadLine());
                    newProduct = new Clothes(name, price, size, stockClothes);
                    break;
                case '2':
                    var expirationDate = AddExpirationDate();
                    Console.WriteLine("Enter the stock quantity:");
                    var stockFood = Convert.ToInt32(Console.ReadLine());
                    newProduct = new Food(name, price, expirationDate, stockFood);
                    break;
                case '3':
                    Console.WriteLine("Enter the warranty period (months):");
                    var warranty = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the stock quantity:");
                    var stockElectronics = Convert.ToInt32(Console.ReadLine());
                    newProduct = new Electronic(name, price, warranty, stockElectronics);
                    break;
            }
            newProductCheck(newProduct);
            Console.ReadKey();
        }

        private void newProductCheck(IProduct? newProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name == newProduct.Name && p.Type == newProduct.Type);
            if (existingProduct != null)
            {
                existingProduct.SetStock(newProduct);
                Console.WriteLine($"Stock updated successfully for {newProduct.Name}. New stock: {existingProduct.Stock}");
            }
            else
            {
                _products.Add(newProduct);
                Console.WriteLine("Product added successfully.");
            }
        }

        public Sizes GetSizeFromUser()
        {
            string[] sizeOptions = Enum.GetNames(typeof(Sizes));
            while (true)
            {
                Console.WriteLine("Select a size by entering the corresponding number:");
                for (int i = 0; i < sizeOptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {sizeOptions[i]}");
                }
                var input = Convert.ToInt32(Console.ReadLine()) - 1;
                if (input < sizeOptions.Length && input >= 0)
                {
                    return (Sizes)(input);
                }
            }
        }

        private DateOnly AddExpirationDate()
        {
            Console.WriteLine("Enter the expiration day (1-31):");
            var inputDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the expiration month (1-12):");
            var inputMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the expiration year:");
            var inputYear = Convert.ToInt32(Console.ReadLine());
            return new DateOnly(inputYear, inputMonth, inputDay);
        }

        public void SelectByCategory()
        {
            Console.Clear();
            string searchResult = "";
            while (true)
            {
                Console.WriteLine("Select category");
                Console.WriteLine("1. Clothes");
                Console.WriteLine("2. Food");
                Console.WriteLine("3. Electronics");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    searchResult = "Clothes";
                    break;
                }
                else if (input == "2")
                {
                    searchResult = "Food";
                    break;
                }
                else if (input == "3")
                {
                    searchResult = "Electronics";
                    break;
                }
                else
                {
                    Console.WriteLine("Not valid");
                }
            }

            GetSearchResults(searchResult);
        }

        private void GetSearchResults(string searchResult)
        {
            Console.Clear();
            var selected = _products.Where(p => p.Type == searchResult).ToList();
            int counter = 1;
            if (selected != null)
            {
                foreach (var product in selected)
                {
                    Console.Write($"{counter}.");
                    product.ShowInfo();
                    counter++;
                }
                var input = Convert.ToInt32(Console.ReadLine())-1;
                if (input < selected.Count)
                {
                    Console.Clear();
                    _selectedProduct = selected[input];
                    Console.WriteLine($"{_selectedProduct.Name} is selected");
                    ShowSelectedOptions();
                }
                else
                {
                    Console.WriteLine("Not valid");
                }
            }
            else
            {
                Console.WriteLine("Found nothing");
            }
        }
    }
}

