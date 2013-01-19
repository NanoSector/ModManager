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
using System.Net;

namespace ModBuilder
{
    public partial class Form1 : Form
    {
        // This version of Mod Builder.
        string mbversion = "1.0";

        string dlfilename;
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(dlfilename) && File.Exists(dlfilename))
            {
                System.Diagnostics.Process.Start(dlfilename);
                return;
            }

            try
            {
                WebClient client = new WebClient();
                
                // Start a new download of the latest version number thing.
                string lver = client.DownloadString("https://raw.github.com/Yoshi2889/ModManager/master/latestver");

                Version mver = new Version(mbversion);
                Version lmver = new Version(lver);

                // Compare the versions.
                int status = mver.CompareTo(lmver);

                if (status > 0 || status == 0)
                {
                    message.information("You are using the latest version of Mod Manager.", MessageBoxButtons.OK);
                    return;
                }
                else if (status < 0)
                {
                    DialogResult result = message.question("A new version of Mod Manager has been released. Do you want to download the update?", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Create a new save dialog.
                        SaveFileDialog sf = new SaveFileDialog();
                        sf.DefaultExt = "exe";
                        sf.AddExtension = true;
                        sf.FileName = "setup.exe";
                        sf.Filter = "Executable files|exe";
                        sf.CheckFileExists = false;
                        sf.CheckPathExists = true;

                        // Show the dialog.
                        DialogResult sfres = sf.ShowDialog();

                        // Quit if we did something wrong-err, weird.
                        if (sfres == DialogResult.Cancel || string.IsNullOrEmpty(sf.FileName))
                            return;

                        // Rezise the form a bit :)
                        Size = new Size(Size.Width, 325);

                        // Start downloading! DLUpdateCompleted will take over once it's done.
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(DLUpdateCompleted);
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                        client.DownloadFileAsync(new Uri("https://github.com/Yoshi2889/ModManager/blob/master/setup.exe?raw=true"), @sf.FileName);
                        dlfilename = sf.FileName;
                    }
                }
            }
            catch
            {
                message.error("An error occured while checking for updates. Please check your internet connection or try later.", MessageBoxButtons.OK);
                return;
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DLUpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            DialogResult result = message.information("The download has completed. Do you want to start the installer now? This will close Mod Manager and any open Mod Editor windows, so save your work before continuing.", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(dlfilename);
                Close();
            }

            linkLabel2.Text = "Update pending...";
            Size = new Size(Size.Width, 264);
        }
    }
}
