namespace EVE.Instructions
{
    public class Jmp : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Pc = instruction.Operand;
        }
    }
}
