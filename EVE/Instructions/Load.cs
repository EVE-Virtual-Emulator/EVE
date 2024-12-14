namespace EVE.Instructions
{
    public class Load : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Registers[instruction.HighOperand] = instruction.LowOperand;
        }
    }
}
