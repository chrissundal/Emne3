namespace ClaimTheSquare.Model;

public class TextObjects
{
    public TextObjects(string backColor, string foreColor, int index, string text)
    {
        BackColor = backColor;
        ForeColor = foreColor;
        Index = index;
        Text = text;
    }

    public string BackColor { get; set; }
    public string ForeColor { get; set; }
    public int Index { get; set; }
    public string Text { get; set; }
}