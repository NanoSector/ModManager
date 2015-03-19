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

using System.Runtime.Serialization.Formatters.Binary;
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
        // Language instance.
        Translate tr;

        // Are we working from disk or memory?
        bool isOnDisk = false;
        string filename = "";

        // Start the form.
        public MainForm()
        {
            InitializeComponent();

            // We'd like a logging instance.
            this.log = new Log();
            this.tr = new Translate(this.log);
            this.log.log("Mod Builder started");
            this.log.log("OS: " + Environment.OSVersion.ToString() + " (is 64-bit: " + Environment.Is64BitOperatingSystem.ToString() + ", is 64-bit process: " + Environment.Is64BitProcess.ToString() + ")");
            this.log.log("Common Language Runtime version: " + Environment.Version.ToString());
            this.log.log("Program directory: " + Environment.CurrentDirectory);

            // Set up a new empty project.
            this.project = new Project();
            this.Text = _("new_project") + " - Mod Builder";
            this.log.log("New project created in memory.");

            // Refresh the strings.
            this.updateStrings();

            this.projectOverview.ExpandAll();
        }

        public void updateStrings()
        {
            try
            {
                this.setStatus(_("status_project_new"));
                this.modNameLabel.Text = _("mod_name");
                this.modVersionLabel.Text = _("mod_version");
                this.compatibilityLabel.Text = _("mod_compat");
                this.compatibilityCustomEnabler.Text = _("mod_compat_custom_enable");
                this.modIDLabel.Text = _("mod_id");
                this.genModID.Text = _("mod_id_gen_check");

                // File menu.
                this.fileMenu.Text = _("file_menu");
                this.newFileToolStripMenuItem.Text = _("file_new");
                this.newProjectToolStripMenuItem.Text = _("project");
                this.newInstructionToolStripMenuItem.Text = _("instruction");
                this.openProjectToolStripMenuItem.Text = _("file_open");
                this.saveProjectToolStripMenuItem.Text = _("file_save");
                this.saveAsToolStripMenuItem.Text = _("file_save_as");
                this.quitToolStripMenuItem.Text = _("file_quit");

                this.editMenu.Text = _("edit_menu");

                this.viewMenu.Text = _("view_menu");

                this.projectMenu.Text = _("project_menu");
                this.openProjectDirectoryToolStripMenuItem.Text = _("project_open_dir");
                this.applyToolStripMenuItem.Text = _("project_apply");
                this.installToInstallationToolStripMenuItem.Text = _("project_apply_install");
                this.removeFromInstallationToolStripMenuItem.Text = _("project_apply_uninstall");
                this.projectSettingsToolStripMenuItem.Text = _("project_settings");

                this.toolsMenu.Text = _("tools_menu");
                this.settingsToolStripMenuItem.Text = _("tools_settings");

                this.helpMenu.Text = _("help_menu");
                this.showLog.Text = _("help_log");
                this.forumTopicToolStripMenuItem.Text = _("help_topic");
                this.aboutToolStripMenuItem.Text = _("help_about");

                // The project tree.
                projectOverview.Nodes.Find("projectNode", false)[0].Text = _("project");
                projectOverview.Nodes.Find("instructionsNode", true)[0].Text = _("instructions");

                // Instructions contextmenustrip.
                instructionContext.Items.Find("createInstructionButton", true)[0].Text = _("icms_create");
            }
            catch (LanguageKeyNotFoundException e)
            {
                MessageBox.Show("The language file you are trying to use is either corrupt, incomplete, or not compatible with this version of Mod Builder. Please check its syntax and try again. Now loading the English language file. Error message: " + e.Message);
                tr.changeLanguage("en");
                this.updateStrings();
            }
        }
        public void updateUI(object sender = null, EventArgs e = null)
        {
            // Update generic form controls.
            this.projectName.Text = this.project.name;
            this.Text = this.project.name + " - Mod Builder";
            this.projectVersion.Text = this.project.version;
            this.compatible11.Checked = this.project.compatible11;
            this.compatible20.Checked = this.project.compatible20;
            this.compatible21.Checked = this.project.compatible21;

            this.compatibilityCustomEnabler.Checked = this.project.compatibleCustomEnabled;
            compatible11.Enabled = compatible20.Enabled = compatible21.Enabled = !this.project.compatibleCustomEnabled;
            compatibleCustom.Visible = this.project.compatibleCustomEnabled;
            compatibleCustom.Text = this.project.compatibleCustom;

            this.userName.Text = this.project.username;

            int i = 0;
            foreach (Mod_Builder.Classes.Instruction.InstructionBase inst in this.project.instructions)
            {
                this.projectOverview.Nodes.Find("instructionsNode", true)[0].Nodes.Add("instruction_" + inst.id, inst.name);
                i++;
            }
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
                this.setStatus(_("status_project_saved"));
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

                // Disable the file system watcher for a minute. :)
                fsWatcher.EnableRaisingEvents = false;

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
                    this.setStatus(_("status_project_saved"));
                }
                catch (Exception ex)
                {
                    this.log.log("Exception caught! " + ex.ToString(), "SAVE");
                    MessageBox.Show(_("error_project_save"), "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                this.isOnDisk = true;
                this.filename = filename;
                this.log.log("Loaded project; working with file: " + this.filename, "LOAD");

                this.updateUI();
                this.log.log("Updated form controls.");

                fsWatcher.Path = Path.GetDirectoryName(this.filename);
                fsWatcher.Filter = Path.GetFileName(this.filename);
                fsWatcher.EnableRaisingEvents = true;
                this.log.log("The loaded file is now watched for changes.", "WATCH");

                this.setStatus(_("status_project_opened"));

            }
            catch
            {
                MessageBox.Show(_("error_project_load"), "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                globalErrorProvider.SetError(tb, _("error_value_required"));
                e.Cancel = true;
            }

            // Nor those trying to insert less-than or greater-than signs. Trying to hack your way out there, ay ;)
            Match match = Regex.Match(tb.Text, @"[^<>]+");
            if (!match.Success || match.Value != tb.Text)
            {
                globalErrorProvider.SetError(tb, _("error_gt_lt"));
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
                globalErrorProvider.SetError(userName, _("error_auto_gen_username"));
                e.Cancel = true;
            }
            else if (genModID.Checked && userName.Text.Length > 30)
            {
                globalErrorProvider.SetError(userName, _("error_username_length"));
                e.Cancel = true;
            }
            else if (genModID.Checked)
            {
                Match m = Regex.Match(userName.Text, @"[a-zA-Z0-9]+");
                if (!m.Success || m.Value != userName.Text)
                {
                    globalErrorProvider.SetError(userName, _("error_username_chars"));
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
            DialogResult dr = MessageBox.Show(_("fw_reload"), "Mod Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
                this.loadProject(this.filename);
        }

        private void fsWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            DialogResult dr = MessageBox.Show(_("fw_delete"), "Mod Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
            this.setStatus(string.Format(_("fw_rename"), e.FullPath, e.OldFullPath));
            this.log.log("The project was renamed to \"" + e.FullPath + "\", old path: \"" + e.OldFullPath + "\". Internal paths updated.", "WATCH");
            this.filename = e.FullPath;
            fsWatcher.Path = Path.GetDirectoryName(e.FullPath);
            fsWatcher.Filter = Path.GetFileName(e.FullPath);
        }

        // Translating stuff the easy way.
        private string _(string key)
        {
            return tr.translate(key);
        }

        private void loadLanguageFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                DialogResult dr = of.ShowDialog();

                if (dr == DialogResult.Cancel)
                    return;

                tr.loadTranslationFile(of.FileName);
            }
        }

        private void createInstructionButton_Click(object sender, EventArgs e)
        {
            Forms.InstructionEditor ie = new Forms.InstructionEditor(this.log, this.tr, this.project, this);
            ie.Show();
        }
    }
    public static class ProjectHelpers
    {
        public static void SerializeObject(string filename, Project objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }
        public static Project DeSerializeObject(string filename)
        {
            Project objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (Project)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
