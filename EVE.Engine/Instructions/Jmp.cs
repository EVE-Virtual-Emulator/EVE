using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Jmp : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Memory.Pc = instruction.DataOperand;
        }
    }
}
