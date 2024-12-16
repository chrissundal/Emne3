using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership
{
    internal class Boat : ITransportation
    {
        public string Brand { get; private set; }
        public Type Category { get; private set; }
        public int Price { get; private set; }
        public int Horsepower { get; private set; }
        public int MaxSpeed { get; private set; }
        public int Weight { get; private set; }

        public Boat(string brand, Type category, int price, int horsepower, int maxSpeed, int weight)
        {
            Brand = brand;
            Category = category;
            Price = price;
            Horsepower = horsepower;
            MaxSpeed = maxSpeed;
            Weight = weight;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Kategori: {Category} | Merke: {Brand} | Vekt: {Weight} | Hester: {Horsepower} | Toppfart: {MaxSpeed} | Pris: {Price}");
        }
        public void GoForARide(Random random)
        {
            Console.Clear();
            string[] ride =
            [
                $"Å seile {Brand} var en fryd, og den nådde raskt sin makshastighet på {MaxSpeed} kmt. Absolutt en opplevelse verdt prisen på {Price} kroner.",
                $"Den solide {Brand} overrasket med sin stabile seiling og evnen til å nå {MaxSpeed} kmt med sine {Horsepower} hester. Virkelig verdt hver krone.",
                $"Selv med sin vekt på {Weight} kg, viste {Brand} seg å være utrolig smidig og nådde imponerende {MaxSpeed} kmt.",
                $"Den imponerende {Brand} med en pris på {Price} kroner viste seg å være både kraftig og elegant med sine {Horsepower} hester.",
                $"På vannet føltes {Brand} robust og pålitelig, og den nådde lett sin toppfart på {MaxSpeed} kmt. En fornøyelse å seile.",
                $"Dessverre levde {Brand} ikke opp til forventningene. Til tross for sine {Horsepower} hester, slet den med å nå {MaxSpeed} kmt.",
                $"Selv om {Brand} ser imponerende ut på papiret, var ytelsen på vannet skuffende. {MaxSpeed} kmt føltes som en kamp.",
                $"Du merket raskt at {Brand} ikke håndterer sin vekt på {Weight} kg særlig godt. Det var en treg opplevelse, selv ved {MaxSpeed} kmt.",
                $"Prisen på {Price} kroner for {Brand} virker urettferdig når den leverer så svak ytelse. Ikke det beste kjøpet.",
                $"Seilturen med {Brand} var alt annet enn tilfredsstillende. Til tross for lovende spesifikasjoner, var {MaxSpeed} kmt vanskelig å oppnå og opplevelsen generelt skuffende."
            ];
            var selRide = ride[random.Next(ride.Length)];
            Console.WriteLine(selRide);
        }
    }
}
