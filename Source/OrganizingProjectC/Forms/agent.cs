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
using ModBuilder.Forms;

namespace ModBuilder
{
    public partial class Form1 : Form
    {
        APIs.Notify message = new APIs.Notify();
        public Form1()
        {
            InitializeComponent();
        }

        private void editProjectButton_Click(object sender, EventArgs e)
        {

            // Show them the loading box.
            loadProject lp = new loadProject();
            lp.Show();

            // Get us a new FolderBrowserDialog
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Please select the directory that your project resides in.";
            fb.ShowNewFolderButton = false;
            fb.ShowDialog();

            // Get the path.
            string dir = fb.SelectedPath;

            // Avoid the annoying An error occured dialog.
            if (string.IsNullOrEmpty(dir))
            {
                lp.Close();
                return;
            }

            // Load the project.
            bool stat = lp.openProjDir(dir);

            // Check the status.
            if (stat == false)
                message.error("An error occured while loading the project, some files could not be found or the project is corrupt.", MessageBoxButtons.OK);

            // Tyvm!
            lp.Close();
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            // Start a new instance of the Mod Editor.
            modEditor me = new modEditor();

            // Assign a new mod console to this instance.
            me.mc = new modConsole();

            // Some default values.
            me.genPkgID.Checked = true;
            me.includeModManLine.Checked = true;

            // Show the instance.
            me.Show();
        }

        private void repairProject_Click(object sender, EventArgs e)
        {
            // Start a new Folder Browser Dialog.
            FolderBrowserDialog fb = new FolderBrowserDialog();

            // Some settings for it.
            fb.Description = "Please select the directory that your project resides in.";
            fb.ShowNewFolderButton = false;

            // And show it.
            DialogResult bresult = fb.ShowDialog();

            // Get the path.
            string dir = fb.SelectedPath;

            // Check if it is empty or if the user clicked Cancel.
            if (bresult == DialogResult.Cancel || string.IsNullOrEmpty(dir))
                return;

            // Check if it is a valid project.
            if (!Directory.Exists(dir + "/Package") || !Directory.Exists(dir + "/Source") || !File.Exists(dir + "/Package/package-info.xml"))
            {
                message.error("The selected project is not a valid project.", MessageBoxButtons.OK);
                return;
            }

            // Ask if the user wants to generate a new database, or to just add the tables.
            DialogResult result = message.question("Should I generate a new database for this project? Answering no will instead try to add all missing tables.", MessageBoxButtons.YesNoCancel);

            // New instance of the mod editor.
            modEditor me = new modEditor();

            // Switch the result, to see what the user has answered.
            switch (result)
            {
                // Generate an all new shiny database.
                case (DialogResult.Yes):
                    me.generateSQL(dir);
                    break;

                // Only add the missing tables.
                case (DialogResult.No):
                    me.generateSQL(dir, false);
                    break;

                // Or don't do anything at all! :D
                case (DialogResult.Cancel):
                    return;
            }

            // Ask if the user wants to load the project.
            result = message.question("Your project has been repaired, should I load it now?", MessageBoxButtons.YesNo);

            // Yes? Load the project.
            if (result == DialogResult.Yes)
            {
                // Show a loadProject dialog.
                loadProject lp = new loadProject();
                lp.Show();

                // Load the project.
                bool stat = lp.openProjDir(dir);

                // Check the status.
                if (stat == false)
                    message.error("An error occured while loading the project.", MessageBoxButtons.OK);

                // Close the loadProject dialog.
                lp.Close();
            }

        }

        private void createProjectFromPackage_Click(object sender, EventArgs e)
        {
            // !WIP!
            Forms.convertProject cp = new Forms.convertProject();
            cp.Show();
            return;

            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Please select the directory that your package resides in.";
            fb.ShowNewFolderButton = false;
            fb.ShowDialog();

            // Get the path.
            string packdir = fb.SelectedPath;

            // No valid directory? Shame on you.
            if (string.IsNullOrEmpty(packdir))
                return;

            // Show it again.
            fb.Description = "Please select the directory where the project should be generated.";
            fb.ShowNewFolderButton = true;
        }
    }
}
