namespace EVE.SDK
{
    /// <summary>
    /// Interface representing a bus for reading from and writing to specific addresses.
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// Reads data from the specified address.
        /// </summary>
        /// <param name="address">The address to read data from.</param>
        /// <returns>The data read from the specified address.</returns>
        dynamic Read(ushort address);

        /// <summary>
        /// Writes data to the specified address.
        /// </summary>
        /// <param name="address">The address to write data to.</param>
        /// <param name="data">The data to write to the specified address.</param>
        void Write(ushort address, dynamic data);
    }
}
