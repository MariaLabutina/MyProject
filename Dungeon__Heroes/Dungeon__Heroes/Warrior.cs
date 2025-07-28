using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Warrior:Entity
    {
        public Warrior() : base() { _clase = "Воин"; health = 115; maxHp = health; }

        public override void Hit(Entity target)
        {

            if (Dice.Roll(1, 3) == 2)
            {
                Console.WriteLine(info() + "делает свой ход");
                SystemMessege($"{info()} использовал усиленную атаку", ConsoleColor.Red);
                target.TakeDamage(Convert.ToInt32((power * 1.3)));
                Console.WriteLine();
            }
            else { base.Hit(target); }

        }
    }
}
