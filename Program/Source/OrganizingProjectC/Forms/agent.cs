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
        string mbversion = "1.2";

        string dlfilename;
        APIs.Notify message = new APIs.Notify();
        public Form1()
        {
            InitializeComponent();
            versionLabel.Text = "v" + mbversion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Have we asked the user if he or she wants to check for an update on each run?
            if (!Properties.Settings.Default.hasAskedACU)
            {
                DialogResult result = message.question("Do you want Mod Manager to check if an update is available automatically on each run?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    Properties.Settings.Default.autoCheckUpdates = true;

                Properties.Settings.Default.hasAskedACU = true;

                Properties.Settings.Default.Save();
            }

            // Check for updates, if set to do so.
            if (Properties.Settings.Default.autoCheckUpdates)
                checkUpdate(false);

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

            me.authorName.Text = Properties.Settings.Default.idUsername;

            // Show the instance.
            me.Show();
        }

        private void repairAProjectToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void convertAPackageToAProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // !WIP!
            Forms.convertProject cp = new Forms.convertProject();
            cp.Show();
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

            checkForUpdatesToolStripMenuItem.Text = "Update pending...";
            Size = new Size(Size.Width, 173);
        }

        private void checkUpdate(bool throwMessage = true)
        {
            try
            {
                WebClient client = new WebClient();

                // Start a new download of the latest version number thing.
                string lver = client.DownloadString("https://raw.github.com/Yoshi2889/ModManager/master/latestver");

                Version mver = new Version(mbversion);
                Version lmver = new Version(lver);

                // Compare the versions.
                int status = mver.CompareTo(lmver);

                if (status >= 0)
                {
                    // If we are running in silent mode, skip this message.
                    if (throwMessage)
                        message.information("You are using the latest version of Mod Manager.");
                    return;
                }
                else
                {
                    DialogResult result = message.question("A new version (" + lver + ") of Mod Manager has been released. Do you want to download the update?", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Create a new save dialog.
                        SaveFileDialog sf = new SaveFileDialog();
                        sf.DefaultExt = "exe";
                        sf.AddExtension = true;
                        sf.FileName = "setup.exe";
                        sf.Filter = "Executable files|*.exe";
                        sf.CheckFileExists = false;
                        sf.CheckPathExists = true;

                        // Show the dialog.
                        DialogResult sfres = sf.ShowDialog();

                        // Quit if we did something wrong-err, weird.
                        if (sfres == DialogResult.Cancel || string.IsNullOrEmpty(sf.FileName))
                            return;

                        // Rezise the form a bit :)
                        Size = new Size(Size.Width, 236);

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
                // Silent mode? Shhh.
                if (throwMessage)
                    message.error("An error occured while checking for updates. Please check your internet connection or try later.", MessageBoxButtons.OK);
                return;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            message.information("Mod Builder, a tool to help you create modifications for SMF (Simple Machines Forum).\nSMF is © Simple Machines, http://simplemachines.org/ \n Mod Builder is © Rick \"Yoshi2889\" Kerkhof");
        }

        private void supportToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://goo.gl/WYQxf");
            }
            catch
            {
                System.Diagnostics.Process.Start("iexplore", "http://goo.gl/WYQxf");
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dlfilename) && File.Exists(dlfilename))
            {
                DialogResult res = message.question("Do you want to start the updater now? This will close Mod Manager, save any open projects.", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(dlfilename);
                    Close();
                }
                return;
            }

            checkUpdate();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options op = new Options();
            op.ShowDialog();
        }
    }
}
