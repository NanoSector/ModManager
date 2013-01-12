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
            modEditor me = new modEditor();
            me.Show();
        }

        private void repairProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Please select the directory that your project resides in.";
            fb.ShowNewFolderButton = false;
            fb.ShowDialog();

            // Get the path.
            string dir = fb.SelectedPath;

            if (string.IsNullOrEmpty(dir))
                return;

            if (!Directory.Exists(dir + "/Package") || !Directory.Exists(dir + "/Source") || !File.Exists(dir + "/Package/package-info.xml"))
                MessageBox.Show("The selected project is not a valid project.", "Repairing project", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DialogResult result = message.question("Should I generate a new database for this project? Answering no will instead try to add all missing tables.", MessageBoxButtons.YesNoCancel);

            // New instance of the mod editor.
            modEditor me = new modEditor();
            if (result == DialogResult.Yes)
                me.generateSQL(dir);
            else if (result == DialogResult.No)
                me.generateSQL(dir, false);
            else if (result == DialogResult.Cancel)
                return;

            result = message.question("Your project has been repaired, should I load it now?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                loadProject lp = new loadProject();
                lp.Show();

                // Load the project.
                bool stat = lp.openProjDir(dir);

                // Check the status.
                if (stat == false)
                    message.error("An error occured while loading the project.", MessageBoxButtons.OK);

                // Tyvm!
                lp.Close();
            }

        }

        private void createProjectFromPackage_Click(object sender, EventArgs e)
        {
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
