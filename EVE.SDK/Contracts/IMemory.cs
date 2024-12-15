namespace EVE.SDK
{
    public interface IMemory
    {
        void LoadProgram(byte[] program);
        byte Read(int address);
        void Write(int address, byte value);
    }
}
