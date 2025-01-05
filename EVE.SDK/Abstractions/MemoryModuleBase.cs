namespace EVE.SDK
{
    public abstract class MemoryModuleBase : IMemoryModule
    {
        private readonly byte[] _sharedMemory;
        private readonly ushort _startAddress;
        private readonly ushort _endAddress;

        public MemoryModuleBase(byte[] sharedMemory, ushort startAddress, ushort endAddress)
        {
            _sharedMemory = sharedMemory;
            _startAddress = startAddress;
            _endAddress = endAddress;
        }
        public virtual dynamic Read(ushort address)
        {
            ValidateAddress(address);
            return _sharedMemory[address];
        }

        public virtual void Write(ushort address, dynamic value)
        {
            ValidateAddress(address);
            _sharedMemory[address] = value;
        }

        private void ValidateAddress(int address)
        {
            if (address < _startAddress || address > _endAddress)
            {
                throw new ArgumentOutOfRangeException(nameof(address));
            }
        }
    }
}
