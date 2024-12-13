namespace EVE.Instructions
{
    public class Inc : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            int result = cpu.Registers[instruction.HighOperand] + 1;
            cpu.Registers[instruction.HighOperand] = (byte)(result & 0xFF);
            cpu.Flags = (byte)((result > 255 ? 0x02 : 0) | (cpu.Registers[instruction.LowOperand] == 0 ? 0x01 : 0));
        }
    }
}
