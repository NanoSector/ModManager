using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;

namespace OrganizingProjectC
{
    public partial class modEditor : Form
    {
        // Strings
        public string workingDirectory;
        public SQLiteConnection conn;

        #region Load
        // Shows the actual editor
        public modEditor()
        {
            InitializeComponent();
        }

        // Loads a mod project in the following steps:
        // First it wipes all the fields.
        // Second it shows the user 
        public void loadModProject(string projectDir)
        {

        }

        private void modEditor_Load(object sender, EventArgs e)
        {
            modType.SelectedItem = "Modification";
        }
        #endregion

        #region Mod ID Generator
        private void modName_TextChanged(object sender, EventArgs e)
        {
            generateModID();

            modName.BackColor = Color.White;
        }

        private void genPkgID_CheckedChanged(object sender, EventArgs e)
        {
            if (genPkgID.Checked == true)
            {
                modID.Enabled = false;
                generateModID();
            }
            else
                modID.Enabled = true;
        }

        private void authorName_TextChanged(object sender, EventArgs e)
        {
            generateModID();
        }

        private void modID_TextChanged(object sender, EventArgs e)
        {
            modID.Text = modID.Text.Replace(" ", "");

            modID.BackColor = Color.White;
        }

        private void generateModID()
        {
            if (genPkgID.Checked == true && !string.IsNullOrEmpty(authorName.Text) && !string.IsNullOrEmpty(modName.Text))
            {
                string an = authorName.Text;
                an.Replace(" ", "");
                string mn = modName.Text;
                mn.Replace(" ", "");
                modID.Text = an + ":" + mn;
            }
        }
        #endregion

