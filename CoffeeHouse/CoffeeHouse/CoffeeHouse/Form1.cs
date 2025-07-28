using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CoffeeHouse
{
    public partial class Form1 : Form
    {
        string zakaz;
        SizeGlass form = new SizeGlass();
        Amount amo = new Amount();
       
        string tovar;
        public static int count = 1;
        public static List<string> z = new List<string>();
        public static List<string> n = new List<string>();
        public static List<int> k = new List<int>();
        public static List<int> r = new List<int>();
        public static List<bool> b = new List<bool>();
        public static List<int> price = new List<int>();
        List<string> name = new List<string>();
        int pr;
        double p;
        int cost = 0;
        public static int payment;
        bool check;
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            classic.BackgroundImageLayout = ImageLayout.Stretch;
            avtorsky.BackgroundImageLayout = ImageLayout.Stretch;
            piroshky.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
            label2.Text=cost.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Singleton.Instance.Connection();

        }
        //активация кнопок Классического кофе
        private void classic_Click(object sender, EventArgs e)
        {
            CleanButton();
            NameCoffee("классика");
            DataBank.pie = false;
            NotHideButton();
        }
        //метод создания имен кнопок
        public void NameCoffee(string a)
        {
            string query = $"SELECT Напиток.[Название] FROM Напиток WHERE Напиток.[Тип]= '{a}'; ";
            OleDbCommand command = new OleDbCommand(query, Singleton.Instance.Connection());
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            button1.Text = name[0];
            button2.Text = name[1];
            button3.Text = name[2];
            name.Clear();
        }

        //активация кнопок товара
        public void NotHideButton()
        {
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = true;
            button2.Visible = true;
            button3.Enabled = true;
            button3.Visible = true;
        }
        //добавление товара
        private void button1_Click(object sender, EventArgs e)
        {
            tovar = button1.Text;
            Zakazik(tovar);

        }
        //добавление товара
        private void button2_Click(object sender, EventArgs e)
        {
            tovar = button2.Text;
            Zakazik(tovar);
        }

        //добавление товара
        private void button3_Click(object sender, EventArgs e)
        {
            tovar = button3.Text;
            Zakazik(tovar);
        }



        //создание заказа
        public void Zakazik(string tovar)
        {
            if(DataBank.pie == false)
            {
                form.ShowDialog();
            }
            amo.ShowDialog();
            CheckPlusAdd(tovar);
            
            if (check == false)
            {
            n.Add(tovar);
            zakaz = $"Товар № {count} ".Replace("\n", Environment.NewLine);
            zakaz += $"\n{tovar} ".Replace("\n", Environment.NewLine);
            if (DataBank.pie == false)
            {
            zakaz += $"\nРазмер: {DataBank.size} ".Replace("\n", Environment.NewLine);
            }
            b.Add(DataBank.pie);
            r.Add(DataBank.s);
            zakaz += $"\nКоличество: {DataBank.count} ".Replace("\n", Environment.NewLine);
            k.Add(DataBank.count);
            Price(tovar,DataBank.count);
            zakaz+= $"\nСтоимость: {pr} \n\n".Replace("\n", Environment.NewLine);
            price.Add(pr);
            richTextBox1.Text += zakaz;
            count++;
            z.Add(zakaz);
            }
            else
            {
                richTextBox1.Clear();
                for(int i=0; i<z.Count; i++)
                {
                    richTextBox1.Text += z[i];
                }
            }
        }
       


        //очистка и перезапись текста в заказе
        protected void Read(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
                richTextBox1.ReadOnly = false;
                richTextBox1.Clear();
                for (int i = 0; i < z.Count; i++)
                {
                    richTextBox1.Text += z[i];
                }
                richTextBox1.ReadOnly = true;
            int p=0;
            for(int i=0; i< price.Count; i++)
            {
                p += price[i];
            }
            label2.Text = p.ToString();
            if (DataBank.del == true)
            {
                count = z.Count+1;
                cost = 0;
            }
        }
        //активация кнопок Авторского кофе
        private void avtorsky_Click(object sender, EventArgs e)
        {
            CleanButton();
            DataBank.pie = false;
            NameCoffee("Авторский");
            NotHideButton();
        }
        //активация кнопок Выпечки
        private void piroshky_Click(object sender, EventArgs e)
        {
            CleanButton();
            DataBank.pie = true;
            string query = $"SELECT Выпечка.[Название] FROM Выпечка; ";
            OleDbCommand command = new OleDbCommand(query, Singleton.Instance.Connection());
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            button1.Text = name[0];
            button2.Text = name[1];
            button3.Text = name[2];
            name.Clear();
            NotHideButton();
        }
        //метод очистки имен кнопок
        public void CleanButton()
        {
            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
        }

        //вычисление стоимости товара
        public void Price(string name, int count)
        {
            pr = 0;
            p = 0;
            if (DataBank.pie == false)
            {
                string request = $"SELECT Напиток.[Стоимость] FROM Напиток WHERE Напиток.[Название]='{name}';";
                OleDbCommand com = new OleDbCommand(request, Singleton.Instance.Connection());
                pr = Convert.ToInt32(com.ExecuteScalar().ToString());
                string z = $"SELECT Напиток.[Процент стоимости на ув об] FROM Напиток WHERE Напиток.[Название]='{name}';";
                OleDbCommand comm = new OleDbCommand(z, Singleton.Instance.Connection());
                p = Convert.ToDouble(comm.ExecuteScalar().ToString());
                p = (p / 100) * pr;
                pr += (int)((DataBank.s / 50 - 4) * p);
                pr *= count;
            }
            else
            {
                string request = $"SELECT Выпечка.[Стоимость] FROM Выпечка WHERE Выпечка.[Название]='{name}';";
                OleDbCommand com = new OleDbCommand(request, Singleton.Instance.Connection());
                pr = Convert.ToInt32(com.ExecuteScalar().ToString());
                pr *= count;
            }
            cost += pr;
            label2.Text = cost.ToString();
        }
        //открытие формы для изменения заказа
        private void changeButton_Click(object sender, EventArgs e)
        {
            Change change = new Change();
            change.Show();
            change.FormClosed += Read;
        }

        //оплата
        private void button6_Click(object sender, EventArgs e)
        {
            Pay pay = new Pay();
            payment = Convert.ToInt32(label2.Text);
            pay.Show();
            pay.FormClosed += On;

        }
        //добавление повторного товара
        public void CheckPlusAdd(string tovar)
        {
            check = false;
            for (int i=0; i<z.Count; i++)
            {
                if (n[i] == tovar)
                {
                    if(DataBank.pie == false)
                    {
                        if (r[i] == DataBank.s)
                        {
                            check = true;
                            Price(tovar, DataBank.count);
                            price[i] += pr;
                            k[i] += DataBank.count;
                            z[i]= $"Товар № {i + 1} \n{n[i]} \nРазмер: {r[i]} ml\nКоличество: {k[i]} \nСтоимость: {price[i]} \n\n".Replace("\n", Environment.NewLine);
                            break;                        
                        }
                       
                    }
                    else
                    {
                        check = true;
                        Price(tovar, DataBank.count);
                        price[i] += pr;
                        k[i] += DataBank.count;
                        z[i] = $"Товар № {i + 1} \n{n[i]} \nКоличество: {k[i]} \nСтоимость: {price[i]} \n\n".Replace("\n", Environment.NewLine);
                        break;
                    }
                }
            }
        }

        //блок кнопок которые больше не нужны и активация оформления заказа
        protected void On(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (DataBank.pay == true)
            {
                button4.Enabled = true;
                button4.Visible = true;
                button6.Enabled = false;
                changeButton.Enabled = false;
                label2.Text = ((int)Pay.fee).ToString();
            }

        }
        //оформление заказа
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ваш заказ отправлен бариста!", "Сообщение", MessageBoxButtons.OK);
            Otkat();
        }

        //возврат к первоначальному окну для создания нового заказа
        public void Otkat()
        {
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
            changeButton.Enabled = true;
            button6.Enabled = true;
            richTextBox1.Clear();
            label2.Text = "0";
            zakaz = " ";
            count = 1;
            z.Clear();
            k.Clear();
            r.Clear();
            b.Clear();
            n.Clear();
            price.Clear();
            cost = 0;
            payment = 0;
        }
    }
}
