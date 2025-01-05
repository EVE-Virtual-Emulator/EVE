using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Pop : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //cpu.Sp++;
            //cpu.Pc = cpu.Memory.Read(cpu.Sp);
            //cpu.Sp = 0;

            // TODO: Implement other addressing modes.
        }
    }
}
