using EVE.SDK;

namespace EVE.Engine.Components
{
    public class Memory : IMemory
    {
        private byte[] _memory;

        public Memory()
        {
            _memory = new byte[UInt16.MaxValue];
        }

        public void LoadProgram(byte[] program)
        {
            for (int i = 0; i < program.Length; i++)
            {
                var address = (ushort)(i + MemoryRegion.ROM_START);
                WriteROM(address, program[i]);
            }
        }

        public byte Read(int address)
        {
            switch (address)
            {
                case int n when (n >= (int)MemoryRegion.ROM_START && n <= (int)MemoryRegion.ROM_END):
                    return ReadROM(address);
                case int n when (n >= (int)MemoryRegion.SYSTEM_RAM_START && n <= (int)MemoryRegion.SYSTEM_RAM_END):
                    return ReadSystemRAM(address);
                case int n when (n >= (int)MemoryRegion.VRAM_START && n <= (int)MemoryRegion.VRAM_END):
                    return ReadVRAM(address);
                case int n when (n >= (int)MemoryRegion.STACK_START && n <= (int)MemoryRegion.STACK_END):
                    return ReadStack(address);
                default:
                    return _memory[address];
            }
        }

        public void Write(int address, byte value)
        {
            if (address >= MemoryRegion.ROM_START && address <= MemoryRegion.ROM_END)
            {
                throw new OutOfMemoryException("Cannot write to ROM");
            }

            switch (address)
            {
                case int n when (n >= (int)MemoryRegion.SYSTEM_RAM_START && n <= (int)MemoryRegion.SYSTEM_RAM_END):
                    WriteSystemRAM(address, value);
                    break;
                case int n when (n >= (int)MemoryRegion.VRAM_START && n <= (int)MemoryRegion.VRAM_END):
                    WriteVRAM(address, value);
                    break;
                case int n when (n <= (int)MemoryRegion.STACK_START && n >= (int)MemoryRegion.STACK_END):
                    WriteStack(address, value);
                    break;
                default:
                    _memory[address] = value;
                    break;
            }
        }

        private byte ReadROM(int address)
        {
            return _memory[address];
        }

        private byte ReadSystemRAM(int address)
        {
            return _memory[address];
        }

        private byte ReadVRAM(int address)
        {
            return _memory[address];
        }

        private byte ReadStack(int address)
        {
            return _memory[address];
        }

        private void WriteROM(int address, byte value)
        {
            _memory[address] = value;
        }

        private void WriteSystemRAM(int address, byte value)
        {
            _memory[address] = value;
        }

        private void WriteVRAM(int address, byte value)
        {
            _memory[address] = value;
        }

        private void WriteStack(int address, byte value)
        {
            _memory[address] = value;
        }
    }
}

// TODO: Implement segments for VRAM, System RAM, and ROM, including a stack  segment for the stack pointer
// Stack segment should be at the top of the memory space in System RAM