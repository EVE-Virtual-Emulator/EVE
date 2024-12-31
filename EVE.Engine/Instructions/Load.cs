using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Load : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            //switch (instruction.Mode)
            //{
            //    case AddressingMode.IMMEDIATE:
            //        cpu.Registers[instruction.RegisterOperand] = instruction.DataOperand;
            //        break;
            //    case AddressingMode.DIRECT:
            //        cpu.Registers[instruction.RegisterOperand] = cpu.Memory.Read(instruction.DataOperand);
            //        break;
            //    case AddressingMode.INDIRECT:
            //        cpu.Registers[instruction.RegisterOperand] = cpu.Memory.Read(cpu.Registers[instruction.DataOperand]);
            //        break;
            //    case AddressingMode.INDEXED:
            //        cpu.Registers[instruction.RegisterOperand] = cpu.Memory.Read(cpu.Registers[instruction.DataOperand] + instruction.DataOperand);
            //        break;
            //    default:
            //        break;
            //}

            // TODO: Implement other addressing modes
        }
    }
}
