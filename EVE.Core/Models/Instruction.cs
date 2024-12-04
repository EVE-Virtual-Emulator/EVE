namespace EVE.Core.Models
{
    public class Instruction
    {
        public byte Opcode { get; set; }
        public byte Operand { get; set; }
        public byte LowOperand { get => (byte)(Operand & 0x0F); }
        public byte HighOperand { get => (byte)(Operand >> 4); }
    }
}
