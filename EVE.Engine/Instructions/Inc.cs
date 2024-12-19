using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Inc : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //int result = cpu.Registers[instruction.HighOperand] + 1;
            //cpu.Registers[instruction.HighOperand] = (byte)(result & 0xFF);
            //cpu.Flags = (byte)((result > 255 ? 0x02 : 0) | (cpu.Registers[instruction.LowOperand] == 0 ? 0x01 : 0));

            // TODO: Implement other addressing modes.
        }
    }
}
