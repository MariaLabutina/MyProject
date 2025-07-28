using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Entity
    {
        protected int health;
        protected int power;
        protected int protection;
        protected string name;
        protected string _clase;
        protected bool isStan;
        protected bool isBurn;
        protected bool boost;
        protected int shildlv;
        string[] name_array = new string[] { "Игнат", "Лёша", "Саша", "Эмиль", "Валера", "Антон", "Илья", "Дима", "Баки", "Максим", "Егор", "Евгений", "Эдик" };

        protected int maxHp;
       
        public Entity()
        {

            shildlv = 1;
            health = 100;
            power = 35;
            protection = 100;
            name = name_array[Dice.Next(0, 10)];
            _clase = "NPC";
            maxHp = health;
        }

        public virtual void Hit(Entity target)
        {
            isStan = false;
            
            Console.WriteLine(info() + "делает свой ход");
            target.TakeDamage(power);
            Console.WriteLine();
        }

        public void TakeDamage(int dmg)
        {
            if (isBurn) { dmg += 2; SystemMessege($"{info()} горит", ConsoleColor.Yellow); }
            if (isStan)
            {
                dmg = 0;
                if (isBurn) { dmg = 2; }
            }

            if(protection- dmg > 0)
            {
                int uron = Convert.ToInt32(dmg * (0.8 / shildlv));
                
                    health -= uron;
                    protection -= Convert.ToInt32((dmg - uron) / shildlv);
                
                dmg = uron;
            }
            else
            {
                health -= dmg;
            }

            if (boost)
            {

                dmg -= Dice.Next(1, 10);
                boost = false;
                if (dmg < 0)
                {
                    dmg = 0;
                }
            }
            Console.WriteLine($"{info()} получил {dmg} урона");
        }

        public string info()
        {
            return ($"({_clase}) {name} [{health}] ^{protection}:{shildlv}:^ ");
        }

        public bool IsLose()
        {
            return health <= 0;
        }

        public bool IsBurn()
        {
            isBurn = true;
            return true;
        }

        public void IsStan()
        {
            isStan = true;
        }
        public  bool IsHp()
        {
            return health < maxHp;
        }
        public  int MaxHp()
        {
            return maxHp;
        }
        public bool IsBr()
        {
            return protection < 100;
        }
        public static void SystemMessege(string messege, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(messege);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public  void Heal(Entity target, int heal)
        {
            target.health += heal;
        }
        public void Up()
        {
            boost = true;
            
        }
        public  void Upgrade(Entity target, int up)
        {
            target.protection += up;
        }
        public bool IsSh()
        {
            return shildlv < 4;
        }
        public void ShildlvUp(Entity target)
        {
            if (IsSh())
            {
                target.shildlv += 1;
            }
        }

    }
}
