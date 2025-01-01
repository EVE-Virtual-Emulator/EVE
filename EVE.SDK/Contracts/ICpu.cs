namespace EVE.SDK
{
    public interface ICpu
    {
        IMemory Memory { get; set; }
        Instruction Instruction { get; set; }
        bool Running { get; set; }

        void Run(bool withDebug);
    }
}
