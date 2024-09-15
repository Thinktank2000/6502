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
                memory.ReadBytesIntoMemory(args[0], registers, memory);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No file found");
                Environment.Exit(1);
            }

            //loop through memory for opcodes and execute them
            for (int i = memory.offset; i < 0xFFF9; i++)
            {
                byte currentOpCode = (byte)memory.memory[registers.PC];
                instructions.ExecuteProgram(currentOpCode, memory, registers);

                if (registers.clock >= 1000000)
                {
                    registers.clock = 0;
                }

                if (currentOpCode == 0xFF)
                {
                    break; 
                }
            }

            Debug.ReadRegister(registers, "X");
            Console.WriteLine("End of Program");
        }
    }
}
