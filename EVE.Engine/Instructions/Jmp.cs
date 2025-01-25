using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Jmp : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            switch (instruction.Mode)
            {
                case AddressingMode.IMMEDIATE:
                    cpu.Memory.Pc = instruction.DataOperand;
                    break;
                case AddressingMode.DIRECT:
                    cpu.Memory.Pc = cpu.Memory.Read(instruction.DataOperand);
                    break;
                case AddressingMode.INDIRECT:
                    cpu.Memory.Pc = cpu.Memory.Read(cpu.Memory.Read(instruction.DataOperand));
                    break;
            }
        }
    }
}
