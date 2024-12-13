namespace EVE.Instructions
{
    public class Jmp : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            cpu.PC = instruction.Operand;
        }
    }
}
