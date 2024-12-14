namespace EVE.Instructions
{
    public class Mov : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Registers[instruction.HighOperand] = cpu.Registers[instruction.LowOperand];
        }
    }
}
