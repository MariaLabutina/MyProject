using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeHouse
{
    public partial class SizeGlass : Form
    {
        int a=200;
        int b=250;
        int c=350;
        string m = " ml";
        public SizeGlass()
        {
            InitializeComponent();
            button2.Text = a.ToString() + m;
            button3.Text = b.ToString() + m;
            button4.Text = c.ToString() + m;

        }

        private void SizeGlass_Load(object sender, EventArgs e)
        {
            DataBank.size = "";
        }
        //сохранение выбранного размера товара
        private void button2_Click(object sender, EventArgs e)
        {
            DataBank.size = button2.Text;
            DataBank.s = a; 
            this.Close();
        }
        //сохранение выбранного размера товара
        private void button3_Click(object sender, EventArgs e)
        {
            DataBank.size = button3.Text;
            DataBank.s = b;
            this.Close();
        }
        //сохранение выбранного размера товара
        private void button4_Click(object sender, EventArgs e)
        {
            DataBank.size = button4.Text;
            DataBank.s = c;
            this.Close();
        }
    }
}
