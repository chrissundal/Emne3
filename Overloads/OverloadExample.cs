namespace Overloads
{
    internal class OverloadExample
    {
        public string Compliment { get; set; }
        public string OpenText { get; set; }

        public void PrintWelcomeMessage()
        {
            OpenText = "Hei og velkommen";
            Compliment = "Du er snill!";
        }

        public void PrintWelcomeMessage(string compliment)
        {
            OpenText = "Hei og velkommen";
            Compliment = compliment;
        }
    }
}