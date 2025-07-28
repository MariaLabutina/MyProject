using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGenerals
{
    internal class State
    {
        public State() { 

        }

        private int peasants = 100; //крестьяне, чел
        private double square = 10; // площадь, км2
        //private double seed; //зерно в общем, т
        private double stocks = 50; //зерно на складе, т

        public State(int peasents, double square, double stocks)
        {
            this.peasants = peasents;
            this.square = square; 
            this.stocks = stocks;
        }


        private double a = 0.25; //потребление зерна одним человеков  в тоннах в год
        private double b = 0.75; //высев зерна на 1 км2
        private double c = 0.001; //место на одного человека в км2
        private int d = 4;//кол-во человек обрабатывающих 1км2

        Random rnd = new Random();

        //засеивать зерно
        public void Sow(double seed)
        {
            stocks -= seed;
            Life(seed);
        }

        private void Life(double seed)
        {
            int bp = 0; //сколько родилось
            int mp = 0;// сколько умерло
            double unplantedArea = square - (seed / b);//площадь которую не засеяли
            double remainingSpace = unplantedArea - (peasants * c);//сколько остается места
            double gh= peasants * a; //потребление зерна
            stocks -= gh;//сколько осталось зерна после посева и потребления
            if (stocks >= 0 & remainingSpace >= 0)
            {
                bp = Birth(remainingSpace);
                peasants += bp;
            }
            else
            {
                mp = Mortality(remainingSpace);
                peasants -= mp;
            }
            stocks += (seed * rnd.Next(2, 10));
            MessageBox.Show($"Зерно {stocks}\n Население {peasants}\n Родилось {bp}\n Умерло {mp}");
        }


        //сколько родилось
        private int Birth(double remainingSpace)
        {
            int i = Convert.ToInt32(remainingSpace / c); //сколько людей может родится в соответсвии с количеством земли
            int j = 0;
            double seed = stocks;

            while (seed>0)
            {
                seed -= a; //все зерно минус потребление рожденного в этот год
                j++;
            }

            j=rnd.Next(1, j);

            return j; //сколько родилось
        }

        //сколько умерло
        private int Mortality(double remainingSpace)
        {
            int count = 0;
            int i = 0;
            int j = 0;

            if (remainingSpace < 0)
            {
               j = Convert.ToInt32((remainingSpace / c) * -1);
            }

            if (stocks < 0)
            {
                i = Convert.ToInt32((stocks / a) * -1);
            }
            
            count = j - i;
            if (count < 0)
            {
                count *= -1;
            }
            if (count > peasants) { count = peasants; }

            return count;
        }


    }
}
