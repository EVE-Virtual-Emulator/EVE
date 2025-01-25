using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Pop : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Memory.Pc = Convert.ToUInt16(cpu.Memory.PopStack());
        }
    }
}
