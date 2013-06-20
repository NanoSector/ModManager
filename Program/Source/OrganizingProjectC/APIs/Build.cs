using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ModBuilder.APIs
{
    class Build
    {
        public bool buildPackageInfo(Dictionary<string, string> info, string output)
        {
            /*using (FileStream fileStream = new FileStream(output + "/package-info.xml", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fileStream))
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                // Some settings before we start.
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                // Start the document.
                writer.WriteStartDocument();

                // Doctype.
                writer.WriteDocType("package-info", null, "http://www.simplemachines.org/xml/package-info", null);

                // Some sort of generator copyright.
                if (info["copyright"] == "True")
                    writer.WriteComment("Generated with Mod Manager (c) 2013 Yoshi2889");

                // Write the package-info start element.
                writer.WriteStartElement("package-info", "http://www.simplemachines.org/xml/package-info");
                writer.WriteAttributeString("xmlns", "smf", null, "http://www.simplemachines.org/");

                // Write the ID.
                writer.WriteElementString("id", info["id"]);

                // Name.
                writer.WriteElementString("name", info["name"]);

                // Version.
                writer.WriteElementString("version", info["version"]);

                // Type. Either modification or avatar.
                writer.WriteElementString("type", info["type"]);

                // Installation instructions.
                writer.WriteStartElement("install");
                writer.WriteAttributeString("for", info["compatibility"]);

                // Readme.
                if (!string.IsNullOrEmpty(info["readme"]))
                {
                    writer.WriteStartElement("readme");
                    writer.WriteAttributeString("parsebbc", "true");
                    writer.WriteString("readme.txt");
                    writer.WriteEndElement();
                }

                // And installation XML.
                if (info["ignoreinstructions"] == "False" && numinst != 0)
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

            // Build succeeded!*/
            return true;
        }
    }
}