        #region Mod builder
        private bool buildMod(string dir)
        {
            // If we don't have a working directory, ask/beg for one.
            if (string.IsNullOrEmpty(workingDirectory))
            {
                FolderBrowserDialog af = new FolderBrowserDialog();
                af.Description = "Select a directory for your project, or create one.";
                af.ShowNewFolderButton = true;
                af.ShowDialog();

                if (string.IsNullOrEmpty(af.SelectedPath))
                {
                    System.Windows.Forms.MessageBox.Show("An error occured while saving the project, because you did not select a (valid) directory. Nothing has been saved.", "Saving Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Set the working directory.
                workingDirectory = af.SelectedPath;
            }

            // Create a Package and Source directory if they do not exist.
            if (!Directory.Exists(workingDirectory + "/Package"))
                Directory.CreateDirectory(workingDirectory + "/Package");
            if (!Directory.Exists(workingDirectory + "/Source"))
                Directory.CreateDirectory(workingDirectory + "/Source");

            // Check if something is empty.
            if (String.IsNullOrEmpty(modName.Text) || String.IsNullOrEmpty(modVersion.Text) || String.IsNullOrEmpty(modType.Text) || String.IsNullOrEmpty(modID.Text) || String.IsNullOrEmpty(modCompatibility.Text))
            {
                System.Windows.Forms.MessageBox.Show("You forgot to fill in some details.", "Saving modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = modDetails;

                if (String.IsNullOrEmpty(modName.Text))
                    modName.BackColor = Color.Red;

                if (String.IsNullOrEmpty(modVersion.Text))
                    modVersion.BackColor = Color.Red;

                if (String.IsNullOrEmpty(modID.Text))
                    modID.BackColor = Color.Red;

                if (String.IsNullOrEmpty(modType.Text))
                    modType.BackColor = Color.Red;

                if (String.IsNullOrEmpty(modCompatibility.Text))
                    modCompatibility.BackColor = Color.Red;
                return false;
            }

            // Lets build the package_info.xml.
            XmlWriterSettings settings = new XmlWriterSettings();

            // Apply proper identation, if you'd please.
            settings.Indent = true;

            // Start the file.
            XmlWriter writer = XmlWriter.Create(workingDirectory + "/Package/package-info.xml", settings);

            // Start the document.
            writer.WriteStartDocument();

            // Doctype (the writer.WriteDocType stuff was confusing me)
            writer.WriteRaw("<!DOCTYPE package-info SYSTEM \"http://www.simplemachines.org/xml/package-info\">");

            // Some sort of generator-thingy-thing.
            writer.WriteComment("Generated by Mod Manager v1");

            // Write the package-info start element.
            writer.WriteStartElement("package-info", "http://www.simplemachines.org/xml/package-info");
            writer.WriteAttributeString("xmlns", "smf", null, "http://www.simplemachines.org/");

            // Write the ID.
            writer.WriteElementString("id", modID.Text);

            // Name.
            writer.WriteElementString("name", modName.Text);

            // Version.
            writer.WriteElementString("version", modVersion.Text);

            // Determine the type.
            Dictionary<string, string> types = new Dictionary<string, string>();

            types.Add("Modification", "modification");
            types.Add("Avatar pack", "avatar");
            string type = types[modType.Text];

            // And write it.
            writer.WriteElementString("type", type);

            // Installation instructions.
            writer.WriteStartElement("install");
            writer.WriteAttributeString("for", modCompatibility.Text);

            // Readme.
            writer.WriteElementString("readme", "readme.txt");
            //writer.WriteAttributeString("parsebbc", "true");

            // And installation XML, if we have any.
            /*
            if (!String.IsNullOrEmpty(modManualInstallInstructions))
            {
                writer.WriteElementString();
            }*/

            // End the element and document.
            writer.WriteEndElement();
            writer.WriteEndDocument();

            // Flush and end!
            writer.Flush();
            writer.Close();

            // Then write the readme.
            File.WriteAllText(workingDirectory + "/Package/readme.txt", modReadme.Text);

            // Do we have an empty database?
            if (!File.Exists(workingDirectory + "/data.sqlite"))
                generateSQL(workingDirectory);


            return true;
        }

        public bool generateSQL(string dir)
        {
            // Create the file.
            SQLiteConnection.CreateFile(workingDirectory + "/data.sqlite");

            // Immediately connect.
            conn = new SQLiteConnection("Data Source=\"" + workingDirectory + "/data.sqlite\";Version=3;");
            conn.Open();

            // Create our tables.
            string sql = "CREATE TABLE instructions(id INT, before VARCHAR(255), after VARCHAR(255), type VARCHAR(20), file VARCHAR(255))";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE hooks(ID int, hook_name VARCHAR(255), value VARCHAR(255))";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE files(ID int, file_name VARCHAR(255), destination VARCHAR(255))";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            return true;
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Build the mod.
            bool result = buildMod(workingDirectory);

            if (result == false)
                MessageBox.Show("An error occured while building your mod. Please try again.", "Building mod", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Project has been build.", "Building project", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Mod Saver
        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(workingDirectory))
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();

                fb.ShowNewFolderButton = true;
                fb.Description = "Please choose a folder to save your project to.";

                fb.ShowDialog();

                if (!Directory.Exists(fb.SelectedPath))
                {
                    MessageBox.Show("An error occured while saving your project, the destination directory does not exist.", "Saving project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                workingDirectory = fb.SelectedPath;
            }

            // Build the mod.
            bool result = buildMod(workingDirectory);

            if (result == false)
                MessageBox.Show("An error occured while saving your project. Please try again.", "Saving project", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Help texts

        private void showHelp(string text)
        {
            System.Windows.Forms.MessageBox.Show(text, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showHelp("This is the title of your modification. It is usually associated with what your mod does, e.g. Simple Portal is a portal for SMF.");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            showHelp("The version of your modification increases after each update. It indicates how many releases have been made. Most version numbers go with the mayor.minor way, like 1.0 is 1 mayor and 0 minor versions released.");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            showHelp("The mod type is important, because it will help SMF decide what category to put your mod in. A Modification is a package which applies code customizations, while an Avatar pack is just a package that contains avatars which members can use.");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            showHelp("The mod ID is the unique identifier for your modification. It must be a unique string. We recommend leaving the auto generation of this field on, so it's harder to get duplicate IDs.");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            showHelp("The compatibility range is important, because it defines the versions of SMF that work with your modification. We recommend you use 2.0 - 2.0.99 as your compatibility range when developing your mod for the 2.x branch.");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            showHelp("This field is not required when you want to enter your own mod ID. It helps the generator in creating a unique mod ID and is not used in your mod.");
        }
#endregion

        #region Colour changing
        private void modType_SelectedIndexChanged(object sender, EventArgs e)
        {
            modType.BackColor = Color.White;
        }

        private void modVersion_TextChanged(object sender, EventArgs e)
        {
            modVersion.BackColor = Color.White;
        }

        private void modCompatibility_TextChanged(object sender, EventArgs e)
        {
            modCompatibility.BackColor = Color.White;
        }
        #endregion

        #region Adding instructions
        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + "/data.sqlite"))
            {
                System.Windows.Forms.MessageBox.Show("Please save your project before continuing.", "Adding new instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            addInstruction ai = new addInstruction(workingDirectory, conn, 0);
            ai.Show();
        }
        #endregion

        #region Generate database
        private void regenerateSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(workingDirectory) || !File.Exists(workingDirectory + "/data.sqlite"))
            {
                MessageBox.Show("Either your project is not saved or you have a corrupted project. Please try saving your project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to regenerate the database file? You will lose almost all your data!", "Regenerate SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                conn.Close();

                try
                {
                    File.Delete(workingDirectory + "/data.sqlite");
                }
                catch (IOException)
                {
                    MessageBox.Show("The database file is in use by another process. Please try again in a few seconds.", "Database file is locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                generateSQL(workingDirectory);

                MessageBox.Show("A new database has been generated. Your project will now be reloaded.", "Generating SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadProject lp = new loadProject();

                lp.Show();
                lp.openProjDir(workingDirectory);

                lp.Close();

                Close();
            }
        }
        #endregion

        #region New project and Open project
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Just start an all new instance. Simple as that.
            modEditor me = new modEditor();
            me.Show();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        #endregion
    }
}
