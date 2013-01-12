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
using System.Xml;
using System.Data.SQLite;

namespace ModBuilder
{
    public partial class loadProject : Form
    {
        public loadProject()
        {
            InitializeComponent();
        }

        public bool openProjDir(string dir)
        {
            // Check if the directory exists. Also should contain a package_info.xml.
            if (!Directory.Exists(dir) || !File.Exists(dir + "/Package/package-info.xml"))
                return false;

            // Start an instance of the mod editor.
            modEditor me = new modEditor();

            // Try to parse the package_info.xml.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(dir + "/Package/package-info.xml", settings);

            // Read it!
            #region Boring XML parsing
            using (reader)
            {
                // Read until we get to the ID element.
                reader.ReadToFollowing("id");
                string mid = reader.ReadElementContentAsString();
                me.modID.Text = mid;

                // Determine the mod author.
                string[] pieces = mid.Split(':');
                me.authorName.Text = pieces[0];

                // And the name element.
                reader.ReadToFollowing("name");
                me.modName.Text = reader.ReadElementContentAsString();
                me.Text = me.modName.Text + " - Mod Editor";

                // The version element.
                reader.ReadToFollowing("version");
                me.modVersion.Text = reader.ReadElementContentAsString();

                // Type.
                reader.ReadToFollowing("type");
                if (reader.ReadElementContentAsString() == "modification")
                    me.modType.SelectedItem = "Modification";
                else
                    me.modType.SelectedItem = "Avatar pack";

                // Move on to the install element to determine the compatibility range.
                reader.ReadToFollowing("install");
                reader.MoveToAttribute("for");
                me.modCompatibility.Text = reader.Value;
            }
            #endregion

            // Also load the readme.txt.
            if (File.Exists(dir + "/Package/readme.txt"))
                me.modReadme.Text = File.ReadAllText(dir + "/Package/readme.txt");

            if (File.Exists(dir + "/Package/install.php"))
                me.customCodeInstall.Text = File.ReadAllText(dir + "/Package/install.php");
            if (File.Exists(dir + "/Package/uninstall.php"))
                me.customCodeUninstall.Text = File.ReadAllText(dir + "/Package/uninstall.php");
            if (File.Exists(dir + "/Package/installDatabase.php"))
                me.installDatabaseCode.Text = File.ReadAllText(dir + "/Package/installDatabase.php");
            if (File.Exists(dir + "/Package/uninstallDatabase.php"))
                me.uninstallDatabaseCode.Text = File.ReadAllText(dir + "/Package/uninstallDatabase.php");

            if (!File.Exists(dir + "/data.sqlite"))
            {
                MessageBox.Show("A required database was not found in your project. It will now be created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                me.generateSQL(dir);

                MessageBox.Show("A database file has been successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            me.workingDirectory = dir;
            me.conn = new SQLiteConnection("Data Source=\"" + dir + "/data.sqlite\";Version=3;");
            me.conn.Open();
            me.hasConn = true;

            me.refreshInstructionTree();
            me.refreshExtractionTree();
            me.reloadSettings();
            me.PopulateFileTree(dir, me.files.Nodes[0]);

            // Checks.
            if (me.settings.ContainsKey("ignoreInstructions") || me.settings.ContainsKey("autoGenerateModID"))
            {
                MessageBox.Show("Your project does not contain all the required settings; please try to repair your project.", "Loading project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                me.conn.Close();
                return false;
            }

            if (me.settings["ignoreInstructions"] == "true")
                me.ignoreInstructions.Checked = true;

            if (me.settings["autoGenerateModID"] == "false")
                me.genPkgID.Checked = false;

            me.Show();

            return true;
        }
    }
}
