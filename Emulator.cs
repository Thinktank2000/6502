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
            AddressingModes addressingModes = new AddressingModes();

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
                Console.WriteLine("Exit code 1");
                Environment.Exit(1);
            }

            //loop through memory for opcodes and execute them
            for (int i = memory.offset; i < 0xFFF9; i++)
            {
                Debug.DisplayAllRegisters(registers);
                Thread.Sleep(1000);
                Console.Clear();

                byte currentOpCode = (byte)memory.memory[registers.PC];
                instructions.ExecuteProgram(currentOpCode, addressingModes ,memory, registers);

                Console.WriteLine("The current Opcode is: {0:X2}", currentOpCode);
                Debug.ReadMemory(memory, registers, memory.memoryLocation);

                if (registers.clock >= 1000000)
                {
                    registers.clock = 0;
                }

                if (currentOpCode == 0xFF)
                {
                    break; 
                }
            }

            Debug.DisplayAllRegisters(registers);
            Console.WriteLine("End of Program");
            Console.WriteLine("Exit code 0");
        }
    }
}
