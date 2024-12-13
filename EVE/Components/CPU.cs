using EVE.Instructions;

namespace EVE.Components
{
    public class Cpu
    {
        private static Cpu _instance;
        public static Cpu Instance
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
        public ushort PC { get; set; }  // program counter
        public ushort IR { get; set; }  // instruction register
        public byte Flags { get; set; } // bit 0 = zero flag, bit 1 = carry flag
        public Instruction Instruction { get; set; }
        public bool Running { get; set; }

        public Cpu()
        {
            Running = true;
            Memory = new Memory();
            Registers = new byte[4];
            PC = 0;
            IR = 0;
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
            ushort opcode = (ushort)(Memory.Read(PC) << 8);
            ushort operand = Memory.Read(PC + 1);
            IR = opcode |= operand;
            PC += 2;

            Instruction.Opcode = (byte)((IR >> 8) & 0xFF);
            Instruction.Operand = (byte)(IR & 0xFF);
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
            //Type type = GetType();
            //var method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            //method.Invoke(this, null);

            Type type = Type.GetType("EVE.Instructions." + className);
            var instance = (IInstruction)Activator.CreateInstance(type);
            instance.Execute(Instruction, this);
        }
        #endregion

        #region Instructions
        //private void Load()
        //{
        //    Registers[Instruction.HighOperand] = Instruction.LowOperand;
        //}

        //private void Move()
        //{
        //    Registers[Instruction.HighOperand] = Registers[Instruction.LowOperand];
        //}

        //private void Add()
        //{
        //    byte result = (byte)(Registers[Instruction.HighOperand] + Registers[Instruction.LowOperand]);
        //    Registers[Instruction.HighOperand] = (byte)(result & 0xFF);
        //    Flags = (byte)((result > 255 ? 0x02 : 0) | (Registers[Instruction.HighOperand] == 0 ? 0x01 : 0));
        //}

        //private void Subtract()
        //{
        //    byte result = (byte)(Registers[Instruction.HighOperand] - Registers[Instruction.LowOperand]);
        //    Registers[Instruction.HighOperand] = (byte)(result & 0xFF);
        //    Flags = (byte)((result < 0 ? 0x02 : 0) | (Registers[Instruction.HighOperand] == 0 ? 0x01 : 0));
        //}

        //private void And()
        //{
        //    Registers[Instruction.HighOperand] &= Registers[Instruction.LowOperand];
        //    Flags = (byte)(Registers[Instruction.HighOperand] == 0 ? 0x01 : 0);
        //}

        //private void Or()
        //{
        //    Registers[Instruction.HighOperand] |= Registers[Instruction.LowOperand];
        //    Flags = (byte)(Registers[Instruction.HighOperand] == 0 ? 0x01 : 0);
        //}

        //private void Xor()
        //{
        //    Registers[Instruction.HighOperand] ^= Registers[Instruction.LowOperand];
        //    Flags = (byte)(Registers[Instruction.HighOperand] == 0 ? 0x01 : 0);
        //}

        //private void Increment()
        //{
        //    int result = Registers[Instruction.HighOperand] + 1;
        //    Registers[Instruction.HighOperand] = (byte)(result & 0xFF);
        //    Flags = (byte)((result > 255 ? 0x02 : 0) | (Registers[Instruction.LowOperand] == 0 ? 0x01 : 0));
        //}

        //private void Decrement()
        //{
        //    int result = Registers[Instruction.HighOperand] - 1;
        //    Registers[Instruction.HighOperand] = (byte)(result & 0xFF);
        //    Flags = (byte)((result < 0 ? 0x02 : 0) | (Registers[Instruction.LowOperand] == 0 ? 0x01 : 0));
        //}

        //private void Jump()
        //{
        //    PC = Instruction.Operand;
        //}

        //private void JumpZero()
        //{
        //    if ((Flags & 0x01) != 0)
        //    {
        //        PC = Instruction.Operand;
        //    }
        //}

        //private void JumpCarry()
        //{
        //    if ((Flags & 0x02) != 0)
        //    {
        //        PC = Instruction.Operand;
        //    }
        //}

        //private void Halt()
        //{
        //    Running = false;
        //}
        #endregion


        #region Debugging
        private void DumpRegisters()
        {
            Console.Write($"PC: {PC} ");
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
