namespace EVE.Instructions
{
    public class Halt : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Running = false;
        }
    }
}
