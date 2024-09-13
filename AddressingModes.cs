namespace _6502
{
    public enum AddressingModes
    {
        //no address is used for this instruction
        Implied = 0,

        //the instruction acts on the accumulator (A)
        Accumulator = 1,

        //the value to operate on immediately follows the instruction
        //for example: {0xA9, 0x02} means ADC 02 to the accumulator
        Immediate = 2,

        //the full memory address is given to the operation (LSB first, 0x00FF is stored as 0xFF00) and the value
        //contained at the memory address is used in the operation, so in the case of 0xA9 (ADC) the value in 0x00FF would be added to the 
        //Accumulator
        Absolute = 3,

        //a full memory address is given to the operation and then added to the contents of the X register, so if the address was
        //0xA92B and the X register contained 0xAA then the final address to be used would be 0xA9D5 and acted upon thusly
        AbsoluteX = 4,

        //same as the previous but with the Y register
        AbsoluteY = 5,

        //only JMP() uses this addressing mode, it uses a absolute address to point to an absolute address to jump to
        //it uses the byte pointed to as the hi byte of the address and the next byte as the lo byte of the address 
        //both of which are then loaded into the 16-bit PC register
        Indirect = 6,

        //NOTE: try to explain these later lol
        IndirectX = 7,
        IndirectY = 8,

        //similar to Absolute but targets the first 255 bytes of memory in an 8 bit memory address (the "Zero page" of RAM)
        ZeroPage = 9,

        //refer to AbsoluteX and Y
        ZeroPageX = 10,
        ZeroPageY = 11,

        //this mode operates on the PC, allows the PC to be modified in 127 bytes either way
        Relative = 12, 
    }
}