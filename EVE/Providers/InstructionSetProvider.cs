using System.Text;
using System.Globalization;

namespace EVE.Providers
{
    public class InstructionSetProvider
    {
        public Dictionary<byte, string> ByteNeumonicPair { get; set; }

        public InstructionSetProvider()
        {
            ByteNeumonicPair = InitializeInstructionSet();
        }

        private Dictionary<byte, string> InitializeInstructionSet()
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

        public void PrintInstructionSet()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ByteNeumonicPair)
            {
                sb.AppendLine($"{item.Key} : {item.Value}");
            }
            
            Console.WriteLine(sb.ToString());
        }
    }
}
