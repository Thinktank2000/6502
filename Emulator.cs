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

            //test for inc instruction (barebones)
            instructions.IncrementMemory(memory, registers);

            //test for PHA instruction (Push A to stack)
            registers.A = 10;
            instructions.PushToStack(memory, registers);

            instructions.ReadMemory(memory, registers, 0x0100);
        }
    }
}
