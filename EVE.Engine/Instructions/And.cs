using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class And : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            switch (instruction.Mode)
            {
                case AddressingMode.IMMEDIATE:
                    {
                        var result = cpu.Memory.Register[instruction.RegisterOperand] & instruction.DataOperand;
                        if (result == 0)
                        {
                            cpu.Memory.Flags |= 0x0001;
                        }

                        cpu.Memory.Register[instruction.RegisterOperand] = result;
                        break;
                    }
                case AddressingMode.DIRECT:
                    {
                        var result = cpu.Memory.Register[instruction.RegisterOperand] & cpu.Memory.Read(instruction.DataOperand);
                        if (result == 0)
                        {
                            cpu.Memory.Flags |= 0x0001;
                        }

                        cpu.Memory.Register[instruction.RegisterOperand] = result;
                        break;
                    }
                case AddressingMode.INDIRECT:
                    {
                        var result = cpu.Memory.Register[instruction.RegisterOperand] & cpu.Memory.Read(cpu.Memory.Read(instruction.DataOperand));
                        if (result == 0)
                        {
                            cpu.Memory.Flags |= 0x0001;
                        }

                        cpu.Memory.Register[instruction.RegisterOperand] = result;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
