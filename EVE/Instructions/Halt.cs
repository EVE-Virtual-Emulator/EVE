namespace EVE.Instructions
{
    public class Halt : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            cpu.Running = false;
        }
    }
}
