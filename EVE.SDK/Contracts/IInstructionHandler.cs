namespace EVE.SDK
{
    public interface IInstructionHandler
    {
        void Execute(Instruction instruction, ICpu cpu);
    }
}
