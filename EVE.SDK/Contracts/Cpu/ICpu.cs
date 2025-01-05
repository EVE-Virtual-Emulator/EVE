namespace EVE.SDK
{
    /// <summary>
    /// Represents a CPU interface with properties for memory, instruction, and running state.
    /// Provides a method to run the CPU with optional debugging.
    /// </summary>
    public interface ICpu
    {
        /// <summary>
        /// Gets or sets the memory associated with the CPU.
        /// </summary>
        IMemory Memory { get; set; }

        /// <summary>
        /// Gets or sets the current instruction being executed by the CPU.
        /// </summary>
        Instruction Instruction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the CPU is currently running.
        /// </summary>
        bool Running { get; set; }

        /// <summary>
        /// Runs the CPU with an option to enable debugging.
        /// </summary>
        /// <param name="withDebug">If set to <c>true</c>, debugging is enabled.</param>
        void Run(bool withDebug);
    }
}
