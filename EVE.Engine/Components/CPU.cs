using EVE.SDK;
using EVE.Engine.Providers;

namespace EVE.Engine.Components
{
    public class Cpu : ICpu
    {
        public IMemory Memory { get; set; }
        public Instruction Instruction { get; set; }  // opcode and operand (high byte is opcode, low byte is operand)
        //public ushort[] Registers { get; set; }  // 12 general purpose registers, R0-R11, each of which can hold a byte and be used as a base register for addressing modes
        //public ushort Pc { get; set; }  // program counter (points to next instruction)
        //public int Ir { get; set; }  // instruction register (holds current instruction)
        //public ushort Sp { get; set; }  // stack pointer (points to top of stack, where stack hold address of instruction for RET opcode)
        //public ushort Flags { get; set; } // bit 0 = zero flag, bit 1 = carry flag
        public bool Running { get; set; }

        private InstructionSetProvider _instructionSetProvider;

        public Cpu(IMemory memory, InstructionSetProvider instructionSetProvider)
        {
            Running = true;
            Memory = memory;
            //Registers = new ushort[12];
            //Pc = MemoryRegion.ROM_START;
            //Ir = 0;
            //Sp = MemoryRegion.STACK_START;
            //Flags = 0;
            Instruction = new Instruction { Value = 0 };
            _instructionSetProvider = instructionSetProvider;
        }

        public void Run(bool withDebug)
        {
            while (Running)
            {
                if (withDebug)
                {
                    DumpRegisters();
                }

                Fetch();
                string methodName = Decode();
                Execute(methodName);
            }
        }

        private void Fetch()
        {
            //int opcodeHighHigh = Memory.Read(Pc) << 24;
            //int opcodeHighLow = Memory.Read(Pc + 1) << 16;
            //int opcodeLowHigh = Memory.Read(Pc + 2) << 8;
            //int opcodeLowLow = Memory.Read(Pc + 3);
            int opcodeHighHigh = Memory.Read(MemoryRegion.PC) << 24;
            int opcodeHighLow = Memory.Read(MemoryRegion.PC + 1) << 16;
            int opcodeLowHigh = Memory.Read(MemoryRegion.PC + 2) << 8;
            int opcodeLowLow = Memory.Read(MemoryRegion.PC + 3);
            Memory.WriteRegister(MemoryRegion.IR, opcodeHighHigh | opcodeHighLow | opcodeLowHigh | opcodeLowLow);
            Memory.WriteRegister(MemoryRegion.PC, Memory.Pc + 4);
            Instruction.Value = Memory.ReadRegister(MemoryRegion.IR);

            //Ir = (opcodeHighHigh | opcodeHighLow | opcodeLowHigh | opcodeLowLow);
            //Pc += 4;
            //Instruction.Value = Ir;
        }

        private string Decode()
        {
            foreach (var pair in _instructionSetProvider.MachineCodeMnemonicPair)
            {
                if (pair.Key == Instruction.Opcode)
                {
                    return pair.Value;
                }
            }

            return string.Empty;
        }

        private void Execute(string className)
        {
            
            foreach (var instructionHandler in _instructionSetProvider.InstructionHandlers)
            {
                if (instructionHandler.GetType().Name == className)
                {
                    instructionHandler.Execute(Instruction, this);
                    return;
                }
            }

            Type type = Type.GetType("EVE.Engine.Instructions." + className);
            var instance = (IInstructionHandler)Activator.CreateInstance(type);
            instance.Execute(Instruction, this);
        }

        private void DumpRegisters()
        {
            Console.Write($"PC: {Memory.ReadRegister(MemoryRegion.PC)} ");
            for (int i = 0; i < Memory.Registers.Length; i++)
            {
                Console.Write($"R{i}: {Memory.ReadRegister((ushort)i):X2} ");
            }
            Console.Write($"IR: {Memory.ReadRegister(MemoryRegion.IR):X8} ");
            Console.Write($"SP: {Memory.ReadRegister(MemoryRegion.SP):X2} ");
            Console.Write($"Flags: {Flags:X2}");
            Console.WriteLine();
        }
    }
}

// TODO: Implement Bus component to connect CPU and Memory components.  Instructions will be transferred on the Bus.
// TODO: Fix Indirect addressing mode to also allow for address of register to also be used as operand.
