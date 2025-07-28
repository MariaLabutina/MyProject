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
    public partial class Pay : Form
    {
        public static double fee;
        string pay= " ";
        int p;
        public static int cash =0;
        public static int change=0;
        double sk;
        public static int skidka;
        public Pay()
        {
            InitializeComponent();
            DataBank.pay = false;
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            fee = Form1.payment;
            textBox1.Text = fee.ToString();
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            groupBox1.Enabled = false;
            button3.Enabled = false;
        }
        //реализация кнопки клавиатуры
        private void b1_Click(object sender, EventArgs e)
        {
            pay += "1";
            Con();

        }
        //реализация кнопки клавиатуры
        private void b2_Click(object sender, EventArgs e)
        {
            pay += "2";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b3_Click(object sender, EventArgs e)
        {
            pay += "3";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b4_Click(object sender, EventArgs e)
        {
            pay += "4";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b5_Click(object sender, EventArgs e)
        {
            pay += "5";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b6_Click(object sender, EventArgs e)
        {
            pay += "6";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b7_Click(object sender, EventArgs e)
        {
            pay += "7";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b8_Click(object sender, EventArgs e)
        {
            pay += "8";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b9_Click(object sender, EventArgs e)
        {
            pay += "9";
            Con();
        }
        //реализация кнопки клавиатуры
        private void b0_Click(object sender, EventArgs e)
        {
            pay += "0";
            Con();
        }
        //реализация кнопки ввода оплаты
        private void button4_Click(object sender, EventArgs e)
        {
            DataBank.pay = true;
            textBox1.Text = " ";
            p = Convert.ToInt32(pay);
            cash = p;
            if(p<(int)fee)
            {
                MessageBox.Show("Введите правильную оплату!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
            textBox2.Text = "Сдача:";
            p -= (int)fee;
                change = p;
            textBox1.Text = p.ToString();
            groupBox1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            }
        }
        //обновление кнопки
        public void Con()
        {
            textBox1.Text = " ";
            textBox1.Text = pay;
        }

        //реализация кнопки для оплаты
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Text = " ";
            textBox2.Text = "Внесено:";
        }

        //реализация кнопки для удаления
        private void button5_Click(object sender, EventArgs e)
        {
            if (pay.Length == 1)
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
                pay = pay.Remove(pay.Length - 1);
            }
            Con();
        }

        //реализация кнопки со скидками
        private void button1_Click(object sender, EventArgs e)
        {
            sk = 0;
            DialogResult result = MessageBox.Show("Клиент пенсионер?","Скидка пенсионерам", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                skidka = 10;
                sk = (fee / 100) * skidka;
                fee -= sk;
            }
            else
            {
                DialogResult r = MessageBox.Show("Клиент студент?", "Скидка голодающим студентам", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    skidka = 5;
                    sk = (fee / 100) * skidka;
                    fee -= sk;
                }
            }
            textBox1.Text = ((int)fee).ToString();
            button1.Enabled = false;
        }

        //создание чека
        private void button3_Click(object sender, EventArgs e)
        {
            Cheque cheque = new Cheque();
            cheque.Print();
            button3.Enabled = false;
            this.Close();
        }
    }
}
