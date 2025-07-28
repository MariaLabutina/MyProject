using System;
using SFML.Window;

namespace Chip8
{
    class VM
    {

        private byte[] Fonts =        {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
            0x20, 0x60, 0x20, 0x20, 0x70, // 1
            0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
            0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
            0x90, 0x90, 0xF0, 0x10, 0x10, // 4
            0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
            0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
            0xF0, 0x10, 0x20, 0x40, 0x40, // 7
            0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
            0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
            0xF0, 0x90, 0xF0, 0x90, 0x90, // A
            0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
            0xF0, 0x80, 0x80, 0x80, 0xF0, // C
            0xE0, 0x90, 0x90, 0x90, 0xE0, // D
            0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
            0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };
        private Byte[] v;//регистры
        private Byte[] memory;//память
        private Byte[] graficMemory;//хранится изображение
        private ushort I;//адресный регистр
        private ushort pc;//счетчик программы
        private ushort[] stack;//стек
        private Byte sp;//указатель на стек
        private ushort opcode;//текущая команда
        private Byte dt;//таймер задержки
        private Byte st;//таймер звука
        private bool[] keys;//массив клавиш
        private Monitor monitor;

        public VM(Monitor monitor, Byte[] prog)
        {
            this.monitor = monitor;
            v = new Byte[16];
            memory = new Byte[4906];
            graficMemory = new Byte[64 * 32];
            I = 0;
            pc = 0x200;
            stack = new ushort[12];
            sp = 0;
            opcode = 0;
            dt = 0;
            st = 0;
            keys = new bool[16];
            prog.CopyTo(memory, 0x200);
            Fonts.CopyTo(memory, 0);
        }

