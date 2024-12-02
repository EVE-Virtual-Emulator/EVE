namespace EVE.Components
{
    public class CPU
    {
        //private Memory _memory;
        private byte[] _memory;
        private byte[] registers;
        private byte _pc;
        private byte _flags; // bit 0 = zero flag, bit 1 = carry flag

        public CPU()
        {
            _memory = new byte[256];
            registers = new byte[8];
            _pc = 0;
            _flags = 0;
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
                byte opcode = _memory[_pc];
                byte operand = _memory[_pc + 1];
                byte op1 = (byte)(operand >> 4);
                byte op2 = (byte)(operand & 0x0F);
                if (withDebug)
                {
                    DumpRegisters();
                }

                _pc += 2;
                switch (opcode)
                {
                    case 0x01:  // LOAD r, n
                        registers[op1] = op2;
                        break;
                    case 0x02:  // MOV r1, r2
                        registers[op1] = registers[op2];
                        break;
                    case 0x03:  // ADD r1, r2
                        {
                            int result = registers[op1] + registers[op2];
                            registers[op1] = (byte)(result & 0xFF);
                            _flags = (byte)((result > 255 ? 0x02 : 0) | (registers[op1] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x04:  // SUB r1, r2
                        {
                            int result = registers[op1] - registers[op2];
                            registers[op1] = (byte)(result & 0xFF);
                            _flags = (byte)((result < 0 ? 0x02 : 0) | (registers[op1] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x05:  // AND r1, r2
                        registers[op1] &= registers[op2];
                        _flags = (byte)(registers[op1] == 0 ? 0x01 : 0);
                        break;
                    case 0x06:  // OR r1, r2
                        registers[op1] |= registers[op2];
                        _flags = (byte)(registers[op1] == 0 ? 0x01 : 0);
                        break;
                    case 0x07:  // XOR r1, r2
                        registers[op1] ^= registers[op2];
                        _flags = (byte)(registers[op1] == 0 ? 0x01 : 0);
                        break;
                    case 0x08:  // INC r
                        {
                            int result = registers[op1] + 1;
                            registers[op1] = (byte)(result & 0xFF);
                            _flags = (byte)((result > 255 ? 0x02 : 0) | (registers[op1] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x09:  // DEC r
                        {
                            int result = registers[op1] - 1;
                            registers[op1] = (byte)(result & 0xFF);
                            _flags = (byte)((result < 0 ? 0x02 : 0) | (registers[op1] == 0 ? 0x01 : 0));
                        }

                        break;
                    case 0x0A:  // JMP addr
                        _pc = operand;
                        break;
                    case 0x0B:  // JZ addr
                        if ((_flags & 0x01) != 0)
                        {
                            _pc = operand;
                        }

                        break;
                    case 0x0C:  // JC addr
                        if ((_flags & 0x02) != 0)
                        {
                            _pc = operand;
                        }

                        break;
                    case 0x0D:  // HALT
                        running = false;
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid opcode: {opcode}");
                }
            }
        }

        private void DumpRegisters()
        {
            Console.Write($"PC: {_pc} ");
            for (int i = 0; i < registers.Length; i++)
            {
                Console.Write($"R{i}: {registers[i]:X2} ");
            }

            Console.Write($"Flags: {_flags:X2}");
            Console.WriteLine();
        }
    }
}
