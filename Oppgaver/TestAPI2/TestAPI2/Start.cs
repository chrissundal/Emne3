namespace TestAPI2;

public class Start
{
    public List<Person> People { get; private set; }

    public Start()
    {
        People =
        [
            new Person("Chris", "Jacobsen", 37, []),
            new Person("Bjarne", "Karlsen", 25, []),
        ];
    }

    public List<Person> GetPeople()
    {
        return People;
    }
}