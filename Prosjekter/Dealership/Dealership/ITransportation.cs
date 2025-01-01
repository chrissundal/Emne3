namespace Dealership
{
    public interface ITransportation
    {
        string Brand { get; }
        Type Category { get; }
        int Price { get; }
        int Horsepower { get; }
        int MaxSpeed { get; }
        int Weight { get; }
        void ShowInfo();

        void GoForARide(Random random);
    }
}
