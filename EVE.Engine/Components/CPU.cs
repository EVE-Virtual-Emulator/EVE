using EVE.SDK;
using EVE.Engine.Providers;

namespace EVE.Engine.Components
{
    public class Cpu : ICpu
    {
        public IMemory Memory { get; set; }
        public Instruction Instruction { get; set; }
        public bool Running { get; set; }

        private InstructionSetProvider _instructionSetProvider;

        public Cpu(IMemory memory, InstructionSetProvider instructionSetProvider)
        {
            Running = true;
            Memory = memory;
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
            int opcodeHighHigh = Memory.Read(Memory.Pc) << 24;
            int opcodeHighLow = Memory.Read(Memory.Pc + 1) << 16;
            int opcodeLowHigh = Memory.Read(Memory.Pc + 2) << 8;
            int opcodeLowLow = Memory.Read(Memory.Pc + 3);
            Memory.Write(MemoryRegion.IR, opcodeHighHigh | opcodeHighLow | opcodeLowHigh | opcodeLowLow);
            Memory.Write(MemoryRegion.PC, Memory.Pc + 4);
            Instruction.Value = Memory.Read(MemoryRegion.IR);
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
            Console.Write($"PC: {Memory.Read(MemoryRegion.PC)} ");
            for (int i = 0; i < Memory.Register.Length; i++)
            {
                Console.Write($"R{i}: {Memory.Read((ushort)i):X2} ");
            }
            Console.Write($"IR: {Memory.Read(MemoryRegion.IR):X8} ");
            Console.Write($"SP: {Memory.Read(MemoryRegion.SP):X2} ");
            Console.Write($"Flags: {Memory.Read(MemoryRegion.FLAGS):X2}");
            Console.WriteLine();
        }
    }
}

// TODO: Implement Bus component to connect CPU and Memory components.  Instructions will be transferred on the Bus.
// TODO: Fix Indirect addressing mode to also allow for address of register to also be used as operand.
