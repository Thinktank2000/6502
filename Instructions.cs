namespace _6502
{
    public class Instructions
    { 
        //method for INX instruction
        public void INX(Registers registers)
        {
            registers.X++;
            registers.PC++;
            registers.clock += 2;

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
            registers.clock += 3;

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
            registers.clock += 4;

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
            registers.clock += 2;
        }

        //branch if equals to zero (127 bytes either way)
        /*
        public void BEQ(Registers registers, Memory memory)
        {
            if (registers.Z == true)
            {
                byte hiByte = (byte)(memory.memory[registers.PC + 0x02]);
                byte loByte = (byte)(memory.memory[registers.PC + 0x01]);

                string hiByteString = hiByte.ToString("X2");
                string loByteString = loByte.ToString("X2");

                string finalAddrString = (hiByteString + loByteString);

                Console.WriteLine(finalAddrString);

                UInt16 finalAddr = UInt16.Parse(finalAddrString, System.Globalization.NumberStyles.HexNumber);

                Console.WriteLine(finalAddr);

                if (finalAddr - registers.PC <= 0x7F)
                {
                    registers.PC = finalAddr;
                    Console.WriteLine(registers.PC);
                    registers.clock += 2;
                }

                else
                {
                    Console.WriteLine("Out of Range");
                    Environment.Exit(1);
                }
            }

            else
            {
                registers.PC += 2;
                registers.clock += 2;
            }
        }
        */

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
                    registers.clock += 7;
                    break;

                case 0xF0:
                    //BEQ(registers, memory);
                    break;

                case 0xFF:
                    break;

                default:
                    registers.PC++;
                    break;
            }
        }

        public void ExecuteProgram(byte opcode, Memory memory, Registers registers)
        {
            ExecuteOpCode(opcode, memory, registers);
        }
    }
}
