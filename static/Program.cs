namespace staticOppgave;

internal class Program
{
    static void Main(string[] args)
    {
        var place = new Place("Stavern", "Larvik", "Vestfold");
        var place2 = new Place("Rjukan", "Tinn", "Telemark");
        
        place.ShowPlaceMuniAndRegion();
        place2.ShowPlaceMuniAndRegion();
    }

   
    //static void Main(string[] args)
    //{
    //    var labelWidth = 8;
    //    ShowSeperatorRow(8);
    //    ShowFieldNameAndValue("Navn", labelWidth, "Stavern");
    //    ShowFieldNameAndValue("Kommune", labelWidth, "Larvik");
    //    ShowFieldNameAndValue("Fylke", labelWidth, "Vestfold");
    //    ShowSeperatorRow(labelWidth);
    //}

    //static void ShowSeperatorRow()
    //{
    //    ShowSeperatorRow(8);
    //}

    
    //static void ShowSeperatorRow(int labelWidth = 8)
    //{
    //    labelWidth += 14;
    //    Console.WriteLine(string.Empty.PadLeft(labelWidth, '*'));
    //}
}
