global using EVE.Engine.Components;
global using EVE.Engine.Providers;
global using EVE.SDK;

namespace EVE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte[] program =
            {
                0x01, 0x00, 0x00, 0xFF, // Load 255 into R0
                0x01, 0x00, 0x00, 0x01, // Load 1 into R1
                0x0D, 0x00, 0x00, 0x00  // Halt
            };

            IMemory memory = new Memory();
            memory.LoadProgram(program);

            ICpu cpu = new Cpu(memory, new InstructionSetProvider());
            cpu.Run(true);

            Console.ReadLine();
        }
    }
}