namespace EVE.SDK
{
    public interface IPortDevice
    {
        dynamic Read();
        void Write(dynamic data);
    }
}
