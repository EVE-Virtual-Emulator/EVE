namespace EVE.SDK
{
    /// <summary>
    /// Defines a handler for executing instructions on a CPU.
    /// </summary>
    public interface IInstructionHandler
    {
        /// <summary>
        /// Executes the given instruction on the specified CPU.
        /// </summary>
        /// <param name="instruction">The instruction to execute.</param>
        /// <param name="cpu">The CPU on which to execute the instruction.</param>
        void Execute(Instruction instruction, ICpu cpu);
    }
}
