using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod_Builder.Classes.ProjectComponents;
using System.Xml.Serialization;
using System.IO;

namespace Mod_Builder.Classes
{
    [Serializable()]
    public class Project
    {
        public List<Instruction.InstructionBase> instructions = new List<Instruction.InstructionBase>();

        public string name = "";
        public string version = "";
        public string username = "";
        public string modID = "";
        public bool generateModID = true;

        public bool compatible11 = false;
        public bool compatible20 = false;
        public bool compatible21 = false;
        public bool compatibleCustomEnabled = false;
        public string compatibleCustom = "";

        public Instruction.InstructionBase findInstructionByKey(int key)
        {
            foreach (Instruction.InstructionBase ib in this.instructions)
            {
                if (ib.id == key)
                    return ib;
            }
            throw new InstructionDoesNotExistException();
        }
        public int lastInstructionID()
        {
            int l = 0;
            foreach (Instruction.InstructionBase ib in this.instructions)
            {
                if (ib.id > l)
                    l = ib.id;
            }
            return l;
        }
        public void addInstruction(Instruction.InstructionBase inst)
        {
            inst.id = lastInstructionID() + 1;
            this.instructions.Add(inst);
        }
    }

    public class InstructionDoesNotExistException : Exception
    {
        public InstructionDoesNotExistException()
        {
        }

        public InstructionDoesNotExistException(string message)
            : base(message)
        {
        }

        public InstructionDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
