namespace Butikkoversikt;

public class Start
{
    private List<string> _storeNames;
    private Random _random;
    private World _world;
    public Start()
    {
        _world = new World();
        _random = new Random();
        _storeNames =
        [
            "Superbutikk",
            "Alt og ingenting",
            "2 for 3",
            "Byens beste",
            "Handlekupp",
            "Enkelt kjøp",
            "Handlevogna",
            "Kornern",
            "Tilbudshjørnet",
            "Lykke hjørnet",
            "Koblingspunktet",
            "Lys og lune",
            "Tidløs trend",
            "Stilskaperen",
            "Stilsmeden",
            "Stilren",
            "Knutepunket",
            "Mat med mer"
        ];
        Run();
    }

    private void Run()
    {
        for (int i = 0; i < 18; i++)
        {
            var type = (Type)_random.Next(3);
            var priceRange = (PriceRange)_random.Next(3);
            var storeName = _storeNames[_random.Next(_storeNames.Count)];
            var newstore = new Store(storeName, priceRange, type);
            _world.AddToList(newstore);
            _storeNames.Remove(storeName);
        }

        _world.GoToStore();
    }
}