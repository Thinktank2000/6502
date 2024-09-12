namespace _6502
{
    public class Memory
    {
        //Memory array: 64k of addressable RAM (0x0000 - 0xFFFF)
        public UInt16[] memory = new UInt16[1024 * 64];

        //Memory map:
        //0x0000 - 0x00FF = Zeropage RAM 
        //0x0100 - 0x01FF = Stack memory, Stack pointer starts at 0x0100
        //0x0200 - 0xFFF9 = General purpose RAM
        //0xFFFA - 0xFFFF = Reset ROM
    }
}
