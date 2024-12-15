namespace EVE.SDK
{
    public static class MemoryRegion
    {
        public const ushort VRAM_START = 0x0000;
        public const ushort VRAM_END = 0x1FFF;
        public const ushort SYSTEM_RAM_START = 0x2000;
        public const ushort SYSTEM_RAM_END = 0x3FF0;
        public const ushort STACK_START = 0x3FF1;
        public const ushort STACK_END = 0x3FFF;
        public const ushort ROM_START = 0x4000;
        public const ushort ROM_END = 0xFFFF;
    }
}
