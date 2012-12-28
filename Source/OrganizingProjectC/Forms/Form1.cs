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
using Ionic.Zip;

namespace ModBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void compileProjectButton_Click(object sender, EventArgs e)
        {
            // Create a new folder browser dialog.
            FolderBrowserDialog selectDirectory = new FolderBrowserDialog();

            // Assign some properties.
            selectDirectory.Description = "Select the folder that contains your project.";
            selectDirectory.ShowNewFolderButton = false;
            selectDirectory.ShowDialog();

            // Grab the directory selected.
            String dir = selectDirectory.SelectedPath;

            // Verify that it exists.
            if (!Directory.Exists(dir))
            {
                System.Windows.Forms.MessageBox.Show("The directory you entered is invalid.", "Compiling Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Also check that the /Source directory exists.
            if (!Directory.Exists(dir + "/Source"))
            {
                System.Windows.Forms.MessageBox.Show("There is no Source directory in the project.", "Compiling Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Same check for /Package
            if (!Directory.Exists(dir + "/Package"))
            {
                System.Windows.Forms.MessageBox.Show("There is no Package directory in the project.", "Compiling Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Start the ZIP process.
            using (ZipFile zip = new ZipFile())
            {
                // Add the Package directory to the root of the ZIP file.
                zip.AddDirectory(dir + "/Package");

                // Then add the Source directory to the files directory of the ZIP file.
                zip.AddDirectory(dir + "/Source", "files");

                // Now we can save the ZIP.
                zip.Save(dir + "/compile.zip");
            }

            MessageBox.Show("The package has been compiled and saved as compile.zip in the project directory.", "Package Compiled", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Load the project.
            bool stat = lp.openProjDir(dir);

            // Check the status.
            if (stat == false)
                System.Windows.Forms.MessageBox.Show("An error occured while loading the project.", "Loading Project", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            DialogResult result = MessageBox.Show("Should I generate a new database for this project?", "Repairing project", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // New instance of the mod editor.
            modEditor me = new modEditor();
            if (result == DialogResult.Yes)
                me.generateSQL(dir);

            result = MessageBox.Show("Your project has been repaired, should I load it now?", "Repaired project", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loadProject lp = new loadProject();
                lp.Show();

                // Load the project.
                bool stat = lp.openProjDir(dir);

                // Check the status.
                if (stat == false)
                    System.Windows.Forms.MessageBox.Show("An error occured while loading the project.", "Loading Project", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Tyvm!
                lp.Close();
            }

        }
    }
}
