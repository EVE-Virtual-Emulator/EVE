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
            throw new NotImplementedException();
        }

        public void Write(ushort address, dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}
