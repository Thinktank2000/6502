namespace _6502
{
    public class Instructions
    { 
        //method for INX instruction
        public void INX(Registers registers)
        {
            registers.X++;
            registers.PC++;
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
            registers.SP++;
            memory.memory[registers.SP] = registers.A;
            registers.PC++;
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

        //method for PLA instruction (Pull A from stack)
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

        //method for NOP instruction (No Operation)
        public void NOP(Registers registers)
        {
            registers.PC++;
            registers.Clock += 2;
        }

        //basic function to recognize processor opcodes and execute the relevant instruction
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

                case 0xEA:
                    NOP(registers);
                    break;

                //implement interrupts later (BRK)
                case 0x00:
                    registers.PC++;
                    break;

                default:
                    Console.WriteLine("Invalid Opcode detected");
                    Environment.Exit(0);
                    break;
            }
        }

        public void ExecuteProgram(byte opcode, Memory memory, Registers registers)
        {
            ExecuteOpCode(opcode, memory, registers);
        }
    }
}
