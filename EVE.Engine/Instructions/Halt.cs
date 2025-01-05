using EVE.SDK;

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
