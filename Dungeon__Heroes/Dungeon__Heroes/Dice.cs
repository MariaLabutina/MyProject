using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    public class Dice
    {
        public static Random r = new Random();

        public static int Roll(int x, int y)
        {
            int s = 0;
            for (int i = 0; i < x; i++)
                s += r.Next(y) + 1;
            return s;
        }

        public static int Next(int x, int y)
        {
            return r.Next(x, y);
        }
    }
}
