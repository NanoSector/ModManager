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

namespace OrganizingProjectC
{
    public partial class modEditor : Form
    {
        public modEditor()
        {
            InitializeComponent();
        }

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
            {
                modID.Enabled = true;
            }
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


            xml = "<?xml version=\"1.0\"?>" +
"<!DOCTYPE package-info SYSTEM \"http://www.simplemachines.org/xml/package-info\">" + System.Environment.NewLine +
"<package-info xmlns=\"http://www.simplemachines.org/xml/package-info\" xmlns:smf=\"http://www.simplemachines.org/\">" + System.Environment.NewLine +
"   <id>" + modID.Text + "</id>" + System.Environment.NewLine +
"   <name>" + modName.Text + "</name>" + System.Environment.NewLine +
"   <type>" + type + "</type>";

            System.Windows.Forms.MessageBox.Show(xml);

;
            File.WriteAllText("C:\\Users\\Rick\\Documents\\test.txt", xml);
        }
    }
}
