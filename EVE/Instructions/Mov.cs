namespace EVE.Instructions
{
    public class Mov : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            cpu.Registers[instruction.HighOperand] = cpu.Registers[instruction.LowOperand];
        }
    }
}
