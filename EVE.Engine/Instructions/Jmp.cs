using EVE.SharedKernel;

namespace EVE.Engine.Instructions
{
    public class Jmp : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Pc = instruction.Operand;
        }
    }
}
