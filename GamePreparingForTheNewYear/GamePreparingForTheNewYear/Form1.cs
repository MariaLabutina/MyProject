using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePreparingForTheNewYear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpBalans();
        }

       void UpBalans()
        {
            label1.Text = $"Баланс: {Databank.balans}$";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Work work = new Work();
            work.Show();
            this.Hide();
            work.FormClosed += Census;
        }
        protected void Census(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            UpBalans();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            House house = new House();
            house.Show();
            this.Hide();
            house.FormClosed += Census;
        }
    }
}
