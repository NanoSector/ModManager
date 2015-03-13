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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void refreshContents(List<string> log)
        {
            // First clear it out. All of it.
            this.textBox1.Text = "";
            foreach (string logItem in log)
            {
                this.updateContents(logItem);
            }
        }

        public void updateContents(string logItem)
        {
            this.textBox1.Text = this.textBox1.Text + logItem + Environment.NewLine;
            lastItem.Text = logItem;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.AddExtension = true;
            sf.DefaultExt = ".log";
            sf.Filter = "Log files (*.log)|*.log|Text files (*.txt)|*.txt";
            sf.Title = "Save log output...";
            sf.OverwritePrompt = true;

            // Prompt the user.
            sf.ShowDialog();

            if (sf.FileName.Length == 0)
                return;

            System.IO.File.WriteAllText(sf.FileName, this.textBox1.Text);
        }

        private void copyClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textBox1.Text);
        }
    }
}