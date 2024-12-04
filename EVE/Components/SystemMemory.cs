namespace EVE.Components
{
    public class SystemMemory
    {
        private byte[] _memory;

        public SystemMemory()
        {
            _memory = new byte[256];
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
