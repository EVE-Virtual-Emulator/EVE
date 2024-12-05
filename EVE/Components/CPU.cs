using EVE.Core.Models;
using System.Reflection;

namespace EVE.Components
{
    public class CPU
    {
        private Memory _memory;
        private byte[] _registers;  // R0, R1, R2, R3
        private ushort _pc;  // program counter
        private ushort _ir;  // instruction register
        private byte _flags; // bit 0 = zero flag, bit 1 = carry flag
        private Instruction _instruction;
        private bool _running;

        public CPU()
        {
            _running = true;
            _memory = new Memory();
            _registers = new byte[4];
            _pc = 0;
            _ir = 0;
            _flags = 0;
            _instruction = new Instruction() { Opcode = 0, Operand = 0 };
        }

        public void LoadProgram(byte[] program)
        {
            // TODO: Replace this with Memory.Write(Cartridge.Program)
            for (int i = 0; i < program.Length; i++)
            {
                _memory.Write(i, program[i]);
            }
        }

        public void Run(bool withDebug)
        {
            while (_running)
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
            ushort opcode = (ushort)(_memory.Read(_pc) << 8);
            ushort operand = _memory.Read(_pc + 1);
            _ir = opcode |= operand;
            _pc += 2;

            _instruction.Opcode = (byte)((_ir >> 8) & 0xFF);
            _instruction.Operand = (byte)(_ir & 0xFF);
        }

        private string Decode()
        {
            switch (_instruction.Opcode)
            {
                case 0x01:  // LOAD r, n
                    return "Load";
                case 0x02:  // MOV r1, r2
                    return "Move";
                case 0x03:  // ADD r1, r2
                    return "Add";
                case 0x04:  // SUB r1, r2
                    return "Subtract";
                case 0x05:  // AND r1, r2
                    return "And";
                case 0x06:  // OR r1, r2
                    return "Or";
                case 0x07:  // XOR r1, r2
                    return "Xor";
                case 0x08:  // INC r
                    return "Increment";
                case 0x09:  // DEC r
                    return "Decrement";
                case 0x0A:  // JMP addr
                    return "Jump";
                case 0x0B:  // JZ addr
                    return "JumpZero";
                case 0x0C:  // JC addr
                    return "JumpCarry";
                case 0x0D:  // HALT
                    return "Halt";
                default:
                    throw new InvalidOperationException($"Invalid opcode: {_instruction.Opcode}");
            }
        }

        private void Execute(string methodName)
        {
            Type type = GetType();
            var method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            method.Invoke(this, null);
        }
        #endregion

        #region Instructions
        private void Load()
        {
            _registers[_instruction.HighOperand] = _instruction.LowOperand;
        }

        private void Move()
        {
            _registers[_instruction.HighOperand] = _registers[_instruction.LowOperand];
        }

        private void Add()
        {
            int result = _registers[_instruction.HighOperand] + _registers[_instruction.LowOperand];
            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
            _flags = (byte)((result > 255 ? 0x02 : 0) | (_registers[_instruction.HighOperand] == 0 ? 0x01 : 0));
        }

        private void Subtract()
        {
            int result = _registers[_instruction.HighOperand] - _registers[_instruction.LowOperand];
            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
            _flags = (byte)((result < 0 ? 0x02 : 0) | (_registers[_instruction.HighOperand] == 0 ? 0x01 : 0));
        }

        private void And()
        {
            _registers[_instruction.HighOperand] &= _registers[_instruction.LowOperand];
            _flags = (byte)(_registers[_instruction.HighOperand] == 0 ? 0x01 : 0);
        }

        private void Or()
        {
            _registers[_instruction.HighOperand] |= _registers[_instruction.LowOperand];
            _flags = (byte)(_registers[_instruction.HighOperand] == 0 ? 0x01 : 0);
        }

        private void Xor()
        {
            _registers[_instruction.HighOperand] ^= _registers[_instruction.LowOperand];
            _flags = (byte)(_registers[_instruction.HighOperand] == 0 ? 0x01 : 0);
        }

        private void Increment()
        {
            int result = _registers[_instruction.HighOperand] + 1;
            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
            _flags = (byte)((result > 255 ? 0x02 : 0) | (_registers[_instruction.LowOperand] == 0 ? 0x01 : 0));
        }

        private void Decrement()
        {
            int result = _registers[_instruction.HighOperand] - 1;
            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
            _flags = (byte)((result < 0 ? 0x02 : 0) | (_registers[_instruction.LowOperand] == 0 ? 0x01 : 0));
        }

        private void Jump()
        {
            _pc = _instruction.Operand;
        }

        private void JumpZero()
        {
            if ((_flags & 0x01) != 0)
            {
                _pc = _instruction.Operand;
            }
        }

        private void JumpCarry()
        {
            if ((_flags & 0x02) != 0)
            {
                _pc = _instruction.Operand;
            }
        }

        private void Halt()
        {
            _running = false;
        }
        #endregion


        #region Debugging
        private void DumpRegisters()
        {
            Console.Write($"PC: {_pc} ");
            for (int i = 0; i < _registers.Length; i++)
            {
                Console.Write($"R{i}: {_registers[i]:X2} ");
            }

            Console.Write($"Flags: {_flags:X2}");
            Console.WriteLine();
        }
        #endregion
    }
}
