using EVE.SDK;
using EVE.SDK.Contracts.Cpu;

namespace EVE.Engine.Instructions
{
    public class Halt : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Running = false;
        }
    }
}
