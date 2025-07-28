using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class TreasureRoom:Room 
    {

        public override void Act()
        {
            
            Console.WriteLine("Вы вошли в комнату с сокровищем");
            int g = Dice.Next(50, 100);
            MainMenu.Gold += g;
            Console.WriteLine($"Вы получили {g} золота, теперь ваш баланс составляет {MainMenu.Gold}");
        }
        public override void Act2()
        {

            Console.WriteLine("Вы вошли в комнату с сокровищем");
            int g = Dice.Next(150, 300);
            MainMenu.Gold += g;
            Console.WriteLine($"Вы получили {g} золота, теперь ваш баланс составляет {MainMenu.Gold}");
        }
        public override void Act3()
        {

            Console.WriteLine("Вы вошли в комнату с сокровищем");
            int g = Dice.Next(300, 600);
            MainMenu.Gold += g;
            Console.WriteLine($"Вы получили {g} золота, теперь ваш баланс составляет {MainMenu.Gold}");
        }
    }
}
