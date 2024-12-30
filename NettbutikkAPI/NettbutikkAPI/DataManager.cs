namespace NettbutikkAPI;

public class DataManager
{
    private readonly List<Product> _products;
    private readonly List<Person> _users;
    private readonly List<Order> _orders;

    public DataManager()
    {
        _users =
        [
            new Person("Chris", "Jacobsen", "c", "1", "Svingen 2","Larvik",0, new List<Product>(),true),
            new Person("Bjarne", "Hansen", "b", "1", "Torget 7","Sandefjord",1, new List<Product>(),false),
        ];
        
        _products =
        [
            new Product(0, "Hat", "Clothing", 49, 10, "IMG/hatt.jpg"),
            new Product(1, "Dusjhette", "Clothing", 99, 10, "IMG/showercap.jpg"),
            new Product(2, "Blyant", "Office", 15, 10, "IMG/blyant.jpg"),
            new Product(3, "Gaffatape", "Office", 35, 10, "IMG/tape.jpg"),
            new Product(4, "Dinosaur", "Toy", 149, 10, "IMG/dinosaur.jpg"),
            new Product(5, "Banan", "Food", 8, 100, "IMG/banan.jpg"),
            new Product(6, "Dopapir", "Food", 49, 10, "IMG/dopapir.jpg"),
            new Product(7, "Redbull", "Food", 35, 10, "IMG/energi.jpg"),
            new Product(8, "Eple", "Food", 7, 10, "IMG/eple.jpg"),
            new Product(9, "Melk", "Food", 22, 10, "IMG/melk.jpg"),
            new Product(10, "Sjokolade", "Food", 35, 10, "IMG/sjokolade.jpg")
        ];
        _orders =
        [
            new Order(1,0,106,[new Product(1, "Dusjhette", "Clothing", 99, 1, "IMG/showercap.jpg"),new Product(8, "Eple", "Food", 7, 1, "IMG/eple.jpg")],false)
        ];
    }

    public List<Person> GetUsers()
    {
        return _users;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public List<Order> GetOrders()
    {
        return _orders;
    }
}