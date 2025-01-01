using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public class ColorSwitch
    {
        public ConsoleColor MapColors(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Yellow:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
