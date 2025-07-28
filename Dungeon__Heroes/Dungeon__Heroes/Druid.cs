using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Druid:Entity
    {
        public Druid() : base() { _clase = "Друид"; health = 85; maxHp = health; }
        public override void Hit(Entity target)
        {

            if (Dice.Roll(1, 4) == 2)
            {
                Console.WriteLine(info() + "делает свой ход");
                int h = Dice.Next(20, 50);
                for( int i=0; i<Hero.count();i++)
                {
                    Hero.Call(i).Up();
                }
                SystemMessege($"{info()} накинул слабый щит на союзников", ConsoleColor.DarkGreen);
                Console.WriteLine();
            }
            else { base.Hit(target); }

        }
    }
}
