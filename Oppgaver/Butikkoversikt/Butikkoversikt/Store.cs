namespace Butikkoversikt;

public class Store
{
    public string StoreName { get; private set; }
    public PriceRange Pricepoint { get; private set; }
    public Type TypeOfProduct { get; private set; }

    public Store(string storeName, PriceRange pricepoint, Type typeOfProduct)
    {
        StoreName = storeName;
        Pricepoint = pricepoint;
        TypeOfProduct = typeOfProduct;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Store: {StoreName} Pricepoint: {Pricepoint} Type: {TypeOfProduct}");
    }

    public Type GetType()
    {
        return TypeOfProduct;
    }
    public PriceRange GetPricePoint()
    {
        return Pricepoint;
    }
}