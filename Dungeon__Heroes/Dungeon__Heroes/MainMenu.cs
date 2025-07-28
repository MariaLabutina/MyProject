using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon__Heroes
{
    class MainMenu
    {
        Entity entity = new Entity();
        Dangeon dangeon = new Dangeon();
       static int gold = 100;
        static public int Gold { get => gold; set => gold = value; }

        public void ChoiceHeroes()
        {
            bool t = false;


            Console.WriteLine("соберите свою команду");

            for (int i = 0; Hero.count() < 4; i++)
            {
                int k;

                Console.WriteLine(" 0 - выход из конструктора \n 1 - воин \n 2 - маг \n 3 - лучник \n 4 - священник \n 5 - ассасин  \n 6 - вор  \n 7 - друид  \n");
                Hero.ShowList();

                bool a = int.TryParse(Console.ReadLine(), out k);
                if (!a) { Console.WriteLine("похоже что-то пошло не так"); }

                switch (k)
                {
                    case 1:
                        Hero.Add(new Warrior());
                        Console.WriteLine();
                        break;
                    case 2:
                        Hero.Add(new Wizard());
                        Console.WriteLine();
                        break;
                    case 3:
                        Hero.Add(new Archer());
                        Console.WriteLine();
                        break;
                    case 4:
                        Hero.Add(new Сleric());
                        Console.WriteLine();
                        break;
                    case 5:
                        Hero.Add(new Assassin());
                        Console.WriteLine();
                        break;
                    case 6:
                        Hero.Add(new Looter());
                        Console.WriteLine();
                        break;
                    case 7:
                        Hero.Add(new Druid());
                        Console.WriteLine();
                        break;
                    case 0:
                        if (Hero.count() < 1) { Console.Clear(); Console.WriteLine("вы должны выбрать хотя бы одного персонажа "); continue; }
                        t = true;
                        break;
                }

                Console.Clear();

                if (t) { break; }
            }
        }

        public  void Menu()
        {
            Console.Clear();
            Console.WriteLine(ShowGold());
            Console.WriteLine();
            Hero.ShowList();
            Console.WriteLine("1 - похилиться \n2 - улучшить броню \n3 - поход в данж \n0 - выход");
            Console.WriteLine("куда пойдём?");

            int k;
            bool a = int.TryParse(Console.ReadLine(), out k);
            if (!a) { Console.WriteLine("Ошибка ввода"); }

            switch (k)
            {
                case 1:
                    taverna();
                    break;

                case 2:
                    Console.WriteLine("починить(1) или улучшить(2)?");
                    int x;
                    a = int.TryParse(Console.ReadLine(), out x);
                    if (!a) { Console.WriteLine("Ошибка ввода"); }
                    switch (x)
                    {
                        case 1:
                            Blacksmith();
                            break;
                        case 2:
                            Upgrade();
                            break;
                        default:
                            Console.WriteLine("Ошибка ввода");
                            break;
                    }
                    break;
                    
                case 3:
                    Console.WriteLine("Выберите сложность данжа: ");
                    Console.WriteLine("1 - фигня \n2 - фигня посложнее \n3 - вообще пипец ");
                    int t;
                    bool f = int.TryParse(Console.ReadLine(), out t);
                    if (!f) { Console.WriteLine("Ошибка ввода"); }
                    switch (t)
                    {
                        case 1:
                            dangeon.GoToDungeon();
                            break;

                        case 2:
                            dangeon.GoToDungeon2();
                            break;

                        case 3:
                            dangeon.GoToDungeon3();
                            break;
                    }
                    break;
                case 0:
                    Environment.Exit(0);
                    break;

            }
        }

        public  void taverna()
        {
            Console.Clear();
            Console.WriteLine("добро пожаловать в таверну");
            Console.WriteLine("Выберите номер персонажа, которого хотите угостить.");
            Console.WriteLine("каждое блюдо лечит на пять единиц и стоит 3 золотых.");
            Console.WriteLine("Если хотите покинуть заведение - нажмите 0.");
            do
            {
                int n;

                Console.WriteLine(ShowGold());
                Hero.ShowList();
                Console.Write("кого угостить: ");

                bool a = int.TryParse(Console.ReadLine(), out n);
                if (!a) { Console.Clear(); Console.WriteLine("ошибка ввода"); continue; }

                if (n == 0)
                    break;

                if (n > Hero.count() || n < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода. Выберите номер бойца");
                    continue;
                }


               

                if (Hero.Call(n - 1).IsHp())
                {

                    entity.Heal(Hero.Call(n - 1), 5);
                    gold -= 3;
                }
                else
                {
                    
                    Console.WriteLine("Ваше hp не может превышать нормы");
                    Console.ReadKey();
                }
               

                Console.Clear();
            } while (gold >= 0);

        }
        public  void Blacksmith()
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать в подвал\nЗдесь вы можете починить свою броню\nНажмите на 0 чтобы выйти");
            do
            {
                int n;

                Console.WriteLine(ShowGold());
                Hero.ShowList();
                Console.WriteLine("Я создаю броню под  коньячок ;) и мне нужно чтобы ты выбрал кому мне сделать эту брону.");
                Console.WriteLine("Я востановлю тебе 5 защиты и стоить это будет 10 золотых.");
                bool a = int.TryParse(Console.ReadLine(), out n);
                if (!a) { Console.Clear(); Console.WriteLine("ошибка ввода"); continue; }

                if (n == 0)
                    break;

                if (n > Hero.count() || n < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода. Выберите номер бойца");
                    continue;
                }



                if (Hero.Call(n - 1).IsBr())
                {
                    entity.Upgrade(Hero.Call(n - 1), 5);
                    gold -= 10;
                }
                else
                {
                    Console.WriteLine("Броня не может быть больше 100");
                    Console.ReadKey();
                }


                Console.Clear();
            } while (gold >= 0);
        }
        public void Upgrade()
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать на чердак \nЗдесь вы можете улучшить свою броню\nНажмите на 0 чтобы выйти");
            
            do
            {
                int n;

                Console.WriteLine(ShowGold());
                Hero.ShowList();
                Console.WriteLine("Я подниму тебе уровень брони за 250 золотых.");
                Console.WriteLine("Мне нужно чтобы ты выбрал кому мне сделать это. ");
                bool a = int.TryParse(Console.ReadLine(), out n);
                if (!a) { Console.Clear(); Console.WriteLine("ошибка ввода"); continue; }

                if (n == 0)
                    break;

                if (n > Hero.count() || n < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода. Выберите номер бойца");
                    continue;
                }
                if (Hero.Call(n - 1).IsSh())
                {
                    entity.ShildlvUp(Hero.Call(n - 1));
                    gold -= 250;
                }
                else
                {
                    Console.WriteLine("Возможности улучшить больше нет! Идите дальше!?");
                    Console.ReadKey();
                }
                

                Console.Clear();
            } while (gold >= 0);
        }

        public  string ShowGold()
        {
            return $"у вас на счету: {gold} монет";
        }

        public  bool IsWin()
        {
            return gold > 15000;

        }
        public  bool IsLose()
        {
            return gold < 0;


        }

        
    }
}
