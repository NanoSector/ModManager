using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

using System.Windows.Forms;


namespace ModBuilder.Classes
{
    class ModParser
    {
        public static Dictionary<string, string> parsePackageInfo(string input)
        {
            if (!File.Exists(input))
                return new Dictionary<string, string>();

            Dictionary<string, string> details = new Dictionary<string, string>();

            try
            {
                #region Boring XML parsing
                // Try to parse the package_info.xml.
                XmlTextReader xmldoc = new XmlTextReader(input);
                xmldoc.DtdProcessing = DtdProcessing.Ignore;
                while (xmldoc.Read())
                {
                    if (xmldoc.NodeType.Equals(XmlNodeType.Element))
                    {
                        switch (xmldoc.LocalName)
                        {
                            case "id":
                                string mid = xmldoc.ReadElementContentAsString();
                                details.Add("modID", mid);

                                // Determine the mod author.
                                string[] pieces = mid.Split(':');
                                details.Add("modUser", pieces[0]);
                                break;

                            case "name":
                                details.Add("modName", xmldoc.ReadElementContentAsString());
                                break;

                            case "version":
                                details.Add("modVersion", xmldoc.ReadElementContentAsString());
                                break;

                            case "type":
                                if (xmldoc.ReadElementContentAsString() == "modification")
                                    details.Add("modType", "Modification");
                                else
                                    details.Add("modType", "Avatar pack");
                                break;

                            case "install":
                                if (!details.ContainsKey("modCompat"))
                                    details.Add("modCompat", xmldoc.GetAttribute("for"));

                                break;
                        }
                    }
                }
                xmldoc.Close();
                #endregion
                return details;
            }
            catch
            {
                return new Dictionary<string, string>();
            }
        }
    }
}