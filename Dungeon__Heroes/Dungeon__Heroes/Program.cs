using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Program
    {
        static void Main(string[] args)
        {



            MainMenu menu = new MainMenu();
            
            menu.ChoiceHeroes();
            while (true)
            {
                menu.Menu();
                if (menu.IsWin()) { Console.Clear(); Console.WriteLine("Поздравляем!!!"); break; }
                if (menu.IsLose()) { Console.Clear(); Console.WriteLine("Похоже вы не смогли уследить за своими финансами. С долгами безбедную старость тебе не видать."); break; }
            }
            Console.ReadKey();
        }
    }
}
