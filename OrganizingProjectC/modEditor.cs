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
using System.IO;

namespace OrganizingProjectC
{
    public partial class modEditor : Form
    {
        // Strings
        public string workingDirectory;

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

        private void modName_TextChanged(object sender, EventArgs e)
        {
            if (genPkgID.Checked == true && !string.IsNullOrEmpty(authorName.Text) && !string.IsNullOrEmpty(modName.Text))
            {
                string an = authorName.Text;
                an.Replace(" ", "");
                string mn = modName.Text;
                mn.Replace(" ", "");
                modID.Text = an + ":" + mn;
            }

            modName.BackColor = Color.White;
        }

        private void genPkgID_CheckedChanged(object sender, EventArgs e)
        {
            if (genPkgID.Checked == true)
            {
                modID.Enabled = false;
                if (genPkgID.Checked == true && !string.IsNullOrEmpty(authorName.Text) && !string.IsNullOrEmpty(modName.Text))
                {
                    string an = authorName.Text;
                    an.Replace(" ", "");
                    string mn = modName.Text;
                    mn.Replace(" ", "");
                    modID.Text = an + ":" + mn;
                }
            }
            else
                modID.Enabled = true;
        }

        private void authorName_TextChanged(object sender, EventArgs e)
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

        private void modID_TextChanged(object sender, EventArgs e)
        {
            modID.Text = modID.Text.Replace(" ", "");

            modID.BackColor = Color.White;
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xml;

            // TODO: Make the app avatar pack-compatible.
            Dictionary<string, string> types = new Dictionary<string, string>();

            types.Add("Modification", "modification");
            types.Add("Avatar pack", "avatar");
            string type = types[modType.Text];

            XmlWriterSettings xsettings = new XmlWriterSettings();



            xml = "<?xml version=\"1.0\"?>" +
"<!DOCTYPE package-info SYSTEM \"http://www.simplemachines.org/xml/package-info\">" + System.Environment.NewLine +
"<package-info xmlns=\"http://www.simplemachines.org/xml/package-info\" xmlns:smf=\"http://www.simplemachines.org/\">" + System.Environment.NewLine +
"   <id>" + modID.Text + "</id>" + System.Environment.NewLine +
"   <name>" + modName.Text + "</name>" + System.Environment.NewLine +
"   <type>" + type + "</type>";

            System.Windows.Forms.MessageBox.Show(xml);
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
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
                    return;
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
                return;
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
        }

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
    }
}
