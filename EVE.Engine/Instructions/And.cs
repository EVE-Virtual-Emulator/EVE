using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class And : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Registers[instruction.HighOperand] &= cpu.Registers[instruction.LowOperand];
            cpu.Flags = (byte)(cpu.Registers[instruction.HighOperand] == 0 ? 0x01 : 0);
        }
    }
}
