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
using ModBuilder.Forms;

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
            try
            {
                // Check if the directory exists. Also should contain a package_info.xml.
                if (!Directory.Exists(dir))
                    return false;

                // Start an instance of the mod editor.
                modEditor me = new modEditor();

                if (!File.Exists(dir + "/data.sqlite"))
                {
                    MessageBox.Show("A required database file was not found in your project. It will now be generated.", "Loading Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    me.generateSQL(dir);
                }

                me.workingDirectory = dir;
                me.conn = new SQLiteConnection("Data Source=\"" + dir + "/data.sqlite\";Version=3;");
                me.conn.Open();
                me.hasConn = true;

                me.refreshInstructionTree();
                me.refreshExtractionTree();
                me.reloadSettings();

                // Checks.
                if (!me.settings.ContainsKey("modName") || !me.settings.ContainsKey("mbVersion") || !me.settings.ContainsKey("ignoreInstructions") || !me.settings.ContainsKey("autoGenerateModID") || !me.settings.ContainsKey("includeModManLine"))
                {
                    MessageBox.Show("Your project does not include all the required settings. Please try to repair your project and try again.", "Loading Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    me.conn.Close();
                    me.Close();
                    return false;
                }

                // Compare the versions
                Version lmver = new Version(Properties.Settings.Default.minMbVersion);
                Version mver = new Version(me.settings["mbVersion"]);
                int status = mver.CompareTo(lmver);

                // If the status is equal to or bigger than 0 we are running the latest version.
                if (status < 0)
                {
                    MessageBox.Show("Your project is generated with an older version of Mod Builder, which used a different format. Please repair your project and try again.", "Loading Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    me.conn.Close();
                    me.Close();
                    return false;
                }

                me.modID.Text = me.settings["modID"];
                me.modName.Text = me.settings["modName"];
                me.modType.SelectedItem = me.settings["modType"];
                me.modVersion.Text = me.settings["modVersion"];
                me.authorName.Text = me.settings["modUser"];
                me.modCompatibility.Text = me.settings["modCompat"];
                me.Text = me.settings["modName"] + " - Mod Builder";

                if (me.settings["ignoreInstructions"] == "true")
                    me.ignoreInstructions.Checked = true;

                if (me.settings["autoGenerateModID"] == "true")
                    me.genPkgID.Checked = true;

                if (me.settings["includeModManLine"] == "true")
                    me.includeModManLine.Checked = true;

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

                me.Show();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
