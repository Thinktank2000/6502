namespace _6502
{
    public class Registers
    {
        //general purpose registers
        public byte A { get; set; } //A register
        public byte X { get; set; } //X register
        public byte Y { get; set; } //Y register

        //special registers
        public UInt16 PC { get; set; }  //Program Counter
        public UInt16 SP { get; set; }  //Stack Pointer

        //processor status flags
        public bool N { get; set; } //negative flag
        public bool V { get; set; } //Overflow flag
        public bool B { get; set; } //Break flag
        public bool D { get; set; } //Decimal enable flag
        public bool I { get; set; } //Interrupt disable flag
        public bool Z { get; set; } //Zero flag
        public bool C { get; set; } //Carry flag

        //CPU clock
        public int clock { get; set; } //CPU clock (1MHz)
    }
}
