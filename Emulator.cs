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

            try
            {
                //load program into memory
                memory.ReadBytesIntoMemory(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No file found");
                Environment.Exit(1);
            }   

            //loop through memory for opcodes and execute them
            for (int i = 0x0200; i < 0xFFF9; i++)
            {
                byte currentOpCode = (byte)memory.memory[i];
                instructions.ExecuteProgram(currentOpCode ,memory, registers);
            }

            Console.WriteLine("End of Program");
        }
    }
}
