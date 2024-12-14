using EVE.Instructions;

namespace EVE.Components
{
    public class Cpu : ICpu
    {
        private static ICpu _instance;
        public static ICpu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Cpu();
                }

                return _instance;
            }
        }

        public Memory Memory { get; set; }
        public byte[] Registers { get; set; }  // R0, R1, R2, R3
        public ushort Pc { get; set; }  // program counter
        public ushort Ir { get; set; }  // instruction register
        public byte Flags { get; set; } // bit 0 = zero flag, bit 1 = carry flag
        public byte Sp { get; set; }  // stack pointer
        public Instruction Instruction { get; set; }
        public bool Running { get; set; }

        public Cpu()
        {
            Running = true;
            Memory = new Memory();
            Registers = new byte[4];
            Pc = 0;
            Ir = 0;
            Flags = 0;
            Instruction = new Instruction() { Opcode = 0, Operand = 0 };
        }

        public void LoadProgram(byte[] program)
        {
            for (int i = 0; i < program.Length; i++)
            {
                Memory.Write(i, program[i]);
            }
        }

        public void Run(bool withDebug)
        {
            while (Running)
            {
                if (withDebug)
                {
                    DumpRegisters();
                }

                Fetch();
                string methodName = Decode();
                Execute(methodName);
            }
        }

        #region Fetch-Decode-Execute
        private void Fetch()
        {
            ushort opcode = (ushort)(Memory.Read(Pc) << 8);
            ushort operand = Memory.Read(Pc + 1);
            Ir = opcode |= operand;
            Pc += 2;

            Instruction.Opcode = (byte)((Ir >> 8) & 0xFF);
            Instruction.Operand = (byte)(Ir & 0xFF);
        }

        private string Decode()
        {
            switch (Instruction.Opcode)
            {
                case 0x01:  // LOAD r, n
                    return "Load";
                case 0x02:  // MOV r1, r2
                    return "Mov";
                case 0x03:  // ADD r1, r2
                    return "Add";
                case 0x04:  // SUB r1, r2
                    return "Sub";
                case 0x05:  // AND r1, r2
                    return "And";
                case 0x06:  // OR r1, r2
                    return "Or";
                case 0x07:  // XOR r1, r2
                    return "Xor";
                case 0x08:  // INC r
                    return "Inc";
                case 0x09:  // DEC r
                    return "Dec";
                case 0x0A:  // JMP addr
                    return "Jmp";
                case 0x0B:  // JZ addr
                    return "Jz";
                case 0x0C:  // JC addr
                    return "Jc";
                case 0x0D:  // HALT
                    return "Halt";
                default:
                    throw new InvalidOperationException($"Invalid opcode: {Instruction.Opcode}");
            }
        }

        private void Execute(string className)
        {
            // TODO: Use reflection to read in all compiled instructions in DLLs stored in ISA directory.

            Type type = Type.GetType("EVE.Instructions." + className);
            var instance = (IInstructionHandler)Activator.CreateInstance(type);
            instance.Execute(Instruction, this);
        }
        #endregion

        #region Debugging
        private void DumpRegisters()
        {
            Console.Write($"PC: {Pc} ");
            for (int i = 0; i < Registers.Length; i++)
            {
                Console.Write($"R{i}: {Registers[i]:X2} ");
            }

            Console.Write($"Flags: {Flags:X2}");
            Console.WriteLine();
        }
        #endregion
    }
}
