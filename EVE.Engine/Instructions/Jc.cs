using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Jc : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            if ((cpu.Flags & 0x02) != 0)
            {
                cpu.Pc = instruction.Operand;
            }
        }
    }
}
