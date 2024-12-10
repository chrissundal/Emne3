﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Car : Itransportation
    {
        public string Brand { get; set; }
        public string RegistrationNumber { get; set; }
        public Color Color { get; set; }

        public Car(string brand, string registrationNumber, Color color)
        {
            Brand = brand;
            RegistrationNumber = registrationNumber;
            Color = color;
        }
        public void Show()
        {
            //trykk på pedalen
            var colorConverted = new ColorSwitch();
            Console.ForegroundColor = colorConverted.MapColors(Color);
            var text = String.Format("Merke: {0,-15} Registreringsnummer: {1,-15} Farge: {2,-10}\n", Brand, RegistrationNumber, Color);
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(2);
            }
            Console.ResetColor();
        }
    }
}
