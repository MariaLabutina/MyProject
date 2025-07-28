using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class EnemyRoom : Room
    {
        Enemy enemy = new Enemy();
        public override void Act()
        {
            for (int i = 0; i < Dice.Next(3, 6); i++)
            {
                enemy.Add(new Enemy());

            }

            Console.WriteLine("Вы вошли в комнату с врагами");
            do
            {

                for (int j = 0; j < Hero.count(); j++)
                {

                    if (enemy.count() > 0)
                    {
                        Hero.Call(j).Hit(enemy.Call(Dice.Next(0, enemy.count())));
                    }

                    for (int h = enemy.count() - 1; h >= 0; h--)
                    {
                        if (enemy.Call(h).IsLose())
                        {
                            Entity.SystemMessege($"{enemy.Call(h).info()} сдох?!", ConsoleColor.DarkRed);
                            enemy.Remove(enemy.Call(h));
                        }
                    }

                }

                for (int h = 0; h < enemy.count(); h++)
                {


                    if (Hero.count() > 0)
                    {
                        enemy.Call(h).Hit(Hero.Call(Dice.Next(0, Hero.count())));
                    }

                    for (int j = Hero.count() - 1; j >= 0; j--)
                    {
                        if (Hero.Call(j).IsLose())
                        {
                            Entity.SystemMessege($"{Hero.Call(j).info()} погиб", ConsoleColor.Magenta);
                            Hero.Remove(Hero.Call(j));
                        }
                    }

                }

                if (enemy.count() <= 0)
                {
                    Entity.SystemMessege("Вы победили", ConsoleColor.Green);
                    break;
                }
                else if (Hero.count() <= 0)
                {

                    Entity.SystemMessege("Вы проиграли", ConsoleColor.Cyan);
                    Console.ReadKey();
                    Environment.Exit(0);


                    break;
                }

            } while (true);
        }
        public override void Act2()
        {
            for (int i = 0; i < Dice.Next(6, 11); i++)
            {
                enemy.Add(new Enemy());

            }

            Console.WriteLine("Вы вошли в комнату с врагами");
            do
            {

                for (int j = 0; j < Hero.count(); j++)
                {

                    if (enemy.count() > 0)
                    {
                        Hero.Call(j).Hit(enemy.Call(Dice.Next(0, enemy.count())));
                    }

                    for (int h = enemy.count() - 1; h >= 0; h--)
                    {
                        if (enemy.Call(h).IsLose())
                        {
                            Entity.SystemMessege($"{enemy.Call(h).info()} сдох?!", ConsoleColor.DarkRed);
                            enemy.Remove(enemy.Call(h));
                        }
                    }

                }

                for (int h = 0; h < enemy.count(); h++)
                {


                    if (Hero.count() > 0)
                    {
                        enemy.Call(h).Hit(Hero.Call(Dice.Next(0, Hero.count())));
                    }

                    for (int j = Hero.count() - 1; j >= 0; j--)
                    {
                        if (Hero.Call(j).IsLose())
                        {
                            Entity.SystemMessege($"{Hero.Call(j).info()} погиб", ConsoleColor.Magenta);
                            Hero.Remove(Hero.Call(j));
                        }
                    }

                }

                if (enemy.count() <= 0)
                {
                    Entity.SystemMessege("Вы победили", ConsoleColor.Green);
                    break;
                }
                else if (Hero.count() <= 0)
                {

                    Entity.SystemMessege("Вы проиграли", ConsoleColor.Cyan);
                    Console.ReadKey();
                    Environment.Exit(0);


                    break;
                }

            } while (true);
        }
        public override void Act3()
        {
            for (int i = 0; i < Dice.Next(10, 15); i++)
            {
                enemy.Add(new Enemy());

            }

            Console.WriteLine("Вы вошли в комнату с врагами");
            do
            {

                for (int j = 0; j < Hero.count(); j++)
                {

                    if (enemy.count() > 0)
                    {
                        Hero.Call(j).Hit(enemy.Call(Dice.Next(0, enemy.count())));
                    }

                    for (int h = enemy.count() - 1; h >= 0; h--)
                    {
                        if (enemy.Call(h).IsLose())
                        {
                            Entity.SystemMessege($"{enemy.Call(h).info()} сдох?!", ConsoleColor.DarkRed);
                            enemy.Remove(enemy.Call(h));
                        }
                    }

                }

                for (int h = 0; h < enemy.count(); h++)
                {


                    if (Hero.count() > 0)
                    {
                        enemy.Call(h).Hit(Hero.Call(Dice.Next(0, Hero.count())));
                    }

                    for (int j = Hero.count() - 1; j >= 0; j--)
                    {
                        if (Hero.Call(j).IsLose())
                        {
                            Entity.SystemMessege($"{Hero.Call(j).info()} погиб", ConsoleColor.Magenta);
                            Hero.Remove(Hero.Call(j));
                        }
                    }

                }

                if (enemy.count() <= 0)
                {
                    Entity.SystemMessege("Вы победили", ConsoleColor.Green);
                    break;
                }
                else if (Hero.count() <= 0)
                {

                    Entity.SystemMessege("Вы проиграли", ConsoleColor.Cyan);
                    Console.ReadKey();
                    Environment.Exit(0);


                    break;
                }

            } while (true);
        }
    }
}
