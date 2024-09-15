namespace _6502
{
    public static class Debug
    {
        public static void ReadMemory(Memory memory, Registers registers, int memoryAddress)
        {
            Console.WriteLine("Value at Memory address: 0x{0:X} = 0x{1:X4}", memoryAddress, memory.memory[memoryAddress]);
        }

        public static void ReadRegister(Registers registers, string register)
        {
            switch (register)
            {
                case "A":
                    Console.WriteLine("The value in the register: A is 0x{0:X2}", registers.A);
                    break;

                case "X":
                    Console.WriteLine("The value in the register: X is 0x{0:X2}", registers.X);
                    break;

                case "Y":
                    Console.WriteLine("The value in the register: Y is 0x{0:X2}", registers.Y);
                    break;

                case "PC":
                    Console.WriteLine("The location of the Program Counter is 0x{0:X4}", registers.PC);
                    break;

                case "SP":
                    Console.WriteLine("The location of the Stack Pointer is 0x{0:X4}", registers.SP);
                    break;

                case "Clock":
                    Console.WriteLine("The current clock cycle is {0}Hz/1MHz", registers.clock);
                    break;

                default:
                    Console.WriteLine("Register not recognized");
                    break;
            }
        }

        public static UInt16 CurrentStackAddr(Registers registers)
        {
            return registers.SP;
        }

        public static void HexDump(Memory memory)
        {
            var numberOfRows = 500;
            var numberOfCols = 16;
            for (var currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (var currentCol = 0; currentCol < numberOfCols; currentCol++)
                {
                    Console.Write("{0:X2}, {1:X2}", currentRow, currentCol);
                }
                Console.WriteLine();
            }
        }
    }
}
