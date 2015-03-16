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
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
        }

        private void License_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Resources.license;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
