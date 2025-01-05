namespace EVE.SDK
{
    public abstract class CpuBase : ICpu
    {
        public bool Running { get; set; }
        public IMemory Memory { get; set; }
        public Instruction Instruction { get; set; }

        public CpuBase(IMemory memory)
        {
            Running = true;
            Memory = memory;
            Instruction = new Instruction { Value = 0 };
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

        protected abstract void Fetch();
        protected abstract string Decode();
        protected abstract void Execute(string methodName);
        protected abstract void DumpRegisters();
    }
}
