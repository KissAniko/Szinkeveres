using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGB
{
    internal class Color
    {

        byte red;
        byte green;
        byte blue;

        public Color(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public byte Red { get => red; set => red = value; }
        public byte Green { get => green; set => green = value; }
        public byte Blue { get => blue; set => blue = value; }
    }
}