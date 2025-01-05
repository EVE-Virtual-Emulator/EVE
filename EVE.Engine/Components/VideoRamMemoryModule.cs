using EVE.SDK;

namespace EVE.Engine.Components
{
    public class VideoRamMemoryModule : IMemoryModule
    {
        public dynamic Read(ushort address)
        {
            throw new NotImplementedException();
        }

        public void Write(ushort address, dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}
