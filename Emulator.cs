namespace _6502
{
    public class Emulator
    {
        public static void Main(string[] args)
        {
            //instances
            CPU cpu = new CPU();
            Registers registers = new Registers();
            Memory memory = new Memory();
            Instructions instructions = new Instructions();

            //initialise CPU
            cpu.Initialize(registers, memory);

            //reset cpu
            cpu.ResetCPU(memory, registers);

            //first opcodes laid down
            instructions.ExecuteOpCode(0xE8, memory, registers);

            registers.A = 0xFF;
            instructions.ExecuteOpCode(0x48, memory, registers);

            registers.A = 0x00;
            instructions.ExecuteOpCode(0x68, memory, registers);

            instructions.ReadMemory(memory, registers, 0x0100);
            ReadAllRegisters(registers, instructions);
        }

        static void ReadAllRegisters(Registers registers, Instructions instructions)
        {
            instructions.ReadRegister(registers, "A");
            instructions.ReadRegister(registers, "X");
            instructions.ReadRegister(registers, "Y");
            instructions.ReadRegister(registers, "PC");
            instructions.ReadRegister(registers, "SP");
        }
    }
}
