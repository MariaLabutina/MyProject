using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Wizard:Entity
    {
        public Wizard() : base() { _clase = "Маг"; health = 90; maxHp = health; }

        public override void Hit(Entity target)
        {

            if (Dice.Roll(1, 3) == 2)
            {
                Console.WriteLine(info() + "делает свой ход");
                SystemMessege($"{info()} применил магию замораживания", ConsoleColor.Blue);
                IsStan();
                target.TakeDamage(power);
                Console.WriteLine();
            }
            else { base.Hit(target); }

        }
    }
}
