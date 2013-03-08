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

                    XmlDocument doc = new XmlDocument();
                    doc.Load(fb.SelectedPath + "/package-info.xml");

                    foreach (XmlNode l_packageNode in doc.LastChild.ChildNodes)
                    {
                        if (l_packageNode.Name == "install")
                        {
                            foreach (XmlNode l_operationNode in l_packageNode.ChildNodes)
                            {
                                switch (l_operationNode.Name)
                                {
                                    case "modification":
                                        installXmlPath.Text = fb.SelectedPath + "/" + l_operationNode.InnerText;
                                        break;
                                    case "code":
                                        installPHPPath.Text = fb.SelectedPath + "/" + l_operationNode.InnerText;
                                        break;
                                    case "database":
                                        installDatabasePHPPath.Text = fb.SelectedPath + "/" + l_operationNode.InnerText;
                                        break;
                                    case "readme":
                                        if (File.Exists(fb.SelectedPath + "/" + l_operationNode.InnerText))
                                            readmeTXTPath.Text = fb.SelectedPath + "/" + l_operationNode.InnerText;
                                        else
                                            readmeTXTPath.Text = "Inline";
                                        break;
                                }
                            }
                        }
                        if (l_packageNode.Name == "uninstall")
                        {
                            foreach (XmlNode l_operationNode in l_packageNode.ChildNodes)
                            {
                                switch (l_operationNode.Name)
                                {
                                    case "code":
                                        uninstallPHPPath.Text = fb.SelectedPath + "/" + l_operationNode.InnerText;
                                        break;
                                    case "database":
                                        uninstallDatabasePHPPath.Text = fb.SelectedPath + "/" + l_operationNode.InnerText;
                                        break;
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
            if (!Directory.Exists(packageInputPath.Text))
            {
                message.error("Your input directory does not exist. Please select a different one.", MessageBoxButtons.OK);
                return;
            }

            if (!Directory.Exists(outputDirectory.Text))
                Directory.CreateDirectory(outputDirectory.Text);

            modEditor me = new modEditor();

            me.generateSQL(outputDirectory.Text);

            // Update a setting.
            string updatesql = "UPDATE settings SET value = \"false\" WHERE key = \"autoGenerateModID\"";
            SQLiteCommand ucomm = new SQLiteCommand(updatesql, me.conn);
            ucomm.ExecuteNonQuery();

            // Create a readme.txt if the text is inline.
            bool readmeTextInline = false;

            if (readmeTXTPath.Text == "Inline")
                readmeTextInline = true;

            // Parse the XML.
            #region Read the install.xml, if it exists.
            if (File.Exists(installXmlPath.Text))
            {
                XmlDocument l_document = new XmlDocument();
                l_document.Load(installXmlPath.Text);

                string filename = "";
                bool optional = false;
                string search = "";
                foreach (XmlNode l_fileNode in l_document.ChildNodes[l_document.ChildNodes.Count - 1].ChildNodes)
                {
                    if (l_fileNode.Name == "file")
                    {
                        filename = l_fileNode.Attributes["name"].Value;

                        if (l_fileNode.ChildNodes.Count > 0 && l_fileNode.ChildNodes[0].Name == "operation")
                        {
                            optional = l_fileNode.Attributes["error"].Value == "skip";
                            string sql = "INSERT INTO instructions(id, before, after, type, file, optional) VALUES(null, @beforeText, @afterText, @type, @fileEdited, @optional)";

                            // Create the query.
                            SQLiteCommand command = new SQLiteCommand(sql, me.conn);
                            command.Parameters.AddWithValue("@fileEdited", filename);
                            command.Parameters.AddWithValue("@optional", optional);

                            // Empty out the search var.
                            search = "";

                            foreach (XmlNode l_operationNode in l_fileNode.ChildNodes[0].ChildNodes)
                            {
                                switch (l_operationNode.Name)
                                {
                                    case "search":
                                        command.Parameters.AddWithValue("@type", l_operationNode.Attributes["position"].Value);

                                        if (l_operationNode.ChildNodes.Count > 0)
                                        {
                                            search = l_operationNode.ChildNodes[0].Value.Replace("\r", "\n").Replace("\n", "\r\n");
                                        }
                                        break;

                                    case "add":
                                        if (l_operationNode.ChildNodes.Count > 0)
                                        {
                                            command.Parameters.AddWithValue("@afterText", l_operationNode.ChildNodes[0].Value.Replace("\r", "\n").Replace("\n", "\r\n"));
                                        }
                                        break;
                                }
                            }

                            command.Parameters.AddWithValue("@beforeText", search);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            #endregion

            // Copy over any remaining files.
            Dictionary<string, string> pfiles = new Dictionary<string, string>();
            Directory.CreateDirectory(outputDirectory.Text + "/Package");
            Directory.CreateDirectory(outputDirectory.Text + "/Source");

            pfiles.Add("Package/package-info.xml", packageInfoXMLPath.Text);
            if (!string.IsNullOrEmpty(readmeTXTPath.Text))
                pfiles.Add("Package/readme.txt", readmeTXTPath.Text);
            if (!string.IsNullOrEmpty(installPHPPath.Text))
                pfiles.Add("Package/install.php", installPHPPath.Text);
            if (!string.IsNullOrEmpty(uninstallPHPPath.Text))
                pfiles.Add("Package/uninstall.php", uninstallPHPPath.Text);
            if (!string.IsNullOrEmpty(installDatabasePHPPath.Text))
                pfiles.Add("Package/installDatabase.php", installDatabasePHPPath.Text);
            if (!string.IsNullOrEmpty(uninstallDatabasePHPPath.Text))
                pfiles.Add("Package/uninstallDatabase.php", uninstallDatabasePHPPath.Text);

            foreach (var pair in pfiles)
            {
                if (!File.Exists(pair.Value))
                    continue;

                if (File.Exists(outputDirectory.Text + "/" + pair.Key))
                    File.Delete(outputDirectory.Text + "/" + pair.Key);

                File.Copy(pair.Value, outputDirectory.Text + "/" + pair.Key);
            }

            #region Read the package.xml, if it exists, for any further information.
            
            if (File.Exists(packageInfoXMLPath.Text))
            {
                XmlDocument l_document = new XmlDocument();
                l_document.Load(packageInfoXMLPath.Text);

                SQLiteCommand sql;
                string sqlquery;
                foreach (XmlNode l_packageNode in l_document.LastChild.ChildNodes)
                {
                    Console.WriteLine("Test node name: " + l_packageNode.Name);
                    if (l_packageNode.Name == "install")
                    {
                        foreach (XmlNode l_operationNode in l_packageNode.ChildNodes)
                        {
                            Console.WriteLine(
                                 "Test child node name: " + l_operationNode.Name);
                            switch (l_operationNode.Name)
                            {
                                case "readme":
                                    if (readmeTextInline)
                                        File.WriteAllText(outputDirectory.Text + "/Package/readme.txt", l_operationNode.InnerText.Replace("\r", "\n").Replace("\n", "\r\n"));
                                    break;
                                case "require-file":
                                     Console.WriteLine("File name: " + l_operationNode.Attributes["name"].Value);
                                     Console.WriteLine("Destination: " + l_operationNode.Attributes["destination"].Value);
                                     string[] pieces = l_operationNode.Attributes["name"].Value.Split('/');
                                     string lastpiece = pieces[pieces.Length - 1];

                                     if (!Directory.Exists(outputDirectory.Text + "/Source/" + l_operationNode.Attributes["name"].Value.Replace("/" + lastpiece, "")) && l_operationNode.Attributes["name"].Value != lastpiece)
                                         Directory.CreateDirectory(outputDirectory.Text + "/Source/" + l_operationNode.Attributes["name"].Value.Replace("/" + lastpiece, ""));

                                     File.Copy(packageInputPath.Text + "/" + l_operationNode.Attributes["name"].Value, outputDirectory.Text + "/Source/" + l_operationNode.Attributes["name"].Value, true);
                                     Console.WriteLine("Copied file");

                                    // Set up a query.
                                     sqlquery = "INSERT INTO files(id, file_name, destination) VALUES(null, @fileName, @destination)";
                                     sql = new SQLiteCommand(sqlquery, me.conn);

                                     sql.Parameters.AddWithValue("@fileName", l_operationNode.Attributes["name"].Value);
                                     sql.Parameters.AddWithValue("@destination", l_operationNode.Attributes["destination"].Value);

                                     sql.ExecuteNonQuery();

                                     break;
                                case "require-dir":
                                    // Just copy over the dir.
                                     DirectoryCopy(packageInputPath.Text + "/" + l_operationNode.Attributes["name"].Value, outputDirectory.Text + "/Source/" + l_operationNode.Attributes["name"].Value, true);

                                     // Set up a query.
                                     sqlquery = "INSERT INTO files(id, file_name, destination) VALUES(null, @fileName, @destination)";
                                     sql = new SQLiteCommand(sqlquery, me.conn);

                                     sql.Parameters.AddWithValue("@fileName", l_operationNode.Attributes["name"].Value);
                                     sql.Parameters.AddWithValue("@destination", l_operationNode.Attributes["destination"].Value);

                                     sql.ExecuteNonQuery();
                                    break;
                            }
                        }
                    }
                    if (l_packageNode.Name == "uninstall")
                    {
                        foreach (XmlNode l_operationNode in l_packageNode.ChildNodes)
                        {
                            switch (l_operationNode.Name)
                            {
                                case "remove-file":
                                    sqlquery = "INSERT INTO files_delete(id, file_name, type) VALUES(null, @fileName, @type)";
                                    sql = new SQLiteCommand(sqlquery, me.conn);
                                    sql.Parameters.AddWithValue("@fileName", l_operationNode.Attributes["name"].Value);
                                    sql.Parameters.AddWithValue("@type", "file");
                                    sql.ExecuteNonQuery();
                                    break;

                                case "remove-dir":
                                    sqlquery = "INSERT INTO files_delete(id, file_name, type) VALUES(null, @fileName, @type)";
                                    sql = new SQLiteCommand(sqlquery, me.conn);
                                    sql.Parameters.AddWithValue("@fileName", l_operationNode.Attributes["name"].Value);
                                    sql.Parameters.AddWithValue("@type", "dir");
                                    sql.ExecuteNonQuery();
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion

            me.Close();

            DialogResult result = message.information("Package has been converted, do you want to load it now?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                loadProject lp = new loadProject();
                lp.openProjDir(outputDirectory.Text);
            }
            Close();
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Just close.
            Close();
        }
    }
}