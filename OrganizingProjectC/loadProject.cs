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

namespace OrganizingProjectC
{
    public partial class loadProject : Form
    {
        public loadProject()
        {
            InitializeComponent();
        }

        private void loadProject_Load(object sender, EventArgs e)
        {

        }

        public Boolean openProjDir(string dir)
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
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "package-info")
                {
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();

                        // Grab the ID.
                        if (reader.Name == "id")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {

                                reader.Read();

                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    me.modID.Text = reader.Value;

                                    string[] pieces = reader.Value.Split(':');

                                    me.authorName.Text = pieces[0];
                                }

                            }

                            reader.Read();
                        }

                        // Grab the name.
                        if (reader.Name == "name")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {

                                reader.Read();

                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    me.modName.Text = reader.Value;
                                }

                            }

                            reader.Read();
                        }

                        // Version.
                        if (reader.Name == "version")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {

                                reader.Read();

                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    me.modVersion.Text = reader.Value;
                                }

                            }

                            reader.Read();
                        }

                        // Type.
                        if (reader.Name == "type")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {

                                reader.Read();

                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    if (reader.Value == "modification")
                                        me.modType.SelectedItem = "Modification";
                                    else
                                        me.modType.SelectedItem = "Avatar pack";
                                }

                            }

                            reader.Read();
                        }
                    }
                }

            }

            // Also load the readme.txt.
            if (File.Exists(dir + "/Package/readme.txt"))
                me.modReadme.Text = File.ReadAllText(dir + "/Package/readme.txt");

            if (!File.Exists(dir + "/data.sqlite"))
            {
                MessageBox.Show("A required database was not found in your project. It will now be created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                me.generateSQL(dir);

                MessageBox.Show("A database file has been successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            me.workingDirectory = dir;
            me.conn = new SQLiteConnection("Data Source=\"" + dir + "/data.sqlite\";Version=3;");

            me.Show();

            return true;
        }
    }
}
