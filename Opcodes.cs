namespace _6502
{
    public class Opcodes
    {
        public static string OpcodeConverter(byte opcode)
        {
            switch(opcode)
            {
                //arithmetic instructions
                //Add with Carry
                case 0x69:
                case 0x65:
                case 0x75:
                case 0x6D:
                case 0x7D:
                case 0x79:
                case 0x61:
                case 0x71:
                    return "ADC";
                
                //Subtract with Borrow
                case 0xE9:
                case 0xE5:
                case 0xF5:
                case 0xED:
                case 0xFD:
                case 0xF9:
                case 0xE1:
                case 0xF1:
                    return "SBC";

                //logical instructions
                //Logical AND
                case 0x29:
                case 0x25:
                case 0x35:
                case 0x2D:
                case 0x3D:
                case 0x39:
                case 0x21:
                case 0x31:
                    return "AND";

                //logical OR
                case 0x09:
                case 0x05:
                case 0x15:
                case 0x0D:
                case 0x1D:
                case 0x19:
                case 0x01:
                case 0x11:
                    return "ORA";

                //logical XOR (EOR)
                case 0x49:
                case 0x45:
                case 0x55:
                case 0x4D:
                case 0x5D:
                case 0x59:
                case 0x41:
                case 0x51:
                    return "EOR";

                //shift and rotate instructions
                //arithmetic shift left
                case 0x0A:
                case 0x06:
                case 0x16:
                case 0x0E:
                case 0x1E:
                    return "ASL";

                //Logical Shift Right
                case 0x4A:
                case 0x46:
                case 0x56:
                case 0x4E:
                case 0x5E:
                    return "LSR";

                //Rotate Left
                case 0x2A:
                case 0x26:
                case 0x36:
                case 0x2E:
                case 0x3E:
                    return "ROL";

                //Rotate Right
                case 0x6A:
                case 0x66:
                case 0x76:
                case 0x6E:
                case 0x7E:
                    return "ROL";

                //Flag manipulation instructions
                //clear carry flag
                case 0x18:
                    return "CLC";

                //clear decimal mode flag
                case 0xD8:
                    return "CLD";

                //clear interrupt disable flag
                case 0x58:
                    return "CLI";

                //clear overflow flag
                case 0xB8:
                    return "CLV";

                //set carry flag
                case 0x38:
                    return "SEC";

                //set decimal enable flag
                case 0xF8:
                    return "SED";

                //set interrupt disable flag
                case 0x78:
                    return "SEI";

                //Load/Store/Transfer instructions
                //Load Accumulator
                case 0xA9:
                case 0xA5:
                case 0xB5:
                case 0xAD:
                case 0xBD:
                case 0xB9:
                case 0xA1:
                case 0xB1:
                    return "LDA";

                //Load X index register
                case 0xA2:
                case 0xA6:
                case 0xB6:
                case 0xAE:
                case 0xBE:
                    return "LDX";

                //load Y index register
                case 0xA0:
                case 0xA4:
                case 0xB4:
                case 0xAC:
                case 0xBC:
                    return "LDY";

                //Store Accumulator in memory
                case 0x85:
                case 0x95:
                case 0x8D:
                case 0x9D:
                case 0x99:
                case 0x81:
                case 0x91:
                    return "STA";

                //Store index X register in memory
                case 0x86:
                case 0x96:
                case 0x8E:
                    return "STX";

                //Store index Y register in memory
                case 0x84:
                case 0x94:
                case 0x8C:
                    return "STY";

                //Transfer Accumulator to X
                case 0xAA:
                    return "TAX";

                //Transfer Accumulator to Y
                case 0xA8:
                    return "TAY";

                //Transfer Stack Pointer to X
                case 0xBA:
                    return "TSX";

                //Transfer X to Accumulator
                case 0x8A:
                    return "TXA";

                //Transfer X to Stack Pointer register
                case 0x9A:
                    return "TXS";

                //Transfer Y to Accumulator
                case 0x98:
                    return "TYA";

                //stack manipulation instructions
                //Push Accumulator to Stack
                case 0x48:
                    return "PHA";

                //Push Flags register to stack
                case 0x08:
                    return "PHP";

                //Pull accumulator from stack
                case 0x68:
                    return "PLA";

                //Pull Flags register from stack
                case 0x28:
                    return "PLP";

                //decrement and increment instructions
                //Decrement memory by one
                case 0xC6:
                case 0xD6:
                case 0xCE:
                case 0xDE:
                    return "DEC";

                //Decrement X by one
                case 0xCA:
                    return "DEX";

                //Decrement Y by one
                case 0x88:
                    return "DEY";

                //Increment memory by one
                case 0xE6:
                case 0xF6:
                case 0xEE:
                case 0xFE:
                    return "INC";

                //Increment X by one
                case 0xE8:
                    return "INX";

                //Increment Y by one
                case 0xC8:
                    return "INY";

                default:
                    Console.WriteLine("No compatible instruction found, may be a memory address");
                    return " ";
            }
        }
    }
}
