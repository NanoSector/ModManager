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
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

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

        // Start the form.
        public MainForm()
        {
            InitializeComponent();

            // We'd like a logging instance.
            this.log = new Log();
            this.log.log("Mod Builder started");
            this.log.log("OS: " + Environment.OSVersion.ToString() + " (is 64-bit: " + Environment.Is64BitOperatingSystem.ToString() + ", is 64-bit process: " + Environment.Is64BitProcess.ToString() + ")");
            this.log.log("Common Language Runtime version: " + Environment.Version.ToString());
            this.log.log("Working directory: " + Environment.CurrentDirectory);

            // Set up a new empty project.
            this.project = new Project();
            log.log("New project created in memory.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void showLog_Click(object sender, EventArgs e)
        {
            this.log.toggleLogDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (logTest.Text.Length == 0)
                return;

            this.log.log(logTest.Text, "DEBUG");
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // !!! Set the default file name to the project name.

            // Show the dialog.
            this.saveProjectDialog.ShowDialog();

            if (this.saveProjectDialog.FileName.Length == 0)
                return;

            this.isOnDisk = true;
            this.log.log("Set flags; the environment is informed of the project state.");

            ProjectHelpers.SerializeObject(this.saveProjectDialog.FileName, this.project);
            this.log.log("Serialized and saved Project to disk. Path: " + this.saveProjectDialog.FileName, "SAVE");
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openProjectDialog.ShowDialog();

            if (this.openProjectDialog.FileName.Length == 0)
                return;

            try
            {
                this.project = ProjectHelpers.DeSerializeObject(this.openProjectDialog.FileName);
                this.log.log("Loaded project into memory: " + this.openProjectDialog.FileName, "LOAD");
                this.log.log(this.project.ToString());
            }
            catch
            {
                MessageBox.Show("An error occured while loading the project.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
