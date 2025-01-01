namespace ClaimTheSquare.Model;

public class DataManager
{
    public DataManager()
    {
        TextObjectsList =
        [
            new TextObjects("yellow", "blue", 1, "Per"),
            new TextObjects("red", "white", 12, "Chris"),
            new TextObjects("blue", "white", 37, "Bjarne"),
            new TextObjects("white", "lime", 55, "Frank")
        ];
    }

    public List<TextObjects> TextObjectsList { get; set; }

    public List<TextObjects> GetTextObjects()
    {
        return TextObjectsList;
    }

    public void AddNewObjects(TextObjects textObjects)
    {
        TextObjectsList.Add(textObjects);
    }
}