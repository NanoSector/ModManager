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

namespace OrganizingProjectC
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
            selectDirectory.ShowDialog();

            // Grab the directory selected.
            String dir = selectDirectory.SelectedPath;

            // Verify that it exists.
            if (!Directory.Exists(dir))
            {
                System.Windows.Forms.MessageBox.Show("The directory you entered is invalid.");
                return;
            }

            // Also check that the /Source directory exists.
            if (!Directory.Exists(dir + "/Source"))
            {
                System.Windows.Forms.MessageBox.Show("There is no Source directory in the project.");
                return;
            }

            // Same check for /Package
            if (!Directory.Exists(dir + "/Package"))
            {
                System.Windows.Forms.MessageBox.Show("There is no Package directory in the project.");
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

            System.Windows.Forms.MessageBox.Show("The package has been compiled and saved as compile.zip in the project directory.", "Package Compiled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editProjectButton_Click(object sender, EventArgs e)
        {

        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            modEditor me = new modEditor();
            me.Show();

        }
    }
}
