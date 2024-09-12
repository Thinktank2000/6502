namespace _6502
{
    public class Instructions
    {
        //debug method for INC instruction
        public void IncrementMemory(Memory memory, Registers registers)
        {
            registers.PC += 2;
            memory.memory[registers.PC] += 1;
            CPU.clock += 5;
        }

        //debug method for PHA instruction (push A to stack)
        public void PushToStack(Memory memory, Registers registers)
        {
            memory.memory[registers.SP] = registers.A;
            registers.SP += 1;
            registers.PC += 1;
            CPU.clock += 3;

            if (registers.SP > 0)
            {
                registers.N = true;
            }

            else if (registers.SP == 0)
            {
                registers.Z = true;
            }
        }

        public void ReadMemory(Memory memory, Registers registers, int memoryAddress)
        {
            Console.WriteLine("Value at Memory address: 0x{0:X} = {1}", memoryAddress, memory.memory[memoryAddress]);
        }
    }
}
