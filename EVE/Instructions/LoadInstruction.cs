using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Instructions
{
    public class LoadInstruction : IInstruction
    {
        public void Execute(CPU cpu, Instruction instruction)
        {
            cpu.Registers[instruction.HighOperand] = instruction.LowOperand;
        }
    }
}
