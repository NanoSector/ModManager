using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SQLite;
using System.Xml.Linq;

namespace ModBuilder.Forms
{
    public partial class convertProject : Form
    {
        APIs.Notify message = new APIs.Notify();
        public convertProject()
        {
            InitializeComponent();
        }

        private void browseOutputDirectory_Click(object sender, EventArgs e)
        {
            // Show a new folder browser dialog.
            FolderBrowserDialog fb = new FolderBrowserDialog();

            // Set some settings.
            fb.Description = "Select the directory the project should be created in.";
            fb.ShowNewFolderButton = true;
            
            // Show it.
            DialogResult result = fb.ShowDialog();

            // Did we get a valid response?
            if (result != DialogResult.Cancel && !String.IsNullOrEmpty(fb.SelectedPath) && Directory.Exists(fb.SelectedPath))
            {
                // Being the nice program I am, I shall check if a project already exists in this directory.
                if (File.Exists(fb.SelectedPath + "/data.sqlite") && File.Exists(fb.SelectedPath + "/Package/package-info.xml"))
                {
                    DialogResult qresult = message.warning("Mod Manager has detected that a project already exists in the selected directory. Are you sure you want to continue and possibly overwrite the existing project?", MessageBoxButtons.YesNo);

                    // No? Quit.
                    if (qresult == DialogResult.No)
                        return;
                }

                // Update the textbox.
                outputDirectory.Text = fb.SelectedPath;
            }
        }

        private void browseInputPackageDirectory_Click(object sender, EventArgs e)
        {
            // Show a new folder browser dialog.
            FolderBrowserDialog fb = new FolderBrowserDialog();

            // Set some settings.
            fb.Description = "Select the directory the project should be created in.";
            fb.ShowNewFolderButton = true;
            
            // Show it.
            DialogResult result = fb.ShowDialog();

            // Did we get a valid response?
            if (result != DialogResult.Cancel && !String.IsNullOrEmpty(fb.SelectedPath) && Directory.Exists(fb.SelectedPath))
            {
                // Being the nice program I am, I shall check if a project already exists in this directory.
                if (!File.Exists(fb.SelectedPath + "/package-info.xml"))
                {
                    DialogResult qresult = message.warning("Mod Manager has detected that there is no package-info.xml in the package, so you will have to manually select any files in the package. Do you still want to continue?", MessageBoxButtons.YesNo);

                    // No? Quit.
                    if (qresult == DialogResult.No)
                        return;
                }

                // Clean out the old fields.
                packageInfoXMLPath.Text = "";
                installXmlPath.Text = "";
                readmeTXTPath.Text = "";
                installPHPPath.Text = "";
                uninstallPHPPath.Text = "";
                installDatabasePHPPath.Text = "";
                uninstallDatabasePHPPath.Text = "";

                // Update the textbox.
                packageInputPath.Text = fb.SelectedPath;

                #region Read the package-info.xml, if it exists.
                if (File.Exists(fb.SelectedPath + "/package-info.xml"))
                {
                    packageInfoXMLPath.Text = fb.SelectedPath + "\\package-info.xml";
                    
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Ignore;
                    XmlReader reader = XmlReader.Create(fb.SelectedPath + "/package-info.xml", settings);

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "install")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.Name == "modification")
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        installXmlPath.Text = fb.SelectedPath + "/" + reader.Value;
                                }

                                if (reader.Name == "code")
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        installPHPPath.Text = fb.SelectedPath + "/" + reader.Value;
                                }

