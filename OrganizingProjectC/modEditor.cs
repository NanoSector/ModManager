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

            // Lets build the package_info.xml.
            XmlWriterSettings settings = new XmlWriterSettings();

            // Apply proper identation, if you'd please.
            settings.Indent = true;

            // Start the file.
            XmlWriter writer = XmlWriter.Create(workingDirectory + "/package-info.xml", settings);

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

            // End the element and document.
            writer.WriteEndElement();
            writer.WriteEndDocument();

            // Flush and end!
            writer.Flush();
            writer.Close();
        }
    }
}
