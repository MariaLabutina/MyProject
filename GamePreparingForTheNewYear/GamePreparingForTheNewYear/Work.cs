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
    public partial class Work : Form
    {
        public static double level = Databank.levelwork+1;
        Button[] buttons = new Button[(int)Math.Pow(level, 2)];
        Button firstbutton;
        Button secondbutton;
        List<int> number=new List<int>();
        Image image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"img\1.jpg"));

        public Work()
        {

            InitializeComponent();
            if (Databank.level>1)
            {
                UpLevel();
            }
            int h = 100 / (int)level;
            tableLayoutPanel1.ColumnCount = (int)level;
            tableLayoutPanel1.RowCount = (int)level;
            tableLayoutPanel1.RowStyles[0] = new RowStyle(SizeType.Percent, h);
            tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, h);
            for (int i=1; i<(int)level; i++)
            {
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,h));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,h));

            }
            label1.Text = $"Уровень {Databank.level}";
            //Databank.win = false;
        }
        public void UpLevel()
        {
            level = Databank.levelwork + 1;
            Array.Resize(ref buttons, (int)Math.Pow(level, 2));
        }
        private void Work_Load(object sender, EventArgs e)
        {
            int m = 1;
            for (int i = 0; i < (int)Math.Pow(level, 2); i++)
            {
                if (i % 16==0)
                {
                    m = 1;
                }
                if (i % 2 == 0&&i!=0&& i % 16 != 0)
                {
                    m += 1;
                }
                number.Add(m);
               
            }
            CreateButtons();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += new System.EventHandler(this.buttons_Click);
            }
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
               
                if (clickedButton.Image ==null)
                    return;

                if (firstbutton == null)
                {
                    firstbutton = clickedButton;
                    firstbutton.Image = null;
                    return;
                }
                if (secondbutton == null)
                {
                    secondbutton = clickedButton;
                    secondbutton.Image = null;
                    if (firstbutton.Text == secondbutton.Text)
                    {
                        firstbutton.Enabled = false;
                        secondbutton.Enabled = false;
                        firstbutton = null;
                        secondbutton = null;
                    }

                }
            }
            timer1.Start();
           
        }

        void CreateButtons()
        {
            Random rnd = new Random();
            int n=0;
            int b = 750/(int)level;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (number.Count == 1)
                {
                    n = 0;
                }
                else
                {
                    n = rnd.Next(0, number.Count);
                }
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"img\{number[n]}.png");
                buttons[i] = new Button();
                buttons[i].BackgroundImage = Image.FromFile(path);
                buttons[i].Image = image;
                buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[i].AutoSize = false;
                buttons[i].Dock = DockStyle.Fill;
                buttons[i].ForeColor = Color.Transparent;
                buttons[i].Height = b;
                buttons[i].Width = b;
                buttons[i].Text = number[n].ToString();
                buttons[i].TextAlign = ContentAlignment.TopLeft;

                tableLayoutPanel1.Controls.Add(buttons[i]);
                number.RemoveAt(n);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (firstbutton != null&& secondbutton!=null)
            {
            firstbutton.Image = image;
            secondbutton.Image = image;
            firstbutton = null;
            secondbutton = null;
            }
            CheckForWinner();
        }

        private void CheckForWinner()
        {
           
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Button iconButton = control as Button;

                if (iconButton != null)
                {
                    if (iconButton.Enabled == true)
                        return;
                }
            }
            MessageBox.Show("Вы прошли уровень!", "Поздравляем!");
            Databank.balans += (25 * Databank.level);
            //Databank.win = true;
            if (Databank.level % 4 == 0)
            {
            Databank.levelwork += 2;
            }
            Databank.level += 1;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
