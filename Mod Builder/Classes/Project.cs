using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_Builder.Classes
{
    [Serializable()]
    public class Project
    {
        List<Instruction.InstructionBase> instructions;
    }
}
