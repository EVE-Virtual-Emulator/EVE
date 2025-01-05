using EVE.SDK;

namespace EVE.Engine.Components
{
    public class SystemRamMemoryModule : IMemoryModule
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
