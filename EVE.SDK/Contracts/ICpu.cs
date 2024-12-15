namespace EVE.SDK
{
    public interface ICpu
    {
        Instruction Instruction { get; set; }
        byte[] Registers { get; set; }
        ushort Pc { get; set; }
        ushort Ir { get; set; }
        ushort Sp { get; set; }
        byte Flags { get; set; }
        bool Running { get; set; }

        void Run(bool withDebug);
    }
}
