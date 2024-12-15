using EVE.SDK;
using EVE.Engine.Providers;

namespace EVE.Engine.Components
{
    public class Cpu : ICpu
    {
        public IMemory Memory { get; set; }
        public Instruction Instruction { get; set; }  // opcode and operand (high byte is opcode, low byte is operand)
        public byte[] Registers { get; set; }  // R0, R1, R2, R3 (general purpose registers)
        public ushort Pc { get; set; }  // program counter (points to next instruction)
        public ushort Ir { get; set; }  // instruction register (holds current instruction)
        public ushort Sp { get; set; }  // stack pointer (points to top of stack, where stack hold address of instruction for RET opcode)
        public byte Flags { get; set; } // bit 0 = zero flag, bit 1 = carry flag
        public bool Running { get; set; }

        private InstructionSetProvider _instructionSetProvider;

        public Cpu(IMemory memory, InstructionSetProvider instructionSetProvider)
        {
            Running = true;
            Memory = memory;
            Registers = new byte[4];
            Pc = MemoryRegion.ROM_START;
            Ir = 0;
            Sp = MemoryRegion.STACK_START;
            Flags = 0;
            Instruction = new Instruction() { Opcode = 0, Operand = 0 };
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
            ushort opcode = (ushort)(Memory.Read(Pc) << 8);
            ushort operand = Memory.Read(Pc + 1);
            Ir = opcode |= operand;
            Pc += 2;

            Instruction.Opcode = (byte)((Ir >> 8) & 0xFF);
            Instruction.Operand = (byte)(Ir & 0xFF);
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
            Console.Write($"PC: {Pc} ");
            for (int i = 0; i < Registers.Length; i++)
            {
                Console.Write($"R{i}: {Registers[i]:X2} ");
            }

            Console.Write($"SP: {Sp:X2} ");

            Console.Write($"Flags: {Flags:X2}");
            Console.WriteLine();
        }
    }
}

// TODO: Implement Bus component to connect CPU and Memory components.  Instructions will be transferred on the Bus.
