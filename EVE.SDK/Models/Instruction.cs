namespace EVE.SDK
{
    /// <summary>
    /// Represents an instruction with various components extracted from a bit-packed value.
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// Gets or sets the raw value of the instruction.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// ********------------------------- first 8 bits
        /// Gets the opcode extracted from the instruction value.
        /// </summary>
        public byte Opcode { get => (byte)((Value >> 24) & 0xFF); }

        /// <summary>
        /// --------****-------------------- next 4 bits
        /// Gets the register address extracted from the instruction value.
        /// R0 = 0... R11 = 11, PC = 12, IR = 13, SP = 14, Flags = 15
        /// </summary>
        public byte RegisterOperand { get => (byte)((Value >> 20) & 0x0F); }

        /// <summary>
        /// ------------**------------------ next 2 bits
        /// Gets the addressing mode extracted from the instruction value.
        /// </summary>
        public byte Mode { get => (byte)((Value >> 18) & 0x03); }

        /// <summary>
        /// --------------*----------------- next 1 bit
        /// Gets the display mode extracted from the instruction value.
        /// 
        /// Bit = 0: Display terminal output in text mode; Bit = 1: Display terminal output in graphics mode.
        /// </summary>
        public byte DisplayMode { get => (byte)((Value >> 17) & 0x01); }

        /// <summary>
        /// ----------------*************** last 16 bits
        /// Gets the data operand extracted from the instruction value.
        /// 
        /// Leading bit = 0: Positive value; Leading bit = 1: Negative value.
        /// </summary>
        public dynamic DataOperand { get => (ushort)(Value >> 15) > 0 ? (short)(Value & 0xFFFF) : (ushort)(Value & 0xFFFF); }
    }
}
