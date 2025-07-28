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
    public partial class Change : Form
    {
        TextBox[] textBox = new TextBox[Form1.z.Count];
        Font font = new Font("Monotype Corsiva", 18.0f, FontStyle.Italic);
        int size = 0;

        public Change()
        {
            InitializeComponent();

        }

        private void Change_Load(object sender, EventArgs e)
        {
            size = Form1.z.Count;
            Array.Resize(ref textBox, size);
            CreateTextBox();

            for (int i = 0; i < Form1.z.Count; i++)
            {
                textBox[i].Click += new System.EventHandler(this.textBox_Click);
            }
        }

        //вызов формы для изменения товара
        private void textBox_Click(object sender, EventArgs e)
        {
            Foc();
            ClickForm form = new ClickForm();
            form.Show();

            form.FormClosed +=Census;
        }
        //создание тестбоксов и их заполнение
        public void CreateTextBox()
        {
            int x = 30;
            int y = 30;
            for (int i = 0; i < Form1.z.Count; i++)
            {
                if (i%3==0&&i!=0)
                {
                x = 30;
                y += 200;
                }
                else if(i!=0)
                {
                x += 300;
                }
                textBox[i] = new TextBox();
                textBox[i].Location = new Point(x, y);
                textBox[i].Multiline = true;
                textBox[i].BackColor = Color.WhiteSmoke;
                textBox[i].Font = font;
                textBox[i].Height = 135;
                textBox[i].Width = 225;
                textBox[i].Text = Form1.z[i];
                textBox[i].ReadOnly = true;
                this.Controls.Add(textBox[i]);
            }
        }
        //изменение товара
        public void ChangeTovar()
        {
            if (DataBank.del == false)
            {
            for(int i=0; i< Form1.z.Count; i++)
            {
                Form1.z[i] = textBox[i].Text;
                textBox[i].Text = " ";
            }

            }
        }
        //сохранение изменений и закрытие формы
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeTovar();
            this.Close();
        }
        //выборка текстбокса
        public void Foc() 
        { 
            for(int i = 0; i < Form1.z.Count; i++)
            {
                if (textBox[i].Focused == true)
                {
                    DataBank.t = i;
                }
            }

        }
        //перепись выбранного тексбокса
        protected void Census(object sender, System.Windows.Forms.FormClosedEventArgs e) 
        {
            if (DataBank.click == true)
            {
            textBox[DataBank.t].Text = DataBank.change;
            }
            if (DataBank.del==true)
            {
                Form1.z.RemoveAt(DataBank.t);
                Read();
                textBox[textBox.Length-1].Visible = false;
                textBox[textBox.Length-1].Enabled = false;
                size = Form1.z.Count;
                Array.Resize(ref textBox, size);
            }
        }

        //реализация метода перезаписи листов с товарами
        public void Read()
        {
            for(int i=0; i < Form1.z.Count; i++)
            {
            Form1.z[i] = $"Товар № {i+1} \n{Form1.n[i]} ".Replace("\n", Environment.NewLine);
            if (Form1.b[i] == false)
            {
                string razmer = Form1.r[i].ToString();
                Form1.z[i] += $"\nРазмер: {razmer} ml".Replace("\n", Environment.NewLine);
            }
            Form1.z[i] += $"\nКоличество: {Form1.k[i]} \nСтоимость: {Form1.price[i]} \n\n".Replace("\n", Environment.NewLine);
             textBox[i].Text= Form1.z[i];
            }
        }


    }
}
