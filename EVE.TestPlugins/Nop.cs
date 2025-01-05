using EVE.SDK;
using EVE.SDK.Contracts.Cpu;

namespace EVE.TestPlugins
{
    public class Nop : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            return;
        }
    }
}
