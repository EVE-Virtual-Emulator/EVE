using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Load : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            if (instruction.Mode == AddressingMode.IMMEDIATE)
            {
                cpu.Registers[instruction.RegisterOperand] = instruction.DataOperand;
            }
            else if (instruction.Mode == AddressingMode.DIRECT)
            {
                cpu.Registers[instruction.RegisterOperand] = cpu.Memory.Read(instruction.DataOperand);
            }

            // TODO: Implement other addressing modes
        }
    }
}
