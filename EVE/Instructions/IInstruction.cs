namespace EVE.Instructions
{
    public interface IInstruction
    {        
        void Execute(Instruction instruction, Cpu cpu);
    }
}
