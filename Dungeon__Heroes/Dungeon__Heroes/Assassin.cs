using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Assassin:Entity
    {
        public Assassin() : base() { _clase = "Ассасин"; health = 105; maxHp = health; }
        public override void Hit(Entity target)
        {
            if (Dice.Roll(1, 6) == 3)
            {
                Console.WriteLine(info() + "делает свой ход");
                SystemMessege($"{info()} сначало тихо тихо, а потом УВААА резко выпрыгивает из кустов", ConsoleColor.DarkMagenta);
                target.TakeDamage(target.MaxHp());
                Console.WriteLine();
            }
            else { base.Hit(target); }
        }
    }
}
