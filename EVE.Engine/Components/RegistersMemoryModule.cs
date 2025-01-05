using EVE.SDK;

namespace EVE.Engine.Components
{
    public class RegistersMemoryModule : IMemoryModule
    {
        public ushort Pc { get; set; }
        public int Ir { get; set; }
        public ushort Sp { get; set; }
        public ushort Flags { get; set; }

        private ushort[] _registers;

        public ushort R0
        {
            get { return _registers[0]; }
            set { _registers[0] = value; }
        }

        public ushort R1
        {
            get { return _registers[1]; }
            set { _registers[1] = value; }
        }

        public ushort R2
        {
            get { return _registers[2]; }
            set { _registers[2] = value; }
        }

        public ushort R3
        {
            get { return _registers[3]; }
            set { _registers[3] = value; }
        }

        public ushort R4
        {
            get { return _registers[4]; }
            set { _registers[4] = value; }
        }

        public ushort R5
        {
            get { return _registers[5]; }
            set { _registers[5] = value; }
        }

        public ushort R6
        {
            get { return _registers[6]; }
            set { _registers[6] = value; }
        }

        public ushort R7
        {
            get { return _registers[7]; }
            set { _registers[7] = value; }
        }

        public ushort R8
        {
            get { return _registers[8]; }
            set { _registers[8] = value; }
        }

        public ushort R9
        {
            get { return _registers[9]; }
            set { _registers[9] = value; }
        }

        public ushort R10
        {
            get { return _registers[10]; }
            set { _registers[10] = value; }
        }

        public ushort R11
        {
            get { return _registers[11]; }
            set { _registers[11] = value; }
        }

        public RegistersMemoryModule()
        {
            _registers = new ushort[12];
        }

        public dynamic Read(ushort address)
        {
            switch (address)
            {
                case MemoryRegion.PC:
                    return Pc;
                case MemoryRegion.IR:
                    return Ir;
                case MemoryRegion.SP:
                    return Sp;
                case MemoryRegion.FLAGS:
                    return Flags;
                case MemoryRegion.R0:
                    return R0;
                case MemoryRegion.R1:
                    return R1;
                case MemoryRegion.R2:
                    return R2;
                case MemoryRegion.R3:
                    return R3;
                case MemoryRegion.R4:
                    return R4;
                case MemoryRegion.R5:
                    return R5;
                case MemoryRegion.R6:
                    return R6;
                case MemoryRegion.R7:
                    return R7;
                case MemoryRegion.R8:
                    return R8;
                case MemoryRegion.R9:
                    return R9;
                case MemoryRegion.R10:
                    return R10;
                case MemoryRegion.R11:
                    return R11;
                default:
                    throw new ArgumentOutOfRangeException(nameof(address));
            }
        }

        public void Write(ushort address, dynamic value)
        {
            switch (address)
            {
                case MemoryRegion.PC:
                    Pc = value;
                    break;
                case MemoryRegion.IR:
                    Ir = value;
                    break;
                case MemoryRegion.SP:
                    Sp = value;
                    break;
                case MemoryRegion.FLAGS:
                    Flags = value;
                    break;
                case MemoryRegion.R0:
                    R0 = value;
                    break;
                case MemoryRegion.R1:
                    R1 = value;
                    break;
                case MemoryRegion.R2:
                    R2 = value;
                    break;
                case MemoryRegion.R3:
                    R3 = value;
                    break;
                case MemoryRegion.R4:
                    R4 = value;
                    break;
                case MemoryRegion.R5:
                    R5 = value;
                    break;
                case MemoryRegion.R6:
                    R6 = value;
                    break;
                case MemoryRegion.R7:
                    R7 = value;
                    break;
                case MemoryRegion.R8:
                    R8 = value;
                    break;
                case MemoryRegion.R9:
                    R9 = value;
                    break;
                case MemoryRegion.R10:
                    R10 = value;
                    break;
                case MemoryRegion.R11:
                    R11 = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(address));
            }
        }
    }
}
