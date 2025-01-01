using EVE.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Engine.Components
{
    public class SystemRamMemoryModule : IMemoryModule
    {
        public dynamic Read(ushort address)
        {
            throw new NotImplementedException();
        }

        public void Write(ushort address, dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}
