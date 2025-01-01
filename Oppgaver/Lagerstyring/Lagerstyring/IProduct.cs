namespace Lagerstyring
{
    public interface IProduct
    {
        string Type { get; }
        string Name { get; }
        int Price { get; }
        int Stock { get; }

        void ShowInfo();

        void SetStock(IProduct newProduct);
        void GetInnerMenu();
    }
}
