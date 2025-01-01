namespace EVE.SDK
{
    public interface IMemory
    {
        ushort[] Register { get; set; }
        ushort Flags { get; set; }
        ushort Pc { get; set; }
        int Ir { get; set; }
        ushort Sp { get; set; }
        void LoadProgram(byte[] program);
        dynamic Read(int address);
        void Write(int address, dynamic value);
    }
}
