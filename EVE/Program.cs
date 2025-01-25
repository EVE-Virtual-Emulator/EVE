global using EVE.Engine.Components;
global using EVE.Engine.Providers;
global using EVE.SDK;

namespace EVE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            short[] program =
            {
                0x0100, 0x00FF, // Load 255 into R0
                0x0110, 0x0001, // Load 1 into R1
                0x0800, 0x0000, // Increment R0
                0x0810, 0x0001, // Increment R1
                0x0300, 0x0001, // Add R0 and R1, store result in R0
                0x0D00, 0x0000  // Halt
            };

            IMemory memory = new Memory();
            memory.LoadProgram(program);

            ICpu cpu = new Cpu(memory, new InstructionSetProvider());
            cpu.Run(true);

            Console.ReadLine();
        }
    }
}