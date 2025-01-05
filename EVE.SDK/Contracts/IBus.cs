namespace EVE.SDK
{
    public interface IBus
    {
        dynamic Read(ushort address);
        void Write(ushort address, dynamic data);
    }
}
