namespace EVE.SDK
{
    public static class MemoryRegion
    {
        // 12 registers, each register is 16 bits wide
        public const ushort R0 = 0x0000;
        public const ushort R1 = 0x0001;
        public const ushort R2 = 0x0002;
        public const ushort R3 = 0x0003;
        public const ushort R4 = 0x0004;
        public const ushort R5 = 0x0005;
        public const ushort R6 = 0x0006;
        public const ushort R7 = 0x0007;
        public const ushort R8 = 0x0008;
        public const ushort R9 = 0x0009;
        public const ushort R10 = 0x000A;
        public const ushort R11 = 0x000B;

        public const ushort PC = 0x000C; // program counter, 16 bits wide
        public const ushort IR = 0x000D; // instruction register, 32 bits wide
        public const ushort SP = 0x000E; // stack pointer, 16 bits wide
        public const ushort FLAGS = 0x000F; // flags register, 16 bits wide

        // memory regions, all memory locations are 8 bits wide
        public const ushort ROM_START = 0x0010;
        public const ushort ROM_END = 0x7FFF;
        public const ushort VRAM_START = 0x8000;
        public const ushort VRAM_END = 0x9FFF;
        public const ushort SYSTEM_RAM_START = 0xA000;
        public const ushort SYSTEM_RAM_END = 0xE7FF;
        public const ushort STACK_START = 0xFFFE;
        public const ushort STACK_END = 0xE800;
    }
}
