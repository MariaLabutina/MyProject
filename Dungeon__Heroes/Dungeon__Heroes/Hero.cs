using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    static class Hero
    {

         static List<Entity> hero = new List<Entity>(4);
        

        static public Entity Call(int heroeNumber)
            {
                return hero[heroeNumber];
            }
        static public void ShowList()
            {
                for (int i = 0; i < hero.Count; i++)
                {
                    Console.WriteLine(hero[i].info());
                }
            }
        static public void Add(Entity _hero)
            {
                hero.Add(_hero);
            }

        static public int count()
            {
                return hero.Count;
            }

        static public void Remove(Entity _hero)
            {
                hero.Remove(_hero);
            }

        }
    }