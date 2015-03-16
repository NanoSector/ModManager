using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod_Builder.Classes.ProjectComponents;

namespace Mod_Builder.Classes
{
    [Serializable()]
    public class Project
    {
        public List<Instruction.InstructionBase> instructions;
        public string name = "";
        public string version = "";
        public string username = "";
        public string modID = "";
        public bool generateModID = true;
        public string compatibility;

        public Settings settings = new Settings();
    }
}
