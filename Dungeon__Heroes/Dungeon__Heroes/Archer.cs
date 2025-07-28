using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Archer : Entity

    {
        public Archer() : base() { _clase = "Лучник"; health = 85; maxHp = health; }

        public override void Hit(Entity target)
        {

            if (Dice.Roll(1, 3) == 2 && target.IsBurn())
            {
                Console.WriteLine(info() + "делает свой ход");
                SystemMessege($"{info()} достал зажигалку", ConsoleColor.DarkYellow);
                target.IsBurn();
                Console.WriteLine();
            }
            else { base.Hit(target); }

        }

    }
}
