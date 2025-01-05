using EVE.SDK;

namespace EVE.Engine.Components
{
    public class RomMemoryModule : IMemoryModule
    {
        public dynamic Read(ushort address)
        {
            if (address < MemoryRegion.ROM_START || address > MemoryRegion.ROM_END)
            {
                throw new ArgumentOutOfRangeException(nameof(address));
            }

            throw new NotImplementedException();
        }

        public void Write(ushort address, dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}
