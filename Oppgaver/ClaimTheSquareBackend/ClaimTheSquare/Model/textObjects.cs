namespace ClaimTheSquare.Model;

public class TextObjects
{
    public int Index { get; set; }
    public string Text { get; set; }
    public string ForeColor { get; set; }
    public string BackColor { get; set; }
    
    public TextObjects(int index, string text, string foreColor, string backColor)
    {
        Index = index;
        Text = text;
        ForeColor = foreColor;
        BackColor = backColor;
    }
}
