namespace EVE.SDK
{
    /// <summary>
    /// Represents the addressing modes used in the EVE SDK.
    /// </summary>
    public class AddressingMode
    {
        /// <summary>
        /// Immediate addressing mode.
        /// In this mode, the operand is specified directly in the instruction itself.
        /// For example, if the instruction is to load a value into a register, the value is provided directly in the instruction.
        /// This mode is fast because it does not require memory access to fetch the operand.
        /// 
        /// Example: LOAD R0, #0x0F (Load the immediate value 0x0F into register R0)
        /// </summary>
        public const byte IMMEDIATE = 0x00;

        /// <summary>
        /// Direct addressing mode.
        /// In this mode, the instruction specifies the memory address where the operand is located.
        /// The CPU fetches the operand from the specified memory address.
        /// This mode is simple and easy to understand but requires a memory access to fetch the operand.
        /// 
        /// Example: LOAD R0, [0x0F] (Load the value stored at memory address (or register address) 0x0F into register R0)
        /// </summary>
        public const byte DIRECT = 0x01;

        /// <summary>
        /// Indirect addressing mode.
        /// In this mode, the instruction specifies a memory address that contains the address of the operand.
        /// The CPU first fetches the address from the specified memory location and then uses that address to fetch the actual operand.
        /// This mode allows for more flexible and dynamic memory access but requires two memory accesses.
        /// 
        /// Example: LOAD R0, ([R2]) (Load the value stored at the memory address pointed to by register R3 into register R0)
        /// Example: LOAD R0, [[0x0F]] (Load the value stored at the memory address pointed to by memory address 0x0F into register R0)
        /// </summary>
        public const byte INDIRECT = 0x02;

        /// <summary>
        /// Indexed addressing mode.
        /// In this mode, the final address of the operand is determined by adding a constant value (index) to the contents of a register.
        /// This mode is useful for accessing elements in arrays or tables where the index can be used to offset from a base address.
        /// It provides a balance between flexibility and performance.
        /// 
        /// Example: LOAD R0, [R1 + 0x05] (Load value stored at memory address pointed to by R1 + 5 into R0)
        /// </summary>
        public const byte INDEXED = 0x03;
    }
}
