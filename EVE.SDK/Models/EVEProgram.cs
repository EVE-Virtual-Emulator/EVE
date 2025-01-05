namespace EVE.SDK
{
    /// <summary>
    /// Represents an EVE program with a name, size, and data.
    /// </summary>
    public class EveProgram
    {
        /// <summary>
        /// Gets or sets the name of the EVE program.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the size of the EVE program.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the data of the EVE program.
        /// </summary>
        public short[] Data { get; set; }
    }
}
