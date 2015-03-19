using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mod_Builder.Classes.Instruction
{
    [Serializable]
    class AddAfterInstruction : InstructionBase
    {
        public override string applyTestEdit(string filename)
        {
            if (this.testInstruction(filename) == false)
                throw new TestInstructionFailedException("Could not apply the edit because testing the instruction failed.");

            string contents = File.ReadAllText(filename);

            return contents.Insert(contents.IndexOf(this.codeSearch) + this.codeSearch.Length, this.codeAdd);
        }
    }
}
