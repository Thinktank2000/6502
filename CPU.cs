using System;

namespace _6502
{
    public class CPU
    {
        public void Initialize(Registers registers, Memory memory)
        {

            ClearMemory(memory);

            //register initialisation
            registers.A = 0;
            registers.X = 0;
            registers.Y = 0;

            //PC and SP initialisation (reset vector for PC is at 0xFFFC)
            registers.PC = 0xFFFA;
            registers.SP = 0x0100;

            registers.clock = 0x00;

            //status flags initialisation
            registers.N = false;
            registers.V = false;
            registers.B = false;
            registers.D = false;
            registers.I = false;
            registers.Z = false;
            registers.C = false;
        }

        public void ResetCPU(Memory memory, Registers registers)
        {
            //CPU clock is reset to 0
            registers.clock = 0;

            //PC is advanced 2 bytes from FFFA and reset vector (FFFC) is set to 0x0200 (start of general purpose RAM)
            registers.PC += 2;
            memory.memory[0xFFFC] = memory.memory[memory.offset];
            registers.PC = memory.memory[0xFFFC];
            registers.clock += 2;

            //clock is advanced 5 cycles (length of rest of CPU reset sequence)
            registers.clock += 5;
        }

        public static int IncrementCycleCount(Registers registers, int cycles)
        {
            registers.clock += cycles;
            return registers.clock;
        }

        private static void ClearMemory(Memory memory)
        {
            //memory initialisation
            for (int i = 0; i < 0xFFFF; i++)
            {
                memory.memory[i] = 0x00;
            }
        }

    }
}
