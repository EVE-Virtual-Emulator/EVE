using EVE.SDK;
using EVE.SDK.Contracts.Cpu;

namespace EVE.Engine.Instructions
{
    public class Jmp : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //cpu.Pc = instruction.Operand;

            // TODO: Implement other addressing modes.
        }
    }
}
