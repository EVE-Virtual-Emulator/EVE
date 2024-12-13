namespace EVE.Instructions
{
    public class Load : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            cpu.Registers[instruction.HighOperand] = instruction.LowOperand;
        }
    }
}
