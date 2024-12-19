namespace EVE.SDK
{
    /// <summary>
    /// Represents an instruction with various components extracted from a ushort value.
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// Gets or sets the raw value of the instruction.
        /// </summary>
        public ushort Value { get; set; }

        /// <summary>
        /// *******--------- first 7 bits
        /// Gets the opcode extracted from the instruction value.
        /// </summary>
        public byte Opcode { get => (byte)((Value >> 9) & 0xFF); }

        /// <summary>
        /// -------***------ next 3 bits
        /// Gets the register operand extracted from the instruction value.
        /// </summary>
        public byte RegisterOperand { get => (byte)((Value >> 6) & 0x07); }

        /// <summary>
        /// ----------**---- next 2 bits
        /// Gets the mode extracted from the instruction value.
        /// </summary>
        public byte Mode { get => (byte)((Value >> 4) & 0x03); }

        /// <summary>
        /// ------------**** last 4 bits
        /// Gets the data operand extracted from the instruction value.
        /// </summary>
        public byte DataOperand { get => (byte)(Value & 0x0F); }
    }
}
