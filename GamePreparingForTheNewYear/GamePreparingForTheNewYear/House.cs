using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePreparingForTheNewYear
{
    public partial class House : Form
    {

        List<string> images = new List<string>();
        List<string> next = new List<string>();
        List<string> dialogs = new List<string>();

        public House()
        {
            InitializeComponent();
            images.Add("уборка.jpg");
            images.Add("убранный.jpg");
            images.Add("добавляемсвет.png");
            images.Add("покупаемелку.jpg");
            images.Add("украшаемелку.jpg");
            images.Add("добавляемеловыхветочек.png");
            images.Add("добавляемвенок.jpg");
            images.Add("ставимпосудунастол.jpg");
            images.Add("ставимзакуски.jpg");
            images.Add("мыготовыкнг.jpg");

            dialogs.Add("Начнем Новый год с чистого листа: выбросим старые и ненужные вещи, которые давно стоят без дела и только занимают место в квартире.");
            dialogs.Add("Молодцы! Давайте повесим гирлянду над кроватью, над окном, вокруг потолка и вдоль книжных полок.");
            dialogs.Add("Так, начало есть. Теперь нам нужно купить елку! ");
            dialogs.Add("Самый верный и быстрый способ создать дома новогоднюю атмосферу — нарядить елку.");
            dialogs.Add("Давайте повесим несколько еловых веток в доме (от потолка до пола).");
            dialogs.Add("На дверь можно повесить еловый венок по европейской традиции.");
            dialogs.Add("Канун Нового года — самое подходящее время, чтобы обновить домашний текстиль. Позаботимся о сервировке: нарядные салфетки и красивая скатерть на праздничном столе будут очень кстати.");
            dialogs.Add("Чтобы лучше прочувствовать атмосферу празника давайте накроем на стол!");
            dialogs.Add("Поздравляю! Мы хорошо постарались!");
            dialogs.Add("Новый год! Ура!");

            next.Add("Приберитесь дома!");
            next.Add("Добавьте огоньков!");
            next.Add("Купите елку!");
            next.Add("Украсьте елку!");
            next.Add("Украсьте дом еловыми веточками!");
            next.Add("Повесьте венок!");
            next.Add("Сервируем стол");
            next.Add("Очередь закусок");
            next.Add("Хорошо постарались, жми дальше!");
            next.Add("Новый год, УРА!!!");
        }

        private void House_Load(object sender, EventArgs e)
        {
            Level();
        }

        void Level()
        {
            if (Databank.img<images.Count())
            {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"img\{images[Databank.img]}");
            pictureBox1.BackgroundImage = Image.FromFile(path);
            label2.Text = next[Databank.dia];
            label1.Text = $"Баланс: {Databank.balans}$";
            richTextBox1.Text = dialogs[Databank.dia];

            }
            else
            {
                button1.Text = "Закончить";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

           var result= MessageBox.Show($"Оплатить {Databank.price}$", "Выполнение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (Databank.price <= Databank.balans)
                {
                    Databank.balans -= Databank.price;
                    if (button1.Text == "Закончить")
                    {
                        this.Close();
                    }
                    else
                    {
                        Databank.dia += 1;
                        Databank.img += 1;
                        Databank.price += 100;
                        Level();
                    }
                }
                else
                {
                    MessageBox.Show($"Недостаточно средств! Сходите на работу!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
