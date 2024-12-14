using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.SharedKernel
{
    public class Instruction
    {
        public byte Opcode { get; set; }
        public byte Operand { get; set; }
        public byte LowOperand { get => (byte)(Operand & 0x0F); }
        public byte HighOperand { get => (byte)(Operand >> 4); }
    }
}
