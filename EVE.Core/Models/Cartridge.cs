using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Core.Models
{
    public class Cartridge
    {
        public string Name { get; set; }
        public byte[] Program { get; set; }
        public ushort Size { get; set; }
    }
}
