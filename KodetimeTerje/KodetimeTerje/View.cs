using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodetimeTerje
{
    internal class View
    {
        public static void Run()
        {
            var trafficLight = new Trafikklys();
            while (true)
            {
                Console.Clear();
                trafficLight.Show();
                Console.ReadKey(true);
                trafficLight.GoToNextPhase();
            }
        }
    }
}
