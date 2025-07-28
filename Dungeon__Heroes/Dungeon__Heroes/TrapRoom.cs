using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class TrapRoom:Room
    {
       
        string[] a = new string[] { " :\"Ай больно в ноге\"", " споткнулся об свою самооценку", ", ты как? \n - Не знаю, я еще лечу ", ": \" Чертов яндекс навигатор!\"", " не смог убежать от догоняющего его кирпича", " наступил на змею" };
        
        public override void Act()
        {
            Console.WriteLine("Вы вошли в комнату и попали в ловушку");
            Entity victim = Hero.Call(Dice.Next(0, Hero.count()));
            int dmg =Dice.Roll(2, 6);
            victim.TakeDamage(dmg);
            if (victim.IsLose())
            {
                Entity.SystemMessege($"{victim.info()} {a[Dice.Next(0,6)]} ", ConsoleColor.Magenta);
                Hero.Remove(victim);
            }
            if (Hero.count() <= 0)
            {

                Entity.SystemMessege("Вы проиграли", ConsoleColor.Cyan);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public override void Act2()
        {
            Console.WriteLine("Вы вошли в комнату и попали в ловушку");
            Entity victim = Hero.Call(Dice.Next(0, Hero.count()));
            int dmg = Dice.Roll(2, 12);
            victim.TakeDamage(dmg);
            if (victim.IsLose())
            {
                Entity.SystemMessege($"{victim.info()} {a[Dice.Next(0, 6)]} ", ConsoleColor.Magenta);
                Hero.Remove(victim);
            }
            if (Hero.count() <= 0)
            {

                Entity.SystemMessege("Вы проиграли", ConsoleColor.Cyan);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public override void Act3()
        {
            Console.WriteLine("Вы вошли в комнату и попали в ловушку");
            Entity victim = Hero.Call(Dice.Next(0, Hero.count()));
            int dmg = Dice.Roll(4, 12);
            victim.TakeDamage(dmg);
            if (victim.IsLose())
            {
                Entity.SystemMessege($"- {victim.info()} {a[Dice.Next(0, 6)]}", ConsoleColor.Magenta);
                Hero.Remove(victim);
            }
            if (Hero.count() <= 0)
            {

                Entity.SystemMessege("Вы проиграли", ConsoleColor.Cyan);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
