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
    public partial class ClickForm : Form
    {
        int pr;
        double p;
        int cost = 0;
        bool pie;
        string vid;
        public ClickForm()
        {
            InitializeComponent();
            //заполнение комбобокса с количеством товара
            for (int i = 1; i < 21; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }
            //заполнение комбобокса с размером
            comboBox4.Items.Add("200");
            comboBox4.Items.Add("250");
            comboBox4.Items.Add("350");
            //активация кнопок размера
            if (Form1.b[DataBank.t] == false)
            {
                comboBox4.Enabled = true;
                comboBox4.Visible = true;
                label5.Visible = true;
                Razmer(Form1.r[DataBank.t]);
            }
            else
            {
                comboBox4.Enabled = false;
                comboBox4.Visible = false;
                label5.Visible = false;
            }
            label7.Text = (DataBank.t + 1).ToString();
            Vid(Form1.n[DataBank.t]);//заполнение комбобокса с видом товара
            ComboName(comboBox1.SelectedIndex);
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                if (Form1.k[DataBank.t].ToString() == comboBox3.Items[i].ToString())
                {
                    comboBox3.SelectedIndex = i;
                }
            }

            Price(comboBox2.SelectedIndex, comboBox3.SelectedIndex);//цена
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
        }

        //выделение товара
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Price(comboBox2.SelectedIndex, comboBox3.SelectedIndex);
        }
    


        private void ClickForm_Load(object sender, EventArgs e)
        {
            Singleton.Instance.Connection();

            DataBank.click = false;
            DataBank.del = false;
        }

        //заполнение комбобокса с именами товара
        public void ComboName(int index)
        {
            string vid = comboBox1.Items[index].ToString();
            if(Form1.b[DataBank.t] == false||pie==false)
            {
                string query = $"SELECT Напиток.[Название] FROM Напиток WHERE Напиток.[Тип]= '{vid}'; ";
                OleDbCommand command = new OleDbCommand(query, Singleton.Instance.Connection());
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
            }
            else if(Form1.b[DataBank.t] == true||pie==true)
            {

                string q = $"SELECT Выпечка.[Название] FROM Выпечка; ";
                OleDbCommand com = new OleDbCommand(q, Singleton.Instance.Connection());
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
            }
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString() == Form1.n[DataBank.t])
                {
                    comboBox2.SelectedIndex = i;
                }
            }
        }
        //заполнение комбобокса с видом товара
        public void Vid(string name)
        {
            if (Form1.b[DataBank.t] == false)
            {
                comboBox1.Items.Add("классика");//0
                comboBox1.Items.Add("авторский");//1
                string query = $"SELECT Напиток.[Тип] FROM Напиток WHERE Напиток.[Название]= '{name}'; ";
            OleDbCommand command = new OleDbCommand(query, Singleton.Instance.Connection());
                string b = command.ExecuteScalar().ToString();
                if (b == "Классика")
                {
                    comboBox1.SelectedIndex = 0;
                    pie = false;
                    vid = "классика";
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                    pie = false;
                    vid = "авторский";
                }


            }
            else
            {
                comboBox1.Items.Add("Выпечка");//3
                comboBox1.SelectedIndex = 0;
                pie = true;
                vid = "пирожок";
            }

           
        }
        //заполнение комбобокса с размером товара
        public void Razmer(int size)
        {
            for(int i=0; i<comboBox4.Items.Count;i++)
            if (comboBox4.Items[i].ToString() == size.ToString())
            {
                    comboBox4.SelectedIndex = i;
            }
        }
        //изменение имен при изменении вида
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            ComboName(comboBox1.SelectedIndex);


        }

        //метод для расчета цены
        public void Price(int n, int c)
        {
            string name = comboBox2.Items[n].ToString();
            int count = Convert.ToInt32(comboBox3.Items[c].ToString());
            pr = 0;
            p = 0;
            if (Form1.b[DataBank.t] == false)
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
            label8.Text = cost.ToString();
            cost = 0;
        }

        //сохранение изменений 
        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.click = true;
            string tovar = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            Form1.n[DataBank.t] = tovar;
            string count = comboBox3.Items[comboBox3.SelectedIndex].ToString();
            Form1.k[DataBank.t] = Convert.ToInt32(count);
            Form1.price[DataBank.t]= Convert.ToInt32(label8.Text);
            DataBank.change = " ";
            DataBank.change = $"Товар № {DataBank.t+1} \n{tovar} ".Replace("\n", Environment.NewLine);
            if (pie == false)
            {
            string razmer = comboBox4.Items[comboBox4.SelectedIndex].ToString();
            Form1.r[DataBank.t] = Convert.ToInt32(razmer);
                DataBank.change += $"\nРазмер: {razmer} ml".Replace("\n", Environment.NewLine);
            }
            DataBank.change+= $"\nКоличество: {count} \nСтоимость: {label8.Text} \n\n".Replace("\n", Environment.NewLine);
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            this.Close();
        }
        //удаление товара
        private void button2_Click(object sender, EventArgs e)
        {
            DataBank.del = true;

            Form1.n.RemoveAt(DataBank.t);
            Form1.k.RemoveAt(DataBank.t);
            Form1.price.RemoveAt(DataBank.t);
            Form1.r.RemoveAt(DataBank.t);
            Form1.b.RemoveAt(DataBank.t);


            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            this.Close();
        }
    }
}
