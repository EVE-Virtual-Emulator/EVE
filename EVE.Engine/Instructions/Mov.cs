using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Mov : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            switch (instruction.Mode)
            {
                case AddressingMode.IMMEDIATE:
                    cpu.Memory.Register[instruction.RegisterOperand] = cpu.Memory.Register[instruction.DataOperand];
                    break;
                case AddressingMode.DIRECT:
                    cpu.Memory.Register[instruction.RegisterOperand] = cpu.Memory.Register[cpu.Memory.Read(instruction.DataOperand)];
                    break;
                case AddressingMode.INDIRECT:
                    cpu.Memory.Register[instruction.RegisterOperand] = cpu.Memory.Register[cpu.Memory.Read(cpu.Memory.Register[instruction.DataOperand])];
                    break;
                default:
                    break;
            }
        }
    }
}
