namespace Butikkoversikt;

public class World
{
    private List<Store> _stores;
    private List<Store> _result;

    public World()
    {
        _result = [];
        _stores = [];
    }
    public void GoToStore()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Velkommen til verden");
            Console.WriteLine("1. Se alle butikker");
            Console.WriteLine("2. Sorter etter pris");
            Console.WriteLine("3. Sorter etter type");
            Console.WriteLine("4. Sorter etter type og pris");
            Console.WriteLine("5. Legg til ny butikk");
            Console.WriteLine("6. Avslutt");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    _result = _stores;
                    ShowResult();
                    break;
                case '2':
                    SortByPrice();
                    ShowResult();
                    break;
                case '3':
                    SortByType();
                    ShowResult();
                    break;
                case '4':
                    SortByTypeAndPrice();
                    ShowResult();
                    break;
                case '5':
                    AddNewStore();
                    break;
                case '6':
                    exit = true;
                    break;
                    
            }
        }
    }

    private void AddNewStore()
    {
        Console.WriteLine("Navn på butikk");
        var name = Console.ReadLine();
        Console.WriteLine("Type butikk");
        GetTypeLoop();
        var input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Butikkens prisrange");
        GetPriceRangeLoop();
        var inputPrice = Convert.ToInt32(Console.ReadLine());
        var type = (Type)input -1;
        var priceRange = (PriceRange)inputPrice -1;
        var newStore = new Store(name, priceRange, type);
        _stores.Add(newStore);
        
    }
    private void SortByPrice()
    {
        GetPriceRangeLoop();
        var input = Convert.ToInt32(Console.ReadLine());
        _result = _stores.Where(store => store.GetPricePoint() == (PriceRange)input-1).ToList();
    }
    private void SortByType()
    {
        GetTypeLoop();
        var input = Convert.ToInt32(Console.ReadLine());
        _result = _stores.Where(store => store.GetType() == (Type)input-1).ToList();
    }
    private void SortByTypeAndPrice()
    {
        GetTypeLoop();
        var input = Convert.ToInt32(Console.ReadLine());
        var result = _stores.Where(store => store.GetType() == (Type)input-1).ToList();
        
        GetPriceRangeLoop();
        var inputprice = Convert.ToInt32(Console.ReadLine());
        _result = result.Where(store => store.GetPricePoint() == (PriceRange)input-1).ToList();
        
    }

    private void GetPriceRangeLoop()
    {
        int num = 1;
        foreach (var price in Enum.GetValues(typeof(PriceRange)))
        {
            Console.WriteLine($"{num}. {price}");
            num++;
        }
    }
    private void GetTypeLoop()
    {
        int num = 1;
        foreach (var t in Enum.GetValues(typeof(Type)))
        {
            Console.WriteLine($"{num}. {t}");
            num++;
        }
    }

    private void ShowResult()
    {
        int num = 1;
        foreach (var store in _result)
        {
            Console.Write($"{num}. ");
            store.ShowInfo();
            num++;
        }
    }
    public void AddToList(Store newstore)
    {
        _stores.Add(newstore);
    }
}