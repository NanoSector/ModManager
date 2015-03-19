using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mod_Builder.Classes.Instruction
{
    [Serializable]
    class EndOfFileInstruction : InstructionBase
    {
        new public string codeSearch = "";

        public override string applyTestEdit(string filename)
        {
            if (this.testInstruction(filename) == false)
                throw new TestInstructionFailedException("Could not apply the edit because testing the instruction failed.");

            string contents = File.ReadAllText(filename);

            if (contents.Trim().Substring(contents.Length - 2) == "?>")
                return contents.Insert(contents.LastIndexOf("?>"), this.codeAdd);
            else
                return contents + this.codeAdd;
        }
    }
}
