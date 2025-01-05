global using EVE.Engine.Components;
global using EVE.Engine.Providers;
global using EVE.SDK;
using EVE.SDK.Contracts.Cpu;

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