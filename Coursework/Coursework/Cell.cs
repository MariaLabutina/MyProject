using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    struct Cell
    {
        public char symbol;
        public Brush foregroundColor;
        public Brush backgroundColor;

        public Cell(char symbol, Brush foregroundColor, Brush backgroundColor)
        {
            this.symbol = symbol;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
        }
    }
}
