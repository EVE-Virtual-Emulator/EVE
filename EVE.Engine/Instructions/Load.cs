using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Load : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            switch (instruction.Mode) 
            {
                case AddressingMode.IMMEDIATE:
                    cpu.Memory.Register[instruction.RegisterOperand] = instruction.DataOperand;
                    break;
                case AddressingMode.DIRECT:
                    cpu.Memory.Register[instruction.RegisterOperand] = cpu.Memory.Read(instruction.DataOperand);
                    break;
                case AddressingMode.INDIRECT:
                    cpu.Memory.Register[instruction.RegisterOperand] = cpu.Memory.Read(cpu.Memory.Read(instruction.DataOperand));
                    break;
                case AddressingMode.INDEXED:
                    cpu.Memory.Register[instruction.RegisterOperand] = cpu.Memory.Read(cpu.Memory.Read(instruction.DataOperand) + instruction.DataOperand);
                    break;
                default:
                    break;
            }
        }
    }
}
