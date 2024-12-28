namespace NettbutikkAPI;

public class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string UserName { get; private set; }
    public string PassWord { get; private set; }
    public int Id { get; private set; }
    public List<Product> MyCart { get; private set; }
    public List<Product> MyInventory { get; private set; }
    public bool IsEmployee { get; private set; }

    public Person(string firstName, string lastName, string userName, string passWord, int id, List<Product> myCart, List<Product> myInventory, bool isEmployee)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        PassWord = passWord;
        Id = id;
        MyCart = myCart;
        MyInventory = myInventory;
        IsEmployee = isEmployee;
    }

    public void AddToCart(Product product)
    {
        MyCart.Add(product);
    }

    public void Checkout()
    {
        foreach (var product in MyCart)
        {
            MyInventory.Add(product);
        } 
        MyCart.Clear();
    }
}