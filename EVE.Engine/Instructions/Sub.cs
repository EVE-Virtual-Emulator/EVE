using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Sub : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            switch (instruction.Mode)
            {
                case AddressingMode.IMMEDIATE:
                    {
                        ushort result = (ushort)(cpu.Memory.Register[instruction.RegisterOperand] - instruction.DataOperand);
                        if (result == 0)
                        {
                            cpu.Memory.Flags |= 0x0001;
                        }
                        if (result < 0)
                        {
                            cpu.Memory.Flags |= 0x0004;
                        }
                        if (result > 0xFFFF)
                        {
                            cpu.Memory.Flags |= 0x0008;
                        }

                        cpu.Memory.Register[instruction.RegisterOperand] = result;
                        break;
                    }

                case AddressingMode.DIRECT:
                    {
                        ushort result = (ushort)(cpu.Memory.Register[instruction.RegisterOperand] - cpu.Memory.Read(instruction.DataOperand));
                        if (result == 0)
                        {
                            cpu.Memory.Flags |= 0x0001;
                        }
                        if (result < 0)
                        {
                            cpu.Memory.Flags |= 0x0004;
                        }
                        if (result > 0xFFFF)
                        {
                            cpu.Memory.Flags |= 0x0008;
                        }

                        cpu.Memory.Register[instruction.RegisterOperand] = result;
                        break;
                    }

                case AddressingMode.INDIRECT:
                    {
                        ushort result = (ushort)(cpu.Memory.Register[instruction.RegisterOperand] - cpu.Memory.Read(cpu.Memory.Read(instruction.DataOperand)));
                        if (result == 0)
                        {
                            cpu.Memory.Flags |= 0x0001;
                        }
                        if (result < 0)
                        {
                            cpu.Memory.Flags |= 0x0004;
                        }
                        if (result > 0xFFFF)
                        {
                            cpu.Memory.Flags |= 0x0008;
                        }

                        cpu.Memory.Register[instruction.RegisterOperand] = result;
                        break;
                    }

                default:
                    break;
            }
        }
    }
}
