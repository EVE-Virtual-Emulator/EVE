using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Jz : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            if ((cpu.Memory.Flags & 0x0001) == 0)
            {
                cpu.Memory.Pc = instruction.DataOperand;
            }
        }
    }
}
