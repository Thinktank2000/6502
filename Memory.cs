using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace _6502
{
    public class Memory
    {
        //Memory array: 64k of addressable RAM (0x0000 - 0xFFFF)
        public UInt16[] memory = new UInt16[1024 * 64];

        public UInt16 offset { get; set; }
        public UInt16 memoryLocation { get; set; }

        //Memory map:
        //0x0000 - 0x00FF = Zeropage RAM 
        //0x0100 - 0x01FF = Stack memory, Stack pointer starts at 0x0100
        //0x0200 - 0xFFF9 = General purpose RAM
        //0xFFFA - 0xFFFF = Reset ROM

        public UInt16 GetMemoryOffset(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte memOffsetLoByte = (byte)fs.ReadByte();
            byte memOffsetHiByte = (byte)fs.ReadByte();

            string memOffsetLoByteString = memOffsetLoByte.ToString("X2");
            string memOffsetHiByteString = memOffsetHiByte.ToString("X2");

            string finalOffsetString = memOffsetHiByteString + memOffsetLoByteString;

            UInt16 finalOffsetAddr = UInt16.Parse(finalOffsetString, System.Globalization.NumberStyles.HexNumber);

            return finalOffsetAddr;
        }

        public byte ReadMemoryValue(UInt16 address, Registers registers)
        {
            var value = memory[address];
            registers.clock++;
            return (byte)value;
        }

        public UInt16 GetAddressByAddressingMode(AddressingModes addressingMode, Registers registers)
        {
            UInt16 address;

            switch (addressingMode)
            {
                case (AddressingModes.Absolute):
                    return (UInt16)(ReadMemoryValue(registers.PC += 1, registers) | (ReadMemoryValue(registers.PC += 1, registers) << 8));


                case (AddressingModes.ZeroPage):
                    address = ReadMemoryValue(registers.PC += 1, registers);
                    return address;

                case (AddressingModes.ZeroPageX):
                    address = ReadMemoryValue(registers.PC += 1, registers);
                    ReadMemoryValue(address, registers);

                    address += registers.X;
                    address &= 0xFF;

                    if (address > 0xFF)
                    {
                        address -= 0x0100;
                    }

                    return address;

                case (AddressingModes.ZeroPageY):
                    address = ReadMemoryValue(registers.PC++, registers);
                    ReadMemoryValue(address, registers);

                    address += registers.Y;
                    address &= 0xFF;

                    return address;

                default:
                    Console.WriteLine("No address found");
                    return 0;
            }
        }

        public void ChangeMemoryByOne(AddressingModes addressingModes, bool Decrement, Registers registers, Memory memory)
        {
            memoryLocation = GetAddressByAddressingMode(AddressingModes.ZeroPage, registers);
            byte memoryValue = ReadMemoryValue(memoryLocation, registers);

            WriteMemoryValue(memoryLocation, memoryValue, registers);

            if (Decrement)
            {
                memoryValue -= 1;
            }

            else if (!Decrement)
            {
                memoryValue += 1;
            }

            WriteMemoryValue(memoryLocation, memoryValue, registers);
        }

        public void WriteMemoryValue(UInt16 address, byte data, Registers registers)
        {
            registers.clock++;
            memory[address] = data;
        }
        
        public void ReadBytesIntoMemory(string filename, Registers registers, Memory memory)
        {
            offset = GetMemoryOffset(filename);

            List<UInt16> buffer = new List<UInt16>();

            buffer.Clear();

            try
            {
                FileStream fs = new FileStream(filename, FileMode .Open, FileAccess.Read);

                for (int i = 0; i < 0xFFFA - offset; i++)
                {
                    buffer.Add((UInt16)fs.ReadByte());
                }

                fs.Close();
                registers.PC = offset;
                buffer.CopyTo(memory.memory, offset);
            }

            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("File too big");
                Environment.Exit(1);
            }  
        }
    }
}
