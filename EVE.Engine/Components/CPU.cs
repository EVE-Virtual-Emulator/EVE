using EVE.SDK;
using EVE.Engine.Providers;

namespace EVE.Engine.Components
{
    public class Cpu : CpuBase
    {
        //public IMemory Memory { get; set; }
        //public Instruction Instruction { get; set; }
        //public bool Running { get; set; }

        private InstructionSetProvider _instructionSetProvider;

        public Cpu(IMemory memory, InstructionSetProvider instructionSetProvider): base(memory)
        {
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

        protected override void Fetch()
        {
            int highBits = Memory.Read(Memory.Pc) << 16;
            int lowBits = Memory.Read(Memory.Pc + 1);
            Memory.Write(MemoryRegion.IR, highBits | lowBits);   // Load instruction into IR
            IncrementPc();
            Instruction.Value = Memory.Read(MemoryRegion.IR);
        }

        protected override string Decode()
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

        protected override void Execute(string className)
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

        private void IncrementPc()
        {
            Memory.Write(MemoryRegion.PC, Memory.Pc + 2);
        }

        protected override void DumpRegisters()
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
