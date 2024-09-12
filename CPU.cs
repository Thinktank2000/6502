namespace _6502
{
    public class CPU
    {
        //Internal CPU clock
        public static UInt32 clock;
        public void Initialize(Registers registers, Memory Memory)
        {
            //memory initialisation
            Array.Clear(Memory.memory);

            //register initialisation
            registers.A = 0;
            registers.X = 0;
            registers.Y = 0;

            //PC and SP initialisation (reset vector for PC is at 0xFFFC)
            registers.PC = 0xFFFA;
            registers.SP = 0x0100;

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
            clock = 0;

            //PC is advanced 2 bytes from FFFA and reset vector (FFFC) is set to 0 (start of Zeropage RAM)
            memory.memory[0xFFFC] = 0x0000;
            clock += 2;
            registers.PC += (UInt16)clock;
            registers.PC = memory.memory[0xFFFC];

            //clock is advanced 5 cycles (length of rest of CPU reset sequence)
            clock += 5;
        }
    }
}
