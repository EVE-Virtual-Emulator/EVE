namespace EVE.SharedKernel.Contracts
{
    public abstract class AbstractCpu
    {
        public bool Running { get; set; }

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

// TODO: Switch ICpu to inherit from AbstractCpu, so that it can use the strategy pattern to implement the Fetch, Decode, Execute, and DumpRegisters methods.
// This will allow other developers to create their own CPU implementations by inheriting from AbstractCpu and implementing the abstract methods.