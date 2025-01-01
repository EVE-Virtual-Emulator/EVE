namespace EVE.SDK
{
    public interface IMemory
    {
        ushort[] Registers { get; set; }
        ushort Flags { get; set; }
        ushort Pc { get; set; }
        int Ir { get; set; }
        ushort Sp { get; set; }
        dynamic? ReadRegister(ushort address);
        void WriteRegister(ushort address, dynamic value);
        void LoadProgram(byte[] program);
        byte Read(int address);
        void Write(int address, byte value);
    }
}
