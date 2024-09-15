using System.Reflection;

namespace _6502
{
    public class Memory
    {
        //Memory array: 64k of addressable RAM (0x0000 - 0xFFFF)
        public UInt16[] memory = new UInt16[1024 * 64];

        public UInt16 offset { get; set; }

        //Memory map:
        //0x0000 - 0x00FF = Zeropage RAM 
        //0x0100 - 0x01FF = Stack memory, Stack pointer starts at 0x0100
        //0x0200 - 0xFFF9 = General purpose RAM
        //0xFFFA - 0xFFFF = Reset ROM

        public void GetMemoryOffset(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte memOffsetLoByte = (byte)fs.ReadByte();
            byte memOffsetHiByte = (byte)fs.ReadByte();

            string memOffsetLoByteString = memOffsetLoByte.ToString("X2");
            string memOffsetHiByteString = memOffsetHiByte.ToString("X2");

            string finalOffsetString = memOffsetHiByteString + memOffsetLoByteString;

            UInt16 finalOffsetAddr = UInt16.Parse(finalOffsetString, System.Globalization.NumberStyles.HexNumber);

            offset = finalOffsetAddr;
        }

        public byte ReadMemoryValue(UInt16 address, Registers registers)
        {
            byte value = (byte)memory[address];
            registers.clock++;
            return value;
        }
        
        public void ReadBytesIntoMemory(string filename, Registers registers, Memory memory)
        {
            GetMemoryOffset(filename);

            List<UInt16> buffer = new List<UInt16>();

            buffer.Clear();

            try
            {
                FileStream fs = new FileStream(filename, FileMode .Open, FileAccess.Read);

                for (int i = 0; i < 0xFFFA - offset; i++)
                {
                    buffer.Add((UInt16)fs.ReadByte());

                    if (buffer[i] == 0xFF)
                    {
                        Console.WriteLine("0xFF byte found");
                        break;
                    }
                }

                fs.Close();
                buffer.CopyTo(memory.memory, offset);
                registers.PC = offset;
            }

            catch (SystemException)
            {
                Console.WriteLine("File too big");
                Environment.Exit(1);
            }  
        }
    }
}
