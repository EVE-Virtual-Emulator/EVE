using EVE.SDK;
using EVE.SDK.Contracts.Cpu;

namespace EVE.Engine.Instructions
{
    public class Sub : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //byte result = (byte)(cpu.Registers[instruction.HighOperand] - cpu.Registers[instruction.LowOperand]);
            //cpu.Registers[instruction.HighOperand] = (byte)(result & 0xFF);
            //cpu.Flags = (byte)((result < 0 ? 0x02 : 0) | (cpu.Registers[instruction.HighOperand] == 0 ? 0x01 : 0));

            // TODO: Implement other addressing modes.
        }
    }
}
