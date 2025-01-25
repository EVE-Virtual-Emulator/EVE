namespace EVE.SDK
{
    /// <summary>
    /// Interface representing the memory structure and operations for the EVE SDK.
    /// </summary>
    public interface IMemory
    {
        /// <summary>
        /// Gets or sets the register array.
        /// </summary>
        ushort[] Register { get; set; }

        /// <summary>
        /// Gets or sets the flags register.
        /// </summary>
        ushort Flags { get; set; }

        /// <summary>
        /// Gets or sets the program counter.
        /// </summary>
        ushort Pc { get; set; }

        /// <summary>
        /// Gets or sets the instruction register.
        /// </summary>
        int Ir { get; set; }

        /// <summary>
        /// Gets or sets the stack pointer.
        /// </summary>
        ushort Sp { get; set; }

        /// <summary>
        /// Loads a program into memory.
        /// </summary>
        /// <param name="program">The program to load.</param>
        void LoadProgram(short[] program);

        /// <summary>
        /// Reads a value from the specified memory address.
        /// </summary>
        /// <param name="address">The memory address to read from.</param>
        /// <returns>The value read from the specified address.</returns>
        dynamic Read(int address);

        /// <summary>
        /// Writes a value to the specified memory address.
        /// </summary>
        /// <param name="address">The memory address to write to.</param>
        /// <param name="value">The value to write.</param>
        void Write(int address, dynamic value);

        short PopStack();
        void PushStack(short value);
    }
}
