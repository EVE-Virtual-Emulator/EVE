namespace EVE.SDK
{
    /// <summary>
    /// Represents the memory regions and registers of the EVE system.
    /// </summary>
    public static class MemoryRegion
    {
        /// <summary>Register 0</summary>
        public const ushort R0 = 0x0000;
        /// <summary>Register 1</summary>
        public const ushort R1 = 0x0001;
        /// <summary>Register 2</summary>
        public const ushort R2 = 0x0002;
        /// <summary>Register 3</summary>
        public const ushort R3 = 0x0003;
        /// <summary>Register 4</summary>
        public const ushort R4 = 0x0004;
        /// <summary>Register 5</summary>
        public const ushort R5 = 0x0005;
        /// <summary>Register 6</summary>
        public const ushort R6 = 0x0006;
        /// <summary>Register 7</summary>
        public const ushort R7 = 0x0007;
        /// <summary>Register 8</summary>
        public const ushort R8 = 0x0008;
        /// <summary>Register 9</summary>
        public const ushort R9 = 0x0009;
        /// <summary>Register 10</summary>
        public const ushort R10 = 0x000A;
        /// <summary>Register 11</summary>
        public const ushort R11 = 0x000B;

        /// <summary>Program counter, 16 bits wide</summary>
        public const ushort PC = 0x000C;
        /// <summary>Instruction register, 32 bits wide</summary>
        public const ushort IR = 0x000D;
        /// <summary>Stack pointer, 16 bits wide</summary>
        public const ushort SP = 0x000E;
        /// <summary>Flags register, 16 bits wide</summary>
        public const ushort FLAGS = 0x000F;

        /// <summary>Start address of ROM</summary>
        public const ushort ROM_START = 0x0010;
        /// <summary>End address of ROM</summary>
        public const ushort ROM_END = 0x7FFF;
        /// <summary>Start address of VRAM</summary>
        public const ushort VRAM_START = 0x8000;
        /// <summary>End address of VRAM</summary>
        public const ushort VRAM_END = 0x9FFF;
        /// <summary>Start address of system RAM</summary>
        public const ushort SYSTEM_RAM_START = 0xA000;
        /// <summary>End address of system RAM</summary>
        public const ushort SYSTEM_RAM_END = 0xE7FF;
        /// <summary>Start address of the stack</summary>
        public const ushort STACK_START = 0xFFFE;
        /// <summary>End address of the stack</summary>
        public const ushort STACK_END = 0xE800;
    }
}
