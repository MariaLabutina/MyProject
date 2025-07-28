using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chip8
{
    public class Monitor:RenderWindow
    {
        RectangleShape rect;
        public Monitor():base(new VideoMode(640,320), "Chip-8")
        {
            Closed += (hendler, e) => { Close(); };
            rect = new RectangleShape(new Vector2f(10f,10f));
        }

        public void Print(Byte[] array)
        {
            Clear();
            for(int i=0; i<64; i++)
            {
                for(int j=0; j<32; j++)
                {
                    if (array[j*64+i] != 0)
                    {
                        rect.Position = new Vector2f(i * 10, j * 10);
                        Draw(rect);
                    }
                }
               
            }
            Display();
        }
    }
    
}
