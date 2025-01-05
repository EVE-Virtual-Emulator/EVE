using EVE.SDK;
using EVE.SDK.Contracts.Cpu;

namespace EVE.Engine.Instructions
{
    public class Jz : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //if ((cpu.Flags & 0x01) != 0)
            //{
            //    cpu.Pc = instruction.Operand;
            //}

            // TODO: Implement other addressing modes.
        }
    }
}
