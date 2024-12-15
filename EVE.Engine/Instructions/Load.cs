using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Load : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Registers[instruction.HighOperand] = instruction.LowOperand;
        }
    }
}
