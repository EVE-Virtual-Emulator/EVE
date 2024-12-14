namespace EVE.Components
{
    public class Memory : IMemory
    {
        private const ushort VRAM_START = 0x0000;
        private const ushort VRAM_END = 0x1FFF;
        private const ushort SYSTEM_RAM_START = 0x2000;
        private const ushort SYSTEM_RAM_END = 0x3FF0;
        private const ushort STACK_START = 0x3FF1;
        private const ushort STACK_END = 0x3FFF;
        private const ushort ROM_START = 0x4000;
        private const ushort ROM_END = 0xFFFF;
        private byte[] _memory;

        public Memory()
        {
            _memory = new byte[UInt16.MaxValue];
        }

        public ushort PopStack()
        {
            throw new NotImplementedException();
        }

        public void PushStack(ushort address)
        {
            throw new NotImplementedException();
        }

        public byte Read(int address)
        {
            return _memory[address];
        }

        public byte ReadROM(int address)
        {
            throw new NotImplementedException();
        }

        public byte ReadSystemRAM(int address)
        {
            throw new NotImplementedException();
        }

        public byte ReadVRAM(int address)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, byte value)
        {
            if (address >= ROM_START)
            {
                throw new OutOfMemoryException("Cannot write to ROM");
            }

            _memory[address] = value;
        }

        public void WriteROM(int address, byte value)
        {
            throw new NotImplementedException();
        }

        public void WriteSystemRAM(int address, byte value)
        {
            throw new NotImplementedException();
        }

        public void WriteVRAM(int address, byte value)
        {
            throw new NotImplementedException();
        }
    }
}

// TODO: Implement segments for VRAM, System RAM, and ROM, including a stack  segment for the stack pointer
// Stack segment should be at the top of the memory space in System RAM