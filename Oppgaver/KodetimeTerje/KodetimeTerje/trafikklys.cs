using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodetimeTerje
{
    internal class Trafikklys
    {
        private int _phase;

        public int Phase
        {
            get
            {
                return _phase;
            }
            set
            {
                if (value >= 0 && value <= 3)
                {
                    _phase = value;
                }
            }
        }


        public void SetPhase(int phase)
        {
            if (phase >= 0 && phase <= 3)
            {
                _phase = phase;
            }
        }

        public void Show()
        {
            var red = _phase < 2;
            var yellow = _phase is 1 or 3;
            var green = _phase == 2;
            TrafficLightConsole.Show(red, yellow, green);
        }

        public void GoToNextPhase()
        {
            _phase++;
            if (_phase == 4)
            {
                _phase = 0;
            }

        }
    }
}
