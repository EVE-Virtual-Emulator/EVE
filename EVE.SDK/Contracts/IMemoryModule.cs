namespace EVE.SDK
{
    public interface IMemoryModule
    {
        dynamic Read(ushort address);
        void Write(ushort address, dynamic value);
    }
}
