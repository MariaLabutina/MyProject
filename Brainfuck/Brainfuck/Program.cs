using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck
{
    class Program
    {
        static string text;
        public static int i;
        public static int j;
        public static int b;
        static async Task Main(string[] args)
        {
            i = 0;
            j = 0;
            b = 0;
            char[] array = new char[100];
            string path = "C:/Users/User/Desktop/жизнь/программист новичек/Brainfuck/Brainfuck/comand.txt";
            // асинхронное чтение
            using (StreamReader reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
                Console.WriteLine(text);
            }
            while(j < text.Length)
            {
                Command(text,  array);
                j++;
            }
            Console.ReadKey();
        }


        static void Command(string text, char[] array)
        {
            switch (text[j])
            {
                case '>':
                    i++;
                    break;
                case '<':
                    i--;
                    break;
                case '+':
                    array[i]++;
                    break;
                case '-':
                    array[i]--;
                    break;
                case '.':
                    Console.Write(array[i]);
                    break;
                case ',':
                    array[i] = Console.ReadKey().KeyChar;
                    break;
                case '[':
                    if (array[i] != 0) { break; }
                    else
                    {
                        b++;
                        while (b != 0)
                        {
                            j++;
                            switch (text[j])
                            {
                                case '[': b++; break;
                                case ']': b--; break;
                            }
                        }
                    }
                    break;
                case ']':
                    if (array[i] == 0) { break; }
                    else
                    {
                        b++;
                        while (b != 0)
                        {
                            j--;
                            switch (text[j])
                            {
                                case '[': b--; break;
                                case ']': b++; break;
                            }
                        }
                        j--;
                    }
                    break;
                default:
                    j++;
                    break;
            }
        }
    }
}
