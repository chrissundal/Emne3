namespace staticOppgave
{
    internal class Place
    {
        public string PlaceName { get; private set; }
        public string Municipitality { get; private set; }
        public string Region { get; private set; }

        public Place(string placeName, string municipitality, string region)
        {
            PlaceName = placeName;
            Municipitality = municipitality;
            Region = region;
        }
        public void ShowPlaceMuniAndRegion()
    {
        var labelWidth = 8;
        ShowSeperatorRow(8);
        ShowFieldNameAndValue("Navn", labelWidth, PlaceName);
        ShowFieldNameAndValue("Kommune", labelWidth, Municipitality);
        ShowFieldNameAndValue("Fylke", labelWidth, Region);
        ShowSeperatorRow(labelWidth);
    }
    private void ShowFieldNameAndValue(string label, int labelWidth, string fieldValue)
    {
        labelWidth -= label.Length;
        Console.WriteLine("  " + label + ":" + String.Empty.PadLeft(labelWidth, ' ') + fieldValue);
    }
    private void ShowSeperatorRow(int labelWidth)
    {
        labelWidth += 14;
        Console.WriteLine(string.Empty.PadLeft(labelWidth, '*'));
    }
    }
}
