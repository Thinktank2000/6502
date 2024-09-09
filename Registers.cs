namespace _6502
{
    public class Registers
    {
        //general purpose registers
        public byte A;     //A register
        public byte X;     //X register
        public byte Y;     //Y register

        //special registers
        public UInt16 PC;  //Program Counter
        public byte SP;    //Stack Pointer

        //processor status flags
        public bool N;     //negative flag
        public bool V;     //Overflow flag
        public bool B;     //Break flag
        public bool D;     //Decimal enable flag
        public bool I;     //Interrupt disable flag
        public bool Z;     //Zero flag
        public bool C;     //Carry flag
    }
}
