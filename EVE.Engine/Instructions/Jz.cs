using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Jz : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            if ((cpu.Flags & 0x01) != 0)
            {
                cpu.Pc = instruction.Operand;
            }
        }
    }
}
