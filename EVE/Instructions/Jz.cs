namespace EVE.Instructions
{
    public class Jz : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            if ((cpu.Flags & 0x01) != 0)
            {
                cpu.PC = instruction.Operand;
            }
        }
    }
}
