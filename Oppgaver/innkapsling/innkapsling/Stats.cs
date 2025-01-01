using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innkapsling
{
    internal class Stats
    {
        public int NumberCount { get; private set; }
        public int Sum { get; private set; }
        public float Mean => (float)Sum / NumberCount;


        public void AddNumber(int number)
        {
            Sum += number;
            NumberCount++;
        }

    }
}
