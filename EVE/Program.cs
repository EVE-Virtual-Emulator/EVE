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
                //0x01, 0x05,  // Load 5 into R0
                //0x01, 0x17,  // Load 7 into R1
                //0x03, 0x01,  // Add R0 and R1 and store in R0
                //0x08, 0x00,  // Increment R0
                //0x0E, 0x00,  // No operation
                //0x0D         // Halt
                //0x02, 0x05,
                //0x02, 0x47,
                //0x1A
                0x01, 0x00, 0x00, 0xFF, // Load 255 into R0
                0x01, 0x00, 0x00, 0x01 // Load 1 into R1
            };

            IMemory memory = new Memory();
            memory.LoadProgram(program);

            ICpu cpu = new Cpu(memory, new InstructionSetProvider());
            cpu.Run(true);

            Console.ReadLine();
        }
    }
}