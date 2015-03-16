using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod_Builder.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fugueLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://p.yusukekamiyamane.com/");
            }
            catch { }
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Yoshi2889/ModManager/");
            }
            catch { }
        }

        private void viewLicense_Click(object sender, EventArgs e)
        {
            License li = new License();
            li.ShowDialog();
        }
    }
}
