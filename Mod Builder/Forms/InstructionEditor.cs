using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod_Builder.Forms
{
    public partial class InstructionEditor : Form
    {
        Classes.Translate tr;
        Classes.Log log;
        Classes.Instruction.InstructionBase inst;

        public InstructionEditor(Classes.Log log, Classes.Translate tr, Classes.Instruction.InstructionBase inst = null)
        {
            if (inst == null)
                inst = new Classes.Instruction.ReplaceInstruction();
            this.tr = tr;
            this.log = log;
            this.inst = inst;

            InitializeComponent();

            this.leftLabel.Text = _("inst_find");
            this.changeLayout();

            this.fileToEditLabel.Text = _("inst_filetoedit");
            this.methodLabel.Text = _("inst_method");
            this.methodAfter.Text = _("inst_after");
            this.methodBefore.Text = _("inst_before");
            this.methodReplace.Text = _("inst_replace");
            this.methodEnd.Text = _("inst_end");
            this.optional.Text = _("inst_optional");
            this.nameLabel.Text = _("inst_custom_name");

            this.okButton.Text = _("ok");
            this.cancelButton.Text = _("cancel");
            
        }

        private void changeLayout()
        {
            switch (this.inst.ToString())
	        {
                case "Mod_Builder.Classes.Instruction.ReplaceInstruction":
                    this.rightLabel.Text = _("inst_replacewith");
                    this.textContainers.Panel1Collapsed = false;
                    break;
                case "Mod_Builder.Classes.Instruction.AddAfterInstruction":
                    this.rightLabel.Text = _("inst_add_after");
                    this.textContainers.Panel1Collapsed = false;
                    break;
                case "Mod_Builder.Classes.Instruction.AddBeforeInstruction":
                    this.rightLabel.Text = _("inst_add_before");
                    this.textContainers.Panel1Collapsed = false;
                    break;
                case "Mod_Builder.Classes.Instruction.EndOfFileInstruction":
                    this.rightLabel.Text = _("inst_add_end");
                    this.textContainers.Panel1Collapsed = true;
                    break;
	        }
        }

        // Translating stuff the easy way.
        private string _(string key)
        {
            return tr.translate(key);
        }
    }
}
