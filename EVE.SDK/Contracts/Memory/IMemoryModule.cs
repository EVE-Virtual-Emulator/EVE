namespace EVE.SDK
{
    /// <summary>
    /// Interface for memory module operations.
    /// </summary>
    public interface IMemoryModule
    {
        /// <summary>
        /// Reads a value from the specified memory address.
        /// </summary>
        /// <param name="address">The memory address to read from.</param>
        /// <returns>The value read from the specified address.</returns>
        dynamic Read(ushort address);

        /// <summary>
        /// Writes a value to the specified memory address.
        /// </summary>
        /// <param name="address">The memory address to write to.</param>
        /// <param name="value">The value to write to the specified address.</param>
        void Write(ushort address, dynamic value);
    }
}
