using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class VoidRoom:Room
    {
        public override void Act()
        {
            Console.WriteLine("Вы вошли в пустую комнату");
        }
        public override void Act2()
        {
            Console.WriteLine("Вы вошли в пустую комнату");
        }
        public override void Act3()
        {
            Console.WriteLine("Вы вошли в пустую комнату");
        }
    }
}
