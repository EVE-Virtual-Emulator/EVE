﻿using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Push : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Memory.Write(cpu.Sp, instruction.LowOperand);
            cpu.Sp--;
        }
    }
}
