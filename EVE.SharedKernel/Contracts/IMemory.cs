namespace EVE.SharedKernel
{
    public interface IMemory
    {
        byte Read(int address);
        void Write(int address, byte value);
        byte ReadSystemRAM(int address);
        void WriteSystemRAM(int address, byte value);
        byte ReadVRAM(int address);
        void WriteVRAM(int address, byte value);
        byte ReadROM(int address);
        void WriteROM(int address, byte value);
        ushort PopStack();
        void PushStack(ushort address);  // address is a 16-bit value that is the location of the instruction in memory to which the program counter should return
    }
}
