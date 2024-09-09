namespace _6502
{
    public class CPU
    {
        public void Initialize(Registers registers, Memory Memory)
        {
            //register initialisation
            registers.A = 0;
            registers.X = 0;
            registers.Y = 0;

            //PC and SP initialisation (reset vector for PC is at 0xFFFC)
            registers.PC = 0xFFFC;
            registers.SP = 0x00;

            //status flags initialisation
            registers.N = false;
            registers.V = false;
            registers.B = false;
            registers.D = false;
            registers.I = false;
            registers.Z = false;
            registers.C = false;

            //memory initialisation
            Array.Clear(Memory.memory);
        }
    }
}
