using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Add : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //byte result = (byte)(cpu.Registers[instruction.HighOperand] + cpu.Registers[instruction.LowOperand]);
            //cpu.Registers[instruction.HighOperand] = (byte)(result & 0xFF);
            //cpu.Flags = (byte)((result > 255 ? 0x02 : 0) | (cpu.Registers[instruction.HighOperand] == 0 ? 0x01 : 0));

            // TODO: Implement other addressing modes.
            switch (instruction.Mode)
            {
                case AddressingMode.IMMEDIATE:
                    {
                        ushort result = (ushort)(cpu.Registers[instruction.RegisterOperand] + instruction.DataOperand);
                        if (result > 0xFFFF)
                        {
                            cpu.Flags = 0x02;
                        }
                        else if (result == 0)
                        {
                            cpu.Flags = 0x01;
                        }
                        else
                        {
                            cpu.Flags = 0x00;
                        }

                        cpu.Registers[instruction.RegisterOperand] = result;
                        break;
                    }

                case AddressingMode.DIRECT:
                    {
                        ushort result = (ushort)(cpu.Registers[instruction.RegisterOperand] + cpu.Memory.Read(instruction.DataOperand));
                        if (result > 0xFFFF)
                        {
                            cpu.Flags = 0x02;
                        }
                        else if (result == 0)
                        {
                            cpu.Flags = 0x01;
                        }
                        else
                        {
                            cpu.Flags = 0x00;
                        }

                        cpu.Registers[instruction.RegisterOperand] = result;
                        break;
                    }

                case AddressingMode.INDIRECT:
                    {
                        ushort result = (ushort)(cpu.Registers[instruction.RegisterOperand] + cpu.Memory.Read(cpu.Memory.Read(instruction.DataOperand)));
                        if (result > 0xFFFF)
                        {
                            cpu.Flags = 0x02;
                        }
                        else if (result == 0)
                        {
                            cpu.Flags = 0x01;
                        }
                        else
                        {
                            cpu.Flags = 0x00;
                        }

                        cpu.Registers[instruction.RegisterOperand] = result;
                        break;
                    }

                case AddressingMode.INDEXED:
                    {
                        ushort result = (ushort)(cpu.Registers[instruction.RegisterOperand] + cpu.Memory.Read(cpu.Registers[instruction.DataOperand] + instruction.DataOperand));
                        if (result > 0xFFFF)
                        {
                            cpu.Flags = 0x02;
                        }
                        else if (result == 0)
                        {
                            cpu.Flags = 0x01;
                        }
                        else
                        {
                            cpu.Flags = 0x00;
                        }

                        cpu.Registers[instruction.RegisterOperand] = result;
                        break;
                    }

                default:
                    break;
            }
        }
    }
}
