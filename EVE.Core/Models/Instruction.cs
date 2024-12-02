namespace EVE.Core.Models
{
    public class Instruction
    {
        public byte Opcode { get; set; }
        public byte Operand { get; set; }
        public byte Op1 { get => (byte)(Operand >> 4); }
        public byte Op2 { get => (byte)(Operand & 0xFF); }
    }
}
