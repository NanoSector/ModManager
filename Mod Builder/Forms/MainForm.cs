using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mod_Builder.Classes;

using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Mod_Builder
{
    public partial class MainForm : Form
    {
        // The log instance. Used for, well, logging.
        Log log;
        // The project instance.
        Project project;

        // Are we working from disk or memory?
        bool isOnDisk = false;
        string filename = "";

        // Start the form.
        public MainForm()
        {
            InitializeComponent();

            // We'd like a logging instance.
            this.log = new Log();
            this.log.log("Mod Builder started");
            this.log.log("OS: " + Environment.OSVersion.ToString() + " (is 64-bit: " + Environment.Is64BitOperatingSystem.ToString() + ", is 64-bit process: " + Environment.Is64BitProcess.ToString() + ")");
            this.log.log("Common Language Runtime version: " + Environment.Version.ToString());
            this.log.log("Program directory: " + Environment.CurrentDirectory);

            // Set up a new empty project.
            this.project = new Project();
            log.log("New project created in memory.");

            this.projectOverview.ExpandAll();
        }

        private void showLog_Click(object sender, EventArgs e)
        {
            this.log.toggleLogDialog();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var info = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath);
            System.Diagnostics.Process.Start(info);
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.filename.Length != 0 && this.isOnDisk && File.Exists(this.filename))
            {
                this.log.log("Saving existing project to disk.", "SAVE");
                ProjectHelpers.SerializeObject(this.filename, this.project);
                this.log.log("Serialized and saved Project to disk. Path: " + this.filename, "SAVE");
                this.setStatus("Project saved.");
            }

            // Simulate a click to the Save as... button ;) Saves a lot of code.
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveProjectDialog = new SaveFileDialog())
            {
                saveProjectDialog.Filter = "Mod Builder Projects (*.mbproj)|*.mbproj";
                saveProjectDialog.FileName = (this.projectName.Text.Length == 0 ? "New Project" : this.projectName.Text);

                DialogResult dr = saveProjectDialog.ShowDialog();

                if (saveProjectDialog.FileName.Length == 0 || dr == DialogResult.Cancel)
                    return;

                try
                {
                    this.isOnDisk = true;
                    this.filename = saveProjectDialog.FileName;
                    this.log.log("Set flags; the environment is informed of the project state.");

                    ProjectHelpers.SerializeObject(saveProjectDialog.FileName, this.project);
                    this.log.log("Serialized and saved Project to disk. Path: " + saveProjectDialog.FileName, "SAVE");

                    fsWatcher.Path = Path.GetDirectoryName(this.filename);
                    fsWatcher.Filter = Path.GetFileName(this.filename);
                    fsWatcher.EnableRaisingEvents = true;
                    this.log.log("The loaded file is now watched for changes.", "WATCH");
                    this.setStatus("Project saved.");
                }
                catch (Exception ex)
                {
                    this.log.log("Exception caught! " + ex.ToString(), "SAVE");
                    MessageBox.Show("Could not save the project.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openProjectDialog = new OpenFileDialog())
            {
                openProjectDialog.Filter = "Mod Builder Projects (*.mbproj)|*.mbproj";
                DialogResult dr = openProjectDialog.ShowDialog();

                if (openProjectDialog.FileName.Length == 0 || dr == DialogResult.Cancel)
                    return;

                this.loadProject(openProjectDialog.FileName);
            }
        }

        private void loadProject(string filename)
        {
            try
            {
                this.project = ProjectHelpers.DeSerializeObject(filename);
                this.log.log("Loaded project into memory: " + filename, "LOAD");

                this.Text = this.project.name + " - Mod Builder";
                this.projectName.Text = this.project.name;
                this.log.log("The project name is: \"" + this.project.name + "\", updated form controls.", "LOAD");

                this.projectVersion.Text = this.project.version;
                this.log.log("The project version is: \"" + this.project.version + "\", updated form controls.", "LOAD");

                this.genModID.Checked = this.project.generateModID;
                this.modID.Text = this.project.modID;
                this.log.log("The mod ID is: \"" + this.project.modID + "\", generated: " + this.project.generateModID.ToString() + ". Updated form controls.", "LOAD");

                this.userName.Text = this.project.username;
                this.log.log("The username used to generate the mod ID is: \"" + this.project.username + "\", updated form controls.", "LOAD");

                this.isOnDisk = true;
                this.filename = filename;
                this.log.log("Loaded project; working with file: " + this.filename, "LOAD");

                fsWatcher.Path = Path.GetDirectoryName(this.filename);
                fsWatcher.Filter = Path.GetFileName(this.filename);
                fsWatcher.EnableRaisingEvents = true;
                this.log.log("The loaded file is now watched for changes.", "WATCH");

                this.setStatus("Project opened.");

            }
            catch
            {
                MessageBox.Show("An error occured while loading the project.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.About ab = new Forms.About();
            ab.ShowDialog();
        }

        private void openProjectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void projectSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ProjectSettings ps = new Forms.ProjectSettings(this.project);
            ps.ShowDialog();

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings set = new Forms.Settings();
            set.ShowDialog();
        }

        private void compatibilityCustomEnabler_CheckedChanged(object sender, EventArgs e)
        {
            if (compatibilityCustomEnabler.Checked == true)
            {
                compatible11.Enabled = compatible20.Enabled = compatible21.Enabled = false;
                compatibleCustom.Visible = true;
            }
            else
            {
                compatible11.Enabled = compatible20.Enabled = compatible21.Enabled = true;
                compatibleCustom.Visible = false;
            }
        }

        private void projectName_Validated(object sender, EventArgs e)
        {
            this.project.name = projectName.Text;
            this.Text = projectName.Text + " - Mod Builder";

            if (genModID.Checked)
            {
                string id;
                if (generateModID(out id))
                {
                    modID.Text = id;
                    this.project.modID = id;
                }
            }
        }

        private void projectVersion_Validated(object sender, EventArgs e)
        {
            this.project.version = projectVersion.Text;
        }

        private void genericTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // We don't accept empty mod names.
            if (tb.Text.Length == 0)
            {
                globalErrorProvider.SetError(tb, "You must enter a value here.");
                e.Cancel = true;
            }

            // Nor those trying to insert less-than or greater-than signs. Trying to hack your way out there, ay ;)
            Match match = Regex.Match(tb.Text, @"[^<>]+");
            if (!match.Success || match.Value != tb.Text)
            {
                globalErrorProvider.SetError(tb, "Not a valid value, this item can not contain less-than or greater-than signs.");
                e.Cancel = true;
            }

            // If all went well, we can clear any errors.
            if (e.Cancel == false)
                globalErrorProvider.SetError(tb, "");
        }

        private void userName_Validating(object sender, CancelEventArgs e)
        {
            if (genModID.Checked && userName.Text.Length == 0)
            {
                globalErrorProvider.SetError(userName, "If you want to automatically generate a mod ID, you need to enter your username here.");
                e.Cancel = true;
            }
            else if (genModID.Checked && userName.Text.Length > 30)
            {
                globalErrorProvider.SetError(userName, "Your username may not exceed 30 characters.");
                e.Cancel = true;
            }
            else if (genModID.Checked)
            {
                Match m = Regex.Match(userName.Text, @"[a-zA-Z0-9]+");
                if (!m.Success || m.Value != userName.Text)
                {
                    globalErrorProvider.SetError(userName, "Your username may only contain the characters a-z, A-Z and 0-9.");
                    e.Cancel = true;
                }
            }

            if (e.Cancel == false)
                globalErrorProvider.SetError(userName, "");
        }

        private void userName_Validated(object sender, EventArgs e)
        {
            this.project.username = this.userName.Text;

            if (genModID.Checked)
            {
                string id;
                if (generateModID(out id))
                {
                    modID.Text = id;
                    this.project.modID = id;
                }
            }
        }

        public bool generateModID(out string modID)
        {
            modID = "";
            if (projectName.Text.Length == 0 || userName.Text.Length == 0)
                return false;

            // The username cannot be longer than 30 characters.
            if (userName.Text.Length > 30)
                return false;

            // Strip anything special, including spaces.
            string modName = Regex.Replace(projectName.Text, @"[^a-zA-Z0-9_-]+", "");

            // First, we count how long the starting username + the colon is,
            // and substract that from the total allowed length.
            int nameLength = 31 - userName.Text.Length;

            // Oops, did we take too much? :D
            if (nameLength > modName.Length)
                nameLength = modName.Length;

            // Mash up the string.
            modID = userName.Text + ":" + modName.Substring(0, nameLength);

            return true;
        }

        private void genModID_CheckedChanged(object sender, EventArgs e)
        {
            modID.ReadOnly = genModID.Checked;
            userName.ReadOnly = !genModID.Checked;
            this.project.generateModID = genModID.Checked;
        }

        private void setStatus(string message)
        {
            this.statusLabel.Text = message;
        }

        private void fsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            DialogResult dr = MessageBox.Show("The loaded project was changed on disk. Do you want to reload it?", "Mod Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
                this.loadProject(this.filename);
        }

        private void fsWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            DialogResult dr = MessageBox.Show("The loaded project was deleted from disk. Do you want to close this project and open a new project? If you choose No, the current project will be moved into memory, and it will be lost upon closing Mod Builder.", "Mod Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
                Application.Restart();
            
            else
            {
                this.filename = "";
                this.isOnDisk = false;
                fsWatcher.EnableRaisingEvents = false;
                this.log.log("Project moved to memory.", "WATCH");
            }
        }

        private void fsWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            this.setStatus("The project was renamed to \"" + e.FullPath + "\", old path: \"" + e.OldFullPath + "\"");
            this.log.log("The project was renamed to \"" + e.FullPath + "\", old path: \"" + e.OldFullPath + "\". Internal paths updated.", "WATCH");
            this.filename = e.FullPath;
            fsWatcher.Path = Path.GetDirectoryName(e.FullPath);
            fsWatcher.Filter = Path.GetFileName(e.FullPath);
        }
    }
    public static class ProjectHelpers
    {
        public static void SerializeObject(string filename, Project objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            XmlSerializer bFormatter = new  XmlSerializer(typeof(Project));
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }
        public static Project DeSerializeObject(string filename)
        {
            Project objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            XmlSerializer bFormatter = new XmlSerializer(typeof(Project));
            objectToSerialize = (Project)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
