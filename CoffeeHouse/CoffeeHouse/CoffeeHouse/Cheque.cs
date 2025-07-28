using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse
{
    //класс создания чека
    class Cheque
    {
        string path = "Чек.txt";//путь к документу
        List<string> n = new List<string>();//лист товаров

        //метод для печати чека в документ
        public void Print()
        {
            int counter = 0;//количество
            double sum = 0;//оплата 
            var builder = new StringBuilder();//переменная хранящая ин-цию из чека
            var buyerList = new List<Goods>();//лист товаров для чека

            for (int i=0; i<Form1.n.Count; i++)
            {
                if (Form1.b[i] == false)
                {
                    n.Add(Form1.n[i] + " " + Form1.r[i] + " ml");
                }
                else
                {
                    n.Add(Form1.n[i]);
                }
            }


            //заполнение чека
            for (int i = 0; i < Form1.count-1; i++)
            {
                buyerList.Add(new Goods(n[i], Form1.k[i], Form1.price[i]));
            }
            builder.AppendLine($"{"".PadRight(15, ' ')}Кофейня 'Добби свободен'");
            builder.AppendLine($"{"".PadRight(25, ' ')}Касса №1");
            foreach (var product in buyerList)
            {
                counter++;
                sum += product.price;
                builder.AppendLine($"{counter}.{product.name}");
                builder.AppendLine($"  Количество:{product.count}");
                builder.AppendLine($"  Стоимость{"".PadRight(40 - product.price.ToString().Length, '.')}{product.price}");
            }
            builder.AppendLine("".PadRight(51, '='));
            builder.AppendLine($"Всего{"".PadRight(46 - sum.ToString().Length, '.')}{sum}");
            builder.AppendLine($"Скидка{"".PadRight(44- Pay.skidka.ToString().Length, ' ')}{Pay.skidka}%");
            sum -= Math.Round(sum / 100 * Pay.skidka, 2);
            builder.AppendLine($"Итог{"".PadRight(47 - ((int)sum).ToString().Length, ' ')}{(int)sum}");
            builder.AppendLine("".PadRight(51, '-'));
            builder.AppendLine($" Наличные{"".PadRight(41 - Pay.cash.ToString().Length, ' ')}{"="+Pay.cash}");
            builder.AppendLine($" Сдача{"".PadRight(44 - Pay.change.ToString().Length, ' ')}{"="+ Pay.change}");


            //вывод чека в документ
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                 writer.WriteLineAsync(builder.ToString());
            }
        }

    }

    //класс с товарами 
         class Goods
        {
            public string name;
            public int count;
            public int price;
            public Goods(string name, int count, int price)
            {
                this.name = name;
                this.count = count;
                this.price = price;
            }

        }
    
}
