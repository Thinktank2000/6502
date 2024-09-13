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

        public void NOP(Registers registers)
        {
            registers.PC++;
            registers.Clock += 2;
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

                case 0xEA:
                    NOP(registers);
                    break;
            }
        }
    }
}
