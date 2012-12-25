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
                // Yes it is, warn the user and reset to the main tab.
                System.Windows.Forms.MessageBox.Show("You forgot to fill in some details.", "Saving modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = modDetails;

                // Also mark the required fields in a nice red colour. It goes away once something's typed. First up is name.
                if (String.IsNullOrEmpty(modName.Text))
                    modName.BackColor = Color.Red;

                // Version.
                if (String.IsNullOrEmpty(modVersion.Text))
                    modVersion.BackColor = Color.Red;

                // ID, when it is not set to automatically generate stuff.
                if (String.IsNullOrEmpty(modID.Text) && !genPkgID.Checked)
                    modID.BackColor = Color.Red;

                // Type.
                if (String.IsNullOrEmpty(modType.Text))
                    modType.BackColor = Color.Red;

                // Compatibility.
                if (String.IsNullOrEmpty(modCompatibility.Text))
                    modCompatibility.BackColor = Color.Red;
                return false;
            }

            // Lets build the package_info.xml.
            using (FileStream fileStream = new FileStream(workingDirectory + "/Package/package-info.xml", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fileStream))
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                // Some settings before we start.
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                // Start the document.
                writer.WriteStartDocument();

                // Doctype (the writer.WriteDocType stuff was confusing me)
                writer.WriteDocType("package-info", null, "http://www.simplemachines.org/xml/package-info", null);
                //writer.WriteRaw("<!DOCTYPE package-info SYSTEM \"http://www.simplemachines.org/xml/package-info\">");

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
                writer.WriteStartElement("readme");
                writer.WriteAttributeString("parsebbc", "true");
                writer.WriteString("readme.txt");
                writer.WriteEndElement();

                // And installation XML.
                writer.WriteElementString("modification", "install.xml");

                // End the element and document.
                writer.WriteEndElement();

                // Uninstallation instructions!
                writer.WriteStartElement("uninstall");
                writer.WriteAttributeString("for", modCompatibility.Text);

                writer.WriteStartElement("modification");
                writer.WriteAttributeString("reverse", "true");
                writer.WriteString("install.xml");
                writer.WriteEndElement();

                writer.WriteEndElement();

                // Last but not least the end of the document.
                writer.WriteEndDocument();

                // Flush and end!
                writer.Flush();
                writer.Close();
            }

            // Some settings before we start.
            using (FileStream fileStream = new FileStream(workingDirectory + "/Package/install.xml", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fileStream))
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                // Some settings before we start.
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                // Start the document.
                writer.WriteStartDocument();

                // Doctype (the writer.WriteDocType stuff was confusing me)
                writer.WriteDocType("modification", null, "http://www.simplemachines.org/xml/modification", null);

                // Some sort of generator-thingy-thing.
                writer.WriteComment("Generated by Mod Manager v1");

                // Write the package-info start element.
                writer.WriteStartElement("modification", "http://www.simplemachines.org/xml/modification");
                writer.WriteAttributeString("xmlns", "smf", null, "http://www.simplemachines.org/");

                // Write the ID.
                writer.WriteElementString("id", modID.Text);

                // Version.
                writer.WriteElementString("version", modVersion.Text);

                // Grab the data.
                if (File.Exists(workingDirectory + "/data.sqlite"))
                {
                    string sql = "SELECT id, before, after, type, file, optional FROM instructions";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        writer.WriteStartElement("file");
                        writer.WriteAttributeString("name", Convert.ToString(reader["file"]));

                        if (Convert.ToInt32(reader["optional"]) == 1)
                            writer.WriteAttributeString("errors", "skip");

                        writer.WriteStartElement("operation");

                        writer.WriteStartElement("search");
                        string fintype = "";
                        switch (Convert.ToString(reader["type"]))
                        {
                            case "add_before":
                                fintype = "before";
                                break;

                            case "add_after":
                                fintype = "after";
                                break;

                            case "replace":
                                fintype = "replace";
                                break;
                        }
                        writer.WriteAttributeString("position", fintype);
                        writer.WriteCData(Convert.ToString(reader["before"]));
                        writer.WriteEndElement();

                        writer.WriteStartElement("add");
                        writer.WriteCData(Convert.ToString(reader["after"]));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
            }

            // Then write the readme.
            File.WriteAllText(workingDirectory + "/Package/readme.txt", modReadme.Text);

            // Do we have an empty database?
            if (!File.Exists(workingDirectory + "/data.sqlite"))
                generateSQL(workingDirectory);

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

        #region Adding and/or changing instructions
        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + "/data.sqlite"))
            {
                System.Windows.Forms.MessageBox.Show("Please save your project before continuing.", "Adding new instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            addInstruction ai = new addInstruction(workingDirectory, conn, 0, this);
            ai.Show();
        }

        private void instructions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int index = instructions.SelectedNode.Index;

            addInstruction ai = new addInstruction(workingDirectory, conn, instructions.SelectedNode.Index, this);
            ai.Show();
        }

        public void refreshInstructionTree()
        {
            if (!File.Exists(workingDirectory + "/data.sqlite"))
            {
                System.Windows.Forms.MessageBox.Show("Please save your project before continuing.", "Adding new instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Grab the data.
            string sql = "SELECT id, file, optional FROM instructions";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();

            instructions.BeginUpdate();
            instructions.Nodes.Clear();
            instructions.Nodes.Add("Instructions");
            int i = 1;
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string opt = "";
                if (Convert.ToInt32(reader["optional"]) == 1)
                    opt = " (optional)";
                instructions.Nodes.Add("id" + id, "Operation #" + i + " on file ROOT/" + reader["file"] + opt, id);
                i++;
            }
            instructions.EndUpdate();
        }

        private void delInstruction_Click(object sender, EventArgs e)
        {
            if (instructions.SelectedNode == null || instructions.SelectedNode.Index == 0)
                return;

            // Get rid of it.
            string sql = "DELETE FROM instructions WHERE id = " + instructions.SelectedNode.Index;
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            refreshInstructionTree();
        }

        private void instructionsRefresh_Click(object sender, EventArgs e)
        {
            refreshInstructionTree();
        }
        #endregion

        #region Generate database
        private void regenerateSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(workingDirectory))
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

        public bool generateSQL(string dir)
        {
            // Create the file.
            SQLiteConnection.CreateFile(dir + "/data.sqlite");

            // Immediately connect.
            conn = new SQLiteConnection("Data Source=\"" + dir + "/data.sqlite\";Version=3;");
            conn.Open();

            // Create our tables.
            string sql = "CREATE TABLE instructions(id INTEGER PRIMARY KEY, before VARCHAR(255), after VARCHAR(255), type VARCHAR(20), file VARCHAR(255), optional INTEGER)";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE hooks(id INTEGER PRIMARY KEY, hook_name VARCHAR(255), value VARCHAR(255))";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE files(id INTEGER PRIMARY KEY, file_name VARCHAR(255), destination VARCHAR(255))";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            return true;
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

        #region File list

        /*
         * A recursive method to populate a TreeView
         * Author: Danny Battison
         * Contact: gabehabe@googlemail.com
         */
        public void PopulateFileTree(string dir, TreeNode node)
        {
            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);

            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                // create a new node
                TreeNode t = new TreeNode(d.Name);
                // populate the new node recursively
                PopulateFileTree(d.FullName, t);
                node.Nodes.Add(t); // add the node to the "master" node
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                // create a new node
                TreeNode t = new TreeNode(f.Name);
                // add it to the "master"
                node.Nodes.Add(t);
            }
        }

        private void refreshFileListButton_Click(object sender, EventArgs e)
        {
            files.Nodes.Clear();
            files.Nodes.Add(new TreeNode("Files"));
            PopulateFileTree(workingDirectory, files.Nodes[0]);
        }

        #endregion
    }
}
