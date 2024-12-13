namespace EVE.Instructions
{
    public class Sub : IInstruction
    {
        public void Execute(Instruction instruction, Cpu cpu)
        {
            byte result = (byte)(cpu.Registers[instruction.HighOperand] - cpu.Registers[instruction.LowOperand]);
            cpu.Registers[instruction.HighOperand] = (byte)(result & 0xFF);
            cpu.Flags = (byte)((result < 0 ? 0x02 : 0) | (cpu.Registers[instruction.HighOperand] == 0 ? 0x01 : 0));
        }
    }
}
