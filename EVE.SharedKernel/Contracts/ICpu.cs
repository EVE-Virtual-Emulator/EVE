namespace EVE.SharedKernel
{
    public interface ICpu
    {
        byte[] Registers { get; set; }
        ushort Pc { get; set; }
        ushort Ir { get; set; }
        byte Flags { get; set; }
        bool Running { get; set; }
        void LoadProgram(byte[] program);
        void Run(bool withDebug);
    }
}
