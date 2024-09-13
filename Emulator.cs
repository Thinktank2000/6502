namespace _6502
{
    public class Emulator
    {
        public static void Main(string[] args)
        {
            //object instances
            CPU cpu = new CPU();
            Registers registers = new Registers();
            Memory memory = new Memory();
            Instructions instructions = new Instructions();

            //initialise CPU
            cpu.Initialize(registers, memory);

            //reset cpu
            cpu.ResetCPU(memory, registers);

            //first opcodes laid down:
            //increment X register
            instructions.ExecuteOpCode(0xE8, memory, registers);
            Debug.ReadRegister(registers, "X");
            Debug.ReadRegister(registers, "PC");

            //load A with 0xA9 and push to stack before reading stack
            registers.A = 0xA9;
            instructions.ExecuteOpCode(0x48, memory, registers);
            Debug.ReadMemory(memory, registers, Debug.CurrentStackAddr(registers));
            Debug.ReadRegister(registers, "PC");
            registers.A = 0x00;

            instructions.ExecuteOpCode(0x68, memory, registers);
            Debug.ReadRegister(registers, "A");
            Console.WriteLine("The current stack location is: 0x{0:X}", Debug.CurrentStackAddr(registers));
            Debug.ReadRegister(registers, "PC");
        }
    }
}
