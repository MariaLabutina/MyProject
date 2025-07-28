using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class Program
    {
        static void Main(string[] args) 
        {
            byte[] prog = File.ReadAllBytes(args[0]);
            Monitor monitor = new Monitor();
            VM vm = new VM(monitor, prog);

            Clock clock = new Clock();
            long dt = 0;
            while (monitor.IsOpen)
            {
                dt += clock.ElapsedTime.AsMicroseconds();
                clock.Restart();

                monitor.DispatchEvents();
                if (dt > 1666)
                {
                    vm.Tick();
                    dt = 0;
                }
                
            }
        }
    }
}
