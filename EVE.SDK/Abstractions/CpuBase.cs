namespace EVE.SDK
{
    /// <summary>
    /// Represents the base class for a CPU, providing core functionality for running instructions.
    /// </summary>
    public abstract class CpuBase : ICpu
    {
        /// <summary>
        /// Gets or sets a value indicating whether the CPU is running.
        /// </summary>
        public bool Running { get; set; }

        /// <summary>
        /// Gets or sets the memory associated with the CPU.
        /// </summary>
        public IMemory Memory { get; set; }

        /// <summary>
        /// Gets or sets the current instruction being executed by the CPU.
        /// </summary>
        public Instruction Instruction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CpuBase"/> class with the specified memory.
        /// </summary>
        /// <param name="memory">The memory to be used by the CPU.</param>
        public CpuBase(IMemory memory)
        {
            Running = true;
            Memory = memory;
            Instruction = new Instruction { Value = 0 };
        }

        /// <summary>
        /// Runs the CPU, fetching, decoding, and executing instructions in a loop.
        /// </summary>
        /// <param name="withDebug">If set to <c>true</c>, dumps the registers before each instruction execution.</param>
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

        /// <summary>
        /// Fetches the next instruction to be executed.
        /// </summary>
        protected abstract void Fetch();

        /// <summary>
        /// Decodes the fetched instruction and returns the method name to be executed.
        /// </summary>
        /// <returns>The method name to be executed.</returns>
        protected abstract string Decode();

        /// <summary>
        /// Executes the specified method.
        /// </summary>
        /// <param name="methodName">The name of the method to execute.</param>
        protected abstract void Execute(string methodName);

        /// <summary>
        /// Dumps the current state of the CPU registers.
        /// </summary>
        protected abstract void DumpRegisters();
    }
}
