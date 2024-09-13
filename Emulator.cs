namespace _6502
{
    public class Emulator
    {
        public static void Main(string[] args)
        {
            //object instances
            CPU cpu = new CPU();
            Registers registers = new Registers();
            Memory memory = new Memory();
            Instructions instructions = new Instructions();

            //initialise CPU
            cpu.Initialize(registers, memory);

            //reset cpu
            cpu.ResetCPU(memory, registers);

            //load program into memory
            memory.ReadBytesIntoMemory(args[0]);

            //check if reading worked
            for (int i = 0; i < 10; i++)
            {
                Debug.ReadMemory(memory, registers, registers.PC);
                registers.PC++;
            }
            
        }
    }
}
