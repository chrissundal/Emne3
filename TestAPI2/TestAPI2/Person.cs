namespace TestAPI2;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Person> Friends { get; set; }

    public Person(string firstName, string lastName, int age, List<Person> friends)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Friends = friends;
    }
}