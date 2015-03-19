using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mod_Builder.Classes.Instruction
{
    [Serializable]
    public abstract class InstructionBase
    {
        public string codeSearch = "";
        public string codeAdd = "";
        public string filename = "";
        public int id = 0;

        // Allow the user to set a custom name for it. Default name == filename + type
        public string name;

        public bool testInstruction(string filename)
        {
            // No file? No dice.
            if (!File.Exists(filename))
                return false;

            // Read the file and check if the string to search for exists.
            string contents = File.ReadAllText(filename);

            if (contents.IndexOf(codeSearch) == -1)
                return false;

            return true;
        }

        abstract public string applyTestEdit(string filename);
    }

    public class TestInstructionFailedException : Exception
    {
        public TestInstructionFailedException()
        {
        }

        public TestInstructionFailedException(string message)
            : base(message)
        {
        }

        public TestInstructionFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
