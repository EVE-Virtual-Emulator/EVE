
namespace EVE.Instructions
{
    public class Dec : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            cpu.Registers[instruction.HighOperand] |= cpu.Registers[instruction.LowOperand];
            cpu.Flags = (byte)(cpu.Registers[instruction.HighOperand] == 0 ? 0x01 : 0);
        }
    }
}
