using System.Text;
using System.Globalization;
using System.Reflection;

namespace EVE.Providers
{
    public class InstructionSetProvider
    {
        public Dictionary<byte, string> ByteNeumonicPair { get; set; }
        public List<IInstructionHandler> InstructionHandlers { get; set; }

        public InstructionSetProvider()
        {
            ByteNeumonicPair = GetInstructionMap();
            InstructionHandlers = GetInstructionHandlers();
        }

        public void PrintInstructionSet()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ByteNeumonicPair)
            {
                sb.AppendLine($"{item.Key} : {item.Value}");
            }

            Console.WriteLine(sb.ToString());
        }

        private Dictionary<byte, string> GetInstructionMap()
        {
            
            string[] opcodes = File.ReadAllLines("ISA/instructionset.map");
            Dictionary<byte, string> byteNeumonicPair = new Dictionary<byte, string>();
            foreach (var opcode in opcodes)
            {
                var parts = opcode.Split(',');
                var opcodeValue = parts[0].Trim().Substring(2);
                var neumonic = parts[1].Trim();
                byteNeumonicPair.Add(byte.Parse(opcodeValue, NumberStyles.HexNumber), neumonic.ToLower());
            }

            return byteNeumonicPair;
        }

        private List<IInstructionHandler> GetInstructionHandlers()
        {
            List<IInstructionHandler> instructionHandlers = new();
            var dllPaths = Directory.GetFiles("ISA", "*.dll");
            foreach (var dllPath in dllPaths)
            {
                var assembly = Assembly.LoadFrom(dllPath);
                var type = assembly.GetType();
                var instance = Activator.CreateInstance(type);
                instructionHandlers.Add((IInstructionHandler)instance);
            }

            return instructionHandlers;
        }
    }
}
