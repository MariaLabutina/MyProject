using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Looter:Entity
    {
        public Looter() : base() { _clase = "Вор"; health = 110; maxHp = health; }
        public override void Hit(Entity target)
        {

            if (Dice.Roll(1, 4) == 2)
            {
                Console.WriteLine(info() + "делает свой ход");
                int g = Dice.Next(20, 50);
                MainMenu.Gold += g;
                SystemMessege($"{info()} :\" Хох, джекпот: {g} золота\"", ConsoleColor.DarkGray);
                Console.WriteLine();
            }
            else { base.Hit(target); }

        }
    }
}
