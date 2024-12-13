namespace EVE.Instructions
{
    public class Jc : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            if ((cpu.Flags & 0x02) != 0)
            {
                cpu.PC = instruction.Operand;
            }
        }
    }
}
