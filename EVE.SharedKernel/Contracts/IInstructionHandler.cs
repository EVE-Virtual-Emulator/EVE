namespace EVE.SharedKernel
{
    public interface IInstructionHandler
    {
        void Execute(Instruction instruction, ICpu cpu);
    }
}
