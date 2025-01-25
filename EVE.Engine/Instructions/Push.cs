﻿using EVE.SDK;

namespace EVE.Engine.Instructions
{
    public class Push : IInstructionHandler
    {
        public void Execute(Instruction instruction, ICpu cpu)
        {
            cpu.Memory.PushStack(instruction.DataOperand);
        }
    }
}
