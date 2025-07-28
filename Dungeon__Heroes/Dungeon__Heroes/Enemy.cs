using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Enemy:Entity
    {
         List<Enemy> enemy = new List<Enemy>();
        public Enemy():base()
        {
            health = 80; 
            power = 15;
            protection = 20;
        }

        public  Enemy Call(int enemyNumber)
        {
            return enemy[enemyNumber];
        }
        public  void ShowList()
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                Console.WriteLine(enemy[i].info());
            }
        }
        public  void Add(Enemy _enemy)
        {
            enemy.Add(_enemy);
        }

        public  int count()
        {
            return enemy.Count;
        }
        public  void Remove(Enemy _enemy)
        {
            enemy.Remove(_enemy);
        }
    }
}
