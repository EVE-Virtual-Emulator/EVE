using EVE.SharedKernel;

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
