namespace EVE.SDK
{
    public interface ICpu
    {
        IMemory Memory { get; set; }
        Instruction Instruction { get; set; }
        ushort[] Registers { get; set; }
        ushort Pc { get; set; }
        int Ir { get; set; }
        ushort Sp { get; set; }
        ushort Flags { get; set; }
        bool Running { get; set; }

        void Run(bool withDebug);
    }
}
