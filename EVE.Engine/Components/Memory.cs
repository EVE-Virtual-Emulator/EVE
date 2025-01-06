using EVE.SDK;

namespace EVE.Engine.Components
{
    public class Memory : IMemory
    {
        public ushort[] Register { get; set; }
        public ushort Flags { get; set; } // 0x0001 = zero flag (Z) 0x0002 = carry flag (C) 0x0004 = negative flag (N) 0x0008 = overflow flag (V)
        public ushort Pc { get; set; }
        public int Ir { get; set; }
        public ushort Sp { get; set; }

        private short[] _memory;

        public Memory()
        {
            Register = new ushort[12];
            Flags = 0;
            Pc = MemoryRegion.ROM_START;
            Ir = 0;
            Sp = MemoryRegion.STACK_START;
            _memory = new short[UInt16.MaxValue];
        }

        public void LoadProgram(short[] program)
        {
            for (int i = 0; i < program.Length; i++)
            {
                var address = (ushort)(i + MemoryRegion.ROM_START);
                WriteROM(address, program[i]);
            }
        }

        public dynamic Read(int address)
        {
            switch (address)
            {
                case int n when (n >= MemoryRegion.R0 && n <= MemoryRegion.R11):
                    return Register[address];
                case int n when (n == MemoryRegion.PC):
                    return Pc;
                case int n when (n == MemoryRegion.SP):
                    return Sp;
                case int n when (n == MemoryRegion.FLAGS):
                    return Flags;
                case int n when (n == MemoryRegion.IR):
                    return Ir;
                case int n when (n >= (int)MemoryRegion.ROM_START && n <= MemoryRegion.ROM_END):
                    return ReadROM(address);
                case int n when (n >= (int)MemoryRegion.SYSTEM_RAM_START && n <= MemoryRegion.SYSTEM_RAM_END):
                    return ReadSystemRAM(address);
                case int n when (n >= (int)MemoryRegion.VRAM_START && n <= MemoryRegion.VRAM_END):
                    return ReadVRAM(address);
                case int n when (n >= (int)MemoryRegion.STACK_START && n <= MemoryRegion.STACK_END):
                    return ReadStack(address);
                default:
                    return _memory[address];
            }
        }

        public void Write(int address, dynamic value)
        {
            if (address >= MemoryRegion.ROM_START && address <= MemoryRegion.ROM_END)
            {
                throw new OutOfMemoryException("Cannot write to ROM");
            }

            switch (address)
            {
                case int n when (n >= MemoryRegion.R0 && n <= MemoryRegion.R11):
                    Register[address] = value;
                    break;
                case int n when (n == MemoryRegion.PC):
                    Pc = (ushort)value;
                    break;
                case int n when (n == MemoryRegion.SP):
                    Sp = (ushort)value;
                    break;
                case int n when (n == MemoryRegion.FLAGS):
                    Flags = (ushort)value;
                    break;
                case int n when (n == MemoryRegion.IR):
                    Ir = value;
                    break;
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

        private short ReadROM(int address)
        {
            return _memory[address];
        }

        private short ReadSystemRAM(int address)
        {
            return _memory[address];
        }

        private short ReadVRAM(int address)
        {
            return _memory[address];
        }

        private short ReadStack(int address)
        {
            return _memory[address];
        }

        private void WriteROM(int address, short value)
        {
            _memory[address] = value;
        }

        private void WriteSystemRAM(int address, short value)
        {
            _memory[address] = value;
        }

        private void WriteVRAM(int address, short value)
        {
            _memory[address] = value;
        }

        private void WriteStack(int address, short value)
        {
            _memory[address] = value;
        }
    }
}
