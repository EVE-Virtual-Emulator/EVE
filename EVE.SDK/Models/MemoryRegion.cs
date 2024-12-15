namespace EVE.SDK
{
    public static class MemoryRegion
    {
        public const ushort ROM_START = 0x0000;
        public const ushort ROM_END = 0x7FFF;
        public const ushort VRAM_START = 0x8000;
        public const ushort VRAM_END = 0x9FFF;
        public const ushort SYSTEM_RAM_START = 0xA000;
        public const ushort SYSTEM_RAM_END = 0xE7FF;
        public const ushort STACK_START = 0xFFFF;
        public const ushort STACK_END = 0xE800;
    }
}
