using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Coursework
{
    public partial class Form1 : Form
    {
        Bitmap btm;
        Graphics g;
        Bitmap bf;
        Bitmap bb;
        Net net;
        Font font;
        bool[,] toolLayout;
        List<Net> HistoryNet;

        int historyCounter;
        int width;
        int height;
        int cellWidth;
        int cellHeight;
        int pictureWidth;
        int pictureHeight;
        int count;

        int x0, y0;
        bool mousePress;


        public Form1()
        {
            InitializeComponent();
            HistoryNet = new List<Net>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            comboBox1.Items.Add("Линия");
            comboBox1.Items.Add("Точка");
            comboBox1.Items.Add("Карандаш");
            comboBox1.Items.Add("Круг");
            comboBox1.Items.Add("Прямоугольник");
            comboBox1.Items.Add("Ластик");
            comboBox1.SelectedIndex = 1;
            DataBank.height = 50;
            DataBank.width = 80;

            FontFamily fontFamily = new FontFamily("Consolas");
            font = new Font(fontFamily, 12, GraphicsUnit.Pixel);

            bf = new Bitmap(pictureBoxColorF.Width, pictureBoxColorF.Height);
            bb = new Bitmap(pictureBoxColorB.Width, pictureBoxColorB.Height);

            Graphics tmpg = CreateGraphics();
            cellWidth = (int)tmpg.MeasureString("a", font).Width;
            cellHeight = (int)tmpg.MeasureString("a", font).Height;

            Creating();
            ChangeBrush();
        }
        void Creating()
        {
            HistoryNet.Clear();
            ClearToolLayout();
            ClearNetArray();
            historyCounter = 0;
            height = DataBank.height;
            width = DataBank.width;
            net = new Net(width, height);
            toolLayout = new bool[width, height];
            mousePress = false;
            count = 0;

            pictureWidth = width * cellWidth;
            pictureHeight = height * cellHeight;
            pictureBox1.Width = pictureWidth;
            pictureBox1.Height = pictureHeight;

            btm = new Bitmap(pictureWidth, pictureHeight);
            g = Graphics.FromImage(btm);

            DataBank.symbol = (char)100;
            DataBank.foregroundColor = Brushes.White;
            DataBank.backgroundColor = Brushes.Green;
            Draw(false);

            HistoryNet.Add(new Net(net));
            historyCounter++;
        }

        void ChangeBrush()
        {
            labelsymbol.Text = DataBank.symbol.ToString();
            Graphics gf = Graphics.FromImage(bf);
            gf.FillRectangle(DataBank.foregroundColor, 0, 0, pictureBoxColorF.Width, pictureBoxColorF.Height);
            pictureBoxColorF.Image = bf;
            Graphics gb = Graphics.FromImage(bb);
            gb.FillRectangle(DataBank.backgroundColor, 0, 0, pictureBoxColorB.Width, pictureBoxColorB.Height);
            pictureBoxColorB.Image = bb;
        }

        void ClearToolLayout()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    toolLayout[x, y] = false;
                }
            }
        }
        void ClearNetArray()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    net.arrayNets[x, y].backgroundColor = Brushes.Black;
                    net.arrayNets[x, y].foregroundColor = Brushes.Black;
                    net.arrayNets[x, y].symbol = (char)32;
                }
            }
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            string text = comboBox1.Text;
            int x = e.X / cellWidth;
            int y = e.Y / cellHeight;
            if (x >= 0 && x <= net.Width && y >= 0 && y <= net.Height)
            {
                if (e.Button == MouseButtons.Left)
                {
                    switch (text)
                    {
                        case "Точка":
                            net.arrayNets[x, y] = new Cell(DataBank.symbol, DataBank.foregroundColor, DataBank.backgroundColor);
                            break;
                        case "Ластик":
                            x0 = x;
                            y0 = y;
                            toolLayout[x, y] = true;
                            mousePress = true;
                            break;
                        case "Карандаш":
                            x0 = x;
                            y0 = y;
                            toolLayout[x, y] = true;
                            mousePress = true;
                            break;
                        case "Круг":
                            x0 = x;
                            y0 = y;
                            mousePress = true;
                            break;
                        case "Прямоугольник":
                            x0 = x;
                            y0 = y;
                            mousePress = true;
                            break;
                        case "Линия":
                            x0 = x;
                            y0 = y;
                            mousePress = true;
                            break;
                    }
                }
            }
        }

        private void Draw(bool withToolLayout)
        {

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (withToolLayout)
                    {
                        if (!toolLayout[x, y])
                        {
                            g.FillRectangle(net.arrayNets[x, y].backgroundColor, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
                            g.DrawString(net.arrayNets[x, y].symbol.ToString(), font, net.arrayNets[x, y].foregroundColor, x * cellWidth, y * cellHeight);
                        }
                        else
                        {
                            g.FillRectangle(net.arrayNets[x, y].foregroundColor, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
                            g.DrawString(net.arrayNets[x, y].symbol.ToString(), font, net.arrayNets[x, y].backgroundColor, x * cellWidth, y * cellHeight);
                        }
                    }
                    else
                    {
                        g.FillRectangle(net.arrayNets[x, y].backgroundColor, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
                        g.DrawString(net.arrayNets[x, y].symbol.ToString(), font, net.arrayNets[x, y].foregroundColor, x * cellWidth, y * cellHeight);
                    }
                }
            }
            pictureBox1.Image = btm;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Palette palette = new Palette();
            palette.Show();
            palette.FormClosed += Change;
        }

        protected void Change(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ChangeBrush();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            string text = comboBox1.Text;
            int x1 = e.X / cellWidth;
            int y1 = e.Y / cellHeight;
            if (x1 >= 0 && x1 <= net.Width && y1 >= 0 && y1 <= net.Height)
            {
                switch (text)
                {
                    case "Линия":
                        if (mousePress)
                        {
                            DrawLine(x0, y0, x1, y1);
                            for (int x = 0; x < width; x++)
                            {
                                for (int y = 0; y < height; y++)
                                {
                                    if (toolLayout[x, y])
                                        net.arrayNets[x, y] = new Cell(DataBank.symbol, DataBank.foregroundColor, DataBank.backgroundColor);
                                }
                            }
                        }
                        break;
                    case "Карандаш":
                        if (mousePress)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                for (int y = 0; y < height; y++)
                                {
                                    if (toolLayout[x, y])
                                        net.arrayNets[x, y] = new Cell(DataBank.symbol, DataBank.foregroundColor, DataBank.backgroundColor);
                                }
                            }
                        }
                        break;
                    case "Ластик":
                        if (mousePress)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                for (int y = 0; y < height; y++)
                                {
                                    if (toolLayout[x, y])
                                        net.arrayNets[x, y] = new Cell((char)32, Brushes.White, Brushes.Black);
                                }
                            }
                        }
                        break;
                    case "Круг":
                        Dyga(x0, y0, x1, y1);
                        for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                                if (toolLayout[x, y])
                                    net.arrayNets[x, y] = new Cell(DataBank.symbol, DataBank.foregroundColor, DataBank.backgroundColor);
                            }
                        }
                        break;
                    case "Прямоугольник":
                        DrawRect(x0, y0, x1, y1);
                        for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                                if (toolLayout[x, y])
                                    net.arrayNets[x, y] = new Cell(DataBank.symbol, DataBank.foregroundColor, DataBank.backgroundColor);
                            }
                        }
                        break;
                }

            }

            Draw(false);
            if (HistoryNet.Count > historyCounter)
            {
                HistoryNet.RemoveRange(historyCounter + 1, HistoryNet.Count - historyCounter - 1);
            }
            HistoryNet.Add(new Net(net));
            if (historyCounter + 1 < 10) historyCounter++;
            if (HistoryNet.Count == 10) { HistoryNet.RemoveAt(0); }
            mousePress = false;
            ClearToolLayout();
           
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string text = comboBox1.Text;
            int x = e.X / cellWidth;
            int y = e.Y / cellHeight;
            if (mousePress)
            {
                switch (text)
                {
                    case "Линия":
                        try
                        {
                        toolLayout[x, y] = true;
                        DrawLine(x0, y0, x, y);
                        DrawBool();
                        ClearToolLayout();
                        }
                        catch { }
                        break;
                    case "Карандаш":
                        DrawLine(x0, y0, x, y);
                        x0 = x;
                        y0 = y;
                        DrawBool();
                        break;
                    case "Ластик":
                        DrawLine(x0, y0, x, y);
                        x0 = x;
                        y0 = y;
                        DrawBool();
                        break;
                    case "Круг":
                        Dyga(x0, y0, x, y);
                        DrawBool();
                        ClearToolLayout();
                        break;
                    case "Прямоугольник":
                        DrawRect(x0, y0, x, y);
                        DrawBool();
                        ClearToolLayout();
                        break;
                }
            }


        }

        void DrawBool()
        {
            if (count++ % 4 == 0)
                Draw(true);
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4;
            SaveDlg.ShowDialog();

            if (SaveDlg.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }
      
        void DrawLine(int x0, int y0, int x1, int y1)
        {
            int deltax = Math.Abs(x1 - x0);
            int deltay = Math.Abs(y1 - y0);
            int signX = Math.Sign(x1 - x0);
            int signY = Math.Sign(y1 - y0);
            int error = deltax - deltay;
            int x = x0;
            int y = y0;
            try
            {
                while (x != x1 || y != y1)
                {
                        toolLayout[x, y] = true;
                        int error2 = error * 2;
                        if (error2 > -deltay)
                        {
                            error -= deltay;
                            x += signX;
                        }
                        if (error2 < deltax)
                        {
                            error += deltax;
                            y += signY;
                        }
                }
            }
            catch
            {

            }

        }


        void Dyga(int x0, int y0, int x1, int y1)
        {
            int x, y, r;
            x = x0 + (x1 - x0) / 2;
            y = y0 + (y1 - y0) / 2;
            r = (y1 - y0) / 2;
            DrawCircle(x, y, r);
        }

        void DrawCircle(int x0, int y0, int radius)
        {
            int x = 0;
            int y = radius;
            int delta = 1 - 2 * radius;
            int error = 0;
            try
            {

                while (y >= 0)
                {
                    toolLayout[x0 + x, y0 + y] = true;
                    toolLayout[x0 + x, y0 - y] = true;
                    toolLayout[x0 - x, y0 + y] = true;
                    toolLayout[x0 - x, y0 - y] = true;
                    error = 2 * (delta + y) - 1;
                    if (delta < 0 && error <= 0)
                    {
                        ++x;
                        delta += 2 * x + 1;
                        continue;
                    }
                    if (delta > 0 && error > 0)
                    {
                        --y;
                        delta += 1 - 2 * y;
                        continue;
                    }
                    ++x;
                    delta += 2 * (x - y);
                    --y;
                }
            }
            catch { }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: сохранитьToolStripMenuItem_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
            CreatingANewCanvas creating = new CreatingANewCanvas();
            creating.Show();
            creating.FormClosed += Create;
        }
        protected void Create(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Creating();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCounter > 0 && HistoryNet.Count>0)
            {
                pictureBox1.Image = null;
                net = HistoryNet[--historyCounter];
            }
            else MessageBox.Show("История пуста");
            Draw(false);
        }

        private void renoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCounter < HistoryNet.Count - 1)
            {
                pictureBox1.Image = null; 
                net = HistoryNet[++historyCounter];
            }
            else MessageBox.Show("История пуста");
            Draw(false);
        }

        void DrawRect(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }
            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }
            try
            {
                for (int i = x1; i <= x2; i++)
                {
                    toolLayout[i, y1] = true;
                    toolLayout[i, y2] = true;
                }
                for (int j = y1; j <= y2; j++)
                {
                    toolLayout[x1, j] = true;
                    toolLayout[x2, j] = true;
                }

            }
            catch { }
        }


    }
}
