namespace EVE.Components
{
    public enum MemorySegment
    {
        VRAM,
        RAM,
        ROM
    }

    public class Memory
    {
        private byte[] _memory;

        public Memory()
        {
            _memory = new byte[UInt16.MaxValue];
        }

        public byte Read(int address)
        {
            return _memory[address];
        }

        public void Write(int address, byte value)
        {
            _memory[address] = value;
        }
    }
}

// TODO: Implement segments for VRAM, System RAM, and ROM