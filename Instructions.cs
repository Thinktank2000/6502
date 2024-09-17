namespace _6502
{
    public class Instructions
    {
        #region increment and decrement instructions
        public void INCzp(Memory memory, Registers registers, AddressingModes addressingModes)
        {
            memory.ChangeMemoryByOne(addressingModes, false, registers, memory);
            CPU.IncrementCycleCount(registers, 5);
        }

        public void INX(Registers registers)
        {
            registers.X++;
            registers.PC++;
            CPU.IncrementCycleCount(registers, 2);

            if (registers.X < 0)
            {
                registers.N = true;
            }

            else if (registers.X == 0)
            {
                registers.Z = true;
            }
        }

        public void INY(Registers registers)
        {
            registers.Y++;
            registers.PC++;
            CPU.IncrementCycleCount(registers, 2);

            if (registers.Y < 0)
            {
                registers.N = true;
            }

            else if (registers.Y == 0)
            {
                registers.Z = true;
            }
        }
        #endregion

        #region stack instructions
        public void PHA(Memory memory, Registers registers)
        {
            registers.SP++;
            memory.memory[registers.SP] = registers.A;
            registers.PC++;
            CPU.IncrementCycleCount(registers, 3);

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
            CPU.IncrementCycleCount(registers, 4);

            if (registers.SP > 0)
            {
                registers.N = true;
            }

            else if (registers.SP == 0)
            {
                registers.Z = true;
            }
        }
        #endregion

        #region No operation
        public void NOP(Registers registers)
        {
            registers.PC++;
            CPU.IncrementCycleCount(registers, 2);   
        }
        #endregion

        #region data load and store instructions
        public void LDAImm(Memory memory, Registers registers)
        {
            registers.A = memory.ReadMemoryValue(registers.PC += 1, registers);
        }

        public void LDAzp(Memory memory, Registers registers, AddressingModes addressingModes)
        {
            registers.A = memory.ReadMemoryValue(memory.GetAddressByAddressingMode(AddressingModes.ZeroPage, registers), registers);
        }

        public void LDXImm(Memory memory, Registers registers)
        {
            registers.X = memory.ReadMemoryValue(registers.PC += 1, registers);
        }

        public void LDYImm(Memory memory, Registers registers)
        {
            registers.Y = memory.ReadMemoryValue(registers.PC += 1, registers);
        }

        public void STAzp(Memory memory, Registers registers, AddressingModes addressingModes)
        {
            memory.WriteMemoryValue(memory.GetAddressByAddressingMode(AddressingModes.ZeroPage, registers), registers.A, registers);
        }

        public void STXzp(Memory memory, Registers registers, AddressingModes addressingModes)
        {
            memory.WriteMemoryValue(memory.GetAddressByAddressingMode(AddressingModes.ZeroPage, registers), registers.X, registers);
        }

        public void STYzp(Memory memory, Registers registers, AddressingModes addressingModes)
        {
            memory.WriteMemoryValue(memory.GetAddressByAddressingMode(AddressingModes.ZeroPage, registers), registers.Y, registers);
        }

        public void TAX(Memory memory, Registers registers)
        {
            registers.X = registers.A;
            registers.A = 0;
            registers.PC++;
            CPU.IncrementCycleCount(registers, 2);

            if (registers.X < 0)
            {
                registers.N = true;
            }

            if (registers.X == 0)
            {
                registers.Z = true;
            }
        }
        #endregion

        //basic function to recognize processor opcodes and execute the relevant instruction
        public void ExecuteOpCode(byte opcode, AddressingModes addressingModes, Memory memory, Registers registers)
        {
            switch (opcode)
            {
                case 0xAA:
                    TAX(memory, registers);
                    break;

                case 0xE6:
                    INCzp(memory, registers, addressingModes);
                    break;

                case 0xC8:
                    INY(registers); 
                    break;

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
                    CPU.IncrementCycleCount(registers, 7);
                    break;

                case 0xF0:
                    //BEQ(registers, memory);
                    break;

                //exit program opcode (no associated instruction)
                case 0xFF:
                    break;

                case 0xA9:
                    LDAImm(memory, registers);
                    registers.PC++;
                    break;

                case 0xA5:
                    LDAzp(memory, registers, addressingModes);
                    registers.PC++;
                    break;

                case 0xA2:
                    LDXImm(memory, registers);
                    registers.PC++;
                    break;

                case 0xA0:
                    LDYImm(memory, registers);
                    registers.PC++;
                    break;

                case 0x85:
                    STAzp(memory, registers, addressingModes);
                    registers.PC++;
                    break;

                case 0x86:
                    STXzp(memory, registers, addressingModes);
                    registers.PC++;
                    break;

                case 0x84:
                    STYzp(memory, registers, addressingModes);
                    registers.PC++;
                    break;

                default:
                    registers.PC++;
                    CPU.IncrementCycleCount(registers, 1);    
                    break;
            }
        }

        public void ExecuteProgram(byte opcode, AddressingModes addressingModes, Memory memory, Registers registers)
        {
            ExecuteOpCode(opcode, addressingModes, memory, registers);
        }
    }
}
