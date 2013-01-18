using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ModBuilder.Forms
{
    public partial class convertProject : Form
    {
        APIs.Notify message = new APIs.Notify();
        public convertProject()
        {
            InitializeComponent();
        }

        private void browseOutputDirectory_Click(object sender, EventArgs e)
        {
            // Show a new folder browser dialog.
            FolderBrowserDialog fb = new FolderBrowserDialog();

            // Set some settings.
            fb.Description = "Select the directory the project should be created in.";
            fb.ShowNewFolderButton = true;
            
            // Show it.
            DialogResult result = fb.ShowDialog();

            // Did we get a valid response?
            if (result != DialogResult.Cancel && !String.IsNullOrEmpty(fb.SelectedPath) && Directory.Exists(fb.SelectedPath))
            {
                // Being the nice program I am, I shall check if a project already exists in this directory.
                if (File.Exists(fb.SelectedPath + "/data.sqlite") && File.Exists(fb.SelectedPath + "/Package/package-info.xml"))
                {
                    DialogResult qresult = message.warning("Mod Manager has detected that a project already exists in the selected directory. Are you sure you want to continue and possibly overwrite the existing project?", MessageBoxButtons.YesNo);

                    // No? Quit.
                    if (qresult == DialogResult.No)
                        return;
                }

                // Update the textbox.
                outputDirectory.Text = fb.SelectedPath;
            }
        }
    }
}
