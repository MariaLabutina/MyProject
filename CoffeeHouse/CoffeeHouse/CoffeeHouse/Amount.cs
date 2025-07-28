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
    public partial class Amount : Form
    {
        int count;
        public Amount()
        {
            InitializeComponent();
            count = 1;
            label2.Text = count.ToString();
        }

        //реализация кнопки подтверждения
        private void button3_Click(object sender, EventArgs e)
        {
            DataBank.count = count;
            count = 1;
            label2.Text = count.ToString();
            this.Close();
        }

        //реализация кнопки добавления количества товара
        private void button2_Click(object sender, EventArgs e)
        {
            if (count > 20)
            {
                MessageBox.Show("Нельзя больше 20 единиц товара!", "Внимание!", MessageBoxButtons.OK);
            }
            else
            {
            count++;
            label2.Text = count.ToString();
            }
        }

        //реализация кнопки удаления количества товара
        private void button1_Click(object sender, EventArgs e)
        {
            if (count <= 1)
            {
                MessageBox.Show("Нельзя меньше 1 товара!", "Внимание!", MessageBoxButtons.OK);
            }
            else
            {
            count--;
            label2.Text = count.ToString();
            }
        }

        private void Amount_Load(object sender, EventArgs e)
        {

        }
    }
}
