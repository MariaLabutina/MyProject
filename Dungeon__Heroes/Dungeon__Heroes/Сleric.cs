using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Сleric : Entity
    {
        public Сleric() : base() { _clase = "Священник"; health = 195; maxHp = health; }

        public override void Hit(Entity target)
        {
            Entity nub;

            if (Dice.Roll(1, 3) == 2)
            {
                for (int i = 0; i < Hero.count(); i++)
                {
                    nub = Hero.Call(Dice.Next(0, Hero.count()));
                    if (nub.IsHp())
                    {
                Console.WriteLine(info() + "делает свой ход");
                SystemMessege($"{info()} поставил свечку за здравие ", ConsoleColor.Yellow);
                Heal(nub, 10); 
                SystemMessege($"{nub.info()} получил божественное благословение", ConsoleColor.Yellow);
                Console.WriteLine();
                        break;
                    }

                }



            }
            else { base.Hit(target); }

        }
    }
}
