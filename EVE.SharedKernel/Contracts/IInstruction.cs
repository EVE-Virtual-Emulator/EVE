using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.SharedKernel.Contracts
{
    public interface IInstruction
    {
        void Execute(IInstruction instruction, ICpu cpu);
    }
}
