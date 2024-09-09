namespace _6502
{
    public class Emulator
    {
        public static void Main(string[] args)
        {
            CPU cpu = new CPU();
            Registers registers = new Registers();
            Memory memory = new Memory();

            //initialise CPU
            cpu.Initialize(registers, memory);

            //test to see if init worked
            Console.WriteLine("{0:X}", registers.PC);
        }
    }
}
