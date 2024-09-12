namespace _6502
{
    public class Instructions
    {
        //method for INX instruction
        public void INX(Registers registers)
        {
            registers.PC += 1;
            registers.X++;
            registers.Clock += 2;

            if (registers.X < 0)
            {
                registers.N = true;
            }

            else if (registers.X == 0)
            {
                registers.Z = true;
            }
        }

        //method for PHA instruction (push A to stack)
        public void PHA(Memory memory, Registers registers)
        {
            registers.SP += 1;
            memory.memory[registers.SP] = registers.A;
            registers.PC += 1;
            registers.Clock += 3;

            if (registers.SP > 0)
            {
                registers.N = true;
            }

            else if (registers.SP == 0)
            {
                registers.Z = true;
            }
        }

        public void PLA(Memory memory, Registers registers)
        {
            registers.A = (byte)memory.memory[registers.SP];
            registers.SP--;
            registers.PC++;
            registers.Clock += 4;

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

        public void ReadRegister(Registers registers, string register)
        {
           switch(register)
            {
                case "A":
                    Console.WriteLine("The value in the register: A is {0}", registers.A);
                    break;

                case "X":
                    Console.WriteLine("The value in the register: X is {0}", registers.X);
                    break;

                case "Y":
                    Console.WriteLine("The value in the register: Y is {0}", registers.Y);
                    break;

                case "PC":
                    Console.WriteLine("The location of the Program Counter is {0:X}", registers.PC);
                    break;

                case "SP":
                    Console.WriteLine("The location of the Stack Pointer is {0:X}", registers.SP);
                    break;

                default:
                    Console.WriteLine("Register not recognized");
                    break;
            }
        }

        public void ExecuteOpCode(byte opcode, Memory memory, Registers registers)
        {
            switch (opcode)
            {
                case 0xE8:
                    INX(registers);
                    break;

                case 0x48:
                    PHA(memory, registers);
                    break;

                case 0x68:
                    PLA(memory, registers);
                    break;
            }
        }
    }
}
