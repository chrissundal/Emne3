namespace NyreTransplantasjon
{
    internal class Sykehus
    {
        public float BMI { get; private set; }
        public int ChanceOfSuccess { get; private set; }
        
        public void UtførTransplantasjon(Person giver, Person mottaker, View view)
        {
            bool exitOperation = false;
            Console.Clear();
            if (giver.Blodtype != mottaker.Blodtype)
            {
                Console.WriteLine("Transplantasjonen kan ikke utføres fordi blodtypene ikke matcher.");
                return;
            }
            else
            {
                Console.WriteLine("Lik blodtype");
            }
            
            if (giver.Nyrer <= 1 || giver.Nyrer > 2)
            {
                Console.WriteLine("Transplantasjonen kan ikke utføres fordi giveren har ikke nok nyrer.");
                return;
            }
            else
            {
                Console.WriteLine($"{giver.Navn} har 2 nyrer");
                exitOperation = false;
            }
            
            while (!exitOperation)
            {
                Console.WriteLine("\nVil du utføre operasjonen? (ja/nei)");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "ja")
                {
                    CalculateChanceOfSuccess(giver, mottaker);
                    
                    Console.WriteLine("\nVil du fortsette? (ja/nei)");
                    var answerAgain = Console.ReadLine();
                    if (answerAgain.ToLower() == "ja")
                    {
                        Random random = new Random();
                        var randomNumber = random.Next(1, 101);

                        Console.WriteLine($"Generert tall for å sjekke suksess: {randomNumber}");

                        if (randomNumber <= ChanceOfSuccess)
                        {
                            Console.Clear();
                            giver.GiNyre();
                            mottaker.MottaNyre();
                            Console.WriteLine("Transplantasjonen var vellykket!");
                            view.selectedFirstPerson = null;
                            view.selectedSecondPerson = null;
                            exitOperation = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{mottaker.Navn} overlevde ikke, og {giver.Navn} sitter igjen med bare 1 nyre.");
                            giver.GiNyre();
                            mottaker.Dead();
                            view.selectedFirstPerson = null;
                            view.selectedSecondPerson = null;
                            exitOperation = true;
                        }
                    }
                    else if (answerAgain.ToLower() == "nei")
                    {
                        Console.Clear();
                        exitOperation = true;
                    }
                }
                else if (answer.ToLower() == "nei")
                {
                    Console.Clear();
                    exitOperation = true;
                }
                else
                {
                    Console.WriteLine("ikke gyldig svar");
                }
            }
        }

        public void GetBMI(Person selectedPerson)
        {
            BMI = (float)selectedPerson.Vekt / (selectedPerson.Høyde * selectedPerson.Høyde / 10000);
            Console.WriteLine($"{selectedPerson.Navn} har en BMI på {BMI} ");
        }

        private void CalculateChanceOfSuccess(Person giver, Person mottaker)
        {
            ChanceOfSuccess = 100;

            GetBMI(giver);
            var giverBMI = BMI;
            GetBMI(mottaker);
            var mottakerBMI = BMI;

            for (int i = 30; i < giver.Alder; i += 5)
            {
                ChanceOfSuccess--;
            }

            for (int i = 30; i < mottaker.Alder; i += 5)
            {
                ChanceOfSuccess--;
            }

            for (int i = 25; i < (int)giverBMI; i++)
            {
                ChanceOfSuccess--;
            }

            for (int i = 25; i < (int)mottakerBMI; i++)
            {
                ChanceOfSuccess--;
            }

            Console.WriteLine($"Suksessraten for transplantasjonen er {ChanceOfSuccess}%");
        }

    }
}