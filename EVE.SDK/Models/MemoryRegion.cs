namespace EVE.SDK
{
    public enum MemoryRegion
    {
        VRAM_START = (ushort)0x0000,
        VRAM_END = (ushort)0x1FFF,
        SYSTEM_RAM_START = (ushort)0x2000,
        SYSTEM_RAM_END = (ushort)0x3FF0,
        STACK_START = (ushort)0x3FF1,
        STACK_END = (ushort)0x3FFF,
        ROM_START = (ushort)0x4000,
        ROM_END = (ushort)0xFFFF
    }
}
