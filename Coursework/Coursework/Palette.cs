using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Palette : Form
    {
        public Palette()
        {
            InitializeComponent();
        }
        Graphics g;
        Graphics g1;
        Graphics gf;
        Graphics gb;
        Brush[,] colorf;
        Brush[,] colorb;
        Bitmap bf;
        Bitmap bb;
        int cellHeightf;
        int cellHeightb;
        int cellWidthf;
        int cellWidthb;
        char[] arrayLetters;

        private void Palette_Load(object sender, EventArgs e)
        {
            Bitmap btmf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bitmap btmb = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            bf = new Bitmap(pictureBoxColorF.Width, pictureBoxColorF.Height);
            bb = new Bitmap(pictureBoxColorB.Width, pictureBoxColorB.Height);
            cellHeightf = pictureBox1.Height / 2;
            cellWidthf = pictureBox1.Width / 8;
            cellHeightb = pictureBox2.Height / 2;
            cellWidthb = pictureBox2.Width / 4;
            int v = 1900;
            int z = 32;
            arrayLetters = new char[v];
            for (int i = 0; i < v; i++)
            {
                if (z == 129) z = 161;
                if (z == 560) z = 9600;
                arrayLetters[i] = (char)z;
                z++;
            }

            int c = 25;
            int l = 0;
            int r = arrayLetters.Length / c -2;
            for (int i = 0; i < c; i++)
            {
                dataGridSymbols.Columns.Add(i.ToString(), "0");
                dataGridSymbols.Columns[i].Width = 22;
            }
            dataGridSymbols.Columns[c].Width = 22;
            for (int i = 0; i < r; i++)
            {
                dataGridSymbols.Rows.Add();
                for (int j = 0; j < c + 1; j++)
                {
                    if (l < v)
                    {
                        char tmp = arrayLetters[l];
                        dataGridSymbols[j, i].Value = tmp;
                        l++;
                    }
                    else
                    {
                        char tmp = (char)160;
                        dataGridSymbols[j, i].Value = tmp;
                    }
                   

                }
            }
            colorf = new Brush[2, 8]{ { Brushes.Black,  Brushes.DarkGray, Brushes.Blue, Brushes.RoyalBlue,Brushes.DarkGreen,Brushes.Green,Brushes.DarkCyan,Brushes.Cyan},
                { Brushes.DarkRed, Brushes.Red, Brushes.DeepPink, Brushes.Coral,Brushes.Orange, Brushes.Yellow, Brushes.LightGray, Brushes.White} };
            colorb = new Brush[2,4] { { Brushes.Black, Brushes.White, Brushes.Blue, Brushes.Red }, { Brushes.Green, Brushes.Yellow, Brushes.Gray, Brushes.Cyan } };
            g = Graphics.FromImage(btmf);
            g1 = Graphics.FromImage(btmb);
            for(int x=0; x < 8; x++)
            {
                for(int y=0; y<2; y++)
                {
                    g.FillRectangle(colorf[y,x], x * cellWidthf, y * cellHeightf, cellWidthf, cellHeightf);
                }
            }

            for(int x=0; x<4; x++)
            {
                for(int y=0; y<2; y++)
                {
                    g1.FillRectangle(colorb[y, x], x * cellWidthb, y * cellHeightb, cellWidthb, cellHeightb);
                }
            }
           
            pictureBox1.Image = btmf;
            pictureBox2.Image = btmb;
        }
        void Draw()
        {
            gf = Graphics.FromImage(bf);
            gf.FillRectangle(DataBank.foregroundColor, 0, 0, pictureBoxColorF.Width, pictureBoxColorF.Height);
            pictureBoxColorF.Image = bf;
            gb = Graphics.FromImage(bb);
            gb.FillRectangle(DataBank.backgroundColor, 0, 0, pictureBoxColorB.Width, pictureBoxColorB.Height);
            pictureBoxColorB.Image = bb;
        }

        private void dataGridSymbols_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBank.symbol = (char)dataGridSymbols.CurrentCell.Value;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / cellWidthf;
            int y = e.Y / cellHeightf;
            if (x >= 0 && x <= pictureBox1.Width && y >= 0 && y <= pictureBox1.Height)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DataBank.foregroundColor = colorf[y, x];
                }
            }
            Draw();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / cellWidthb;
            int y = e.Y / cellHeightb;
            if (x >= 0 && x <= pictureBox2.Width && y >= 0 && y <= pictureBox2.Height)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DataBank.backgroundColor = colorb[y, x];
                }
            }
            Draw();
        }
    }
}