        private void UpdateKeyboard()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num1))
                keys[0x1] = true;
            else
                keys[0x1] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num2))
                keys[0x2] = true;
            else
                keys[0x2] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num3))
                keys[0x3] = true;
            else
                keys[0x3] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num4))
                keys[0xC] = true;
            else
                keys[0xC] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                keys[0x4] = true;
            else
                keys[0x4] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                keys[0x5] = true;
            else
                keys[0x5] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                keys[0x6] = true;
            else
                keys[0x6] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                keys[0xD] = true;
            else
                keys[0xD] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                keys[0x7] = true;
            else
                keys[0x7] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                keys[0x8] = true;
            else
                keys[0x8] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                keys[0x9] = true;
            else
                keys[0x9] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
                keys[0xE] = true;
            else
                keys[0xE] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
                keys[0xA] = true;
            else
                keys[0xA] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                keys[0x0] = true;
            else
                keys[0x0] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.C))
                keys[0xB] = true;
            else
                keys[0xB] = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.V))
                keys[0xF] = true;
            else
                keys[0xF] = false;
        }
        public void Tick()
        {
            opcode = (ushort)(memory[pc] << 8 | memory[pc + 1]);
            pc += 2;
            ushort nnn = (ushort)(opcode & 0x0FFF);
            Byte kk = (Byte)(opcode & 0x00FF);
            Byte n = (Byte)(opcode & 0x000F);
            Byte x = (Byte)((opcode & 0x0F00) >> 8);
            Byte y = (Byte)((opcode & 0x00F0) >> 4);

            UpdateKeyboard();
            switch (opcode & 0xF000)
            {
                case 0x0000 when opcode == 0x00E0:
                    Opcode_00E0();
                    break;
                case 0x0000 when opcode == 0x00EE:
                    Opcode_00EE();
                    break;
                case 0x0000:
                    Opcode_0nnn(nnn);
                    break;
                case 0x1000:
                    Opcode_1nnn(nnn);
                    break;
                case 0x2000:
                    Opcode_2nnn(nnn);
                    break;
                case 0x3000:
                    Opcode_3xkk(x, kk);
                    break;
                case 0x4000:
                    Opcode_4xkk(x, kk);
                    break;
                case 0x5000:
                    Opcode_5xy0(x, y);
                    break;
                case 0x6000:
                    Opcode_6xkk(x, kk);
                    break;
                case 0x7000:
                    Opcode_7xkk(x, kk);
                    break;
                case 0x8000 when n == 0:
                    Opcode_8xy0(x, y);
                    break;
                case 0x8000 when n == 1:
                    Opcode_8xy1(x, y);
                    break;
                case 0x8000 when n == 2:
                    Opcode_8xy2(x, y);
                    break;
                case 0x8000 when n == 3:
                    Opcode_8xy3(x, y);
                    break;
                case 0x8000 when n == 4:
                    Opcode_8xy4(x, y);
                    break;
                case 0x8000 when n == 5:
                    Opcode_8xy5(x, y);
                    break;
                case 0x8000 when n == 6:
                    Opcode_8xy6(x, y);
                    break;
                case 0x8000 when n == 7:
                    Opcode_8xy7(x, y);
                    break;
                case 0x8000 when n == 0xE:
                    Opcode_8xyE(x, y);
                    break;
                case 0x9000:
                    Opcode_9xy0(x, y);
                    break;
                case 0xA000:
                    Opcode_Annn(nnn);
                    break;
                case 0xB000:
                    Opcode_Bnnn(nnn);
                    break;
                case 0xC000:
                    Opcode_Cxkk(x, kk);
                    break;
                case 0xD000:
                    Opcode_Dxyn(x, y, n);
                    break;
                case 0xE000 when n == 0xE:
                    Opcode_Ex9E(x);
                    break;
                case 0xE000 when n == 1:
                    Opcode_ExA1(x);
                    break;
                case 0xF000 when kk == 7:
                    Opcode_Fx07(x);
                    break;
                case 0xF000 when kk == 0xA:
                    Opcode_Fx0A(x);
                    break;
                case 0xF000 when kk == 0x15:
                    Opcode_Fx15(x);
                    break;
                case 0xF000 when kk == 0x18:
                    Opcode_Fx18(x);
                    break;
                case 0xF000 when kk == 0x1E:
                    Opcode_Fx1E(x);
                    break;
                case 0xF000 when kk == 0x29:
                    Opcode_Fx29(x);
                    break;
                case 0xF000 when kk == 0x33:
                    Opcode_Fx33(x);
                    break;
                case 0xF000 when kk == 0x55:
                    Opcode_Fx55(x);
                    break;
                case 0xF000 when kk == 0x65:
                    Opcode_Fx65(x);
                    break;
            }
            if (dt > 0)
            {
                dt--;
            }
        }
        //очистить дисплей
        void Opcode_00E0()
        {
            graficMemory = new Byte[64 * 32];
        }
        //возврат из подпрограммы
        void Opcode_00EE()
        {
            sp--;
            pc = stack[sp];
        }
        //переход к процедуре машинного кода по адресу
        void Opcode_0nnn(ushort nnn)
        {
            pc = nnn;
        }
        //переход по адресу
        void Opcode_1nnn(ushort nnn)
        {
            pc = nnn;
        }
        //вызов подпрограммы
        void Opcode_2nnn(ushort nnn)
        {
            stack[sp] = pc;
            pc = nnn;
            sp++;
        }
        //Пропустить следующую инструкцию, если V[x] = kk
        void Opcode_3xkk(Byte x, Byte kk)
        {
            if (v[x] == kk)
            {
                pc += 2;
            }
        }
        //Пропустить следующую инструкцию, если V[x] != kk
        void Opcode_4xkk(Byte x, Byte kk)
        {
            if (v[x] != kk)
            {
                pc += 2;
            }
        }
        //Пропустить следующую инструкцию, если V[x] = V[y]
        void Opcode_5xy0(Byte x, Byte y)
        {
            if (v[x] == v[y])
            {
                pc += 2;
            }
        }
        //Установить V[x] = kk
        void Opcode_6xkk(Byte x, Byte kk)
        {
            v[x] = kk;
        }
        //Прибавить kk к V[x]
        void Opcode_7xkk(Byte x, Byte kk)
        {
            v[x] += kk;
        }
        //Установить V[x] = V[y]
        void Opcode_8xy0(Byte x, Byte y)
        {
            v[x] = v[y];
        }
        //Установить V[x] = V[x] OR V[y]
        void Opcode_8xy1(Byte x, Byte y)
        {
            v[x] = (Byte)(v[x] | v[y]);
        }
        //Установить V[x] = V[x] AND V[y]
        void Opcode_8xy2(Byte x, Byte y)
        {
            v[x] = (Byte)(v[x] & v[y]);
        }
        //Установить V[x] = V[x] X OR V[y]
        void Opcode_8xy3(Byte x, Byte y)
        {
            v[x] = (Byte)(v[x] ^ v[y]);
        }
        //Прибавить V[y] к V[x], бит переноса в V[F]
        void Opcode_8xy4(Byte x, Byte y)
        {
            if (v[y] > 255 - v[x])
            {
                v[15] = 1;
            }
            else
            {
                v[15] = 0;
            }
            v[x] += v[y];
        }
        //Вычесть V[y] из V[x], без переноса
        void Opcode_8xy5(Byte x, Byte y)
        {
            if (v[y] > v[x])
            {
                v[15] = 0;
            }
            else
            {
                v[15] = 1;
            }
            v[x] -= v[y];
        }
        //Сдвиг V[x] вправо на 1
        void Opcode_8xy6(Byte x, Byte y)
        {
            v[15] = (Byte)(v[x] & 1);
            v[x] = (Byte)(v[x] >> 1);
        }
        //Вычесть V[x] из V[y], без переноса
        void Opcode_8xy7(Byte x, Byte y)
        {
            if (v[x] > v[y])
            {
                v[15] = 0;
            }
            else
            {
                v[15] = 1;
            }
            v[x] = (Byte)(v[y] - v[x]);
        }
        //Сдвиг V[x] влево на 1
        void Opcode_8xyE(Byte x, Byte y)
        {
            v[15] = (Byte)(v[x] & 0x80 >> 7);
            v[x] = (Byte)(v[x] << 1);
        }
        //Пропустить следующую инструкцию, если V[x] != V[y].
        void Opcode_9xy0(Byte x, Byte y)
        {
            if (v[x] != v[y])
            {
                pc += 2;
            }
        }
        //Установить I = nnn
        void Opcode_Annn(ushort nnn)
        {
            I = nnn;
        }
        //Перейдите по адресу nnn + V[0]
        void Opcode_Bnnn(ushort nnn)
        {
            pc = (ushort)(nnn + v[0]);
        }
        //Установить V[x] = Random b[y]te AND kk
        void Opcode_Cxkk(Byte x, Byte kk)
        {
            Random rnd = new Random();
            v[x] = (Byte)(rnd.Next(0, 256) & kk);
        }
        //Отобразить n-байтовый спрайт, начиная с ячейки памяти I в позицию (V[x], V[y]), установите VF = коллизия.
        void Opcode_Dxyn(Byte x, Byte y, Byte n)
        {
            v[15] = 0;
            for (int i = 0; i < n; i++)
            {
                int y1 = (v[y] + i) % 32;
                Byte sprait = memory[I + i];
                for (int j = 0; j < 8; j++)
                {
                    if ((sprait & 0x80) != 0)
                    {
                        int x1 = (v[x] + j) % 64;
                        if (graficMemory[y1 * 64 + x1] == 1)
                        {
                            v[15] = 1;
                        }
                        graficMemory[y1 * 64 + x1] ^= 1;
                    }
                    sprait <<= 1;
                }
            }
            monitor.Print(graficMemory);
        }
        //Пропустить следующую инструкцию, если нажата клавиша со значением V[x].
        void Opcode_Ex9E(Byte x)
        {
            if (keys[v[x]])
            {
                pc += 2;
            }
        }
        //Пропустить следующую инструкцию, если не нажата клавиша со значением V[x].
        void Opcode_ExA1(Byte x)
        {
            if (!keys[v[x]])
            {
                pc += 2;
            }
        }
        //Установить V[x] = значение таймера задержки
        void Opcode_Fx07(Byte x)
        {
            v[x] = dt;
        }
        //Ожидать нажатия клавиши, сохранить значение клавиши в V[x].
        void Opcode_Fx0A(Byte x)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i])
                {
                    v[x] = (Byte)i;
                    return;
                }
            }
            pc -= 2;
        }
        //Установить таймер задержки = V[x].
        void Opcode_Fx15(Byte x)
        {
            dt = v[x];
        }
        //Установить звуковой таймер = V[x].
        void Opcode_Fx18(Byte x)
        {
            st = v[x];
        }
        //Установить I = I + V[x].
        void Opcode_Fx1E(Byte x)
        {
            I = (ushort)(I + v[x]);
        }
        //Установить I = местоположение спрайта для цифры V[x]
        void Opcode_Fx29(Byte x)
        {
            I = (ushort)(v[x] * 5);
        }
        //Сохранить BCD-представление V[x] в ячейках памяти I, I+1 и I+2.
        void Opcode_Fx33(Byte x)
        {
            memory[I] = (Byte)(v[x] / 100);
            memory[I + 1] = (Byte)((v[x] % 100) / 10);
            memory[I + 2] = (Byte)(v[x] % 10);
        }
        //Сохранить регистры V0–V[x] в памяти, начиная с ячейки I
        void Opcode_Fx55(Byte x)
        {
            for (int i = 0; i <= x; i++)
            {
                memory[I + i] = v[i];
            }
        }
        //Считать регистры V0–V[x] из памяти, начиная с ячейки I.
        void Opcode_Fx65(Byte x)
        {
            for (int i = 0; i <= x; i++)
            {
                v[i] = memory[I + i];
            }
        }
    }
}
