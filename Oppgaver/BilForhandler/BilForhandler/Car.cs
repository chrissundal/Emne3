using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler
{
    public class Car
    {
        public string Merke { get;  private set; }
        public int Årsmodell { get; private set; }
        public string Registreringsnummer { get; private set; }
        public int Kilometerstand { get; private set; }
        public int Pris {  get; private set; }

        public Car(string merke, int årsmodell, string registreringsnummer, int kilometerstand, int pris)
        {
            Merke = merke;
            Årsmodell = årsmodell;
            Registreringsnummer = registreringsnummer;
            Kilometerstand = kilometerstand;
            Pris = pris;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Merke: {Merke} Årsmodell: {Årsmodell} RegistreringsNummer: {Registreringsnummer} Kilometerstand: {Kilometerstand} Pris: {Pris}");
        }
    }
}
