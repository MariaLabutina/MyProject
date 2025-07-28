using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Net
    {
        public int Width;
        public int Height;
        public Cell[,] arrayNets;


        public Net(int width, int height)
        {
            Width = width;
            Height = height;


            arrayNets = new Cell[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    arrayNets[x, y] = new Cell((char)32, Brushes.White, Brushes.Black);
                }
            }

        }
        public Net(Net net)
        {
            Width = net.Width;
            Height = net.Height;


            arrayNets = new Cell[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    arrayNets[x, y] = net.arrayNets[x, y];
                }
            }

        }
    }
}
