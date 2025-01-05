namespace EVE.SDK
{
    /// <summary>
    /// Abstract base class for memory modules.
    /// </summary>
    public abstract class MemoryModuleBase : IMemoryModule
    {
        private readonly byte[] _sharedMemory;
        private readonly ushort _startAddress;
        private readonly ushort _endAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryModuleBase"/> class.
        /// </summary>
        /// <param name="sharedMemory">The shared memory array.</param>
        /// <param name="startAddress">The start address of the memory module.</param>
        /// <param name="endAddress">The end address of the memory module.</param>
        public MemoryModuleBase(byte[] sharedMemory, ushort startAddress, ushort endAddress)
        {
            _sharedMemory = sharedMemory;
            _startAddress = startAddress;
            _endAddress = endAddress;
        }

        /// <summary>
        /// Reads a value from the specified address.
        /// </summary>
        /// <param name="address">The address to read from.</param>
        /// <returns>The value read from the specified address.</returns>
        public virtual dynamic Read(ushort address)
        {
            ValidateAddress(address);
            return _sharedMemory[address];
        }

        /// <summary>
        /// Writes a value to the specified address.
        /// </summary>
        /// <param name="address">The address to write to.</param>
        /// <param name="value">The value to write.</param>
        public virtual void Write(ushort address, dynamic value)
        {
            ValidateAddress(address);
            _sharedMemory[address] = value;
        }

        /// <summary>
        /// Validates the specified address.
        /// </summary>
        /// <param name="address">The address to validate.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the address is out of range.</exception>
        private void ValidateAddress(int address)
        {
            if (address < _startAddress || address > _endAddress)
            {
                throw new ArgumentOutOfRangeException(nameof(address));
            }
        }
    }
}
