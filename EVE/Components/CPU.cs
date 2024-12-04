using EVE.Core.Models;

namespace EVE.Components
{
    public class CPU
    {
        //private Memory _memory;
        private byte[] _memory;
        private byte[] _registers;
        private byte _pc;
        private byte _flags; // bit 0 = zero flag, bit 1 = carry flag
        private Instruction _instruction;

        public CPU()
        {
            _memory = new byte[256];
            _registers = new byte[8];
            _pc = 0;
            _flags = 0;
            _instruction = new Instruction() { Opcode = 0, Operand = 0 };
        }

        public void LoadProgram(byte[] program)
        {
            for (int i = 0; i < program.Length; i++)
            {
                _memory[i] = program[i];
            }
        }

        public void Run(bool withDebug)
        {
            bool running = true;
            while (running)
            {
                Fetch();
                if (withDebug)
                {
                    DumpRegisters();
                }

                _pc += 2;
                switch (_instruction.Opcode)
                {
                    case 0x01:  // LOAD r, n
                        _registers[_instruction.HighOperand] = _instruction.LowOperand;
                        break;
                    case 0x02:  // MOV r1, r2
                        _registers[_instruction.HighOperand] = _registers[_instruction.LowOperand];
                        break;
                    case 0x03:  // ADD r1, r2
                        {
                            int result = _registers[_instruction.HighOperand] + _registers[_instruction.LowOperand];
                            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
                            _flags = (byte)((result > 255 ? 0x02 : 0) | (_registers[_instruction.HighOperand] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x04:  // SUB r1, r2
                        {
                            int result = _registers[_instruction.HighOperand] - _registers[_instruction.LowOperand];
                            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
                            _flags = (byte)((result < 0 ? 0x02 : 0) | (_registers[_instruction.HighOperand] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x05:  // AND r1, r2
                        _registers[_instruction.HighOperand] &= _registers[_instruction.LowOperand];
                        _flags = (byte)(_registers[_instruction.HighOperand] == 0 ? 0x01 : 0);
                        break;
                    case 0x06:  // OR r1, r2
                        _registers[_instruction.HighOperand] |= _registers[_instruction.LowOperand];
                        _flags = (byte)(_registers[_instruction.HighOperand] == 0 ? 0x01 : 0);
                        break;
                    case 0x07:  // XOR r1, r2
                        _registers[_instruction.HighOperand] ^= _registers[_instruction.LowOperand];
                        _flags = (byte)(_registers[_instruction.HighOperand] == 0 ? 0x01 : 0);
                        break;
                    case 0x08:  // INC r
                        {
                            int result = _registers[_instruction.HighOperand] + 1;
                            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
                            _flags = (byte)((result > 255 ? 0x02 : 0) | (_registers[_instruction.LowOperand] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x09:  // DEC r
                        {
                            int result = _registers[_instruction.HighOperand] - 1;
                            _registers[_instruction.HighOperand] = (byte)(result & 0xFF);
                            _flags = (byte)((result < 0 ? 0x02 : 0) | (_registers[_instruction.LowOperand] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x0A:  // JMP addr
                        _pc = _instruction.Operand;
                        break;
                    case 0x0B:  // JZ addr
                        if ((_flags & 0x01) != 0)
                        {
                            _pc = _instruction.Operand;
                        }

                        break;
                    case 0x0C:  // JC addr
                        if ((_flags & 0x02) != 0)
                        {
                            _pc = _instruction.Operand;
                        }

                        break;
                    case 0x0D:  // HALT
                        running = false;
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid opcode: {_instruction.Opcode}");
                }
            }
        }

        private void Fetch()
        {
            _instruction.Opcode = _memory[_pc];
            _instruction.Operand = _memory[_pc + 1];
        }

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
    }
}