                                if (reader.Name == "database")
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        installDatabasePHPPath.Text = fb.SelectedPath + "/" + reader.Value;
                                }

                                if (reader.Name == "readme")
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        if (File.Exists(fb.SelectedPath + "/" + reader.Value))
                                            readmeTXTPath.Text = fb.SelectedPath + "/" + reader.Value;
                                        else
                                            readmeTXTPath.Text = "Inline (package-info.xml)";
                                    }
                                }
                            }
                        }
                           
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "uninstall")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();

                                if (reader.Name == "code")
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        uninstallPHPPath.Text = fb.SelectedPath + "/" + reader.Value;
                                }

                                if (reader.Name == "database")
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        uninstallDatabasePHPPath.Text = fb.SelectedPath + "/" + reader.Value;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
        }

        #region Browse for files
        private string browseFile(string description, string filter)
        {
            // New file browser.
            OpenFileDialog of = new OpenFileDialog();

            // Set the description and alike.
            of.CheckFileExists = true;
            of.InitialDirectory = (!String.IsNullOrEmpty(packageInputPath.Text) ? packageInputPath.Text : "");
            of.Title = (!String.IsNullOrEmpty(description) ? description : "Select a file...");
            of.Filter = (!String.IsNullOrEmpty(filter) ? filter : "All files|*.*");

            // Show the dialog.
            of.ShowDialog();

            // Did we get a valid input?
            if (!string.IsNullOrEmpty(of.FileName) || !File.Exists(of.FileName))
                return "false";

            // We did. Now return it.
            return of.FileName;
        }

        private void browsePackageInfoXML_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the package-info.xml file...", "XML files|*.xml");

            if (result == "false")
                return;

            packageInfoXMLPath.Text = result;
        }

        private void browseReadmeTXT_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the file containing your readme...", "TXT files|*.txt");

            if (result == "false")
                return;

            readmeTXTPath.Text = result;
        }

        private void browseInstallXML_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the XML file containing your installation instructions...", "XML files|*.xml");

            if (result == "false")
                return;

            installXmlPath.Text = result;
        }

        private void browseInstallPHP_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the PHP file containing code to be run on installation...", "PHP files|*.php");

            if (result == "false")
                return;

            installPHPPath.Text = result;
        }

        private void browseUninstallPHP_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the PHP file containing code to be run on deinstallation...", "PHP files|*.php");

            if (result == "false")
                return;

            uninstallPHPPath.Text = result;
        }

        private void browseInstallDatabasePHP_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the PHP file containing database code to be run on installation...", "PHP files|*.php");

            if (result == "false")
                return;

            installDatabasePHPPath.Text = result;
        }

        private void browseUninstallDatabasePHP_Click(object sender, EventArgs e)
        {
            string result = browseFile("Select the PHP file containing code to be run on deinstallation...", "PHP files|*.php");

            if (result == "false")
                return;

            uninstallDatabasePHPPath.Text = result;
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            modEditor me = new modEditor();

            me.generateSQL(outputDirectory.Text);

            // Parse the XML again.
            #region Read the package-info.xml, if it exists.
            if (File.Exists(installXmlPath.Text))
            {
                #region Obsolete code
                /*
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Ignore;
                XmlReader reader = XmlReader.Create(installXmlPath.Text, settings);

                // Some variables which will be reset.
                string filename = "";
                string position = "";
                string search = "";
                string add = "";
                string temp = "";
                bool optional = false;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "file")
                    {
                        filename = reader.GetAttribute("name");
                        if (reader.GetAttribute("error") == "skip")
                            optional = true;

                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "operation")
                            {
                                string sql = "INSERT INTO instructions(id, before, after, type, file, optional) VALUES(null, @beforeText, @afterText, @type, @fileEdited, @optional)";

                                // Create the query.
                                SQLiteCommand command = new SQLiteCommand(sql, me.conn);
                                Console.WriteLine("File: " + filename);
                                command.Parameters.AddWithValue("@fileEdited", filename);
                                command.Parameters.AddWithValue("@optional", optional);

                                while (reader.NodeType != XmlNodeType.EndElement)
                                {
                                    reader.Read();
                                    if (reader.Name == "search")
                                    {
                                        temp = reader.GetAttribute("position");
                                        message.information(temp, MessageBoxButtons.OK);

                                        switch (temp)
                                        {
                                            case "before":
                                                position = "add_before";
                                                break;
                                            case "after":
                                                position = "add_after";
                                                break;
                                            case "end":
                                                position = "end";
                                                break;
                                            case "":
                                                continue;
                                            default:
                                                position = "replace";
                                                break;
                                        }

                                        command.Parameters.AddWithValue("@type", position);
                                        Console.WriteLine("Position: " + position);

                                        if (reader.NodeType == XmlNodeType.Text)
                                        {
                                            search = reader.Value;
                                            command.Parameters.AddWithValue("@beforeText", search);
                                            Console.WriteLine("Search: " + search);
                                        }
                                    }
                                    if (reader.Name == "add")
                                    {
                                        add = reader.Value;
                                        command.Parameters.AddWithValue("@afterText", add);
                                    }
                                }

                                //command.ExecuteNonQuery();
                            }
                        }
                    }
                }*/
                #endregion

                XmlDocument doc = new XmlDocument();
                doc.Load(installXmlPath.Text);


            }
            #endregion
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Just close.
            Close();
        }
    }
}