using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mod_Builder.Classes.Instruction
{
    class ReplaceInstruction : InstructionBase
    {
        override public string applyTestEdit(string filename)
        {
            if (this.testInstruction(filename) == false)
                throw new TestInstructionFailedException("Could not apply the edit because testing the instruction failed.");

            string contents = File.ReadAllText(filename);

            return ReplaceFirst(contents, this.codeSearch, this.codeAdd);
        }

        // Gathered from http://stackoverflow.com/questions/141045/how-do-i-replace-the-first-instance-of-a-string-in-net
        string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
                return text;
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
