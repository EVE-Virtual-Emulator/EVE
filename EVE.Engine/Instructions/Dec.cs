using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Dec : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            switch (instruction.Mode)
            {
                case AddressingMode.IMMEDIATE:
                    var result = cpu.Memory.Register[instruction.RegisterOperand]--;
                    if (result == 0)
                        cpu.Memory.Flags |= 0x0001;
                    if (result < 0)
                        cpu.Memory.Flags |= 0x0004;
                    if (result == ushort.MaxValue)
                        cpu.Memory.Flags |= 0x0008;
                    break;
                default:
                    throw new Exception($"Addressing mode {instruction.Mode} is not supported.");
            }
        }
    }
}
