using EVE.Components;

namespace EVE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte[] program =
            {
                0x01, 0x05,
                0x08, 0x00,
                0x0D
            };

            CPU cpu = new CPU();
            cpu.LoadProgram(program);
            cpu.Run(true);
            Console.ReadLine();
        }
    }
}