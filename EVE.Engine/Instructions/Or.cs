using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Or : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            if (instruction.Mode == AddressingMode.IMMEDIATE)
            {

            }
            else if (instruction.Mode == AddressingMode.DIRECT)
            {

            }

            //cpu.Registers[instruction.] |= cpu.Registers[instruction.LowOperand];
            //cpu.Flags = (byte)(cpu.Registers[instruction.HighOperand] == 0 ? 0x01 : 0);

            // TODO: Implement other addressing modes.
        }
    }
}
