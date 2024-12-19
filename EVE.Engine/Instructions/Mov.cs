using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Mov : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Registers[instruction.RegisterOperand] = cpu.Registers[instruction.DataOperand];
        }
    }
}
