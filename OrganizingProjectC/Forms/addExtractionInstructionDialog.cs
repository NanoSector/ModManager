using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OrganizingProjectC.Forms
{
    public partial class addExtractionInstructionDialog : Form
    {
        string workingDirectory;
        modEditor me;
        public addExtractionInstructionDialog(string workingDirectory, modEditor me)
        {
            InitializeComponent();
            this.workingDirectory = workingDirectory;
            this.me = me;
            fileComboBox.Items.Clear();
            refreshComboboxList(workingDirectory);
        }

        public void refreshComboboxList(string dir)
        {

            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);

            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {

                string name = d.FullName.Replace(workingDirectory + "\\", "") + "\\";
                fileComboBox.Items.Add(name);
                refreshComboboxList(d.FullName);
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                string name = f.FullName.Replace(workingDirectory + "\\", "");
                // create a new node
                MessageBox.Show(name);
                fileComboBox.Items.Add(name);
            }
        }

        private void refreshComboBox_Click(object sender, EventArgs e)
        {
            fileComboBox.Items.Clear();
            refreshComboboxList(workingDirectory);
        }
    }
}
