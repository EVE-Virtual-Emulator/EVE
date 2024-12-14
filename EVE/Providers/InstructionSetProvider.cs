using System.Text;
using System.Globalization;
using System.Reflection;

namespace EVE.Providers
{
    public class InstructionSetProvider
    {
        public Dictionary<byte, string> MachineCodeMnemonicPair { get; set; }
        public List<IInstructionHandler> InstructionHandlers { get; set; }

        public InstructionSetProvider()
        {
            MachineCodeMnemonicPair = GetInstructionMap();
            InstructionHandlers = GetInstructionHandlers();
        }

        public void PrintInstructionSet()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in MachineCodeMnemonicPair)
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
                neumonic = neumonic.Substring(0, 1).ToUpper() + neumonic.Substring(1).ToLower();
                byteNeumonicPair.Add(byte.Parse(opcodeValue, NumberStyles.HexNumber), neumonic);
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
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterfaces().Contains(typeof(IInstructionHandler)))
                    {
                        var instance = (IInstructionHandler)Activator.CreateInstance(type);
                        instructionHandlers.Add(instance);
                    }
                }
            }

            return instructionHandlers;
        }
    }
}
