using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGenerals
{
    public partial class Form1 : Form
    {
        private int peasants = 0; //крестьяне, чел
        private double square = 0; // площадь, км2
        private double stocks = 0; //зерно на складе, т
        Random rnd = new Random();
        private State state;
        public Form1()
        {
            Completion();
            InitializeComponent();
            numericUpDownSeed.Maximum = Convert.ToDecimal((peasants / d) * b);
            Fill();
            state = new State(peasants, square, stocks);
        }

        int d = 4; //человек на км2
        double b = 0.75; //зерна на км2
        

        private void button1_Click(object sender, EventArgs e)
        {
            state.Sow((double)numericUpDownSeed.Value);
            
        }

        //установка изначальных параметров государства
        private void Completion()
        {
            square = rnd.Next(10, 10000);
            peasants = rnd.Next((int)square, (int)square * 100);
            stocks = rnd.Next((int)(peasants * 0.25 * 1.5), (int)(peasants * 0.25 * 4));
        }


        private void Fill()
        {
            labelSquare.Text = square.ToString();
            labelPopulation.Text = peasants.ToString();
            labelSeed.Text = stocks.ToString();
        }
    }
}
