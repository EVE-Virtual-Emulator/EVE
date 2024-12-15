using EVE.SharedKernel;

namespace EVE.Engine.Components
{
    public class Memory : IMemory
    {
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
            if (address >= (int)MemoryRegion.ROM_START && address <= (int)MemoryRegion.ROM_END)
            {
                return _memory[address];
            }

            throw new OutOfMemoryException("Address is not in ROM");
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
            if (address >= (int)MemoryRegion.ROM_START)
            {
                throw new OutOfMemoryException("Cannot write to ROM");
            }

            _memory[address] = value;
        }

        public void WriteROM(int address, byte value)
        {
            if (address >= (int)MemoryRegion.ROM_START && address <= (int)MemoryRegion.ROM_END)
            {
                _memory[address] = value;
            }
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