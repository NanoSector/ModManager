using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using ModBuilder.Forms;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text.RegularExpressions;

namespace ModBuilder
{
    public partial class modEditor : Form
    {
        // The big big Mod Editor class! Dozens of functions here, split up into regions for your convenience :)
        #region Strings and other variables.
        public string workingDirectory;
        public SQLiteConnection conn;
        public bool hasConn = false;
        public Dictionary<string, string> settings = new Dictionary<string,string>();
        //public bool changesPending = false; - For later :)
        #endregion

        #region Load
        // Shows the actual editor
        public modEditor()
        {
            InitializeComponent();
        }

        public void reloadSettings()
        {
            if (!hasConn)
                return;

            settings.Clear();

            string sql = "SELECT key, value FROM settings";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                settings.Add(reader["key"].ToString(), reader["value"].ToString());
            }
        }

        private void modEditor_Load(object sender, EventArgs e)
        {
            modType.SelectedItem = "Modification";

            string[] updates;

            // Grab the respective templates for every component that can handle templates.
            //ccodeInstallTemplates
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_install"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_install");
            else
            {
                updates = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_install");
                foreach (string file in updates)
                {
                    if (file.Split('.').Last() == "php")
                        ccodeInstallTemplates.Items.Add(file.Replace(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_install\", "").Replace(".php", ""));
                }
            }

            //ccodeUninstallTemplates
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_uninstall"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_uninstall");
            else
            {
                updates = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_uninstall");
                foreach (string file in updates)
                {
                    if (file.Split('.').Last() == "php")
                        ccodeUninstallTemplates.Items.Add(file.Replace(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_uninstall\", "").Replace(".php", ""));
                }
            }

            //adatabaseInstallTemplates
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install");
            else
            {
                updates = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install");
                foreach (string file in updates)
                {
                    if (file.Split('.').Last() == "php")
                        adatabaseInstallTemplates.Items.Add(file.Replace(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install\", "").Replace(".php", ""));
                }
            }

            //adatabaseUninstallTemplates
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install");
            else
            {
                updates = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_uninstall");
                foreach (string file in updates)
                {
                    if (file.Split('.').Last() == "php")
                        adatabaseUninstallTemplates.Items.Add(file.Replace(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_uninstall\", "").Replace(".php", ""));
                }
            }

            if (!File.Exists(Properties.Settings.Default.phppath))
            {
                cfeDBInstall.Enabled = false;
                cfeDBUninstall.Enabled = false;
                cfeInstallCode.Enabled = false;
                cfeUninstallCode.Enabled = false;
            }
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
            if (genPkgID.Checked == false)
            {
                string tmpstr = System.Text.RegularExpressions.Regex.Replace(modID.Text, @"[^a-zA-Z0-9:_-]", "");
                if (tmpstr.Length > 32)
                    genModIDWarn.Visible = true;
                else
                    genModIDWarn.Visible = false;

                modID.Text = tmpstr;
            }

            modID.BackColor = Color.White;
        }

        private void generateModID()
        {
            if (genPkgID.Checked == true && !string.IsNullOrEmpty(authorName.Text) && !string.IsNullOrEmpty(modName.Text))
            {
                string an = System.Text.RegularExpressions.Regex.Replace(authorName.Text, @"[^a-zA-Z0-9_-]", "");
                string mn = System.Text.RegularExpressions.Regex.Replace(modName.Text, @"[^a-zA-Z0-9_-]", "");
                string tmpstr = (an + ":" + mn);
                if (tmpstr.Length > 32)
                    tmpstr = tmpstr.Substring(0, 32);
                modID.Text = tmpstr;
            }
        }
        #endregion

        #region Mod builder
        private bool buildMod(string dir)
        {
            // If we don't have a working directory, we're screwed.
            if (string.IsNullOrEmpty(workingDirectory))
                return false;

            // Create a Package and Source directory if they do not exist.
            if (!Directory.Exists(workingDirectory + "/Package"))
                Directory.CreateDirectory(workingDirectory + "/Package");
            if (!Directory.Exists(workingDirectory + "/Source"))
                Directory.CreateDirectory(workingDirectory + "/Source");

            // Check if something is empty.
            if (String.IsNullOrEmpty(modName.Text) || String.IsNullOrEmpty(modVersion.Text) || String.IsNullOrEmpty(modType.Text) || String.IsNullOrEmpty(modID.Text) || String.IsNullOrEmpty(modCompatibility.Text))
            {
                // Yes it is, warn the user and reset to the main tab.
                modSettings.SelectedTab = modDetailsTab;

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

            if (modID.Text.Length > 32)
            {
                MessageBox.Show("The mod ID is too long. Please shorten it to (less than) 32 characters. Build aborted.", "Build", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Grab the amount of instructions.
            string csql = "SELECT count(id) FROM instructions";
            SQLiteCommand ccommand = new SQLiteCommand(csql, conn);
            SQLiteDataReader creader = ccommand.ExecuteReader();
            creader.Read();

            int numinst = Convert.ToInt32(creader[0]);

            // Lets build the package_info.xml.
            #region Build package-info.xml
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

                // Some sort of generator copyright.
                if (includeModManLine.Checked == true)
                    writer.WriteComment("Generated with Mod Manager (c) 2013 Yoshi2889");

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
                if (!string.IsNullOrEmpty(modReadme.Text))
                {
                    writer.WriteStartElement("readme");
                    writer.WriteAttributeString("parsebbc", "true");
                    writer.WriteString("readme.txt");
                    writer.WriteEndElement();
                }

                // And installation XML.
                if (!ignoreInstructions.Checked && numinst != 0)
                    writer.WriteElementString("modification", "install.xml");

                // If we have a custom install code text thing entered, now's the time to add it.
                if (!string.IsNullOrEmpty(customCodeInstall.Text))
                    writer.WriteElementString("code", "install.php");
                if (!string.IsNullOrEmpty(installDatabaseCode.Text))
                    writer.WriteElementString("database", "installDatabase.php");
                
                // Now for the extraction of files and/or dirs.
                if (hasConn)
                {
                    string sql = "SELECT id, file_name, destination FROM files";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (!File.Exists(workingDirectory + "\\Source\\" + reader["file_name"].ToString()) && Directory.Exists(workingDirectory + "\\Source\\" + reader["file_name"].ToString()))
                            writer.WriteStartElement("require-dir");
                        else
                            writer.WriteStartElement("require-file");

                        writer.WriteAttributeString("name", "files/" + reader["file_name"].ToString().Replace("\\", "/"));
                        writer.WriteAttributeString("destination", reader["destination"].ToString().Replace("\\", "/"));

                        writer.WriteEndElement();
                    }
                }

                // End the element and document.
                writer.WriteEndElement();

                // Uninstallation instructions!
                writer.WriteStartElement("uninstall");
                writer.WriteAttributeString("for", modCompatibility.Text);

                if (!ignoreInstructions.Checked && numinst != 0)
                {
                    writer.WriteStartElement("modification");
                    writer.WriteAttributeString("reverse", "true");
                    writer.WriteString("install.xml");
                    writer.WriteEndElement();
                }

                // Got custom uninstall code? Enter it.
                if (!string.IsNullOrEmpty(customCodeUninstall.Text))
                    writer.WriteElementString("code", "uninstall.php");
                if (!string.IsNullOrEmpty(uninstallDatabaseCode.Text))
                    writer.WriteElementString("database", "uninstallDatabase.php");


                if (hasConn)
                {
                    // Now for the deletion of files and dirs.
                    string sql2 = "SELECT id, file_name, type FROM files_delete";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, conn);
                    SQLiteDataReader reader2 = command2.ExecuteReader();

                    string intype = "";
                    while (reader2.Read())
                    {
                        switch (reader2["type"].ToString())
                        {
                            case "dir":
                                intype = "dir";
                                break;

                            default:
                                intype = "file";
                                break;
                        }
                        writer.WriteStartElement("remove-" + intype);
                        writer.WriteAttributeString("name", reader2["file_name"].ToString());
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();

                // Last but not least the end of the document.
                writer.WriteEndDocument();

                // Flush and end!
                writer.Flush();
                writer.Close();
            }
            #endregion

            // Some settings before we start writing install.xml.
            #region Build install.xml
            if (!ignoreInstructions.Checked)
            {

                if (numinst != 0)
                {
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

                        // Some sort of generator copyright.
                        if (includeModManLine.Checked == true)
                            writer.WriteComment("Generated with Mod Manager (c) 2013 Yoshi2889");

                        // Write the package-info start element.
                        writer.WriteStartElement("modification", "http://www.simplemachines.org/xml/modification");
                        writer.WriteAttributeString("xmlns", "smf", null, "http://www.simplemachines.org/");

                        // Write the ID.
                        writer.WriteElementString("id", modID.Text);

                        // Version.
                        writer.WriteElementString("version", modVersion.Text);

                        // Grab the data.
                        if (hasConn)
                        {
                            string sql = "SELECT id, before, after, type, file, optional FROM instructions ORDER BY file";
                            SQLiteCommand command = new SQLiteCommand(sql, conn);
                            SQLiteDataReader reader = command.ExecuteReader();

                            string lastfile = "";
                            string file = "";
                            bool hasstarted = false;
                            while (reader.Read())
                            {
                                if (string.IsNullOrEmpty(lastfile))
                                    lastfile = file;
                                file = Convert.ToString(reader["file"]);

                                if (lastfile != file && Properties.Settings.Default.groupInstructions)
                                {
                                    if (hasstarted)
                                        writer.WriteEndElement();
                                    writer.WriteStartElement("file");
                                    writer.WriteAttributeString("name", file);
                                }
                                else if (!Properties.Settings.Default.groupInstructions)
                                {
                                    writer.WriteStartElement("file");
                                    writer.WriteAttributeString("name", file);
                                }

                                writer.WriteStartElement("operation");
                                if (Convert.ToInt32(reader["optional"]) == 1)
                                    writer.WriteAttributeString("error", "skip");

                                writer.WriteStartElement("search");
                                string fintype = "";
                                switch (Convert.ToString(reader["type"]))
                                {
                                    case "add_before":
                                        fintype = "after";
                                        break;

                                    case "add_after":
                                        fintype = "before";
                                        break;

                                    case "replace":
                                        fintype = "replace";
                                        break;

                                    case "end":
                                        fintype = "end";
                                        break;
                                }

                                writer.WriteAttributeString("position", fintype);
                                if (fintype != "end")
                                {
                                    writer.WriteRaw("<![CDATA[" + Convert.ToString(reader["before"]).Replace("]]>", "]]]]><![CDATA[>") + "]]>");
                                }
                                // search end
                                writer.WriteEndElement();

                                writer.WriteStartElement("add");
                                writer.WriteRaw("<![CDATA[" + Convert.ToString(reader["after"]).Replace("]]>", "]]]]><![CDATA[>") + "]]>");
                                writer.WriteEndElement();

                                // operation end
                                writer.WriteEndElement();

                                if (!Properties.Settings.Default.groupInstructions)
                                    writer.WriteEndElement();

                                lastfile = file;
                                hasstarted = true;
                            }
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();

                        writer.Flush();
                        writer.Close();
                    }
                }
                else
                {
                    if (File.Exists(workingDirectory + "/Package/install.xml"))
                        File.Delete(workingDirectory + "/Package/install.xml");
                }
            }
            // If we did select to ignore the instructions part, delete the install.xml file. The data is stored in the database anyway.
            else if (ignoreInstructions.Checked && File.Exists(workingDirectory + "/Package/install.xml"))
                File.Delete(workingDirectory + "/Package/install.xml");
            #endregion

            #region Writing files

            // File -> string to write
            Dictionary<string, string> filesToHandle = new Dictionary<string, string>();

            // The readme.
            filesToHandle.Add("readme.txt", modReadme.Text);

            // Custom installation file.
            filesToHandle.Add("install.php", customCodeInstall.Text);

            // Custom uninstallation file.
            filesToHandle.Add("uninstall.php", customCodeUninstall.Text);

            // Custom database installation file.
            filesToHandle.Add("installDatabase.php", installDatabaseCode.Text);

            // Custom database deinstallation file.
            filesToHandle.Add("uninstallDatabase.php", uninstallDatabaseCode.Text);

            // For every file, perform a few operations.
            foreach (var pair in filesToHandle)
            {
                // If we have a valid check, write the file.
                if (!string.IsNullOrEmpty(pair.Value))
                    File.WriteAllText(workingDirectory + "/Package/" + pair.Key, pair.Value);

                // Else if we left out data for this file, remove it to save possible space and empty files in the package
                else if (string.IsNullOrEmpty(pair.Value) && File.Exists(workingDirectory + "/Package/" + pair.Key))
                    File.Delete(workingDirectory + "/Package/" + pair.Key);
            }
            #endregion

            // Do we have a database?
            if (!hasConn)
                generateSQL(workingDirectory);

            // Return true so we know.
            return true;
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Build the mod.
            bool result = buildMod(workingDirectory);

            if (result == false)
                MessageBox.Show("An error occured while building your mod. Please try again.", "Build", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Mod Saver
        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set up a dictionary for the settings to be updated.
            Dictionary<string, string> update = new Dictionary<string, string>();

            // And our actual settings.
            update.Add("ignoreInstructions", ignoreInstructions.Checked.ToString().ToLower());
            update.Add("autoGenerateModID", genPkgID.Checked.ToString().ToLower());
            update.Add("includeModManLine", includeModManLine.Checked.ToString().ToLower());
            update.Add("modName", modName.Text);
            update.Add("modVersion", modVersion.Text);
            update.Add("modType", modType.Text);
            update.Add("modCompat", modCompatibility.Text);
            update.Add("modUser", authorName.Text);
            update.Add("modID", modID.Text);

            // If we have no working directory yet, prompt for one.
            if (!Directory.Exists(workingDirectory))
            {
                // Show our known folderbrowserdialog.
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.ShowNewFolderButton = true;
                fb.Description = "Please choose a folder to save your project to.";
                fb.ShowDialog();

                // Avoid error messages when we clicked Cancel.
                if (string.IsNullOrEmpty(fb.SelectedPath))
                    return;

                // Rare scenario, yet possible.
                if (!Directory.Exists(fb.SelectedPath))
                {
                    MessageBox.Show("An error occured while saving your project, the destination directory does not exist.", "Saving project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate a new SQL file.
                generateSQL(fb.SelectedPath, true, update);

                // Set the working directory.
                workingDirectory = fb.SelectedPath;

                // Reload the settings.
                reloadSettings();
            }

            // Update our settings when we have a connection.
            if (hasConn)
            {


                // Loop through each to update them.
                SQLiteCommand updatecommand;
                foreach (var pair in update)
                {
                    // Don't do anything if the value is the same.
                    if (settings[pair.Key] == pair.Value)
                        continue;

                    // Set up our query.
                    updatecommand = new SQLiteCommand("UPDATE settings SET value = @value WHERE key = @key", conn);
                    updatecommand.Parameters.AddWithValue("@key", pair.Key);
                    updatecommand.Parameters.AddWithValue("@value", pair.Value);

                    // And execute the command.
                    updatecommand.ExecuteNonQuery();
                }
            }

            // Build the mod.
            bool result = buildMod(workingDirectory);

            // Did we get an error from the builder?
            if (result == false)
            {
                MessageBox.Show("An error occured while saving your project. Please try again or try repairing your project.", "Saving project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nope, we must have a connection now.
            hasConn = true;

            // Also update the title with the mod title.
            this.Text = modName.Text + " - Mod Editor";
        }
        #endregion

        #region Help texts

        private void showHelp(string text)
        {
            MessageBox.Show(text, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            showHelp("The compatibility range is important, because it defines the versions of SMF that work with your modification. We recommend you use 2.0 - 2.0.99 as your compatibility range when developing your mod for the 2.x branch, and 1.1 - 1.1.99 when developing for the 1.1.x branch.");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            showHelp("This field is not required when you want to enter your own mod ID. It helps the generator in creating a unique mod ID and is not used in your mod.");
        }

        private void filesHelp_Click(object sender, EventArgs e)
        {
            showHelp("This screen gives you a brief overview of all the files, including project files, in your project. Click on the \"Open directory\" button to open the project in Windows Explorer.");
        }

        private void readmeHelp_Click(object sender, EventArgs e)
        {
            showHelp("This screen allows you to enter a detailed description of your modification. A few examples of topic to handle would be your mods features, a link to contact the author and what the mod should do once installed. You may use Bulletin Board Code (BBCode) tags here.");
        }

        private void instructionHelp_Click(object sender, EventArgs e)
        {
            showHelp("This area allows you to specify any custom edits to be made to SMFs files. Click \"Add instruction\" to get started.");
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
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Adding instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            addInstruction ai = new addInstruction(workingDirectory, conn, 0, this);
            ai.Show();
        }

        private void instructions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Editing instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tindex = instructions.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));

            addInstruction ai = new addInstruction(workingDirectory, conn, index, this);
            ai.Show();
        }

        public void refreshInstructionTree()
        {
            if (!File.Exists(workingDirectory + "/data.sqlite"))
            {
                MessageBox.Show("Please save your project before continuing.", "Refreshing instructions", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            instructions.Nodes.Add(i - 1 + " instructions total.");
            instructions.EndUpdate();
        }

        private void delInstruction_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Deleting instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tindex = instructions.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));

            // Get rid of it.
            string sql = "DELETE FROM instructions WHERE id = " + index;
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            refreshInstructionTree();
        }

        private void instructionsRefresh_Click(object sender, EventArgs e)
        {
            refreshInstructionTree();
        }
        #endregion

        #region Mod Settings
        private bool isEditing = false;
        private int editing = -1;

        private void button9_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Adding setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(settingName.Text))
            {
                MessageBox.Show("You need to enter a setting name.", "Adding setting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Regex r = new Regex(@"^[a-zA-Z0-9_\-]*$");
            if (!r.IsMatch(settingName.Text))
            {
                MessageBox.Show("Only alphabetic characters (a to z, lower and uppercase, and numbers), underscores and minuses are allowed in setting names.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(settingValue.Text))
            {
                DialogResult res = MessageBox.Show("You have not entered a default value for the setting. Do you still want to add it?", "Adding setting", MessageBoxButtons.OK, MessageBoxIcon.Question);

                if (res == DialogResult.No)
                    return;
            }

            // Inserting a new one?
            if (isEditing == false || editing == -1)
            {
                // First lets check if the key doesn't already exist.
                string sql = "SELECT id, key, value FROM modsettings WHERE key = @key";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.Parameters.AddWithValue("@key", settingName.Text);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show("A setting with the same name already exists. Please think of a different name.", "Adding setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Then do the actual updating.
                sql = "INSERT INTO modsettings(key, value) VALUES(@key, @value)";

                // Create the query.
                command = new SQLiteCommand(sql, conn);

                command.Parameters.AddWithValue("@key", settingName.Text);
                command.Parameters.AddWithValue("@value", settingValue.Text);

                command.ExecuteNonQuery();

                refreshSettingTree();

                settingName.Text = "";
                settingValue.Text = "";
            }

            // No? Editing, then.
            else
            {
                string sql = "UPDATE modsettings SET key = @key, value = @value WHERE id = @id";

                // Create the query.
                SQLiteCommand command = new SQLiteCommand(sql, conn);

                command.Parameters.AddWithValue("@id", editing);
                command.Parameters.AddWithValue("@key", settingName.Text);
                command.Parameters.AddWithValue("@value", settingValue.Text);

                command.ExecuteNonQuery();

                refreshSettingTree();

                settingName.Text = "";
                settingValue.Text = "";
                modSettingsCancel.Visible = false;
                msDelete.Visible = false;
                button9.Text = "Add setting";
                addSettingBox.Text = "Add a new setting";
                isEditing = false;
                editing = -1;
            }
        }
        public void refreshSettingTree()
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Refreshing instructions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Start updating.
            modSettingsTree.BeginUpdate();
            modSettingsTree.Nodes.Clear();

            // Add what this is.
            modSettingsTree.Nodes.Add("Custom mod settings");

            // Grab the data.
            int i = 1;
            string sql = "SELECT id, key, value FROM modsettings";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                modSettingsTree.Nodes.Add("id" + id, "Setting \"" + reader["key"] + "\"");
                i++;
            }
            modSettingsTree.Nodes.Add(i - 1 + " instructions total.");
            
            modSettingsTree.EndUpdate();
        }
        private void modSettingsTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Editing instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tindex = modSettingsTree.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));

            string sql = "SELECT id, key, value FROM modsettings WHERE id = @id";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.Parameters.AddWithValue("@id", index);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                settingName.Text = reader["key"].ToString();
                settingValue.Text = reader["value"].ToString();
                isEditing = true;
                editing = Convert.ToInt32(reader["id"]);
                modSettingsCancel.Visible = true;
                msDelete.Visible = true;
                button9.Text = "Update this setting";
                addSettingBox.Text = "Edit setting \"" + reader["key"] + "\"";
            }
        }
        private void modSettingsCancel_Click(object sender, EventArgs e)
        {
            settingName.Text = "";
            settingValue.Text = "";
            modSettingsCancel.Visible = false;
            msDelete.Visible = false;
            button9.Text = "Add setting";
            addSettingBox.Text = "Add a new setting";
            isEditing = false;
            editing = -1;
        }
        private void msDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM modsettings WHERE id = @id";

            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.Parameters.AddWithValue("@id", editing);
            command.ExecuteNonQuery();
            settingName.Text = "";
            settingValue.Text = "";
            modSettingsCancel.Visible = false;
            msDelete.Visible = false;
            button9.Text = "Add setting";
            addSettingBox.Text = "Add a new setting";
            isEditing = false;
            editing = -1;
            refreshSettingTree();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            refreshSettingTree();
        }
        #endregion

        #region Extracting files
        public void refreshExtractionTree()
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Refreshing instructions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Allow us to update.
            extractFiles.BeginUpdate();
            extractFiles.Nodes.Clear();

            // Add a "header" node.
            extractFiles.Nodes.Add("Files to be extracted on install");
            int i = 1;
            string sql = "SELECT id, file_name, destination FROM files";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                extractFiles.Nodes.Add("id" + id, "Extract \"" + reader["file_name"] + "\" to \"" + reader["destination"] + "\"");
                i++;
            }
            extractFiles.Nodes.Add(i - 1 + " instructions total.");
            extractFiles.EndUpdate();

            deleteFiles.BeginUpdate();
            deleteFiles.Nodes.Clear();
            deleteFiles.Nodes.Add("Files to be removed on uninstall");
            sql = "SELECT id, file_name FROM files_delete";
            command = new SQLiteCommand(sql, conn);
            reader = command.ExecuteReader();
            i = 1;
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                deleteFiles.Nodes.Add("id" + id, "Remove \"" + reader["file_name"] + "\"", id);
                i++;
            }
            deleteFiles.Nodes.Add(i - 1 + " instructions total.");
            deleteFiles.EndUpdate();

            // While we are busy, also refresh the files.
            fileComboBoxE.Items.Clear();
            fileComboBoxE.Items.Add(" ");
            refreshComboboxList(workingDirectory + "\\Source");
        }

        public void refreshComboboxList(string dir)
        {

            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);

            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {

                string name = d.FullName.Replace(workingDirectory + "\\Source\\", "");
                fileComboBoxE.Items.Add(name);
                refreshComboboxList(d.FullName);
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                string name = f.FullName.Replace(workingDirectory + "\\Source\\", "");
                // create a new node
                fileComboBoxE.Items.Add(name);
            }
        }

        private void extractionRefresh_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Refreshing instructions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            refreshExtractionTree();
        }

        private void createExtractionInstruction_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Create instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*addExtractionInstructionDialog aeid = new addExtractionInstructionDialog(workingDirectory, this, conn, 0);
            aeid.Show();*/

            if (string.IsNullOrEmpty(fileComboBoxE.SelectedItem.ToString()) || string.IsNullOrEmpty(filePrefixE.SelectedItem.ToString()))
            {
                MessageBox.Show("You did not fill in all fields; all fields are required.", "Saving instruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO files(id, file_name, destination) VALUES(null, @fileName, @destination)";

            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, conn);

            command.Parameters.AddWithValue("@fileName", fileComboBoxE.SelectedItem);
            string ext = "";
            if (!string.IsNullOrEmpty(fileNameE.Text))
                ext = "/" + fileNameE.Text;
            command.Parameters.AddWithValue("@destination", filePrefixE.SelectedItem + ext);

            command.ExecuteNonQuery();

            refreshExtractionTree();

            fileComboBoxE.SelectedItem = " ";
            filePrefixE.SelectedItem = " ";
            fileNameE.Text = "";
        }

        private void extractFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Editing instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tindex = extractFiles.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));
            addExtractionInstructionDialog aeid = new addExtractionInstructionDialog(workingDirectory, this, conn, index);
            aeid.Show();
        }

        private void deleteExtractButton_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Delete instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (extractFiles.SelectedNode == null)
                return;
            var tindex = extractFiles.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));

            // Get rid of it.
            string sql = "DELETE FROM files WHERE id = " + index;
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            refreshExtractionTree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Adding instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*addDeletionInstructionDialog adid = new addDeletionInstructionDialog(workingDirectory, this, conn, 0);
            adid.Show();*/

            if (string.IsNullOrEmpty(fileNameD.Text) || string.IsNullOrEmpty(filePrefixD.SelectedItem.ToString()))
            {
                MessageBox.Show("You did not fill in all fields; all fields are required.", "Adding instruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (whatIs_Dir.Checked == false && whatIs_File.Checked == false)
            {
                MessageBox.Show("Please select the type of the item you want to delete before continuing.", "Adding instruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO files_delete(id, file_name, type) VALUES(null, @fileName, @type)";

            string type = "";
            if (whatIs_Dir.Checked == true)
                type = "dir";
            else
                type = "file";


            // Create the query.
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.Parameters.AddWithValue("@fileName", filePrefixD.SelectedItem + "/" + fileNameD.Text);
            command.Parameters.AddWithValue("@type", type);

            command.ExecuteNonQuery();
            refreshExtractionTree();
            filePrefixD.SelectedItem = " ";
            fileNameD.Text = "";
            whatIs_Dir.Checked = false;
            whatIs_File.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Delete instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tindex = deleteFiles.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));

            // Get rid of it.
            string sql = "DELETE FROM files_delete WHERE id = " + index;
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            refreshExtractionTree();
        }

        private void deleteFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!hasConn)
            {
                MessageBox.Show("Please save your project before continuing.", "Editing instruction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tindex = deleteFiles.SelectedNode.Name;
            if (String.IsNullOrEmpty(tindex))
                return;
            int index = Convert.ToInt32(tindex.Replace("id", ""));

            addDeletionInstructionDialog ai = new addDeletionInstructionDialog(workingDirectory, this, conn, index);
            ai.Show();
        }
        #endregion

        #region Generate database
        private void regenerateSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If we have no working directory set, we have no saved project here or the project has become corrupt. Either way, cancel.
            if (!Directory.Exists(workingDirectory))
            {
                MessageBox.Show("Either your project is not saved or you have a corrupted project. Please try saving your project.", "Regenerating SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmation...
            DialogResult result = MessageBox.Show("Are you sure you want to regenerate the database file? You will lose all your data!", "Regenrating SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // They're sure. Lets start.
            if (result == DialogResult.Yes)
            {
                // Close any open connection we may have.
                if (hasConn)
                    conn.Close();

                // Try to delete the file; catch an IOException when it occurs.
                try
                {
                    File.Delete(workingDirectory + "/data.sqlite");
                }
                catch (IOException)
                {
                    MessageBox.Show("The database file is in use by another process. Please try again in a few seconds.", "Regenerating SQL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Then regenerate the SQL file.
                generateSQL(workingDirectory);

                // Information.
                MessageBox.Show("A new database has been generated. Your project will now be reloaded.", "Regenerating SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // And reload the project to take advantage of the changes.
                loadProject lp = new loadProject();
                lp.Show();
                lp.openProjDir(workingDirectory);
                lp.Close();
                Close();
            }
        }

        public bool generateSQL(string dir, bool deleteFile = true, Dictionary<string, string> addSettings = null)
        {
            // Create the file.
            if (deleteFile)
            {
                // If we have a connection, close it.
                if (hasConn)
                    conn.Close();

                // Sleep to avoid exceptions.
                System.Threading.Thread.Sleep(100);

                // Create a new file.
                SQLiteConnection.CreateFile(dir + "/data.sqlite");
            }

            // Immediately connect.
            conn = new SQLiteConnection("Data Source=\"" + dir + "/data.sqlite\";Version=3;");
            conn.Open();

            // Trick the ME into believing that we have a valid connection, which we in fact have.
            hasConn = true;

            // Create our tables.
            string[] sqlcomm = new string[]
            {
                "CREATE TABLE IF NOT EXISTS instructions(id INTEGER PRIMARY KEY, before VARCHAR(255), after VARCHAR(255), type VARCHAR(20), file VARCHAR(255), optional INTEGER)",
                "CREATE TABLE IF NOT EXISTS hooks(id INTEGER PRIMARY KEY, hook_name VARCHAR(255), value VARCHAR(255))",
                "CREATE TABLE IF NOT EXISTS files(id INTEGER PRIMARY KEY, file_name VARCHAR(255), destination VARCHAR(255), type VARCHAR(255))",
                "CREATE TABLE IF NOT EXISTS files_delete(id INTEGER PRIMARY KEY, file_name VARCHAR(255), type VARCHAR(255))",
                "CREATE TABLE IF NOT EXISTS settings(key VARCHAR(255), value VARCHAR(255))",
                "CREATE TABLE IF NOT EXISTS modsettings(id INTEGER PRIMARY KEY, key VARCHAR(255), value VARCHAR(255))"
            };

            SQLiteCommand command;
            foreach (string sql in sqlcomm)
            {
                command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }

            // Reload the settings.
            reloadSettings();

            // If a setting doesn't exist, insert it.
            Dictionary<string, string> cset = new Dictionary<string, string>();
            
            // All our settings. Setting name => default value.
            cset.Add("mbVersion", Properties.Settings.Default.mbVersion);
            cset.Add("ignoreInstructions", "false");
            cset.Add("autoGenerateModID", "true");
            cset.Add("includeModManLine", "true");
            
            // Any custom ones?
            if (addSettings != null)
            {
                foreach (var pair in addSettings)
                {
                    // We no like errors.
                    if (cset.ContainsKey(pair.Key))
                        continue;

                    cset.Add(pair.Key, pair.Value);
                }
            }

            // Loop through each to add them.
            foreach (var pair in cset)
            {
                // If it already exists, skip this one.
                if (settings.ContainsKey(pair.Key))
                    continue;

                // Build our query.
                command = new SQLiteCommand("INSERT INTO settings(key, value) VALUES(@key, @value)", conn);

                // Set our parameters.
                command.Parameters.AddWithValue("@key", pair.Key);
                command.Parameters.AddWithValue("@value", pair.Value);

                // Then execute it.
                command.ExecuteNonQuery();
            }

            return true;
        }
        #endregion

        #region New project and Open project
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Just start an all new instance. Simple as that.
            modEditor me = new modEditor();

            // Some default values.
            me.genPkgID.Checked = true;
            me.includeModManLine.Checked = true;

            // Show the instance.
            me.Show();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show them the loading box.
            loadProject lp = new loadProject();
            lp.Show();

            // Get us a new FolderBrowserDialog
            CommonOpenFileDialog fb = new CommonOpenFileDialog();
            fb.IsFolderPicker = true;
            fb.Title = "Please select the directory that your project resides in.";
            fb.EnsurePathExists = true;
            fb.ShowDialog();

            // Get the path.
            string dir = fb.FileName;

            // Avoid the annoying An error occured dialog.
            if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir))
            {
                lp.Close();
                return;
            }

            // Load the project.
            bool stat = lp.openProjDir(dir);

            // Check the status.
            if (stat == false)
                MessageBox.Show("An error occured while loading the project, some files could not be found or the project is corrupt.", "Open project", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Tyvm!
            lp.Close();
        }
        #endregion

        #region Compiling mods
        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(workingDirectory) || !Directory.Exists(workingDirectory + "/Package") || !Directory.Exists(workingDirectory + "/Source"))
            {
                MessageBox.Show("Unable to compile project because not all required files are in place. Please save your project and try again.", "Compiling project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the mod.
            buildMod(workingDirectory);

            SaveFileDialog sf = new SaveFileDialog();
            sf.AddExtension = true;
            sf.DefaultExt = "zip";
            sf.Filter = "Compressed files|*.zip";
            sf.InitialDirectory = workingDirectory;
            sf.CheckFileExists = false;
            sf.CheckPathExists = true;
            sf.ShowDialog();

            if (string.IsNullOrEmpty(sf.FileName))
                return;

            if (File.Exists(sf.FileName))
                File.Delete(sf.FileName);

            // Throw the package together.
            Directory.CreateDirectory(workingDirectory + "/tempcomp");

            DirectoryInfo tc = new DirectoryInfo(workingDirectory + "/tempcomp");
            DirectoryInfo pkg = new DirectoryInfo(workingDirectory + "/Package");
            DirectoryInfo src = new DirectoryInfo(workingDirectory + "/Source");

            // Copy everything in /Package to /tempcomp.
            CopyFilesRecursively(pkg, tc);

            // Now the files.
            if (Directory.GetFiles(workingDirectory + "/Source").Length != 0 || Directory.GetDirectories(workingDirectory + "/Source").Length != 0)
            {
                Directory.CreateDirectory(workingDirectory + "/tempcomp/files");
                DirectoryInfo tcf = new DirectoryInfo(workingDirectory + "/tempcomp/files");
                CopyFilesRecursively(src, tcf);
            }
            
            // Put it together.
            try
            {
                ZipFile.CreateFromDirectory(workingDirectory + "/tempcomp", sf.FileName);
                DeleteRecursively(new DirectoryInfo(workingDirectory + "/tempcomp"));
                MessageBox.Show("Your package has been compiled.", "Mod Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DeleteRecursively(new DirectoryInfo(workingDirectory + "/tempcomp"));
                MessageBox.Show("Something went wrong while compiling your package. Please try again.", "Compiling project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }
        public static void DeleteRecursively(DirectoryInfo source)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                DeleteRecursively(dir);
            foreach (FileInfo file in source.GetFiles())
                File.Delete(file.FullName);

            Directory.Delete(source.FullName);
        }
        #endregion

        #region Unload SQL
        private void modEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasConn)
                conn.Close();
        }
        #endregion

        #region BBCode Editor
        private void insertBBC(string tag, bool close = true)
        {
            string insert1 = "[" + tag + "]";
            int selectstart = modReadme.SelectionStart;
            string text = modReadme.Text.Insert(selectstart, insert1);
            modReadme.Text = text;

            // Or the end tag?
            if (close)
            {
                text = modReadme.Text.Insert((selectstart + insert1.Length), "[/" + tag + "]");
                modReadme.Text = text;
            }

            modReadme.Focus();
            modReadme.SelectionStart = (selectstart + insert1.Length);
            modReadme.SelectionLength = 0;
        }
        
        private void bbcbutton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            insertBBC(btn.Text.ToLower());
        }
        #endregion

        #region Templates
        private void ccodeInstallTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_install\" + ccodeInstallTemplates.SelectedItem.ToString() + ".php"))
            {
                string tcontents = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_install\" + ccodeInstallTemplates.SelectedItem.ToString() + ".php");
                customCodeInstall.Text = tcontents;
            }
            else
                MessageBox.Show("The requested template does not exist!", "Calling template", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ccodeUninstallTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_uninstall\" + ccodeUninstallTemplates.SelectedItem.ToString() + ".php"))
            {
                string tcontents = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\templates\code_uninstall\" + ccodeUninstallTemplates.SelectedItem.ToString() + ".php");
                customCodeUninstall.Text = tcontents;
            }
            else
                MessageBox.Show("The requested template does not exist!", "Calling template", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void adatabaseInstallTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install\" + adatabaseInstallTemplates.SelectedItem.ToString() + ".php"))
            {
                string tcontents = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install\" + adatabaseInstallTemplates.SelectedItem.ToString() + ".php");
                installDatabaseCode.Text = tcontents;
            }
            else
                MessageBox.Show("The requested template does not exist!", "Calling template", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void adatabaseUninstallTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install\" + adatabaseUninstallTemplates.SelectedItem.ToString() + ".php"))
            {
                string tcontents = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\templates\database_install\" + adatabaseUninstallTemplates.SelectedItem.ToString() + ".php");
                uninstallDatabaseCode.Text = tcontents;
            }
            else
                MessageBox.Show("The requested template does not exist!", "Calling template", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Code error checking

        private void checkCode(string code)
        {
            if (!File.Exists(Properties.Settings.Default.phppath))
            {
                MessageBox.Show("PHP was not found; can't check for errors.", "Checking code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Write the code to a temporary file.
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\temp.php", code);

            // Start a process.
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Properties.Settings.Default.phppath;
            p.StartInfo.Arguments = " \"" + AppDomain.CurrentDomain.BaseDirectory + "\\temp.php\"";
            p.Start();

            // Read the output.
            p.StandardOutput.ReadLine();
            string output = p.StandardOutput.ReadLine();

            // Grab the focus back!
            this.TopMost = true;
            this.TopMost = false;
            this.Activate();

            if (!String.IsNullOrWhiteSpace(output) && output.IndexOf("Parse error") != -1)
                MessageBox.Show(output.Replace(" in " + AppDomain.CurrentDomain.BaseDirectory + "temp.php", ""), "Checking code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (String.IsNullOrWhiteSpace(output))
                MessageBox.Show("No parse errors were detected", "Checking code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Something went wrong when checking for errors. Please check that the path to php.exe is set correctly and try again.", "Checking code", MessageBoxButtons.OK, MessageBoxIcon.Error);

            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\temp.php");
        }

        private void cfeInstallCode_Click(object sender, EventArgs e)
        {
            checkCode(customCodeInstall.Text);
        }

        private void cfeUninstallCode_Click(object sender, EventArgs e)
        {
            checkCode(customCodeUninstall.Text);
        }

        private void cfeDBInstall_Click(object sender, EventArgs e)
        {
            checkCode(installDatabaseCode.Text);
        }

        private void cfeDBUninstall_Click(object sender, EventArgs e)
        {
            checkCode(uninstallDatabaseCode.Text);
        }

        #endregion

        #region Various
        private void openProjectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workingDirectory))
                return;

            System.Diagnostics.Process.Start("explorer.exe", workingDirectory);
        }
    #endregion

    }
}
