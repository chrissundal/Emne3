namespace datatyper
{
    internal class Datatyper
    {
        int tall = 1;

        float desimaltall = 1.01F; //nøyaktig
        double desimalTall2 = 1.01; //skulle vært en D bak, men det er default så ikke nødvendig
        decimal descimalTall3 = 1.01M; //veldig nøyaktig

        char bokstav = 'a';
        string tekst = "Hei";
        bool santUsant = true; //boolean
        int[] tallArray = { 1, 2, 3};
        string[] tekstArray = { "a", "b", "c"};

        List<int> listeMedTall = new List<int>(); //lager en liste med tall

        public int NumberFive()
        {
            return 5;
        }
    }
}
