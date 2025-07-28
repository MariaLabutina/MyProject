using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class Dangeon
    {
        public Dangeon() 
        { 
        }
        TrapRoom trapRoom = new TrapRoom();
        VoidRoom voidRoom = new VoidRoom();
        TreasureRoom treasureRoom = new TreasureRoom();
        EnemyRoom enemyRoom = new EnemyRoom();
        public  void GoToDungeon()
        {
            for (int i = 0; i < Dice.Next(5, 11); i++)
            {
                Console.Clear();
                Console.WriteLine($"комната номер {i + 1}");
                switch (Dice.Roll(1, 4))
                {
                    case 1:
                        voidRoom.Act();
                        Console.ReadKey();
                        break;
                    case 2:
                        trapRoom.Act();
                        Console.ReadKey();
                        break;
                    case 3:
                        treasureRoom.Act();
                        Console.ReadKey();
                        break;
                    case 4:
                        enemyRoom.Act();
                        Console.ReadKey();
                        break;


                }
            }
            Console.WriteLine("Поздравляем, вы успешно вышли из подземелья");
            Console.ReadKey();
        }
        public void GoToDungeon2()
        {
            for (int i = 0; i < Dice.Next(8, 13); i++)
            {
                Console.Clear();
                Console.WriteLine($"комната номер {i + 1}");
                switch (Dice.Roll(1, 4))
                {
                    case 1:
                        voidRoom.Act2();
                        Console.ReadKey();
                        break;
                    case 2:
                        trapRoom.Act2();
                        Console.ReadKey();
                        break;
                    case 3:
                        treasureRoom.Act2();
                        Console.ReadKey();
                        break;
                    case 4:
                        enemyRoom.Act2();
                        Console.ReadKey();
                        break;


                }
            }
            Console.WriteLine("Поздравляем, вы успешно вышли из подземелья");
            Console.ReadKey();
        }
        public void GoToDungeon3()
        {
            for (int i = 0; i < Dice.Next(10, 16); i++)
            {
                Console.Clear();
                Console.WriteLine($"комната номер {i + 1}");
                switch (Dice.Roll(1, 4))
                {
                    case 1:
                        voidRoom.Act3();
                        Console.ReadKey();
                        break;
                    case 2:
                        trapRoom.Act3();
                        Console.ReadKey();
                        break;
                    case 3:
                        treasureRoom.Act3();
                        Console.ReadKey();
                        break;
                    case 4:
                        enemyRoom.Act3();
                        Console.ReadKey();
                        break;


                }
            }
            Console.WriteLine("Поздравляем, вы успешно вышли из подземелья");
            Console.ReadKey();
        }
    }
}
